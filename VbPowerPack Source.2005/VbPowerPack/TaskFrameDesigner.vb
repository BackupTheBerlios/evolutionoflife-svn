'-------------------------------------------------------------------------------
'<copyright file="TaskFrameDesigner.vb" company="Microsoft">
'   Copyright (c) Microsoft Corporation. All rights reserved.
'</copyright>
'
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'-------------------------------------------------------------------------------

Imports System.Windows.Forms.Design
Imports System.collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms


Namespace Design

    '=----------------------------------------------------------------------=
    ' TaskFrameDesigner
    '=----------------------------------------------------------------------=
    ' This class will provide most of the interesting design time 
    ' functionality for this control.
    '
    <System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, Flags:=System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Public Class TaskFrameDesigner
        Inherits System.Windows.Forms.Design.ScrollableControlDesigner




        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        ' Private member variables 
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=


        '
        ' shadowed visible property
        '
        Private m_visible As Boolean

        '
        ' Shadowed Isexpanded property
        '
        Private m_IsExpanded As Boolean






        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '                    Public Methods/Properties/etc.
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=




        '=------------------------------------------------------------------=
        ' Constructor
        '=------------------------------------------------------------------=
        ' Initializes an instance of this class for use.
        '
        Public Sub New()

            MyBase.New()
            Me.m_IsExpanded = True
            Me.m_visible = True

        End Sub ' New





        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '                Private/Protected/Friend Subs/Functions
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=



        '=------------------------------------------------------------------=
        ' Visible
        '=------------------------------------------------------------------=
        ' Shadows property which we will let users set and persist at design,
        ' but we don't actually want it happening until runtime!
        '
        ' Type:
        '       Boolean
        '
        Private Property Visible() As Boolean

            Get
                Return Me.m_visible
            End Get

            Set(ByVal in_newVisible As Boolean)
                Me.m_visible = in_newVisible
            End Set

        End Property ' Visible


        '=------------------------------------------------------------------=
        ' IsExpanded
        '=------------------------------------------------------------------=
        ' Shadowed property which will let users set and persist this for
        ' proper use at runtime ...
        ' 
        ' Type:
        '       Boolean
        '
        Private Property IsExpanded() As Boolean
            Get
                Return Me.m_IsExpanded
            End Get

            Set(ByVal in_newIsExpanded As Boolean)
                Me.m_IsExpanded = in_newIsExpanded
            End Set

        End Property ' IsExpanded

        '=------------------------------------------------------------------=
        ' CanBeParentedTo
        '=------------------------------------------------------------------=
        Public Overrides Function CanBeParentedTo(ByVal in_parentDesigner As IDesigner) As Boolean

            If TypeOf (in_parentDesigner) Is TaskPaneDesigner Then
                Return True
            Else
                Return False
            End If
        End Function ' CanBeParentedTo


        '=------------------------------------------------------------------=
        ' SelectionRules
        '=------------------------------------------------------------------=
        Public Overrides ReadOnly Property SelectionRules() As SelectionRules
            Get
                Dim sr As SelectionRules
                Dim ctl As Control

                sr = MyBase.SelectionRules
                ctl = Control

                If TypeOf (ctl.Parent) Is TaskPane Then
                    sr = sr And (Not SelectionRules.AllSizeable)
                End If

                Return sr
            End Get
        End Property ' SelectionRules


        '=------------------------------------------------------------------=
        ' PreFilterProperties
        '=------------------------------------------------------------------=
        ' We want to "Shadow" a few properties, most notably:
        '
        ' - IsExpanded
        ' - Visible
        '
        ' This stuff is incredibly complicated.
        '
        Protected Overrides Sub PreFilterProperties(ByVal in_properties As IDictionary)

            Dim propDesc As PropertyDescriptor
            Dim shadowProps() As String
            Dim empty() As Attribute

            shadowProps = New String() { _
                    "Visible", _
                    "IsExpanded" _
            }

            empty = New Attribute() {}

            For x As Integer = 0 To shadowProps.Length - 1

                propDesc = CType(in_properties(shadowProps(x)), PropertyDescriptor)
                If Not propDesc Is Nothing Then
                    in_properties(shadowProps(x)) = TypeDescriptor.CreateProperty(GetType(TaskFrameDesigner), propDesc, empty)
                End If
            Next

        End Sub ' PreFilterProperties

    End Class ' TaskFrameDesigner




End Namespace ' Design
