'-------------------------------------------------------------------------------
'<copyright file="UtilityToolBarShowText.vb" company="Microsoft">
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
' UtilityToolBarShowText
'=--------------------------------------------------------------------------=
' These are the possible values for the ShowText property on the 
' UtilityToolBar control.  They control if and where the text is shown for
' the buttons on it.
'
<LocalisableDescription("UtilityToolBarShowText")> _
Public Enum UtilityToolBarShowText

    <LocalisableDescription("UtilityToolBarShowText.ShowTextLabels")> _
    ShowTextLabels = 0

    <LocalisableDescription("UtilityToolBarShowText.ShowSelectiveLabels")> _
    ShowSelectiveLabels

    <LocalisableDescription("UtilityToolBarShowText.ShowNoLabels")> _
    ShowNoLabels

End Enum  ' UtilityToolBarShowText


