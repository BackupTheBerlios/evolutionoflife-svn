'-------------------------------------------------------------------------------
'<copyright file="UtilityToolBarDesigner.vb" company="Microsoft">
'   Copyright (c) Microsoft Corporation. All rights reserved.
'</copyright>
'
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'-------------------------------------------------------------------------------

Imports System.Runtime.InteropServices
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing


Namespace Design

    '=----------------------------------------------------------------------=
    ' UtilityToolBarDesigner
    '=----------------------------------------------------------------------=
    ' Contains some pretty nifty design time support for our UtilityToolBar
    ' control.
    '
    <System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, Flags:=System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Public Class UtilityToolBarDesigner
        Inherits ControlDesigner


        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '                     Private Types/Methods/Etc
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=

        '
        ' private little structure we'll use to represent a win32 POINT
        '
        <StructLayout(LayoutKind.Sequential)> _
        Private Structure Win32POINT

            Public x As Integer
            Public y As Integer

        End Structure ' Win32POINT

        Private Declare Auto Function SendMessage Lib "user32.dll" ( _
                                        ByVal in_hwnd As IntPtr, _
                                        ByVal in_msg As Integer, _
                                        ByVal in_wparam As Integer, _
                                        ByRef in_lparam As Win32POINT) _
                                        As Integer

        Private Const TB_HITTEST As Integer = &H445


        '
        ' This is the last button hovered over.
        '
        Private m_lastButton As Integer


        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '                   Public Methods/Properties/etc
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=


        '=------------------------------------------------------------------=
        ' Initialize
        '=------------------------------------------------------------------=
        ' Initializes our designer.  basically, we need to get component
        ' change notifications on the ToolBar, and see if we can help
        ' the win32 toolbar along in some tricky situations.
        '
        '
        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)

            Dim iccs As IComponentChangeService

            MyBase.Initialize(component)

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
        ' GetHitTest
        '=------------------------------------------------------------------=
        ' Gets whether the given point is within our bounds or not.  We 
        ' actually don't care, but just want to track what the current
        ' button the mouse is over is.
        '
        ' Parameters:
        '       Point           - [in]  point to check
        '
        ' Returns:
        '       Boolean         - False to indicate we don't want it!
        '
        Protected Overrides Function GetHitTest(ByVal in_point As Point) As Boolean

            Dim result As Integer
            Dim pp As Win32POINT
            Dim pt As Point

            pt = Control.PointToClient(in_point)
            pp.x = pt.X
            pp.y = pt.Y

            '
            ' Get the button index of the last button.  Negative means
            ' no button under the mouse.
            '
            result = SendMessage(Control.Handle, TB_HITTEST, 0, pp)
            Me.m_lastButton = result

            Return False

        End Function ' GetHitTest


        '=------------------------------------------------------------------=
        ' AssociatedComponents
        '=------------------------------------------------------------------=
        ' This is a property that lets us associate other 
        ' components on the form with us so that they are included in 
        ' Cut/Copy/Paste operations. 
        '
        ' Type:
        '       ICollection
        '
        Public Overrides ReadOnly Property AssociatedComponents() As ICollection

            Get
                Dim utb As UtilityToolBar
                utb = CType(Control, UtilityToolBar)
                If Not utb Is Nothing Then
                    Return utb.Buttons
                Else
                    Return MyBase.AssociatedComponents
                End If

            End Get

        End Property ' AssociatedComponents


        '=------------------------------------------------------------------=
        ' SelectionRules
        '=------------------------------------------------------------------=
        ' This helps us select the control at design time.  
        '
        ' Type:
        '       SelectionRules
        '
        Public Overrides ReadOnly Property SelectionRules() As SelectionRules

            Get
                Dim propDock, propAutoSize As PropertyDescriptor
                Dim rules As SelectionRules
                Dim comp As Object

                rules = MyBase.SelectionRules
                comp = Component

                propDock = TypeDescriptor.GetProperties(comp)("Dock")
                propAutoSize = TypeDescriptor.GetProperties(comp)("AutoSize")


                If Not propDock Is Nothing AndAlso Not propAutoSize Is Nothing Then

                    Dim dock As DockStyle
                    Dim autoSize As Boolean

                    dock = propDock.GetValue(comp)
                    autoSize = propAutoSize.GetValue(comp)
                    If autoSize Then

                        rules = rules And Not (SelectionRules.TopSizeable Or SelectionRules.BottomSizeable)
                        If Not dock = DockStyle.None Then
                            rules = rules And Not (SelectionRules.AllSizeable)
                        End If
                    End If
                End If

                Return rules

            End Get

        End Property ' SelectionRules


        '=------------------------------------------------------------------=
        ' DoDefaultAction
        '=------------------------------------------------------------------=
        ' We want to override the default code generation action so that
        ' we can generate code for the last button over which the user
        ' hovered the mouse.
        '
        Public Overrides Sub DoDefaultAction()

            Dim selectionService As ISelectionService
            Dim components As ICollection
            Dim eps As IEventBindingService
            Dim thisDefaultEvent As EventDescriptor
            Dim thisHandler As String
            Dim host As IDesignerHost
            Dim t As DesignerTransaction

            selectionService = GetService(GetType(ISelectionService))
            If selectionService Is Nothing Then Return

            components = selectionService.GetSelectedComponents()

            eps = getservice(GetType(IEventBindingService))
            host = getservice(GetType(IDesignerHost))

            Try

                For Each comp As Object In components
                    If TypeOf (comp) Is IComponent Then
                        Dim defaultEvent As EventDescriptor
                        Dim defaultPropEvent As PropertyDescriptor
                        Dim handler As String
                        Dim eventChanged As Boolean
                        Dim utb As UtilityToolBar
                        Dim eventName As String

                        If Me.m_lastButton >= 0 Then
                            utb = CType(Control, UtilityToolBar)
                            eventName = utb.findAppropriateEvent(Me.m_lastButton)
                            If Not (eventName Is Nothing) AndAlso Not (eventName = "") Then
                                Dim edc As EventDescriptorCollection
                                edc = TypeDescriptor.GetEvents(comp)
                                For Each ed As EventDescriptor In edc

                                    If ed.Name = eventName Then
                                        defaultEvent = ed
                                        Exit For
                                    End If
                                Next

                            End If
                        End If

                        If defaultEvent Is Nothing Then
                            defaultEvent = TypeDescriptor.GetDefaultEvent(comp)
                        End If

                        If Not defaultEvent Is Nothing Then

                            If Not eps Is Nothing Then
                                defaultPropEvent = eps.GetEventProperty(defaultEvent)
                            End If

                        End If

                        If Not defaultPropEvent Is Nothing AndAlso Not defaultPropEvent.IsReadOnly Then


                            Try
                                If Not host Is Nothing AndAlso t Is Nothing Then
                                    t = host.CreateTransaction("winky tinky spinky")
                                End If
                            Catch ex As CheckoutException
                                If ex Is CheckoutException.Canceled Then Return

                                Throw ex
                            End Try

                            handler = defaultPropEvent.GetValue(comp)

                            If handler Is Nothing Then
                                eventChanged = True
                                handler = eps.CreateUniqueMethodName(comp, defaultEvent)
                            Else
                                eventChanged = True
                                For Each compatibleMethod As String In eps.GetCompatibleMethods(defaultEvent)
                                    If handler = compatibleMethod Then Exit For
                                Next
                            End If


                            If eventChanged AndAlso Not (defaultPropEvent Is Nothing) Then
                                defaultPropEvent.SetValue(comp, handler)
                            End If

                            If Component Is comp Then
                                thisDefaultEvent = defaultEvent
                                thisHandler = handler
                            End If
                        End If

                    End If
                Next
            Finally
                If Not t Is Nothing Then
                    t.Commit()
                End If
            End Try

            If Not thisHandler Is Nothing AndAlso Not thisDefaultEvent Is Nothing Then
                eps.ShowCode(Component, thisDefaultEvent)
            End If

        End Sub ' DoDefaultAction








        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '              Private/Protected/Friend Methods/Subs/etc
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

            Dim utb As UtilityToolBar
            If TypeOf (e.Component) Is UtilityToolBar Then
                If (Not e.Member Is Nothing) AndAlso (e.Member.Name = "Buttons") Then

                    utb = CType(e.Component, UtilityToolBar)

                    'utb.setResizeHack()

                End If
            End If

        End Sub ' OnComponentChanged



    End Class ' UtilityToolBarDesigner


End Namespace ' Design
