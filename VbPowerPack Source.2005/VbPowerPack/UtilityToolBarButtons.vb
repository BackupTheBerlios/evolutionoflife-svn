'-------------------------------------------------------------------------------
'<copyright file="UtilityToolBarButtons.vb" company="Microsoft">
'   Copyright (c) Microsoft Corporation. All rights reserved.
'</copyright>
'
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'-------------------------------------------------------------------------------

Imports System.Windows.Forms
Imports System.ComponentModel




'=--------------------------------------------------------------------------=
' UtilityToolBarButton
'=--------------------------------------------------------------------------=
' Superclass from which all or our specific buttons will inherit.  We are 
' doing this strictly so we can type check against this class instead of
' having to always have a 25+ item Select Case statement which would be a 
' hassle to maintain, and extraordinarily inefficient ...
'
'
Public Class UtilityToolBarButton
    Inherits ToolBarButton

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                   Private/Protected Local Data
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '
    ' We have to have a "shadow" text property here, since there are 
    ' cases where we'll want some of these controls to have text and 
    ' others where we won't.
    '
    Protected m_text As String

    '
    ' This indicates whether or not the control is one where "selected text"
    ' should show text or not.  By default, it's no.
    '
    Protected m_showForSelectedText As Boolean


    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                  Public Methods/Properties/Functions
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class given the text that we may
    ' or may not display for it.  This text will also serve as ToolTipText
    ' for those cases where the caption isn't drawn.
    '
    ' Parameters:
    '       String                  - [in]  Text caption for the button
    '       Boolean [optional]      - [in]  Do we show text when "Seleted
    '                                       Text" indicated?
    '
    Public Sub New(ByVal in_text As String, _
                   Optional ByVal in_showForSelectedText As Boolean = False)

        MyBase.New()

        If in_text Is Nothing Then
            Throw New ArgumentNullException("in_text", "Invalid parameter in UtilityToolBarButton constructor")
        End If

        Me.m_text = in_text
        Me.m_showForSelectedText = in_showForSelectedText

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' This is the plain vanilla version of the constructor, and should only
    ' be called from the Forms designer or other places where users want to
    ' set up a button that is a separator ...
    '
    Public Sub New()
        MyBase.New()

    End Sub 'new


    '=----------------------------------------------------------------------=
    ' ImageIndex
    '=----------------------------------------------------------------------=
    ' Attempt to hide the property.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property ImageIndex() As Integer

        Get
            Return MyBase.ImageIndex
        End Get

        Set(ByVal newImageIndex As Integer)
            MyBase.ImageIndex = newImageIndex
        End Set

    End Property ' ImageIndex


    '=----------------------------------------------------------------------=
    ' Style
    '=----------------------------------------------------------------------=
    ' Attempt to hide the property.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property Style() As ToolBarButtonStyle

        Get
            Return MyBase.Style
        End Get

        Set(ByVal newStyle As ToolBarButtonStyle)
            MyBase.Style = newStyle
        End Set

    End Property ' Style


    '=----------------------------------------------------------------------=
    ' Text
    '=----------------------------------------------------------------------=
    ' Attempt to hide the property.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property Text() As String

        Get
            Return MyBase.Text
        End Get

        Set(ByVal newText As String)
            MyBase.Text = newText
        End Set

    End Property ' Text


    '=----------------------------------------------------------------------=
    ' ToolTipText
    '=----------------------------------------------------------------------=
    ' Attempt to hide the property.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property ToolTipText() As String
        Get
            Return MyBase.ToolTipText
        End Get

        Set(ByVal newToolTipText As String)
            MyBase.ToolTipText = newToolTipText
        End Set

    End Property ' ToolTipText



    '=----------------------------------------------------------------------=
    ' GetCategoryForButton
    '=----------------------------------------------------------------------=
    ' Returns the Category bit for the given Button Type ...
    '
    ' Parameters:
    '       UtilityToolBarButtonType        - [in]  find my category please.
    '
    ' Returns:
    '       Integer                         - category
    '
    Friend Shared Function GetCategoryForButton( _
                                      ByVal in_button As UtilityToolBarButtonType) _
                                      As Integer

        Select Case in_button

            Case UtilityToolBarButtonType.BackUtilityButton, _
                 UtilityToolBarButtonType.ForwardUtilityButton, _
                 UtilityToolBarButtonType.UpUtilityButton, _
                 UtilityToolBarButtonType.StopUtilityButton, _
                 UtilityToolBarButtonType.RefreshUtilityButton, _
                 UtilityToolBarButtonType.HomeUtilityButton

                Return UtilityToolBarButtonCategories.BasicBrowsing

            Case UtilityToolBarButtonType.SearchUtilityButton, _
                 UtilityToolBarButtonType.FoldersUtilityButton, _
                 UtilityToolBarButtonType.ViewsUtilityButton, _
                 UtilityToolBarButtonType.FavoritesUtilityButton, _
                 UtilityToolBarButtonType.HistoryUtilityButton, _
                 UtilityToolBarButtonType.FullScreenUtilityButton

                Return UtilityToolBarButtonCategories.AdvancedBrowsing

            Case UtilityToolBarButtonType.CutUtilityButton, _
                 UtilityToolBarButtonType.CopyToUtilityButton, _
                 UtilityToolBarButtonType.PasteUtilityButton, _
                 UtilityToolBarButtonType.UndoUtilityButton

                Return UtilityToolBarButtonCategories.Clipboard

            Case UtilityToolBarButtonType.SaveAllUtilityButton, _
                 UtilityToolBarButtonType.SaveUtilityButton, _
                 UtilityToolBarButtonType.LoadUtilityButton, _
                 UtilityToolBarButtonType.PrintPreviewUtilityButton, _
                 UtilityToolBarButtonType.PrintUtilityButton

                Return UtilityToolBarButtonCategories.FileOperations

            Case UtilityToolBarButtonType.MapDriveUtilityButton, _
                 UtilityToolBarButtonType.DisconnectUtilityButton, _
                 UtilityToolBarButtonType.MoveToUtilityButton, _
                 UtilityToolBarButtonType.CopyToUtilityButton, _
                 UtilityToolBarButtonType.DeleteUtilityButton

                Return UtilityToolBarButtonCategories.AdvancedFileOperations

            Case UtilityToolBarButtonType.PropertiesUtilityButton, _
                 UtilityToolBarButtonType.FolderOptionsUtilityButton, _
                 UtilityToolBarButtonType.MailUtilityButton

                Return UtilityToolBarButtonCategories.MiscOperations

            Case Else
                '
                ' Couldn't find it
                '
                Return 0

        End Select

    End Function ' GetCategoryForButton






    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '              Private/Protected/Friend Methods/Functions
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' updateTextValues
    '=----------------------------------------------------------------------=
    ' The ShowText property on our parent UtilityToolBar has changed.  Go and
    ' update our text/tooltip values based on this now.
    ' 
    ' NOTE:  This implementation is for those controls who WON'T show text
    '        in the "Selected text" showing implementation.  Others should
    '        override this and indicate that they will not show any text.
    '
    ' Parameters:
    '       UtilityToolbarShowText      - [in]  new value for ShowText on 
    '                                           our parent.
    '
    Friend Overridable Sub updateTextValues(ByVal in_showText As UtilityToolBarShowText)

        Select Case in_showText

            Case UtilityToolBarShowText.ShowNoLabels
                MyBase.Text = ""
                MyBase.ToolTipText = Me.m_text

            Case UtilityToolBarShowText.ShowSelectiveLabels
                If Me.m_showForSelectedText Then
                    MyBase.Text = Me.m_text
                    MyBase.ToolTipText = ""
                Else
                    MyBase.Text = ""
                    MyBase.ToolTipText = Me.m_text
                End If

            Case UtilityToolBarShowText.ShowTextLabels
                MyBase.Text = Me.m_text
                MyBase.ToolTipText = ""

        End Select

    End Sub ' updateTextValues

    '=----------------------------------------------------------------------=
    ' getTextForButton
    '=----------------------------------------------------------------------=
    ' Returns the (localized) text for the button with the given
    ' UtilityToolBarButtonType ...
    '
    ' Parameters:
    '       UtilityToolBarButtonType    - [in]  type for which to get text
    '
    ' Returns:
    '       String                      - the text
    '
    Friend Shared Function getTextForButton(ByVal in_type As UtilityToolBarButtonType) _
                                            As String

        Select Case in_type

            Case UtilityToolBarButtonType.BackUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Back")

            Case UtilityToolBarButtonType.ForwardUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Forward")

            Case UtilityToolBarButtonType.UpUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Up")

            Case UtilityToolBarButtonType.SearchUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Search")

            Case UtilityToolBarButtonType.FoldersUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Folders")

            Case UtilityToolBarButtonType.ViewsUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Views")

            Case UtilityToolBarButtonType.StopUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Stop")

            Case UtilityToolBarButtonType.RefreshUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Refresh")

            Case UtilityToolBarButtonType.HomeUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Home")

            Case UtilityToolBarButtonType.MapDriveUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_MapDrive")

            Case UtilityToolBarButtonType.DisconnectUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Disconnect")

            Case UtilityToolBarButtonType.FavoritesUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Favorites")

            Case UtilityToolBarButtonType.HistoryUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_History")

            Case UtilityToolBarButtonType.FullScreenUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_FullScreen")

            Case UtilityToolBarButtonType.MoveToUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_MoveTo")

            Case UtilityToolBarButtonType.CopyToUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_CopyTo")

            Case UtilityToolBarButtonType.DeleteUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Delete")

            Case UtilityToolBarButtonType.UndoUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Undo")

            Case UtilityToolBarButtonType.PropertiesUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Properties")

            Case UtilityToolBarButtonType.CutUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Cut")

            Case UtilityToolBarButtonType.CopyUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Copy")

            Case UtilityToolBarButtonType.PasteUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Paste")

            Case UtilityToolBarButtonType.FolderOptionsUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_FolderOptions")

            Case UtilityToolBarButtonType.MailUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Mail")

            Case UtilityToolBarButtonType.PrintUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Print")

            Case UtilityToolBarButtonType.SaveUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Save")

            Case UtilityToolBarButtonType.LoadUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_Load")

            Case UtilityToolBarButtonType.SaveAllUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_SaveAll")

            Case UtilityToolBarButtonType.PrintPreviewUtilityButton
                Return VbPowerPackMain.GetResourceManager().GetString("UTBButton_PrintPreview")

        End Select

    End Function ' getTextForButton

    '=----------------------------------------------------------------------=
    ' CreateButtonForType
    '=----------------------------------------------------------------------=
    ' Given a type of button, go and create a new UtilityToolBarButton for
    ' it
    '
    ' Parameters:
    '       UtilityToolBarButtonType    - [in]  type to create
    '
    ' Returns:
    '       UtilityToolBarButton        - appropriate button
    '
    Friend Shared Function CreateButtonForType(ByVal in_type As UtilityToolBarButtonType) _
                                               As UtilityToolBarButton

        Select Case in_type

            Case UtilityToolBarButtonType.BackUtilityButton
                Return New BackUtilityButton

            Case UtilityToolBarButtonType.ForwardUtilityButton
                Return New ForwardUtilityButton

            Case UtilityToolBarButtonType.UpUtilityButton
                Return New UpUtilityButton

            Case UtilityToolBarButtonType.SearchUtilityButton
                Return New SearchUtilityButton

            Case UtilityToolBarButtonType.FoldersUtilityButton
                Return New FoldersUtilityButton

            Case UtilityToolBarButtonType.ViewsUtilityButton
                Return New ViewsUtilityButton

            Case UtilityToolBarButtonType.StopUtilityButton
                Return New StopUtilityButton

            Case UtilityToolBarButtonType.RefreshUtilityButton
                Return New RefreshUtilityButton

            Case UtilityToolBarButtonType.HomeUtilityButton
                Return New HomeUtilityButton

            Case UtilityToolBarButtonType.MapDriveUtilityButton
                Return New MapDriveUtilityButton

            Case UtilityToolBarButtonType.DisconnectUtilityButton
                Return New DisconnectUtilityButton

            Case UtilityToolBarButtonType.FavoritesUtilityButton
                Return New FavoritesUtilityButton

            Case UtilityToolBarButtonType.HistoryUtilityButton
                Return New HistoryUtilityButton

            Case UtilityToolBarButtonType.FullScreenUtilityButton
                Return New FullScreenUtilityButton

            Case UtilityToolBarButtonType.MoveToUtilityButton
                Return New MoveToUtilityButton

            Case UtilityToolBarButtonType.CopyToUtilityButton
                Return New CopyToUtilityButton

            Case UtilityToolBarButtonType.DeleteUtilityButton
                Return New DeleteUtilityButton

            Case UtilityToolBarButtonType.UndoUtilityButton
                Return New UndoUtilityButton

            Case UtilityToolBarButtonType.PropertiesUtilityButton
                Return New PropertiesUtilityButton

            Case UtilityToolBarButtonType.CutUtilityButton
                Return New CutUtilityButton

            Case UtilityToolBarButtonType.CopyUtilityButton
                Return New CopyUtilityButton

            Case UtilityToolBarButtonType.PasteUtilityButton
                Return New PasteUtilityButton

            Case UtilityToolBarButtonType.FolderOptionsUtilityButton
                Return New FolderOptionsUtilityButton

            Case UtilityToolBarButtonType.MailUtilityButton
                Return New MailUtilityButton

            Case UtilityToolBarButtonType.PrintUtilityButton
                Return New PrintUtilityButton

            Case UtilityToolBarButtonType.SaveUtilityButton
                Return New SaveUtilityButton

            Case UtilityToolBarButtonType.LoadUtilityButton
                Return New LoadUtilityButton

            Case UtilityToolBarButtonType.SaveAllUtilityButton
                Return New SaveAllUtilityButton

            Case UtilityToolBarButtonType.PrintPreviewUtilityButton
                Return New PrintPreviewUtilityButton

        End Select
    End Function ' CreateButtonForType


End Class ' UtilityToolBarButton


'=--------------------------------------------------------------------------=
' BackUtilityButton
'=--------------------------------------------------------------------------=
' The "Back" Button
'
'
Public Class BackUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Sets us up to be the Back Button on the toolbar.  Basically, just make
    ' sure we have the right ImageIndex set up ....
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.BackUtilityButton), True)
        Me.ImageIndex = UtilityToolBarButtonType.BackUtilityButton

    End Sub

End Class ' BackUtilityButton


'=--------------------------------------------------------------------------=
' ForwardUtilityButton
'=--------------------------------------------------------------------------=
' The "Forward" Button
'
'
Public Class ForwardUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.ForwardUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.ForwardUtilityButton

    End Sub

End Class ' ForwardUtilityButton


'=--------------------------------------------------------------------------=
' UpUtilityButton
'=--------------------------------------------------------------------------=
' The "Up" Button
'
'
Public Class UpUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.UpUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.UpUtilityButton

    End Sub

End Class ' UpUtilityButton


'=--------------------------------------------------------------------------=
' SearchUtilityButton
'=--------------------------------------------------------------------------=
' The "Search" Button
'
'
Public Class SearchUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.SearchUtilityButton), True)
        Me.ImageIndex = UtilityToolBarButtonType.SearchUtilityButton

    End Sub


End Class ' SearchUtilityButton


'=--------------------------------------------------------------------------=
' FoldersUtilityButton
'=--------------------------------------------------------------------------=
' The "Folders" Button
'
'
Public Class FoldersUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.FoldersUtilityButton), True)
        Me.ImageIndex = UtilityToolBarButtonType.FoldersUtilityButton

    End Sub


End Class ' FoldersUtilityButton


'=--------------------------------------------------------------------------=
' ViewsUtilityButton
'=--------------------------------------------------------------------------=
' The "Up" Button
'
'
Public Class ViewsUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.ViewsUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.ViewsUtilityButton

    End Sub

End Class ' ViewsUtilityButton


'=--------------------------------------------------------------------------=
' StopUtilityButton
'=--------------------------------------------------------------------------=
' The "Stop" Button
'
'
Public Class StopUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.StopUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.StopUtilityButton

    End Sub

End Class ' StopUtilityButton


'=--------------------------------------------------------------------------=
' RefreshUtilityButton
'=--------------------------------------------------------------------------=
' The "Refresh" Button
'
'
Public Class RefreshUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.RefreshUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.RefreshUtilityButton

    End Sub

End Class ' RefreshUtilityButton


'=--------------------------------------------------------------------------=
' HomeUtilityButton
'=--------------------------------------------------------------------------=
' The "Home" Button
'
'
Public Class HomeUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.HomeUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.HomeUtilityButton

    End Sub

End Class ' HomeUtilityButton


'=--------------------------------------------------------------------------=
' MapDriveUtilityButton
'=--------------------------------------------------------------------------=
' The "MapDrive" Button
'
'
Public Class MapDriveUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.MapDriveUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.MapDriveUtilityButton

    End Sub

End Class ' MapDriveUtilityButton


'=--------------------------------------------------------------------------=
' DisconnectUtilityButton
'=--------------------------------------------------------------------------=
' The "Disconnect" Button
'
'
Public Class DisconnectUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.DisconnectUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.DisconnectUtilityButton

    End Sub

End Class ' DisconnectUtilityButton


'=--------------------------------------------------------------------------=
' FavoritesUtilityButton
'=--------------------------------------------------------------------------=
' The "Favorites" Button
'
'
Public Class FavoritesUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.FavoritesUtilityButton), True)
        Me.ImageIndex = UtilityToolBarButtonType.FavoritesUtilityButton

    End Sub

End Class ' FavoritesUtilityButton


'=--------------------------------------------------------------------------=
' HistoryUtilityButton
'=--------------------------------------------------------------------------=
' The "History" Button
'
'
Public Class HistoryUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.HistoryUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.HistoryUtilityButton

    End Sub

End Class ' HistoryUtilityButton


'=--------------------------------------------------------------------------=
' FullScreenUtilityButton
'=--------------------------------------------------------------------------=
' The "FullScreen" Button
'
'
Public Class FullScreenUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.FullScreenUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.FullScreenUtilityButton

    End Sub

End Class ' FullScreenUtilityButton


'=--------------------------------------------------------------------------=
' MoveToUtilityButton
'=--------------------------------------------------------------------------=
' The "MoveTo" Button
'
'
Public Class MoveToUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.MoveToUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.MoveToUtilityButton

    End Sub

End Class ' MoveToUtilityButton


'=--------------------------------------------------------------------------=
' CopyToUtilityButton
'=--------------------------------------------------------------------------=
' The "CopyTo" Button
'
'
Public Class CopyToUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.CopyToUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.CopyToUtilityButton

    End Sub

End Class ' CopyToUtilityButton


'=--------------------------------------------------------------------------=
' DeleteUtilityButton
'=--------------------------------------------------------------------------=
' The "Delete" Button
'
'
Public Class DeleteUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.DeleteUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.DeleteUtilityButton

    End Sub

End Class ' DeleteUtilityButton


'=--------------------------------------------------------------------------=
' UndoUtilityButton
'=--------------------------------------------------------------------------=
' The "Undo" Button
'
'
Public Class UndoUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.UndoUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.UndoUtilityButton

    End Sub

End Class ' UndoUtilityButton


'=--------------------------------------------------------------------------=
' PropertiesUtilityButton
'=--------------------------------------------------------------------------=
' The "Properties" Button
'
'
Public Class PropertiesUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.PropertiesUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.PropertiesUtilityButton

    End Sub

End Class ' PropertiesUtilityButton


'=--------------------------------------------------------------------------=
' CutUtilityButton
'=--------------------------------------------------------------------------=
' The "Cut" Button
'
'
Public Class CutUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.CutUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.CutUtilityButton

    End Sub

End Class ' CutUtilityButton


'=--------------------------------------------------------------------------=
' CopyUtilityButton
'=--------------------------------------------------------------------------=
' The "Copy" Button
'
'
Public Class CopyUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.CopyUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.CopyUtilityButton

    End Sub

End Class ' CopyUtilityButton


'=--------------------------------------------------------------------------=
' PasteUtilityButton
'=--------------------------------------------------------------------------=
' The "Paste" Button
'
'
Public Class PasteUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.PasteUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.PasteUtilityButton

    End Sub

End Class ' PasteUtilityButton


'=--------------------------------------------------------------------------=
' FolderOptionsUtilityButton
'=--------------------------------------------------------------------------=
' The "FolderOptions" Button
'
'
Public Class FolderOptionsUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.FolderOptionsUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.FolderOptionsUtilityButton

    End Sub

End Class ' FolderOptionsUtilityButton


'=--------------------------------------------------------------------------=
' MailUtilityButton
'=--------------------------------------------------------------------------=
' The "Mail" Button
'
'
Public Class MailUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.MailUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.MailUtilityButton

    End Sub

End Class ' MailUtilityButton


'=--------------------------------------------------------------------------=
' PrintUtilityButton
'=--------------------------------------------------------------------------=
' The "Print" Button
'
'
Public Class PrintUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.PrintUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.PrintUtilityButton

    End Sub

End Class ' PrintUtilityButton


'=--------------------------------------------------------------------------=
' SaveUtilityButton
'=--------------------------------------------------------------------------=
' The "Save" Button
'
'
Public Class SaveUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.SaveUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.SaveUtilityButton

    End Sub

End Class ' SaveUtilityButton

'=--------------------------------------------------------------------------=
' LoadUtilityButton
'=--------------------------------------------------------------------------=
' The "Load" Button
'
'
Public Class LoadUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.LoadUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.LoadUtilityButton

    End Sub

End Class ' LoadUtilityButton


'=--------------------------------------------------------------------------=
' SaveAllUtilityButton
'=--------------------------------------------------------------------------=
' The "SaveAll" Button
'
'
Public Class SaveAllUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.SaveAllUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.SaveAllUtilityButton

    End Sub

End Class ' SaveAllUtilityButton


'=--------------------------------------------------------------------------=
' PrintPreviewUtilityButton
'=--------------------------------------------------------------------------=
' The "PrintPreview" Button
'
'
Public Class PrintPreviewUtilityButton
    Inherits UtilityToolBarButton

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class ...
    '
    Public Sub New()

        MyBase.new(UtilityToolBarButton.getTextForButton(UtilityToolBarButtonType.PrintPreviewUtilityButton))
        Me.ImageIndex = UtilityToolBarButtonType.PrintPreviewUtilityButton

    End Sub

End Class ' PrintPreviewUtilityButton

