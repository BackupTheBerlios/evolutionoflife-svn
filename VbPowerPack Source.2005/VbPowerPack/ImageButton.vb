'-------------------------------------------------------------------------------
'<copyright file="ImageButton.vb" company="Microsoft">
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



'=--------------------------------------------------------------------------=
' ImageButton
'=--------------------------------------------------------------------------=
' this is a button class that lets the user specify images to control its
' behaviour, specifically, the normal image, the image to show when the mouse
' hovers over the control, and what to display when the button is listed as
' the default button
'
'
<DefaultProperty("NormalImage"), _
 DefaultEvent("Click"), _
 Designer(GetType(VbPowerPack.Design.ImageButtonDesigner))> _
Public Class ImageButton
    Inherits Control
    Implements IButtonControl

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    ' Private member variables and the likes
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    Private Const DISABLED_ALPHABLEND_VALUE As Integer = 75
    Private Const MAX_TEXT_WIDTH As Double = 250.0


    '
    ' Which image should be drawn right now?
    '
    Private Enum DrawState

        Normal
        Hover
        Pressed

    End Enum ' DrawState

    '
    ' The normal image to display
    '
    Private m_normalImage As Image

    '
    ' this is the disabled version of the normal image.  This can either
    ' be a property that the user has set on us (in which case we will use
    ' their version), or an image that we have generated ourselves.
    '
    Private m_disabledImage As Image
    Private m_disabledGenImage As Image

    '
    ' [optional] the image to display when the users presses the button
    '
    Private m_pressedImage As Image

    '
    ' [optional] the image to display as the mouse hovers o'er the button
    '
    Private m_hoverImage As Image

    '
    ' the current image we should be showing
    '
    Private m_drawState As DrawState

    '
    ' Should we draw a focus rect in the bounding rectangle for this 
    ' control when it has focus, or just leave everything well alone?
    '
    Private m_showFocusRect As Boolean

    '
    ' What Dialog result to return when the user clicks on the button.
    '
    Private m_dialogResult As DialogResult

    '
    ' We will use this colour to mask out the three images in case users
    ' aren't able to find a tool for creating images with truly transparent
    ' backgrounds!
    '
    Private m_transparentColour As Color

    '
    ' indicates where the text caption, if any, is drawn.
    '
    Private m_textAlign As ContentAlignment

    '
    ' How should we resize ourselves when images are set.
    '
    Private m_sizeMode As ImageButtonSizeMode




    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    ' Public Methods, Members, etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this control.
    '
    Public Sub New()

        MyBase.New()

        '
        ' These are values that let us act as a transparent object, as well
        ' as avoid flicker when painting.
        '
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)

        Me.m_drawState = DrawState.Normal
        Me.m_showFocusRect = True
        Me.m_dialogResult = DialogResult.OK
        Me.m_transparentColour = Color.Transparent
        Me.m_sizeMode = ImageButtonSizeMode.AutoSize

        '
        ' default text settings are for no text, but if there has to be
        ' some, then put it below the images.
        '
        Me.Text = ""
        Me.m_textAlign = ContentAlignment.BottomCenter

        '
        ' we're transparent, and that's the way it is.  Users cannot change
        ' this.
        '
        MyBase.BackColor = Color.Transparent

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' NormalImage
    '=----------------------------------------------------------------------=
    ' the image that is displayed in our "normal" ready state for this button
    '
    <LocalisableDescription("ImageButton.NormalImage"), _
     Category("Appearance"), _
     DefaultValue(GetType(Image), Nothing), _
     Localizable(True)> _
    Public Property NormalImage() As Image

        Get
            Return Me.m_normalImage
        End Get

        '
        ' after storing the new image, we want to resize ourselves if 
        ' necessary, and redraw ourselves to reflect the new image
        '
        Set(ByVal newNormalImage As Image)

            Me.m_normalImage = maskImageForTransparency(newNormalImage, Me.m_transparentColour)
            Me.masterRecomputeSizes()
            Me.Refresh()
            Me.m_disabledGenImage = Nothing

        End Set

    End Property ' HoverImage


    '=----------------------------------------------------------------------=
    ' HoverImage
    '=----------------------------------------------------------------------=
    ' this is the image to display when the user hovers the mouse over the
    ' image button.  if it is not specified, then the NormalImage is used
    ' instead.
    '
    <LocalisableDescription("ImageButton.HoverImage"), _
     Category("Appearance"), _
     DefaultValue(GetType(Image), Nothing), _
     Localizable(True)> _
    Public Property HoverImage() As Image

        Get
            Return Me.m_hoverImage
        End Get

        '
        ' set the new image, recompute sizes, and refresh
        '
        Set(ByVal newHoverImage As Image)

            Me.m_hoverImage = maskImageForTransparency(newHoverImage, Me.m_transparentColour)
            Me.masterRecomputeSizes()
            Me.Refresh()

        End Set

    End Property ' HoverImage


    '=----------------------------------------------------------------------=
    ' PressedImage
    '=----------------------------------------------------------------------=
    ' This is the image to display when the user "clicks" on the control,
    ' whether via the mouse, or keyboard.
    '
    <LocalisableDescription("ImageButton.PressedImage"), _
     Category("Appearance"), _
     DefaultValue(GetType(Image), Nothing), _
     Localizable(True)> _
    Public Property PressedImage() As Image

        Get
            Return Me.m_pressedImage
        End Get

        ' 
        ' set the image, recompute our sizes, and refresh
        '
        Set(ByVal newPressedImage As Image)

            Me.m_pressedImage = maskImageForTransparency(newPressedImage, Me.m_transparentColour)
            Me.masterRecomputeSizes()
            Me.Refresh()

        End Set

    End Property ' DisabledImage


    '=----------------------------------------------------------------------=
    ' DisabledImage
    '=----------------------------------------------------------------------=
    ' This is the image to display when the Enabled property is set to "False"
    ' If it is not specified, then a default image is generated instead.
    '
    ' Type:
    '       Image
    '
    <LocalisableDescription("ImageButton.DisabledImage"), _
     Category("Appearance"), _
     DefaultValue(GetType(Image), Nothing), _
     Localizable(True)> _
    Public Property DisabledImage() As Image

        Get
            Return Me.m_disabledImage
        End Get

        ' 
        ' set the image, recompute our sizes, and refresh
        '
        Set(ByVal in_newDisabledImage As Image)

            Me.m_disabledImage = maskImageForTransparency(in_newDisabledImage, Me.m_transparentColour)
            Me.masterRecomputeSizes()
            Me.Refresh()

        End Set

    End Property ' DisabledImage


    '=----------------------------------------------------------------------=
    ' SizeMode
    '=----------------------------------------------------------------------=
    ' Controls how the control is resized when images are set.
    '
    ' Type:
    '       ImageButtonSizeMode
    '
    <LocalisableDescription("ImageButton.SizeMode"), _
     Category("Behavior"), _
     DefaultValue(VbPowerPack.ImageButtonSizeMode.AutoSize), _
     Localizable(True)> _
    Public Overridable Property SizeMode() As ImageButtonSizeMode

        Get
            Return Me.m_sizeMode
        End Get

        '
        ' Set the new value, and resize if necessary.
        '
        Set(ByVal in_newSizeMode As ImageButtonSizeMode)

            If in_newSizeMode < 1 OrElse in_newSizeMode > 2 Then
                Throw New ArgumentOutOfRangeException("Value", VbPowerPackMain.GetResourceManager().GetString("excImageButtonSizeModeInvalid"))
            End If

            If Not in_newSizeMode = Me.m_sizeMode Then

                Me.m_sizeMode = in_newSizeMode
                Me.masterRecomputeSizes()
                Me.Refresh()
            End If


        End Set

    End Property ' SizeMode


    '=----------------------------------------------------------------------=
    ' ShowFocusRect
    '=----------------------------------------------------------------------=
    ' Lets the programmer control whether or not we will draw a focus rect
    ' around the control when it has focus.  Default value is True.
    '
    <LocalisableDescription("ImageButton.ShowFocusRect"), _
     Category("Behavior"), _
     DefaultValue(True), _
     Localizable(True)> _
    Public Property ShowFocusRect() As Boolean

        Get
            Return Me.m_showFocusRect
        End Get

        '
        ' if they changed it, then go ahead and set the new value and repaint
        ' if appropriate.
        '
        Set(ByVal in_newvalue As Boolean)

            If Not Me.m_showFocusRect = in_newvalue Then
                Me.m_showFocusRect = in_newvalue
                If Me.Focused Then Me.Refresh()
            End If
        End Set

    End Property ' ShowFocusRect


    '=----------------------------------------------------------------------=
    ' TransparentColor
    '=----------------------------------------------------------------------=
    ' Given that most users don't have much in the way of tools for creating
    ' truly transparent images such as PNGs or GIFs, we'll let them specify
    ' a "mask" colour here for their images.  We'll default to Transparent,
    ' in case they have such a tool, but otherwise, they can just specify the
    ' colour we will use to mask them out ...
    '
    <LocalisableDescription("ImageButton.TransparentColour"), _
     Category("Appearance"), _
     DefaultValue(GetType(Color), "Transparent"), _
     Localizable(True)> _
    Public Property TransparentColor() As Color

        Get
            Return Me.m_transparentColour
        End Get

        '
        ' set the new value, and then mask any images we've already got ...
        '
        Set(ByVal newTransparentColour As Color)

            If Not newTransparentColour.Equals(Me.m_transparentColour) Then
                Me.m_transparentColour = newTransparentColour
                If Not Me.m_normalImage Is Nothing Then
                    Me.m_normalImage = maskImageForTransparency(Me.m_normalImage, Me.m_transparentColour)
                End If
                If Not Me.m_hoverImage Is Nothing Then
                    Me.m_hoverImage = maskImageForTransparency(Me.m_hoverImage, Me.m_transparentColour)
                End If
                If Not Me.m_pressedImage Is Nothing Then
                    Me.m_pressedImage = maskImageForTransparency(Me.m_pressedImage, Me.m_transparentColour)
                End If
                If Not Me.m_disabledImage Is Nothing Then
                    Me.m_disabledImage = maskImageForTransparency(Me.m_disabledImage, Me.m_transparentColour)
                End If

                Me.Refresh()
            End If
        End Set

    End Property ' TransparentColor


    '=----------------------------------------------------------------------=
    ' BackColor
    '=----------------------------------------------------------------------=
    ' Our backcolor can only be Color.Transparent.  We'll hide it from the
    ' programmer in the IDE and code editor.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property BackColor() As Color

        Get
            Return Color.Transparent
        End Get

        Set(ByVal in_newcolour As Color)
            ' 
            ' We're just going to ignore what the programmer gives us. This
            ' seems to be preferred to throwing an exception ...
            '
        End Set

    End Property ' BackColor


    '=----------------------------------------------------------------------=
    ' DialogResult                                          [IButtonControl]
    '=----------------------------------------------------------------------=
    ' what result to return for this button.
    '
    <LocalisableDescription("ImageButton.DialogResult"), _
     Localizable(True)> _
    Public Property DialogResult() As System.Windows.Forms.DialogResult Implements System.Windows.Forms.IButtonControl.DialogResult

        Get
            Return Me.m_dialogResult
        End Get

        Set(ByVal newDialogResult As System.Windows.Forms.DialogResult)
            Me.m_dialogResult = newDialogResult
        End Set

    End Property ' DialogResult


    '=----------------------------------------------------------------------=
    ' TextAlign
    '=----------------------------------------------------------------------=
    ' we support putting some text along with the image, the exact location
    ' of which depends on both this property and whether we're on a Right
    ' To Left system or not.
    '
    <LocalisableDescription("ImageButton.TextAlign"), _
     Category("Appearance"), _
     DefaultValue(ContentAlignment.BottomCenter), _
     Localizable(True)> _
     Public Property TextAlign() As ContentAlignment

        Get
            Return Me.m_textAlign
        End Get

        '
        ' set the text location, recompute our size, and then update 
        ' ourselves
        '
        Set(ByVal in_newTextAlign As ContentAlignment)

            '
            ' Some quick checking.  It's not worth doing too much else
            '
            If (in_newTextAlign < 0) OrElse (in_newTextAlign > 1024) Then
                Throw New ArgumentOutOfRangeException("Value", VbPowerPackMain.GetResourceManager().GetString("excImageButtonTextAlignInvalid"))
            End If

            If Not Me.m_textAlign = in_newTextAlign Then
                Me.m_textAlign = in_newTextAlign
                masterRecomputeSizes()
                Me.Refresh()
            End If

        End Set

    End Property ' TextAlign


    '=----------------------------------------------------------------------=
    ' Font
    '=----------------------------------------------------------------------=
    ' If the user is going to display a text caption in this control, then we
    ' need to recompute our size every time they set a font.
    '
    <LocalisableDescription("ImageButton.Font"), _
     Category("Appearance"), _
     Localizable(True)> _
    Public Overrides Property Font() As System.Drawing.Font

        Get
            Return MyBase.Font
        End Get

        '
        ' set the new one, recompute our size, and redraw.
        '
        Set(ByVal newFont As System.Drawing.Font)
            MyBase.Font = newFont
            masterRecomputeSizes()
            Me.Refresh()
        End Set

    End Property ' Font


    '=----------------------------------------------------------------------=
    ' Text
    '=----------------------------------------------------------------------=
    ' If the user is going to display a text caption in this control, then we
    ' need to recompute our size every time they set the text.
    '
    <LocalisableDescription("ImageButton.Text"), _
     Category("Behavior"), _
     DefaultValue(""), _
     Localizable(True)> _
    Public Overrides Property Text() As String

        Get
            Return MyBase.Text
        End Get

        '
        ' set the new one, recompute our size, and redraw.
        '
        Set(ByVal newText As String)
            MyBase.Text = newText
            masterRecomputeSizes()
            Me.Refresh()
        End Set

    End Property ' Text


    '=----------------------------------------------------------------------=
    ' NotifyDefault                                         [IButtonControl]
    '=----------------------------------------------------------------------=
    ' we are now the form's default button.  This doesn't affect us at all.
    '
    Public Sub NotifyDefault(ByVal in_amIDefault As Boolean) Implements System.Windows.Forms.IButtonControl.NotifyDefault
        '
        ' we don't do anything different if we're the default.
        '
    End Sub ' NotifyDefault


    '=----------------------------------------------------------------------=
    ' PerformClick                                          [IButtonControl]
    '=----------------------------------------------------------------------=
    ' the user has carried out some action that has the net result of this 
    ' button being clicked (usually hitting ENTER or ESC).
    '
    Public Sub PerformClick() Implements System.Windows.Forms.IButtonControl.PerformClick

        If Me.Enabled Then
            RaiseEvent Click()
        End If

    End Sub ' PerformClick


    '=----------------------------------------------------------------------=
    ' BackgroundImage
    '=----------------------------------------------------------------------=
    ' We don't support this, so we'll hide it from the programmer in the IDE
    ' or code editor.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property BackgroundImage() As System.Drawing.Image

        Get
            Return MyBase.BackgroundImage
        End Get

        Set(ByVal in_newValue As System.Drawing.Image)
            MyBase.BackgroundImage = in_newValue
        End Set

    End Property ' BackgroundImage


    '=----------------------------------------------------------------------=
    ' ImeMode
    '=----------------------------------------------------------------------=
    ' We don't support this, so we'll hide it from the programmer in the IDE
    ' or code editor.   We don't support any sort of input on this control, 
    ' so the need for the IME is not there.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property ImeMode() As ImeMode

        Get
            Return MyBase.ImeMode
        End Get

        Set(ByVal in_newValue As ImeMode)
            MyBase.ImeMode = in_newValue
        End Set

    End Property ' ImeMode


    '=----------------------------------------------------------------------=
    ' AllowDrop
    '=----------------------------------------------------------------------=
    ' We don't support this, so we'll hide it from the programmer in the IDE
    ' or code editor.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property AllowDrop() As Boolean

        Get
            Return MyBase.AllowDrop
        End Get

        Set(ByVal in_newValue As Boolean)
            MyBase.AllowDrop = in_newValue
        End Set

    End Property ' AllowDrop


    '=----------------------------------------------------------------------=
    ' CausesValidation
    '=----------------------------------------------------------------------=
    ' We don't support this, so we'll hide it from the programmer in the IDE
    ' or code editor.  There is no data to validate in this control.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property CausesValidation() As Boolean

        Get
            Return MyBase.CausesValidation
        End Get

        Set(ByVal in_newValue As Boolean)
            MyBase.CausesValidation = in_newValue
        End Set

    End Property ' CausesValidation





    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    ' Private Members/Methods, etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' getImageForDrawState
    '=----------------------------------------------------------------------=
    ' Given our current draw state, goes and gets the apprropriate image for
    ' that draw state.  if that image doesn't exist, defaults to the next
    ' appropriate image.
    '
    ' Returns:
    '       Image       - the image object to paint
    '
    Private Function getImageForDrawState() As Image

        Select Case Me.m_drawState

            Case DrawState.Normal
                Return Me.m_normalImage

            Case DrawState.Hover
                If Not Me.m_hoverImage Is Nothing Then
                    Return Me.m_hoverImage
                Else
                    Return Me.m_normalImage
                End If

            Case DrawState.Pressed
                If Not Me.m_pressedImage Is Nothing Then
                    Return Me.m_pressedImage
                Else
                    Return Me.m_normalImage
                End If

        End Select

    End Function ' getImageForDrawState


    '=----------------------------------------------------------------------=
    ' OnPaint
    '=----------------------------------------------------------------------=
    ' How we go about drawing ourselves
    '
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim rImage As RectangleF
        Dim rText As RectangleF
        Dim sf As StringFormat
        Dim g As Graphics
        Dim i As Image

        g = e.Graphics

        '
        ' We need to first get the text rectangle for painting so that we
        ' can correctly stretch the images in the case where there the 
        ' SizeMode property is set to StretchImage
        '
        computeRectangleForTextDrawing(rText, sf)

        '
        ' do we have an image to draw?
        '
        If Not Me.m_normalImage Is Nothing Then

            '
            ' Figure out what image with which we're going to work.
            '
            If Me.Enabled = False Then
                i = getDisabledImage()
                If i Is Nothing Then i = Me.m_normalImage
            Else
                i = getImageForDrawState()
            End If

            '
            ' Compute the drawing boundaries for this image.
            '
            rImage = computeImageDrawingRectangle(rText, i)

            '
            ' Draw it!
            '
            g.DrawImage(i, rImage)

            '
            ' draw a focus rect if we're focused.
            '
            If Me.Focused And Me.m_showFocusRect = True Then
                drawBoundingFocusRect(g)
            End If

        End If ' do we have an image?

        '
        ' do we have to draw some text?
        '
        If Not Me.Text Is Nothing And Not Me.Text = "" Then
            If MiscFunctions.GetRightToLeftValue(Me) Then
                sf.FormatFlags = sf.FormatFlags Or StringFormatFlags.DirectionRightToLeft
            End If
            g.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), _
                         rText, sf)
        End If

    End Sub ' OnPaint


    '=----------------------------------------------------------------------=
    ' computePropertiesForTextDrawing
    '=----------------------------------------------------------------------=
    ' Computes the bounding rect and formatting properties for drawing text
    ' for the ImageButton
    '
    ' Parameters:
    '       ByRef RectangleF        - [in]  bounding rect for text
    '       ByRef StringFormat      - [in]  how the string should be formatted
    '
    ' Both references are assigned to new objects on exit.
    '
    Private Sub computeRectangleForTextDrawing(ByRef in_rect As RectangleF, _
                                               ByRef in_sf As StringFormat)

        If Me.m_sizeMode = ImageButtonSizeMode.AutoSize Then
            computeTextRectangleForAutoSize(in_rect, in_sf)
        Else
            computeTextRectangleForFreeSize(in_rect, in_sf)
        End If

    End Sub ' computeRectangleForTextDrawing


    '=----------------------------------------------------------------------=
    ' computeImageDrawingRectangle
    '=----------------------------------------------------------------------=
    ' returns the rectangle in which the Image(s) should be drawn.
    '
    ' Parameters:
    '       RectangleF              - [in]  the drawing rect for the text
    '       Image                   - [in]  the image to be drawn.
    '
    ' Returns:
    '       RectangleF
    '
    Private Function computeImageDrawingRectangle(ByVal in_textRect As RectangleF, _
                                                  ByVal in_image As Image) _
                                                  As RectangleF

        Dim s As Size

        s = recomputeImagesBoundingRect()

        If Me.m_sizeMode = ImageButtonSizeMode.AutoSize Then
            Return computeImageDrawRectForAutoSize(in_image.Size)
        Else
            Return computeImageDrawRectForFreeSize(New SizeF(in_textRect.Width, in_textRect.Height))
        End If

    End Function ' computeImageDrawingRectangle


    '=----------------------------------------------------------------------=
    ' computeTextRectangleForAutoSize
    '=----------------------------------------------------------------------=
    ' if we're an autosizing ImageButton, then this goes and obtains the
    ' bounding rectangle for the text, which is basically the size of the
    ' control sans the image.  Not terribly complex.
    '
    ' Parameters:
    '       ByRef RectangleF            - [out] Bounding rect computed
    '       ByRef StringFormat          - [out] StringFormat flags for drawing
    '
    Private Sub computeTextRectangleForAutoSize(ByRef in_rect As RectangleF, _
                                                ByRef in_sf As StringFormat)

        Dim s As Size

        System.Diagnostics.Debug.Assert(Me.m_sizeMode = ImageButtonSizeMode.AutoSize)

        s = recomputeImagesBoundingRect()

        in_sf = New StringFormat

        Select Case mapTextAlignForRTL()

            Case ContentAlignment.BottomCenter
                in_sf.Alignment = StringAlignment.Center
                in_sf.LineAlignment = StringAlignment.Near
                in_rect = New RectangleF(0, s.Height, Me.Width, Me.Height - s.Height)

            Case ContentAlignment.BottomLeft
                in_sf.Alignment = StringAlignment.Near
                in_sf.LineAlignment = StringAlignment.Far
                in_rect = New RectangleF(0, s.Height, Me.Width - s.Width, Me.Height - s.Height)

            Case ContentAlignment.BottomRight
                in_sf.Alignment = StringAlignment.Far
                in_sf.LineAlignment = StringAlignment.Far
                in_rect = New RectangleF(s.Width, s.Height, Me.Width - s.Width, Me.Height - s.Height)

            Case ContentAlignment.TopLeft
                in_sf.Alignment = StringAlignment.Near
                in_sf.LineAlignment = StringAlignment.Near
                in_rect = New RectangleF(0.0, 0.0, Me.Width - s.Width, Me.Height - s.Height)

            Case ContentAlignment.TopCenter
                in_sf.Alignment = StringAlignment.Center
                in_sf.LineAlignment = StringAlignment.Far
                in_rect = New RectangleF(0.0, 0.0, Me.Width, Me.Height - s.Height)

            Case ContentAlignment.TopRight
                in_sf.Alignment = StringAlignment.Far
                in_sf.LineAlignment = StringAlignment.Near
                in_rect = New RectangleF(s.Width, 0.0, Me.Width - s.Width, Me.Height - s.Height)

            Case ContentAlignment.MiddleRight
                in_sf.Alignment = StringAlignment.Near
                in_sf.LineAlignment = StringAlignment.Center
                in_rect = New RectangleF(s.Width, 0, Me.Width - s.Width, _
                             Me.Height)

            Case ContentAlignment.MiddleLeft
                in_sf.Alignment = StringAlignment.Near
                in_sf.LineAlignment = StringAlignment.Center
                in_rect = New RectangleF(0.0, 0.0, Me.Width - s.Width, _
                                         Me.Height)

            Case ContentAlignment.MiddleCenter
                in_sf.Alignment = StringAlignment.Center
                in_sf.LineAlignment = StringAlignment.Center
                in_rect = New RectangleF(0.0, 0.0, Me.Width, _
                                         Me.Height)

        End Select

    End Sub ' computeTextRectangleForAutoSize


    '=----------------------------------------------------------------------=
    ' computeTextRectangleForFreeSize
    '=----------------------------------------------------------------------=
    ' Given that our ImageButton control is not currently being autosized,
    ' we need to go and figure out just how much space we should use for
    ' the text, and how much space should be saved for the (stretched)
    ' image.
    '
    ' Parameters:
    '       ByRef RectangleF            - [out] bounding rect for text
    '       ByRef StringFormat          - [out] flags for painting text.
    '
    '
    Private Sub computeTextRectangleForFreeSize(ByRef in_rect As RectangleF, _
                                                ByRef in_sf As StringFormat)

        Dim widthIsBounded As Boolean
        Dim boundedLimit As Single
        Dim textSize As SizeF
        Dim g As Graphics

        System.Diagnostics.Debug.Assert(Me.m_sizeMode = ImageButtonSizeMode.StretchImage)

        in_sf = New StringFormat

        '
        ' Okay, depending on where the text is positioned, we need to 
        ' choose either a width or a height that will be bounding, and
        ' then compute the other dimension based on that bounded one.
        '
        ' First, get the Bounded edge and its bounding limit.
        '
        getBoundedEdgeAndLimit(widthIsBounded, boundedLimit, Me.Size)

        '
        ' Next, compute the other size.
        '
        g = Graphics.FromHwnd(Me.Handle)
        Try
            If widthIsBounded Then
                textSize = g.MeasureString(Me.Text, Me.Font, _
                                           boundedLimit)
            Else
                textSize = g.MeasureString(Me.Text, Me.Font, _
                                           New SizeF(CType(Me.Width, Single) * 0.5, boundedLimit))
            End If
        Finally
            If Not g Is Nothing Then g.Dispose()
        End Try

        '
        ' Great, we've got the bounding size.  now we need to piece that into
        ' a rectangle
        '
        Select Case mapTextAlignForRTL()

            Case ContentAlignment.TopLeft
                in_rect = New RectangleF(New PointF(0, 0), textSize)
                in_sf.Alignment = StringAlignment.Near
                in_sf.LineAlignment = StringAlignment.Near

            Case ContentAlignment.TopCenter
                in_rect = New RectangleF(New PointF(0, 0), New SizeF(Me.Width, textSize.Height))
                in_sf.Alignment = StringAlignment.Center
                in_sf.LineAlignment = StringAlignment.Near

            Case ContentAlignment.TopRight
                in_rect = New RectangleF(New PointF(Me.Width - textSize.Width, 0), _
                                         textSize)
                in_sf.Alignment = StringAlignment.Far
                in_sf.LineAlignment = StringAlignment.Near

            Case ContentAlignment.MiddleLeft
                in_rect = New RectangleF(New PointF(0, 0), New SizeF(textSize.Width, Me.Height))
                in_sf.Alignment = StringAlignment.Near
                in_sf.LineAlignment = StringAlignment.Center

            Case ContentAlignment.MiddleCenter
                in_rect = New RectangleF(New PointF(0, 0), New SizeF(Me.Width, Me.Height))
                in_sf.Alignment = StringAlignment.Center
                in_sf.LineAlignment = StringAlignment.Center

            Case ContentAlignment.MiddleRight
                in_rect = New RectangleF(Me.Width - textSize.Width, 0, _
                                         textSize.Width, Me.Height)
                in_sf.Alignment = StringAlignment.Far
                in_sf.LineAlignment = StringAlignment.Center

            Case ContentAlignment.BottomLeft
                in_rect = New RectangleF(0, Me.Height - textSize.Height, _
                                         textSize.Width, textSize.Height)
                in_sf.Alignment = StringAlignment.Near
                in_sf.LineAlignment = StringAlignment.Far

            Case ContentAlignment.BottomCenter
                in_rect = New RectangleF(New PointF(0, Me.Height - textSize.Height), _
                                         New SizeF(Me.Width, textSize.Height))
                in_sf.Alignment = StringAlignment.Center
                in_sf.LineAlignment = StringAlignment.Far

            Case ContentAlignment.BottomRight
                in_rect = New RectangleF(New PointF(Me.Width - textSize.Width, _
                                                    Me.Height - textSize.Height), _
                                         textSize)
                in_sf.Alignment = StringAlignment.Far
                in_sf.LineAlignment = StringAlignment.Far

        End Select


    End Sub 'computeTextRectangleForFreeSize


    '=----------------------------------------------------------------------=
    ' computeImageDrawRectForAutoSize
    '=----------------------------------------------------------------------=
    ' Given the size of the image we have to draw, compute the location of
    ' the image we have to draw given that we are an auto sizing imagebutton
    '
    ' Parameters:
    '       Size                - [in]  size of image
    '   
    ' Returns:
    '       RectangleF          - where to draw image
    '
    Private Function computeImageDrawRectForAutoSize(ByVal in_imageSize As Size) _
                                                     As RectangleF

        Select Case mapTextAlignForRTL()

            Case ContentAlignment.BottomCenter, _
                 ContentAlignment.BottomRight
                Return New RectangleF(0, 0, in_imageSize.Width, _
                                      in_imageSize.Height)

            Case ContentAlignment.BottomLeft
                Return New RectangleF(Me.Width - in_imageSize.Width, 0, _
                                      in_imageSize.Width, in_imageSize.Height)

            Case ContentAlignment.MiddleCenter, _
                 ContentAlignment.MiddleRight
                Return New RectangleF(0, 0, in_imageSize.Width, _
                                      in_imageSize.Height)

            Case ContentAlignment.MiddleLeft
                Return New RectangleF(Me.Width - in_imageSize.Width, 0, _
                                      in_imageSize.Width, in_imageSize.Height)

            Case ContentAlignment.TopLeft
                Return New RectangleF(Me.Width - in_imageSize.Width, _
                                      Me.Height - in_imageSize.Height, _
                                      in_imageSize.Width, in_imageSize.Height)

            Case ContentAlignment.TopCenter, _
                 ContentAlignment.TopRight
                Return New RectangleF(0, Me.Height - in_imageSize.Height, _
                                      in_imageSize.Width, in_imageSize.Height)

        End Select

    End Function ' computeImageDrawRectForAutoSize


    '=----------------------------------------------------------------------=
    ' computeImageDrawRectForFreeSize
    '=----------------------------------------------------------------------=
    ' Given the size of the text we have to draw, compute the location of
    ' the image we have to draw given that we are a free sizing imagebutton
    '
    ' Parameters:
    '       SizeF               - [in]  size of text
    '   
    ' Returns:
    '       RectangleF          - where to draw image
    '
    '
    Private Function computeImageDrawRectForFreeSize(ByVal in_textSize As SizeF) _
                                                     As RectangleF

        Select Case mapTextAlignForRTL()

            Case ContentAlignment.TopLeft
                Return New RectangleF(in_textSize.Width, _
                                      in_textSize.Height, _
                                      Me.Width - in_textSize.Width, _
                                      Me.Height - in_textSize.Height)

            Case ContentAlignment.TopCenter
                Return New RectangleF(0, in_textSize.Height, Me.Width, _
                                      Me.Height - in_textSize.Height)

            Case ContentAlignment.TopRight
                Return New RectangleF(0, in_textSize.Height, _
                                      Me.Width, Me.Height - in_textSize.Height)

            Case ContentAlignment.MiddleLeft
                Return New RectangleF(in_textSize.Width, 0, _
                                      Me.Width - in_textSize.Width, _
                                      Me.Height)

            Case ContentAlignment.MiddleCenter
                Return New RectangleF(0, 0, Me.Width, Me.Height)

            Case ContentAlignment.MiddleRight
                Return New RectangleF(0, 0, Me.Width - in_textSize.Width, Me.Height)

            Case ContentAlignment.BottomLeft
                Return New RectangleF(in_textSize.Width, 0, _
                                      Me.Width - in_textSize.Width, _
                                      Me.Height - in_textSize.Height)

            Case ContentAlignment.BottomCenter
                Return New RectangleF(0, 0, Me.Width, Me.Height - in_textSize.Height)

            Case ContentAlignment.BottomRight
                Return New RectangleF(0, 0, Me.Width - in_textSize.Width, _
                                      Me.Height - in_textSize.Height)

        End Select

        '
        ' dead code
        '

    End Function


    '=----------------------------------------------------------------------=
    ' getBoundedEdgeAndLimit 
    '=----------------------------------------------------------------------=
    ' Indicates whether the width or height should be bounded, and then 
    ' what the max dimensions of that bounded edge should be.
    '
    ' Parameters:
    '       ByRef Boolean           - [out] True = width bounded, false height
    '       ByRef Single            - [out] limit of bounded edge.
    '       ByVal Size              - [in]  base size for the non-bound edge
    '
    '
    Private Sub getBoundedEdgeAndLimit(ByRef in_widthIsBounded As Boolean, _
                                       ByRef in_boundedLimit As Single, _
                                       ByVal in_baseSize As Size)

        Select Case mapTextAlignForRTL()
            Case ContentAlignment.TopLeft
                in_widthIsBounded = True
                in_boundedLimit = CType(in_baseSize.Width, Single) * 0.5

            Case ContentAlignment.TopCenter
                in_widthIsBounded = True
                in_boundedLimit = CType(in_baseSize.Width, Single)

            Case ContentAlignment.TopRight
                in_widthIsBounded = True
                in_boundedLimit = CType(in_baseSize.Width, Single) * 0.5

            Case ContentAlignment.MiddleLeft
                in_widthIsBounded = False
                in_boundedLimit = CType(in_baseSize.Height, Single)

            Case ContentAlignment.MiddleCenter
                in_widthIsBounded = True
                in_boundedLimit = CType(in_baseSize.Width, Single)

            Case ContentAlignment.MiddleRight
                in_widthIsBounded = False
                in_boundedLimit = CType(in_baseSize.Height, Single)

            Case ContentAlignment.BottomLeft
                in_widthIsBounded = True
                in_boundedLimit = CType(in_baseSize.Width, Single) * 0.5

            Case ContentAlignment.BottomCenter
                in_widthIsBounded = True
                in_boundedLimit = CType(in_baseSize.Width, Single)

            Case ContentAlignment.BottomRight
                in_widthIsBounded = True
                in_boundedLimit = CType(in_baseSize.Width, Single) * 0.5

        End Select

    End Sub ' getBoundedEdgeAndLimit


    '=----------------------------------------------------------------------=
    ' drawBoundingFocusRect
    '=----------------------------------------------------------------------=
    ' If we're focused, and the programmer wishes us to, this goes and draws a
    ' dotted line around us to indicate we have focus ...
    '
    Private Sub drawBoundingFocusRect(ByVal in_g As Graphics)

        Dim p As Pen
        p = New Pen(SystemColors.ControlDarkDark, 1)
        p.DashStyle = Drawing2D.DashStyle.Dot

        in_g.DrawRectangle(p, 0, 0, Me.Width - 1, Me.Height - 1)

    End Sub ' drawBoudningRect


    '=----------------------------------------------------------------------=
    ' setDrawState
    '=----------------------------------------------------------------------=
    ' Sets the draw state to the given value and redraws if necessary.
    '
    ' Parameters:
    '       DrawState       - [in]  new draw state
    '
    Private Sub setDrawState(ByVal in_newstate As DrawState)

        If Not Me.m_drawState = in_newstate Then
            Me.m_drawState = in_newstate
            Me.Refresh()
        End If

    End Sub ' setDrawState


    '=----------------------------------------------------------------------=
    ' masterRecomputeSizes
    '=----------------------------------------------------------------------=
    ' Whenever there is an image set or text change, we want to recompute
    ' our size.   We set our size to be the smallest rectangle that 
    ' 
    ' 1. contains all the image rectangles
    ' 2. contains the text caption (if any) 
    '
    Private Sub masterRecomputeSizes()

        Dim imageSize As Size
        Dim totalSize As Size

        '
        ' We only want to do this if we've got an HWND.  Otherwise, we'll
        ' force Handle creation too early, and I don't really want that.
        '
        If Not Me.IsHandleCreated Then Return

        '
        ' If the user has set our SizeMode to StretchImage, then we
        ' will just use the size from the Size property.
        '
        If Me.m_sizeMode = ImageButtonSizeMode.StretchImage Then Return

        '
        ' Otherwise, if there is no image or text, then we will do nothing.
        '
        If Me.m_normalImage Is Nothing _
           AndAlso (Me.Text Is Nothing OrElse Me.Text = "") Then Return

        '
        ' first get the bounding rect for our image(s)
        '
        imageSize = recomputeImagesBoundingRect()

        '
        ' do we have any text?
        '
        If Not Me.Text Is Nothing And Not Me.Text = "" Then

            Dim textSize As Size

            totalSize = New Size

            textSize = computeTextSizes(imageSize)

            '
            ' now, depending on the text align property, go and compute
            ' our size.
            '
            Select Case mapTextAlignForRTL()

                Case ContentAlignment.TopLeft
                    totalSize.Width = textSize.Width + imageSize.Width
                    totalSize.Height = textSize.Height + imageSize.Height

                Case ContentAlignment.TopCenter
                    totalSize.Width = Math.Max(imageSize.Width, textSize.Width)
                    totalSize.Height = textSize.Height + imageSize.Height

                Case ContentAlignment.TopRight
                    totalSize.Width = textSize.Width + imageSize.Width
                    totalSize.Height = textSize.Height + imageSize.Height

                Case ContentAlignment.MiddleLeft
                    totalSize.Width = textSize.Width + imageSize.Width
                    totalSize.Height = Math.Max(imageSize.Height, textSize.Height)

                Case ContentAlignment.MiddleCenter
                    totalSize.Width = Math.Max(imageSize.Width, textSize.Width)
                    totalSize.Height = Math.Max(imageSize.Height, textSize.Height)

                Case ContentAlignment.MiddleRight
                    totalSize.Width = textSize.Width + imageSize.Width
                    totalSize.Height = Math.Max(imageSize.Height, textSize.Height)

                Case ContentAlignment.BottomLeft
                    totalSize.Width = textSize.Width + imageSize.Width
                    totalSize.Height = textSize.Height + imageSize.Height

                Case ContentAlignment.BottomCenter
                    totalSize.Width = Math.Max(imageSize.Width, textSize.Width)
                    totalSize.Height = imageSize.Height + textSize.Height

                Case ContentAlignment.BottomRight
                    totalSize.Width = textSize.Width + imageSize.Width
                    totalSize.Height = textSize.Height + imageSize.Height

            End Select

        Else
            '
            ' there is no text, so this is easy!
            '
            totalSize = imageSize
        End If

        Me.Size = totalSize

    End Sub ' masterRecomputeSizes


    '=----------------------------------------------------------------------=
    ' computeTextSize
    '=----------------------------------------------------------------------=
    ' Recomputes the size of the text based on some default values.
    '
    ' Parameters:
    '       Size                    - [in]  size of our image(s)
    '
    ' Returns:
    '       Size
    '
    Private Function computeTextSizes(ByVal in_imageSize As Size) As Size

        Dim widthIsBounded As Boolean
        Dim boundedLimit As Single
        Dim textSize As SizeF
        Dim g As Graphics
        Dim w As Integer

        '
        ' get the text rectangle and then round to the next highest
        ' Integer
        '
        getBoundedEdgeAndLimit(widthIsBounded, boundedLimit, in_imageSize)

        '
        ' Next, compute the other size.
        '
        g = Graphics.FromHwnd(Me.Handle)
        Try
            If widthIsBounded Then
                textSize = g.MeasureString(Me.Text, Me.Font, _
                                           boundedLimit)
            Else
                If in_imageSize.Width < 10 Then w = 10

                textSize = g.MeasureString(Me.Text, Me.Font, _
                                           New SizeF(MAX_TEXT_WIDTH, boundedLimit))
            End If
        Finally
            If Not g Is Nothing Then g.Dispose()
        End Try

        '
        ' create a new size, rounding up to the next int.
        '
        Return New Size(textSize.Width + 0.5, textSize.Height + 0.5)

    End Function  ' computeTextSizes


    '=----------------------------------------------------------------------=
    ' recomputeImagesBoundingRect()
    '=----------------------------------------------------------------------=
    ' This function goes and figures out the max bounding rect for all our
    ' images.  This is then used along with information about our text
    ' caption, and TextLocation to compute the total bounding rect for this
    ' control.
    '
    ' Returns:
    '       Size            - max bounding rect for all our images.
    '
    Private Function recomputeImagesBoundingRect() As Size

        Dim w, h, x As Integer
        Dim myImages() As Image = New Image() {Me.m_normalImage, _
                                               Me.m_hoverImage, _
                                               Me.m_pressedImage, _
                                               Me.m_disabledImage}

        w = 0 : h = 0 : x = 0

        While x < myImages.GetLength(0) - 1
            If Not (myImages(x) Is Nothing) Then
                If myImages(x).Width > w Then w = myImages(x).Width
                If myImages(x).Height > h Then h = myImages(x).Height
            End If
            x += 1
        End While

        Return New Size(w, h)

    End Function ' recomputeImagesBoundingRect


    '=----------------------------------------------------------------------=
    ' OnMouseEnter
    '=----------------------------------------------------------------------=
    ' If the mouse has entered our client area, then we want to go and change
    ' the image we display
    '
    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        setDrawState(DrawState.Hover)
    End Sub


    '=----------------------------------------------------------------------=
    ' OnMouseLeave
    '=----------------------------------------------------------------------=
    ' The mouse has left our client area -- go and change the image as 
    ' appropriate and repaint.
    '
    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        If Me.Enabled = False Then Return
        setDrawState(DrawState.Normal)
    End Sub


    '=----------------------------------------------------------------------=
    ' OnMouseDown
    '=----------------------------------------------------------------------=
    ' The user has pressed the mouse in our client area.  go and deal with 
    ' that now ...
    '
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button And MouseButtons.Left Then
            '
            ' we are now officially a pressed button ....
            '
            setDrawState(DrawState.Pressed)

            '
            ' take the capture until da button be released, and take da focus
            '
            Me.Capture = True
            Me.Focus()
        End If

    End Sub ' OnMouseDown


    '=----------------------------------------------------------------------=
    ' OnMouseUp
    '=----------------------------------------------------------------------=
    ' We are no longer a pressed button.  If we are within the client area,
    ' the button should be considered "Clicked", and we should go do that
    ' now
    '
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button And MouseButtons.Left Then
            '
            ' no capture, and we are normal-ish now
            '
            Me.Capture = False
            If e.X > 0 And e.Y > 0 And e.X < Me.Width And e.Y < Me.Height Then
                setDrawState(DrawState.Hover)
            Else
                setDrawState(DrawState.Normal)
            End If

            '
            ' fire the click only if they released the button in our client area
            ' (if they dragged out and then released, then it's not a fire -- this
            ' is the same behaviour as the regular win32 button ...)
            '
            If e.X > 0 And e.Y > 0 And e.X < Me.Width And e.Y < Me.Height Then
                PerformClick()
            End If
        End If

    End Sub ' OnMouseUp


    '=----------------------------------------------------------------------=
    ' OnMouseMove
    '=----------------------------------------------------------------------=
    ' If the user has the mouse down, then we need to set the image to the
    ' correct one ... basically, if they're in the client area, then the 
    ' image will be pressed, otherwise, it will be the regular one ...
    '
    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)

        If (Me.MouseButtons = MouseButtons.Left) Then
            If e.X > 0 And e.X < Me.Width And e.Y > 0 And e.Y < Me.Height Then
                setDrawState(DrawState.Pressed)
            Else
                setDrawState(DrawState.Normal)
            End If
        End If

    End Sub



    '=----------------------------------------------------------------------=
    ' OnGotFocus
    '=----------------------------------------------------------------------=
    ' We've got focus!  Redraw.
    '
    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)

        Me.Refresh()

    End Sub ' OnGotFocus


    '=----------------------------------------------------------------------=
    ' OnLostFocus
    '=----------------------------------------------------------------------=
    ' No more focus for us.  Redraw.
    '
    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)

        Me.Refresh()

    End Sub ' OnLostFocus


    '=----------------------------------------------------------------------=
    ' OnKeyDown
    '=----------------------------------------------------------------------=
    ' If they hit the ENTER or RETURN keys, then as soon as they're they're,
    ' we fire the click event. (as opposed to SPACE, where we wait for the
    ' KeyUp event...)
    '
    ' If they press space here, then mark the button as pressed.
    '
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            PerformClick()
        ElseIf e.KeyCode = Keys.Space Then
            setDrawState(DrawState.Pressed)
        End If

    End Sub ' OnKeyDown


    '=----------------------------------------------------------------------=
    ' OnKeyUp
    '=----------------------------------------------------------------------=
    ' We fire the Click() event in response to the user pressing AND releasing
    ' the Space bar ...
    '
    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Space Then
            PerformClick()
            setDrawState(DrawState.Normal)
        End If

    End Sub


    '=----------------------------------------------------------------------=
    ' getDisabledImage
    '=----------------------------------------------------------------------=
    ' Returns a disabled version of our main image.  We basically just take
    ' our image and alpha-blend it down to around 25% opacity.
    '
    Protected Function getDisabledImage() As Image

        Dim i As Image
        Dim c, newc As Color
        Dim b As Bitmap

        '
        ' If the user gave us one of these, use it.
        '
        If Not Me.m_disabledImage Is Nothing Then Return Me.m_disabledImage

        '
        ' if we don't have a normal image, or we've already computed
        ' a disabled image, this is e-z.
        '
        If Me.m_normalImage Is Nothing Then Return Nothing
        If Not Me.m_disabledGenImage Is Nothing Then Return Me.m_disabledGenImage

        i = Me.m_normalImage.Clone

        '
        ' For most image formats, this cast will work.  For WMFs, this
        ' won't, so we'll simply not be able to do anything for them.
        '
        b = CType(i, Bitmap)
        If b Is Nothing Then Return Nothing

        '
        ' our basic heuristic is this:  for any pixel that has an
        ' Alpha of greater than DISABLED_ALPHABLEND_VALUE (i.e. it's 
        ' pretty solid), go and lower that value down to 
        ' DISABLED_ALPHABLEND_VALUE()
        '
        For x As Integer = 0 To i.Width - 1
            For y As Integer = 0 To i.Height - 1

                c = b.GetPixel(x, y)
                If (c.A > DISABLED_ALPHABLEND_VALUE) Then
                    newc = Color.FromArgb(DISABLED_ALPHABLEND_VALUE, c)
                    b.SetPixel(x, y, newc)
                End If
            Next
        Next

        Me.m_disabledGenImage = b
        Return b

    End Function ' getDisabledImage


    '=----------------------------------------------------------------------=
    ' OnEnabledChanged
    '=----------------------------------------------------------------------=
    ' We just need to repaint here to show the correct image
    '
    Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)

        Me.Refresh()

    End Sub ' OnEnabledChanged


    '=----------------------------------------------------------------------=
    ' OnResize
    '=----------------------------------------------------------------------=
    ' We don't let you resize the control if there's an image specified.
    '
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)

        MyBase.OnResize(e)
        Me.Refresh()

    End Sub ' OnResize


    '=----------------------------------------------------------------------=
    ' maskImageForTransparency
    '=----------------------------------------------------------------------='
    ' Given an image that has one colour used to mark certain regions as
    ' "transparent", go ahead and actually make them transparent now.
    '
    ' Parameters:
    '       Image           - [in]  image to modify
    '       Color           - [in]  colour to use as the mask colour.
    '
    ' Returns:
    '       Image           - the newly masked image.
    '
    ' Notes:
    '       Please note that WMFs don't support this, but that shouldn't be an
    '       issue as they naturally have transparent backgrounds anyway ...
    '
    Private Function maskImageForTransparency(ByVal in_image As Image, _
                                              ByVal in_maskColour As Color) As Image

        Dim i As Image
        Dim b As Bitmap

        '
        ' if our mask colour is just the transparent colour, this is easy.
        '
        If Me.m_transparentColour.Equals(Color.Transparent) Then
            Return in_image
        End If

        '
        ' clone the image (so we don't destroy the one we've been given),
        ' get it as a bitmap (or if we can't, oh well), and then mask it
        '
        i = in_image.Clone()
        b = CType(i, Bitmap)
        If Not b Is Nothing Then
            b.MakeTransparent(Me.m_transparentColour)
        End If

        Return i

    End Function ' maskImageForTransparency


    '=----------------------------------------------------------------------=
    ' mapTextAlignForRTL
    '=----------------------------------------------------------------------=
    ' Maps the TextAlignProperty on this control to the proper value given
    ' the current RightToLeft setting.
    '
    ' Returns:
    '       ContentAlignment
	'
	Private Function mapTextAlignForRTL() As ContentAlignment

		Dim reverse As Boolean = MiscFunctions.GetRightToLeftValue(Me)

		If Not reverse Then
			Return Me.m_textAlign
		Else

			Select Case Me.m_textAlign
				Case ContentAlignment.BottomLeft
					Return ContentAlignment.BottomRight

				Case ContentAlignment.BottomRight
					Return ContentAlignment.BottomLeft

				Case ContentAlignment.MiddleLeft
					Return ContentAlignment.MiddleRight

				Case ContentAlignment.MiddleRight
					Return ContentAlignment.MiddleLeft

				Case ContentAlignment.TopLeft
					Return ContentAlignment.TopRight

				Case ContentAlignment.TopRight
					Return ContentAlignment.TopLeft

				Case Else
					Return Me.m_textAlign
			End Select
		End If

	End Function ' mapTextAlignForRTL



    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                               Events
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Click Event
    '=----------------------------------------------------------------------=
    ' This is our main event -- fired when the user "clicks" on the button,
    ' either via mouse, keyboard, or programmatically ...
    '
    <LocalisableDescription("ImageButton.Click"), _
     Category("Behavior")> _
    Public Shadows Event Click()



End Class ' ImageButton



