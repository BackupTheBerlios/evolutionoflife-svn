'-------------------------------------------------------------------------------
'<copyright file="FolderViewerNodes.vb" company="Microsoft">
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





'=--------------------------------------------------------------------------=
' FolderViewerTreeNode
'=--------------------------------------------------------------------------=
' This class represents a node in the FolderViewer class.  It's basically
' a TreeNode, except that it has a bunch of code to go and auto populate
' itself, it hides a few properties from the programmer (since we really
' don't want them manipulating things), and adds a few new interesting
' properties.
'
'
Public Class FolderViewerTreeNode
    Inherits TreeNode

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                       Private Members/Types/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '
    ' Make the TreeView think this node has children
    ' until we have actually gone and found them ...
    '
    Protected Const FAKE_NODE As String = "___FAKEIT_NODE___"

    '
    ' These two control whether or not we think/know there are children, and
    ' whether or not we have actually gone and GOT those children from the
    ' Windows Shell.
    '
    Protected m_thereAreSubFolders As Boolean
    Protected m_verifiedAllChildren As Boolean

    '
    ' This is our Full Path as far as the operating system is concerned. 
    ' Please note that for "My Computer", this will just be "My Computer"
    '
    Protected m_fullPath As String

    '
    ' our parent
    '
    Protected m_parent As FolderViewer

    '
    ' Prevent infinite recursion
    '
    Protected m_verifyingChildren As Boolean

    '
    ' Should we show hidden folders ??
    '
    Protected m_showHidden As Boolean




    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '               Public Members/Methods/Functions/etc...
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Goes and initializes a new instance of this class.  We need to know
    ' the information the shell gave us about this class, as well as 
    ' the ImageList into which we should insert any images ...
    '
    ' Parameters:
    '       String          - [in]  Path to the item
    '       String          - [in]  Display Name, or Nothing.
    '       FolderViewer    - [in]  our parent
    '       Boolean         - [in]  should we show hidden children?
    '
    Public Sub New(ByVal in_fullPath As String, _
                   ByVal in_displayName As String, _
                   ByVal in_parent As FolderViewer, _
                   ByVal in_showHidden As Boolean)

        '
        ' 0. Save out variables
        '
        Me.m_fullPath = in_fullPath
        Me.m_parent = in_parent

        '
        ' 1. See if we have any subfolders.
        '
        Me.m_thereAreSubFolders = doesPathHaveSubFolders()
        If Not Me.m_thereAreSubFolders Then
            Me.m_verifiedAllChildren = True
        Else
            MyBase.Nodes.Add(New TreeNode(FAKE_NODE))
        End If

        '
        ' 2. Get our display name.
        '
        If in_displayName Is Nothing OrElse in_displayName = "" Then
            MyBase.Text = Path.GetFileName(in_fullPath)
        Else
            MyBase.Text = in_displayName
        End If

        '
        ' 3. Misc other goo
        '
        Me.m_verifyingChildren = False

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' This is an overloaded version of our constructor for subclasses that
    ' dont necessarily have "normal" paths.
    '
    ' Parameters:
    '       FolderViewer            - [in]  parent control
    '       Boolean                 - [in]  Should we show hidden children?
    '
    Protected Sub New(ByVal in_parent As FolderViewer, _
                      ByVal in_showHidden As Boolean)

        Me.m_parent = in_parent
        Me.m_verifyingChildren = False
        Me.m_showHidden = in_showHidden

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' Nodes
    '=----------------------------------------------------------------------=
    ' If the user wants to get at the nodes, we'll quickly have to make sure
    ' that we have populated them all ...
    '
    ' Type:
    '       TreeNodeCollection
    '
    Public Shadows ReadOnly Property Nodes() As TreeNodeCollection

        Get
            If Not Me.m_verifyingChildren Then Me.verifyChildrenPresent()
            Return MyBase.Nodes
        End Get

    End Property ' Nodes


    '=----------------------------------------------------------------------=
    ' FirstNode
    '=----------------------------------------------------------------------=
    ' If the user wants to get at the nodes, we'll quickly have to make sure
    ' that we have populated them all ...
    '
    ' Type:
    '       TreeNodeCollection
    '
    Public Shadows ReadOnly Property FirstNode() As TreeNode

        Get
            If Not Me.m_verifyingChildren Then Me.verifyChildrenPresent()
            Return MyBase.FirstNode
        End Get

    End Property ' FirstNode


    '=----------------------------------------------------------------------=
    ' LastNode
    '=----------------------------------------------------------------------=
    ' If the user wants to get at the nodes, we'll quickly have to make sure
    ' that we have populated them all ...
    '
    ' Type:
    '       TreeNodeCollection
    '
    Public Shadows ReadOnly Property LastNode() As TreeNode

        Get
            If Not Me.m_verifyingChildren Then Me.verifyChildrenPresent()
            Return MyBase.LastNode
        End Get

    End Property ' FirstNode


    '=----------------------------------------------------------------------=
    ' GetNodeCount
    '=----------------------------------------------------------------------=
    ' If the user wants to get at the nodes, we'll quickly have to make sure
    ' that we have populated them all ...
    '
    Public Shadows Function GetNodeCount(ByVal in_countALL As Boolean) As Integer

        If Not Me.m_verifyingChildren Then Me.verifyChildrenPresent()
        Return MyBase.GetNodeCount(in_countALL)

    End Function ' GetNodeCount


    '=----------------------------------------------------------------------=
    ' FolderPath
    '=----------------------------------------------------------------------=
    ' Returns the file system path to this node, if applicable.  For certain
    ' types of nodes, this will simply be ""
    '
    ' Type:
    '       String
    '
    ' Notes:
    '
    <LocalisableDescription("FolderViewerTreeNode.FolderPath"), _
     Category("Behavior")> _
    Public ReadOnly Property FolderPath() As String

        Get
            Return Me.m_fullPath
        End Get

    End Property ' FolderPath


    '=----------------------------------------------------------------------=
    ' Clone
    '=----------------------------------------------------------------------=
    ' Method should be hidden from the user.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Function Clone() As Object

        Return MyBase.Clone()

    End Function ' Clone


    '=----------------------------------------------------------------------=
    ' Remove
    '=----------------------------------------------------------------------=
    ' Method should be hidden from the user.
    '
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Sub Remove()

        MyBase.Remove()

    End Sub ' Remove







    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '           Protected/Private Members/Methods/Functions/etc...
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' verifyChildrenPresent
    '=----------------------------------------------------------------------=
    ' This method is called by various routines to ensure that we have 
    ' actually gone and looked for our children, thus making sure we get a
    ' chance to grab them.
    '
    ' Returns:
    '       Boolean             - True means we have children, False nope.
    '
    Protected Friend Overridable Function verifyChildrenPresent() As Boolean

        Dim directories() As DirectoryInfo
        Dim dirInfo As DirectoryInfo
        Dim fvtn As FolderViewerTreeNode

        '
        ' are we already doing this?
        '
        If Me.m_verifyingChildren = True Then Return False
        Me.m_verifyingChildren = True

        Try

            '
            ' If we've already done this, return the value.
            '
            If Me.m_verifiedAllChildren Then Return Me.m_thereAreSubFolders

            '
            ' Clear out the old nodes
            '
            MyBase.Nodes.Clear()

            dirInfo = New DirectoryInfo(Me.m_fullPath)
            If dirInfo.Exists Then
                directories = dirInfo.GetDirectories()

                For x As Integer = 0 To directories.Length - 1

                    Dim hidden, system As Boolean

                    hidden = directories(x).Attributes And FileAttributes.Hidden
                    system = directories(x).Attributes And FileAttributes.System

                    '
                    ' Only show the directory if it's not hidden, or
                    ' we're supposed to show hidden, and if it's not system 
                    '
                    If (Me.m_showHidden OrElse (Not (hidden))) _
                       AndAlso (Not (system)) Then

                        fvtn = New FolderViewerTreeNode(directories(x).FullName, _
                                                        Nothing, Me.m_parent, _
                                                        Me.m_showHidden)
                        Me.Nodes.Add(fvtn)

                    End If

                Next

            End If

        Finally

            '
            ' We've checked for children (in case of failure, we just 
            ' say there aren't any ...) and we're done with this function
            '
            Me.m_verifiedAllChildren = True
            Me.m_verifyingChildren = False

        End Try

        Return Me.m_thereAreSubFolders

    End Function ' verifyChildrenPresent


    '=----------------------------------------------------------------------=
    ' doesPathHaveSubFolders
    '=----------------------------------------------------------------------=
    ' Indicates whether our path has sub-folders or not.
    '
    ' Returns:
    '       Boolean             - True means yes.
    '
    Protected Function doesPathHaveSubFolders() As Boolean

        Dim dirInfo As DirectoryInfo
        Dim dirs() As DirectoryInfo

        System.Diagnostics.Debug.Assert(Not Me.m_fullPath Is Nothing, "Haven't set m_fullPath yet !!!!")
        dirInfo = New DirectoryInfo(Me.m_fullPath)

        If dirInfo.Exists Then
            dirs = dirInfo.GetDirectories()
            If Not dirs Is Nothing AndAlso dirs.Length > 0 Then
                Return True
            End If
        End If

        Return False

    End Function ' doesPathHaveSubFolders


End Class  ' FolderViewerTreeNoe










'=--------------------------------------------------------------------------=
' DesktopFolderViewerTreeNode
'=--------------------------------------------------------------------------=
' This node has a slightly different way in which its children are found, so
' we'll go ahead and put it in a separate class that will, for all intents
' and purposes, behave like the desktop.
'
' 
Friend Class DesktopFolderViewerTreeNode
    Inherits FolderViewerTreeNode


    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                       Private Members/Types/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=





    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '               Public Members/Methods/Functions/etc...
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=




    '=----------------------------------------------------------------------=
    ' New
    '=----------------------------------------------------------------------=
    ' Initializes a new instance of this class, filling in the contents of
    ' the Desktop into our child nodes.
    '
    ' Parameters:
    '       FolderViewer            - [in]  parent ctl.
    '       Boolean                 - [in]  Show Hidden Children?
    '
    Public Sub New(ByVal in_parent As FolderViewer, ByVal in_showHidden As Boolean)

        MyBase.New(in_parent, in_showHidden)

        Dim fvtn() As FolderViewerTreeNode

        '
        ' 0. Get our name and path.
        '
        getDesktopNameAndPath(Me.Text, Me.m_fullPath)

        '
        ' Generate our child nodes, add them all, and then make sure we
        ' are expanded ...
        '
        fvtn = generateChildNodesOfDesktop()
        Me.Nodes.AddRange(fvtn)
        Me.Expand()

        '
        ' We know this already.  Cool!
        '
        Me.m_thereAreSubFolders = True
        Me.m_verifiedAllChildren = True

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' generateChildNodesOfDesktop
    '=----------------------------------------------------------------------=
    ' Go and get all the children off the desktop.  Return them in an array
    ' of Nodes
    '
    ' Returns:
    '       FolderViewerTreeNode()      - array of kids to add
    '
    Protected Function generateChildNodesOfDesktop() As FolderViewerTreeNode()

        Dim fiis() As ShellFolder.FolderItemInfo
        Dim fvtn As FolderViewerTreeNode
        Dim myComputer As String
        Dim sf As ShellFolder
        Dim list As ArrayList

        '
        ' 0. Get the path to My Computer so we can identify it l8er.
        '
        myComputer = ShellFolder.GetMyComputerText()

        '
        ' 1. Get the Contents of the desktop
        '
        sf = ShellFolder.DesktopFolder()
        fiis = sf.EnumerateContents(True, False, Me.m_showHidden, False)

        System.Diagnostics.Debug.Assert(Not fiis Is Nothing, "ARGH! Where's my desktop goo????")
        list = New ArrayList(fiis.Length)

        '
        ' Now, for each item on the desktop, if it's not a special path
        ' (i.e. starts with "::...") OR it's "My Computer", then process
        ' and add it.
        '
        For x As Integer = 0 To fiis.Length - 1

            If (Not fiis(x).FullPath.StartsWith("::")) Then

                fvtn = generateNodeForItemWithPath(fiis(x))
                list.Add(fvtn)

            ElseIf fiis(x).Name = myComputer Then

                fvtn = generateNodeForMyComputer(fiis(x))
                list.Add(fvtn)
                Me.m_parent.m_myComputer = fvtn

            End If

        Next

        Return list.ToArray(GetType(FolderViewerTreeNode))

    End Function ' generateChildNodesOfDesktop


    '=----------------------------------------------------------------------=
    ' generateNodeForItemWithPath
    '=----------------------------------------------------------------------=
    ' Generates a FolderViewerTreeNode for an item with a regular path.
    '
    ' Parameters:
    '       FolderItemInfo          - [in]  item to generate
    '
    ' Returns:
    '       FolderViewerTreeNode
    '
    Protected Function generateNodeForItemWithPath(ByVal in_fii As ShellFolder.FolderItemInfo) _
                                                   As FolderViewerTreeNode
        Dim fvtn As FolderViewerTreeNode
        Dim index As Integer

        '
        ' Create the new node
        '
        fvtn = New FolderViewerTreeNode(in_fii.FullPath, in_fii.Name, Me.m_parent, Me.m_showHidden)

        '
        ' Set the image indices
        '
        index = Me.m_parent.ImageList.Images.Count
        Me.m_parent.ImageList.Images.Add(in_fii.SmallIcon.ToBitmap())
        fvtn.ImageIndex = index

        If Not in_fii.SelectedIcon Is Nothing Then
            index += 1
            Me.m_parent.ImageList.Images.Add(in_fii.SelectedIcon.ToBitmap())
        End If

        fvtn.SelectedImageIndex = index
        Return fvtn

    End Function ' generateNodeForDesktop


    '=----------------------------------------------------------------------=
    ' generateNodeForMyComputer
    '=----------------------------------------------------------------------=
    ' Generates the My Computer item for the desktop.
    '
    ' Parameters:
    '       FolderItemInfo      - [in]  details
    '
    ' Returns:
    '       FolderViewerTreeNode
    '
    Private Function generateNodeForMyComputer(ByVal in_fii As ShellFolder.FolderItemInfo) _
                                               As FolderViewerTreeNode
        Dim fvtn As FolderViewerTreeNode
        Dim index As Integer

        '
        ' Create the new node
        '
        fvtn = New MyComputerFolderViewerTreeNode(in_fii.FullPath, in_fii.Name, Me.m_parent, Me.m_showHidden)

        '
        ' Set the image indices
        '
        index = Me.m_parent.ImageList.Images.Count
        Me.m_parent.ImageList.Images.Add(in_fii.SmallIcon.ToBitmap())
        fvtn.ImageIndex = index
        index += 1

        If Not in_fii.SelectedIcon Is Nothing Then
            index += 1
            Me.m_parent.ImageList.Images.Add(in_fii.SelectedIcon.ToBitmap())
        End If

        fvtn.SelectedImageIndex = index
        Return fvtn

    End Function ' generateNodeForMyComputer


    '=----------------------------------------------------------------------=
    ' getDesktopNameAndPath
    '=----------------------------------------------------------------------=
    ' Goes to the system to learn the name and full path to the Desktop
    ' for the current user.
    '
    ' Parameters:
    '       ByRef String        - [out] where to put the Name
    '       ByRef String        - [out] where to put the full path.
    '
    Private Shared Sub getDesktopNameAndPath(ByRef out_name As String, _
                                             ByRef out_fullPath As String)
        Dim sb As System.Text.StringBuilder
        Dim result As Integer
        Dim pidl As IntPtr
        Dim ptr As IntPtr
        Dim f As Boolean


        result = ShellApis.SHGetSpecialFolderLocation(IntPtr.Zero, _
                                    ShellApis.CSIDL_DESKTOP, pidl)
        If Not result = 0 Then
            Throw New FolderViewerException(VbPowerPackMain.GetResourceManager().GetString("excFolderViewerDesktopError"), New Win32Exception(Win32Helper.GetLastError()))
        End If

        Try
            ' 
            ' We're going to use the very cool SHGetFileInfo API to get the
            ' text.  First step: Allocate a buffer for the SHFILEINFO structure.
            '
            ptr = Marshal.AllocCoTaskMem(692)

            '
            ' 0x200 for the uFlags parameter specifies 'display name'. 0x8
            ' says we're passing in a PIDl instead of path.
            '
            result = ShellApis.SHGetFileInfoW(pidl, _
                                              0, _
                                              ptr, _
                                              692, _
                                              &H200 Or &H8)
            If result = 0 Then
                Throw New FolderViewerException(VbPowerPackMain.GetResourceManager().GetString("excFolderViewerDesktopError"), New Win32Exception(Win32Helper.GetLastError()))
            End If

            out_name = Marshal.PtrToStringUni(New IntPtr(ptr.ToInt32() + 12))

            '
            ' Now get the path to the desktop ...
            '
            sb = New System.Text.StringBuilder(260)
            f = ShellApis.SHGetSpecialFolderPath(IntPtr.Zero, sb, _
                                                 ShellApis.CSIDL_DESKTOP, False)
            If f = False Then
                Throw New FolderViewerException(VbPowerPackMain.GetResourceManager().GetString("excFolderViewerDesktopError"), New Win32Exception(Win32Helper.GetLastError()))
            End If
            out_fullPath = sb.ToString()

        Finally

            '
            ' Clean up
            '
            If Not ptr.Equals(IntPtr.Zero) Then Marshal.FreeCoTaskMem(ptr)
            If Not pidl.Equals(IntPtr.Zero) Then ShellApis.GetSHMalloc().Free(pidl)

        End Try

    End Sub ' getDesktopNameAndPath


End Class ' DesktopFolderViewerTreeNode











'=--------------------------------------------------------------------------=
' MyComputerFolderViewerTreeNode
'=--------------------------------------------------------------------------=
' Special node to handle the contents of My Computer ....
'
'
'
Friend Class MyComputerFolderViewerTreeNode
    Inherits FolderViewerTreeNode




    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' Goes and initializes a new instance of this class.  We need to know
    ' the information the shell gave us about this class, as well as 
    ' the ImageList into which we should insert any images ...
    '
    ' Parameters:
    '       String          - [in]  Path to the item
    '       String          - [in]  Display Text
    '       FolderViewer    - [in]  our parent
    '       Boolean         - [in]  should we show hidden children?
    '
    Public Sub New(ByVal in_fullPath As String, _
                   ByVal in_displayText As String, _
                   ByVal in_parent As FolderViewer, _
                   ByVal in_showHidden As Boolean)

        MyBase.New(in_parent, in_showHidden)

        Me.m_fullPath = in_fullPath
        Me.Text = in_displayText

        '
        ' We will definitely have to go loooking for kids. Fake it
        ' for now.
        '
        Me.m_thereAreSubFolders = True
        Me.m_verifiedAllChildren = False

        '
        ' We're just going to force the creation of all these now.
        '
        verifyChildrenPresent()

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' verifyChildrenPresent
    '=----------------------------------------------------------------------=
    ' This method is called by various routines to ensure that we have 
    ' actually gone and looked for our children, thus making sure we get a
    ' chance to grab them.
    '
    ' Returns:
    '       Boolean             - True means we have children, False nope.
    '
    Protected Friend Overrides Function verifyChildrenPresent() As Boolean

        Dim fiis() As ShellFolder.FolderItemInfo
        Dim fvtn As FolderViewerTreeNode
        Dim sf As ShellFolder

        '
        ' are we already doing this?
        '
        If Me.m_verifyingChildren = True Then Return False
        Me.m_verifyingChildren = True

        Try

            '
            ' If we've already done this, then this is easy!
            '
            If Me.m_verifiedAllChildren Then Return Me.m_thereAreSubFolders

            '
            ' Clear out the old nodes
            '
            Me.Nodes.Clear()

            '
            ' Okay, now get the shell folder for my computer
            '
            sf = ShellFolder.MyComputerFolder()

            '
            ' Enumerate the contents, and then add them one at a time ...
            '
            fiis = sf.EnumerateContents(True, False, Me.m_showHidden, False)
            System.Diagnostics.Debug.Assert(Not fiis Is Nothing, "Nothing Under My Computer!!! ARGH!")

            For x As Integer = 0 To fiis.Length - 1

                '
                ' For each one, go and add the icons, and then add the
                ' node
                '
                If Not fiis(x).FullPath.StartsWith("::") Then
                    fvtn = generateNodeForItemWithPath(fiis(x))
                    Me.Nodes.Add(fvtn)

                    Dim xx As Integer
                    xx = Me.Nodes.Count
                End If

            Next

        Finally

            '
            ' We've checked for children (in case of failure, we just 
            ' say there aren't any ...) and we're done with this function
            '
            Me.m_verifiedAllChildren = True
            Me.m_verifyingChildren = False

        End Try

        Return Me.m_thereAreSubFolders

    End Function ' verifyChildrenPresent


    '=----------------------------------------------------------------------=
    ' generateNodeForItemWithPath
    '=----------------------------------------------------------------------=
    ' Generates a FolderViewerTreeNode for an item with a regular path.
    '
    ' Parameters:
    '       FolderItemInfo          - [in]  item to generate
    '
    ' Returns:
    '       FolderViewerTreeNode
    '
    Protected Function generateNodeForItemWithPath(ByVal in_fii As ShellFolder.FolderItemInfo) _
                                                   As FolderViewerTreeNode
        Dim fvtn As FolderViewerTreeNode
        Dim index As Integer

        '
        ' Create the new node
        '
        fvtn = New FolderViewerTreeNode(in_fii.FullPath, in_fii.Name, Me.m_parent, Me.m_showHidden)

        '
        ' Set the image indices
        '
        index = Me.m_parent.ImageList.Images.Count
        Me.m_parent.ImageList.Images.Add(in_fii.SmallIcon.ToBitmap())
        fvtn.ImageIndex = index

        If Not in_fii.SelectedIcon Is Nothing Then
            index += 1
            Me.m_parent.ImageList.Images.Add(in_fii.SelectedIcon.ToBitmap())
        End If

        fvtn.SelectedImageIndex = index
        Return fvtn

    End Function ' generateNodeForDesktop




End Class ' MyComputerFolderViewerTreeNode





