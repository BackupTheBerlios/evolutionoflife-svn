'-------------------------------------------------------------------------------
'<copyright file="ImageButtonDesigner.vb" company="Microsoft">
'   Copyright (c) Microsoft Corporation. All rights reserved.
'</copyright>
'
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'-------------------------------------------------------------------------------

Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.ComponentModel


Namespace Design


    '=----------------------------------------------------------------------=
    ' ImageButtonDesigner
    '=----------------------------------------------------------------------=
    ' This class contains design time support for the ImageButton control.
    ' Basically, we need to be sure the Text property defaults to ""
    '
    '
    Public Class ImageButtonDesigner
        Inherits ControlDesigner


        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '                   Private Member Data/Types/etc
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=







        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '                      Public Properties/Methods
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=


        '=------------------------------------------------------------------=
        ' Initialize
        '=------------------------------------------------------------------=
        ' Initializes our designer and hooks up a few events.
        '
        '
        Public Overrides Sub Initialize(ByVal in_comp As IComponent)

            Dim iccs As IComponentChangeService

            MyBase.Initialize(in_comp)

            '
            ' We need to know when the component has changed.
            '
            iccs = CType(getService(GetType(IComponentChangeService)), _
                        IComponentChangeService)
            If Not iccs Is Nothing Then
                AddHandler iccs.ComponentChanged, AddressOf Me.OnComponentChanged
            End If


        End Sub ' Initialize


        '=------------------------------------------------------------------=
        ' SelectionRules
        '=------------------------------------------------------------------=
        ' We need to indicate the appropriate values for the size grips 
        ' depending on the value of the control's size mode.
        '
        Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules

            Get
                Dim ib As ImageButton
                ib = CType(Me.Control, ImageButton)
                If ib.SizeMode = ImageButtonSizeMode.AutoSize Then
                    Return MyBase.SelectionRules Xor SelectionRules.AllSizeable
                Else
                    Return MyBase.SelectionRules
                End If
            End Get

        End Property ' SelectionRules


        '=------------------------------------------------------------------=
        ' OnSetComponentDefaults
        '=------------------------------------------------------------------=
        ' Makes sure that our default Text property value is ""
        '
        Public Overrides Sub OnSetComponentDefaults()

            MyBase.OnSetComponentDefaults()
            Me.Control.Text = ""

        End Sub ' OnSetComponentDefaults







        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '              Protected/Private/Friend Methods/Props
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=


        '=------------------------------------------------------------------=
        ' Dispose
        '=------------------------------------------------------------------=
        ' Allows us to clean up some of our state.
        '
        Protected Overloads Overrides Sub Dispose(ByVal in_disposing As Boolean)

            Dim iccs As IComponentChangeService

            If in_disposing Then

                '
                ' Next, we want to unhook the ComponentChanged event.
                '
                iccs = CType(Me.GetService(GetType(IComponentChangeService)), _
                             IComponentChangeService)
                If Not iccs Is Nothing Then
                    RemoveHandler iccs.ComponentChanged, AddressOf Me.OnComponentChanged
                End If

            End If

            MyBase.Dispose(in_disposing)

        End Sub ' Dispose



        '=------------------------------------------------------------------=
        ' OnComponentChanged
        '=------------------------------------------------------------------=
        ' When the component changes, we want to see if the SizeMode property
        ' has changed.  In this case, we will update the size grips.
        '
        Private Sub OnComponentChanged(ByVal sender As Object, ByVal e As ComponentChangedEventArgs)

        End Sub ' OnComponentChanged


    End Class ' ImageButtonDesigner


End Namespace ' Design


