'-------------------------------------------------------------------------------
'<copyright file="TaskPane.vb" company="Microsoft">
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





'=--------------------------------------------------------------------------=
' TaskPane
'=--------------------------------------------------------------------------=
' This is the base container class that users add to their forms in Visual
' Studio.  Using various Design Time functionality, users can then go and
' child frames (in the TaskFrame class) to it, and customise them as
' they wish.
'
'
<DefaultProperty("TaskFrames"), DefaultEvent("FrameCollapsed"), _
 Designer(GetType(Design.TaskPaneDesigner))> _
Public Class TaskPane
    Inherits ContainerControl



    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    ' Private member variables
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '
    ' amount of space to allow between each Frame.
    '
    Private Const FRAME_PADDING As Integer = 12

    '
    ' How many ms between collapse/expand changes and the total time we want
    ' the operation to last...
    '
    Private Const TIMER_DELTA As Integer = 50
    Private Const TOTAL_CHANGE_TIME As Integer = 250   ' half a second

    '
    ' This is the style of corners we will paint for these controls.
    '
    Private m_cornerStyle As TaskFrameCornerStyle

    '
    ' This is user configurable
    '
    Private m_padding As Integer


    '
    ' This is our collection of TaskFrame objects.  For each frame,
    ' we also associate a CaptionBar class, which contains the image, caption,
    ' and collapse button (if applicable)
    '
    Private m_frameCollection As TaskFrameCollection

    '
    ' This timer is used for expanding/collapsing of frames.
    '
    Private WithEvents m_collapseTimer As Timer


    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                     Public Methods, Members, etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Intitializes a new instance of our TaskPane class.  We don't 
    ' have any frames by default, and they need to be added one by one.
    '
    '
    Public Sub New()

        '
        ' set up some reasonable default values for the various properties
        ' we've got.
        '
        Me.m_cornerStyle = TaskFrameCornerStyle.SystemDefault
        Me.BackColor = SystemColors.InactiveCaption

        Me.m_frameCollection = New TaskFrameCollection(Me)

        '
        ' Set up a decent default width, and we'll dock to the left
        '
        Me.Width = 150
        Me.Dock = DockStyle.Left

        Me.SetStyle(ControlStyles.DoubleBuffer, True)

        '
        ' finally, set up the collapse/expand timer we'll use to do a lot
        ' of the work.
        '
        Me.m_collapseTimer = New Timer
        Me.m_collapseTimer.Interval = TIMER_DELTA

        Me.AutoScroll = True
        Me.HScroll = False

        Me.m_padding = FRAME_PADDING

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' CornerStyle
    '=----------------------------------------------------------------------=
    ' Controls how the corners are drawn for the caption bars at the top of
    ' the individual child frames.  By default, they track what the current
    ' Operating System style is using, but users can force this to other 
    ' values if they so wish.
    '
    <LocalisableDescription("TaskPane.CornerStyle"), _
     Category("Appearance"), _
     DefaultValue(VbPowerPack.TaskFrameCornerStyle.SystemDefault), _
     Localizable(True)> _
    Public Property CornerStyle() As TaskFrameCornerStyle

        Get
            Return Me.m_cornerStyle
        End Get

        '
        ' set the new value and refresh the control to reflect the change.
        '
        Set(ByVal in_newCornerStyle As TaskFrameCornerStyle)

            If in_newCornerStyle < 0 OrElse in_newCornerStyle > 2 Then
                Throw New ArgumentOutOfRangeException("Value", VbPowerPackMain.GetResourceManager().GetString("excTaskPaneCornerStyleRange"))
            End If

            If Not in_newCornerStyle = Me.m_cornerStyle Then
                Me.m_cornerStyle = in_newCornerStyle
                Me.Refresh()
            End If
        End Set

    End Property ' CornerStyle


    '=----------------------------------------------------------------------=
    ' Padding
    '=----------------------------------------------------------------------=
    ' Specifies just how much space should be left between individual Task
    ' Frames and between frames and the edges of the TaskPane.
    '
    ' Type:
    '       Integer
    '
    <LocalisableDescription("TaskPane.Padding"), _
     Category("Appearance"), _
     DefaultValue(FRAME_PADDING), _
     Localizable(True)> _
    Public Overridable Property Padding() As Integer
        Get
            Return Me.m_padding
        End Get

        '
        ' set the new value if appropriate, and relayout the container.
        '
        Set(ByVal in_newPadding As Integer)
            If in_newPadding < 0 Then
                Throw New ArgumentOutOfRangeException("Value")
            End If

            If Not in_newPadding = Me.m_padding Then
                Me.m_padding = in_newPadding
                layoutAllFrames()
            End If
        End Set

    End Property  ' Padding


    '=----------------------------------------------------------------------=
    ' TaskFrames
    '=----------------------------------------------------------------------=
    ' This is our collection of TaskFrame child panels.  This 
    ' collection object also manages the CaptionBars for us.
    '
    <LocalisableDescription("TaskPane.TaskFrames"), _
     Category("Misc"), _
     DefaultValue(False), _
     Editor("VbPowerPack.Design.TaskFrameCollectionEditor", GetType(System.drawing.Design.UITypeEditor)), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), _
     MergableProperty(False)> _
    Public ReadOnly Property TaskFrames() As TaskFrameCollection

        Get
            Return Me.m_frameCollection
        End Get

    End Property ' TaskFrames


    '=----------------------------------------------------------------------=
    ' Text
    '=----------------------------------------------------------------------=
    ' The text property isn't visible on this control, so we'll go and hide
    ' it now.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property Text() As String

        Get
            Return MyBase.Text
        End Get

        Set(ByVal newText As String)
            MyBase.Text = newText
        End Set

    End Property ' Text


    '=----------------------------------------------------------------------=
    ' ExpandAll
    '=----------------------------------------------------------------------=
    ' Expands all of our child frames.
    '
    <LocalisableDescription("TaskPane.ExpandAll")> _
    Public Sub ExpandAll()

        Dim tf As TaskFrame

        '
        ' Loop through our collection of TaskFrames and then expand each
        ' one at a time ...
        '
        For i As Integer = 0 To Me.TaskFrames.Count - 1
            tf = CType(Me.TaskFrames(i), TaskFrame)
            tf.IsExpanded = True
        Next

    End Sub ' ExpandAll


    '=----------------------------------------------------------------------=
    ' CollapseAll
    '=----------------------------------------------------------------------=
    ' Collapses all of our child frames.
    '
    <LocalisableDescription("TaskPane.CollapseAll")> _
    Public Sub CollapseAll()

        Dim tf As TaskFrame

        '
        ' Loop through our collection of TaskFrames and then collapse each
        ' one at a time ...
        '
        For i As Integer = 0 To Me.TaskFrames.Count - 1
            tf = CType(Me.TaskFrames(i), TaskFrame)
            tf.IsExpanded = False
        Next

    End Sub ' CollapseAll


    '=----------------------------------------------------------------------=
    ' Refresh
    '=----------------------------------------------------------------------=
    ' Make sure that everybody is refreshed!
    '
    Public Overrides Sub Refresh()

        For x As Integer = 0 To Me.Controls.Count - 1
            Me.Controls(x).Refresh()
        Next

        MyBase.Refresh()

    End Sub ' Refresh











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
    ' CreateHandle
    '=----------------------------------------------------------------------=
    ' Make sure we're all laid out properly.
    '
    Protected Overrides Sub CreateHandle()

        MyBase.CreateHandle()

        layoutAllFrames()

    End Sub ' CreateHandle


    '=----------------------------------------------------------------------=
    ' CreateControlsInstance
    '=----------------------------------------------------------------------=
    ' Creates the ControlCollection object with which we will work.  
    ' Our version will be a bit special in that it will only 
    ' accept TaskFrames to be added, and will also add in the CaptionBar
    ' for the given frame.
    '
    ' Returns:
    '       Control.ControlCollection   - our new collection
    '
    Protected Overrides Function CreateControlsInstance() As Control.ControlCollection
        Return New TaskPane.ControlCollection(Me)
    End Function


    '=----------------------------------------------------------------------=
    ' OnFrameCollapsed
    '=----------------------------------------------------------------------=
    ' The user has collapsed the given frame.
    '
    ' Parameters:
    '       TaskFrame        - [in]  Frame collapsed.
    '
    Protected Sub OnFrameCollapsed(ByVal frame As TaskFrame)

        RaiseEvent FrameCollapsed(Me, New TaskPaneEventArgs(frame))

    End Sub


    '=----------------------------------------------------------------------=
    ' OnFrameExpanded
    '=----------------------------------------------------------------------=
    ' The user has expanded the given frame.
    '
    ' Parameters:
    '       TaskFrame        - [in]  Frame expanded.
    '
    Protected Sub OnFrameExpanded(ByVal frame As TaskFrame)

        RaiseEvent FrameExpanded(Me, New TaskPaneEventArgs(frame))

    End Sub


    '=----------------------------------------------------------------------=
    ' OnFrameCollapsing
    '=----------------------------------------------------------------------=
    ' The user is about to collapse the given frame.
    '
    ' Parameters:
    '       TaskFrame        - [in]  Frame being collapsed.
    '
    ' Returns:
    '       Boolean          - True to Cancel, False to let continue.
    '
    Protected Function OnFrameCollapsing(ByVal frame As TaskFrame) As Boolean

        Dim ce As TaskPaneCancelEventArgs
        ce = New TaskPaneCancelEventArgs(frame)

        RaiseEvent FrameCollapsing(Me, ce)

        Return ce.Cancel

    End Function


    '=----------------------------------------------------------------------=
    ' OnFrameExpanding
    '=----------------------------------------------------------------------=
    ' The user is about to expand the given frame.
    '
    ' Parameters:
    '       TaskFrame        - [in]  Frame being expanded.
    '
    ' Returns:
    '       Boolean          - True to Cancel, False to let continue.
    '
    Protected Function OnFrameExpanding(ByVal frame As TaskFrame) As Boolean

        Dim ce As TaskPaneCancelEventArgs
        ce = New TaskPaneCancelEventArgs(frame)

        RaiseEvent FrameExpanding(Me, ce)

        Return ce.Cancel

    End Function


    '=----------------------------------------------------------------------=
    ' OnLayout
    '=----------------------------------------------------------------------=
    ' We're being asked to lay out all of our components.
    '
    Protected Overrides Sub OnLayout(ByVal levent As System.Windows.Forms.LayoutEventArgs)
        layoutAllFrames()
        MyBase.OnLayout(levent)
    End Sub



    '=----------------------------------------------------------------------=
    ' layoutAllFrames
    '=----------------------------------------------------------------------=
    ' Given that we now have a bunch of TaskFrames and associated 
    ' CaptionBar controls, go and lay them out now, including doing things
    ' like making sure our scroll height is correct, etc ...
    '
    Friend Sub layoutAllFrames()
        Static b As Boolean
        Dim h, w As Integer

        ' Since the TaskPaneDesigner can draw some frame around selected TaskFrames,
        ' refresh the current control.
        MyBase.Refresh()

        '
        ' if we don't have any frames, then this is easy.
        '
        If Me.m_frameCollection Is Nothing Then Return

        '
        ' If we're not created, then this is also easy.
        '
        If Not Me.IsHandleCreated Then Return

        If Not b = False Then Exit Sub
        b = True

        '
        ' okay, we should have a window handle now, which means we can start
        ' figuring out sizes, etc ...
        ' 

        '
        ' 1. Compute the height
        '
        h = computeTotalHeight()

        '
        ' 2. readjust our scrollbars to reflect this.
        '
        If h > Me.Height Then

            Dim i As Integer
            Me.AutoScrollMinSize = New Size(0, h)

            '
            ' Our width has to have some room for the scrollbar ...
            '
            i = SystemInformation.VerticalScrollBarWidth
            w = Me.Width - i - 1

        Else

            Me.AutoScrollMinSize = New Size(0, 0)
            w = Me.Width

        End If

        '
        ' 3. Now go and adjust all the controls' sizes correctly.
        '
        positionAllFrames(w)

        b = False
    End Sub ' layoutAllFrames


    '=----------------------------------------------------------------------=
    ' computeTotalHeight
    '=----------------------------------------------------------------------=
    ' Figures out how tall our TaskPane control needs to be, given the number
    ' of frames and caption bars we have, as well as appropriate padding.
    '
    ' Returns:
    '       Integer             - total height in pixesl of the control.
    '
    Private Function computeTotalHeight() As Integer

        Dim tf As TaskFrame
        Dim height As Integer

        '
        ' first, we have to compute the total height of evertying, to figure
        ' out if we need to go and set up a scrollbar.
        '
        height = 0

        For i As Integer = 0 To Me.m_frameCollection.Count - 1

            tf = Me.m_frameCollection(i)

            If tf.m_captionBar.Visible Then

                '
                ' every frame adds:
                '
                ' 1. fixed buffer space at the top
                ' 2. the height of the caption bar
                ' 3. the height of the actual frame itself, provided it's
                '    not collapsed.
                '
                height += Me.m_padding
                height += tf.m_captionBar.Height
                If Not tf.IsExpanded = False Then
                    height += tf.Height
                End If

            End If
        Next

        '
        ' finally, add some height for a buffer at the bottom and return
        '
        height += Me.m_padding
        Return height

    End Function ' computeTotalHeight


    '=----------------------------------------------------------------------=
    ' positionAllFrames
    '=----------------------------------------------------------------------=
    ' Given that we've figured out our height, and now know our width, we
    ' now need to go and move all the frames and caption bars to be in the 
    ' correct place.
    '
    ' Parameters:
    '       Integer             - [in]  computed client width of this control.
    '
    Private Sub positionAllFrames(ByVal in_width As Integer)

        Dim tf As TaskFrame
        Dim realWidth As Integer
        Dim top As Integer
        Dim left As Integer

        '
        ' set up the base width and height
        '
        realWidth = in_width - (2 * Me.m_padding)
        If realWidth < 1 Then
            realWidth = 10
        End If
        top = Me.m_padding

        '
        ' Make sure we show at least SOMETHING if the padding is ridiculously
        ' huge.
        '
        If Me.m_padding > (Me.Width / 2) - 5 Then
            left = (Me.Width / 2) - 5
        Else
            left = Me.m_padding
        End If

        '
        ' for each item, go and position it appropriately.
        '
        For i As Integer = 0 To Me.m_frameCollection.Count - 1

            Dim hwnd As IntPtr

            tf = Me.m_frameCollection(i)

            '
            ' Make sure that the handle has been created for the 
            ' TaskFrame.
            '
            hwnd = tf.Handle
            If tf.m_captionBar.Visible Then

                '
                ' caption bar
                '
                tf.m_captionBar.Top = top + Me.AutoScrollPosition.Y

                tf.m_captionBar.Left = Me.m_padding
                tf.m_captionBar.Width = realWidth
                top += tf.m_captionBar.Height

            Else
                System.Diagnostics.Debug.Assert(Not tf.Visible, "How can I have an invisible CaptionBar but visible Frame ????")
            End If

            If tf.getReallyVisible() = True Then

                '
                ' frame.
                '
                tf.Top = top + Me.AutoScrollPosition.Y
                tf.Left = Me.m_padding
                tf.Width = realWidth
                top += tf.Height

                tf.Refresh()
            End If

            If tf.m_captionBar.Visible Then
                top += Me.m_padding
            End If
        Next

    End Sub ' positiionAllFrames



    '=----------------------------------------------------------------------=
    ' expandCollapseFrame
    '=----------------------------------------------------------------------=
    ' Contains the actual logic to go and expand or collapse the given 
    ' TaskFrame.  To do this from code, you should just set 
    ' myTaskPane1.IsExpanded = either True or False.
    ' 
    ' Please note that there should be nothing here preventing controls from
    ' having their IsExpanded property changed WHILE they are actively 
    ' collapsing or expanding.  We should simply be able to deal with this.
    '
    ' Parameters:
    '       TaskFrame           - [in]  the frame to be changed
    '       Boolean             - [in]  True = Collapse, False = Expand
    '
    Friend Sub expandCollapseFrame(ByVal in_frame As TaskFrame, ByVal in_collapse As Boolean)
        '
        ' If the pane is already collapsed, then this is pretty easy.  
        ' Otherwise, given them the chance to cancel the happening!
        '
        If in_collapse Then
            If in_frame.m_activeState = TaskFrame.ActiveState.Collapsing Then Return
            If Me.OnFrameCollapsing(in_frame) = True Then Return
        Else
            If in_frame.m_activeState = TaskFrame.ActiveState.Expanding Then Return
            If Me.OnFrameExpanding(in_frame) = True Then Return
        End If

        '
        ' Now, suspend the layout on it if we're collapsing it, so any child 
        ' Controls don't freak out that they're being moved around.
        '
        If in_collapse = True Then
            in_frame.SuspendLayout()
        Else
            '
            ' if we're going to expand it, make sure it's visible again.
            '
            in_frame.Height = 0
            in_frame.showWithoutCaptionBar()
        End If

        '
        ' Next, tell the control how much we're going to change it by each
        ' tick, and then start sliding it up to height zero or the original
        ' size.  With the changeDelta, we're targeting a TOTAL_CHANGE_TIME
        ' length collapse.
        '
        If in_collapse = True _
           AndAlso Not in_frame.m_activeState = TaskFrame.ActiveState.Collapsing _
           AndAlso Not in_frame.m_activeState = TaskFrame.ActiveState.Expanding Then

            in_frame.m_changeDelta = in_frame.Height / (TOTAL_CHANGE_TIME / TIMER_DELTA)
            in_frame.m_originalSize = in_frame.Height

        ElseIf in_collapse = False _
               AndAlso Not in_frame.m_activeState = TaskFrame.ActiveState.Collapsing _
               AndAlso Not in_frame.m_activeState = TaskFrame.ActiveState.Expanding Then

            in_frame.m_changeDelta = in_frame.m_originalSize / (TOTAL_CHANGE_TIME / TIMER_DELTA)

        End If

        If in_collapse = True Then
            in_frame.m_activeState = TaskFrame.ActiveState.Collapsing
        Else
            in_frame.m_activeState = TaskFrame.ActiveState.Expanding
        End If

        '
        ' start the timer doing it's thang.
        '
        If Not Me.m_collapseTimer.Enabled Then
            Me.m_collapseTimer.Start()
        End If

    End Sub ' expandCollapsePane


    '=----------------------------------------------------------------------=
    ' m_collapseTimer_Tick
    '=----------------------------------------------------------------------=
    ' We're the timer that goes along and expands/collapses the various 
    ' taskframes.
    '
    Private Sub m_collapseTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_collapseTimer.Tick

        Dim activelyChangingCount As Integer
        Dim tf As TaskFrame

        activelyChangingCount = 0

        '
        ' for each frame that is expanding or collapsing, go and change its
        ' state just a bit this time ...
        '
        For i As Integer = 0 To Me.m_frameCollection.Count() - 1

            tf = Me.m_frameCollection(i)

            '
            ' what's our current state?
            '
            Select Case tf.m_activeState

                Case TaskFrame.ActiveState.Collapsing

                    tf.Height = tf.Height - tf.m_changeDelta

                    '
                    ' did we completely collapse that dude? if so,
                    ' set some state and fire the event!
                    '
                    If tf.Height <= 0 Then

                        '
                        ' Height is zero, and hide it so that children
                        ' aren't included the z-order any more.
                        '
                        tf.Height = 0
                        tf.hideWithoutCaptionBar()
                        tf.m_activeState = TaskFrame.ActiveState.Collapsed
                        layoutAllFrames()

                        OnFrameCollapsed(tf)
                        tf.m_captionBar.Refresh()
                    Else
                        activelyChangingCount += 1
                    End If


                Case TaskFrame.ActiveState.Expanding

                    tf.Height += tf.m_changeDelta

                    '
                    ' did we completely expand the frame?  if so,
                    ' set some state and fire the event!
                    '
                    If tf.Height >= tf.m_originalSize Then

                        '
                        ' Set it back to its original size, and then
                        ' relayout the container
                        '
                        tf.Height = tf.m_originalSize
                        tf.m_activeState = TaskFrame.ActiveState.Expanded
                        layoutAllFrames()

                        '
                        ' Fire the event and repaint everything
                        '
                        OnFrameExpanded(tf)
                        tf.m_captionBar.Refresh()

                        '
                        ' finally, don't forget to tell it that it can
                        ' reposition controls again.
                        '
                        tf.Refresh()
                        tf.ResumeLayout()
                    Else
                        activelyChangingCount += 1
                    End If
            End Select
        Next

        '
        ' If there are no controls actively changing state, then go and
        ' shut down the timer, so we don't waste any time here ...
        '
        If activelyChangingCount = 0 Then
            Me.m_collapseTimer.Stop()
        End If



    End Sub ' m_collapsibleTimer_Tick


    '=----------------------------------------------------------------------=
    ' GetCompleteRectForFrame
    '=----------------------------------------------------------------------=
    ' Returns the rect bounding both a frame as well as its associated
    ' captionbar.
    '
    ' Parameters:
    '       TaskFrame               - [in]  how'm I bounded?
    '
    ' Returns:
    '       Rectangle
    '
    Friend Function GetCompletRectForFrame(ByVal in_frame As TaskFrame) As Rectangle

        Dim pt As Point
        Dim sz As Size

        System.Diagnostics.Debug.Assert(Not in_frame Is Nothing)
        pt = in_frame.m_captionBar.Location()

        sz = New Size
        sz.Width = in_frame.Width
        sz.Height = in_frame.Bottom - in_frame.m_captionBar.Top

        Return New Rectangle(pt, sz)

    End Function ' GetCompleteRectForFrame













    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                                Events
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' FrameCollapsed
    '=----------------------------------------------------------------------=
    ' The given frame has been collapsed, either by the user or in code.
    '
    <LocalisableDescription("TaskPane.FrameCollapsed"), _
     Category("Behavior")> _
    Public Event FrameCollapsed(ByVal sender As Object, ByVal e As TaskPaneEventArgs)

    '=----------------------------------------------------------------------=
    ' FrameCollapsing
    '=----------------------------------------------------------------------=
    ' The given frame is about to be collapsed, either by the user or via
    ' code.  Programmers can cancel this collapse here.
    '
    <LocalisableDescription("TaskPane.FrameCollapsing"), _
     Category("Behavior")> _
    Public Event FrameCollapsing(ByVal sender As Object, ByVal ce As TaskPaneCancelEventArgs)


    '=----------------------------------------------------------------------=
    ' FrameExpanded
    '=----------------------------------------------------------------------=
    ' The given frame has been expanded, either by the user or via code.
    '
    <LocalisableDescription("TaskPane.FrameExpanded"), _
     Category("Behavior")> _
    Public Event FrameExpanded(ByVal sender As Object, ByVal e As TaskPaneEventArgs)

    '=----------------------------------------------------------------------=
    ' FrameExpanding
    '=----------------------------------------------------------------------=
    ' The given frame is about to be expanded, either by the user or via code.
    '
    <LocalisableDescription("TaskPane.FrameExpanding"), _
     Category("Behavior")> _
    Public Event FrameExpanding(ByVal sender As Object, ByVal ce As TaskPaneCancelEventArgs)







    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                           Nested Classes
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' ControlCollection
    '=----------------------------------------------------------------------=
    ' all of the pages in the TaskFrame control are in a collection of
    ' TaskFrame objects
    '
    Public Shadows Class ControlCollection
        Inherits Control.ControlCollection

        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '             Private Member variables, enums, consts
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=

        '
        ' Our Parent TaskPane
        '
        Private m_parent As TaskPane

        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '             Public Methods/Properties/Functions, etc 
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=



        '=------------------------------------------------------------------=
        ' Constructor
        '=------------------------------------------------------------------=
        ' Initializes a new instance of this collection with the given parent.
        '
        ' Parameters:
        '       TaskPane            - [in]  parent TaskPane control.
        '
        Public Sub New(ByVal in_parent As TaskPane)

            MyBase.New(in_parent)
            Me.m_parent = in_parent

        End Sub ' ControlCollection.New


        '=------------------------------------------------------------------=
        ' Add
        '=------------------------------------------------------------------=
        ' Adds the given control to our list of Sub controls.  It had BETTER
        ' be a TaskFrame.  In this case, we need to go and create the appropriate
        ' CaptionBar for it, and add it as well ...
        '
        Public Overrides Sub Add(ByVal in_control As Control)

            Dim container As IContainer
            Dim cb As CaptionBar
            Dim tf As TaskFrame
            Dim site As ISite

            '
            ' Double check the arg type first ...
            '
            If Not TypeOf (in_control) Is TaskFrame _
               And Not TypeOf (in_control) Is CaptionBar Then

                Throw New ArgumentException(String.Format(VbPowerPackMain.GetResourceManager().GetString("excTaskPaneTaskFramesOnly"), in_control.GetType().ToString()))
            End If


            If Me.Contains(in_control) Then Return

            '
            ' Go and create the CaptionBar for this frame ...
            '
            tf = CType(in_control, TaskFrame)
            cb = New CaptionBar(tf)
            tf.m_captionBar = cb
            cb.setVisibleInternal(True)

            '
            ' Now, add the caption bar to our list of controls.
            '
            MyBase.Add(cb)
            '
            ' And now add the actual frame to our list of controls.
            '
            MyBase.Add(tf)

            '
            ' Next, site the controls if at all necessary.
            '
            site = Me.m_parent.Site
            If Not site Is Nothing Then

                '
                ' Site the TaskFrame here, as controls need to be
                ' sited in order to have code generated for them at
                ' design time.
                ' Please note this means we DON'T want to site the
                ' CaptionBars ...
                '
                If tf.Site Is Nothing Then
                    container = site.Container
                    container.Add(tf)
                End If

            End If

            '
            ' Finally, add the frame to our parent's collection of 
            ' frames, and then tell it to re-layout everything. 
            '
            Me.m_parent.TaskFrames.addFrameInternal(tf)
            Me.m_parent.layoutAllFrames()

        End Sub ' ControlCollection.Add


        '=------------------------------------------------------------------=
        ' Remove
        '=------------------------------------------------------------------=
        ' Removes the given TaskFrame from our list of controls, as well as the
        ' associated CaptionBar control.
        '
        ' Parameters:
        '       Control         - [in]  control to remove, had better be TaskFrame
        '
        Public Overrides Sub Remove(ByVal in_control As Control)

            Dim tf As TaskFrame

            If Not TypeOf (in_control) Is TaskFrame Then Return

            If Not Me.Contains(in_control) Then Return

            '
            ' remove this Frame and its CaptionBar
            '
            tf = CType(in_control, TaskFrame)
            MyBase.Remove(tf.m_captionBar)
            MyBase.Remove(tf)

            '
            ' Remove it from the other collection the TaskPane maintains.
            '
            Me.m_parent.TaskFrames.removeFrameInternal(tf)

            '
            ' Finally, tell the parent Pane to layout everything again.
            '
            Me.m_parent.layoutAllFrames()

        End Sub ' ControlCollection.Remove


        '=------------------------------------------------------------------=
        ' Clear
        '=------------------------------------------------------------------=
        ' Removes all the items in this control collection.
        '
        Public Overrides Sub Clear()

            '
            ' For each TaskFrame in the control, go and remove it 
            ' now.  Removing the individual TaskFrames will go and
            ' remove the CaptionBars as well !!
            '
            For x As Integer = 0 To Me.m_parent.m_frameCollection.Count - 1
                Me.Remove(Me.m_parent.m_frameCollection(0))
            Next

            '
            ' Finally, go and clear out the frame collection too.  This keeps
            ' everybody nice and in sync with each other.
            '
            Me.m_parent.m_frameCollection.clearInternal()

        End Sub ' ControlCollection.Clear


        '=------------------------------------------------------------------=
        ' AddRange
        '=------------------------------------------------------------------=
        ' Adds a range of controls to our collection. 
        '
        Public Overrides Sub AddRange(ByVal in_array() As Control)

            Dim tf As TaskFrame

            If in_array Is Nothing Then Return
            If in_array.GetLength(0) = 0 Then Return

            '
            ' Now, for each item, go and make sure it's a TaskFrame, and
            ' then go and add if it is.
            '
            For x As Integer = 0 To in_array.GetLength(0) - 1

                tf = CType(in_array(x), TaskFrame)
                If tf Is Nothing Then
                    Throw New ArgumentException(String.Format(VbPowerPackMain.GetResourceManager().GetString("excTaskPaneTaskFramesOnly"), in_array(x).GetType().ToString()))
                End If

                Me.Add(tf)

            Next

        End Sub ' ControlCollection.AddRange


    End Class ' ControlCollection


End Class ' TaskPane






'=--------------------------------------------------------------------------=
' TaskFrameCollection
'=--------------------------------------------------------------------------=
' all of the pages in the TaskFrame control are in a collection of
' TaskFrame objects
'
Public Class TaskFrameCollection
    Implements IList


    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    ' Private member variables and the likes
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '
    ' This is our actual list of pages and how many we've got.
    '
    Private m_frames() As TaskFrame
    Private m_cFrames As Integer

    '
    ' this is our parent TaskPane control
    '
    Private m_parent As TaskPane





    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                     Public Methods, Members, etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' we need to know who our parent is, and then go and set up some array 
    ' space for the frames.  Please note that this constructor is declared as
    ' "Friend" so that only we can create them and not end users.
    '
    ' Parameters:
    '       TaskFrame        - [in]  parent control
    '
    Friend Sub New(ByVal in_parent As TaskPane)

        Me.m_parent = in_parent

        System.Diagnostics.Debug.Assert(Not in_parent Is Nothing)

        '
        ' create a base space to hold the frames.  we'll grow it as
        ' necessary
        '
        Me.m_frames = New TaskFrame(3) {}
        Me.m_cFrames = 0

    End Sub


    '=----------------------------------------------------------------------=
    ' CopyTo                                                     ICollection]
    '=----------------------------------------------------------------------=
    ' Copy from our collection into the given dest array
    '
    Public Sub CopyTo(ByVal in_dest As System.Array, ByVal in_index As Integer) Implements System.Collections.ICollection.CopyTo

        If Me.m_cFrames <= in_index Then
            Throw New ArgumentException(VbPowerPackMain.GetResourceManager().GetString("excTaskPaneBogusIdx"))
        End If

        For i As Integer = in_index To Me.m_cFrames - 1
            in_dest(i) = Me.m_frames(i)
        Next

    End Sub


    '=----------------------------------------------------------------------=
    ' Count                                                      ICollection]
    '=----------------------------------------------------------------------=
    ' How many do we have so far?
    '
    Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
        Get
            Return Me.m_cFrames
        End Get
    End Property

    '=----------------------------------------------------------------------=
    ' IsSynchronized                                             ICollection]
    '=----------------------------------------------------------------------=
    ' Are we thread-safe?  No, we are not.
    '
    Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
        Get
            Return False
        End Get
    End Property

    '=----------------------------------------------------------------------=
    ' SyncRoot                                                   ICollection]
    '=----------------------------------------------------------------------=
    ' Object with which to synchronize for threading
    '
    Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
        Get
            Return Me
        End Get
    End Property

    '=----------------------------------------------------------------------=
    ' GetEnumerator                                              ICollection]
    '=----------------------------------------------------------------------=
    ' Returns an enumerator for the list of our TaskFrame controls
    '
    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator

        Dim pages() As TaskFrame

        '
        ' If there's nothing to enumerate return nothing.
        '
        If (Me.m_frames Is Nothing) OrElse Me.m_cFrames = 0 Then
            pages = New TaskFrame() {}
            Return pages.GetEnumerator()
        End If

        '
        ' we have to copy these over since we could have empty slots in our
        ' array of pages that we're not using.
        '
        pages = New TaskFrame(Me.m_cFrames - 1) {}
        For i As Integer = 0 To Me.m_cFrames - 1
            pages(i) = Me.m_frames(i)
        Next
        Return pages.GetEnumerator()

    End Function

    '=----------------------------------------------------------------------=
    ' Add
    '=----------------------------------------------------------------------=
    ' This is a strongly typed version of the Add method that only takes
    ' TaskFrames ...
    '
    ' Parameters:
    '       TaskFrame           - [in]  Add me to the collection please.
    '
    Public Function Add(ByVal in_newFrame As TaskFrame) As Integer

        '
        ' Arg Checking
        '
        If in_newFrame Is Nothing Then
            Throw New ArgumentException(VbPowerPackMain.GetResourceManager().GetString("excTaskPaneNullFrame"))
        End If

        '
        ' Please see the comments at the top of this file.  Basically, 
        ' because people don't HAVE to use this collectin to add/remove
        ' items, we initiate all adding and removing of this collection
        ' off the Controls collection on the parent TaskPane.
        '
        Me.m_parent.Controls.Add(in_newFrame)

    End Function ' Add (strongly typed)


    '=----------------------------------------------------------------------=
    ' Add                                                             [IList]
    '=----------------------------------------------------------------------=
    ' Adds a new frame to the end of the list.  This is the IList version of
    ' this function and is NOT strongly typed for TaskFrames
    '
    '
    Public Function Add(ByVal in_newFrame As Object) As Integer Implements System.Collections.IList.Add

        Dim tf As TaskFrame

        '
        ' Arg Checking
        '
        If in_newFrame Is Nothing Then
            Throw New ArgumentException(VbPowerPackMain.GetResourceManager().GetString("excTaskPaneNullFrame"))
        End If
        If Not TypeOf (in_newFrame) Is TaskFrame Then
            Throw New ArgumentException(String.Format(VbPowerPackMain.GetResourceManager().GetString("excTaskPaneTaskFramesOnly"), in_newFrame.GetType().ToString()))
        End If

        '
        ' Get in the correct format
        '
        tf = CType(in_newFrame, TaskFrame)

        Me.Add(tf)

    End Function ' Add (IList)


    '=----------------------------------------------------------------------=
    ' Clear                                                           [IList]
    '=----------------------------------------------------------------------=
    ' Removes all the frames from this control
    '
    Public Sub Clear() Implements System.Collections.IList.Clear

        If Me.m_frames Is Nothing Then Return

        '
        ' First clear out our control collection.  It's vital to do this,
        ' as it keys off us for the list of controls ...
        '
        Me.m_parent.Controls.Clear()

    End Sub ' Clear (IList)


    '=----------------------------------------------------------------------=
    ' Contains                                                        [IList]
    '=----------------------------------------------------------------------=
    ' Is the given frame one of ours?
    '
    Public Function Contains(ByVal in_amIFamily As Object) As Boolean Implements System.Collections.IList.Contains

        Return Not (IndexOf(in_amIFamily) = -1)

    End Function ' Contains (IList)


    '=----------------------------------------------------------------------=
    ' IndexOf                                                         [IList]
    '=----------------------------------------------------------------------=
    ' Returns the integer (zero-based) index of the item in our list, or 
    ' returns -1 if we don't have it as a member.
    '
    Public Function IndexOf(ByVal in_findMyIndex As Object) As Integer Implements System.Collections.IList.IndexOf

        For i As Integer = 0 To Me.m_cFrames - 1
            If Me.m_frames(i) Is in_findMyIndex Then
                Return i
            End If
        Next

        Return -1

    End Function ' IndexOf (IList)


    '=----------------------------------------------------------------------=
    ' Insert                                                          [IList]
    '=----------------------------------------------------------------------=
    ' Inserts the given page at the given index.
    '
    Public Sub Insert(ByVal in_index As Integer, ByVal in_newPage As Object) Implements System.Collections.IList.Insert

        Throw New NotSupportedException

    End Sub


    '=----------------------------------------------------------------------=
    ' IsFixedSize                                                     [IList]
    '=----------------------------------------------------------------------=
    ' Are we a fixed size?
    '
    Public ReadOnly Property IsFixedSize() As Boolean Implements System.Collections.IList.IsFixedSize
        Get
            Return False
        End Get
    End Property

    '=----------------------------------------------------------------------=
    ' IsReadOnly                                                      [IList]
    '=----------------------------------------------------------------------=
    ' Are we read-only ?
    '
    Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.IList.IsReadOnly
        Get
            Return False
        End Get
    End Property


    '=----------------------------------------------------------------------=
    ' Item
    '=----------------------------------------------------------------------=
    ' This is a strongly typed version of the Item() method that is used by
    ' indexers and array references, etc ...  This is preferred to the IList
    ' version, which only supports Object.
    '
    ' Parameters:
    '       Integer             - [in]  index of item to fetch
    '
    ' Type:
    '       TaskFrame
    '
    ' Notes:
    '       We do not support the Set() method on this because we do not yet
    '       support arbitrary item insertion/replacement (this is also true
    '       for other controls such as the TabControl, etc).  We may.
    '
    Default Public Property Item(ByVal in_index As Integer) As TaskFrame

        Get
            ' 
            ' arg checking
            '
            If in_index < 0 Or in_index >= Me.m_cFrames Then
                Throw New ArgumentException(VbPowerPackMain.GetResourceManager().GetString("excTaskPaneBogusIdx"))
            End If

            Return Me.m_frames(in_index)

        End Get

        Set(ByVal in_newFrame As TaskFrame)

            Throw New NotSupportedException(VbPowerPackMain.GetResourceManager().GetString("excTaskPaneInsertNotImpl"))

        End Set

    End Property ' Item

    '=----------------------------------------------------------------------=
    ' IListItem                                                       [IList]
    '=----------------------------------------------------------------------=
    ' Returns the TaskFrame object at the given index.  This is the IList
    ' version of this method that is NOT strongly typed to TaskFrame (blech).
    '
    Public Property IListItem(ByVal in_index As Integer) As Object Implements System.Collections.IList.Item

        Get
            ' 
            ' arg checking
            '
            If in_index < 0 Or in_index >= Me.m_cFrames Then
                Throw New ArgumentException(VbPowerPackMain.GetResourceManager().GetString("excTaskPaneBogusIdx"))
            End If

            Return Me.m_frames(in_index)

        End Get

        Set(ByVal in_replaceThisItem As Object)

            Throw New NotSupportedException(VbPowerPackMain.GetResourceManager().GetString("excTaskPaneInsertNotImpl"))

        End Set

    End Property ' IListItem

    '=----------------------------------------------------------------------=
    ' Remove
    '=----------------------------------------------------------------------=
    ' This is an overloaded version of the Remove method that goes and removes
    ' only those objects that are of type TaskFrame.
    '
    ' Parameters:
    '       TaskFrame               - [in]  remove me please.
    '
    Public Sub Remove(ByVal in_removeMe As TaskFrame)

        If in_removeMe Is Nothing Then
            Throw New ArgumentNullException("in_removeMe", "In TaskFrameCollection.Remove()")
        End If

        '
        ' Tell our parent's controls collection to remove this.
        ' Part of that operation will be to call removeFrameInternal
        ' on THIS class, which will remove it from our collection ...
        '
        Me.m_parent.Controls.Remove(in_removeMe)

    End Sub ' Remove (strongly typed)

    '=----------------------------------------------------------------------=
    ' Remove                                                          [IList]
    '=----------------------------------------------------------------------=
    ' removes the given page from our collection of pages
    '
    Public Sub Remove(ByVal in_removeMe As Object) Implements System.Collections.IList.Remove

        Dim tf As TaskFrame

        If in_removeMe Is Nothing Then
            Throw New ArgumentNullException("in_removeMe", "In TaskFrameCollection.Remove()")
        End If

        tf = CType(in_removeMe, TaskFrame)
        If tf Is Nothing Then
            Throw New ArgumentException("Object passed to TaskFrameCollection is not a TaskFrame.")
        End If

        '
        ' Pass the buck on.
        '
        Me.Remove(in_removeMe)

    End Sub ' Remove (IList)

    '=----------------------------------------------------------------------=
    ' RemoveAt                                                        [IList]
    '=----------------------------------------------------------------------=
    ' Removes the page at the given index
    '
    Public Sub RemoveAt(ByVal in_index As Integer) Implements System.Collections.IList.RemoveAt

        '
        ' 0. arg checking
        '
        If in_index < 0 Or in_index >= Me.m_cFrames Then
            Throw New ArgumentException(VbPowerPackMain.GetResourceManager().GetString("excTaskPaneBogusIdx"))
        End If

        '
        ' 1. Pass the buck.
        '
        Me.Remove(Me.m_frames(in_index))

    End Sub ' RemoveAt




    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '          Private/Protected/Friend    Methods, Members, etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' addFrameInternal
    '=----------------------------------------------------------------------=
    ' The programmer is trying to add the frame to the TaskPane's Controls
    ' collection instead of adding it to this collection.  The 
    ' ControlCollection will call this to be sure that it gets added to
    ' this collection anyhow.
    '
    ' Parameters:
    '       TaskFrame           - [in]  new frame being added.
    '
    Friend Sub addFrameInternal(ByVal in_frame As TaskFrame)

        '
        ' 1. make sure the array is big enough to hold it.
        '
        If Me.m_cFrames <= 0 And Me.m_frames Is Nothing Then

            Me.m_frames = New TaskFrame(7) {}

        ElseIf Not (Me.m_cFrames + 1) < Me.m_frames.GetLength(0) Then

            Dim rep() As TaskFrame

            rep = New TaskFrame((Me.m_cFrames * 2) - 1) {}
            Array.Copy(Me.m_frames, rep, Me.m_cFrames)

            Me.m_frames = rep

        End If

        '
        ' 2. Add the new Frame to our list, as well as our parent's
        '    control collection.
        '
        Me.m_frames(Me.m_cFrames) = in_frame
        Me.m_cFrames += 1

    End Sub ' addFrameInternal


    '=----------------------------------------------------------------------=
    ' removeFrameInternal
    '=----------------------------------------------------------------------=
    ' This goes and actually removes the frame from our collection of frames.
    ' It is factored out from the Remove() methods on IList because we also
    ' have to be able handle the case where the programmer works with the 
    ' TaskPane.Controls collection ...
    '
    ' Parameters:
    '       TaskFrame           - [in]  remove me please.
    '
    Friend Sub removeFrameInternal(ByVal in_frame As TaskFrame)

        If in_frame Is Nothing Then
            Throw New ArgumentException(VbPowerPackMain.GetResourceManager().GetString("excTaskPaneNullFrame"))
        End If

        '
        ' now, go and look for this frame.  if we find it, 
        ' then remove it.
        '
        For i As Integer = 0 To Me.m_cFrames - 1

            '
            ' found it !!!!
            '
            If Me.m_frames(i) Is in_frame Then
                For x As Integer = i To Me.m_cFrames - 1
                    Me.m_frames(x) = Me.m_frames(x + 1)
                Next

                Me.m_cFrames -= 1
                Return
            End If
        Next

        '
        ' Apparently, standard COR behaviour is to NOT throw an exception
        ' if we're asked to remove something that isn't ours ...
        '

    End Sub ' removeFrameInternal


    '=----------------------------------------------------------------------=
    ' clearInternal
    '=----------------------------------------------------------------------=
    ' Makes sure that we clear out our list of frames, etc ...
    '
    Friend Sub clearInternal()

        Me.m_frames = Nothing
        Me.m_cFrames = 0

    End Sub ' clearInternal



End Class ' TaskFrameCollection




'=--------------------------------------------------------------------------=
' TaskPaneEventArgs
'=--------------------------------------------------------------------------=
' Provides information about the frame being manipulated in the current
' event.
'
' 
Public Class TaskPaneEventArgs
    Inherits System.EventArgs

    '
    ' should we cancel?
    '
    Private m_cancel As Boolean

    '
    ' The frame being manipulated by this event.
    '
    Private m_taskFrame As TaskFrame


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initialise a new instance of this class.
    '
    ' Parameters:
    '       TaskFrame               - [in]  frame being referred to in this evt
    '
    Public Sub New(ByVal in_frame As TaskFrame)

        Me.m_taskFrame = in_frame

    End Sub  ' New


    '=----------------------------------------------------------------------=
    ' TaskFrame
    '=----------------------------------------------------------------------=
    ' The frame for the event
    '
    ' Type:
    '       TaskFrame
    '
    <LocalisableDescription("TaskPaneEA.TaskFrame")> _
    Public ReadOnly Property TaskFrame() As TaskFrame

        Get
            Return Me.m_taskFrame
        End Get

    End Property ' TaskFrame


End Class ' TaskPaneEventArgs


'=--------------------------------------------------------------------------=
' TaskPaneCancelEventArgs
'=--------------------------------------------------------------------------=
' Allows a TaskPaneEvent to be cancelled
'
'
'
Public Class TaskPaneCancelEventArgs
    Inherits TaskPaneEventArgs

    '
    ' Should this event be cancelled?
    '
    Private m_cancel As Boolean


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initialise a new instance of this class
    '
    ' Parameters:
    '       TaskFrame               - [in]  frame that generated this event.
    '
    Public Sub New(ByVal in_taskFrame As TaskFrame)

        MyBase.New(in_taskFrame)

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' Cancel
    '=----------------------------------------------------------------------=
    ' Should the event be cancelled.
    '
    ' Type:
    '       Boolean
    '
    <LocalisableDescription("TaskPaneCEA.Cancel")> _
    Public Property Cancel() As Boolean

        Get
            Return Me.m_cancel
        End Get

        Set(ByVal Value As Boolean)
            Me.m_cancel = Value
        End Set

    End Property ' Cancel


End Class ' TaskPaneCancelEventArgs

