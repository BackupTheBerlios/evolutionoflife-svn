'-------------------------------------------------------------------------------
'<copyright file="ShellApis.vb" company="Microsoft">
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
' ShellApis
'=--------------------------------------------------------------------------=
' Declares a lot of the functions that we will use while interacting with the
' Win32 Shell APIs.
'
'
Public Class ShellApis

    '
    ' This is the IMalloc for the shell folder.  Please use "GetSHMalloc" to
    ' get this pointer.
    '
    Private Shared s_shellMalloc As IMalloc

    '=----------------------------------------------------------------------=
    ' GetSHMalloc
    '=----------------------------------------------------------------------=
    ' returns the shell's malloc pointer.
    '
    Public Shared Function GetSHMalloc() As IMalloc

        If ShellApis.s_shellMalloc Is Nothing Then
            ShellApis.SHGetMalloc(ShellApis.s_shellMalloc)
        End If

        Return ShellApis.s_shellMalloc

    End Function ' GetSHMalloc


    '=----------------------------------------------------------------------=
    ' CSIDLs
    '=----------------------------------------------------------------------=
    ' These are a few (but not all) of the CSIDLs, and are the ones about
    ' which we care.
    '
    '
    Public Const CSIDL_BITBUCKET As Integer = &HA
    Public Const CSIDL_DESKTOP As Integer = 0
    Public Const CSIDL_DRIVES As Integer = &H11
    Public Const CSIDL_NETHOOD As Integer = &H12
    Public Const CSIDL_MYDOCUMENTS As Integer = &HC
    Public Const CSIDL_CONTROLS As Integer = &H3


    '=----------------------------------------------------------------------=
    ' SHCONTF_ values
    '=----------------------------------------------------------------------=
    ' for IShellFolder::EnumObjects
    '
    Public Enum SHCONTF

        SHCONTF_FOLDERS = &H20
        SHCONTF_NONFOLDERS = &H40
        SHCONTF_INCLUDEHIDDEN = &H80
        SHCONTF_INIT_ON_FIRST_NEXT = &H100
        SHCONTF_NETPRINTERSRCH = &H200
        SHCONTF_SHAREABLE = &H400
        SHCONTF_STORAGE = &H800

    End Enum ' SHCONTF


    '=----------------------------------------------------------------------=
    ' SHGetMalloc
    '=----------------------------------------------------------------------=
    ' HRESULT SHGetMalloc(
    '       LPMALLOC *ppMalloc
    ' );
    '
    Public Declare Auto Function SHGetMalloc Lib "shell32.dll" ( _
                                    ByRef out_ppMalloc As IMalloc) _
                                    As Integer


    '=----------------------------------------------------------------------=
    ' SHGetDesktopFolder
    '=----------------------------------------------------------------------=
    ' HRESULT SHGetDesktopFolder(
    '          IShellFolder **ppshf
    ' );
    '
    Public Declare Auto Function SHGetDesktopFolder Lib "shell32.dll" ( _
                                    ByRef out_ppSF As IShellFolder) _
                                    As Integer


    '=----------------------------------------------------------------------=
    ' SHGetSpecialFolderLocation
    '=----------------------------------------------------------------------=
    ' HRESULT SHGetSpecialFolderLocation(
    '          HWND hwndOwner,
    '          int nFolder,
    '          LPITEMIDLIST *ppidl
    ' );
    '
    Public Declare Auto Function SHGetSpecialFolderLocation Lib "shell32.dll" ( _
                                    ByVal in_hwndOwner As IntPtr, _
                                    ByVal in_nFolder As Integer, _
                                    ByRef out_ppidl As IntPtr) _
                                    As Integer


    '=----------------------------------------------------------------------=
    ' SHGetSpecialFolderPath
    '=----------------------------------------------------------------------=
    ' BOOL SHGetSpecialFolderPath(
    '          HWND hwndOwner,
    '          LPTSTR lpszPath,
    '          int nFolder,
    '          BOOL fCreate
    ' );
    '
    Public Declare Auto Function SHGetSpecialFolderPath Lib "shell32.dll" ( _
                                    ByVal in_hwndOwner As IntPtr, _
                                    ByVal in_lpszPath As System.Text.StringBuilder, _
                                    ByVal in_nFolder As Integer, _
                                    ByVal in_fCreate As Boolean) _
                                    As Boolean



    '=----------------------------------------------------------------------=
    ' SHGetFileInfo
    '=----------------------------------------------------------------------=
    ' DWORD_PTR SHGetFileInfo(
    '       LPCTSTR pszPath,        // THIS CAN BE A PIDL INSTEAD !!!!
    '       DWORD dwFileAttributes,
    '       SHFILEINFO *psfi,
    '       UINT cbFileInfo,
    '       UINT uFlags
    ' );
    '
    ' NOTE:  in_pshfi is a pointer to a struct called SHFILEINFO.  We will
    '        CoTaskMemAlloc this using the Marshall class (the struct is 692
    '        bytes in size), and then pick apart the data on our own.  I've
    '        simply had too many problems trying to marshall it any other 
    '        way ....
    '
    Public Declare Unicode Function SHGetFileInfoW Lib "Shell32.dll" ( _
                                    ByVal in_pidl As IntPtr, _
                                    ByVal in_dwFileAttributes As Integer, _
                                    ByVal in_pshfi As IntPtr, _
                                    ByVal in_cbFileInfo As Integer, _
                                    ByVal in_uFlags As Integer) _
                                    As Integer


    '=----------------------------------------------------------------------=
    ' Shell_GetImageLists
    '=----------------------------------------------------------------------=
    ' BOOL Shell_GetImageLists(
    '          HIMAGELIST *phiml,
    '          HIMAGELIST *phimlSmall
    ' );
    '
    Public Declare Auto Function Shell_GetImageLists Lib "shell32.dll" ( _
                                    ByRef out_phimlLarge, _
                                    ByRef out_phimlSmall) _
                                    As Boolean


    '=----------------------------------------------------------------------=
    ' CopyMemory
    '=----------------------------------------------------------------------=
    ' void CopyMemory(
    '       PVOID Destination,
    '       const VOID* Source,
    '       SIZE_T Length
    ' );
    '
    Public Declare Auto Sub CopyMemory Lib "kernel32.dll" ( _
                                    ByVal in_dest As IntPtr, _
                                    ByVal in_src As IntPtr, _
                                    ByVal in_cb As Integer)


End Class


'=--------------------------------------------------------------------------=
' IMalloc
'=--------------------------------------------------------------------------=
' We'll need to work with the shell's allocator.
'
'
<ComImport(), Guid("00000002-0000-0000-c000-000000000046"), System.Runtime.InteropServices.InterfaceTypeAttribute(System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIUnknown), System.Security.SuppressUnmanagedCodeSecurity()> _
Public Interface IMalloc
    <PreserveSig()> _
    Function Alloc(<MarshalAs(UnmanagedType.U4)> ByVal in_cb As Integer) As IntPtr

    Sub Free(ByVal in_freeMe As IntPtr)

    Function Realloc(ByVal in_pv As IntPtr, ByVal in_cb As Integer) As IntPtr

    Function GetSize(ByVal in_pv As IntPtr) As Integer

    Function DidAlloc(ByVal in_pv As IntPtr) As Integer

    Sub HeapMinimize()

End Interface ' IMalloc


'=--------------------------------------------------------------------------=
' IShellFolder
'=--------------------------------------------------------------------------=
' We need to use this to interact with a lot of Shell methods.  please note that
' we are NOT fully declaring it, as it's reasonably complex, and some parts are
' not required.
'
<ComImport(), Guid("000214E6-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
Public Interface IShellFolder

    '
    '        virtual HRESULT STDMETHODCALLTYPE ParseDisplayName( 
    '            /* [in] */ HWND hwnd,
    '            /* [in] */ LPBC pbc,
    '            /* [string][in] */ LPOLESTR pszDisplayName,
    '            /* [out] */ ULONG *pchEaten,
    '            /* [out] */ LPITEMIDLIST *ppidl,
    '            /* [unique][out][in] */ ULONG *pdwAttributes) = 0;
    ' 
    Sub ParseDisplayName(ByVal in_hwnd As IntPtr, _
                         ByVal in_pbc As IntPtr, _
                         ByVal in_pszDisplayName As String, _
                         ByRef out_pchEaten As Integer, _
                         ByRef out_ppidl As IntPtr, _
                         ByRef inout_pdwAttributes As Integer)

    '
    '        virtual HRESULT STDMETHODCALLTYPE EnumObjects( 
    '            /* [in] */ HWND hwnd,
    '            /* [in] */ SHCONTF grfFlags,
    '            /* [out] */ IEnumIDList **ppenumIDList) = 0;
    '
    Sub EnumObjects(ByVal in_hwnd As IntPtr, _
                    ByVal in_grfFlags As Integer, _
                    ByRef out_ppenumIDList As IEnumIDList)


    '        virtual HRESULT STDMETHODCALLTYPE BindToObject( 
    '            /* [in] */ LPCITEMIDLIST pidl,
    '            /* [in] */ LPBC pbc,
    '            /* [in] */ REFIID riid,
    '            /* [iid_is][out] */ void **ppv) = 0;
    '
    Sub BindToObject(ByVal in_pidl As IntPtr, _
                     ByVal in_pbc As IntPtr, _
                     ByRef in_riid As Guid, _
                     ByRef out_ppv As IShellFolder)

    ' DON'T CALL ME UNTIL I'M DEFINED !!!!!!
    '
    '        virtual HRESULT STDMETHODCALLTYPE BindToStorage( 
    '            /* [in] */ LPCITEMIDLIST pidl,
    '            /* [in] */ LPBC pbc,
    '            /* [in] */ REFIID riid,
    '            /* [iid_is][out] */ void **ppv) = 0;
    '
    Sub BindToStorage()

    ' DON'T CALL ME UNTIL I'M DEFINED !!!!!!
    '
    '        virtual HRESULT STDMETHODCALLTYPE CompareIDs( 
    '            /* [in] */ LPARAM lParam,
    '            /* [in] */ LPCITEMIDLIST pidl1,
    '            /* [in] */ LPCITEMIDLIST pidl2) = 0;
    '
    <PreserveSig()> _
    Function CompareIDs(ByVal in_lparam As IntPtr, _
                   ByVal in_pidl1 As IntPtr, _
                   ByVal in_pidl2 As IntPtr) _
                   As Integer

    ' DON'T CALL ME UNTIL I'M DEFINED !!!!!!
    '
    '        virtual HRESULT STDMETHODCALLTYPE CreateViewObject( 
    '            /* [in] */ HWND hwndOwner,
    '            /* [in] */ REFIID riid,
    '            /* [iid_is][out] */ void **ppv) = 0;
    '
    Sub CreateViewObject()


    ' DON'T CALL ME UNTIL I'M DEFINED !!!!!!
    '
    '        virtual HRESULT STDMETHODCALLTYPE GetAttributesOf( 
    '            /* [in] */ UINT cidl,
    '            /* [size_is][in] */ LPCITEMIDLIST *apidl,
    '            /* [out][in] */ SFGAOF *rgfInOut) = 0;
    '
    Sub GetAttributesOf( _
                            ByVal in_cidl As Integer, _
                            ByVal in_apidl As IntPtr, _
                            ByVal inout_rgfInOut As IntPtr)


    ' DON'T CALL ME UNTIL I'M DEFINED !!!!!!
    '
    '        virtual HRESULT STDMETHODCALLTYPE GetUIObjectOf( 
    '            /* [in] */ HWND hwndOwner,
    '            /* [in] */ UINT cidl,
    '            /* [size_is][in] */ LPCITEMIDLIST *apidl,
    '            /* [in] */ REFIID riid,
    '            /* [unique][out][in] */ UINT *rgfReserved,
    '            /* [iid_is][out] */ void **ppv) = 0;
    '
    Sub GetUIObjectOf()

    '
    '            virtual HRESULT STDMETHODCALLTYPE GetDisplayNameOf( 
    '            /* [in] */ LPCITEMIDLIST pidl,
    '            /* [in] */ SHGDNF uFlags,
    '            /* [out] */ STRRET *pName) = 0;
    '
    Sub GetDisplayNameOf(ByVal in_pidl As IntPtr, _
                         ByVal in_uFlags As Integer, _
                         ByVal in_pname As IntPtr)

    ' DON'T CALL ME UNTIL I'M DEFINED !!!!!!
    '
    '        virtual HRESULT STDMETHODCALLTYPE SetNameOf( 
    '            /* [in] */ HWND hwnd,
    '            /* [in] */ LPCITEMIDLIST pidl,
    '            /* [string][in] */ LPCOLESTR pszName,
    '            /* [in] */ SHGDNF uFlags,
    '            /* [out] */ LPITEMIDLIST *ppidlOut) = 0;
    '
    Sub SetNameOf()


End Interface ' IShellFolder

'=--------------------------------------------------------------------------=
' IEnumIDList
'=--------------------------------------------------------------------------=
' We need this to enumerate items in a particular folder.
'
'
<ComImport(), Guid("000214F2-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
Public Interface IEnumIDList

    '
    '        virtual HRESULT STDMETHODCALLTYPE Next( 
    '            /* [in] */ ULONG celt,
    '            /* [length_is][size_is][out] */ LPITEMIDLIST *rgelt,
    '            /* [out] */ ULONG *pceltFetched) = 0;
    '
    Function NextItem(ByVal in_celt As Integer, _
                 ByRef out_rgelt As IntPtr, _
                 ByRef out_pceltFetched As Integer) _
                 As Integer

    ' DON'T CALL ME UNTIL I'M DEFINED !!!!!!
    '
    '        virtual HRESULT STDMETHODCALLTYPE Skip( 
    '           /* [in] */ ULONG celt) = 0;
    '
    Sub Skip()

    '
    '        virtual HRESULT STDMETHODCALLTYPE Reset( void) = 0;
    '
    Sub Reset()

    '
    '        virtual HRESULT STDMETHODCALLTYPE Clone( 
    '            /* [out] */ IEnumIDList **ppenum) = 0;
    '
    Sub Clone(ByRef out_ppenum As IEnumIDList)


End Interface ' IEnumIDList

