'-------------------------------------------------------------------------------
'<copyright file="VbPowerPackMain.vb" company="Microsoft">
'   Copyright (c) Microsoft Corporation. All rights reserved.
'</copyright>
'
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'-------------------------------------------------------------------------------

Imports System.Resources



'=--------------------------------------------------------------------------=
' VbPowerPackMain
'=--------------------------------------------------------------------------=
' A Module with methods and the like which we will use to manage globalisation
' and other aspects of using the controls at runtime.
'
Friend Module VbPowerPackMain

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                       Private data/types/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    Private s_resourceManager As ResourceManager

    '
    ' This is the resource manager for strictly design time descriptions
    '
    Private s_designResources As ResourceManager







    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                            Public Methods
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' GetResourceManager
    '=----------------------------------------------------------------------=
    ' Returns our resource manager, loading it the first time it is required.
    '
    ' Returns:
    '       ResourceManager
    '
    Public Function GetResourceManager() As ResourceManager

        '
        ' Load in the manager if necessary.
        '
        If s_resourceManager Is Nothing Then

            s_resourceManager = New ResourceManager("VbPowerPack.VbPowerPackResources", _
                                                    GetType(FileViewer).Assembly)

        End If

        Return s_resourceManager

    End Function ' GetResourceManager


    '=----------------------------------------------------------------------=
    ' GetDesignTimeResources
    '=----------------------------------------------------------------------=
    ' Returns our design time resource manager, loading it the first time it 
    'is required.
    '
    ' Returns:
    '       ResourceManager
    '
    Public Function GetDesignTimeResources() As ResourceManager

        '
        ' Load in the manager if necessary.
        '
        If s_designResources Is Nothing Then

            s_designResources = New ResourceManager("VbPowerPack.VBPPDesignResources", _
                                                    GetType(FileViewer).Assembly)

        End If

        Return s_designResources

    End Function ' GetDesignTimeResources



End Module ' VBPowerPackMain

