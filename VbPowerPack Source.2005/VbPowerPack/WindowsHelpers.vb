'-------------------------------------------------------------------------------
'<copyright file="WindowsHelpers.vb" company="Microsoft">
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
' WindowsHelpers
'=--------------------------------------------------------------------------=
' Wraps a number of the Windows APIs from Win32Helper and prepares the
' required data.
'
Public Class WindowsHelpers

    '=----------------------------------------------------------------------=
    ' GetFullPathInformation
    '=----------------------------------------------------------------------=
    ' Returns the icons and description for the given path.
    '
    ' Parameters:
    '       String                  - [in]  path to query.
    '       ByRef String            - [out] Description
    '       ByRef IntPtr            - [out] HICON large
    '       ByRef IntPtr            - [out] HICON small
    '
    ' Returns:
    '       Boolean                 - False means info wasn't obtainable.
    '
    ' NOTE:
    '       !!!!! CALLER MUST Win32Helper.DestroyIcon BOTH HICONS !!!!!!!
    '
    Public Shared Function GetPathInformation(ByVal in_path As String, _
                                              ByRef out_description As String, _
                                              ByRef out_hiconLarge As IntPtr, _
                                              ByRef out_hiconSmall As IntPtr) _
                                              As Boolean
        Dim flags As Integer
        Dim ptr As IntPtr
        Dim dw As Integer

        out_hiconLarge = IntPtr.Zero
        out_hiconSmall = IntPtr.Zero

        '
        ' First Step, allocate a SHFILEINFO structure.  It's 692 bytes.
        '
        ptr = Marshal.AllocCoTaskMem(692)

        Try
            flags = &H300

            '
            ' Call SHGetFileInfo
            '
            dw = Win32Helper.SHGetFileInfoW(in_path, 0, ptr, 692, flags)
            If Not dw = 0 Then Return False

            out_description = Marshal.PtrToStringUni(New IntPtr(ptr.ToInt32() + 532))
            out_hiconLarge = Marshal.ReadIntPtr(ptr, 0)

            '
            ' Call it a second time to get the small icon
            '
            Marshal.WriteInt32(ptr, 0, 0)
            flags = &H101

            dw = Win32Helper.SHGetFileInfoW(in_path, 0, ptr, 692, flags)
            If Not dw = 0 Then Return False

            out_hiconSmall = Marshal.ReadIntPtr(ptr, 0)

        Catch ex As Exception

            If Not out_hiconLarge.Equals(IntPtr.Zero) Then
                Win32Helper.DestroyIcon(out_hiconLarge)
            End If
            If Not out_hiconSmall.Equals(IntPtr.Zero) Then
                Win32Helper.DestroyIcon(out_hiconSmall)
            End If

            Return False
        Finally

            If Not ptr.Equals(IntPtr.Zero) Then Marshal.FreeCoTaskMem(ptr)

        End Try

        '
        ' if we made it all the way down here, that's a good thing!
        '
        Return True

    End Function ' GetFullPathInformation


    '=----------------------------------------------------------------------=
    ' GetPathIcon
    '=----------------------------------------------------------------------=
    ' Returns a single Icon for the given path.
    '
    ' Parameters:
    '       String              - [in]  path to query.
    '       Boolean             - [in]  True means LARGE, False small
    '
    ' Returns:
    '       IntPtr              - HICON.  MUST CALL DESTROYICON() ON IT!
    '
    Public Shared Function GetPathIcon(ByVal in_path As String, _
                                       ByVal in_large As Boolean) _
                                       As IntPtr

        Dim flags As Integer
        Dim ptr As IntPtr
        Dim dw As Integer


        '
        ' First Step, allocate a SHFILEINFO structure.  It's 692 bytes.
        '
        ptr = Marshal.AllocCoTaskMem(692)

        Try
            If in_large Then
                flags = &H100
            Else
                flags = &H101
            End If

            '
            ' Call SHGetFileInfo
            '
            dw = Win32Helper.SHGetFileInfoW(in_path, 0, ptr, 692, flags)
            If dw = 0 Then Return IntPtr.Zero

            Return Marshal.ReadIntPtr(ptr, 0)

        Finally

            If Not ptr.Equals(IntPtr.Zero) Then Marshal.FreeCoTaskMem(ptr)

        End Try

        Return IntPtr.Zero

    End Function ' GetPathIcon



    '=----------------------------------------------------------------------=
    ' GetPathDescription
    '=----------------------------------------------------------------------=
    ' Returns the description for the given path.
    '
    ' Parameters:
    '       String              - [in]  path to query.
    '
    ' Returns:
    '       String              - OS description for this path
    '
    Public Shared Function GetPathDescription(ByVal in_path As String) _
                                              As String

        Dim flags As Integer
        Dim ptr As IntPtr
        Dim dw As Integer

        '
        ' First Step, allocate a SHFILEINFO structure.  It's 692 bytes.
        '
        ptr = Marshal.AllocCoTaskMem(692)

        Try
            flags = &H200

            '
            ' Call SHGetFileInfo
            '
            dw = Win32Helper.SHGetFileInfoW(in_path, 0, ptr, 692, flags)
            If dw = 0 Then Return ""

            Return Marshal.PtrToStringUni(New IntPtr(ptr.ToInt32() + 12))

        Finally

            If Not ptr.Equals(IntPtr.Zero) Then Marshal.FreeCoTaskMem(ptr)

        End Try

        Return ""

    End Function ' GetPathIcon


    '=----------------------------------------------------------------------=
    ' GetSpecialFolderName
    '=----------------------------------------------------------------------=
    ' Gets the name of the given special folder in the system, since we will
    ' need this to let the user enter them ...
    '
    ' Parameters:
    '       Integer                 - [in]  CSIDL of special folder to find.
    '
    ' Returns:
    '       String                  - the resulting folder name
    '
    Public Shared Function GetSpecialFolderName(ByVal in_csidl As Integer) _
                                                As String

        Dim pidl, ptr, p As IntPtr
        Dim retval As String
        Dim dw As Integer

        Dim isf As IShellFolder

        '
        ' Get the Desktop Folder
        '
        ShellApis.SHGetDesktopFolder(isf)

        '
        ' Get the PIDL, so we can get the display name ...
        '
        dw = ShellApis.SHGetSpecialFolderLocation(IntPtr.Zero, _
                                                  in_csidl, _
                                                  pidl)
        If Not dw = 0 Then Return Nothing
        Try
            '
            ' Allocate a STRRET for the call to GetDisplayNameOf. 0 in the
            ' first DWORD tells the OS we want a WSTR.
            '
            ptr = Marshal.AllocCoTaskMem(264)
            Marshal.WriteInt32(ptr, 0, 0)
            isf.GetDisplayNameOf(pidl, 0, ptr)

            '
            ' Make sure they actually gave us a WSTR ...
            '
            dw = Marshal.ReadInt32(ptr, 0)
            If dw = 0 Then

                p = Marshal.ReadIntPtr(ptr, 4)
                retval = Marshal.PtrToStringUni(p)
                Marshal.FreeCoTaskMem(p)

            End If
        Finally

            '
            ' Clean up some memory we allocated
            '
            If Not ptr.Equals(IntPtr.Zero) Then Marshal.FreeCoTaskMem(ptr)
            If Not pidl.Equals(IntPtr.Zero) Then ShellApis.GetSHMalloc().Free(pidl)

        End Try

        '
        ' return the string we got
        '
        Return retval

    End Function ' GetSpecialFolderName

    '=----------------------------------------------------------------------=
    ' GetMyComputerPath
    '=----------------------------------------------------------------------=
    ' Returns the path of "My Computer".  IT's actually quite difficult.
    '
    ' Parameters:
    '       Integer                 - [in]  CSIDL from ShellApis
    '
    ' Returns:
    '       String
    '
    Public Shared Function GetMyComputerPath() As String

        Dim fiis() As ShellFolder.FolderItemInfo
        Dim myComputer As String
        Dim sf As ShellFolder
        Dim retval As String

        '
        ' 0. Get the path to My Computer so we can identify it l8er.
        '
        myComputer = ShellFolder.GetMyComputerText()

        '
        ' 1. Get the Contents of the desktop
        '
        sf = ShellFolder.DesktopFolder()
        fiis = sf.EnumerateContents(True, False, True, False)

        System.Diagnostics.Debug.Assert(Not fiis Is Nothing, "ARGH! Where's my desktop goo????")

        '
        ' Now, for each item on the desktop, if it's not a special path
        ' (i.e. starts with "::...") OR it's "My Computer", then process
        ' and add it.
        '
        For x As Integer = 0 To fiis.Length - 1

            If fiis(x).Name = myComputer Then

                '
                ' got it!
                '
                retval = fiis(x).FullPath
                Exit For
            End If

        Next

        Return retval

    End Function ' GetMyComputerPath



End Class ' WindowsHelpers
