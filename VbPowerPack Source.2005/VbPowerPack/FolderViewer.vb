'-------------------------------------------------------------------------------
'<copyright file="FolderViewer.vb" company="Microsoft">
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
' FolderViewer
'=--------------------------------------------------------------------------=
' This is a version of the regular WinForms TreeView class that we will use
' to browse folders and other similar places on the local computer.
'
'
<DefaultProperty("RootPath"), _
 DefaultEvent("NodeClicked")> _
Public Class FolderViewer
    Inherits TreeView

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                   Private Member Data, Types, etc...
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    Private Enum ImageIndices

        Folder = 0

    End Enum ' ImageIndices


    '
    ' What is our root path node?
    '
    Private m_rootPath As String

    '
    ' How do you say Desktop on the current system?
    '
    Private m_localizedDesktop As String

    '
    ' How do you say My Computer on the current system?
    '
    Private m_localizedMyComputer As String

    '
    ' Should we show hidden directories as well as regular ones?
    '
    Private m_showHidden As Boolean

    '
    ' This will help us with some searches later on ...
    '
    Friend m_myComputer As FolderViewerTreeNode


    '
    ' For cases where the user sets the CurrentFolder BEFORE we have
    ' a handle and populated treeview...
    '
    Private m_cachedCurrentFolder As String




    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                   Public Methods/Properites/Etc.
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Initialises a new instance of this control.
    '
    '
    Public Sub New()
        MyBase.New()

        '
        ' Set up some values on the properties we're hiding from the 
        ' user ...
        '
        Me.CheckBoxes = False
        Me.FullRowSelect = False
        Me.PathSeparator = "\"
        Me.ShowRootLines = False

        Me.Indent = 0

        '
        ' Other reasonable defaults
        '
        Me.LabelEdit = False
        Me.HotTracking = True
        Me.HideSelection = False

        '
        ' Set up our ImageList
        '
        resetImageList()

        '
        ' Please note that we initialize the initial set of nodes
        ' in the "CreateHandle" method.
        '
        Me.m_rootPath = ""

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' CheckBoxes
    '=----------------------------------------------------------------------=
    ' This property doesn't make sense in this control, and is hidden from
    ' the user.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overridable Shadows Property CheckBoxes() As Boolean

        Get
            Return MyBase.CheckBoxes
        End Get

        Set(ByVal in_newCheckBoxes As Boolean)
            '
            ' We don't support this
            '
        End Set

    End Property ' CheckBoxes


    '=----------------------------------------------------------------------=
    ' Nodes
    '=----------------------------------------------------------------------=
    ' This property from the regular TreeView control will also be available
    ' on our control, except that we will remove any design time support from
    ' it.  Users should not be modifying this stuff.
    '
    ' Type:
    '       TreeNodeCollection (all will be FolderViewerTreeNodes)
    '
    <LocalisableDescription("FolderViewer.Nodes"), _
     Category("Behavior"), _
     Browsable(False)> _
    Public Shadows ReadOnly Property Nodes() As TreeNodeCollection

        Get
            Return MyBase.Nodes
        End Get

    End Property ' Nodes


    '=----------------------------------------------------------------------=
    ' CurrentFolder
    '=----------------------------------------------------------------------=
    ' Returns the name or path of the currently selected folder.
    '
    ' Type:
    '       String              - This may be a localized special name, such
    '                             as "My Computer", etc ...
    '
    <LocalisableDescription("FolderViewer.CurrentFolder"), _
     Category("Behavior"), _
     Browsable(False), _
     DefaultValue(""), _
     Localizable(True)> _
    Public Overridable Property CurrentFolder() As String
        Get

            '
            ' If we have a selected node, then go and see if it has a
            ' FolderPath, or if it's a node like "Desktop", in which 
            ' case we just return the text value ...
            '
            If Not Me.SelectedNode Is Nothing Then
                Dim fvtn As FolderViewerTreeNode
                fvtn = CType(Me.SelectedNode, FolderViewerTreeNode)
                System.Diagnostics.Debug.Assert(Not fvtn Is Nothing, "Argh! Where did this node come from ??? -- " & Me.SelectedNode.Text)

                If fvtn.FolderPath Is Nothing OrElse fvtn.FolderPath = "" Then
                    Return fvtn.Text
                Else
                    Return fvtn.FolderPath
                End If
            End If

            '
            ' Otherwise, return empty string.
            '
            Return ""

        End Get

        Set(ByVal in_newCurrentFolder As String)
            If Me.IsHandleCreated Then
                setPath(in_newCurrentFolder)
            Else
                Me.m_cachedCurrentFolder = in_newCurrentFolder
            End If
        End Set

    End Property ' CurrentFolder


    '=----------------------------------------------------------------------=
    ' RootPath
    '=----------------------------------------------------------------------=
    ' Indicates the path that should form the root of the Tree.  By default,
    ' this is "", which is the same as the "Desktop".
    '
    ' Type:
    '       String  
    '
    <LocalisableDescription("FolderViewer.RootPath"), _
     Category("Behavior"), DefaultValue(""), _
     Localizable(True)> _
    Public Property RootPath() As String

        Get
            Return Me.m_rootPath
        End Get

        '
        ' Set the new value, and rebuild the tree if necessary.
        '
        Set(ByVal in_newRootPath As String)

            '
            ' Arg checking
            '
            If Not in_newRootPath Is Nothing AndAlso Not in_newRootPath = "" _
               AndAlso ((in_newRootPath.Length >= 2 _
                         AndAlso in_newRootPath.Chars(1) = ":" _
                         AndAlso Char.IsLetter(in_newRootPath.Chars(0))) _
                        OrElse Not isSpecialFolder(in_newRootPath)) Then

                Dim di As System.IO.DirectoryInfo
                di = New System.IO.DirectoryInfo(in_newRootPath)

                If Not di.Exists Then
                    Throw New ArgumentException(VbPowerPackMain.GetResourceManager().GetString("excFileViewerPathInvalid"))
                End If

            End If

            '
            ' Otherwise, set the new value, provided it's not the same as the
            ' old one!
            '
            If Not in_newRootPath = Me.m_rootPath Then

                If in_newRootPath = Nothing OrElse in_newRootPath = "" Then
                    Me.m_rootPath = Nothing
                Else
                    '
                    ' given them some help for "C:", etc ...
                    '
                    in_newRootPath = in_newRootPath.Trim().ToLower()
                    If in_newRootPath.Length = 2 And in_newRootPath.Chars(1) = ":" Then
                        Me.m_rootPath = in_newRootPath & "\"
                    Else
                        Me.m_rootPath = in_newRootPath
                    End If
                End If

                '
                ' rebuild the tree and reset the path.
                '
                constructDefaultTree()
                Me.CurrentFolder = ""
            End If

        End Set

    End Property ' RootPath


    '=----------------------------------------------------------------------=
    ' ShowHidden
    '=----------------------------------------------------------------------=
    ' Indicates whether or not we should show hidden folders.
    '
    ' Type:
    '       Boolean
    '
    <LocalisableDescription("FolderViewer.ShowHidden"), _
     Category("Behavior"), _
     DefaultValue(False), _
     Localizable(True)> _
    Public Property ShowHidden() As Boolean

        Get
            Return Me.m_showHidden
        End Get

        '
        ' Set the new value, and rebuild the tree if necessary.
        '
        Set(ByVal in_newShowHidden As Boolean)

            If Not Me.m_showHidden = in_newShowHidden Then
                Me.m_showHidden = in_newShowHidden
                constructDefaultTree()
            End If

        End Set

    End Property ' ShowHidden


    '=----------------------------------------------------------------------=
    ' Refresh
    '=----------------------------------------------------------------------=
    ' Completely refreshes the list of goo in this TreeView control.  Will
    ' attempt to restore the existing path ...
    '
    <LocalisableDescription("FolderViewer.Refresh")> _
    Public Overrides Sub Refresh()

        Dim fvtn As FolderViewerTreeNode
        Dim path As String

        '
        ' save out this value
        '
        If Not Me.SelectedNode Is Nothing Then

            fvtn = CType(Me.SelectedNode, FolderViewerTreeNode)
            If Not fvtn Is Nothing Then
                path = fvtn.FullPath
            End If
        End If

        Me.RecreateHandle()


        MyBase.Refresh()

        '
        ' Now, go and try to find this node again ...
        '
        If Not (path Is Nothing) OrElse Not (path = "") Then
            restoreFromFullPath(path)
        End If


    End Sub '  Refresh


    '=----------------------------------------------------------------------=
    ' ImageList
    '=----------------------------------------------------------------------=
    ' Attempt to hide this property.
    '
    ' Type:
    '       ImageList
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property ImageList() As ImageList

        Get
            Return MyBase.ImageList
        End Get

        Set(ByVal in_newImageList As ImageList)
            '
            ' Ignore this ... we don't ever want people to set this.
            ' 
        End Set

    End Property ' ImageList


    '=----------------------------------------------------------------------=
    ' ImageIndex
    '=----------------------------------------------------------------------=
    ' Attempt to hide this property.
    '
    ' Type:
    '       Integer
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property ImageIndex() As Integer

        Get
            Return MyBase.ImageIndex
        End Get

        Set(ByVal in_newImageIndex As Integer)
            '
            ' Ignore this.  We don't want people fiddling with it.
            '
        End Set

    End Property ' ImageIndex

    '=----------------------------------------------------------------------=
    ' Indent
    '=----------------------------------------------------------------------=
    ' Attempt to hide this property. 
    ' 
    ' Type:
    '       Integer
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property Indent() As Integer

        Get
            Return MyBase.Indent
        End Get

        Set(ByVal in_newIndent As Integer)

            MyBase.Indent = in_newIndent

        End Set

    End Property ' Indent


    '=----------------------------------------------------------------------=
    ' ItemHeight
    '=----------------------------------------------------------------------=
    ' Attempt to hide this property.
    '
    ' Type:
    '       Integer
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property ItemHeight() As Integer

        Get
            Return MyBase.ItemHeight
        End Get

        Set(ByVal in_newItemHeight As Integer)
            MyBase.ItemHeight = in_newItemHeight
        End Set

    End Property ' ItemHeight


    '=----------------------------------------------------------------------=
    ' PathSeparator
    '=----------------------------------------------------------------------=
    ' Our Path separator is always a backslash.
    '
    ' Type:
    '       String
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property PathSeparator() As String
        Get
            Return MyBase.PathSeparator
        End Get

        Set(ByVal in_newPathSeparator As String)
            MyBase.PathSeparator = in_newPathSeparator
        End Set

    End Property ' PathSeparator


    '=----------------------------------------------------------------------=
    ' ShowLines
    '=----------------------------------------------------------------------=
    ' Attempt to hide this property.
    '
    ' Type:
    '       Boolean
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property ShowLines() As Boolean
        Get
            Return MyBase.ShowLines
        End Get

        Set(ByVal in_newShowLines As Boolean)
            MyBase.ShowLines = in_newShowLines
        End Set

    End Property ' ShowLines


    '=----------------------------------------------------------------------=
    ' ShowPlusMinus
    '=----------------------------------------------------------------------=
    ' Attempt to hide this property.
    '
    ' Type:
    '       Boolean
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property ShowPlusMinus() As Boolean
        Get
            Return MyBase.ShowPlusMinus
        End Get

        Set(ByVal in_newShowPlusMinus As Boolean)
            MyBase.ShowPlusMinus = in_newShowPlusMinus
        End Set

    End Property ' ShowPlusMinus


    '=----------------------------------------------------------------------=
    ' ShowRootLines
    '=----------------------------------------------------------------------=
    ' Attempt to hide this property.
    '
    ' Type:
    '       Boolean
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property ShowRootLines() As Boolean
        Get
            Return MyBase.ShowRootLines
        End Get

        Set(ByVal in_newShowRootLines As Boolean)
            MyBase.ShowRootLines = in_newShowRootLines
        End Set

    End Property ' ShowRootLines




    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '               Private Methods/Subs/Properties/etc...
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
            If Me.m_localizedDesktop Is Nothing Then
                Me.m_localizedDesktop = WindowsHelpers.GetSpecialFolderName(ShellApis.CSIDL_DESKTOP).ToLower()
            End If

            Return Me.m_localizedDesktop
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
            If Me.m_localizedMyComputer Is Nothing Then
                Me.m_localizedMyComputer = WindowsHelpers.GetSpecialFolderName(ShellApis.CSIDL_DRIVES).ToLower()
            End If

            Return Me.m_localizedMyComputer
        End Get

    End Property ' LocalizedMyComputer




    '=----------------------------------------------------------------------=
    ' CreateHandle
    '=----------------------------------------------------------------------=
    ' Initializes our default set of items in this control, provided we're 
    ' not verifiably in Design Mode ...
    '
    Protected Overrides Sub CreateHandle()

        MyBase.CreateHandle()

        '
        ' Create the tree, provided we're not at design time, etc ...
        '
        constructDefaultTree()

    End Sub ' CreateHandle



    '=----------------------------------------------------------------------=
    ' constructDefaultTree
    '=----------------------------------------------------------------------=
    ' Sets up an initial or default set of tree items that will show the 
    ' important things in our computer.
    ' 
    '
    Private Sub constructDefaultTree()

        Dim fvtn As FolderViewerTreeNode

        '
        ' 0. If we're in Design Mode, then we don't want to do this !! 
        '
        If Me.DesignMode Then Return

        '
        ' 1. Otherwise, clear out anything we've got already.
        '
        Me.m_myComputer = Nothing
        Me.Nodes.Clear()

        '
        ' 2. Get a base set of icons (folders, Desktop, etc ...)
        '
        generateBaseIcons()

        '
        ' 3. Get the root node as specified by the RootPath property.
        '
        fvtn = generateRootNode()

        '
        ' 4. Add it and force it to be expanded.
        '
        Me.Nodes.Add(fvtn)
        fvtn.Expand()
        Me.SelectedNode = fvtn

        '
        ' 5. Finally, if the user set a CurrentFolder value BEFORE we created
        '    our handle and populated the tree, go and set that now, risking,
        '    of course, throwing an exception.
        '
        If Not Me.m_cachedCurrentFolder Is Nothing Then
            setPath(Me.m_cachedCurrentFolder)
            Me.m_cachedCurrentFolder = Nothing
        End If

    End Sub ' constructDefaultTree


    '=----------------------------------------------------------------------=
    ' generateBaseIcons
    '=----------------------------------------------------------------------=
    ' In an attempt to prevent waste of space in our ImageList, we're going
    ' to pre-cache icons for simple folders and anything else that is likely
    ' to be seen very commonly in the control.
    '
    Private Sub generateBaseIcons()

        Dim hiconSmall As IntPtr
        Dim windir As String

        Me.ImageList.Images.Clear()

        '
        ' 0. ImageIndices.Folder:
        '
        ' We need to choose a good directory from which to get the folder
        ' icon.  %WINDIR% is always a good bet.
        '
        windir = System.Environment.GetEnvironmentVariable("WINDIR")

        '
        ' Get and add the icon
        '
        hiconSmall = WindowsHelpers.GetPathIcon(windir, False)
        Me.ImageList.Images.Add(Icon.FromHandle(hiconSmall).ToBitmap())
        Win32Helper.DestroyIcon(hiconSmall)

        '
        ' Any Others???
        '

    End Sub ' generateBaseIcons


    '=----------------------------------------------------------------------=
    ' generateRootNode
    '=----------------------------------------------------------------------=
    ' Figures out what the root node of the tree is (Depending on the value
    ' of the RootPath variable), and then generates this, returning it.
    '
    ' Returns:
    '       FolderViewerTreeNode    - Root Node.  You should Nodes.Add this
    '
    '
    Private Function generateRootNode() As FolderViewerTreeNode

        Dim fvtn As FolderViewerTreeNode

        '
        ' Are we a Desktop Root Node?
        '
        If Not Me.m_rootPath Is Nothing AndAlso Me.m_rootPath.Length >= 2 AndAlso Me.m_rootPath.Chars(1) = ":" AndAlso Char.IsLetter(Me.m_rootPath.Chars(0)) Then

            Dim s As String
            s = WindowsHelpers.GetPathDescription(Me.m_rootPath)
            fvtn = New FolderViewerTreeNode(Me.m_rootPath, s, Me, Me.m_showHidden)

        ElseIf Me.m_rootPath Is Nothing OrElse Me.m_rootPath = "" _
           OrElse Me.m_rootPath = "desktop" _
           OrElse Me.m_rootPath = Me.LocalizedDesktop Then

            fvtn = New DesktopFolderViewerTreeNode(Me, Me.m_showHidden)
        ElseIf Me.m_rootPath = "my computer" _
               OrElse Me.m_rootPath = Me.LocalizedMyComputer Then

            Dim s As String
            s = WindowsHelpers.GetMyComputerPath()

            fvtn = New MyComputerFolderViewerTreeNode(s, Me.LocalizedMyComputer, Me, Me.m_showHidden)
            Me.m_myComputer = fvtn

        End If

        Return fvtn

    End Function ' generateRootNode


    '=----------------------------------------------------------------------=
    ' OnBeforeExpand
    '=----------------------------------------------------------------------=
    ' We are being asked to expand a node.  We will see if the node needs to
    ' go and find its children, and if so, have it do so.  Otherwise, we will
    ' just go and continue.  
    '
    Protected Overrides Sub OnBeforeExpand(ByVal cea As TreeViewCancelEventArgs)

        Dim fvtn As FolderViewerTreeNode
        Dim haveChildren As Boolean

        fvtn = CType(cea.Node, FolderViewerTreeNode)
        If Not fvtn Is Nothing Then

            '
            ' give it a chance to get its children
            '
            haveChildren = fvtn.verifyChildrenPresent()

            cea.Cancel = Not haveChildren

        Else
            System.Diagnostics.Debug.Fail("Unable to convert node to One of ours!!")
        End If

    End Sub ' OnBeforeExpand


    '=----------------------------------------------------------------------=
    ' resetImageList
    '=----------------------------------------------------------------------=
    ' sets/resets the ImageList for this control.
    '
    Private Sub resetImageList()

        Dim il As ImageList

        il = New ImageList
        il.ColorDepth = ColorDepth.Depth24Bit
        il.ImageSize = New Size(16, 16)
        il.TransparentColor = Color.Black
        MyBase.ImageList = il

    End Sub ' resetImageLists


    '=----------------------------------------------------------------------=
    ' setPath
    '=----------------------------------------------------------------------=
    ' Sets the path from the given string.
    '
    ' Parameters:
    '       String          - [in]  path to set
    '
    Private Sub setPath(ByVal in_newPath As String)

        Dim fvtn, fvtnFind As FolderViewerTreeNode
        Dim drive As String

        If Not in_newPath Is Nothing Then in_newPath = in_newPath.Trim().ToLower()

        '
        ' this causes us to just select the root node in the tree.
        '
        If in_newPath Is Nothing OrElse in_newPath = "" Then

            If Not Me.Nodes Is Nothing Then
                For Each n As TreeNode In Me.Nodes
                    Me.SelectedNode = n
                    Exit For
                Next
            End If
            Return

        ElseIf Not (in_newPath.Length >= 2 AndAlso in_newPath.Chars(1) = ":" AndAlso Char.IsLetter(in_newPath.Chars(0))) Then

            '
            ' for the case where they entered Desktop or My Computer
            '
            If in_newPath = "desktop" OrElse in_newPath = Me.LocalizedDesktop Then
                If (Me.m_rootPath = Nothing OrElse Me.m_rootPath = "" OrElse Me.m_rootPath = "desktop" OrElse Me.m_rootPath = Me.LocalizedDesktop) Then
                    Me.SelectedNode = Me.Nodes(0)
                Else
                    Throw New ArgumentException(String.Format(VbPowerPackMain.GetResourceManager().GetString("excFolderViewerNotRooted"), in_newPath, Me.m_rootPath))
                End If
            ElseIf in_newPath = "my computer" OrElse in_newPath = Me.LocalizedMyComputer Then
                If Not Me.m_myComputer Is Nothing Then
                    Me.SelectedNode = Me.m_myComputer
                Else
                    Throw New ArgumentException(String.Format(VbPowerPackMain.GetResourceManager().GetString("excFolderViewerNotRooted"), in_newPath, Me.m_rootPath))
                End If
            End If

            Return

        End If

        '
        ' try to see if it's a drive-qualified path.
        '
        If in_newPath.Substring(1, 2) = ":\" Then

            drive = in_newPath.Substring(0, 3)

            '
            ' find the node with this drive root, provided we have a 
            ' My Computer Node.  If our RootPath doesn't permit this,
            ' then we just have to brute force it, unfortunately.
            '
            If Not Me.m_myComputer Is Nothing Then
                For x As Integer = 0 To Me.m_myComputer.Nodes.Count - 1

                    fvtn = CType(Me.m_myComputer.Nodes(x), FolderViewerTreeNode)
                    If Not fvtn Is Nothing _
                       AndAlso fvtn.FolderPath.ToLower() = drive.ToLower() Then

                        fvtnFind = matchPathFromDriveRoot(in_newPath, fvtn)
                        Exit For
                    End If
                Next
            Else

                '
                ' If the current root node isn't the Desktop or my computer,
                ' then this will only work if the root node starts with
                ' some portion of the path they gave us.
                '
                System.Diagnostics.Debug.Assert(Not Me.m_rootPath Is Nothing)
                If in_newPath.ToLower().StartsWith(Me.m_rootPath) Then
                    fvtnFind = matchPathFromDriveRoot(in_newPath.Substring(Me.m_rootPath.Length), Me.Nodes(0))
                End If

            End If

        ElseIf in_newPath.StartsWith("::") _
               AndAlso in_newPath.ToLower() = Me.m_myComputer.FolderPath.ToLower() Then

            fvtnFind = Me.m_myComputer

        Else

            '
            ' This isn't a valid node.  We don't have any paths in the 
            ' FolderViewer that aren't filesystem paths EXCEPT for the
            ' My Computer Node, handled above ...
            '
            fvtnFind = Nothing

        End If

        If Not fvtnFind Is Nothing Then
            Me.SelectedNode = fvtnFind
        Else
            Dim valid As Boolean

            '
            ' see if we failed because they gave us a bogus path or because 
            ' they gave us a path that's not currently rooted (i.e. our root
            ' directory doesn't contain this as a sub-directory)
            '
            Try
                Dim di As System.IO.DirectoryInfo
                di = New System.IO.DirectoryInfo(in_newPath)
                valid = di.Exists

            Catch ex As Exception
                valid = False
            End Try

            If valid Then
                Throw New ArgumentException(String.Format(VbPowerPackMain.GetResourceManager().GetString("excFolderViewerNotRooted"), in_newPath, Me.m_rootPath))
            Else
                Throw New ArgumentException(String.Format(VbPowerPackMain.GetResourceManager().GetString("excFolderViewerBadPath"), in_newPath))
            End If
        End If

    End Sub ' setPath


    '=----------------------------------------------------------------------=
    ' matchPathFromDriveRoot
    '=----------------------------------------------------------------------=
    ' Matches the given path to the given node representing its drive root. 
    ' We do this using recursion. 
    '
    ' Parameters:
    '       String                  - [in]  path to match.
    '       FolderViewerTreeNode    - [in]  drive root node
    '
    ' Returns:
    '       FolderViewerTreeNode    - matched node
    '
    Private Function matchPathFromDriveRoot(ByVal in_path As String, _
                                            ByVal in_node As FolderViewerTreeNode) _
                                            As FolderViewerTreeNode
        Dim items() As String

        If in_path.ToLower() = in_node.FolderPath.ToLower() Then
            Return in_node
        End If

        '
        ' Split the path up, and then go and look through the node's children
        ' to see if we can't find what we're looking for.
        '
        items = in_path.Split("\")
        Return recurseAndMatchPath(1, items, in_node)

    End Function ' matchPathFromDriveRoot


    '=----------------------------------------------------------------------=
    ' recurseAndMatchPath
    '=----------------------------------------------------------------------=
    ' Performs the recursive portion of matchPathFromDriveRoot
    '
    ' Parameters:
    '       Integer                 - [in]  Recursion Index into in_items
    '       String()                - [in]  path split all up.
    '       FolderViewerTreeNode    - [in]  node in which to look
    '
    ' Returns:
    '       FolderViewerTreeNode    - Found node or nothing if couldn't
    '
    Private Function recurseAndMatchPath(ByVal in_recursionIndex As Integer, _
                                         ByVal in_items() As String, _
                                         ByVal in_node As FolderViewerTreeNode) _
                                         As FolderViewerTreeNode

        '
        ' End to the recursion:  We keep finding things, and there's nothing
        ' more to find.
        '
        If in_recursionIndex >= in_items.Length Then
            Return in_node
        End If

        '
        ' Otherwise, look through the children for a match.
        '
        For x As Integer = 0 To in_node.Nodes.Count - 1
            If in_node.Nodes(x).Text.ToLower() = in_items(in_recursionIndex).ToLower() Then
                Return recurseAndMatchPath(in_recursionIndex + 1, in_items, in_node.Nodes(x))
            End If
        Next

        '
        ' If we got here, and then we couldn't find the kid, in which case
        ' our work here is done.
        '
        Return Nothing

    End Function ' recurseAndMatchPath


    '=----------------------------------------------------------------------=
    ' restoreFromFullPath
    '=----------------------------------------------------------------------=
    ' Given  a TREEVIEW path, go and restore the selected item from this
    ' treeview path.
    '
    ' Parameters:
    '       String                  - [in]  TreeView path.
    '
    Private Sub restoreFromFullPath(ByVal in_path As String)

        Dim s() As String
        Dim path As String

        s = in_path.Split("\")

        If Not s(0) = Me.Nodes(0).Text Then Return
        If s.Length = 1 Then
            Me.SelectedNode = Me.Nodes(0)
            Return
        End If

        path = s(0)
        recursiveRestoreFromFullPath(1, Me.Nodes(0), s, path)

    End Sub ' restoreFromFullPath


    '=----------------------------------------------------------------------=
    ' recursiveRestoreFromFullPath
    '=----------------------------------------------------------------------=
    ' Basically does a breadth first search of our tree trying to restore
    ' from the given FullPath we got back from a node at some point in time.
    '
    ' Parameters:
    '       Integer             - [in]  recursion index (into array of paths)
    '       TreeNode            - [in]  current node in tree search
    '       String()            - [in]  array of path components
    '       String              - [in]  path generated thus far 
    '
    ' Returns:
    '       Boolean             - True: found it, abort search.
    '
    Private Function recursiveRestoreFromFullPath(ByVal in_recursionIndex As Integer, _
                                             ByVal in_node As TreeNode, _
                                             ByVal in_array() As String, _
                                             ByVal in_path As String) _
                                             As Boolean

        Dim path As String

        If in_recursionIndex >= in_array.Length Then
            Me.SelectedNode = in_node
            Return True
        End If

        path = in_path & "\" & in_array(in_recursionIndex)
        in_node.Expand()

        For Each node As TreeNode In in_node.Nodes
            If node.FullPath = path Then
                If recursiveRestoreFromFullPath(in_recursionIndex + 1, _
                                                node, _
                                                in_array, path) Then
                    Return True
                End If
            End If
        Next

        Return False

    End Function ' recursiveRestoreFromFullPath



    '=----------------------------------------------------------------------=
    ' OnAfterSelect
    '=----------------------------------------------------------------------=
    ' Instead of this event, we want users to see the NodeClicked
    ' event.
    '
    Protected Overrides Sub OnAfterSelect(ByVal e As System.Windows.Forms.TreeViewEventArgs)

        Dim fvtn As FolderViewerTreeNode

        fvtn = CType(e.Node, FolderViewerTreeNode)
        If Not fvtn Is Nothing Then
            Me.OnNodeClicked(New FolderViewerEventArgs(fvtn))
        End If

        MyBase.OnAfterSelect(e)

    End Sub ' OnAfterSelect


    '=----------------------------------------------------------------------=
    ' OnDoubleClick
    '=----------------------------------------------------------------------=
    ' To make this a bit less confusing for application writers, we're going 
    ' to given them a double click event which provides the node that was
    ' double clicked ...
    '
    ' 
    Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)

        Dim fvtn As FolderViewerTreeNode
        Dim tn As TreeNode
        Dim pt As Point

        '
        ' Get the current mouse poisition in our coordinates.
        '
        pt = Me.MousePosition
        pt = Me.PointToClient(pt)

        '
        ' now, go and get the appropriate item at these coordinates.
        '
        tn = Me.GetNodeAt(pt)
        If Not tn Is Nothing Then
            fvtn = CType(tn, FolderViewerTreeNode)
            If Not fvtn Is Nothing Then

                '
                ' It's one of ours!  go and fire the event!
                '
                OnNodeDoubleClicked(New FolderViewerEventArgs(fvtn))

            End If
        End If

    End Sub ' OnDoubleClick


    '=----------------------------------------------------------------------=
    ' OnNodeClicked
    '=----------------------------------------------------------------------=
    ' Fires the NodeClicked Event.
    '
    ' Parameters:
    '       FolderViewerEventArgs           - [in]  details
    '
    Protected Overridable Sub OnNodeClicked(ByVal fvea As FolderViewerEventArgs)

        RaiseEvent NodeClicked(Me, fvea)

    End Sub ' OnNodeClicked


    '=----------------------------------------------------------------------=
    ' OnNodeDoubleClicked
    '=----------------------------------------------------------------------=
    ' The user double clicked on a node.  The exact node is provided to the
    ' application writer.
    '
    ' Parameters:
    '       FolderViewerEventArgs           - [in]  details.
    '
    Protected Overridable Sub OnNodeDoubleClicked(ByVal fvea As FolderViewerEventArgs)

        RaiseEvent NodeDoubleClicked(Me, fvea)

    End Sub ' OnNodeDoubleClicked


    '=----------------------------------------------------------------------=
    ' isSpecialFolder
    '=----------------------------------------------------------------------=
    ' Is the given path a special folder ???
    '
    ' Parameters:
    '       String              - [in]  string to check
    '
    ' Returns:
    '       Boolean
    '
    Private Function isSpecialFolder(ByVal in_path As String) As Boolean

        If Not in_path Is Nothing Then in_path = in_path.Trim().ToLower()

        If in_path = "desktop" OrElse in_path = "my computer" _
           OrElse in_path = Me.LocalizedDesktop OrElse in_path = Me.LocalizedMyComputer Then
            Return True
        End If

        Return False

    End Function ' isSpecialFolder


    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                               EVENTS
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' NodeClicked
    '=----------------------------------------------------------------------=
    ' This event is sent when a Node is "Clicked".  It's designed to be a
    ' little less confusing than all the events in the regular TreeView, and
    ' just let the application know that the user has clicked an item.
    '
    '
    <LocalisableDescription("FolderViewer.NodeClicked"), Category("Behavior")> _
    Public Event NodeClicked(ByVal sender As Object, ByVal e As FolderViewerEventArgs)


    '=----------------------------------------------------------------------=
    ' NodeDoubleClicked
    '=----------------------------------------------------------------------=
    ' The user has double clicked on a node in the application.  
    '
    <LocalisableDescription("FolderViewer.NodeDoubleClicked"), Category("Behavior")> _
    Public Event NodeDoubleClicked(ByVal sender As Object, ByVal e As FolderViewerEventArgs)


    '=----------------------------------------------------------------------=
    ' AfterCheck
    '=----------------------------------------------------------------------=
    ' We don't support checking of items on this control
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Event AfterCheck(ByVal sender As Object, ByVal e As TreeViewEventArgs)


    '=----------------------------------------------------------------------=
    ' BeforeCheck
    '=----------------------------------------------------------------------=
    ' We don't support checking of items on this control
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Event BeforeCheck(ByVal sender As Object, ByVal e As TreeViewEventArgs)


End Class ' FolderViewer




'=--------------------------------------------------------------------------=
' FolderViewerException
'=--------------------------------------------------------------------------=
' A simple, but specific class to let users know that a win32 error came 
' via the FolderViewer control.
'
Public Class FolderViewerException
    Inherits Exception

    Public Sub New(ByVal in_msg As String, _
                   Optional ByVal in_inner As Exception = Nothing)

        MyBase.New(in_msg, in_inner)

    End Sub ' New

End Class  ' FolderViewerException



'=--------------------------------------------------------------------------=
' FolderViewerEventArgs
'=--------------------------------------------------------------------------=
' Details about a particular event in the FolderViewer
'
'
Public Class FolderViewerEventArgs
    Inherits System.EventArgs


    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                       Private Data/Types/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '
    ' The node affected
    '
    Private m_node As FolderViewerTreeNode


    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                    Public Methods/Properties/etc
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
    '       FolderViewerTreeNode        - [in]  Node affected.
    '
    '
    Public Sub New(ByVal in_node As FolderViewerTreeNode)

        Me.m_node = in_node

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' Node
    '=----------------------------------------------------------------------=
    ' The node affected by the event.
    '
    ' Type:
    '       FolderViewerTreeNode
    '
    Public Overridable ReadOnly Property Node() As FolderViewerTreeNode

        Get
            Return Me.m_node
        End Get

    End Property ' Node


End Class ' FolderViewerEventArgs