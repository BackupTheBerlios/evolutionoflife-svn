'-------------------------------------------------------------------------------
'<copyright file="TaskPaneDesigner.vb" company="Microsoft">
'   Copyright (c) Microsoft Corporation. All rights reserved.
'</copyright>
'
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'-------------------------------------------------------------------------------

Imports System.Windows.Forms.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing

Namespace Design


    '=----------------------------------------------------------------------=
    ' TaskPaneDesigner
    '=----------------------------------------------------------------------=
    ' This is the designer for the TaskPane control. 
    '
    '
    <System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, Flags:=System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Public Class TaskPaneDesigner
        Inherits ScrollableControlDesigner


        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '              Private Member Variables, Enums, etc.
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=

        '
        ' We'll need this for some hit testing we'll do ...
        '
        Declare Auto Function SendMessage Lib "user32.dll" (ByVal hwnd As System.IntPtr, _
                        ByVal msg As Integer, ByVal wparam As IntPtr, _
                        ByVal lparam As IntPtr) As Integer

        Private Const WM_NCHITTEST As Integer = &H84
        Private Const WM_VSCROLL As Integer = &H115
        Private Const HTVSCROLL As Integer = &H7

        '
        ' This is our collection of design-time verbs.
        '
        Private m_verbCollection As DesignerVerbCollection
        Private m_removeVerb As DesignerVerb

        Private m_disableDrawGrid As Boolean



        '
        ' This helps us track the last selected TaskFrame, so we can provide
        ' clues to the user for the "Remove" verb, etc ...
        '
        Private m_lastFrameSelected As TaskFrame





        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '                   Public Methods/Functions/Etc.
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=


        '=------------------------------------------------------------------=
        ' Initialize
        '=------------------------------------------------------------------=
        ' We're a new designer.  Go and initialize ourselves and set up some
        ' host pointers, as well as go and listen to some events ...
        '
        Public Overrides Sub Initialize(ByVal in_component As IComponent)

            Dim iccs As IComponentChangeService
            Dim selsvc As ISelectionService

            MyBase.Initialize(in_component)

            System.Diagnostics.Debug.Assert(TypeOf (Me.Control) Is TaskPane)

            '
            ' Add A selection change handler.
            '
            selsvc = CType(getservice(GetType(ISelectionService)), ISelectionService)
            If Not selsvc Is Nothing Then
                AddHandler selsvc.SelectionChanged, AddressOf Me.OnSelectionChanged
            End If

            '
            ' Next, we want to get the ComponentChanging and ComponentChanged
            ' event as well.
            '
            iccs = Me.GetService(GetType(IComponentChangeService))
            If Not iccs Is Nothing Then
                AddHandler iccs.ComponentChanging, AddressOf Me.OnComponentChanging
                AddHandler iccs.ComponentChanged, AddressOf Me.OnComponentChanged
            End If

            Me.m_disableDrawGrid = False

        End Sub ' Initialize


        '=------------------------------------------------------------------=
        ' Dispose
        '=------------------------------------------------------------------=
        ' Allows us to clean up some of our state.
        '
        Protected Overloads Overrides Sub Dispose(ByVal in_disposing As Boolean)

            Dim iccs As IComponentChangeService
            Dim selsvc As ISelectionService

            If in_disposing Then

                '
                ' Unhook the Selection changing service.
                '
                selsvc = CType(getservice(GetType(ISelectionService)), ISelectionService)
                If Not selsvc Is Nothing Then
                    RemoveHandler selsvc.SelectionChanged, AddressOf Me.OnSelectionChanged
                End If


                '
                ' Next, we want to unhook the ComponentChanging and 
                ' ComponentChanged event as well.
                '
                iccs = Me.GetService(GetType(IComponentChangeService))
                If Not iccs Is Nothing Then
                    RemoveHandler iccs.ComponentChanging, AddressOf Me.OnComponentChanging
                    RemoveHandler iccs.ComponentChanged, AddressOf Me.OnComponentChanged
                End If

            End If

            MyBase.Dispose(in_disposing)

        End Sub ' Dispose


        '=------------------------------------------------------------------=
        ' AssociatedComponents
        '=------------------------------------------------------------------=
        ' Indicates with which components we are associated so that various
        ' cut/copy/paste/undo/redo operation type things will work fine.
        '
        ' Type:
        '       ICollection
        '
        Public Overrides ReadOnly Property AssociatedComponents() As System.Collections.ICollection
            Get
                Dim tp As TaskPane
                tp = CType(Control, TaskPane)
                If Not tp Is Nothing Then
                    Return tp.TaskFrames
                Else
                    Return MyBase.AssociatedComponents
                End If
            End Get

        End Property ' AssociatedComponents


        '=------------------------------------------------------------------=
        ' Verbs
        '=------------------------------------------------------------------=
        ' Returns the list of verbs we support at DesignTime ...
        '
        Public Overrides ReadOnly Property Verbs() As DesignerVerbCollection

            Get
                If Me.m_verbCollection Is Nothing Then
                    Me.m_verbCollection = New DesignerVerbCollection
                    Me.m_removeVerb = New DesignerVerb(VbPowerPackMain.GetResourceManager().GetString("TaskPaneMiscRemove"), _
                                                       AddressOf Me.OnRemove)
                    Me.m_removeVerb.Enabled = False
                    Me.m_verbCollection.Add(New DesignerVerb(VbPowerPackMain.GetResourceManager().GetString("TaskPaneMiscAddNew"), _
                                                             New EventHandler(AddressOf Me.OnAdd)))
                    Me.m_verbCollection.Add(Me.m_removeVerb)
                End If

                Return Me.m_verbCollection
            End Get

        End Property ' Verbs


        '=------------------------------------------------------------------=
        ' CanParent
        '=------------------------------------------------------------------=
        ' 
        Public Overloads Overrides Function CanParent(ByVal in_control As Control) As Boolean

            If TypeOf (in_control) Is TaskFrame Then
                Return True
            Else
                Return False
            End If

        End Function ' CanParent









        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '         Private/Protected/Friend Methods/Functions/Etc.
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=


        '=------------------------------------------------------------------=
        ' DrawGrid
        '=------------------------------------------------------------------=
        ' We never support drawing a grid on this control at design time.
        '
        Protected Overrides Property DrawGrid() As Boolean

            Get
                If Me.m_disableDrawGrid Then
                    Return False
                End If
                Return MyBase.DrawGrid
            End Get

            Set(ByVal newDrawGrid As Boolean)

                MyBase.DrawGrid = newDrawGrid
            End Set

        End Property ' DrawGrid


        '=------------------------------------------------------------------=
        ' OnRemove
        '=------------------------------------------------------------------=
        ' The user has selected the "Remove" verb in the designer.  Go and
        ' remove the active TaskFrame.
        '
        Private Sub OnRemove(ByVal sender As Object, ByVal e As EventArgs)

            Dim dt As DesignerTransaction
            Dim md As MemberDescriptor
            Dim idh As IDesignerHost
            Dim tp As TaskPane

            '
            ' Make sure we have a task pane with some valid frames !!!
            '
            tp = CType(Me.Component, TaskPane)
            If tp Is Nothing OrElse Me.m_lastFrameSelected Is Nothing _
               OrElse Not tp.TaskFrames.Contains(Me.m_lastFrameSelected) Then
                Return
            End If

            md = TypeDescriptor.GetProperties(Me.Component)("Controls")

            '
            ' Get last selection taskframe.
            '
            '
            ' get the designer host
            '
            idh = Me.GetService(GetType(IDesignerHost))
            If Not idh Is Nothing Then

                Try
                    Try
                        dt = idh.CreateTransaction(VbPowerPackMain.GetResourceManager().GetString("TaskPaneMiscTransR"))
                        RaiseComponentChanging(md)
                    Catch ex As Exception
                        '
                        ' If this was cancelled, then that's cool.
                        '
                        If ex Is CheckoutException.Canceled Then
                            Return
                        End If
                        Throw ex
                    End Try

                    idh.DestroyComponent(Me.m_lastFrameSelected)
                    RaiseComponentChanged(md, Nothing, Nothing)
                    tp.Refresh()
                Finally
                    If Not dt Is Nothing Then dt.Commit()
                End Try

            End If

        End Sub ' OnRemove


        '=------------------------------------------------------------------=
        ' OnAdd
        '=------------------------------------------------------------------=
        ' The user has selected the 'Add' verb in the designer.  Go and 
        ' add a new TaskFrame to the TaskPane.  
        '
        Private Sub OnAdd(ByVal sender As Object, ByVal e As EventArgs)

            Dim dt As DesignerTransaction
            Dim pd As PropertyDescriptor
            Dim md As MemberDescriptor
            Dim idh As IDesignerHost
            Dim tf As TaskFrame
            Dim tp As TaskPane

            tp = CType(Me.Component, TaskPane)
            md = TypeDescriptor.GetProperties(Me.Component)("Controls")
            idh = Me.GetService(GetType(IDesignerHost))

            If Not idh Is Nothing Then
                Try
                    Try

                        dt = idh.CreateTransaction(VbPowerPackMain.GetResourceManager().GetString("TaskPaneMiscTransA"))
                        RaiseComponentChanging(md)

                    Catch ex As Exception

                        '
                        ' if it was cancelled, then we have no problem.
                        '
                        If ex Is CheckoutException.Canceled Then
                            Return
                        End If

                        '
                        ' otherwise, rethrow the exception.
                        '
                        Throw ex

                    End Try

                    '
                    ' create the new component, name it, and then add it.
                    '
                    tf = idh.CreateComponent(GetType(TaskFrame))

                    pd = TypeDescriptor.GetProperties(tf)("Name")
                    If Not pd Is Nothing And pd.PropertyType Is GetType(String) Then
                        tf.Text = pd.GetValue(tf)
                    End If

                    tp.Controls.Add(tf)

                    '
                    ' Finally, fire some more events...
                    '
                    RaiseComponentChanged(md, Nothing, Nothing)
                Finally
                    If Not dt Is Nothing Then
                        dt.Commit()
                    End If
                End Try
            End If

        End Sub ' OnAdd


        '=------------------------------------------------------------------=
        ' OnComponentChanging
        '=------------------------------------------------------------------=
        '
        Private Sub OnComponentChanging(ByVal sender As Object, ByVal e As ComponentChangingEventArgs)

            If e.Component Is Me.Component Then
                If Not e.Member Is Nothing Then
                    If e.Member.Name = "TaskFrames" Then

                        Dim pd As PropertyDescriptor
                        pd = TypeDescriptor.GetProperties(Me.Control)("Controls")

                        RaiseComponentChanging(pd)

                    End If
                End If
            End If

        End Sub ' OnComponentChanging



        '=------------------------------------------------------------------=
        ' OnComponentChanged
        '=------------------------------------------------------------------=
        '
        Private Sub OnComponentChanged(ByVal sender As Object, ByVal e As ComponentChangedEventArgs)

            If e.Component Is Me.Component Then
                If Not e.Member Is Nothing Then
                    If e.Member.Name = "TaskFrames" Then

                        Dim pd As PropertyDescriptor
                        pd = TypeDescriptor.GetProperties(Me.Control)("Controls")

                        RaiseComponentChanging(pd)

                    End If
                End If
            End If

            checkVerbStatus()

        End Sub ' OnComponentChanged



        '=------------------------------------------------------------------=
        ' OnSelectionChanged
        '=------------------------------------------------------------------=
        ' The ISelectionService tells us when the selection has changed. 
        ' We'll use this to help us track which TaskFrame was last selected
        ' by the user.
        '
        '
        Private Sub OnSelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim selsvc As ISelectionService
			selsvc = CType(GetService(GetType(ISelectionService)), ISelectionService)

			If Not selsvc Is Nothing Then

				Dim c As Object

				c = selsvc.PrimarySelection()

				If Not c Is Nothing And c.GetType.ToString = "VbPowerPack.FaskFrame" Then
					Dim tf As TaskFrame

					tf = CType(c, TaskFrame)

					If Not tf Is Nothing Then
						Me.m_lastFrameSelected = tf
						tf.Parent.Refresh()
					End If
				End If
			End If

            checkVerbStatus()
		End Sub	' OnSelectionChanged

        '=------------------------------------------------------------------=
        ' OnPaintAdornments
        '=------------------------------------------------------------------=
        ' We want to be sure that our child TaskFrames get their grid drawn
        ' correctly, but that we don't ...
        '
        '
        Protected Overrides Sub OnPaintAdornments(ByVal pe As PaintEventArgs)

            Dim tp As TaskPane
            Dim r As Rectangle
            Dim c As Color
            Dim p As Pen

            '
            ' Okay, we'll go and paint a highlight rect around the active
            ' task frame, if there is one.
            '
            tp = CType(Me.Control, TaskPane)
            If Not Me.m_lastFrameSelected Is Nothing _
               AndAlso tp.TaskFrames.Contains(Me.m_lastFrameSelected) Then

                c = MiscFunctions.FlipColour(tp.BackColor)
                r = tp.GetCompletRectForFrame(Me.m_lastFrameSelected)
                r.Inflate(2, 2)

                Try
                    p = New Pen(c, 2)
                    pe.Graphics.DrawRectangle(p, r)
                Finally
                    If Not p Is Nothing Then p.Dispose()
                End Try

            End If

            '
            ' Work around to get our child taskFrame 
            ' controls to actually draw their grid.  Otherwise, it 
            ' doesn't work quite right.
            '
            Try
                Me.m_disableDrawGrid = True
                MyBase.OnPaintAdornments(pe)
            Finally
                Me.m_disableDrawGrid = False
            End Try

        End Sub ' OnPaintAdornments


        '=------------------------------------------------------------------=
        ' getTaskFrameOfComponent
        '=------------------------------------------------------------------=
        ' Given some component, return the TaskFrame in which it lives, or
        ' null if it's not in a TaskFrame.
        '
        ' Returns:
        '       TaskFrame
        '
        Private Function getTaskFrameOfComponent(ByVal in_comp As Component) As TaskFrame

            Dim c As Control

            If Not TypeOf (in_comp) Is Control Then Return Nothing

            '
            ' Scoot our way up the parent chain until we find the TaskFrame
            ' or simply run out of parents ...
            '
            c = CType(in_comp, Control)
            While (Not c Is Nothing) And (Not TypeOf (c) Is TaskFrame)
                c = c.Parent
            End While

            Return CType(c, TaskFrame)

        End Function ' getTaskFrameOfComponent


        '=------------------------------------------------------------------=
        ' checkVerbStatus
        '=------------------------------------------------------------------=
        ' Figures out whether we should enable/disable the Remove TaskFrame
        ' verb.
        '
        Private Sub checkVerbStatus()

            Dim tp As TaskPane

            If Me.m_removeVerb Is Nothing Then Return

            '
            ' If there's a last frame active, make sure it's still valid.
            '
            If Not Me.m_lastFrameSelected Is Nothing Then
                tp = CType(Me.Control, TaskPane)
                If Not tp Is Nothing Then
                    If Not tp.TaskFrames.Contains(Me.m_lastFrameSelected) Then
                        Me.m_lastFrameSelected = Nothing
                    End If
                End If
            End If

            '
            ' Okay, if we've still got it, then go and enable the remove verb
            '
            If Not Me.m_lastFrameSelected Is Nothing Then
                Me.m_removeVerb.Enabled = True
            Else
                Me.m_removeVerb.Enabled = False
            End If

        End Sub ' checkVerbStatus


    End Class ' TaskPaneDesigner

End Namespace ' VbPowerPack.Design

