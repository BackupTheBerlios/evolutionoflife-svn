'-------------------------------------------------------------------------------
'<copyright file="FileViewer.vb" company="Microsoft">
'   Copyright (c) Microsoft Corporation. All rights reserved.
'</copyright>
'
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'-------------------------------------------------------------------------------

Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing
Imports System.ComponentModel
Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Threading



'=--------------------------------------------------------------------------=
' FileViewer
'=--------------------------------------------------------------------------=
' This is a version of the WinForms ListView control that we will use to 
' browse files and folders on the local filesystem.  We will also be able to
' browse a couple of special places such as My Computer and the Desktop.
'
'
<DefaultProperty("Path"), _
 DefaultEvent("ItemClicked")> _
Public Class FileViewer
    Inherits ListView


    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                       Private Classes/Members/Data
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '
    ' This is for cross thread icon population
    '
    Private Delegate Sub CrossThreadIconPopulator(ByVal in_iaia() As ItemAndIcons, _
                                                  ByVal count As Integer)

    Protected Structure ItemAndIcons

        Public Item As FileViewerListViewItem
        Public LargeIcon As Icon
        Public SmallIcon As Icon
        Public PreCachedIndex As Integer

    End Structure ' ItemAndIcons


    '
    ' These will form the basic images of the Image List.
    '
    Protected Enum BaseImageIndexes

        Directory = 0
        Dll
        Unknown
        Exe

    End Enum ' BaseImageIndexes

    '
    ' These are the possible views of the column headers ...
    '
    Protected Enum ColumnHeaderViews

        None = -1
        Files = 0
        MyComputer = 1

    End Enum ' ColumnHeaderViews

    '
    ' What's the directory we're currently browsing?
    '
    Private m_path As String

    '
    ' These are the localized versions of the special strings we will
    ' understand.
    '
    Private m_desktop As String
    Private m_myComputer As String
    Private m_myDocuments As String

    '
    ' Background thread that will go and grab the icons for all the different
    ' files in the ListView right now ...
    '
    Private m_iconThread As Thread
    Private m_abortThread As Boolean

    '
    ' This is the pattern passed on to DirectoryInfo.GetFiles 
    '
    Private m_pattern As String

    '
    ' Controls what we show ....
    '
    Private m_showFiles As Boolean
    Private m_showFolders As Boolean
    Private m_showHidden As Boolean

    '
    ' Current Column Header View and cache of column headers ...
    '
    Private m_columnView As ColumnHeaderViews
    Private m_columnCache() As Object

    '
    ' SortBy ...
    '
    Private m_sortBy As FileViewerSortBy

    '
    ' Type Description Cache
    '
    Private Const FOLDER_KEY As String = "<<FOLDER>>"
    Private m_typeCache As Hashtable

    '
    ' Icon cache.
    '
    Private m_iconCache As Hashtable





    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                 Public Methods/Properties/Functions
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializs a new instance of our FileViewer class.
    '
    '
    Public Sub New()
        MyBase.New()

        '
        ' Set Default path to "My Computer"
        '
        Me.m_path = "My Computer"

        '
        ' Set up some reasonable defaults.
        '
        Me.m_showFiles = True
        Me.m_showFolders = True
        Me.m_showHidden = False

        '
        ' We don't have a view yet, and create an array to hold the old
        ' column headers for when we switch views ...
        '
        Me.m_columnView = ColumnHeaderViews.None
        Me.m_columnCache = New Object(4) {}

        '
        ' Default pattern is ALL files ...
        '
        Me.m_pattern = "*"

        '
        ' Set up the default sorting ...
        '
        Me.m_sortBy = FileViewerSortBy.Name
        Me.Sorting = SortOrder.Ascending
        Me.ListViewItemSorter = New ItemSorter(Me)

        '
        ' misc other goo
        '
        Me.m_iconThread = Nothing
        Me.m_abortThread = False

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' Refresh
    '=----------------------------------------------------------------------=
    ' Causes us to completely refill our list of items based on the current
    ' path.  Any existing selection and/or positioning is lost.
    '
    <LocalisableDescription("FileViewer.Refresh")> _
    Public Overrides Sub Refresh()

        populateControl()
        MyBase.Refresh()

    End Sub ' Refresh


    '=----------------------------------------------------------------------=
    ' Path
    '=----------------------------------------------------------------------=
    ' Represents the path to be searched.  Please note that, in addition to
    ' regular paths, other, special paths can be browsed as well ...
    '
    ' Type:
    '       String
    '
    <LocalisableDescription("FileViewer.Path"), _
     Category("Behavior"), _
     Localizable(True)> _
    Public Property Path() As String

        Get
            Return Me.m_path
        End Get

        '
        ' Set it, and update the control as necessary.
        '
        Set(ByVal in_newPath As String)

            '
            ' arg checking.   avoid looking at the localized Desktop and
            ' My Computer if possible !
            '
            If in_newPath = Nothing OrElse in_newPath = "" Then
                Me.Items.Clear()
                Return
            ElseIf Not (in_newPath.Length >= 2 AndAlso in_newPath.Chars(1) = ":" AndAlso Char.IsLetter(in_newPath.Chars(0))) _
                   AndAlso (Not pathIsSpecialPath(in_newPath)) _
                   AndAlso (Not pathIsValidDiskPath(in_newPath)) Then
                Throw New ArgumentException(VbPowerPackMain.GetResourceManager().GetString("excFileViewerPathInvalid"))
                'Return
            End If

            If in_newPath.Length = 2 AndAlso in_newPath.EndsWith(":") _
               AndAlso Char.IsLetter(in_newPath.Chars(0)) Then
                in_newPath = in_newPath & "\"
            End If

            '
            ' Don't do anything if the new path is the same as the old
            ' one.
            '
            If Me.m_path = in_newPath Then Return

            '
            ' Otherwise, set the new path, and then repopulate the list.
            '
            Me.m_path = in_newPath
            populateControl()

        End Set

    End Property ' Path


    '=----------------------------------------------------------------------=
    ' Pattern
    '=----------------------------------------------------------------------=
    ' This is how (if at all) we mask out files that we show to the user.
    '
    ' Type:
    '       String
    '
    <LocalisableDescription("FileViewer.Pattern"), _
     Category("Behavior"), DefaultValue("*"), _
     Localizable(True)> _
    Public Property Pattern() As String

        Get
            Return Me.m_pattern
        End Get

        '
        ' Set the new pattern, and refresh if necessary ...
        '
        Set(ByVal in_newPattern As String)

            If in_newPattern Is Nothing OrElse in_newPattern = "" Then
                in_newPattern = "*"
            End If

            '
            ' If the pattern is new, and we've got an HWND, then go
            ' and repopulate the control with the new pattern.
            '
            If Not Me.m_pattern = in_newPattern Then
                Me.m_pattern = in_newPattern
                populateControl()
            End If
        End Set

    End Property ' Pattern


    '=----------------------------------------------------------------------=
    ' ShowFiles
    '=----------------------------------------------------------------------=
    ' Should we show files in the FileViewer??
    '
    ' Type:
    '       Boolean
    '
    <LocalisableDescription("FileViewer.ShowFiles"), _
     Category("Behavior"), DefaultValue(True), _
     Localizable(True)> _
    Public Property ShowFiles() As Boolean

        Get
            Return Me.m_showFiles
        End Get

        '
        ' Set the new value, and update what we're showing if
        ' appropriate.
        '
        Set(ByVal in_newShowFiles As Boolean)

            '
            ' Only do all the work if the value is different
            '
            If Not Me.m_showFiles = in_newShowFiles Then
                Me.m_showFiles = in_newShowFiles
                populateControl()
            End If
        End Set

    End Property ' ShowFiles


    '=----------------------------------------------------------------------=
    ' ShowFolders
    '=----------------------------------------------------------------------=
    ' Should we show folders in the FileViewer??
    '
    ' Type:
    '       Boolean
    '
    <LocalisableDescription("FileViewer.ShowFolders"), _
     Category("Behavior"), DefaultValue(True), _
     Localizable(True)> _
    Public Property ShowFolders() As Boolean

        Get
            Return Me.m_showFolders
        End Get

        '
        ' Set the new value, and update what we're showing, if necesary.
        '
        Set(ByVal in_newShowFolders As Boolean)

            If Not Me.m_showFolders = in_newShowFolders Then
                Me.m_showFolders = in_newShowFolders
                populateControl()
            End If

        End Set

    End Property ' ShowFolders


    '=----------------------------------------------------------------------=
    ' ShowHidden
    '=----------------------------------------------------------------------=
    ' Should we show hidden files in the control?
    '
    ' Type:
    '       Boolean
    '
    <LocalisableDescription("FileViewer.ShowHidden"), _
     Category("Behavior"), DefaultValue(False), _
     Localizable(True)> _
    Public Property ShowHidden() As Boolean

        Get
            Return Me.m_showHidden
        End Get

        '
        ' Set the new value and update our list as appropriate.
        '
        Set(ByVal in_newShowHidden As Boolean)

            If Not Me.m_showHidden = in_newShowHidden Then
                Me.m_showHidden = in_newShowHidden
                populateControl()
            End If

        End Set

    End Property ' ShowHidden


    '=----------------------------------------------------------------------=
    ' View
    '=----------------------------------------------------------------------=
    ' Controls how the items in the ListView are shown.
    '
    ' Type:
    '       System.Windows.Forms.View
    '
    <LocalisableDescription("FileViewer.View"), _
     Category("Appearance"), DefaultValue(System.Windows.Forms.View.LargeIcon), _
     Localizable(True)> _
    Public Shadows Property View() As System.Windows.Forms.View

        Get
            Return MyBase.View
        End Get

        Set(ByVal in_newView As System.Windows.Forms.View)

            If Not in_newView = MyBase.View Then
                MyBase.View = in_newView
                OnViewChanged()
            End If
        End Set

    End Property ' View


    '=----------------------------------------------------------------------=
    ' Files
    '=----------------------------------------------------------------------=
    ' Returns a list of all the files in the current path.
    '
    ' Type:
    '       System.IO.FileInfo()
    '
    '
    <LocalisableDescription("FileViewer.Files"), _
     Category("Behavior"), _
     Browsable(False)> _
    Public ReadOnly Property Files() As FileInfo()

        Get
            Return getFileInfos(False)
        End Get

    End Property ' Files


    '=----------------------------------------------------------------------=
    ' Folders
    '=----------------------------------------------------------------------=
    ' Returns a list of all the folders in the current path.
    '
    ' Type:
    '       System.IO.DirectoryInfo()
    '
    '
    <LocalisableDescription("FileViewer.Folders"), _
     Category("Behavior"), _
     Browsable(False)> _
    Public ReadOnly Property Folders() As DirectoryInfo()

        Get
            Return getFolderInfos(False)
        End Get

    End Property ' Folders


    '=----------------------------------------------------------------------=
    ' SelectedFiles
    '=----------------------------------------------------------------------=
    ' Returns a list of all the files currently selected in the FileViewer
    ' control.
    '
    ' Type:
    '       System.IO.FileInfo()
    '
    '
    <LocalisableDescription("FileViewer.SelectedFiles"), _
     Category("Behavior"), _
     Browsable(False)> _
    Public ReadOnly Property SelectedFiles() As FileInfo()

        Get
            Return getFileInfos(True)
        End Get

    End Property ' SelectedFiles


    '=----------------------------------------------------------------------=
    ' SelectedFolders
    '=----------------------------------------------------------------------=
    ' Returns a list of all the folders currently selected in the FileViewer
    ' control.
    '
    ' Type:
    '       System.IO.DirectoryInfo()
    '
    '
    <LocalisableDescription("FileViewer.SelectedFolders"), _
     Category("Behavior"), _
     Browsable(False)> _
    Public ReadOnly Property SelectedFolders() As DirectoryInfo()

        Get
            Return getFolderInfos(True)
        End Get

    End Property ' SelectedFolders


    '=----------------------------------------------------------------------=
    ' SortBy
    '=----------------------------------------------------------------------=
    ' Controls how the items in the FileViewer are sorted.
    '
    ' Type:
    '       FileViewerSortBy
    '
    <LocalisableDescription("FileViewer.SortBy"), _
     Category("Behavior"), DefaultValue(FileViewerSortBy.Name), _
     Localizable(True)> _
    Public Overridable Property SortBy() As FileViewerSortBy

        Get
            Return Me.m_sortBy
        End Get

        '
        ' Set the new value and resort if necessary.
        '
        Set(ByVal in_newSortBy As FileViewerSortBy)

            If in_newSortBy < FileViewerSortBy.None _
               OrElse in_newSortBy > FileViewerSortBy.ModifiedTime Then
                Throw New ArgumentException(VbPowerPackMain.GetResourceManager().GetString("excFileViewerSortByInvalid"))
            End If

            '
            ' Don't bother if the value is the same ...
            '
            If Not Me.m_sortBy = in_newSortBy Then

                Me.m_sortBy = in_newSortBy
                If Me.IsHandleCreated Then
                    Me.Sort()
                End If

                '
                ' Finally, raise an event to this effect.
                '
                OnSortByChanged()

            End If

        End Set

    End Property ' SortBy


    '=----------------------------------------------------------------------=
    ' Columns
    '=----------------------------------------------------------------------=
    ' We don't want to expose the property.
    '
    ' Type:
    '       ColumnHeaderCollection
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows ReadOnly Property Columns() As ListView.ColumnHeaderCollection

        Get
            Return MyBase.Columns
        End Get

    End Property ' Columns


    '=----------------------------------------------------------------------=
    ' CheckBoxes
    '=----------------------------------------------------------------------=
    ' We don't want to expose the property.
    '
    ' Type:
    '       Boolean
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property CheckBoxes() As Boolean

        Get
            Return MyBase.CheckBoxes
        End Get

        Set(ByVal in_newcheckboxes As Boolean)
            MyBase.CheckBoxes = in_newcheckboxes
        End Set

    End Property ' CheckBoxes


    '=----------------------------------------------------------------------=
    ' Items
    '=----------------------------------------------------------------------=
    ' We don't want to expose the property.
    '
    ' Type:
    '   ListViewItemCollection
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows ReadOnly Property Items() As ListView.ListViewItemCollection

        Get
            Return MyBase.Items
        End Get

    End Property ' Items


    '=----------------------------------------------------------------------=
    ' SelectedItems
    '=----------------------------------------------------------------------=
    ' We want people to use the SelectedFiles and SelectedFolders properties
    ' instead.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows ReadOnly Property SelectedItems() As SelectedListViewItemCollection

        Get
            Return MyBase.SelectedItems
        End Get

    End Property ' SelectedItems


    '=----------------------------------------------------------------------=
    ' SelectedIndices
    '=----------------------------------------------------------------------=
    ' We want people to use the SelectedFiles and SelectedFolders properties
    ' instead.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows ReadOnly Property SelectedIndices() As SelectedIndexCollection

        Get
            Return MyBase.SelectedIndices
        End Get

    End Property ' SelectedIndices


    '=----------------------------------------------------------------------=
    ' LargeImageList
    '=----------------------------------------------------------------------=
    ' We don't want to expose the property.
    '
    ' Type:
    '       ImageList
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property LargeImageList() As ImageList

        Get
            Return MyBase.LargeImageList
        End Get

        Set(ByVal in_newLargeImageList As ImageList)
            MyBase.LargeImageList = in_newLargeImageList
        End Set

    End Property ' LargeImageList


    '=----------------------------------------------------------------------=
    ' SmallImageList
    '=----------------------------------------------------------------------=
    ' We don't want to expose the property.
    '
    ' Type:
    '       ImageList
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property SmallImageList() As ImageList

        Get
            Return MyBase.SmallImageList
        End Get

        Set(ByVal in_newSmallImageList As ImageList)
            MyBase.SmallImageList = in_newSmallImageList
        End Set

    End Property ' SmallImageList


    '=----------------------------------------------------------------------=
    ' StateImageList
    '=----------------------------------------------------------------------=
    ' We don't want to expose the property.
    '
    ' Type:
    '       ImageList
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property StateImageList() As ImageList

        Get
            Return MyBase.StateImageList
        End Get

        Set(ByVal in_newStateImageList As ImageList)
            MyBase.StateImageList = in_newStateImageList
        End Set

    End Property ' StateImageList


    '=----------------------------------------------------------------------=
    ' ListViewItemSorter
    '=----------------------------------------------------------------------=
    ' We don't want to expose the property.
    '
    ' Type:
    '       IComparer
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property ListViewItemSorter() As IComparer

        Get
            Return MyBase.ListViewItemSorter
        End Get

        Set(ByVal in_newListViewItemSorter As IComparer)
            MyBase.ListViewItemSorter = in_newListViewItemSorter
        End Set

    End Property ' ListViewItemSorter


    '=----------------------------------------------------------------------=
    ' Clear
    '=----------------------------------------------------------------------=
    ' We don't want to expose the method.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Sub Clear()

        MyBase.Clear()

    End Sub ' Clear


    '=----------------------------------------------------------------------=
    ' CheckedIndices
    '=----------------------------------------------------------------------=
    ' We don't want to expose the property.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows ReadOnly Property CheckedIndices() As CheckedIndexCollection

        Get
            Return MyBase.CheckedIndices
        End Get

    End Property ' CheckedIndices


    '=----------------------------------------------------------------------=
    ' CheckedItems
    '=----------------------------------------------------------------------=
    ' We don't want to expose the property.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows ReadOnly Property CheckedItems() As CheckedListViewItemCollection

        Get
            Return MyBase.CheckedItems
        End Get

    End Property ' CheckedItems










    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                Private/Proteted/Friend Methods/Subs/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' LocalizedDesktop
    '=----------------------------------------------------------------------=
    ' Returns the localized name of "Desktop"
    ' 
    ' Type:
    '       String
    '
    Private ReadOnly Property LocalizedDesktop() As String
        Get
            If Me.m_desktop Is Nothing Then
                initializeLocalizedStrings()
            End If

            Return Me.m_desktop
        End Get
    End Property ' LocalizedDesktop


    '=----------------------------------------------------------------------=
    ' LocalizedMyComputer
    '=----------------------------------------------------------------------=
    ' Returns the localized name of "My Computer"
    ' 
    ' Type:
    '       String
    '
    Private ReadOnly Property LocalizedMyComputer() As String
        Get
            If Me.m_myComputer Is Nothing Then
                initializeLocalizedStrings()
            End If

            Return Me.m_myComputer
        End Get

    End Property ' LocalizedMyComputer




    '=----------------------------------------------------------------------=
    ' CreateHandle
    '=----------------------------------------------------------------------=
    ' Make sure we populate our control for those cases where the path was
    ' set before handle creation.
    '
    Protected Overrides Sub CreateHandle()

        MyBase.CreateHandle()
        populateControl()

    End Sub ' CreateHandle


    '=----------------------------------------------------------------------=
    ' WndProc
    '=----------------------------------------------------------------------=
    ' Window proc.  Unfortunately, DestroyHandle doesn't seem to get called
    ' all the time, so we have to intercept WM_DESTROY, and make sure that
    ' our background icon thread, if it exists, isn't running still.  If so,
    ' kill it!
    '
    Protected Overrides Sub WndProc(ByRef in_message As Message)

        '
        ' if the message is WM_DESTROY, then make sure our background
        ' thread is gone !!!
        '
        If in_message.Msg = &H2 Then
            If Not Me.m_iconThread Is Nothing Then

                '
                ' Tell it to abort, and then wait up to 2 seconds.  Otherwise
                ' kill it.
                '
                Me.m_abortThread = True
                Me.m_iconThread.Join(2000)
                If Not Me.m_iconThread Is Nothing Then
                    Me.m_iconThread.Abort()
                End If
            End If
        End If

        '
        ' Never forget to call our base in this function !!!
        '
        MyBase.WndProc(in_message)

    End Sub ' WndProc


    '=----------------------------------------------------------------------=
    ' OnViewChanged
    '=----------------------------------------------------------------------=
    ' Fires the ViewChanged event.
    '
    Protected Overridable Sub OnViewChanged()

        RaiseEvent ViewChanged(Me, EventArgs.Empty)

    End Sub ' OnViewChanged


    '=----------------------------------------------------------------------=
    ' OnSortByChanged
    '=----------------------------------------------------------------------=
    ' Fires the SortByChanged event.
    '
    Protected Overridable Sub OnSortByChanged()

        RaiseEvent SortByChanged(Me, EventArgs.Empty)

    End Sub ' OnSortByChanged


    '=----------------------------------------------------------------------=
    ' OnItemCheck
    '=----------------------------------------------------------------------=
    ' We're going to hide this from the user, since we're hiding Item
    ' Checking by default.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Protected Overrides Sub OnitemCheck(ByVal in_ica As ItemCheckEventArgs)

        MyBase.OnItemCheck(in_ica)

    End Sub ' OnItemCheck


    '=----------------------------------------------------------------------=
    ' initializeLocalizedStrings
    '=----------------------------------------------------------------------=
    ' Initializes the localized versions of the special strings that
    ' this control will understand to browse special and interesting places
    ' above and beyond simple files ...
    '
    Private Sub initializeLocalizedStrings()

        '
        ' Now, for each of the special folders, go and get the the PIDL
        ' for it, and then get the display name.
        '
        Me.m_desktop = WindowsHelpers.GetSpecialFolderName(ShellApis.CSIDL_DESKTOP)
        Me.m_myComputer = WindowsHelpers.GetSpecialFolderName(ShellApis.CSIDL_DRIVES)

    End Sub ' initializeLocalizedStrings


    '=----------------------------------------------------------------------=
    ' populateControl
    '=----------------------------------------------------------------------=
    ' Populates the control for our current path.
    '
    Private Sub populateControl()

        Dim typeDesc As String

        '
        ' 0. If we're not in run mode or there's no handle, then we don't
        ' do this
        '
        If Me.DesignMode Then Return
        If Not Me.IsHandleCreated Then Return

        '
        ' 1. clear out everything we've got right now ...
        '
        Me.Items.Clear()
        resetImageLists()

        '
        ' 2. Next, we will initialize the type cache to contain a description
        '    for folders.
        '
        Me.m_typeCache = New Hashtable(100)
        typeDesc = ShellFolder.GetTypeDescriptionForFile(System.Environment.ExpandEnvironmentVariables("%WINDIR%"))
        If Not typeDesc Is Nothing Then Me.m_typeCache.Add(FOLDER_KEY, typeDesc)

        '
        ' 3. Set up the columns for the current path ..
        '
        setColumnsForCurrentPath()

        '
        ' 4. If the path is My Computer, then we have to use IShellFolder.
        '    Otherwise, we'll just use regular Filesystem goo.
        '
        If Me.m_path.Length >= 2 AndAlso Me.m_path.Chars(1) = ":" AndAlso Char.IsLetter(Me.m_path.Chars(0)) Then
            populateControlForPath()
        ElseIf Me.m_path = Me.LocalizedMyComputer OrElse Me.m_path = "My Computer" Then
            populateControlForMyComputer()
        ElseIf Me.m_path = Me.LocalizedDesktop OrElse Me.m_path = "Desktop" Then
            populateControlForDesktop()
        End If

    End Sub ' populateControl


    '=----------------------------------------------------------------------=
    ' populateControlForPath
    '=----------------------------------------------------------------------=
    ' Our path is just a regular path.  Go and populate it using regular
    ' filesystem methods.
    '
    Private Sub populateControlForPath()

        Dim dirInfo As DirectoryInfo
        Dim dirs() As DirectoryInfo
        Dim files() As FileInfo

        dirInfo = New DirectoryInfo(Me.m_path)

        '
        ' First, go and add all the directories.
        '
        If Me.m_showFolders Then
            dirs = dirInfo.GetDirectories(Me.m_pattern)
            If Not dirs Is Nothing AndAlso dirs.Length > 0 Then
                For x As Integer = 0 To dirs.Length - 1
                    addListViewItemForDirectory(dirs(x))
                Next
            End If
        End If

        '
        ' Next, the files.
        '
        If Me.m_showFiles Then
            files = dirInfo.GetFiles(Me.m_pattern)
            If Not files Is Nothing AndAlso files.Length > 0 Then

                For x As Integer = 0 To files.Length - 1
                    addListViewItemForFile(files(x))
                Next
            End If
        End If

        '
        ' Finally, start the background thread to go through our list
        ' of items and see if we can't come up with better icons for
        ' them.
        '
        Me.m_iconThread = New Thread(AddressOf Me.populateIconsThread)
        Me.m_iconThread.Start()

        '
        ' Clear out the type cache to save some space.
        '
        Me.m_typeCache = Nothing

    End Sub ' populateControlForPath


    '=----------------------------------------------------------------------=
    ' populateControlForMyComputer
    '=----------------------------------------------------------------------=
    ' populates the list view given that the current path is My Computer.  
    ' We have to use Shell folder goo to handle all this.
    '
    Private Sub populateControlForMyComputer()

        Dim fiis() As ShellFolder.FolderItemInfo
        Dim sf As ShellFolder

        '
        ' We need to use the Shell Folder APIs and itfs for this stuff.
        '
        sf = ShellFolder.MyComputerFolder()

        '
        ' Enumerate the contents.
        '
        fiis = sf.EnumerateContents(True, True, Me.m_showHidden)
        If Not fiis Is Nothing AndAlso fiis.Length > 0 Then

            For x As Integer = 0 To fiis.Length - 1

                '
                ' if it's not a virtual folder, then add it.
                '
                If Not fiis(x).FullPath.StartsWith("::") Then
                    addListViewItemForMyComputerItem(fiis(x))
                End If

            Next

        End If

    End Sub ' populateControlForMyComputer


    '=----------------------------------------------------------------------=
    ' populateControlForDesktop
    '=----------------------------------------------------------------------=
    ' Populates the list view given that the current path is the Desktop.
    ' We have to use the Shell Folder goo to do this.
    '
    Private Sub populateControlForDesktop()

        Dim fiis() As ShellFolder.FolderItemInfo
        Dim sf As ShellFolder

        '
        ' We need to use the Shell Folder APIs and itfs for this stuff.
        '
        sf = ShellFolder.DesktopFolder()

        '
        ' Enumerate the contents.
        '
        fiis = sf.EnumerateContents(True, True, Me.m_showHidden)
        If Not fiis Is Nothing AndAlso fiis.Length > 0 Then

            For x As Integer = 0 To fiis.Length - 1

                '
                ' if it's not a virtual folder (or if it's my computer),
                ' then add it.
                '
                If Not fiis(x).FullPath.StartsWith("::") _
                   OrElse fiis(x).Name = Me.LocalizedMyComputer Then
                    addListViewItemForDesktopItem(fiis(x))
                End If

            Next

        End If

    End Sub  ' populateControlForDesktop


    '=----------------------------------------------------------------------=
    ' addListViewItemForDirectory
    '=----------------------------------------------------------------------=
    ' Given an item that is a directory, go and add a ListViewItem for it.
    '
    ' Parameters:
    '       DirectoryInfo           - [in]  details, details, details
    '
    Private Sub addListViewItemForDirectory(ByVal in_dirInfo As DirectoryInfo)

        Dim lvsi As ListViewItem.ListViewSubItem
        Dim systemAttr, hiddenAttr As Boolean
        Dim lvi As FileViewerListViewItem

        System.Diagnostics.Debug.Assert(Me.m_columnView = ColumnHeaderViews.Files, "Can't Add Directories if View isn't 'Files'")

        '
        ' 0. make sure the attributes are okay to us. If not, exit
        '
        hiddenAttr = in_dirInfo.Attributes And FileAttributes.Hidden
        systemAttr = in_dirInfo.Attributes And FileAttributes.System
        If (hiddenAttr And Not Me.m_showHidden) OrElse systemAttr Then Return

        '
        ' 1. Generate a ListViewItem for it ...
        '
        lvi = New FileViewerListViewItem(in_dirInfo.FullName, True, 0)
        lvi.Text = in_dirInfo.Name
        lvi.ImageIndex = BaseImageIndexes.Directory

        '
        ' Size
        '
        lvsi = New ListViewItem.ListViewSubItem
        lvsi.Text = ""
        lvi.SubItems.Add(lvsi)

        '
        ' Type
        '
        lvsi = New ListViewItem.ListViewSubItem
        lvsi.Text = getTypeDescription("")
        lvi.SubItems.Add(lvsi)

        lvsi = New ListViewItem.ListViewSubItem
        lvsi.Text = in_dirInfo.LastAccessTime.ToString()
        lvi.SubItems.Add(lvsi)

        '
        ' 2. Add the item to our list. 
        '
        Me.Items.Add(lvi)

    End Sub ' addListViewItemForDirectory


    '=----------------------------------------------------------------------=
    ' addListViewItemForFile
    '=----------------------------------------------------------------------=
    ' We're in File View, and we've been asked to add a file to our list of
    ' items.  get the appropriate information, and then go add it.  
    '
    ' Parameters:
    '       FileInfo            - [in]  details, details, details.
    '
    Private Sub addListViewItemForFile(ByVal in_fileInfo As FileInfo)

        Dim lvsi As ListViewItem.ListViewSubItem
        Dim systemAttr, hiddenAttr As Boolean
        Dim lvi As FileViewerListViewItem

        System.Diagnostics.Debug.Assert(Me.m_columnView = ColumnHeaderViews.Files, "Can't Add Files if View isn't 'Files'")

        '
        ' 0. make sure the attributes are okay to us. If not, exit
        '
        hiddenAttr = in_fileInfo.Attributes And FileAttributes.Hidden
        systemAttr = in_fileInfo.Attributes And FileAttributes.System
        If (hiddenAttr And Not Me.m_showHidden) OrElse systemAttr Then Return

        '
        ' 1. Generate a ListViewItem for it ...
        '
        lvi = New FileViewerListViewItem(in_fileInfo.FullName, False, in_fileInfo.Length)
        lvi.Text = in_fileInfo.Name
        lvi.ImageIndex = getBestGuessImageIndex(in_fileInfo.Extension)

        '
        ' Size
        '
        lvsi = New ListViewItem.ListViewSubItem
        lvsi.Text = nicePrintSizeSimple(lvi.FileSize)
        lvi.SubItems.Add(lvsi)

        '
        ' Type
        '
        lvsi = New ListViewItem.ListViewSubItem
        lvsi.Text = getTypeDescription(in_fileInfo.FullName)
        lvi.SubItems.Add(lvsi)

        lvsi = New ListViewItem.ListViewSubItem
        lvsi.Text = in_fileInfo.LastAccessTime.ToString()
        lvi.SubItems.Add(lvsi)

        '
        ' 2. Add the item to our list.  
        '
        Me.Items.Add(lvi)

    End Sub ' addListViewItemForFile


    '=----------------------------------------------------------------------=
    ' addListViewItemForMyComputerItem
    '=----------------------------------------------------------------------=
    ' Given an item that we know is for "My Computer", go and create a list
    ' view item for it, and add it .
    '
    ' Parameters:
    '       ShellFolder.FolderItemInfo
    '
    Private Sub addListViewItemForMyComputerItem(ByVal in_fii As ShellFolder.FolderItemInfo)

        Dim totalSize, freeSize, userSize As Long
        Dim lvsi As ListViewItem.ListViewSubItem
        Dim lvi As FileViewerListViewItem
        Dim index As Integer

        System.Diagnostics.Debug.Assert(Me.m_columnView = ColumnHeaderViews.MyComputer, "Can't Add Items if View isn't 'My Computer!!!'")

        '
        ' 1. Insert the Icons into the ImageLists.
        '
        index = Me.LargeImageList.Images.Count
        Me.LargeImageList.Images.Add(in_fii.LargeIcon.ToBitmap())
        If Not in_fii.SmallIcon Is Nothing Then
            Me.SmallImageList.Images.Add(in_fii.SmallIcon.ToBitmap())
        Else
            Me.SmallImageList.Images.Add(in_fii.LargeIcon.ToBitmap())
        End If

        '
        ' 2. Create the base item for it.
        '
        lvi = New FileViewerListViewItem(in_fii.FullPath, True, 0)
        lvi.Text = in_fii.Name
        lvi.ImageIndex = index

        '
        ' 3. Create the subitems.
        '
        lvsi = New ListViewItem.ListViewSubItem
        lvsi.Text = ShellFolder.GetTypeDescriptionForFile(in_fii.FullPath)
        lvi.SubItems.Add(lvsi)

        '
        ' if it's a drive, then get size information
        '
        If in_fii.FullPath.Length = 3 AndAlso in_fii.FullPath.EndsWith(":\") Then

            Win32Helper.GetDiskFreeSpaceEx(in_fii.FullPath, userSize, totalSize, freeSize)

            lvsi = New ListViewItem.ListViewSubItem
            If Not totalSize = 0 Then
                lvi.setSize(totalSize)
                lvsi.Text = nicePrintSizeComplex(totalSize)
            End If
            lvi.SubItems.Add(lvsi)

            lvsi = New ListViewItem.ListViewSubItem
            If Not freeSize = 0 Then
                lvsi.Text = nicePrintSizeComplex(freeSize)
            End If
            lvi.SubItems.Add(lvsi)
        Else
            lvsi = New ListViewItem.ListViewSubItem
            lvi.SubItems.Add(lvsi)
            lvsi = New ListViewItem.ListViewSubItem
            lvi.SubItems.Add(lvsi)
        End If

        Me.Items.Add(lvi)

    End Sub ' addListViewItemForMyComputerItem


    '=----------------------------------------------------------------------=
    ' addListViewItemForDesktopItem
    '=----------------------------------------------------------------------=
    ' Given an item that we know is for "Desktop", go and create a list
    ' view item for it, and add it .
    '
    ' Parameters:
    '       ShellFolder.FolderItemInfo
    '
    Private Sub addListViewItemForDesktopItem(ByVal in_fii As ShellFolder.FolderItemInfo)

        Dim lvsi As ListViewItem.ListViewSubItem
        Dim lvi As FileViewerListViewItem
        Dim dirExists As Boolean
        Dim index As Integer
        Dim size As Long

        System.Diagnostics.Debug.Assert(Me.m_columnView = ColumnHeaderViews.Files, "Can't Add Items if View isn't 'Files' !!")

        '
        ' 1. Insert the Icons into the ImageLists.
        '
        index = Me.LargeImageList.Images.Count
        Me.LargeImageList.Images.Add(in_fii.LargeIcon.ToBitmap())
        If Not in_fii.SmallIcon Is Nothing Then
            Me.SmallImageList.Images.Add(in_fii.SmallIcon.ToBitmap())
        Else
            Me.SmallImageList.Images.Add(in_fii.LargeIcon.ToBitmap())
        End If

        '
        ' 2. See if this is a directory
        '
        If Not in_fii.FullPath.StartsWith("::") Then
            dirExists = (New DirectoryInfo(in_fii.FullPath)).Exists
        End If

        '
        ' 2. Create the base item for it.
        '
        lvi = New FileViewerListViewItem(in_fii.FullPath, dirExists, 0)
        lvi.Text = in_fii.Name
        lvi.ImageIndex = index

        '
        ' 3. Create the subitems.
        '    First one: size
        '
        lvsi = New ListViewItem.ListViewSubItem
        If Not in_fii.FullPath.StartsWith("::") Then

            Dim di As DirectoryInfo
            di = New DirectoryInfo(in_fii.FullPath)
            If Not di.Exists Then
                size = New FileInfo(in_fii.FullPath).Length
            End If
        End If
        If Not size = 0 Then
            lvi.setSize(size)
            lvsi.Text = nicePrintSizeSimple(size)
        End If
        lvi.SubItems.Add(lvsi)

        '
        ' Next, type:
        '
        lvsi = New ListViewItem.ListViewSubItem
        If Not in_fii.FullPath.StartsWith("::") Then
            lvsi.Text = ShellFolder.GetTypeDescriptionForFile(in_fii.FullPath)
        End If
        lvi.SubItems.Add(lvsi)

        '
        ' Finally, date:
        '
        lvsi = New ListViewItem.ListViewSubItem
        If Not in_fii.FullPath.StartsWith("::") Then
            lvsi.Text = New FileInfo(in_fii.FullPath).LastAccessTime
        End If
        lvi.SubItems.Add(lvsi)


        Me.Items.Add(lvi)

    End Sub ' addListViewItemForDesktopItem



    '=----------------------------------------------------------------------=
    ' getBestGuessImageIndex
    '=----------------------------------------------------------------------=
    ' Given a file of which whose type we are uncertain, go and get a best
    ' guess Image Index for our defaults now, and then later in the 
    ' background thread, we'll try to get a better one.
    '
    ' Parameters:
    '       String                  - [in]  extention of type to guess
    '
    ' Returns:
    '       BaseImageIndexes        - best guess
    '
    Private Shared Function getBestGuessImageIndex(ByVal in_ext As String) _
                                                   As BaseImageIndexes
        Dim s As String

        s = in_ext.ToLower()

        If s = ".dll" Then
            Return BaseImageIndexes.Dll
        ElseIf s = ".exe" Then
            Return BaseImageIndexes.Exe
        Else
            Return BaseImageIndexes.Unknown
        End If

    End Function ' getBestGuessImageIndex


    '=----------------------------------------------------------------------=
    ' pathIsSpecialPath
    '=----------------------------------------------------------------------=
    ' Indicates whether the given path is one of the special paths which we
    ' handle separately.
    '
    ' Parameters:
    '       String          - [in]  path to examine.
    '
    ' Returns:
    '       Boolean         - True means it is, false not.
    '
    Friend Function pathIsSpecialPath(ByVal in_path As String) As Boolean

        If in_path = Me.LocalizedDesktop _
           OrElse in_path = "Desktop" _
           OrElse in_path = Me.LocalizedMyComputer _
           OrElse in_path = "My Computer" Then

            Return True

        Else
            Return False
        End If

    End Function ' pathIsSpecialPath


    '=----------------------------------------------------------------------=
    ' pathIsValidDiskPath
    '=----------------------------------------------------------------------=
    ' Indicates whether the given path is a valid disk or UNC path, and
    ' points to a valid directory tree ...
    '
    ' Parameters:
    '       String                  - [in]  path to check
    '
    ' Returns:
    '       Boolean                 - True means it is, False nope.
    '
    Private Shared Function pathIsValidDiskPath(ByVal in_path As String) As Boolean

        Dim di As DirectoryInfo

        Try
            di = New DirectoryInfo(in_path)
        Catch ex As Exception
            Return False
        End Try

        Return di.Exists

    End Function


    '=----------------------------------------------------------------------=
    ' resetImageLists
    '=----------------------------------------------------------------------=
    ' At Various points throughout the control's lifetime, we'll need to go
    ' and reset the image lists to the base set of images.  We'll do that
    ' now.
    '
    '
    Private Sub resetImageLists()

        Dim i As ImageList

        '
        ' First, create the large image list.
        '
        If Me.LargeImageList Is Nothing Then

            i = New ImageList
            i.ImageSize = New Size(32, 32)
            i.TransparentColor = Me.BackColor
            i.ColorDepth = ColorDepth.Depth32Bit

            Me.LargeImageList = i
        End If

        '
        ' Next, the Small Image List ...
        '
        If Me.SmallImageList Is Nothing Then
            i = New ImageList
            i.ImageSize = New Size(16, 16)
            i.TransparentColor = Color.Cyan
            i.ColorDepth = ColorDepth.Depth32Bit

            Me.SmallImageList = i
        End If


        '
        ' Now go and populate both of these with the default 
        ' set of icons from the OS (Folder, EXEs, Unknown, and DLLs)
        '
        populateImageListsWithDefaultImages()

        '
        ' Finally, clear the icon cache out.
        '
        Me.m_iconCache = New Hashtable(100)

    End Sub ' resetImageLists


    '=----------------------------------------------------------------------=
    ' populateIconsThread
    '=----------------------------------------------------------------------=
    ' This is a method that exectutes on a different thread to go and, one by
    ' one, populate the items in the ListView with the appropriate Icon.  This
    ' can be as simple as an "ExtractIconEx" call, or as complicated as going
    ' through the registry to figure out what icon to use ...
    '
    Private Sub populateIconsThread()

        Const ICON_CHUNK_SIZE As Integer = 15
        Dim iaia() As ItemAndIcons
        Dim iai As ItemAndIcons
        Dim x As Integer

        '
        ' Create a large array to hold chunks of items
        '
        iaia = New ItemAndIcons(ICON_CHUNK_SIZE - 1) {}

        '
        ' Okay, for each item in the ListView, go and see if we can do a 
        ' little better trying to find an icons for it ...
        '
        For Each i As ListViewItem In Me.Items

            '
            ' let the thread die if necessary.
            '
            If Me.m_abortThread Then Exit For

            '
            ' set up the default values on this and extract the icons
            '
            iai.Item = CType(i, FileViewerListViewItem)
            iai.PreCachedIndex = -1
            iai.LargeIcon = Nothing
            iai.SmallIcon = Nothing

            extractIconsForItem(iai)

            If Not iai.LargeIcon Is Nothing Then
                iaia(x) = iai

                '
                ' increment our count, and if we've filled up the temp array,
                ' go and insert the items on a cross-thread invoke, and
                ' then reset the array ...
                '
                x += 1
                If x = ICON_CHUNK_SIZE Then
                    Me.Invoke(New CrossThreadIconPopulator(AddressOf Me.crossThreadAddIcons), New Object() {iaia, x - 1})
                    x = 0
                    iaia = New ItemAndIcons(ICON_CHUNK_SIZE - 1) {}
                End If
            End If


        Next

        '
        ' Finally, if there are any remaining items the array, invoke
        ' them now.
        '
        If Not x = 0 Then
            Me.Invoke(New CrossThreadIconPopulator(AddressOf Me.crossThreadAddIcons), New Object() {iaia, x - 1})
        End If

        Me.m_iconThread = Nothing

    End Sub ' populateIconsThread


    '=----------------------------------------------------------------------=
    ' crossThreadAddIcons
    '=----------------------------------------------------------------------=
    ' Given a collection of items and icons, go and insert the icons for
    ' the items and set their ImageIndices to reflect this ...
    '
    ' Parameters:
    '       ItemAndIcons()          - [in]  array of information
    '       Integer                 - [in]  Count of items in array.
    '
    Private Sub crossThreadAddIcons(ByVal in_iaia() As ItemAndIcons, ByVal in_count As Integer)

        Dim idx As Integer
        Dim ext As String

        For x As Integer = 0 To in_count

            If Not in_iaia(x).PreCachedIndex = -1 Then
                in_iaia(x).Item.ImageIndex = in_iaia(x).PreCachedIndex
            Else

                '
                ' first see if the item is already in the icon cache ...
                '
                ext = System.IO.Path.GetExtension(in_iaia(x).Item.Text).ToLower()
                If Me.m_iconCache.Contains(ext) Then
                    in_iaia(x).Item.ImageIndex = Me.m_iconCache(ext)
                Else

                    '
                    ' insert the icons into the image list.
                    '
                    idx = Me.LargeImageList.Images.Count
                    Me.LargeImageList.Images.Add(MiscFunctions.IconToBitmap(Me.BackColor, _
                                                                            in_iaia(x).LargeIcon))
                    Me.SmallImageList.Images.Add(MiscFunctions.IconToBitmap(Me.BackColor, _
                                                                            in_iaia(x).SmallIcon))
                    in_iaia(x).Item.ImageIndex = idx

                    '
                    ' update the icon cache if necessary.
                    '
                    If Not ext.Equals(".exe") Then Me.m_iconCache.Add(ext, idx)

                End If
            End If
        Next

    End Sub ' crossThreadAddIcons


    '=----------------------------------------------------------------------=
    ' extractIconsForItem
    '=----------------------------------------------------------------------=
    ' Given a FileViewerListViewItem, go and get the icons for it, depending 
    ' on what type of item it is.
    '
    ' Parameters:
    '       ByRef ItemAndIcons      - [in]  the item and where to put results
    '
    Private Sub extractIconsForItem(ByRef in_iai As ItemAndIcons)

        '
        ' Depending on the current type of the item, go and figure out
        ' what exactly we need to do here ...
        '
        If in_iai.Item.FullPath.ToLower().EndsWith(".exe") Then
            extractIconsForExeItem(in_iai)
        ElseIf in_iai.Item.ImageIndex = BaseImageIndexes.Unknown Then
            extractIconsForUnknownItem(in_iai)
        End If

    End Sub ' extractIconsForItem


    '=----------------------------------------------------------------------=
    ' extractIconsForExeItem
    '=----------------------------------------------------------------------=
    ' Given a file that we know is an EXE, try to extract the icons for it.
    '
    ' Parameters:
    '       ByRef ItemAndIcons      - [in]  item and where to put results
    '
    Private Sub extractIconsForExeItem(ByRef in_iai As ItemAndIcons)

        Dim hiconLarge, hiconSmall As IntPtr
        Dim result As Integer

        '
        ' Okay, we're going to try and get the icon from the EXE file
        ' using win32 apis ...
        '
        hiconLarge = IntPtr.Zero
        hiconSmall = IntPtr.Zero

        Try
            result = Win32Helper.ExtractIconEx( _
                                        in_iai.Item.FullPath, _
                                        0, hiconLarge, hiconSmall, _
                                        1)
            If result <= 0 OrElse hiconLarge.Equals(IntPtr.Zero) Then Return

            '
            ' prepare the icons for returning to the caller.  We'll clone
            ' these icons so we don't have to worry about cleaning them up
            ' laaaaaater.
            '
            in_iai.LargeIcon = Icon.FromHandle(hiconLarge).Clone()
            If Not hiconSmall.Equals(IntPtr.Zero) Then
                in_iai.SmallIcon = Icon.FromHandle(hiconSmall).Clone()
            Else
                in_iai.SmallIcon = Icon.FromHandle(hiconLarge).Clone()
            End If

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.ToString())
        Finally
            If Not hiconLarge.Equals(IntPtr.Zero) Then Win32Helper.DestroyIcon(hiconLarge)
            If Not hiconSmall.Equals(IntPtr.Zero) Then Win32Helper.DestroyIcon(hiconSmall)
        End Try

    End Sub ' extractIconsForExeItem


    '=----------------------------------------------------------------------=
    ' extractIconsForUnknownItem
    '=----------------------------------------------------------------------=
    ' Given a random file-type, do our best to figure out its icon and use
    ' that ...
    '
    ' Parameters:
    '       ByRef ItemAndIcons          - [in]  item and where to put results
    '
    Private Sub extractIconsForUnknownItem(ByRef in_iai As ItemAndIcons)

        Dim hiconlarge, hiconsmall As IntPtr
        Dim ptr As IntPtr
        Dim ext As String
        Dim dw As Integer
        Dim o As Object

        '
        ' First, see if this file type is in the Icon Cache ...
        '
        ext = System.IO.Path.GetExtension(in_iai.Item.FullPath)
        o = Me.m_iconCache(ext)
        If Not o Is Nothing Then
            in_iai.PreCachedIndex = CType(o, Integer)
            Return
        End If

        '
        ' We don't have it, so we have to go and extract/generate them now.
        '
        Try
            '
            ' We're going to use the very cool SHGetFileInfo API for this.
            ' First step: Allocate a buffer for the SHFILEINFO structure.
            '
            ptr = Marshal.AllocCoTaskMem(692)

            '
            ' Next, call the API first to get large icon.  0x100 for the 
            ' uFlags parameter specifies 'large icon'
            '
            dw = Win32Helper.SHGetFileInfoW(in_iai.Item.FullPath, _
                                            0, _
                                            ptr, _
                                            692, _
                                            &H100)
            If dw = 0 Then Return

            hiconlarge = Marshal.ReadIntPtr(ptr, 0)

            '
            ' Get the small icon.  0x101 is small icon
            '
            dw = Win32Helper.SHGetFileInfoW(in_iai.Item.FullPath, _
                                            0, _
                                            ptr, _
                                            692, _
                                            &H101)
            If dw = 0 Then Return

            hiconsmall = Marshal.ReadIntPtr(ptr, 0)

            '
            ' prepare the icons for returning to the caller.  We'll clone
            ' these icons so we don't have to worry about cleaning them up
            ' laaaaaater.
            '
            in_iai.LargeIcon = Icon.FromHandle(hiconlarge).Clone()
            If Not hiconsmall.Equals(IntPtr.Zero) Then
                in_iai.SmallIcon = Icon.FromHandle(hiconsmall).Clone()
            Else
                in_iai.SmallIcon = Icon.FromHandle(hiconlarge).Clone()
            End If

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.ToString())
        Finally

            '
            ' Clean up the memory !
            '
            If Not ptr.Equals(IntPtr.Zero) Then Marshal.FreeCoTaskMem(ptr)
            If Not hiconlarge.Equals(IntPtr.Zero) Then Win32Helper.DestroyIcon(hiconlarge)
            If Not hiconsmall.Equals(IntPtr.Zero) Then Win32Helper.DestroyIcon(hiconsmall)

        End Try


    End Sub ' extractIconsForUnknownItem


    '=----------------------------------------------------------------------=
    ' setColumnsForCurrentPath
    '=----------------------------------------------------------------------=
    ' Fiure out what set of columns we need to be using for the current path
    ' and then go and set them into the ListView
    '
    Private Sub setColumnsForCurrentPath()

        Dim headers() As ColumnHeader
        Dim columnView As Integer

        '
        ' 0. get the view for the current path
        '
        If Me.m_path.Chars(1) = ":" AndAlso Char.IsLetter(Me.m_path.Chars(0)) Then
            columnView = ColumnHeaderViews.Files
        ElseIf Me.m_path = Me.LocalizedMyComputer OrElse Me.m_path = "My Computer" Then
            columnView = ColumnHeaderViews.MyComputer
        End If

        ' 
        ' if we are already in this view, then we're done.
        '
        If Me.m_columnView = columnView Then Return

        '
        ' Save out the old headers.
        '
        If Not Me.m_columnView = ColumnHeaderViews.None Then
            cacheHeadersForView(Me.m_columnView)
        End If

        '
        ' Load in the new ones to which we will switch 
        '
        headers = loadHeadersForView(columnView)

        '
        ' Now, for each header, go and set it up.
        '
        Me.Columns.Clear()
        For Each h As ColumnHeader In headers
            Me.Columns.Add(h)
        Next

        ' 
        ' set the new view
        '
        Me.m_columnView = columnView

    End Sub ' setColumnsForCurrentPath


    '=----------------------------------------------------------------------=
    ' cacheHeadersForView
    '=----------------------------------------------------------------------=
    ' Takes all the headers in the current view and saves them into our array
    ' of header arrays, so they can be restored later, leaving the user with
    ' the illusion that their settings have been saved.
    '
    ' Parameters:
    '       ColumnHeaderViews       - [in]  what view to save.
    '
    Private Sub cacheHeadersForView(ByVal in_view As ColumnHeaderViews)

        Dim headers() As ColumnHeader
        Dim c As Integer

        c = Me.Columns.Count
        headers = New ColumnHeader(c - 1) {}

        For x As Integer = 0 To c - 1
            headers(x) = Me.Columns(x)
        Next

        '
        ' Save away the cached headers.
        '
        Me.m_columnCache(in_view) = headers

    End Sub  ' cacheHeadersForView


    '=----------------------------------------------------------------------=
    ' loadHeadersForView
    '=----------------------------------------------------------------------=
    ' If we already have the headers for the given view cached away, go and
    ' restore those.  Otherwise, we'll go and create a new set with default
    ' values ....
    '
    ' Parameters:
    '       ColumnHeaderViews       - [in]  view to load.
    '
    ' Returns:
    '       ColumnHeader()          - array of headers
    '
    Private Function loadHeadersForView(ByVal in_view As ColumnHeaderViews) As ColumnHeader()
		'
        ' Do we have to go generate them?
        '
        If Me.m_columnCache(in_view) Is Nothing Then
            Me.m_columnCache(in_view) = generateHeadersForView(in_view)
        End If

        '
        ' Now go and restore the values ...
        '
        Return Me.m_columnCache(in_view)

    End Function ' loadHeadersForView


    '=----------------------------------------------------------------------=
    ' generateHeadersForView
    '=----------------------------------------------------------------------=
    ' Generates the headers for the view, getting the localized text and 
    ' default width values for the header.
    '
    ' Parameters:
    '       ColumnHeaderViews       - [in]  view for which to get headers.
    ' 
    ' Returns:
    '       ColumnHeaders()
    '
    Private Function generateHeadersForView(ByVal in_view As ColumnHeaderViews) As ColumnHeader()

        Dim headers() As ColumnHeader
        Dim ch As ColumnHeader
        Dim a, y As Integer

        '
        ' row 0: file/directory view
        ' row 1: my computer view
        '
        Dim templates()() As Object = { _
            New Object(11) {"FileViewerHdrName", 125, 0, "FileViewerHdrSize", 50, 1, "FileViewerHdrType", 125, 0, "FileViewerHdrDateModified", 125, 0}, _
            New Object(11) {"FileViewerHdrName", 125, 0, "FileViewerHdrType", 125, 0, "FileViewerHdrTotalSize", 75, 1, "FileViewerHdrFreeSpace", 75, 1} _
        }

        headers = New ColumnHeader((templates(in_view).GetLength(0) / 3) - 1) {}
        y = 0 : a = 0

        '
        ' Get the array of data, and then work through the creation
        '
        For x As Integer = 0 To headers.GetLength(0) - 1

            ch = New ColumnHeader
            ch.Text = VbPowerPackMain.GetResourceManager().GetString(templates(in_view)(a))
            '            ch.Text = templates(in_view)(a)
            a += 1
            ch.Width = templates(in_view)(a)
            a += 1
            ch.TextAlign = templates(in_view)(a)
            a += 1

            headers(y) = ch
            y += 1

        Next

        Return headers

    End Function ' generateHeadersForView


    '=----------------------------------------------------------------------=
    ' getTypeDescription
    '=----------------------------------------------------------------------=
    ' Gets the description for the given file type.  Given that it is very
    ' expensive to keep going back and forth between managed and native
    ' code, we're going to cache this as much as possible.
    '
    ' Parameters:
    '       String              - [in]  full path, or "" for directories
    '
    ' Returns:
    '       String              - Type Description
    '
    Private Function getTypeDescription(ByVal in_path As String) As String

        Dim typeDesc, ext As String

        '
        ' Is it a directory?  We've definitely already got that!
        '
        If in_path Is Nothing OrElse in_path = "" Then
            Return Me.m_typeCache(FOLDER_KEY)
        End If

        '
        ' Otherwise, see if we've already got it for the given extension
        '
        ext = System.IO.Path.GetExtension(in_path)
        typeDesc = Me.m_typeCache(ext)
        If typeDesc Is Nothing OrElse typeDesc = "" Then

            typeDesc = ShellFolder.GetTypeDescriptionForFile(in_path)
            Me.m_typeCache.Add(ext, typeDesc)

        End If

        Return typeDesc

    End Function ' getTypeDescription


    '=----------------------------------------------------------------------=
    ' getDescriptionForFileType
    '=----------------------------------------------------------------------=
    ' Uses the windows shell APIs to get the friendly description for this
    ' type of file, such as "Text Document", etc ...
    '
    ' Parameters:
    '       FileInfo        - [in] file for which we want the info
    '
    ' Returns:
    '       String          - "" if we couldn't get it
    '
    Private Function getDescriptionForFileType(ByVal in_file As FileInfo) As String

        Dim ptr As IntPtr
        Dim dw As Integer

        '
        ' We'll use the very nifty SHGetFileInfo API for this.  We need
        ' a 692 byte struct first ...
        '
        Try
            ptr = Marshal.AllocCoTaskMem(692)

            '
            ' Call the fn.  0x400 means get type description
            '
            dw = Win32Helper.SHGetFileInfoW(in_file.FullName, 0, _
                                            ptr, 692, &H400)
            If dw = 0 Then Return ""

            Return Marshal.PtrToStringUni(New IntPtr(ptr.ToInt32() + 532))

        Catch ex As Exception
            Return ""
        Finally

            ' 
            ' don't forget to free the buffer we allocated
            '
            If Not ptr.Equals(IntPtr.Zero) Then Marshal.FreeCoTaskMem(ptr)

        End Try

    End Function ' getDescriptionForFileType


    '=----------------------------------------------------------------------=
    ' nicePrintSizeSimple
    '=----------------------------------------------------------------------=
    ' Given a file size, go and get it in a nicer format ...
    '
    ' Parameters:
    '       Long         - [in]  file size
    '
    ' Returns:
    '       String
    '
    Private Shared Function nicePrintSizeSimple(ByVal in_size As Long) As String

        Dim rm As System.Resources.ResourceManager
        Dim baseString As String
        Dim kb As Long

        kb = in_size / 1024

        '
        ' Get the base string.  This is in case the suffix and number have
        ' to be moved around in order ...
        '
        rm = VbPowerPackMain.GetResourceManager()
        baseString = rm.GetString("FileViewerMiscSizeFormat")

        Return String.Format(baseString, kb, rm.GetString("FileViewerMiscKB"))

    End Function ' nicePrintSize


    '=----------------------------------------------------------------------=
    ' nicePrintSizeComplex
    '=----------------------------------------------------------------------=
    ' Given a file size, go and get it in a nicer format ...
    '
    ' Parameters:
    '       Long         - [in]  file size
    '
    ' Returns:
    '       String
    '
    Private Shared Function nicePrintSizeComplex(ByVal in_size As Long) As String

        Dim rm As System.Resources.ResourceManager
        Dim baseString As String
        Dim size As Double
        Dim base As Integer

        size = CType(in_size, Double)

        While size > 1024.0 And base < 4

            size /= 1024.0
            base += 1

        End While

        '
        ' Get the base string.  This is in case the suffix and number have
        ' to be moved around in order ...
        '
        rm = VbPowerPackMain.GetResourceManager()
        baseString = rm.GetString("FileViewerMiscSizeFormat")

        Select Case base

            Case 0
                Return String.Format(baseString, size, rm.GetString("FileViewerMiscBytes"))

            Case 1
                Return String.Format(baseString, size, rm.GetString("FileViewerMiscKB"))

            Case 2
                Return String.Format(baseString, size, rm.GetString("FileViewerMiscMB"))

            Case 3
                Return String.Format(baseString, size, rm.GetString("FileViewerMiscGB"))

            Case 4
                Return String.Format(baseString, size, rm.GetString("FileViewerMiscTB"))

            Case Else
                '
                ' This is a bug
                '
                System.Diagnostics.Debug.Fail("This is a bug")
                Return in_size.ToString()
        End Select

    End Function ' nicePrintSize


    '=----------------------------------------------------------------------=
    ' getFileInfos
    '=----------------------------------------------------------------------=
    ' Returns an array of FileInfo objects for all the files in the current
    ' view.  Optionally returns only those that are selected.
    '
    ' Parameters:
    '       Boolean             - [in]  if True, only return those Selected
    '
    ' Returns:
    '       FileInfo()          - array of matching objects.
    '
    Private Function getFileInfos(ByVal in_selectedOnly) As FileInfo()

        Dim lvi As ListViewItem
        Dim files() As FileInfo
        Dim list As ArrayList
        Dim x As Integer

        '
        ' If it's not a special path, then go and get all the items
        ' that don't have a "Folder" icon. 
        '
        If Not pathIsSpecialPath(Me.m_path) Then

            If Not Me.IsHandleCreated Then

                If in_selectedOnly Then Return New FileInfo() {}

                '
                ' The control isn't populated yet, so go and get the items
                ' using regular ole' filesystem APIs.
                '
                files = New DirectoryInfo(Me.m_path).GetFiles(Me.m_pattern)
                list = New ArrayList(files.Length - 1)

                '
                ' now, whip through, making sure the attributes are right.
                '
                For x = 0 To files.Length - 1
                    If (files(x).Attributes And FileAttributes.Hidden) Then
                        If Me.m_showHidden Then list.Add(files(x))
                    Else
                        list.Add(files(x))
                    End If
                Next
            Else

                '
                ' We do have a handle, so we want to go and use the 
                ' ListViewItems that we have, since they will have other
                ' information in them, such as selection, etc.
                '
                list = New ArrayList(20)
                For x = 0 To Me.Items.Count - 1

                    lvi = Me.Items(x)

                    If in_selectedOnly = False _
                       OrElse (in_selectedOnly = True And lvi.Selected = True) Then

                        If Not lvi.ImageIndex = BaseImageIndexes.Directory Then
                            list.Add(New FileInfo(Me.Path & "\" & lvi.Text))
                        End If

                    End If
                Next
            End If

        Else

            '
            ' It's a special folder.  There are only folders here, not 
            ' files.
            '
            Return New FileInfo() {}

        End If

        Return list.ToArray(GetType(FileInfo))

    End Function ' getFileInfos


    '=----------------------------------------------------------------------=
    ' getFolderInfos
    '=----------------------------------------------------------------------=
    ' Returns an array of Directory objects for all the folders in the current
    ' view.  Optionally returns only those that are selected.
    '
    ' Parameters:
    '       Boolean             - [in]  if True, only return those Selected
    '
    ' Returns:
    '       DirectoryInfo()     - array of matching objects.
    '
    Private Function getFolderInfos(ByVal in_selectedOnly As Boolean) As DirectoryInfo()

        Dim fvlvi As FileViewerListViewItem
        Dim dirs() As DirectoryInfo
        Dim lvi As ListViewItem
        Dim list As ArrayList
        Dim x As Integer

        '
        ' If it's not a special path, then go and get all the items
        ' that have a "Folder" icon. 
        '
        If Not pathIsSpecialPath(Me.m_path) Then

            If Not Me.IsHandleCreated Then

                '
                ' if we don't yet have a handle, then we're going to just
                ' use system APIs to do this for more efficiency.
                '
                If in_selectedOnly Then Return New DirectoryInfo() {}

                dirs = New DirectoryInfo(Me.m_path).GetDirectories(Me.m_pattern)
                list = New ArrayList(Files.Length - 1)

                '
                ' now, whip through, making sure the attributes are right.
                '
                For x = 0 To dirs.Length - 1
                    If (dirs(x).Attributes And FileAttributes.Hidden) Then
                        If Me.m_showHidden Then list.Add(dirs(x))
                    Else
                        list.Add(dirs(x))
                    End If
                Next
            Else

                '
                ' Otherwise, we've got a handle, so go and just use the
                ' items in our listview to see what are directories, etc.
                '
                list = New ArrayList(20)

                For x = 0 To Me.Items.Count - 1

                    lvi = Me.Items(x)

                    If in_selectedOnly = False _
                       OrElse (in_selectedOnly = True And lvi.Selected = True) Then
                        If lvi.ImageIndex = BaseImageIndexes.Directory Then
                            list.Add(New DirectoryInfo(Me.Path & "\" & lvi.Text))
                        End If
                    End If
                Next

            End If

        Else

            '
            ' Go and just use the items we've got in the special folder.  
            ' They're all "Folder" type items anyway!  Make sure we definitely
            ' have a handle right now!
            '
            If Me.IsDisposed Then Return New DirectoryInfo() {}
            If Not Me.IsHandleCreated Then Me.CreateHandle()

            list = New ArrayList(10)

            For Each lvi In Me.Items

                fvlvi = CType(lvi, FileViewerListViewItem)
                If Not fvlvi Is Nothing Then
                    If Not fvlvi.FullPath.StartsWith("::") Then
                        list.Add(New DirectoryInfo(fvlvi.FullPath))
                    End If
                End If
            Next

        End If

        '
        ' finally, return the fruits of our labours.
        '
        Return list.ToArray(GetType(DirectoryInfo))

    End Function ' getFolderInfos


    '=----------------------------------------------------------------------=
    ' getListItemForDrive
    '=----------------------------------------------------------------------=
    ' Given some sort of drive, go and get the ListItem that we will use
    ' for it.
    '
    ' Parameters:
    '       FolderItemInfo              - [in]  name and path.
    '
    ' Returns:
    '       FileViewerListItem
    '
    Private Function getListItemForDrive(ByVal in_fii As ShellFolder.FolderItemInfo) As FileViewerListViewItem

        Dim userFree, diskSize, totalFree As Long
        Dim lvsi As ListViewItem.ListViewSubItem
        Dim lvi As FileViewerListViewItem

        lvi = New FileViewerListViewItem(in_fii.FullPath, True, 0)
        lvi.Text = in_fii.Name

        '
        ' is it a drive??  if so, get free space info.  if not, they'll
        ' stay at 0, and won't be used ...
        '
        If in_fii.FullPath.Length = 3 Then
            Win32Helper.GetDiskFreeSpaceEx(in_fii.FullPath, userFree, diskSize, totalFree)
        End If

        '
        ' sub items
        '
        lvsi = New ListViewItem.ListViewSubItem
        If Not in_fii.FullPath.StartsWith("::") Then
            lvsi.Text = getDescriptionForFileType(New FileInfo(in_fii.FullPath))
        Else
            lvsi.Text = VbPowerPackMain.GetResourceManager().GetString("FileViewerMiscSystemFolder")
        End If

        lvi.SubItems.Add(lvsi)

        lvsi = New ListViewItem.ListViewSubItem
        If Not diskSize = 0 Then
            lvi.setSize(diskSize)
            lvsi.Text = nicePrintSizeComplex(diskSize)
        Else
            lvsi.Text = ""
        End If
        lvi.SubItems.Add(lvsi)

        lvsi = New ListViewItem.ListViewSubItem
        If Not totalFree = 0 Or diskSize > 0 Then
            lvsi.Text = nicePrintSizeComplex(totalFree)
        Else
            lvsi.Text = ""
        End If
        lvi.SubItems.Add(lvsi)

        Return lvi

    End Function ' getListItemForDrive


    '=----------------------------------------------------------------------=
    ' populateImageListsWithDefaultImages
    '=----------------------------------------------------------------------=
    ' We want to have a default set of images with which to work, and we
    ' want them to look appropriate on the appropriate platforms, so we'll go
    ' and extract the images from the OS.
    '
    Private Sub populateImageListsWithDefaultImages()

        Dim largeIcon, smallIcon As Icon
        Dim s As String

        Me.LargeImageList.Images.Clear()
        Me.SmallImageList.Images.Clear()

        '
        ' BaseImageIndexes.Directory
        '
        s = System.Environment.ExpandEnvironmentVariables("%PROGRAMFILES%")
        extractIconsForFile(s, largeIcon, smallIcon)
        Me.LargeImageList.Images.Add(largeIcon.ToBitmap())
        Me.SmallImageList.Images.Add(smallIcon.ToBitmap())

        '
        ' BaseImageIndexes.DLL
        '
        s = System.Environment.ExpandEnvironmentVariables("%WINDIR%\system32\shell32.dll")
        extractIconsForFile(s, largeIcon, smallIcon)
        Me.LargeImageList.Images.Add(largeIcon.ToBitmap())
        Me.SmallImageList.Images.Add(smallIcon.ToBitmap())

        '
        ' BaseImageIndexes.Unknown
        '
        s = System.Environment.ExpandEnvironmentVariables("%WINDIR%\system32\vga.drv")
        extractIconsForFile(s, largeIcon, smallIcon)
        Me.LargeImageList.Images.Add(largeIcon.ToBitmap())
        Me.SmallImageList.Images.Add(smallIcon.ToBitmap())

        '
        ' BaseImageIndexes.EXE
        '
        s = System.Environment.ExpandEnvironmentVariables("%WINDIR%\system32\xcopy.exe")
        extractIconsForFile(s, largeIcon, smallIcon)
        Me.LargeImageList.Images.Add(largeIcon.ToBitmap())
        Me.SmallImageList.Images.Add(smallIcon.ToBitmap())


    End Sub ' populateImageListsWithDefaultImages


    '=----------------------------------------------------------------------=
    ' extractIconsForFile
    '=----------------------------------------------------------------------=
    ' Takes a file or path, and gets the large and small icons associated with
    ' it.
    '
    ' Parameters:
    '       String              - [in]  path to use
    '       ByRef Icon          - [out] large icon
    '       ByRef Icon          - [out] Small Icon
    '
    Private Sub extractIconsForFile(ByVal in_path As String, _
                                    ByRef out_largeIcon As Icon, _
                                    ByRef out_smallIcon As Icon)

        Dim hiconLarge, hiconSmall As IntPtr
        Dim i As System.Drawing.Icon
        Dim dw As Integer
        Dim ptr As IntPtr

        Try
            ' 
            ' Get the Large Icon
            '
            ' We're going to use the very cool SHGetFileInfo API for this.
            ' First step: Allocate a buffer for the SHFILEINFO structure.
            '
            ptr = Marshal.AllocCoTaskMem(692)

            '
            ' 0x100 for the uFlags parameter specifies 'large icon'.
            '
            dw = Win32Helper.SHGetFileInfoW(in_path, _
                                          0, _
                                          ptr, _
                                          692, _
                                          &H100)
            If dw = 0 Then
                Return
            End If

            hiconLarge = Marshal.ReadIntPtr(ptr, 0)

            '
            ' Get the small icon.  0x101 is small icon
            '
            dw = Win32Helper.SHGetFileInfoW(in_path, _
                                          0, _
                                          ptr, _
                                          692, _
                                          &H101)
            If dw = 0 Then
                Win32Helper.DestroyIcon(hiconLarge)
                Return
            End If

            hiconSmall = Marshal.ReadIntPtr(ptr, 0)

            '
            ' Finally, put together the FolderItemInfo structure.
            '
            i = System.Drawing.Icon.FromHandle(hiconLarge)
            out_largeIcon = i.Clone()
            i = System.Drawing.Icon.FromHandle(hiconSmall)
            out_smallIcon = i.Clone()

        Finally

            If Not ptr.Equals(IntPtr.Zero) Then Marshal.FreeCoTaskMem(ptr)
            If Not hiconLarge.Equals(IntPtr.Zero) Then Win32Helper.DestroyIcon(hiconLarge)
            If Not hiconSmall.Equals(IntPtr.Zero) Then Win32Helper.DestroyIcon(hiconSmall)

        End Try


    End Sub ' extractIconsForFile

    '=----------------------------------------------------------------------=
    ' prettyPrintable
    '=----------------------------------------------------------------------=
    ' Takes a string that is ALL capitals and lowers it, and then capitalises
    ' the first letter.  We'll do this in a locale friendly 
    ' way ...
    '
    ' Parameters:
    '       String              - [in]  string to prettify
    '
    ' Returns:
    '       String              - prettified string
    '
    Private Shared Function prettyPrintable(ByVal in_prettify As String) As String

        Dim lower As String

        If in_prettify Is Nothing OrElse in_prettify = "" Then Return ""

        lower = in_prettify.ToLower()

        If Char.IsLower(lower.Chars(0)) Then
            Return Char.ToUpper(lower.Chars(0)) & lower.Substring(1)
        End If

        Return lower

    End Function ' prettyPrintable


    '=----------------------------------------------------------------------=
    ' OnItemClicked
    '=----------------------------------------------------------------------=
    ' An item was clicked by the user in the FileViewer.  Notify the 
    ' application of this now.
    '
    ' Parameters:
    '       FileViewerEventArgs         - [in]  details.
    '
    Protected Overridable Sub OnItemClicked(ByVal fvea As FileViewerEventArgs)

        RaiseEvent ItemClicked(Me, fvea)

    End Sub  ' OnItemClicked


    '=----------------------------------------------------------------------=
    ' OnItemDoubleClicked
    '=----------------------------------------------------------------------=
    ' An Item was double clicked by the user.  Notify the application of this
    ' now.
    '
    ' Parameters:
    '       FileViewerEventArgs         - [in]  details.
    '
    Protected Overridable Sub OnItemDoubleClicked(ByVal fvea As FileViewerEventArgs)

        RaiseEvent ItemDoubleClicked(Me, fvea)

    End Sub ' OnItemDoubleClicked


    '=----------------------------------------------------------------------=
    ' OnSelectedIndexChanged
    '=----------------------------------------------------------------------=
    ' We want to convert this to a more friendly OnItemClicked for our
    ' users.
    '
    Protected Overrides Sub OnSelectedIndexChanged(ByVal e As System.EventArgs)

        If Me.SelectedItems.Count > 0 Then
            Me.OnItemClicked(New FileViewerEventArgs(Me.SelectedItems(0)))
            MyBase.OnItemActivate(e)
        End If

    End Sub ' OnSelectedIndexChanged



    '=----------------------------------------------------------------------=
    ' OnDoubleClick
    '=----------------------------------------------------------------------=
    ' The user has double clicked somewhere in the control.  Translate this
    ' into a more friendly ItemDoubleClicked event.
    '
    '
    Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)

        Dim fvlvi As FileViewerListViewItem
        Dim lvi As ListViewItem
        Dim pt As Point

        '
        ' get the mouse location in the appropraite coordinates
        '
        pt = Me.MousePosition
        pt = Me.PointToClient(pt)
        lvi = Me.GetItemAt(pt.X, pt.Y)
        If Not lvi Is Nothing Then
            fvlvi = CType(lvi, FileViewerListViewItem)
            If Not fvlvi Is Nothing Then
                Me.OnItemDoubleClicked(New FileViewerEventArgs(fvlvi))
            End If
        End If

        MyBase.OnDoubleClick(e)

    End Sub ' OnDoubleClick




    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                              Events
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' ViewChanged
    '=----------------------------------------------------------------------=
    ' The view on the ListView has changed.  People might want to know about
    ' this.
    '
    <LocalisableDescription("FileViewer.ViewChanged"), _
     Category("Behavior")> _
    Public Event ViewChanged(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' SortByChanged
    '=----------------------------------------------------------------------=
    ' The SortBy property has changed.  
    '
    <LocalisableDescription("FileViewer.SortByChanged"), Category("Behavior")> _
    Public Event SortByChanged(ByVal sender As Object, ByVal e As EventArgs)


    '=----------------------------------------------------------------------=
    ' ItemClicked
    '=----------------------------------------------------------------------=
    ' The user has clicked on one of the items in our FileViewer.  Tell
    ' them about this now.
    '
    <LocalisableDescription("FileViewer.ItemClicked"), Category("Behavior")> _
    Public Event ItemClicked(ByVal sender As Object, ByVal fvea As FileViewerEventArgs)


    '=----------------------------------------------------------------------=
    ' ItemDoubleClicked
    '=----------------------------------------------------------------------=
    ' The user has double clicke on one of the items in our FileViewer.  Tell
    ' the application about it.
    '
    <LocalisableDescription("FileViewer.ItemDoubleClicked"), Category("Behavior")> _
    Public Event ItemDoubleClicked(ByVal sender As Object, ByVal fvea As FileViewerEventArgs)


    '=----------------------------------------------------------------------=
    ' ItemCheck
    '=----------------------------------------------------------------------=
    ' We're not exposing CheckBoxes by default, so we don't want to expose
    ' this either ...
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Event ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs)





    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                           Private Classes
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' ItemSorter
    '=----------------------------------------------------------------------=
    ' This class performs the sorting in the FileViewer control.
    '
    '
    Private Class ItemSorter
        Implements IComparer


        '
        ' Parent
        '
        Private m_parent As FileViewer



        '=------------------------------------------------------------------=
        ' Constructor
        '=------------------------------------------------------------------=
        ' Initializes a new instance of the comparer.  We need a reference to
        ' our parent, as well as what field we're sorting on ...
        '
        ' Parameters:
        '       FileViewer          - [in]  our parent.
        '
        Public Sub New(ByVal in_parent As FileViewer)

            Me.m_parent = in_parent

        End Sub ' New


        '=------------------------------------------------------------------=
        ' Compare                                                 [IComparer]
        '=------------------------------------------------------------------=
        ' Performs the comparison.  If we're not browsing files right now, 
        ' then we're just going do a simple name compare.
        '
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare

            Dim lvix, lviy As FileViewerListViewItem
            Dim s1, s2 As String

            lvix = CType(x, FileViewerListViewItem)
            lviy = CType(y, FileViewerListViewItem)

            If lvix Is Nothing OrElse lviy Is Nothing Then
                System.Diagnostics.Debug.Fail("Being asked to compare things that aren't ListViewItems")
                Return 0
            End If

            '
            ' If one's a directory, and the other isn't, then the directory
            ' goes first.
            '
            If lvix.IsFolder AndAlso Not lviy.IsFolder Then
                Return -1
            ElseIf lviy.IsFolder AndAlso Not lvix.IsFolder Then
                Return 1
            End If

            '
            ' sort by name or if we're not in a file/directory view, sort
            ' by name anyway !!!
            '
            If Me.m_parent.SortBy = FileViewerSortBy.Name OrElse Me.m_parent.pathIsSpecialPath(Me.m_parent.Path) Then

                '
                ' Otherwise, just do a name compare ...
                '
                If lvix.Text = lviy.Text Then Return 0
                If lvix.Text > lviy.Text Then Return 1
                Return -1

            ElseIf Me.m_parent.SortBy = FileViewerSortBy.Type Then

                s1 = lvix.SubItems(2).Text
                s2 = lviy.SubItems(2).Text

                If s1 = s2 Then Return 0
                If s1 > s2 Then Return 1
                Return -1

            ElseIf Me.m_parent.SortBy = FileViewerSortBy.Size Then

                If lvix.FileSize > lviy.FileSize Then Return 1
                If lvix.FileSize < lviy.FileSize Then Return -1
                Return 0

            ElseIf Me.m_parent.SortBy = FileViewerSortBy.ModifiedTime Then

                Dim d1, d2 As DateTime

                s1 = lvix.SubItems(2).Text
                s2 = lviy.SubItems(2).Text

                If (s2 Is Nothing OrElse s2 = "") _
                   AndAlso Not (s1 Is Nothing OrElse s1 = "") Then
                    Return 1
                ElseIf (s1 Is Nothing OrElse s1 = "") _
                   AndAlso Not (s2 Is Nothing OrElse s2 = "") Then
                    Return -1
                ElseIf (s2 Is Nothing OrElse s2 = "") _
                   AndAlso (s1 Is Nothing OrElse s1 = "") Then
                    Return 0
                End If

                d1 = DateTime.Parse(lvix.SubItems(3).Text)
                d2 = DateTime.Parse(lviy.SubItems(3).Text)

                If d1 > d2 Then Return 1
                If d2 > d1 Then Return -1
                Return 0

            End If

            '
            ' Dead code .. shouldn't hit ... ?
            '
            Return 0

        End Function ' Compare

    End Class


End Class ' FileViewer


'=--------------------------------------------------------------------------=
' FileViewerListViewItem
'=--------------------------------------------------------------------------=
' This is a subclass of the ListViewItem.  It just has a few more pieces of
' information on it that users might find interesting.
'
'
Public Class FileViewerListViewItem
    Inherits ListViewItem

    '
    ' Private data we'll keep handy so as to keep public access to this 
    ' readonly.
    '
    Private m_fullPath As String
    Private m_isFolder As Boolean
    Private m_fileSize As Long

    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class. 
    '
    Public Sub New(ByVal in_fullPath As String, ByVal in_folder As Boolean, _
                   ByVal in_fileSize As Long)

        Me.m_fileSize = in_fileSize
        Me.m_fullPath = in_fullPath
        Me.m_isFolder = in_folder

    End Sub  ' New


    '=----------------------------------------------------------------------=
    ' FullPath
    '=----------------------------------------------------------------------=
    ' Returns our Full Path
    '
    ' Type:
    '       String
    '
    <LocalisableDescription("FileViewerListViewItem.FullPath")> _
    Public ReadOnly Property FullPath() As String

        Get
            Return Me.m_fullPath
        End Get

    End Property ' FullPath


    '=----------------------------------------------------------------------=
    ' IsFolder
    '=----------------------------------------------------------------------=
    ' Indicates whether or not we have sub items of some sort.
    '
    ' Type:
    '       Boolean
    '
    <LocalisableDescription("FileViewerListViewItem.IsFolder")> _
    Public ReadOnly Property IsFolder() As Boolean

        Get
            Return Me.m_isFolder
        End Get

    End Property ' IsFolder


    '=----------------------------------------------------------------------=
    ' FileSize
    '=----------------------------------------------------------------------=
    ' Returns the size of this file, if applicable.  Otherwise zero is 
    ' returned.
    '
    ' Type:
    '       Long
    '
    <LocalisableDescription("FileViewerListViewItem.FileSize")> _
    Public ReadOnly Property FileSize() As Long

        Get
            Return Me.m_fileSize
        End Get

    End Property ' FileSize



    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                  Private/Friend/Protected methods/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' setSize
    '=----------------------------------------------------------------------=
    ' Gives us a backdoor way to set the size for those few cases where we
    ' can't quite get it right away ...
    '
    ' Parameters:
    '       Long                - [in]  file size.
    '
    Friend Sub setSize(ByVal in_size As Long)

        Me.m_fileSize = in_size

    End Sub ' setSize

End Class ' FileViewerListViewItem







'=--------------------------------------------------------------------------=
' FileViewerEventArgs
'=--------------------------------------------------------------------------=
' Contains more information about one of our events.
'
'
Public Class FileViewerEventArgs
    Inherits System.EventArgs

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                       Private data/types/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '
    ' The item affected.
    '
    Private m_item As FileViewerListViewItem



    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                   Public Methods/Properties/etc.
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class.
    '
    ' Parameters:
    '       FileViewerListViewItem      - [in]  item affected.
    '
    Public Sub New(ByVal in_item As FileViewerListViewItem)

        Me.m_item = in_item

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' Item
    '=----------------------------------------------------------------------=
    ' Indicates the item that was affected by this event.
    '
    ' Type:
    '       FileViewerListViewItem
    '
    Public ReadOnly Property Item() As FileViewerListViewItem

        Get
            Return Me.m_item
        End Get

    End Property ' Item


End Class ' FileViewerEventArgs



