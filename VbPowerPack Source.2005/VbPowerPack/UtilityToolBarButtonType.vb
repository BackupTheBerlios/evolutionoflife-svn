'-------------------------------------------------------------------------------
'<copyright file="UtilityToolBarButtonType.vb" company="Microsoft">
'   Copyright (c) Microsoft Corporation. All rights reserved.
'</copyright>
'
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'-------------------------------------------------------------------------------

Imports System.ComponentModel


'=--------------------------------------------------------------------------=
' UtilityToolBarButtonType
'=--------------------------------------------------------------------------=
' These are the allowed toolbar buttons
'
'
<LocalisableDescription("UtilityToolBarButtonType")> _
Friend Enum UtilityToolBarButtonType

    '
    ' Basic Browsing
    '
    BackUtilityButton = 0
    ForwardUtilityButton
    UpUtilityButton
    StopUtilityButton
    RefreshUtilityButton
    HomeUtilityButton

    '
    ' Advanced Browsing
    '
    SearchUtilityButton
    FoldersUtilityButton
    ViewsUtilityButton
    FavoritesUtilityButton
    HistoryUtilityButton
    FullScreenUtilityButton

    '
    ' Clipboard
    '
    CutUtilityButton
    CopyUtilityButton
    PasteUtilityButton
    UndoUtilityButton

    '
    ' File Operations
    '
    SaveUtilityButton
    LoadUtilityButton
    SaveAllUtilityButton
    PrintUtilityButton
    PrintPreviewUtilityButton

    '
    ' Advanced File Operations
    '
    MapDriveUtilityButton
    DisconnectUtilityButton
    MoveToUtilityButton
    CopyToUtilityButton
    DeleteUtilityButton

    '
    ' Misc operations
    '
    PropertiesUtilityButton
    FolderOptionsUtilityButton
    MailUtilityButton

End Enum ' UtilityToolBarButtonType




'=--------------------------------------------------------------------------=
' UtilityToolBarButtonCategories
'=--------------------------------------------------------------------------=
' These are the broad categories of toolbarbuttons in a bitmask format.
'
'
<LocalisableDescription("UtilityToolBarButtonCategories")> _
Public Enum UtilityToolBarButtonCategories

    BasicBrowsing = &H1
    AdvancedBrowsing = &H2
    Clipboard = &H4
    FileOperations = &H8
    AdvancedFileOperations = &H10
    MiscOperations = &H20

End Enum ' UtilityToolBarButtonCategories



