'-------------------------------------------------------------------------------
'<copyright file="ShellFolder.vb" company="Microsoft">
'   Copyright (c) Microsoft Corporation. All rights reserved.
'</copyright>
'
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'-------------------------------------------------------------------------------

Imports System.Collections
Imports System.Runtime.InteropServices



'=--------------------------------------------------------------------------=
' ShellFolder
'=--------------------------------------------------------------------------=
' This class is used to enumerate the contents of a Shell32 PIDL specified
' folder.
'
'
Public Class ShellFolder

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                       Local Types/members/Data
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '=----------------------------------------------------------------------=
    ' FolderItemInfo
    '=----------------------------------------------------------------------=
    ' A simple structure that has the name and icons for items in a folder
    '
    Public Structure FolderItemInfo

        '
        ' Display Name
        '
        Public Name As String

        '
        ' Fully qualified Path for OS Shell
        '
        Public FullPath As String

        ' 
        ' Icons for the object, as well as the Sys Icon Index, which
        ' will help us avoid adding duplicate icons later on ...
        '
        Public LargeIcon As System.Drawing.Icon
        Public SmallIcon As System.Drawing.Icon
        Public SelectedIcon As System.Drawing.Icon

    End Structure ' FolderItemInfo


    '
    ' We always need this handle ...
    '
    Private m_desktopSF As IShellFolder

    '
    ' This is a handle to the shell locatino
    '
    Private m_pidl As IntPtr

    '
    ' do we show folders, files, or hidden?
    '
    Private m_showFolders As Boolean
    Private m_showHidden As Boolean
    Private m_showFiles As Boolean






    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                   Public Properties/Methods/Subs
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ' given the PIDL for a Folder, set oursevles up to enumerate its
    ' contents.
    '
    ' Parameters:
    '       IntPtr              - [in]  PIDL for a Shell Folder.
    '
    Public Sub New(ByVal in_pidl As IntPtr)

        Me.m_pidl = in_pidl

        Me.m_showFiles = True
        Me.m_showHidden = True
        Me.m_showFolders = True

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' EnumerateContents
    '=----------------------------------------------------------------------=
    ' Enumerates the contents of the given folder, returning them in an
    ' array of FolderItemInfo structures
    '
    ' Parameters:
    '       Boolean             - [in]  Show Folders?
    '       Boolean             - [in]  Show Files (Non Folders) ?
    '       Boolean             - [in]  Show Hiddens ?
    '       Boolean             - [in]  try to be quick about it [be smart
    '                                   about icon fetching ...]
    '
    ' Output:
    '       FolderItemInfo()
    '
    Public Function EnumerateContents(ByVal in_showFolders As Boolean, _
                                      ByVal in_showFiles As Boolean, _
                                      ByVal in_showHidden As Boolean, _
                                      Optional ByVal in_quick As Boolean = False) _
                                      As FolderItemInfo()

        Dim pSF As IShellFolder
        Dim result As Integer
        Dim g As Guid

        Me.m_showFolders = in_showFolders
        Me.m_showHidden = in_showHidden
        Me.m_showFiles = in_showFiles

        '
        ' IShellFolder
        '
        g = New Guid("000214E6-0000-0000-C000-000000000046")

        '
        ' If we don't have the desktop yet, then go and get it.  otherwise,
        ' we're the desktop !!!
        '
        If Me.m_desktopSF Is Nothing Then

            result = ShellApis.SHGetDesktopFolder(Me.m_desktopSF)
            If Not result = 0 Then
                Throw New ShellFolderException(VbPowerPackMain.GetResourceManager().GetString("excShellFolderNoDesktop"))
            End If

            Me.m_desktopSF.BindToObject(Me.m_pidl, IntPtr.Zero, g, pSF)

        Else
            ' 
            ' Don't need to do anything, since we already have the 
            ' IShellFolder we need!
            '
            pSF = Me.m_desktopSF

        End If

        '
        ' Get the contents of the shell folder
        '
        Return enumerateAllItems(pSF)

    End Function ' EnumeateContents


    '=----------------------------------------------------------------------=
    ' DesktopFolder
    '=----------------------------------------------------------------------=
    ' Returns the ShellFolder for a Win32 Desktop ...
    '
    ' Returns:
    '       ShellFolder         - For the Desktop
    '
    Public Shared Function DesktopFolder() As ShellFolder

        Dim pdesktop As IShellFolder
        Dim result As Integer
        Dim sf As ShellFolder

        result = ShellApis.SHGetDesktopFolder(pdesktop)
        If Not result = 0 Then Return Nothing

        sf = New ShellFolder(IntPtr.Zero)
        sf.m_desktopSF = pdesktop

        Return sf

    End Function ' DesktopFolder


    '=----------------------------------------------------------------------=
    ' MyComputerFolder
    '=----------------------------------------------------------------------=
    ' Returns the ShellFolder for a Win32 Desktop ...
    '
    ' Returns:
    '       ShellFolder         - For the Desktop
    '
    Public Shared Function MyComputerFolder() As ShellFolder

        Dim result As Integer
        Dim pidl As IntPtr

        result = ShellApis.SHGetSpecialFolderLocation(IntPtr.Zero, _
                                    ShellApis.CSIDL_DRIVES, pidl)
        If Not result = 0 Then Return Nothing

        Return New ShellFolder(pidl)

    End Function ' MyComputerFolder


    '=----------------------------------------------------------------------=
    ' GetTypeDescriptionForFile
    '=----------------------------------------------------------------------=
    ' Given a path, returns the Type Description of it for the shell.
    '
    ' Parameters:
    '       String          - [in]  path to query
    '
    ' Returns:
    '       String
    '
    Public Shared Function GetTypeDescriptionForFile(ByVal in_path As String) As String

        Dim flags As Integer
        Dim ptr As IntPtr
        Dim dw As Integer

        Try
            '
            ' Next Step, allocate a SHFILEINFO structure.  It's 692 bytes.
            '
            ptr = Marshal.AllocCoTaskMem(692)

            '
            ' 0x400 says get display name
            '
            flags = &H400

            '
            ' Call SHGetFileInfo
            '
            dw = Win32Helper.SHGetFileInfoW(in_path, 0, ptr, 692, flags)
            If dw = 0 Then Return ""

            Return Marshal.PtrToStringUni(New IntPtr(ptr.ToInt32() + 532))

        Finally

            If Not ptr.Equals(IntPtr.Zero) Then Marshal.FreeCoTaskMem(ptr)

        End Try

        '
        ' Dead code
        '
        Return ""

    End Function ' GetTypeDescriptionForFile


    '=----------------------------------------------------------------------=
    ' GetMyComputerText
    '=----------------------------------------------------------------------=
    ' Retrieves the name of "My Computer" in the current locale.  We use this
    ' to find it off the desktop.  This isn't a problem, because there's no way for
    ' anything ELSE called "MY ComputeR" to show up on the desktop ...
    '
    ' Returns:
    '       String
    '
    Public Shared Function GetMyComputerText() As String

        Dim flags As Integer
        Dim pidl As IntPtr
        Dim hr As Integer
        Dim ptr As IntPtr
        Dim dw As Integer

        '
        ' Get the PIDL for MyComputer ...
        '
        hr = ShellApis.SHGetSpecialFolderLocation(IntPtr.Zero, _
                                                  ShellApis.CSIDL_DRIVES, _
                                                  pidl)
        If Not hr = 0 Then Return ""

        Try
            '
            ' Next Step, allocate a SHFILEINFO structure.  It's 692 bytes.
            '
            ptr = Marshal.AllocCoTaskMem(692)

            '
            ' 0x200 says get display name, 0x8 says PIDL, not path.
            '
            flags = &H208

            '
            ' Call SHGetFileInfo
            '
            dw = ShellApis.SHGetFileInfoW(pidl, 0, ptr, 692, flags)
            If dw = 0 Then Return ""

            Return Marshal.PtrToStringUni(New IntPtr(ptr.ToInt32() + 12))

        Finally

            If Not ptr.Equals(IntPtr.Zero) Then Marshal.FreeCoTaskMem(ptr)
            If Not pidl.Equals(IntPtr.Zero) Then
                ShellApis.GetSHMalloc().Free(pidl)
            End If

        End Try

        Return ""

    End Function ' GetPIDLForMyComputer




    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                       Private Methods/Subs/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' enumerateAllItems
    '=----------------------------------------------------------------------=
    ' Enumerates all the items in the given ShellFolder, and then returns
    ' them in an array of FolderItemInfo structures ...
    '
    ' Parameters:
    '       IShellFolder                - [in]  what to enumerate
    '
    ' Returns:
    '       FolderItemInfo()            - array o' info
    '
    Private Function enumerateAllItems(ByVal in_pSF As IShellFolder) _
                                       As FolderItemInfo()

        Dim infos() As FolderItemInfo
        Dim pidls() As IntPtr

        '
        ' Get the PIDLs for all the items
        '
        pidls = getAllPIDLs(in_pSF)
        If pidls Is Nothing OrElse pidls.Length = 0 Then Return Nothing

        Try
            ' 
            ' Allocate an array of info structures ..
            '
            infos = New FolderItemInfo(pidls.Length - 1) {}

            '
            ' Get each item
            '
            For x As Integer = 0 To pidls.Length - 1
                infos(x) = getInfoForItem(in_pSF, pidls(x))
            Next

            Return infos

        Finally

            '
            ' Make sure we clean up the PIDLs here ...
            '
            For x As Integer = 0 To pidls.Length - 1
                If Not pidls(x).Equals(IntPtr.Zero) Then
                    ShellApis.GetSHMalloc().Free(pidls(x))
                End If
            Next

        End Try

    End Function ' enumerateAllItems


    '=----------------------------------------------------------------------=
    ' getAllPIDLs
    '=----------------------------------------------------------------------=
    ' Enumerates all the PIDLs in this folder
    '
    ' Parameters:
    '       IShellFolder                - [in]  folder to enumerate
    '
    ' Returns:
    '       IntPtr()                    - array of PIDLs
    '
    Private Function getAllPIDLs(ByVal in_pSF As IShellFolder) _
                                 As IntPtr()

        Dim pidlList As ArrayList
        Dim pEIDL As IEnumIDList
        Dim result As Integer
        Dim item As IntPtr
        Dim c As Integer

        '
        ' We need the enumerator
        '
        in_pSF.EnumObjects(IntPtr.Zero, getSHCONTFFlags(), pEIDL)
        pidlList = New ArrayList(20)

        ' 
        ' loop through them getting all the PIDLs
        '
        While result = 0

            result = pEIDL.NextItem(1, item, c)
            If Not (result = 0 OrElse result = 1) Then
                Throw New ShellFolderException(VbPowerPackMain.GetResourceManager().GetString("excShellFolderCantEnum"))
            End If

            If result = 1 OrElse c = 0 OrElse item.Equals(IntPtr.Zero) Then Exit While
            pidlList.Add(item)

        End While


        Return pidlList.ToArray(GetType(IntPtr))

    End Function ' getAllPIDLs


    '=----------------------------------------------------------------------=
    ' getSHCONTFFlags
    '=----------------------------------------------------------------------=
    ' Depending on what our internal settings are, get the SHCONTF_ flags for
    ' EnumObjects.
    '
    ' Returns:
    '       Integer                 - OR of SHCONTF_ flags
    '
    Private Function getSHCONTFFlags() As Integer

        Dim f As Integer

        f = 0

        If Me.m_showFiles Then
            f = f Or (ShellApis.SHCONTF.SHCONTF_NONFOLDERS Or ShellApis.SHCONTF.SHCONTF_STORAGE)
        End If

        If Me.m_showHidden Then f = f Or ShellApis.SHCONTF.SHCONTF_INCLUDEHIDDEN
        If Me.m_showFolders Then f = (f Or ShellApis.SHCONTF.SHCONTF_FOLDERS Or ShellApis.SHCONTF.SHCONTF_SHAREABLE)

        Return f

    End Function 'getSHCONTFFlags


    '=----------------------------------------------------------------------=
    ' getInfoForItem
    '=----------------------------------------------------------------------=
    ' Retrieves the name, icons, and any other info we need for a shell item.
    '
    ' Parameters:
    '       IntPtr                  - [in]  PIDL to query
    '
    ' Returns:
    '       FolderItemInfo
    '
    Private Function getInfoForItem(ByVal in_pSF As IShellFolder, ByVal in_pidl As IntPtr) As FolderItemInfo

        Dim fii As FolderItemInfo
        Dim pidl As IntPtr

        Try
            '
            ' 1. The Display Name and the Full Path to the item.
            '
            getNameAndPath(in_pSF, in_pidl, fii)

            '
            ' 2. Get the fully qualified PIDL for the item, so we can 
            '    call SHGetFileInfo...
            '
            pidl = constructFullPIDL(Me.m_pidl, in_pidl)

            '
            ' 3. Get the icons for the item
            '
            extractIconsForItem(pidl, fii)

        Finally

            If Not pidl.Equals(IntPtr.Zero) Then ShellApis.GetSHMalloc.Free(pidl)

        End Try

        Return fii

    End Function ' getInfoForItem


    '=----------------------------------------------------------------------=
    ' getNameAndPath
    '=----------------------------------------------------------------------=
    ' Gets the name and path for the item specified by the given PIDL
    '
    ' Parameters:
    '       IShellFolder            - [in]  folder in which item lives
    '       IntPtr                  - [in]  item to query
    '       ByRef FolderItemInfo    - [in]  where to put results
    '
    Private Sub getNameAndPath(ByVal in_pSF As IShellFolder, ByVal in_pidl As IntPtr, ByRef in_fii As FolderItemInfo)

        Dim ptr As IntPtr
        Dim dw As Integer
        Dim p As IntPtr

        Try
            '
            ' 1. Get the name from the IShellFolder
            '

            '
            ' This is a STRRET structure. 0 for the first DWORD tells them
            ' we want a WSTR
            '
            ptr = Marshal.AllocCoTaskMem(264)
            Marshal.WriteInt32(ptr, 0, 0)
            in_pSF.GetDisplayNameOf(in_pidl, 0, ptr)

            '
            ' make sure they actually gave us a WSTR
            '
            dw = Marshal.ReadInt32(ptr, 0)
            If dw = 0 Then

                p = Marshal.ReadIntPtr(ptr, 4)
                in_fii.Name = Marshal.PtrToStringUni(p)
                Marshal.FreeCoTaskMem(p)

            End If

            '
            ' 2. Get the FULL Path
            '
            Marshal.WriteInt32(ptr, 0, 0)
            Marshal.WriteInt32(ptr, 4, 0)

            in_pSF.GetDisplayNameOf(in_pidl, &H8000, ptr)
            dw = Marshal.ReadInt32(ptr, 0)
            If dw = 0 Then

                p = Marshal.ReadIntPtr(ptr, 4)
                in_fii.FullPath = Marshal.PtrToStringUni(p)
                Marshal.FreeCoTaskMem(p)

            End If
        Finally

            '
            ' Make sure we clean up memory here ...
            '
            Marshal.FreeCoTaskMem(ptr)

        End Try

    End Sub ' getNameAndPath


    '=----------------------------------------------------------------------=
    ' extractIconsForItem
    '=----------------------------------------------------------------------=
    ' Gets the large and small icons for teh item specified by the given
    ' PIDL
    '
    ' Parameters:
    '       IntPtr                  - [in]  PIDL
    '       ByRef FolderItemInfo    - [in]  where to put the icons
    '
    Private Sub extractIconsForItem(ByVal in_pidl As IntPtr, _
                                    ByRef in_fii As FolderItemInfo)

        Dim hiconLarge, hiconSmall, hiconOpen As IntPtr
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
            ' 0x100 for the uFlags parameter specifies 'large icon'. 0x8 lets
            ' us use a PIDL instead of a string.
            '
            dw = ShellApis.SHGetFileInfoW(in_pidl, _
                                          0, _
                                          ptr, _
                                          692, _
                                          &H100 Or &H8)
            If dw = 0 Then
                Return
            End If

            hiconLarge = Marshal.ReadIntPtr(ptr, 0)

            '
            ' Get the small icon.  0x101 is small icon. 0x8 is PIDL
            '
            dw = ShellApis.SHGetFileInfoW(in_pidl, _
                                          0, _
                                          ptr, _
                                          692, _
                                          &H101 Or &H8)
            If dw = 0 Then
                Win32Helper.DestroyIcon(hiconLarge)
                Return
            End If

            hiconSmall = Marshal.ReadIntPtr(ptr, 0)

            '
            ' Get the selected icon.  0x103 is small open, 0x8 is pidl.
            '
            dw = ShellApis.SHGetFileInfoW(in_pidl, _
                                          0, ptr, 692, _
                                          &H103 Or &H8)
            If dw = 0 Then
                Win32Helper.DestroyIcon(hiconLarge)
                Win32Helper.DestroyIcon(hiconSmall)
                Return
            End If

            hiconOpen = Marshal.ReadIntPtr(ptr, 0)

            '
            ' Finally, put together the FolderItemInfo structure.
            '
            i = System.Drawing.Icon.FromHandle(hiconLarge)
            in_fii.LargeIcon = i.Clone()
            i = System.Drawing.Icon.FromHandle(hiconSmall)
            in_fii.SmallIcon = i.Clone()
            i = System.Drawing.Icon.FromHandle(hiconOpen)
            in_fii.SelectedIcon = i.Clone()

        Finally

            If Not ptr.Equals(IntPtr.Zero) Then Marshal.FreeCoTaskMem(ptr)
            If Not hiconLarge.Equals(IntPtr.Zero) Then Win32Helper.DestroyIcon(hiconLarge)
            If Not hiconSmall.Equals(IntPtr.Zero) Then Win32Helper.DestroyIcon(hiconSmall)
            If Not hiconOpen.Equals(IntPtr.Zero) Then Win32Helper.DestroyIcon(hiconOpen)

        End Try

    End Sub ' extractIconsForItem


    '=----------------------------------------------------------------------=
    ' constructFullPIDL
    '=----------------------------------------------------------------------=
    ' Convert from a relative pidl to a full PIDL.
    ' 
    ' Parameters:
    '       IntPtr              - [in]  parent/base PIDL
    '       IntPtr              - [in]  relative PIDL of the child
    '
    ' Returns:
    '       IntPtr              - newly allocated FULLY QUALIFIED PIDL.
    '                             Caller MUST FREE WITH ShellApis.GetSHMalloc
    '
    Private Shared Function constructFullPIDL(ByVal in_basePIDL As IntPtr, _
                                              ByVal in_pidl As IntPtr) _
                                              As IntPtr

        Dim baseSize, relativeSize, totalSize As Integer
        Dim fullPIDL As IntPtr

        '
        ' Size needed is: size of root pidl, size of relative pidl, 
        ' plus 2 bytes to hold terminating zero.
        '
        baseSize = getPIDLSize(in_basePIDL)
        relativeSize = getPIDLSize(in_pidl)
        totalSize = baseSize + relativeSize + 2

        '
        ' Now, allocate a new PIDL
        '
        fullPIDL = ShellApis.GetSHMalloc().Alloc(totalSize)

        If Not fullPIDL.Equals(IntPtr.Zero) Then
            ShellApis.CopyMemory(fullPIDL, in_basePIDL, baseSize)
            ShellApis.CopyMemory(New IntPtr(fullPIDL.ToInt32() + baseSize), in_pidl, relativeSize)

            ' 
            ' write out the terminating 0 character
            '
            Marshal.WriteInt16(fullPIDL, baseSize + relativeSize, 0S)
        End If

        Return fullPIDL

    End Function ' constructFullPIDL


    '=----------------------------------------------------------------------=
    ' getPIDLSize
    '=----------------------------------------------------------------------=
    '
    ' Parameters:
    '       IntPtr              - [in]  The PIDL who's size we need to know
    '
    ' Returns:
    '       Integer             - size of the PIDL or 0 on error.
    '
    Private Shared Function getPIDLSize(ByVal in_pidl As IntPtr) As Integer

        Dim size As Integer
        Dim cb As Integer
        Dim ptr As IntPtr

        If in_pidl.Equals(IntPtr.Zero) Then Return 0
        ptr = in_pidl

        '
        ' while there is an item in the chain, get the size and add it
        ' all together ...
        '
        cb = Marshal.ReadInt16(ptr, 0)
        While Not cb = 0

            size += cb
            ptr = New IntPtr(ptr.ToInt32() + cb)
            cb = Marshal.ReadInt16(ptr, 0)

        End While

        Return size

    End Function ' getPIDLSize

End Class ' ShellFolder



Public Class ShellFolderException
    Inherits Exception

    Public Sub New(ByVal in_msg As String)
        MyBase.New(in_msg)
    End Sub ' New
End Class
