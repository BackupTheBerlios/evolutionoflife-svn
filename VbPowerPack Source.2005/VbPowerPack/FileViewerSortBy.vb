'-------------------------------------------------------------------------------
'<copyright file="FileViewerSortBy.vb" company="Microsoft">
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
' FileViewerSortBy
'=--------------------------------------------------------------------------=
<LocalisableDescription("FileViewerSortBy")> _
Public Enum FileViewerSortBy

    <LocalisableDescription("FileViewerSortBy.None")> _
    None

    <LocalisableDescription("FileViewerSortBy.Name")> _
    Name

    <LocalisableDescription("FileViewerSortBy.Size")> _
    Size

    <LocalisableDescription("FileViewerSortBy.Type")> _
    Type

    <LocalisableDescription("FileViewerSortBy.ModifiedTime")> _
    ModifiedTime

End Enum ' FileViewerSortBy
