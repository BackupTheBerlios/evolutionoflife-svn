'-------------------------------------------------------------------------------
'<copyright file="TaskFrame.vb" company="Microsoft">
'   Copyright (c) Microsoft Corporation. All rights reserved.
'</copyright>
'
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'-------------------------------------------------------------------------------

Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports System.Collections
Imports System.Runtime.InteropServices
Imports VbPowerPack.MiscFunctions



'=--------------------------------------------------------------------------=
' TaskFrame
'=--------------------------------------------------------------------------=
' These are the indidivudal frames that show up in the TaskPane control.  
' they have a caption bar across the top, which, while closely associated 
' with this TaskFrame (The properties on this class modify said caption
' bar), is not actually part of this control.
'
'
<LocalisableDescription("TaskFrame"), _
 DefaultProperty("Text"), _
 ToolboxItem(False), _
 DesignTimeVisible(False), _
 DefaultEvent("Click"), _
 Designer(GetType(Design.TaskFrameDesigner))> _
Public Class TaskFrame
    Inherits Panel



    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    ' Private member variables 
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '
    ' Indicates if we're in the process of actually doing some collapsing or
    ' expanding with this frame.
    '
    Friend Enum ActiveState

        Collapsing
        Collapsed
        Expanding
        Expanded

    End Enum ' ActiveState


    '
    ' What's going on with this frame.
    '
    Friend m_activeState As ActiveState

    '
    ' a reference to the CaptionBar tied to us.
    '
    Friend m_captionBar As CaptionBar

    '
    ' How much we're being shurnk or expanded at a time and what the original
    ' size was ....
    '
    Friend m_changeDelta As Integer
    Friend m_originalSize As Integer

    '
    ' The way the caption bar is painted.
    '
    Private m_captionBlend As BlendFill

    '
    ' Do we show our CollapseButton?
    '
    Private m_collapseButtonVisible As Boolean

    '
    ' This is the corner image we will display in the captionbar of this
    ' control.
    '
    Private m_image As Image

    '
    ' This is the 'mask' colour for the images.
    '
    Private m_imageTransparentColour As Color

    '
    ' Are we hidden because the user changed the Visible property, or
    ' because IsExpanded is False?
    '
    Private m_invisibleFromCollapse As Boolean


    '
    ' This is the high light color of the caption when the mouse is hovering 
    ' across the caption bar.
    '
    Private m_CaptionHighlightColor As Color


    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                    Public Methods/Properties/etc.
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Intializes a new instance of our class
    '
    Public Sub New()
        MyBase.New()

        Me.BackColor = colourDefaultBackground()
        Me.CaptionBlend = New BlendFill(BlendStyle.Horizontal, _
                                        colourCaptionBlendStart(), _
                                        colourCaptionBlendFinish())

        '
        ' Set up some reasonable defaults here for the properties.
        '   
        Me.m_collapseButtonVisible = True

        '
        ' Make sure we don't bother sending this to the HWND, since it
        ' will never see/use it.
        '
        setStyle(ControlStyles.CacheText, True)


        '
        ' Setting up our initial collapse/expand state.
        '
        Me.m_activeState = ActiveState.Expanded
        Me.m_invisibleFromCollapse = False


        Me.m_CaptionHighlightColor = System.Drawing.SystemColors.ActiveCaption

        '
        ' misc 
        '
        Me.m_imageTransparentColour = Color.Transparent

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' Image
    '=----------------------------------------------------------------------=
    ' The image we will display in the caption bar area.  The image is masked
    ' against the ImageTransparentColor on our parent TaskPane control.
    '
    ' Type:
    '       Image
    '
    <LocalisableDescription("TaskFrame.Image"), _
     Category("Appearance"), _
     DefaultValue(GetType(Image), Nothing), _
     Localizable(True)> _
    Public Property Image() As Image

        Get
            Return Me.m_image
        End Get

        '
        ' set the new image and tell the caption bar to refresh
        '
        Set(ByVal in_newImage As Image)

            Dim tp As TaskPane
            Dim b As Bitmap

            If Not in_newImage Is Me.m_image Then
                Me.m_image = in_newImage

                b = CType(Me.m_image, Bitmap)
                If Not b Is Nothing Then
                    tp = CType(Me.Parent, TaskPane)
                    If Not tp Is Nothing Then
                        Try
                            b.MakeTransparent(Me.ImageTransparentColor)
                        Catch ex As InvalidOperationException
                            ' In case developer selects an icon, we'll get this exception.
                            ' It's hard to differentiate between bitmap and icon from this property,
                            ' so ignore this exception.
                        End Try
                    End If
                End If
                If Not Me.m_captionBar Is Nothing Then
                    Me.m_captionBar.recomputeSizes()
                    Me.m_captionBar.Refresh()
                End If
            End If

        End Set

    End Property ' Image


    '=----------------------------------------------------------------------=
    ' ImageTransparentColor
    '=----------------------------------------------------------------------=
    ' This is the colour that the individual TaskFrames will use to mask the
    ' background of their Image properties for transparency.
    '
    ' Type:
    '       Color
    '
    <LocalisableDescription("TaskFrame.ImageTransparentColour"), _
     Category("Behavior"), _
     DefaultValue(GetType(Color), "Transparent"), _
     Localizable(True)> _
    Public Property ImageTransparentColor() As Color

        Get
            Return Me.m_imageTransparentColour
        End Get

        '
        ' set the new one, and then force a complete update of all the
        ' child frames in case they are using any of these ...
        '
        Set(ByVal in_newImageTransparentColor As Color)
            If Not in_newImageTransparentColor.Equals(Me.m_imageTransparentColour) Then
                Me.m_imageTransparentColour = in_newImageTransparentColor
                Me.Refresh()
            End If
        End Set

    End Property ' ImageTransparentColor


    '=----------------------------------------------------------------------=
    ' CollapseButtonVisible
    '=----------------------------------------------------------------------=
    ' Indicates whether or not we should show a button on our caption bar
    ' which will allow users to collapse or uncollapse us.
    '
    <LocalisableDescription("TaskFrame.CollapseButtonVisible"), _
     Category("Behavior"), _
     DefaultValue(True), _
     Localizable(True)> _
    Public Property CollapseButtonVisible() As Boolean

        Get
            Return Me.m_collapseButtonVisible
        End Get

        '
        ' set the new value and tell our caption bar to refresh
        '
        Set(ByVal in_newCollapseButtonVisible As Boolean)

            Me.m_collapseButtonVisible = in_newCollapseButtonVisible
            If Not Me.m_captionBar Is Nothing Then
                Me.m_captionBar.Refresh()
            End If

        End Set

    End Property ' CollapseButtonVisible


    '=----------------------------------------------------------------------=
    ' IsExpanded
    '=----------------------------------------------------------------------=
    ' Controls and/or indicates whether or not we are expanded at this point
    ' in time. Changing the value will cause the frame to collapse or 
    ' uncollapse itself.
    '
    <LocalisableDescription("TaskFrame.IsExpanded"), _
     Category("Behavior"), DefaultValue(True), _
     Localizable(True)> _
    Public Property IsExpanded() As Boolean

        Get

            '
            ' Please note that partially expanded frames will return
            ' True to this property.
            '
            If Me.m_activeState = ActiveState.Collapsed Then
                Return False
            Else
                Return True
            End If

        End Get

        '
        ' go ahead and start the process to collapse or expand the frame
        ' if appropriate.
        '
        Set(ByVal in_newIsExpanded As Boolean)

            Dim tp As TaskPane
            tp = CType(Me.Parent, TaskPane)

            '
            ' if the whole frame is hidden (indicated by our caption bar
            ' not being visible) or we have no HWND yet, then just force
            ' the full visible/invisible now.
            '
            If Me.m_captionBar Is Nothing _
               OrElse Not Me.m_captionBar.Visible _
               OrElse Not Me.m_captionBar.IsHandleCreated Then

                If in_newIsExpanded = True Then

                    '
                    ' If we're not already expanded, go and do this now.
                    '
                    If Not Me.m_activeState = ActiveState.Expanded Then
                        Me.Height = Me.m_originalSize
                    End If

                    Me.m_activeState = ActiveState.Expanded
                    Me.showWithoutCaptionBar()

                Else

                    '
                    ' If we're not already collapsed, just go and do this
                    ' now
                    '
                    If Not Me.m_activeState = ActiveState.Collapsed Then
                        If Me.m_activeState = ActiveState.Expanded Then
                            Me.m_originalSize = Me.Height
                        End If
                    End If

                    Me.m_activeState = ActiveState.Collapsed
                    Me.hideWithoutCaptionBar()

                End If

                If Not tp Is Nothing Then tp.layoutAllFrames()

            Else

                '
                ' Okay, the Frame is supposed to be visible (as indicated
                ' by the caption bar being visible) and we have an HWND,
                ' so go and start the slide open/closed.
                '
                If Me.m_activeState = ActiveState.Collapsed _
                   OrElse Me.m_activeState = ActiveState.Collapsing Then

                    '
                    ' We're already collapsed/ing, so we only have to do
                    ' something if they're asking us to expand ...
                    '
                    If in_newIsExpanded = True Then
                        tp.expandCollapseFrame(Me, False)
                    End If

                Else

                    ' 
                    ' We're expanded/ing, so only do something if they're
                    ' asking us to Collapse
                    '
                    If in_newIsExpanded = False Then
                        tp.expandCollapseFrame(Me, True)
                    End If

                End If

                '
                ' Repaint the caption bar!
                '
                Me.m_captionBar.Refresh()

            End If

        End Set

    End Property ' IsExpanded


    '=----------------------------------------------------------------------=
    ' CaptionBlend
    '=----------------------------------------------------------------------=
    ' This controls how the background is drawn. 
    '
    ' Type:
    '       VbPowerPack.BlendFill
    '
    <LocalisableDescription("TaskFrame.CaptionBlend"), _
     Category("Appearance"), _
     Localizable(True)> _
    Public Property CaptionBlend() As BlendFill

        Get
            Return Me.m_captionBlend
        End Get

        '
        ' set the new value, refresh, and fire a change event.
        '
        Set(ByVal in_newCaptionBlend As BlendFill)
            Me.m_captionBlend = in_newCaptionBlend
            If Not Me.m_captionBar Is Nothing Then Me.m_captionBar.Refresh()
        End Set

    End Property ' CaptionBlend


    '=----------------------------------------------------------------------=
    ' CaptionHighlightColor
    '=----------------------------------------------------------------------=
    ' This the color of the caption when the mouse is hovering across the  
    ' caption bar.
    '
    ' Type:
    '       System.Color
    '
    <LocalisableDescription("TaskFrame.CaptionHighlightColor"), _
     Category("Appearance"), _
     Localizable(True)> _
    Public Property CaptionHighlightColor() As Color

        Get
            Return Me.m_CaptionHighlightColor
        End Get

        Set(ByVal Value As Color)
            Me.m_CaptionHighlightColor = Value
        End Set

    End Property ' CaptionHighlightColor


    '=----------------------------------------------------------------------=
    ' Text
    '=----------------------------------------------------------------------=
    ' The text property on this control is very much visible.
    '
    <LocalisableDescription("TaskFrame.Text"), _
     Category("Appearance"), _
     Browsable(True), EditorBrowsable(EditorBrowsableState.Always), _
     Localizable(True)> _
    Public Overrides Property Text() As String

        Get
            Return MyBase.Text
        End Get

        Set(ByVal in_newText As String)
            MyBase.Text = in_newText
            If Not Me.m_captionBar Is Nothing Then
                Me.m_captionBar.Refresh()
            End If
        End Set

    End Property ' Text


    '=----------------------------------------------------------------------=
    ' Font
    '=----------------------------------------------------------------------=
    ' Overridden from our parent, because we need to tell our caption bar 
    ' when the Font changes ...
    '
    ' Type:
    '       Font
    '
    <LocalisableDescription("TaskFrame.Font"), _
     Category("Appearance"), _
     Localizable(True)> _
    Public Shadows Property Font() As Font

        Get
            Return MyBase.Font
        End Get

        '
        ' set the new value and tell our caption bar about it.
        '
        Set(ByVal in_newFont As Font)

            MyBase.Font = in_newFont
            If Not Me.m_captionBar Is Nothing Then
                Me.m_captionBar.setFontInternal(in_newFont)
            End If

        End Set

    End Property ' Font


    '=----------------------------------------------------------------------=
    ' Anchor
    '=----------------------------------------------------------------------=
    ' This property doesn't make sense for us as all sizing is controlled by
    ' the parent TaskPane
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property Anchor() As AnchorStyles

        Get
            Return MyBase.Anchor
        End Get

        Set(ByVal newAnchor As AnchorStyles)
            MyBase.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        End Set

    End Property ' Anchor


    '=----------------------------------------------------------------------=
    ' Dock
    '=----------------------------------------------------------------------=
    ' This property doesn't make sense for us as all sizing is controlled by
    ' the parent TaskPane
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property Dock() As DockStyle

        Get
            Return MyBase.Dock
        End Get

        Set(ByVal newDock As DockStyle)
            MyBase.Dock = newDock
        End Set

    End Property ' Dock


    '=----------------------------------------------------------------------=
    ' DockPadding
    '=----------------------------------------------------------------------=
    ' This property doesn't make sense for us as all sizing is controlled by
    ' the parent TaskPane
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows ReadOnly Property DockPadding() As DockPaddingEdges

        Get
            Return MyBase.DockPadding
        End Get

    End Property ' DockPadding


    '=----------------------------------------------------------------------=
    ' Visible
    '=----------------------------------------------------------------------=
    ' When we're made visible or invisible, we need to be sure to go and
    ' hide and/or reshow our associated caption bar control.
    '
    ' Type:
    '       Boolean
    '
    <LocalisableDescription("TaskFrame.Visible"), _
     Category("Behavior"), DefaultValue(True)> _
    Public Shadows Property Visible() As Boolean

        Get
            If Not Me.m_captionBar Is Nothing Then
                Return Me.m_captionBar.Visible
            Else
                Return False
            End If
        End Get

        '
        ' If they're giving us a different value, and it's not at design
        ' time, then set the new value.
        ' 
        Set(ByVal in_newVisible As Boolean)

            Try
                If Not Me.Parent Is Nothing Then
                    Me.Parent.SuspendLayout()
                End If

                '
                ' 2. Now go and show/hide us, depending on whether we're
                '    already hidden, and why.
                '
                If Not Me.m_invisibleFromCollapse Then
                    MyBase.Visible = in_newVisible
                End If

                '
                ' 1. Make sure our associated caption bar gets shown/hidden
                '
                Me.m_captionBar.setVisibleInternal(in_newVisible)

            Finally
                Me.Parent.ResumeLayout()
            End Try

        End Set

    End Property ' Visible


    '=----------------------------------------------------------------------=
    ' Enabled
    '=----------------------------------------------------------------------=
    ' When we're made Enabled or disabled, we need to be sure to go and
    ' enable and/or disable our buddy caption bar
    '
    ' Type:
    '       Boolean
    '
    <LocalisableDescription("TaskFrame.Enabled"), _
     Category("Behavior"), DefaultValue(True)> _
    Public Shadows Property Enabled() As Boolean

        Get
            Return MyBase.Enabled
        End Get

        '
        ' If they're giving us a different value, then set it
        '
        Set(ByVal in_newEnabled As Boolean)

            If Not Me.m_captionBar Is Nothing Then
                Me.m_captionBar.setEnabledInternal(in_newEnabled)
            End If
            MyBase.Enabled = in_newEnabled

        End Set

    End Property ' Enabled


    '=----------------------------------------------------------------------=
    ' ImeMode
    '=----------------------------------------------------------------------=
    ' TaskFrames don't have input, so this isn't terribly useful.
    '
    ' Type:
    '       ImeMode
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property ImeMode() As ImeMode

        Get
            Return MyBase.ImeMode
        End Get
        Set(ByVal Value As ImeMode)
            MyBase.ImeMode = Value
        End Set

    End Property ' ImeMode


    '=----------------------------------------------------------------------=
    ' RightToLeft
    '=----------------------------------------------------------------------=
    ' Make sure we update our caption bar appropriately.
    '
    ' Type:
    '       RightToLeft
    Public Overrides Property RightToLeft() As System.Windows.Forms.RightToLeft

        Get
            Return MyBase.RightToLeft
        End Get

        Set(ByVal Value As System.Windows.Forms.RightToLeft)
            MyBase.RightToLeft = Value
            If Not Me.m_captionBar Is Nothing Then Me.m_captionBar.Refresh()
        End Set

    End Property ' RightToLeft









    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                Private/Protected/Friend Subs/Functions
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' hideWithoutCaptionBar
    '=----------------------------------------------------------------------=
    ' Hides this TaskFrame without hiding our associated caption bar.  That's
    ' rather important, since every time we are collapsed, we are hidden to
    ' keep us out of the tab order, etc ...
    '
    '
    Protected Friend Sub hideWithoutCaptionBar()

        Me.m_invisibleFromCollapse = True
        MyBase.Visible = False

    End Sub ' hideWithoutCaptionBar


    '=----------------------------------------------------------------------=
    ' showWithoutCaptionBar
    '=----------------------------------------------------------------------=
    ' Shows this TaskFrame without affecting our associated caption bar.  
    ' That's rather important, since every time we are collapsed, we are
    ' hidden to keep us out of the tab order, etc ...
    '
    '
    Protected Friend Sub showWithoutCaptionBar()

        Me.m_invisibleFromCollapse = False
        MyBase.Visible = True

    End Sub ' showWithoutCaptionBar


    '=----------------------------------------------------------------------=
    ' getReallyVisible
    '=----------------------------------------------------------------------=
    ' Returns whether or not this actual TaskFrame control is visible, 
    ' regardless of the reasons it may not be.  Should only be needed by the
    ' layout code in the parent TaskPane itself.
    '
    ' Returns:
    '       Boolean             - whether this actual ctl is visible or not
    '
    Friend Function getReallyVisible() As Boolean

        Return MyBase.Visible

    End Function ' getReallyVisible


    '=----------------------------------------------------------------------=
    ' OnResize
    '=----------------------------------------------------------------------=
    ' Whenever the control is resized, we need to know about the change in
    ' height so we can set our original size to reflect this ...
    '
    Protected Overrides Sub OnResize(ByVal eventargs As System.EventArgs)

        If Me.m_activeState = ActiveState.Expanded Then
            Me.m_originalSize = Me.Height
        End If

        MyBase.OnResize(eventargs)

    End Sub ' OnResize









    '=----------------------------------------------------------------------=
    ' colourDefaultBackground
    '=----------------------------------------------------------------------=
    ' This returns the default background colour for our TaskFrame.
    '
    ' Returns:
    '       Color
    '
    Private Function colourDefaultBackground() As Color

        Return System.Drawing.SystemColors.InactiveCaptionText

    End Function ' colourDefaultBackground


    '=----------------------------------------------------------------------=
    ' colourCaptionBlendStart
    '=----------------------------------------------------------------------=
    ' Returns the start colour to be used to blend the caption bar.
    '
    ' Returns:
    '       Color
    '
    Private Function colourCaptionBlendStart() As Color

        Return SystemColors.Window

    End Function ' colourCaptionBlendStart


    '=----------------------------------------------------------------------=
    ' colourCaptionBlendFinish
    '=----------------------------------------------------------------------=
    ' Returns the finish colour to be used to blend the caption bar.
    '
    ' Returns:
    '       Color
    '
    Private Function colourCaptionBlendFinish() As Color

        Return MiscFunctions.ScaleColour(SystemColors.InactiveCaption, 125)

    End Function ' colourCaptionBlendFinish


End Class ' TaskFrame



