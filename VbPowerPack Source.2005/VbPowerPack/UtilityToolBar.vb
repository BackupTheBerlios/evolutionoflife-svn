'-------------------------------------------------------------------------------
'<copyright file="UtilityToolBar.vb" company="Microsoft">
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
' UtilityToolBar
'=--------------------------------------------------------------------------=
' A specialized version of the regular WinForms ToolBar class that has a 
' fixed set of buttons available, each with its own event on the main class.
' The buttons shown will be customisable both at design and run time.
'
'
<Designer(GetType(Design.UtilityToolBarDesigner)), _
 DefaultProperty("Buttons"), _
 DefaultEvent("Click")> _
Public Class UtilityToolBar
    Inherits ToolBar


    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                   Private/Protected  Member data
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '
    ' Controls how text labels and tooltips are shown.
    '
    Private m_showText As UtilityToolBarShowText

    '
    ' controls how the icons are shown
    '
    Private m_iconOptions As UtilityToolBarIconOptions

    '
    ' there is an issue in the WinForms ToolBar by which it does
    ' not correctly reset the size grips when a new row of buttons is added.
    ' this member variable is one of the only ways to get aorund this.
    '
    Private m_resizeHack As Boolean


    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '               Public Methods/Functions/Properties/etc.
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initialises a new instance of this control.
    '
    Public Sub New()
        MyBase.New()

        '
        ' Set up some reasonable defaults.
        '
        MyBase.DropDownArrows = True

        '
        ' This will set the following properties on our base class:
        ' ShowToolTips, TextAlign
        '
        Me.ShowText = UtilityToolBarShowText.ShowSelectiveLabels

        '
        ' Default to Small Icons
        '
        Me.IconOptions = UtilityToolBarIconOptions.SmallIcons

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' ShowText
    '=----------------------------------------------------------------------=
    ' Controls if and how the text is shown for individual buttons on the
    ' UtilityToolBar control.  Possible values come from the 
    ' UtilityToolBarShowText enumeration
    '
    <LocalisableDescription("UtilityToolBar.ShowText"), _
     Category("Appearance"), _
     DefaultValue(VbPowerPack.UtilityToolBarShowText.ShowSelectiveLabels), _
     Localizable(True)> _
    Public Overridable Property ShowText() As UtilityToolBarShowText

        Get
            Return Me.m_showText
        End Get

        Set(ByVal in_showText As UtilityToolBarShowText)

            '
            ' if there's a new value, set it, and then go and
            ' set some properties to reflect this, and then go
            ' and tell the buttons about it ...
            '
            If Not Me.m_showText = in_showText Then

                Me.m_showText = in_showText

                Select Case Me.m_showText
                    Case UtilityToolBarShowText.ShowNoLabels
                        MyBase.ShowToolTips = True
                        MyBase.TextAlign = ToolBarTextAlign.Underneath

                    Case UtilityToolBarShowText.ShowSelectiveLabels
                        MyBase.ShowToolTips = True
                        MyBase.TextAlign = ToolBarTextAlign.Right

                    Case UtilityToolBarShowText.ShowTextLabels
                        MyBase.ShowToolTips = False
                        MyBase.TextAlign = ToolBarTextAlign.Underneath
                End Select

                '
                ' now tell all the buttons about the new value.
                '
                For Each x As ToolBarButton In Me.Buttons

                    Dim utb As UtilityToolBarButton

                    If (TypeOf x Is UtilityToolBarButton) Then
                        utb = CType(x, UtilityToolBarButton)
                        If Not utb Is Nothing Then
                            utb.updateTextValues(in_showText)
                        End If
                    End If
                Next
            End If
        End Set

    End Property ' ShowText


    '=----------------------------------------------------------------------=
    ' Buttons
    '=----------------------------------------------------------------------=
    ' This returns the set of buttons available in this control. 
    ' 
    ' We also need to make sure to set up our editor here ...
    '
    <Editor("VbPowerPack.Design.UtilityToolBarButtonEditor", GetType(System.Drawing.Design.UITypeEditor))> _
    Public Overridable Shadows ReadOnly Property Buttons() As ToolBarButtonCollection

        Get
            Return MyBase.Buttons
        End Get

    End Property ' Buttons


    '=----------------------------------------------------------------------=
    ' IconOptions
    '=----------------------------------------------------------------------=
    ' Controls how the icons are displayed in the control.
    '
    ' Type:
    '       UtilityToolBarIconOptions
    '
    <LocalisableDescription("UtilityToolBar.IconOptions"), _
     Category("Appearance"), _
     DefaultValue(VbPowerPack.UtilityToolBarIconOptions.SmallIcons), _
     Localizable(True)> _
    Public Property IconOptions() As UtilityToolBarIconOptions

        Get
            Return Me.m_iconOptions
        End Get

        '
        ' Set the new option, and recreate the ImageList if necessary
        '
        Set(ByVal in_newIconOptions As UtilityToolBarIconOptions)

            If in_newIconOptions < 0 Or in_newIconOptions > 1 Then
                Throw New ArgumentOutOfRangeException("Value")
            End If

            If Not in_newIconOptions = Me.m_iconOptions Then
                Me.m_iconOptions = in_newIconOptions
                If Me.IsHandleCreated Then
                    resetImageList()
                End If
            End If
        End Set

    End Property ' IconOptions



    '=----------------------------------------------------------------------=
    ' ButtonSize
    '=----------------------------------------------------------------------=
    ' Attempt to hide the property.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), RefreshProperties(RefreshProperties.All)> _
    Public Overridable Shadows Property ButtonSize() As Size

        Get
            Return MyBase.ButtonSize
        End Get

        Set(ByVal in_newButtonSize As Size)
            MyBase.ButtonSize = in_newButtonSize
        End Set

    End Property ' ButtonSize


    '=----------------------------------------------------------------------=
    ' DropDownArrows
    '=----------------------------------------------------------------------=
    ' Attempt to hide the property.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property DropDownArrows() As Boolean

        Get
            Return MyBase.DropDownArrows
        End Get

        Set(ByVal in_newDropDownArrows As Boolean)
            MyBase.DropDownArrows = in_newDropDownArrows
        End Set

    End Property ' DropDownArrows


    '=----------------------------------------------------------------------=
    ' ImageList
    '=----------------------------------------------------------------------=
    ' Attempt to hide the property.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overridable Shadows Property ImageList() As ImageList

        Get
            Return MyBase.ImageList
        End Get

        Set(ByVal in_imageList As ImageList)

            '
            ' Ignore this.  
            '

        End Set

    End Property ' ImageList


    '=----------------------------------------------------------------------=
    ' ShowToolTips
    '=----------------------------------------------------------------------=
    ' Attempt to hide the property.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overridable Shadows Property ShowToolTips() As Boolean

        Get
            Return MyBase.ShowToolTips
        End Get

        Set(ByVal in_showToolTips As Boolean)

            '
            ' Ignore this.  We set this to True in our constructor
            ' and that's how it's going to be!
            ' NOTE: People can still get around this by casting this
            ' object to a regular ToolBar control, and setting the 
            ' ShowToolTips there.  This irks me, but I don't see much I
            ' can do about it ... !!!! argh.
            '

        End Set

    End Property  ' ShowToolTips


    '=----------------------------------------------------------------------=
    ' TextAlign
    '=----------------------------------------------------------------------=
    ' Attempt to hide the property.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overridable Shadows Property TextAlign() As Boolean

        Get
            Return MyBase.TextAlign
        End Get

        Set(ByVal in_textAlign As Boolean)

            '
            ' Ignore this.  We manipulate this property depending on
            ' the value of the ShowText property.
            '

        End Set

    End Property ' TextAlign


    '=----------------------------------------------------------------------=
    ' ShowCustomizeDialog
    '=----------------------------------------------------------------------=
    ' Shows the customise dialog, letting the end user change the collection
    ' of buttons visible.
    '
    ' Please note that it's up to the application to actually persist these
    ' changes across Application invokes!
    '
    <LocalisableDescription("UtilityToolBar.ShowCustomizeDialog")> _
    Public Sub ShowCustomizeDialog()

        '
        ' Just show the dialog sans mask.
        '
        ShowCustomizeDialog(&HFFFFFFFF)

    End Sub ' ShowCustomizeDialog


    '=----------------------------------------------------------------------=
    ' ShowCustomizeDialog
    '=----------------------------------------------------------------------=
    ' Shows the customise dialog, letting the end user change the collection
    ' of buttons visible.
    '
    ' Parameters:
    '       Integer         - [in]  Bit mask specifying categories of buttons
    '                               to show.
    '
    ' Please note that it's up to the application to actually persist these
    ' changes across Application invokes!
    '
    <LocalisableDescription("UtilityToolBar.ShowCustomizeDialog")> _
    Public Sub ShowCustomizeDialog(ByVal in_mask As Integer)

        Dim items() As UtilityToolBarCustomiseDialog.ListBoxButtonData
        Dim lbbd As UtilityToolBarCustomiseDialog.ListBoxButtonData
        Dim cd As UtilityToolBarCustomiseDialog
        Dim utb As UtilityToolBarButton
        Dim dr As DialogResult

        '
        ' create and show the customise dialog.  We'll parent it off 
        ' ourselves for showing it modally .
        '
        cd = New UtilityToolBarCustomiseDialog(Me.Buttons, Me, in_mask)
        dr = cd.ShowDialog(Me)
        If dr = DialogResult.Cancel Then Return

        '
        ' Now, go and get the values they wanted to put into the new
        ' set, and go and set them up now
        '
        Me.Buttons.Clear()
        items = New UtilityToolBarCustomiseDialog.ListBoxButtonData(cd.currentListBox.Items.Count() - 2) {}
        For x As Integer = 0 To cd.currentListBox.Items.Count() - 2

            lbbd = CType(cd.currentListBox.Items(x), UtilityToolBarCustomiseDialog.ListBoxButtonData)
            System.Diagnostics.Debug.Assert(Not lbbd Is Nothing, "Bogus Type in Customise list box!!!")
            items(x) = lbbd

        Next

        '
        ' Great, now loop through this array and add them one at a
        ' time ...
        '
        For Each button As UtilityToolBarCustomiseDialog.ListBoxButtonData In items

            If button.m_imageIndex = -1 Then
                utb = New UtilityToolBarButton("")
                utb.Style = ToolBarButtonStyle.Separator
            Else
                utb = UtilityToolBarButton.CreateButtonForType(button.m_imageIndex)
            End If

            Me.Buttons.Add(utb)
        Next

        '
        ' Finally, set up the other props
        '
        Me.IconOptions = cd.iconOptionsCombo.SelectedIndex
        Me.ShowText = cd.textOptionsCombo.SelectedIndex

    End Sub ' ShowCustomizeDialog




    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '         Private/Protected/Friend Properties/Methods/Functions
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' OnButtonClicked
    '=----------------------------------------------------------------------=
    ' The user has clicked a button.  Go and fire one of our events instead
    ' of the default ButtonClick event.
    '
    ' Parameters:
    '       ToolBarButtonClickEventArgs - [in]  the Info.
    '
    Protected Overrides Sub OnButtonClick(ByVal e As ToolBarButtonClickEventArgs)

        '
        ' First of all, make sure it's one of our buttons ...
        '
        If Not TypeOf (e.Button) Is UtilityToolBarButton Then
            MyBase.OnButtonClick(e)
            Return
        End If


        '
        ' Now, figure out what type of button it is, and then go and fire
        ' the appropriate event for it ...
        '
        Select Case e.Button.ImageIndex

            Case UtilityToolBarButtonType.BackUtilityButton
                If Not TypeOf (e.Button) Is BackUtilityButton Then Return
                RaiseEvent BackPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.ForwardUtilityButton
                If Not TypeOf (e.Button) Is ForwardUtilityButton Then Return
                RaiseEvent ForwardPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.UpUtilityButton
                If Not TypeOf (e.Button) Is UpUtilityButton Then Return
                RaiseEvent UpPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.SearchUtilityButton
                If Not TypeOf (e.Button) Is SearchUtilityButton Then Return
                RaiseEvent SearchPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.FoldersUtilityButton
                If Not TypeOf (e.Button) Is FoldersUtilityButton Then Return
                RaiseEvent FoldersPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.ViewsUtilityButton
                If Not TypeOf (e.Button) Is ViewsUtilityButton Then Return
                RaiseEvent ViewsPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.StopUtilityButton
                If Not TypeOf (e.Button) Is StopUtilityButton Then Return
                RaiseEvent StopPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.RefreshUtilityButton
                If Not TypeOf (e.Button) Is RefreshUtilityButton Then Return
                RaiseEvent RefreshPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.HomeUtilityButton
                If Not TypeOf (e.Button) Is HomeUtilityButton Then Return
                RaiseEvent HomePressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.MapDriveUtilityButton
                If Not TypeOf (e.Button) Is MapDriveUtilityButton Then Return
                RaiseEvent MapDrivePressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.DisconnectUtilityButton
                If Not TypeOf (e.Button) Is DisconnectUtilityButton Then Return
                RaiseEvent DisconnectPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.FavoritesUtilityButton
                If Not TypeOf (e.Button) Is FavoritesUtilityButton Then Return
                RaiseEvent FavoritesPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.HistoryUtilityButton
                If Not TypeOf (e.Button) Is HistoryUtilityButton Then Return
                RaiseEvent HistoryPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.FullScreenUtilityButton
                If Not TypeOf (e.Button) Is FullScreenUtilityButton Then Return
                RaiseEvent FullScreenPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.MoveToUtilityButton
                If Not TypeOf (e.Button) Is MoveToUtilityButton Then Return
                RaiseEvent MoveToPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.CopyToUtilityButton
                If Not TypeOf (e.Button) Is CopyToUtilityButton Then Return
                RaiseEvent CopyToPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.DeleteUtilityButton
                If Not TypeOf (e.Button) Is DeleteUtilityButton Then Return
                RaiseEvent DeletePressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.UndoUtilityButton
                If Not TypeOf (e.Button) Is UndoUtilityButton Then Return
                RaiseEvent UndoPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.PropertiesUtilityButton
                If Not TypeOf (e.Button) Is PropertiesUtilityButton Then Return
                RaiseEvent PropertiesPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.CutUtilityButton
                If Not TypeOf (e.Button) Is CutUtilityButton Then Return
                RaiseEvent CutPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.CopyUtilityButton
                If Not TypeOf (e.Button) Is CopyUtilityButton Then Return
                RaiseEvent CopyPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.PasteUtilityButton
                If Not TypeOf (e.Button) Is PasteUtilityButton Then Return
                RaiseEvent PastePressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.FolderOptionsUtilityButton
                If Not TypeOf (e.Button) Is FolderOptionsUtilityButton Then Return
                RaiseEvent FolderOptionsPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.MailUtilityButton
                If Not TypeOf (e.Button) Is MailUtilityButton Then Return
                RaiseEvent MailPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.PrintUtilityButton
                If Not TypeOf (e.Button) Is PrintUtilityButton Then Return
                RaiseEvent PrintPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.SaveUtilityButton
                If Not TypeOf (e.Button) Is SaveUtilityButton Then Return
                RaiseEvent SavePressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.LoadUtilityButton
                If Not TypeOf (e.Button) Is LoadUtilityButton Then Return
                RaiseEvent LoadPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.SaveAllUtilityButton
                If Not TypeOf (e.Button) Is SaveAllUtilityButton Then Return
                RaiseEvent SaveAllPressed(Me, EventArgs.Empty)

            Case UtilityToolBarButtonType.PrintPreviewUtilityButton
                If Not TypeOf (e.Button) Is PrintPreviewUtilityButton Then Return
                RaiseEvent PrintPreviewPressed(Me, EventArgs.Empty)

            Case Else
                System.Diagnostics.Debug.Fail("Unexpected button type.")

        End Select ' e.Button.ImageIndex

    End Sub ' OnButtonClick


    '=----------------------------------------------------------------------=
    ' resetImageList
    '=----------------------------------------------------------------------=
    ' Depending on our icon size, go and set our image list to have the
    ' right icons
    '
    Private Sub resetImageList()

        '
        ' 1. Properties common to both types of image lists.
        '
        MyBase.ImageList = New ImageList
        MyBase.ImageList.ColorDepth = ColorDepth.Depth24Bit
        MyBase.ImageList.TransparentColor = Color.Cyan

        '
        ' Now go and load in the appropriate image strip for the current
        ' image size.
        '
        If Me.IconOptions = UtilityToolBarIconOptions.LargeIcons Then
            MyBase.ImageList.ImageSize = New Size(24, 24)
            MyBase.ImageList.Images.AddStrip(New Bitmap(GetType(UtilityToolBar), "UtilityToolBarImagesLg.bmp"))
        Else
            MyBase.ImageList.ImageSize = New Size(16, 16)
            MyBase.ImageList.Images.AddStrip(New Bitmap(GetType(UtilityToolBar), "UtilityToolBarImages.bmp"))
        End If

        If Me.IsHandleCreated Then
            RecreateHandle()
        End If

    End Sub ' resetImageList



    '=----------------------------------------------------------------------=
    ' CreateHandle
    '=----------------------------------------------------------------------=
    ' When the control handle has been recreated, go and tell all of our
    ' buttons to update their text correctly ...
    '
    Protected Overrides Sub CreateHandle()

        Dim utb As UtilityToolBarButton

        resetImageList()

        '
        ' 1. Set the text values for each of the buttons, depending on the
        '    TextOptions property.
        '
        For x As Integer = 0 To Me.Buttons.Count - 1

            If (TypeOf Me.Buttons(x) Is UtilityToolBarButton) Then
                utb = CType(Me.Buttons(x), UtilityToolBarButton)
                utb.updateTextValues(Me.ShowText)
            End If

        Next

        '
        ' 2. Finally, tell the base to continue doing its work
        '
        MyBase.CreateHandle()

    End Sub ' CreateHandle


    '=----------------------------------------------------------------------=
    ' findAppropriateEvent
    '=----------------------------------------------------------------------=
    ' The user has given us a button index, so go and see what button it is
    ' and then return the even that would best match it.
    '
    ' Returns:
    '       The Name of the event that best matches the index.
    '
    Friend Function findAppropriateEvent(ByVal in_index As Integer) As String

        Dim utbb As UtilityToolBarButton

        If in_index < 0 OrElse in_index >= Me.Buttons.Count Then
            Return ""
        End If

        utbb = Me.Buttons(in_index)

        Select Case utbb.ImageIndex

            Case UtilityToolBarButtonType.BackUtilityButton
                Return "BackPressed"

            Case UtilityToolBarButtonType.ForwardUtilityButton
                Return "ForwardPressed"

            Case UtilityToolBarButtonType.UpUtilityButton
                Return "UpPressed"

            Case UtilityToolBarButtonType.SearchUtilityButton
                Return "SearchPressed"

            Case UtilityToolBarButtonType.FoldersUtilityButton
                Return "FoldersPressed"

            Case UtilityToolBarButtonType.ViewsUtilityButton
                Return "ViewsPressed"

            Case UtilityToolBarButtonType.StopUtilityButton
                Return "StopPressed"

            Case UtilityToolBarButtonType.RefreshUtilityButton
                Return "RefreshPressed"

            Case UtilityToolBarButtonType.HomeUtilityButton
                Return "HomePressed"

            Case UtilityToolBarButtonType.MapDriveUtilityButton
                Return "MapDrivePressed"

            Case UtilityToolBarButtonType.DisconnectUtilityButton
                Return "DisconnectPressed"

            Case UtilityToolBarButtonType.FavoritesUtilityButton
                Return "FavoritesPressed"

            Case UtilityToolBarButtonType.HistoryUtilityButton
                Return "HistoryPressed"

            Case UtilityToolBarButtonType.FullScreenUtilityButton
                Return "FullScreenPressed"

            Case UtilityToolBarButtonType.MoveToUtilityButton
                Return "MoveToPressed"

            Case UtilityToolBarButtonType.CopyToUtilityButton
                Return "CopyToPressed"

            Case UtilityToolBarButtonType.DeleteUtilityButton
                Return "DeletePressed"

            Case UtilityToolBarButtonType.UndoUtilityButton
                Return "UndoPressed"

            Case UtilityToolBarButtonType.PropertiesUtilityButton
                Return "PropertiesPressed"

            Case UtilityToolBarButtonType.CutUtilityButton
                Return "CutPressed"

            Case UtilityToolBarButtonType.CopyUtilityButton
                Return "CopyPressed"

            Case UtilityToolBarButtonType.PasteUtilityButton
                Return "PastePressed"

            Case UtilityToolBarButtonType.FolderOptionsUtilityButton
                Return "FolderOptionsPressed"

            Case UtilityToolBarButtonType.MailUtilityButton
                Return "MailPressed"

            Case UtilityToolBarButtonType.PrintUtilityButton
                Return "PrintPressed"

            Case UtilityToolBarButtonType.SaveUtilityButton
                Return "SavePressed"

            Case UtilityToolBarButtonType.LoadUtilityButton
                Return "LoadPressed"

            Case UtilityToolBarButtonType.SaveAllUtilityButton
                Return "SaveAllPressed"

            Case UtilityToolBarButtonType.PrintPreviewUtilityButton
                Return "PrintPreviewPressed"

            Case Else
                '
                ' Separator, or something else ...  Just choose some
                ' harmless event and let users play with that.
                '
                Return "Click"

        End Select

    End Function ' findAppropriateEvent


    '=----------------------------------------------------------------------=
    ' shouldSerializeButtonSize
    '=----------------------------------------------------------------------=
    ' no.  This is particularly bad because some of our buttons will be large
    ' with text on the right, and others will not.
    '
    Private Function ShouldSerializeButtonSize() As Boolean

        Return False

    End Function ' ShouldSerializeButtonSize


    '=----------------------------------------------------------------------=
    ' setResizeHack
    '=----------------------------------------------------------------------=
    ' This method lets our designer tell us that our buttons have been changed
    ' which in turn lets us decide to force a changing of the size grips when
    ' we get a chance.
    '
    Friend Sub setResizeHack()

        Me.m_resizeHack = True

    End Sub ' setResizeHack


    '=----------------------------------------------------------------------=
    ' WndProc
    '=----------------------------------------------------------------------=
    ' This is here to let us reset the size grips at design time when the
    ' buttons change.
    '
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        Dim msg As Integer

        '
        ' is it WM_NOTIFY
        '
        If m.Msg = &H400 + &H1C00 + &H4E Then
            msg = Marshal.ReadInt32(m.LParam, 8)
            If msg = -12 Then
                If Me.m_resizeHack Then

                    Dim iccs As System.ComponentModel.design.IComponentChangeService

                    If Not Me.Site Is Nothing Then
                        iccs = CType(Me.Site.GetService(GetType(System.ComponentModel.Design.IComponentChangeService)), System.ComponentModel.Design.IComponentChangeService)
                        If Not iccs Is Nothing Then
                            iccs.OnComponentChanged(Me, TypeDescriptor.GetProperties(Me.GetType())("Buttons"), Nothing, Nothing)
                        End If
                    End If
                    Me.m_resizeHack = False
                End If

            End If
        End If

        '
        ' Always pass the message on.
        '
        MyBase.WndProc(m)

    End Sub ' WndProc




    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                              EVENTS
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' ButtonClick
    '=----------------------------------------------------------------------=
    ' We'll hide this from our parent ToolBar control.  We have our own
    ' Events for the various buttons.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Event ButtonClick(ByVal sender As Object, ByVal e As ToolBarButtonClickEventArgs)


    '=----------------------------------------------------------------------=
    ' ButtonDropDown
    '=----------------------------------------------------------------------=
    ' We'll hide this from our parent ToolBar control.  We have our own
    ' Events for the various buttons.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Event ButtonDropDown(ByVal sender As Object, ByVal e As ToolBarButtonClickEventArgs)


    '=----------------------------------------------------------------------=
    ' BackPressed
    '=----------------------------------------------------------------------=
    ' The "Back" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.BackPressed"), _
     Category("Behavior")> _
    Public Event BackPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' ForwardPressed
    '=----------------------------------------------------------------------=
    ' The "Forward" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.ForwardPressed"), _
     Category("Behavior")> _
    Public Event ForwardPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' UpPressed
    '=----------------------------------------------------------------------=
    ' The "Up" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.UpPressed"), _
     Category("Behavior")> _
    Public Event UpPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' SearchPressed
    '=----------------------------------------------------------------------=
    ' The "Search" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.SearchPressed"), _
     Category("Behavior")> _
    Public Event SearchPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' FoldersPressed
    '=----------------------------------------------------------------------=
    ' The "Folders" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.FoldersPressed"), _
     Category("Behavior")> _
    Public Event FoldersPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' ViewsPressed
    '=----------------------------------------------------------------------=
    ' The "Views" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.ViewsPressed"), _
     Category("Behavior")> _
    Public Event ViewsPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' StopPressed
    '=----------------------------------------------------------------------=
    ' The "Stop" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.StopPressed"), _
     Category("Behavior")> _
    Public Event StopPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' RefreshPressed
    '=----------------------------------------------------------------------=
    ' The "Refresh" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.RefreshPressed"), _
     Category("Behavior")> _
    Public Event RefreshPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' HomePressed
    '=----------------------------------------------------------------------=
    ' The "Home" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.HomePressed"), _
     Category("Behavior")> _
    Public Event HomePressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' MapDrivePressed
    '=----------------------------------------------------------------------=
    ' The "MapDrive" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.MapDrivePressed"), _
     Category("Behavior")> _
    Public Event MapDrivePressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' DisconnectPressed
    '=----------------------------------------------------------------------=
    ' The "Disconnect" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.DisconnectPressed"), _
     Category("Behavior")> _
    Public Event DisconnectPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' FavoritesPressed
    '=----------------------------------------------------------------------=
    ' The "Favorites" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.FavoritesPressed"), _
     Category("Behavior")> _
    Public Event FavoritesPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' HistoryPressed
    '=----------------------------------------------------------------------=
    ' The "History" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.HistoryPressed"), _
     Category("Behavior")> _
    Public Event HistoryPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' FullScreenPressed
    '=----------------------------------------------------------------------=
    ' The "FullScreen" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.FullScreenPressed"), _
     Category("Behavior")> _
    Public Event FullScreenPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' MoveToPressed
    '=----------------------------------------------------------------------=
    ' The "MoveTo" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.MoveToPressed"), _
     Category("Behavior")> _
    Public Event MoveToPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' CopyToPressed
    '=----------------------------------------------------------------------=
    ' The "CopyTo" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.CopyToPressed"), _
     Category("Behavior")> _
    Public Event CopyToPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' DeletePressed
    '=----------------------------------------------------------------------=
    ' The "Delete" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.DeletePressed"), _
     Category("Behavior")> _
    Public Event DeletePressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' UndoPressed
    '=----------------------------------------------------------------------=
    ' The "Undo" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.UndoPressed"), _
     Category("Behavior")> _
    Public Event UndoPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' PropertiesPressed
    '=----------------------------------------------------------------------=
    ' The "Properties" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.PropertiesPressed"), _
     Category("Behavior")> _
    Public Event PropertiesPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' CutPressed
    '=----------------------------------------------------------------------=
    ' The "Cut" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.CutPressed"), _
     Category("Behavior")> _
    Public Event CutPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' CopyPressed
    '=----------------------------------------------------------------------=
    ' The "Copy" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.CopyPressed"), _
     Category("Behavior")> _
    Public Event CopyPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' PastePressed
    '=----------------------------------------------------------------------=
    ' The "Paste" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.PastePressed"), _
     Category("Behavior")> _
    Public Event PastePressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' FolderOptionsPressed
    '=----------------------------------------------------------------------=
    ' The "FolderOptions" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.FolderOptionsPressed"), _
     Category("Behavior")> _
    Public Event FolderOptionsPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' MailPressed
    '=----------------------------------------------------------------------=
    ' The "Mail" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.MailPressed"), _
     Category("Behavior")> _
    Public Event MailPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' PrintPressed
    '=----------------------------------------------------------------------=
    ' The "Print" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.PrintPressed"), _
     Category("Behavior")> _
    Public Event PrintPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' SavePressed
    '=----------------------------------------------------------------------=
    ' The "Save" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.SavePressed"), _
     Category("Behavior")> _
    Public Event SavePressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' LoadPressed
    '=----------------------------------------------------------------------=
    ' The "Load" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.LoadPressed"), _
     Category("Behavior")> _
    Public Event LoadPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' SaveAllPressed
    '=----------------------------------------------------------------------=
    ' The "SaveAll" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.SaveAllPressed"), _
     Category("Behavior")> _
    Public Event SaveAllPressed(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' PrintPreviewPressed
    '=----------------------------------------------------------------------=
    ' The "PrintPreview" was pressed.
    '
    <LocalisableDescription("UtilityToolBar.PrintPreviewPressed"), _
     Category("Behavior")> _
    Public Event PrintPreviewPressed(ByVal sender As Object, ByVal e As EventArgs)


End Class ' UtilityToolBar



