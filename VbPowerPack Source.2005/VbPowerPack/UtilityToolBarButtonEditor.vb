'-------------------------------------------------------------------------------
'<copyright file="UtilityToolBarButtonEditor.vb" company="Microsoft">
'   Copyright (c) Microsoft Corporation. All rights reserved.
'</copyright>
'
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'-------------------------------------------------------------------------------

Imports System.Windows.Forms
Imports System.Drawing.design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.ComponentModel
Imports System.Windows.Forms.Design


Namespace Design

    '=----------------------------------------------------------------------=
    ' UtilityToolBarButtonEditor
    '=----------------------------------------------------------------------=
    ' This is the editor we will use to let the programmer select the list of
    ' buttons available at design time.
    '
    '
    Public Class UtilityToolBarButtonEditor
        Inherits UITypeEditor


        '=------------------------------------------------------------------=
        ' GetEditStyle
        '=------------------------------------------------------------------=
        ' We use this method to indicate that we're going to be using a Modal
        ' Dialog to let us edit our values. 
        '
        Public Overloads Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As UITypeEditorEditStyle

            If Not (context Is Nothing) And Not (context.Instance Is Nothing) Then
                Return UITypeEditorEditStyle.Modal
            End If

            Return MyBase.GetEditStyle(context)

        End Function ' GetEditStyle


        '=------------------------------------------------------------------=
        ' EditValue
        '=------------------------------------------------------------------=
        ' We're being asked by the designer to edit the Buttons Value now.  Go
        ' ahead and show our dialog for doing just this !
        '
        ' 
        Public Overloads Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object

            Dim iconOptions As UtilityToolBarIconOptions
            Dim coll As ToolBar.ToolBarButtonCollection
            Dim showText As UtilityToolBarShowText
            Dim existing() As ToolBarButton
            Dim utb As UtilityToolBar
            Dim idh As IDesignerHost

            Dim resultsList() As UtilityToolBarCustomiseDialog.ListBoxButtonData
            Dim dr As DialogResult

            '
            ' 0. Arg casting and checking
            '
            coll = CType(value, ToolBar.ToolBarButtonCollection)
            If coll Is Nothing Then
                Throw New ArgumentException(VbPowerPackMain.GetResourceManager().GetString("excUTBInvalidButton"))
            End If

            '
            ' 1. Show the editor dialog to let the user select buttons.
            '
            dr = showCustomiseToolBarDialog(provider, coll, context.Instance, resultsList, iconOptions, showText)
            If dr = DialogResult.Cancel Then Return value

            '
            ' 2. Save out any options besides the buttons.
            '
            utb = CType(context.Instance, UtilityToolBar)
            If Not utb Is Nothing Then
                utb.IconOptions = iconOptions
                utb.ShowText = showText
            End If

            '
            ' 3. If they kept any of the existing buttons, we want to use
            '    the actual objects for them, in case the user renamed them
            '    or did anything else with them in the designer/code.  To 
            '    handle this, we'll get them all in an array.
            '
            existing = existingItemsAsArray(coll)

            '
            ' 4. Get a Designer interface for adding controls
            '
            idh = CType(context.GetService(GetType(IDesignerHost)), IDesignerHost)

            '
            ' 5. Now go and construct the new collection of buttons
            ' 
            constructButtonCollection(resultsList, existing, idh, coll)

            '
            ' 6. Just go and return this collection (value == coll)
            '
            utb.setResizeHack()
            Return value

        End Function ' EditValue


        '=------------------------------------------------------------------=
        ' showCustomiseToolBarDialog
        '=------------------------------------------------------------------=
        ' Shows the Customise ToolBar dialog.
        '
        ' Parameters:
        '       IServiceProvider        - [in]  where to get design time supp.
        '       ToolBarButtonCollection - [in]  initial set of values.
        '       ListBoxButtonItem ()    - [out] the array of items in the 
        '                                       result set.
        '       UtilityToolBarIconOptions - [out] icon opotions
        '       UtilityToolBarShowText  - [out] show text options
        '
        ' Returns:
        '       DialogResult            - how the user dismissed the dialog.
        '
        Private Function showCustomiseToolBarDialog( _
                                        ByVal in_provider As IServiceProvider, _
                                        ByVal in_coll As ToolBar.ToolBarButtonCollection, _
                                        ByVal in_ctl As UtilityToolBar, _
                                        ByRef out_resultsList() As UtilityToolBarCustomiseDialog.ListBoxButtonData, _
                                        ByRef out_iconOptions As UtilityToolBarIconOptions, _
                                        ByRef out_showText As UtilityToolBarShowText) _
                                        As DialogResult

            Dim iwfes As IWindowsFormsEditorService
            Dim cd As UtilityToolBarCustomiseDialog
            Dim dr As DialogResult
            Dim i As Integer

            '
            ' go to the host and get the service that will let us show a
            ' dialog ....
            '
            iwfes = CType(in_provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

            '
            ' create a new customise dialog, giving it the existing values,
            ' and then go and show it !!!
            '
            cd = New UtilityToolBarCustomiseDialog(in_coll, in_ctl)
            dr = iwfes.ShowDialog(cd)
            If dr = DialogResult.OK Then

                '
                ' create the array to hold them all
                '
                out_resultsList = New UtilityToolBarCustomiseDialog.ListBoxButtonData(cd.currentListBox.Items.Count() - 2) {}

                '
                ' now loop through copying all those that are valid and
                ' aren't our terminating separator
                '
                i = 0
                For Each x As Object In cd.currentListBox.Items
                    Dim lbbd As UtilityToolBarCustomiseDialog.ListBoxButtonData

                    lbbd = CType(x, UtilityToolBarCustomiseDialog.ListBoxButtonData)
                    If lbbd Is Nothing Then
                        System.Diagnostics.Debug.WriteLine("Bogus ListBox Item in Customise Dialog !!")
                    Else
                        '
                        ' if it's not the final place holder separator,
                        ' add it to the array.
                        '
                        If Not lbbd.m_imageIndex = -2 Then
                            out_resultsList(i) = lbbd
                            i += 1
                        End If
                    End If
                Next

                '
                ' Set up the other values
                '
                out_iconOptions = cd.iconOptionsCombo.SelectedIndex
                out_showText = cd.textOptionsCombo.SelectedIndex

            Else
                out_resultsList = Nothing
            End If

            Return dr

        End Function ' showCustomiseToolBarDialog


        '=------------------------------------------------------------------=
        ' existingItemsAsArray
        '=------------------------------------------------------------------=
        ' Returns the items in the given collection as an array.
        '
        ' Parameters:
        '       ToolBarButtonCollection - [in]  collection of buttons
        '
        ' Returns:
        '       UtilityToolBarButton()  - array of buttons.
        '
        Private Function existingItemsAsArray( _
                                ByVal in_coll As ToolBar.ToolBarButtonCollection) _
                                As UtilityToolBarButton()

            Dim existing() As UtilityToolBarButton
            Dim utbb As UtilityToolBarButton

            existing = New UtilityToolBarButton(in_coll.Count - 1) {}

            '
            ' for each button, get it in UtilityToolBarButton format
            ' and add it to our array.
            '
            For x As Integer = 0 To in_coll.Count - 1

                utbb = CType(in_coll(x), UtilityToolBarButton)

                existing(x) = utbb
            Next

            Return existing

        End Function ' existingItemsAsArray


        '=------------------------------------------------------------------=
        ' constructButtonCollection
        '=------------------------------------------------------------------=
        ' Given the list of things the user selected in the dialog, as well
        ' as the existing set of buttons, go and rebuild the collection
        ' of items that the user wants 
        '
        ' Parameters:
        '       ListBoxButtonData()         - [in]  the buttons the user wants
        '       ToolBarButton()             - [in]  existing buttons
        '       IDesignerHost               - [in]  how they're added at 
        '                                           design time.
        '       ToolBarButtonCollection     - [in]  the actual collection to
        '                                           modify.
        '
        Private Sub constructButtonCollection( _
                                    ByVal in_resultsList() As UtilityToolBarCustomiseDialog.ListBoxButtonData, _
                                    ByVal in_existing() As ToolBarButton, _
                                    ByVal in_idh As IDesignerHost, _
                                    ByVal in_coll As ToolBar.ToolBarButtonCollection)

            Dim lbbd As UtilityToolBarCustomiseDialog.ListBoxButtonData
            Dim x As Integer


            '
            ' First things first, clear the existing collection of its 
            ' values
            '
            destroyExistingCollection(in_idh, in_coll, in_resultsList)

            '
            ' Now, for each item the user wants, go and see if it's a button
            ' or a separator, and add as appropriate, using existing buttons
            ' where they exist!
            '
            For x = 0 To in_resultsList.Length - 1

                lbbd = in_resultsList(x)

                '
                ' First, see if it's an existing button
                '
                If arrayContainsButton(in_existing, lbbd.m_button) Then

                    '
                    ' exists already.  Just go and add it to the collection.
                    ' The button is already properly sited, etc ...
                    '
                    in_coll.Add(lbbd.m_button)

                Else

                    '
                    ' This button doesn't exist already, so go and create
                    ' and add/site it.
                    '

                    '
                    ' Is it a separator, or a button type?
                    '
                    If lbbd.m_imageIndex = -1 Then

                        '
                        ' separator
                        '
                        createAndAddSeparator(in_idh, in_coll)

                    Else

                        '
                        ' Regular ole' button
                        '
                        createAndAddButton(lbbd.m_imageIndex, in_idh, in_coll)

                    End If

                End If

            Next

        End Sub ' constructButtonCollection


        '=------------------------------------------------------------------=
        ' createAndAddSeparator
        '=------------------------------------------------------------------=
        ' Goes and creates a new toolbar separator button, and then adds it
        ' to the control, going through all the design time mechanisms to
        ' ensure it's sited and has a member variable, etc ...
        '
        ' Parameters:
        '       IDesignerHost           - [in]  how to create it
        '       ToolBarButtonCollection - [in]  where to add it.
        '
        Private Sub createAndAddSeparator(ByVal in_idh As IDesignerHost, _
                                          ByVal in_coll As ToolBar.ToolBarButtonCollection)

            Dim utb As UtilityToolBarButton
            Dim id As IDesigner

            '
            ' create the new component and set it to be
            ' a separator
            '
            utb = in_idh.CreateComponent(GetType(UtilityToolBarButton), Nothing)
            utb.Style = ToolBarButtonStyle.Separator

            '
            ' now initialize it in the designer
            '
            id = in_idh.GetDesigner(utb)
            If Not id Is Nothing And TypeOf (id) Is ComponentDesigner Then
                CType(id, ComponentDesigner).OnSetComponentDefaults()
            End If

            '
            ' Finally, add it to the collection
            '
            in_coll.Add(utb)

        End Sub ' createAndAddSeparator


        '=------------------------------------------------------------------=
        ' createAndAddButton
        '=------------------------------------------------------------------=
        ' Given the type for a new button, go and create and then add this
        ' new button using appropriate means at design time, etc ...
        '
        ' Parameters:
        '       UtilityToolBarButtonType - [in]  what type of button ??
        '       IDesignerHost            - [in]  how to create it
        '       ToolBarButtonCollection  - [in]  where to add it.
        '
        Private Sub createAndAddButton(ByVal in_type As UtilityToolBarButtonType, _
                                       ByVal in_idh As IDesignerHost, _
                                       ByVal in_coll As ToolBar.ToolBarButtonCollection)

            Dim utb As UtilityToolBarButton
            Dim id As IDesigner
            Dim t As Type

            '
            ' First, we need the type of button to create
            '
            t = getTypeObjectOfButtonType(in_type)
            If t Is Nothing Then
                System.Diagnostics.Debug.Fail("Bogus Button Type Requested in Customise Dialog !!")
                Return
            End If

            '
            ' Now go and create the component via the designer to site and 
            ' name it, etc ...
            '
            utb = in_idh.CreateComponent(t)

            '
            ' now initialize it in the designer
            '
            id = in_idh.GetDesigner(utb)
            If Not id Is Nothing And TypeOf (id) Is ComponentDesigner Then
                CType(id, ComponentDesigner).OnSetComponentDefaults()
            End If

            '
            ' Finally, add it to the collection
            '
            in_coll.Add(utb)


        End Sub ' createAndAddButton


        '=------------------------------------------------------------------=
        ' arrayContainsButton
        '=------------------------------------------------------------------=
        ' Does the given array of UtilityToolBarButtons contain the given
        ' button???
        '
        ' Parameters:
        '       UtilityToolBarButton()      - [in]  array in which to search
        '       UtilityToolBarButton        - [in]  find me please
        '
        ' Returns:
        '       Boolean                     - True = contains it, False nope
        '
        Private Function arrayContainsButton( _
                                ByVal in_buttonArray() As UtilityToolBarButton, _
                                ByVal in_button As UtilityToolBarButton) _
                                As Boolean

            '
            ' If the button itself is empty, do nothing.
            '
            If in_button Is Nothing Then Return False

            '
            ' Otherwise, go and look through all of them
            '
            For Each x As UtilityToolBarButton In in_buttonArray
                If x Is in_button Then Return True
            Next

            '
            ' We did not find it.
            '
            Return False

        End Function ' arrayContainsButton


        '=------------------------------------------------------------------=
        ' destroyExistingCollection
        '=------------------------------------------------------------------=
        ' Unfortunately, we have to destroy the existing collection of 
        ' buttons by removing them from the code generator.  Not terribly
        ' compliated.
        '
        ' Parameters:
        '       IDesingerHost            - [in]  how we remove them from codegen
        '       ToolBarButtonCollection  - [in]  remove me please.
        '       ListBoxButtonData        - [in]  the new set of buttons to use
        '
        Private Sub destroyExistingCollection(ByVal in_idh As IDesignerHost, _
                                              ByVal in_coll As ToolBar.ToolBarButtonCollection, _
                                              ByVal in_resultsList() As UtilityToolBarCustomiseDialog.ListBoxButtonData)

            Dim lbbd As UtilityToolBarCustomiseDialog.ListBoxButtonData
            Dim utb As UtilityToolBarButton
            Dim found As Boolean

            '
            ' For each item in the collection, if it's not in the results 
            ' list, then go and destroy it. To delete item in a collection, go backward.
            '
            Dim index As Integer
            For index = in_coll.Count - 1 To 0 Step -1

                utb = CType(in_coll.Item(index), UtilityToolBarButton)
                If Not utb Is Nothing Then

                    found = False

                    For Each lbbd In in_resultsList
                        If lbbd.m_button Is utb Then
                            found = True
                            Exit For
                        End If
                    Next

                    '
                    ' Destroy it if it's no longer to be with us.
                    '
                    If Not found Then
                        in_idh.DestroyComponent(utb)
                    End If

                End If
            Next

            '
            ' Finally, clear out the collection.
            '
            in_coll.Clear()

        End Sub ' destroyExistingCollection



        '=------------------------------------------------------------------=
        ' getTypeObjectOfButtonType
        '=------------------------------------------------------------------=
        ' Given the enum type of a button, go and get the .NET Type object for
        ' this type.
        '
        ' Parameters:
        '       UtilityToolBarButtonType    - [in]  type of button
        '
        ' Returns:
        '       Type                        -
        '
        Private Function getTypeObjectOfButtonType(ByVal in_type As UtilityToolBarButtonType) As Type

            Select Case in_type

                Case UtilityToolBarButtonType.BackUtilityButton
                    Return GetType(BackUtilityButton)

                Case UtilityToolBarButtonType.ForwardUtilityButton
                    Return GetType(ForwardUtilityButton)

                Case UtilityToolBarButtonType.UpUtilityButton
                    Return GetType(UpUtilityButton)

                Case UtilityToolBarButtonType.SearchUtilityButton
                    Return GetType(SearchUtilityButton)

                Case UtilityToolBarButtonType.FoldersUtilityButton
                    Return GetType(FoldersUtilityButton)

                Case UtilityToolBarButtonType.ViewsUtilityButton
                    Return GetType(ViewsUtilityButton)

                Case UtilityToolBarButtonType.StopUtilityButton
                    Return GetType(StopUtilityButton)

                Case UtilityToolBarButtonType.RefreshUtilityButton
                    Return GetType(RefreshUtilityButton)

                Case UtilityToolBarButtonType.HomeUtilityButton
                    Return GetType(HomeUtilityButton)

                Case UtilityToolBarButtonType.MapDriveUtilityButton
                    Return GetType(MapDriveUtilityButton)

                Case UtilityToolBarButtonType.DisconnectUtilityButton
                    Return GetType(DisconnectUtilityButton)

                Case UtilityToolBarButtonType.FavoritesUtilityButton
                    Return GetType(FavoritesUtilityButton)

                Case UtilityToolBarButtonType.HistoryUtilityButton
                    Return GetType(HistoryUtilityButton)

                Case UtilityToolBarButtonType.FullScreenUtilityButton
                    Return GetType(FullScreenUtilityButton)

                Case UtilityToolBarButtonType.MoveToUtilityButton
                    Return GetType(MoveToUtilityButton)

                Case UtilityToolBarButtonType.CopyToUtilityButton
                    Return GetType(CopyToUtilityButton)

                Case UtilityToolBarButtonType.DeleteUtilityButton
                    Return GetType(DeleteUtilityButton)

                Case UtilityToolBarButtonType.UndoUtilityButton
                    Return GetType(UndoUtilityButton)

                Case UtilityToolBarButtonType.PropertiesUtilityButton
                    Return GetType(PropertiesUtilityButton)

                Case UtilityToolBarButtonType.CutUtilityButton
                    Return GetType(CutUtilityButton)

                Case UtilityToolBarButtonType.CopyUtilityButton
                    Return GetType(CopyUtilityButton)

                Case UtilityToolBarButtonType.PasteUtilityButton
                    Return GetType(PasteUtilityButton)

                Case UtilityToolBarButtonType.FolderOptionsUtilityButton
                    Return GetType(FolderOptionsUtilityButton)

                Case UtilityToolBarButtonType.MailUtilityButton
                    Return GetType(MailUtilityButton)

                Case UtilityToolBarButtonType.PrintUtilityButton
                    Return GetType(PrintUtilityButton)

                Case UtilityToolBarButtonType.SaveUtilityButton
                    Return GetType(SaveUtilityButton)

                Case UtilityToolBarButtonType.LoadUtilityButton
                    Return GetType(LoadUtilityButton)

                Case UtilityToolBarButtonType.SaveAllUtilityButton
                    Return GetType(SaveAllUtilityButton)

                Case UtilityToolBarButtonType.PrintPreviewUtilityButton
                    Return GetType(PrintPreviewUtilityButton)

                Case Else
                    Return Nothing

            End Select ' in_type

        End Function ' getTypeObjectOfButtonType

    End Class ' UtilityToolBarButtonEditor


End Namespace ' Design

