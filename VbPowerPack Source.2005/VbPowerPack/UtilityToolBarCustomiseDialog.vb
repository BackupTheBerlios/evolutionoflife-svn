'-------------------------------------------------------------------------------
'<copyright file="UtilityToolBarCustomiseDialog.vb" company="Microsoft">
'   Copyright (c) Microsoft Corporation. All rights reserved.
'</copyright>
'
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'-------------------------------------------------------------------------------

Imports System.Windows.Forms
Imports System.Drawing


'=--------------------------------------------------------------------------=
' UtilityToolBarCustomiseDialog
'=--------------------------------------------------------------------------=
' This dialog is used both at design time and run time to let users customise
' the UtilityToolBar control, by letting them select the buttons that are
' used ...
'
'
Public Class UtilityToolBarCustomiseDialog
    Inherits System.Windows.Forms.Form

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                          Private Data
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '
    ' Where to get the images for the list boxes ...
    '
    Private m_imageList As ImageList

    '
    ' The collection of buttons we got in the constructor ..
    '
    Private m_collection As ToolBar.ToolBarButtonCollection

    '
    ' The control with which we are working
    '
    Private m_toolBar As UtilityToolBar

    '
    ' Mask of available buttons
    '
    Private m_buttonMask As Integer

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal in_coll As ToolBar.ToolBarButtonCollection, _
                   ByVal in_ctl As UtilityToolBar, _
                   Optional ByVal in_mask As Integer = &HFFFFFFFF)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call


        Me.m_collection = in_coll
        Me.m_buttonMask = in_mask
        Me.m_toolBar = in_ctl


        '
        ' Make sure we're centred in the screen.
        '
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen

        '
        ' Now, go and get the image list of items we need.
        '
        Me.m_imageList = New ImageList
        Me.m_imageList.ImageSize = New Size(16, 16)
        Me.m_imageList.ColorDepth = ColorDepth.Depth24Bit
        Me.m_imageList.TransparentColor = Color.Cyan
        Me.m_imageList.Images.AddStrip(New Bitmap(GetType(UtilityToolBarCustomiseDialog), "UtilityToolBarImages.bmp"))

        '
        ' Populate the list boxes with the items, as appropriate
        ' 
        populateAvailableListBox(Me.availableListBox, in_coll, in_mask)
        populateCurrentListBox(Me.currentListBox, in_coll)

        '
        ' Populate the two combo boxes with their enumeration values.
        '
        fillTextOptionsCombo(in_ctl)
        fillIconOptionsCombo(in_ctl)

    End Sub ' New

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents availableLabel As System.Windows.Forms.Label
    Friend WithEvents currentLabel As System.Windows.Forms.Label
    Friend WithEvents resetButton As System.Windows.Forms.Button
    Friend WithEvents moveDownButton As System.Windows.Forms.Button
    Friend WithEvents moveUpButton As System.Windows.Forms.Button
    Friend WithEvents addButton As System.Windows.Forms.Button
    Friend WithEvents removeButton As System.Windows.Forms.Button
    Friend WithEvents textOptionsLabel As System.Windows.Forms.Label
    Friend WithEvents iconOptionsLabel As System.Windows.Forms.Label
    Friend WithEvents textOptionsCombo As System.Windows.Forms.ComboBox
    Friend WithEvents iconOptionsCombo As System.Windows.Forms.ComboBox
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents availableListBox As System.Windows.Forms.ListBox
    Friend WithEvents currentListBox As System.Windows.Forms.ListBox
    Friend WithEvents localCancelButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UtilityToolBarCustomiseDialog))
        Me.availableLabel = New System.Windows.Forms.Label
        Me.currentLabel = New System.Windows.Forms.Label
        Me.resetButton = New System.Windows.Forms.Button
        Me.moveDownButton = New System.Windows.Forms.Button
        Me.moveUpButton = New System.Windows.Forms.Button
        Me.addButton = New System.Windows.Forms.Button
        Me.removeButton = New System.Windows.Forms.Button
        Me.textOptionsLabel = New System.Windows.Forms.Label
        Me.iconOptionsLabel = New System.Windows.Forms.Label
        Me.textOptionsCombo = New System.Windows.Forms.ComboBox
        Me.iconOptionsCombo = New System.Windows.Forms.ComboBox
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        Me.closeButton = New System.Windows.Forms.Button
        Me.availableListBox = New System.Windows.Forms.ListBox
        Me.currentListBox = New System.Windows.Forms.ListBox
        Me.localCancelButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'availableLabel
        '
        Me.availableLabel.AccessibleDescription = resources.GetString("availableLabel.AccessibleDescription")
        Me.availableLabel.AccessibleName = resources.GetString("availableLabel.AccessibleName")
        Me.availableLabel.Anchor = CType(resources.GetObject("availableLabel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.availableLabel.AutoSize = CType(resources.GetObject("availableLabel.AutoSize"), Boolean)
        Me.availableLabel.Dock = CType(resources.GetObject("availableLabel.Dock"), System.Windows.Forms.DockStyle)
        Me.availableLabel.Enabled = CType(resources.GetObject("availableLabel.Enabled"), Boolean)
        Me.availableLabel.Font = CType(resources.GetObject("availableLabel.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.availableLabel, resources.GetString("availableLabel.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.availableLabel, CType(resources.GetObject("availableLabel.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.availableLabel, resources.GetString("availableLabel.HelpString"))
        Me.availableLabel.Image = CType(resources.GetObject("availableLabel.Image"), System.Drawing.Image)
        Me.availableLabel.ImageAlign = CType(resources.GetObject("availableLabel.ImageAlign"), System.Drawing.ContentAlignment)
        Me.availableLabel.ImageIndex = CType(resources.GetObject("availableLabel.ImageIndex"), Integer)
        Me.availableLabel.ImeMode = CType(resources.GetObject("availableLabel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.availableLabel.Location = CType(resources.GetObject("availableLabel.Location"), System.Drawing.Point)
        Me.availableLabel.Name = "availableLabel"
        Me.availableLabel.RightToLeft = CType(resources.GetObject("availableLabel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.availableLabel, CType(resources.GetObject("availableLabel.ShowHelp"), Boolean))
        Me.availableLabel.Size = CType(resources.GetObject("availableLabel.Size"), System.Drawing.Size)
        Me.availableLabel.TabIndex = CType(resources.GetObject("availableLabel.TabIndex"), Integer)
        Me.availableLabel.Text = resources.GetString("availableLabel.Text")
        Me.availableLabel.TextAlign = CType(resources.GetObject("availableLabel.TextAlign"), System.Drawing.ContentAlignment)
        Me.availableLabel.Visible = CType(resources.GetObject("availableLabel.Visible"), Boolean)
        '
        'currentLabel
        '
        Me.currentLabel.AccessibleDescription = resources.GetString("currentLabel.AccessibleDescription")
        Me.currentLabel.AccessibleName = resources.GetString("currentLabel.AccessibleName")
        Me.currentLabel.Anchor = CType(resources.GetObject("currentLabel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.currentLabel.AutoSize = CType(resources.GetObject("currentLabel.AutoSize"), Boolean)
        Me.currentLabel.Dock = CType(resources.GetObject("currentLabel.Dock"), System.Windows.Forms.DockStyle)
        Me.currentLabel.Enabled = CType(resources.GetObject("currentLabel.Enabled"), Boolean)
        Me.currentLabel.Font = CType(resources.GetObject("currentLabel.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.currentLabel, resources.GetString("currentLabel.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.currentLabel, CType(resources.GetObject("currentLabel.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.currentLabel, resources.GetString("currentLabel.HelpString"))
        Me.currentLabel.Image = CType(resources.GetObject("currentLabel.Image"), System.Drawing.Image)
        Me.currentLabel.ImageAlign = CType(resources.GetObject("currentLabel.ImageAlign"), System.Drawing.ContentAlignment)
        Me.currentLabel.ImageIndex = CType(resources.GetObject("currentLabel.ImageIndex"), Integer)
        Me.currentLabel.ImeMode = CType(resources.GetObject("currentLabel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.currentLabel.Location = CType(resources.GetObject("currentLabel.Location"), System.Drawing.Point)
        Me.currentLabel.Name = "currentLabel"
        Me.currentLabel.RightToLeft = CType(resources.GetObject("currentLabel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.currentLabel, CType(resources.GetObject("currentLabel.ShowHelp"), Boolean))
        Me.currentLabel.Size = CType(resources.GetObject("currentLabel.Size"), System.Drawing.Size)
        Me.currentLabel.TabIndex = CType(resources.GetObject("currentLabel.TabIndex"), Integer)
        Me.currentLabel.Text = resources.GetString("currentLabel.Text")
        Me.currentLabel.TextAlign = CType(resources.GetObject("currentLabel.TextAlign"), System.Drawing.ContentAlignment)
        Me.currentLabel.Visible = CType(resources.GetObject("currentLabel.Visible"), Boolean)
        '
        'resetButton
        '
        Me.resetButton.AccessibleDescription = resources.GetString("resetButton.AccessibleDescription")
        Me.resetButton.AccessibleName = resources.GetString("resetButton.AccessibleName")
        Me.resetButton.Anchor = CType(resources.GetObject("resetButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.resetButton.BackgroundImage = CType(resources.GetObject("resetButton.BackgroundImage"), System.Drawing.Image)
        Me.resetButton.Dock = CType(resources.GetObject("resetButton.Dock"), System.Windows.Forms.DockStyle)
        Me.resetButton.Enabled = CType(resources.GetObject("resetButton.Enabled"), Boolean)
        Me.resetButton.FlatStyle = CType(resources.GetObject("resetButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.resetButton.Font = CType(resources.GetObject("resetButton.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.resetButton, resources.GetString("resetButton.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.resetButton, CType(resources.GetObject("resetButton.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.resetButton, resources.GetString("resetButton.HelpString"))
        Me.resetButton.Image = CType(resources.GetObject("resetButton.Image"), System.Drawing.Image)
        Me.resetButton.ImageAlign = CType(resources.GetObject("resetButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.resetButton.ImageIndex = CType(resources.GetObject("resetButton.ImageIndex"), Integer)
        Me.resetButton.ImeMode = CType(resources.GetObject("resetButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.resetButton.Location = CType(resources.GetObject("resetButton.Location"), System.Drawing.Point)
        Me.resetButton.Name = "resetButton"
        Me.resetButton.RightToLeft = CType(resources.GetObject("resetButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.resetButton, CType(resources.GetObject("resetButton.ShowHelp"), Boolean))
        Me.resetButton.Size = CType(resources.GetObject("resetButton.Size"), System.Drawing.Size)
        Me.resetButton.TabIndex = CType(resources.GetObject("resetButton.TabIndex"), Integer)
        Me.resetButton.Text = resources.GetString("resetButton.Text")
        Me.resetButton.TextAlign = CType(resources.GetObject("resetButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.resetButton.Visible = CType(resources.GetObject("resetButton.Visible"), Boolean)
        '
        'moveDownButton
        '
        Me.moveDownButton.AccessibleDescription = resources.GetString("moveDownButton.AccessibleDescription")
        Me.moveDownButton.AccessibleName = resources.GetString("moveDownButton.AccessibleName")
        Me.moveDownButton.Anchor = CType(resources.GetObject("moveDownButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.moveDownButton.BackgroundImage = CType(resources.GetObject("moveDownButton.BackgroundImage"), System.Drawing.Image)
        Me.moveDownButton.Dock = CType(resources.GetObject("moveDownButton.Dock"), System.Windows.Forms.DockStyle)
        Me.moveDownButton.Enabled = CType(resources.GetObject("moveDownButton.Enabled"), Boolean)
        Me.moveDownButton.FlatStyle = CType(resources.GetObject("moveDownButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.moveDownButton.Font = CType(resources.GetObject("moveDownButton.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.moveDownButton, resources.GetString("moveDownButton.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.moveDownButton, CType(resources.GetObject("moveDownButton.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.moveDownButton, resources.GetString("moveDownButton.HelpString"))
        Me.moveDownButton.Image = CType(resources.GetObject("moveDownButton.Image"), System.Drawing.Image)
        Me.moveDownButton.ImageAlign = CType(resources.GetObject("moveDownButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.moveDownButton.ImageIndex = CType(resources.GetObject("moveDownButton.ImageIndex"), Integer)
        Me.moveDownButton.ImeMode = CType(resources.GetObject("moveDownButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.moveDownButton.Location = CType(resources.GetObject("moveDownButton.Location"), System.Drawing.Point)
        Me.moveDownButton.Name = "moveDownButton"
        Me.moveDownButton.RightToLeft = CType(resources.GetObject("moveDownButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.moveDownButton, CType(resources.GetObject("moveDownButton.ShowHelp"), Boolean))
        Me.moveDownButton.Size = CType(resources.GetObject("moveDownButton.Size"), System.Drawing.Size)
        Me.moveDownButton.TabIndex = CType(resources.GetObject("moveDownButton.TabIndex"), Integer)
        Me.moveDownButton.Text = resources.GetString("moveDownButton.Text")
        Me.moveDownButton.TextAlign = CType(resources.GetObject("moveDownButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.moveDownButton.Visible = CType(resources.GetObject("moveDownButton.Visible"), Boolean)
        '
        'moveUpButton
        '
        Me.moveUpButton.AccessibleDescription = resources.GetString("moveUpButton.AccessibleDescription")
        Me.moveUpButton.AccessibleName = resources.GetString("moveUpButton.AccessibleName")
        Me.moveUpButton.Anchor = CType(resources.GetObject("moveUpButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.moveUpButton.BackgroundImage = CType(resources.GetObject("moveUpButton.BackgroundImage"), System.Drawing.Image)
        Me.moveUpButton.Dock = CType(resources.GetObject("moveUpButton.Dock"), System.Windows.Forms.DockStyle)
        Me.moveUpButton.Enabled = CType(resources.GetObject("moveUpButton.Enabled"), Boolean)
        Me.moveUpButton.FlatStyle = CType(resources.GetObject("moveUpButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.moveUpButton.Font = CType(resources.GetObject("moveUpButton.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.moveUpButton, resources.GetString("moveUpButton.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.moveUpButton, CType(resources.GetObject("moveUpButton.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.moveUpButton, resources.GetString("moveUpButton.HelpString"))
        Me.moveUpButton.Image = CType(resources.GetObject("moveUpButton.Image"), System.Drawing.Image)
        Me.moveUpButton.ImageAlign = CType(resources.GetObject("moveUpButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.moveUpButton.ImageIndex = CType(resources.GetObject("moveUpButton.ImageIndex"), Integer)
        Me.moveUpButton.ImeMode = CType(resources.GetObject("moveUpButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.moveUpButton.Location = CType(resources.GetObject("moveUpButton.Location"), System.Drawing.Point)
        Me.moveUpButton.Name = "moveUpButton"
        Me.moveUpButton.RightToLeft = CType(resources.GetObject("moveUpButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.moveUpButton, CType(resources.GetObject("moveUpButton.ShowHelp"), Boolean))
        Me.moveUpButton.Size = CType(resources.GetObject("moveUpButton.Size"), System.Drawing.Size)
        Me.moveUpButton.TabIndex = CType(resources.GetObject("moveUpButton.TabIndex"), Integer)
        Me.moveUpButton.Text = resources.GetString("moveUpButton.Text")
        Me.moveUpButton.TextAlign = CType(resources.GetObject("moveUpButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.moveUpButton.Visible = CType(resources.GetObject("moveUpButton.Visible"), Boolean)
        '
        'addButton
        '
        Me.addButton.AccessibleDescription = resources.GetString("addButton.AccessibleDescription")
        Me.addButton.AccessibleName = resources.GetString("addButton.AccessibleName")
        Me.addButton.Anchor = CType(resources.GetObject("addButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.addButton.BackgroundImage = CType(resources.GetObject("addButton.BackgroundImage"), System.Drawing.Image)
        Me.addButton.Dock = CType(resources.GetObject("addButton.Dock"), System.Windows.Forms.DockStyle)
        Me.addButton.Enabled = CType(resources.GetObject("addButton.Enabled"), Boolean)
        Me.addButton.FlatStyle = CType(resources.GetObject("addButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.addButton.Font = CType(resources.GetObject("addButton.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.addButton, resources.GetString("addButton.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.addButton, CType(resources.GetObject("addButton.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.addButton, resources.GetString("addButton.HelpString"))
        Me.addButton.Image = CType(resources.GetObject("addButton.Image"), System.Drawing.Image)
        Me.addButton.ImageAlign = CType(resources.GetObject("addButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.addButton.ImageIndex = CType(resources.GetObject("addButton.ImageIndex"), Integer)
        Me.addButton.ImeMode = CType(resources.GetObject("addButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.addButton.Location = CType(resources.GetObject("addButton.Location"), System.Drawing.Point)
        Me.addButton.Name = "addButton"
        Me.addButton.RightToLeft = CType(resources.GetObject("addButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.addButton, CType(resources.GetObject("addButton.ShowHelp"), Boolean))
        Me.addButton.Size = CType(resources.GetObject("addButton.Size"), System.Drawing.Size)
        Me.addButton.TabIndex = CType(resources.GetObject("addButton.TabIndex"), Integer)
        Me.addButton.Text = resources.GetString("addButton.Text")
        Me.addButton.TextAlign = CType(resources.GetObject("addButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.addButton.Visible = CType(resources.GetObject("addButton.Visible"), Boolean)
        '
        'removeButton
        '
        Me.removeButton.AccessibleDescription = resources.GetString("removeButton.AccessibleDescription")
        Me.removeButton.AccessibleName = resources.GetString("removeButton.AccessibleName")
        Me.removeButton.Anchor = CType(resources.GetObject("removeButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.removeButton.BackgroundImage = CType(resources.GetObject("removeButton.BackgroundImage"), System.Drawing.Image)
        Me.removeButton.Dock = CType(resources.GetObject("removeButton.Dock"), System.Windows.Forms.DockStyle)
        Me.removeButton.Enabled = CType(resources.GetObject("removeButton.Enabled"), Boolean)
        Me.removeButton.FlatStyle = CType(resources.GetObject("removeButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.removeButton.Font = CType(resources.GetObject("removeButton.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.removeButton, resources.GetString("removeButton.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.removeButton, CType(resources.GetObject("removeButton.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.removeButton, resources.GetString("removeButton.HelpString"))
        Me.removeButton.Image = CType(resources.GetObject("removeButton.Image"), System.Drawing.Image)
        Me.removeButton.ImageAlign = CType(resources.GetObject("removeButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.removeButton.ImageIndex = CType(resources.GetObject("removeButton.ImageIndex"), Integer)
        Me.removeButton.ImeMode = CType(resources.GetObject("removeButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.removeButton.Location = CType(resources.GetObject("removeButton.Location"), System.Drawing.Point)
        Me.removeButton.Name = "removeButton"
        Me.removeButton.RightToLeft = CType(resources.GetObject("removeButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.removeButton, CType(resources.GetObject("removeButton.ShowHelp"), Boolean))
        Me.removeButton.Size = CType(resources.GetObject("removeButton.Size"), System.Drawing.Size)
        Me.removeButton.TabIndex = CType(resources.GetObject("removeButton.TabIndex"), Integer)
        Me.removeButton.Text = resources.GetString("removeButton.Text")
        Me.removeButton.TextAlign = CType(resources.GetObject("removeButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.removeButton.Visible = CType(resources.GetObject("removeButton.Visible"), Boolean)
        '
        'textOptionsLabel
        '
        Me.textOptionsLabel.AccessibleDescription = resources.GetString("textOptionsLabel.AccessibleDescription")
        Me.textOptionsLabel.AccessibleName = resources.GetString("textOptionsLabel.AccessibleName")
        Me.textOptionsLabel.Anchor = CType(resources.GetObject("textOptionsLabel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.textOptionsLabel.AutoSize = CType(resources.GetObject("textOptionsLabel.AutoSize"), Boolean)
        Me.textOptionsLabel.Dock = CType(resources.GetObject("textOptionsLabel.Dock"), System.Windows.Forms.DockStyle)
        Me.textOptionsLabel.Enabled = CType(resources.GetObject("textOptionsLabel.Enabled"), Boolean)
        Me.textOptionsLabel.Font = CType(resources.GetObject("textOptionsLabel.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.textOptionsLabel, resources.GetString("textOptionsLabel.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.textOptionsLabel, CType(resources.GetObject("textOptionsLabel.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.textOptionsLabel, resources.GetString("textOptionsLabel.HelpString"))
        Me.textOptionsLabel.Image = CType(resources.GetObject("textOptionsLabel.Image"), System.Drawing.Image)
        Me.textOptionsLabel.ImageAlign = CType(resources.GetObject("textOptionsLabel.ImageAlign"), System.Drawing.ContentAlignment)
        Me.textOptionsLabel.ImageIndex = CType(resources.GetObject("textOptionsLabel.ImageIndex"), Integer)
        Me.textOptionsLabel.ImeMode = CType(resources.GetObject("textOptionsLabel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.textOptionsLabel.Location = CType(resources.GetObject("textOptionsLabel.Location"), System.Drawing.Point)
        Me.textOptionsLabel.Name = "textOptionsLabel"
        Me.textOptionsLabel.RightToLeft = CType(resources.GetObject("textOptionsLabel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.textOptionsLabel, CType(resources.GetObject("textOptionsLabel.ShowHelp"), Boolean))
        Me.textOptionsLabel.Size = CType(resources.GetObject("textOptionsLabel.Size"), System.Drawing.Size)
        Me.textOptionsLabel.TabIndex = CType(resources.GetObject("textOptionsLabel.TabIndex"), Integer)
        Me.textOptionsLabel.Text = resources.GetString("textOptionsLabel.Text")
        Me.textOptionsLabel.TextAlign = CType(resources.GetObject("textOptionsLabel.TextAlign"), System.Drawing.ContentAlignment)
        Me.textOptionsLabel.Visible = CType(resources.GetObject("textOptionsLabel.Visible"), Boolean)
        '
        'iconOptionsLabel
        '
        Me.iconOptionsLabel.AccessibleDescription = resources.GetString("iconOptionsLabel.AccessibleDescription")
        Me.iconOptionsLabel.AccessibleName = resources.GetString("iconOptionsLabel.AccessibleName")
        Me.iconOptionsLabel.Anchor = CType(resources.GetObject("iconOptionsLabel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.iconOptionsLabel.AutoSize = CType(resources.GetObject("iconOptionsLabel.AutoSize"), Boolean)
        Me.iconOptionsLabel.Dock = CType(resources.GetObject("iconOptionsLabel.Dock"), System.Windows.Forms.DockStyle)
        Me.iconOptionsLabel.Enabled = CType(resources.GetObject("iconOptionsLabel.Enabled"), Boolean)
        Me.iconOptionsLabel.Font = CType(resources.GetObject("iconOptionsLabel.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.iconOptionsLabel, resources.GetString("iconOptionsLabel.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.iconOptionsLabel, CType(resources.GetObject("iconOptionsLabel.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.iconOptionsLabel, resources.GetString("iconOptionsLabel.HelpString"))
        Me.iconOptionsLabel.Image = CType(resources.GetObject("iconOptionsLabel.Image"), System.Drawing.Image)
        Me.iconOptionsLabel.ImageAlign = CType(resources.GetObject("iconOptionsLabel.ImageAlign"), System.Drawing.ContentAlignment)
        Me.iconOptionsLabel.ImageIndex = CType(resources.GetObject("iconOptionsLabel.ImageIndex"), Integer)
        Me.iconOptionsLabel.ImeMode = CType(resources.GetObject("iconOptionsLabel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.iconOptionsLabel.Location = CType(resources.GetObject("iconOptionsLabel.Location"), System.Drawing.Point)
        Me.iconOptionsLabel.Name = "iconOptionsLabel"
        Me.iconOptionsLabel.RightToLeft = CType(resources.GetObject("iconOptionsLabel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.iconOptionsLabel, CType(resources.GetObject("iconOptionsLabel.ShowHelp"), Boolean))
        Me.iconOptionsLabel.Size = CType(resources.GetObject("iconOptionsLabel.Size"), System.Drawing.Size)
        Me.iconOptionsLabel.TabIndex = CType(resources.GetObject("iconOptionsLabel.TabIndex"), Integer)
        Me.iconOptionsLabel.Text = resources.GetString("iconOptionsLabel.Text")
        Me.iconOptionsLabel.TextAlign = CType(resources.GetObject("iconOptionsLabel.TextAlign"), System.Drawing.ContentAlignment)
        Me.iconOptionsLabel.Visible = CType(resources.GetObject("iconOptionsLabel.Visible"), Boolean)
        '
        'textOptionsCombo
        '
        Me.textOptionsCombo.AccessibleDescription = resources.GetString("textOptionsCombo.AccessibleDescription")
        Me.textOptionsCombo.AccessibleName = resources.GetString("textOptionsCombo.AccessibleName")
        Me.textOptionsCombo.Anchor = CType(resources.GetObject("textOptionsCombo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.textOptionsCombo.BackgroundImage = CType(resources.GetObject("textOptionsCombo.BackgroundImage"), System.Drawing.Image)
        Me.textOptionsCombo.Dock = CType(resources.GetObject("textOptionsCombo.Dock"), System.Windows.Forms.DockStyle)
        Me.textOptionsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.textOptionsCombo.Enabled = CType(resources.GetObject("textOptionsCombo.Enabled"), Boolean)
        Me.textOptionsCombo.Font = CType(resources.GetObject("textOptionsCombo.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.textOptionsCombo, resources.GetString("textOptionsCombo.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.textOptionsCombo, CType(resources.GetObject("textOptionsCombo.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.textOptionsCombo, resources.GetString("textOptionsCombo.HelpString"))
        Me.textOptionsCombo.ImeMode = CType(resources.GetObject("textOptionsCombo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.textOptionsCombo.IntegralHeight = CType(resources.GetObject("textOptionsCombo.IntegralHeight"), Boolean)
        Me.textOptionsCombo.ItemHeight = CType(resources.GetObject("textOptionsCombo.ItemHeight"), Integer)
        Me.textOptionsCombo.Location = CType(resources.GetObject("textOptionsCombo.Location"), System.Drawing.Point)
        Me.textOptionsCombo.MaxDropDownItems = CType(resources.GetObject("textOptionsCombo.MaxDropDownItems"), Integer)
        Me.textOptionsCombo.MaxLength = CType(resources.GetObject("textOptionsCombo.MaxLength"), Integer)
        Me.textOptionsCombo.Name = "textOptionsCombo"
        Me.textOptionsCombo.RightToLeft = CType(resources.GetObject("textOptionsCombo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.textOptionsCombo, CType(resources.GetObject("textOptionsCombo.ShowHelp"), Boolean))
        Me.textOptionsCombo.Size = CType(resources.GetObject("textOptionsCombo.Size"), System.Drawing.Size)
        Me.textOptionsCombo.TabIndex = CType(resources.GetObject("textOptionsCombo.TabIndex"), Integer)
        Me.textOptionsCombo.Text = resources.GetString("textOptionsCombo.Text")
        Me.textOptionsCombo.Visible = CType(resources.GetObject("textOptionsCombo.Visible"), Boolean)
        '
        'iconOptionsCombo
        '
        Me.iconOptionsCombo.AccessibleDescription = resources.GetString("iconOptionsCombo.AccessibleDescription")
        Me.iconOptionsCombo.AccessibleName = resources.GetString("iconOptionsCombo.AccessibleName")
        Me.iconOptionsCombo.Anchor = CType(resources.GetObject("iconOptionsCombo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.iconOptionsCombo.BackgroundImage = CType(resources.GetObject("iconOptionsCombo.BackgroundImage"), System.Drawing.Image)
        Me.iconOptionsCombo.Dock = CType(resources.GetObject("iconOptionsCombo.Dock"), System.Windows.Forms.DockStyle)
        Me.iconOptionsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.iconOptionsCombo.Enabled = CType(resources.GetObject("iconOptionsCombo.Enabled"), Boolean)
        Me.iconOptionsCombo.Font = CType(resources.GetObject("iconOptionsCombo.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.iconOptionsCombo, resources.GetString("iconOptionsCombo.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.iconOptionsCombo, CType(resources.GetObject("iconOptionsCombo.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.iconOptionsCombo, resources.GetString("iconOptionsCombo.HelpString"))
        Me.iconOptionsCombo.ImeMode = CType(resources.GetObject("iconOptionsCombo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.iconOptionsCombo.IntegralHeight = CType(resources.GetObject("iconOptionsCombo.IntegralHeight"), Boolean)
        Me.iconOptionsCombo.ItemHeight = CType(resources.GetObject("iconOptionsCombo.ItemHeight"), Integer)
        Me.iconOptionsCombo.Location = CType(resources.GetObject("iconOptionsCombo.Location"), System.Drawing.Point)
        Me.iconOptionsCombo.MaxDropDownItems = CType(resources.GetObject("iconOptionsCombo.MaxDropDownItems"), Integer)
        Me.iconOptionsCombo.MaxLength = CType(resources.GetObject("iconOptionsCombo.MaxLength"), Integer)
        Me.iconOptionsCombo.Name = "iconOptionsCombo"
        Me.iconOptionsCombo.RightToLeft = CType(resources.GetObject("iconOptionsCombo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.iconOptionsCombo, CType(resources.GetObject("iconOptionsCombo.ShowHelp"), Boolean))
        Me.iconOptionsCombo.Size = CType(resources.GetObject("iconOptionsCombo.Size"), System.Drawing.Size)
        Me.iconOptionsCombo.TabIndex = CType(resources.GetObject("iconOptionsCombo.TabIndex"), Integer)
        Me.iconOptionsCombo.Text = resources.GetString("iconOptionsCombo.Text")
        Me.iconOptionsCombo.Visible = CType(resources.GetObject("iconOptionsCombo.Visible"), Boolean)
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = resources.GetString("HelpProvider1.HelpNamespace")
        '
        'closeButton
        '
        Me.closeButton.AccessibleDescription = resources.GetString("closeButton.AccessibleDescription")
        Me.closeButton.AccessibleName = resources.GetString("closeButton.AccessibleName")
        Me.closeButton.Anchor = CType(resources.GetObject("closeButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.closeButton.BackgroundImage = CType(resources.GetObject("closeButton.BackgroundImage"), System.Drawing.Image)
        Me.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.closeButton.Dock = CType(resources.GetObject("closeButton.Dock"), System.Windows.Forms.DockStyle)
        Me.closeButton.Enabled = CType(resources.GetObject("closeButton.Enabled"), Boolean)
        Me.closeButton.FlatStyle = CType(resources.GetObject("closeButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.closeButton.Font = CType(resources.GetObject("closeButton.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.closeButton, resources.GetString("closeButton.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.closeButton, CType(resources.GetObject("closeButton.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.closeButton, resources.GetString("closeButton.HelpString"))
        Me.closeButton.Image = CType(resources.GetObject("closeButton.Image"), System.Drawing.Image)
        Me.closeButton.ImageAlign = CType(resources.GetObject("closeButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.closeButton.ImageIndex = CType(resources.GetObject("closeButton.ImageIndex"), Integer)
        Me.closeButton.ImeMode = CType(resources.GetObject("closeButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.closeButton.Location = CType(resources.GetObject("closeButton.Location"), System.Drawing.Point)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.RightToLeft = CType(resources.GetObject("closeButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.closeButton, CType(resources.GetObject("closeButton.ShowHelp"), Boolean))
        Me.closeButton.Size = CType(resources.GetObject("closeButton.Size"), System.Drawing.Size)
        Me.closeButton.TabIndex = CType(resources.GetObject("closeButton.TabIndex"), Integer)
        Me.closeButton.Text = resources.GetString("closeButton.Text")
        Me.closeButton.TextAlign = CType(resources.GetObject("closeButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.closeButton.Visible = CType(resources.GetObject("closeButton.Visible"), Boolean)
        '
        'availableListBox
        '
        Me.availableListBox.AccessibleDescription = resources.GetString("availableListBox.AccessibleDescription")
        Me.availableListBox.AccessibleName = resources.GetString("availableListBox.AccessibleName")
        Me.availableListBox.Anchor = CType(resources.GetObject("availableListBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.availableListBox.BackgroundImage = CType(resources.GetObject("availableListBox.BackgroundImage"), System.Drawing.Image)
        Me.availableListBox.ColumnWidth = CType(resources.GetObject("availableListBox.ColumnWidth"), Integer)
        Me.availableListBox.Dock = CType(resources.GetObject("availableListBox.Dock"), System.Windows.Forms.DockStyle)
        Me.availableListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.availableListBox.Enabled = CType(resources.GetObject("availableListBox.Enabled"), Boolean)
        Me.availableListBox.Font = CType(resources.GetObject("availableListBox.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.availableListBox, resources.GetString("availableListBox.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.availableListBox, CType(resources.GetObject("availableListBox.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.availableListBox, resources.GetString("availableListBox.HelpString"))
        Me.availableListBox.HorizontalExtent = CType(resources.GetObject("availableListBox.HorizontalExtent"), Integer)
        Me.availableListBox.HorizontalScrollbar = CType(resources.GetObject("availableListBox.HorizontalScrollbar"), Boolean)
        Me.availableListBox.ImeMode = CType(resources.GetObject("availableListBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.availableListBox.IntegralHeight = CType(resources.GetObject("availableListBox.IntegralHeight"), Boolean)
        Me.availableListBox.ItemHeight = CType(resources.GetObject("availableListBox.ItemHeight"), Integer)
        Me.availableListBox.Location = CType(resources.GetObject("availableListBox.Location"), System.Drawing.Point)
        Me.availableListBox.Name = "availableListBox"
        Me.availableListBox.RightToLeft = CType(resources.GetObject("availableListBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.availableListBox.ScrollAlwaysVisible = CType(resources.GetObject("availableListBox.ScrollAlwaysVisible"), Boolean)
        Me.HelpProvider1.SetShowHelp(Me.availableListBox, CType(resources.GetObject("availableListBox.ShowHelp"), Boolean))
        Me.availableListBox.Size = CType(resources.GetObject("availableListBox.Size"), System.Drawing.Size)
        Me.availableListBox.TabIndex = CType(resources.GetObject("availableListBox.TabIndex"), Integer)
        Me.availableListBox.Visible = CType(resources.GetObject("availableListBox.Visible"), Boolean)
        '
        'currentListBox
        '
        Me.currentListBox.AccessibleDescription = resources.GetString("currentListBox.AccessibleDescription")
        Me.currentListBox.AccessibleName = resources.GetString("currentListBox.AccessibleName")
        Me.currentListBox.Anchor = CType(resources.GetObject("currentListBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.currentListBox.BackgroundImage = CType(resources.GetObject("currentListBox.BackgroundImage"), System.Drawing.Image)
        Me.currentListBox.ColumnWidth = CType(resources.GetObject("currentListBox.ColumnWidth"), Integer)
        Me.currentListBox.Dock = CType(resources.GetObject("currentListBox.Dock"), System.Windows.Forms.DockStyle)
        Me.currentListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.currentListBox.Enabled = CType(resources.GetObject("currentListBox.Enabled"), Boolean)
        Me.currentListBox.Font = CType(resources.GetObject("currentListBox.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.currentListBox, resources.GetString("currentListBox.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.currentListBox, CType(resources.GetObject("currentListBox.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.currentListBox, resources.GetString("currentListBox.HelpString"))
        Me.currentListBox.HorizontalExtent = CType(resources.GetObject("currentListBox.HorizontalExtent"), Integer)
        Me.currentListBox.HorizontalScrollbar = CType(resources.GetObject("currentListBox.HorizontalScrollbar"), Boolean)
        Me.currentListBox.ImeMode = CType(resources.GetObject("currentListBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.currentListBox.IntegralHeight = CType(resources.GetObject("currentListBox.IntegralHeight"), Boolean)
        Me.currentListBox.ItemHeight = CType(resources.GetObject("currentListBox.ItemHeight"), Integer)
        Me.currentListBox.Location = CType(resources.GetObject("currentListBox.Location"), System.Drawing.Point)
        Me.currentListBox.Name = "currentListBox"
        Me.currentListBox.RightToLeft = CType(resources.GetObject("currentListBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.currentListBox.ScrollAlwaysVisible = CType(resources.GetObject("currentListBox.ScrollAlwaysVisible"), Boolean)
        Me.HelpProvider1.SetShowHelp(Me.currentListBox, CType(resources.GetObject("currentListBox.ShowHelp"), Boolean))
        Me.currentListBox.Size = CType(resources.GetObject("currentListBox.Size"), System.Drawing.Size)
        Me.currentListBox.TabIndex = CType(resources.GetObject("currentListBox.TabIndex"), Integer)
        Me.currentListBox.Visible = CType(resources.GetObject("currentListBox.Visible"), Boolean)
        '
        'localCancelButton
        '
        Me.localCancelButton.AccessibleDescription = resources.GetString("localCancelButton.AccessibleDescription")
        Me.localCancelButton.AccessibleName = resources.GetString("localCancelButton.AccessibleName")
        Me.localCancelButton.Anchor = CType(resources.GetObject("localCancelButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.localCancelButton.BackgroundImage = CType(resources.GetObject("localCancelButton.BackgroundImage"), System.Drawing.Image)
        Me.localCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.localCancelButton.Dock = CType(resources.GetObject("localCancelButton.Dock"), System.Windows.Forms.DockStyle)
        Me.localCancelButton.Enabled = CType(resources.GetObject("localCancelButton.Enabled"), Boolean)
        Me.localCancelButton.FlatStyle = CType(resources.GetObject("localCancelButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.localCancelButton.Font = CType(resources.GetObject("localCancelButton.Font"), System.Drawing.Font)
        Me.HelpProvider1.SetHelpKeyword(Me.localCancelButton, resources.GetString("localCancelButton.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.localCancelButton, CType(resources.GetObject("localCancelButton.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.localCancelButton, resources.GetString("localCancelButton.HelpString"))
        Me.localCancelButton.Image = CType(resources.GetObject("localCancelButton.Image"), System.Drawing.Image)
        Me.localCancelButton.ImageAlign = CType(resources.GetObject("localCancelButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.localCancelButton.ImageIndex = CType(resources.GetObject("localCancelButton.ImageIndex"), Integer)
        Me.localCancelButton.ImeMode = CType(resources.GetObject("localCancelButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.localCancelButton.Location = CType(resources.GetObject("localCancelButton.Location"), System.Drawing.Point)
        Me.localCancelButton.Name = "localCancelButton"
        Me.localCancelButton.RightToLeft = CType(resources.GetObject("localCancelButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me.localCancelButton, CType(resources.GetObject("localCancelButton.ShowHelp"), Boolean))
        Me.localCancelButton.Size = CType(resources.GetObject("localCancelButton.Size"), System.Drawing.Size)
        Me.localCancelButton.TabIndex = CType(resources.GetObject("localCancelButton.TabIndex"), Integer)
        Me.localCancelButton.Text = resources.GetString("localCancelButton.Text")
        Me.localCancelButton.TextAlign = CType(resources.GetObject("localCancelButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.localCancelButton.Visible = CType(resources.GetObject("localCancelButton.Visible"), Boolean)
        '
        'UtilityToolBarCustomiseDialog
        '
        Me.AcceptButton = Me.closeButton
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.localCancelButton
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.Add(Me.localCancelButton)
        Me.Controls.Add(Me.currentListBox)
        Me.Controls.Add(Me.availableListBox)
        Me.Controls.Add(Me.iconOptionsCombo)
        Me.Controls.Add(Me.textOptionsCombo)
        Me.Controls.Add(Me.iconOptionsLabel)
        Me.Controls.Add(Me.textOptionsLabel)
        Me.Controls.Add(Me.removeButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.moveUpButton)
        Me.Controls.Add(Me.moveDownButton)
        Me.Controls.Add(Me.resetButton)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.currentLabel)
        Me.Controls.Add(Me.availableLabel)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, resources.GetString("$this.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me, CType(resources.GetObject("$this.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me, resources.GetString("$this.HelpString"))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimizeBox = False
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "UtilityToolBarCustomiseDialog"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.HelpProvider1.SetShowHelp(Me, CType(resources.GetObject("$this.ShowHelp"), Boolean))
        Me.ShowInTaskbar = False
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.ResumeLayout(False)

    End Sub

#End Region


    '=----------------------------------------------------------------------=
    ' availableListBox_DrawItem
    '=----------------------------------------------------------------------=
    ' This is the list box of items that are available to be selected/included
    ' in the UtilityToolBar
    '
    Private Sub availableListBox_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles availableListBox.DrawItem
        drawItemForListBox(CType(sender, ListBox), e)
    End Sub


    '=----------------------------------------------------------------------=
    ' currentListBox_DrawItem
    '=----------------------------------------------------------------------=
    ' This is the list box of items that are currently selected by the
    ' user for inclusion in the UtilityToolBar
    '
    Private Sub currentListBox_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles currentListBox.DrawItem
        drawItemForListBox(CType(sender, ListBox), e)
    End Sub


    '=----------------------------------------------------------------------=
    ' drawItemForListBox
    '=----------------------------------------------------------------------=
    ' Handles the DrawItem event for our two list boxes.   It turns out that
    ' there is so much common code they can both share most of it.
    '
    ' Parameters:
    '       ListBox             - [in]  From whence the event came.
    '       DrawItemEventArgs   - [in]  Details, details, details.
    '
    Private Sub drawItemForListBox(ByVal in_listBox As ListBox, _
                                   ByVal in_eventargs As DrawItemEventArgs)

        Dim lbbd As ListBoxButtonData
        Dim b As SolidBrush

        If in_listBox Is Nothing Then
            System.Diagnostics.Debug.Fail("DrawItem event for something that isn't a ListBox!")
            Return
        End If

        '
        ' draw the background for all the buttons. 
        '
        in_eventargs.DrawBackground()

        lbbd = CType(in_listBox.Items(in_eventargs.Index), ListBoxButtonData)
        If lbbd Is Nothing Then
            System.Diagnostics.Debug.Fail("A bogus item was inserted into the " & in_listBox.Name & " ListBox.")
            Return
        End If

        '
        ' If they asked us to draw a separator, then skip the image
        '
        If Not lbbd.m_imageIndex = -1 And Not lbbd.m_imageIndex = -2 Then
            in_eventargs.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            Me.m_imageList.Draw(in_eventargs.Graphics, New Point(in_eventargs.Bounds.Left + 1, in_eventargs.Bounds.Top + 1), lbbd.m_imageIndex)
        End If

        '
        ' Finally, draw the text.  Make sure we clean up afterwards.
        '
        Try
            If in_eventargs.State And DrawItemState.Selected Then
                b = New SolidBrush(Me.availableListBox.BackColor)
            Else
                If Not lbbd.m_imageIndex = -2 Then
                    b = New SolidBrush(SystemColors.ControlText)
                Else
                    b = New SolidBrush(SystemColors.ControlDark)
                End If
            End If
            in_eventargs.Graphics.DrawString(in_listBox.Items(in_eventargs.Index).ToString(), _
                                             Me.Font, b, 18, _
                                             in_eventargs.Bounds.Top + 2)
        Finally
            b.Dispose()
        End Try

    End Sub ' drawItemForListBox


    '=----------------------------------------------------------------------=
    ' populateAvailableListBox
    '=----------------------------------------------------------------------=
    ' Fills in the "available" list box with all the items possible that
    ' aren't already in the "currently selected" list box.
    '
    ' Parameters:
    '       ListBox                 - [in]  available list box
    '       ToolBarButtonCollection - [in]  collection with which to work.
    '       Integer                 - [in]  Category Mask
    '
    Private Sub populateAvailableListBox(ByVal in_available As ListBox, _
                                         ByVal in_coll As ToolBar.ToolBarButtonCollection, _
                                         ByVal in_mask As Integer)

        Dim resources As System.Resources.ResourceManager
        resources = VbPowerPackMain.GetResourceManager()

        '
        ' First, add a separator 
        '
        in_available.Items.Add(New ListBoxButtonData(resources.GetString("UtilityToolBar.Separator"), -1, Nothing))

        '
        ' Now, for each possible value, if it's not already selected, add it
        ' to this list.
        '
        For Each x As UtilityToolBarButtonType In System.Enum.GetValues(GetType(UtilityToolBarButtonType))

            If Not itemInCollection(x, in_coll) _
               AndAlso buttonInCategoryMask(x, in_mask) Then
                in_available.Items.Add(New ListBoxButtonData(UtilityToolBarButton.getTextForButton(x), x, Nothing))
            End If

        Next

    End Sub ' populateAvailableListBox


    '=----------------------------------------------------------------------=
    ' populateCurrentListBox
    '=----------------------------------------------------------------------=
    ' Populates the "currently selected" list box with all the items that the
    ' user has currently selected to be in the ToolBar
    '
    ' Parameters:
    '       ListBox                 - [in]  to which list box to add them.
    '       ToolBarButtonCollection - [in]  which items to add
    '
    Private Sub populateCurrentListBox(ByVal in_currently As ListBox, _
                                       ByVal in_coll As ToolBar.ToolBarButtonCollection)

        Dim resources As System.Resources.ResourceManager
        Dim i As Integer

        If in_coll Is Nothing Then Return
        resources = VbPowerPackMain.GetResourceManager()

        '
        ' Go and add each item one at a time ...
        '
        For x As Integer = 0 To in_coll.Count - 1

            Dim utb As UtilityToolBarButton
            utb = CType(in_coll(x), UtilityToolBarButton)
            System.Diagnostics.Debug.Assert(Not utb Is Nothing, "Bogus ToolBarButton showing Customise Dialog.")

            If Not utb.Style = ToolBarButtonStyle.Separator Then
                i = utb.ImageIndex
                in_currently.Items.Add(New ListBoxButtonData( _
                                           UtilityToolBarButton.getTextForButton(i), _
                                           i, utb))
            Else
                in_currently.Items.Add(New ListBoxButtonData( _
                                           "Separator", -1, utb))
            End If
        Next

        '
        ' Lastly, add a special separator at the end to support
        ' inserting always. (otherwise, the user could never add anything
        ' to the end of the list!)
        '
        in_currently.Items.Add(New ListBoxButtonData(resources.GetString("UtilityToolBar.Separator"), -2, Nothing))

    End Sub ' populateCurrentListBox


    '=----------------------------------------------------------------------=
    ' buttonInCategoryMask
    '=----------------------------------------------------------------------=
    ' Indicaites if the given button is "allowed" by the given Category
    ' Mask.
    '
    ' Parameters:
    '       UtilityToolBarButtonType    - [in]  button
    '       Integer                     - [in]  permissible Category mask
    '
    ' Returns:
    '       Boolean                     - True, allowed, False, denied
    '
    Private Function buttonInCategoryMask(ByVal in_button As UtilityToolBarButtonType, _
                                          ByVal in_mask As Integer) _
                                          As Boolean

        Dim buttonMask As Integer

        If in_mask = &HFFFFFFFF Then Return True

        buttonMask = UtilityToolBarButton.GetCategoryForButton(in_button)
        If in_mask And buttonMask Then
            Return True
        Else
            Return False
        End If

    End Function ' buttonInCategoryMask


    '=----------------------------------------------------------------------=
    ' itemInCollection
    '=----------------------------------------------------------------------=
    ' Looks to see if the given items is in the collection given to us.
    '
    ' Parameters:
    '       Integer                 - [in]  UtilityToolBarButtonType sought
    '       ToolBarButtonCollection - [in]  where to look
    '
    ' Returns:
    '       Boolean                 - True = Item IN the coll, False NO.
    '
    Private Function itemInCollection(ByVal in_imageIndex As Integer, _
                                      ByVal in_coll As ToolBar.ToolBarButtonCollection) _
                                      As Boolean

        For Each x As ToolBarButton In in_coll
            If x.ImageIndex = in_imageIndex Then Return True
        Next
        Return False

    End Function ' itemInCollection


    '=----------------------------------------------------------------------=
    ' addButton_Click
    '=----------------------------------------------------------------------=
    ' Takes the currently selected item from the availableListBox and moves
    ' it o'er to the currentListBox.  It is NOT removed, however, if it's the
    ' separator.
    '
    '
    Private Sub addButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addButton.Click

        Dim insertAt As Integer
        Dim i As Integer
        Dim o As Object

        i = Me.availableListBox.SelectedIndex

        '
        ' If there isn't really a selected item, return
        '
        If i = -1 Then Return

        '
        ' Add the item to the currentListBox before the current selection
        '
        o = Me.availableListBox.Items(i)
        insertAt = Me.currentListBox.SelectedIndex
        If insertAt = -1 Then insertAt = Me.currentListBox.Items.Count() - 1
        Me.currentListBox.Items.Insert(insertAt, o)

        '
        ' Remove it, provided it's not the separator
        '
        If Not i = 0 Then
            Me.availableListBox.Items.Remove(o)

            '
            ' Make sure that there's still an item selected in the listbox.
            '
            If Not i > Me.availableListBox.Items.Count() - 1 Then
                Me.availableListBox.SelectedIndex = i
            Else
                Me.availableListBox.SelectedIndex = i - 1
            End If

        End If
        '
        ' finally, update the buttons
        '
        updateButtons()

    End Sub ' addButton_Click

    '=----------------------------------------------------------------------=
    ' removeButton_Click
    '=----------------------------------------------------------------------=
    ' The user wishes to remove the currently selected button from the list
    ' of Currently Selected buttons ...
    '
    ' 
    Private Sub removeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeButton.Click

        Dim insertIndex As Integer
        Dim i As Integer
        Dim o As Object

        i = Me.currentListBox.SelectedIndex

        '
        ' If there isn't really a selected item or it's the "fixed"
        ' separator in the current listbox, then return
        '
        If i = -1 Or i = Me.currentListBox.Items.Count() - 1 Then Return

        '
        ' Add the item back to the availableListBox, provided it's not a
        ' separator
        '
        o = Me.currentListBox.Items(i)
        insertIndex = determineInsertIndex(Me.availableListBox, o)
        If Not insertIndex = -1 Then
            Me.availableListBox.Items.Insert(insertIndex, o)
        End If

        '
        ' Remove it from the currently selected list o' items
        '
        Me.currentListBox.Items.Remove(o)

        '
        ' Make sure that there's still an item selected in the listbox.
        '
        If Not i > Me.currentListBox.Items.Count() - 1 Then
            Me.currentListBox.SelectedIndex = i
        Else
            Me.currentListBox.SelectedIndex = i - 1
        End If

        '
        ' finally, update the buttons
        '
        updateButtons()

    End Sub ' removeButton_Click

    '=----------------------------------------------------------------------=
    ' determineInsertIndex
    '=----------------------------------------------------------------------=
    ' Given that we want to put an item back into the Available ListBox, go
    ' and figure out where it needs to go there, since they're "ordered" based
    ' on their UtilityToolBarButtonTypes ...
    '
    ' Parameters:
    '       ListBox             - [in]  available list box.
    '       Object              - [in]  item to put back
    '
    ' Returns:
    '       Integer             - [in]  index at which it should be reinserted
    '
    Private Function determineInsertIndex(ByVal in_listBox As ListBox, _
                                          ByVal in_lbbd As Object) _
                                          As Integer
        Dim lbbd As ListBoxButtonData
        Dim imageIndex As Integer

        lbbd = CType(in_lbbd, ListBoxButtonData)
        If lbbd Is Nothing Then
            System.Diagnostics.Debug.Fail("Bogus ListBox Item type in Remove Operation.")
            Return -1
        End If

        ' 
        ' Get the Image index and abort if it's a separator
        '
        imageIndex = lbbd.m_imageIndex
        If imageIndex = -1 Then Return -1

        '
        ' Loop through the items in the list box looking for one with a type
        ' value bigger than this ...
        '
        For x As Integer = 0 To in_listBox.Items.Count() - 1

            lbbd = CType(in_listBox.Items(x), ListBoxButtonData)
            If lbbd Is Nothing Then
                System.Diagnostics.Debug.Fail("Bogus ListBox Item type in Remove Operation.")
                Return -1
            End If

            '
            ' is it bigger?  If so, insert before it!
            '
            If lbbd.m_imageIndex > imageIndex Then Return x

        Next

        '
        ' Otherwise, it must be the last in the list !!!
        '
        Return in_listBox.Items.Count()

    End Function ' determineInsertIndex


    '=----------------------------------------------------------------------=
    ' resetButton_Click
    '=----------------------------------------------------------------------=
    ' The user pressed the Reset Button.  Go and reset the lists now ...
    '
    '
    Private Sub resetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resetButton.Click

        '
        ' clear the existing contents of both list boxes ...
        '
        Me.availableListBox.Items.Clear()
        Me.currentListBox.Items.Clear()

        '
        ' and repopulate them to their original state ...
        '
        populateAvailableListBox(Me.availableListBox, Me.m_collection, Me.m_buttonMask)
        populateCurrentListBox(Me.currentListBox, Me.m_collection)

        '
        ' finally, update the buttons
        '
        updateButtons()

    End Sub ' resetButton_Click


    '=----------------------------------------------------------------------=
    ' moveUpButton_Click
    '=----------------------------------------------------------------------=
    ' The user clicked on the MoveUp button.  We want to move the current
    ' item in the "current" list box up one notch.
    '
    '
    Private Sub moveUpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moveUpButton.Click

        Dim i As Integer
        Dim o As Object

        '
        ' get the currently selected index and item.  if there is no
        ' selection, or it's the first item in the list, go away.
        '
        i = Me.currentListBox.SelectedIndex
        If i = -1 Or i = 0 Then Return

        o = Me.currentListBox.SelectedItem

        '
        ' now, remove this item, and then insert it one item earlier
        '
        Me.currentListBox.Items.Remove(o)
        Me.currentListBox.Items.Insert(i - 1, o)

        '
        ' Now, make sure an item is still selected.
        '
        Me.currentListBox.SelectedIndex = i - 1

        '
        ' finally, update the buttons
        '
        updateButtons()

    End Sub ' moveUpButton_Click

    '=----------------------------------------------------------------------=
    ' moveDownButton_Click
    '=----------------------------------------------------------------------=
    ' The user clicked on the MoveDown button.  We want to move the currently
    ' selected item in the "current" list box down one item ...
    '
    '
    Private Sub moveDownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moveDownButton.Click

        Dim i As Integer
        Dim o As Object

        '
        ' get the currently selected index and item.  if there is no
        ' selection, or it's the lastitem in the list, go away.
        '
        i = Me.currentListBox.SelectedIndex
        If i = -1 Or i = Me.currentListBox.Items.Count() - 1 Then Return

        o = Me.currentListBox.SelectedItem

        '
        ' now, remove this item, and then insert it one item later.
        '
        Me.currentListBox.Items.Remove(o)
        Me.currentListBox.Items.Insert(i + 1, o)

        '
        ' Now, make sure an item is still selected.
        '
        Me.currentListBox.SelectedIndex = i + 1

        '
        ' finally, update the buttons
        '
        updateButtons()

    End Sub ' moveDownButton_Click

    '=----------------------------------------------------------------------=
    ' updateButtons
    '=----------------------------------------------------------------------=
    ' Go and enable and disable the various buttons on the form depending on
    ' how the user 
    Private Sub updateButtons()

        '
        ' "Add" button
        '
        Me.addButton.Enabled = Not (Me.availableListBox.SelectedIndex = -1)

        '
        ' "Remove"  button
        '
        Me.removeButton.Enabled = (Me.currentListBox.Items.Count() > 0)

        '
        ' "Move Up" button.
        '
        If Me.currentListBox.Items.Count() > 1 _
           AndAlso Me.currentListBox.SelectedIndex > 0 _
           AndAlso Not (Me.currentListBox.SelectedIndex = Me.currentListBox.Items.Count() - 1) Then
            Me.moveUpButton.Enabled = True
        Else
            Me.moveUpButton.Enabled = False
        End If

        '
        ' "Move Down" button
        '
        If Me.currentListBox.Items.Count() > 0 _
           And Not (Me.currentListBox.SelectedIndex >= Me.currentListBox.Items.Count() - 2) Then
            Me.moveDownButton.Enabled = True
        Else
            Me.moveDownButton.Enabled = False
        End If


    End Sub ' updateButtons


    '=----------------------------------------------------------------------=
    ' availableListBox_SelectedIndexChanged
    '=----------------------------------------------------------------------=
    ' update our buttons when the user clicks around ...
    '
    Private Sub availableListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles availableListBox.SelectedIndexChanged

        '
        ' Update the buttons
        '
        updateButtons()

    End Sub ' availableListBox_SelectedIndexChanged

    '=----------------------------------------------------------------------=
    ' currentListBox_SelectedIndexChanged
    '=----------------------------------------------------------------------=
    ' update our buttons when the user clicks around ...
    '
    Private Sub currentListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles currentListBox.SelectedIndexChanged

        '
        ' Update the buttons
        '
        updateButtons()

    End Sub ' currentListBox_SelectedIndexChanged


    '=----------------------------------------------------------------------=
    ' availableListBox_DoubleClick
    '=----------------------------------------------------------------------=
    ' This is the same as clicking the Add Button.
    '
    Private Sub availableListBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles availableListBox.DoubleClick

        addButton_Click(sender, e)

    End Sub ' availableListBox_DoubleClick


    '=----------------------------------------------------------------------=
    ' currentListBox_DoubleClick
    '=----------------------------------------------------------------------=
    ' This is the same as clicking the Remove button.
    '
    Private Sub currentListBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles currentListBox.DoubleClick

        removeButton_Click(sender, e)

    End Sub ' currentListBox_DoubleClick


    '=----------------------------------------------------------------------=
    ' fillTextOptionsCombo
    '=----------------------------------------------------------------------=
    ' Fills up the Text Options Combo box with the possible values and
    ' selects the appropriate one based on current settings in the
    ' UtilityToolBar
    '
    ' Parameters:
    '       UtilityToolBar          - [in]  control
    '
    Private Sub fillTextOptionsCombo(ByVal in_ctl As UtilityToolBar)

        Dim resources As System.Resources.ResourceManager

        resources = VbPowerPackMain.GetResourceManager()

        '
        ' !!! Please note that the order of these (0, 1, 2) corresponds
        ' exactly to values in the UtilityToolBarShowText enumeration !!!!!
        '
        Dim vals() As String = { _
            resources.GetString("UtilityToolBar.textOptions1"), _
            resources.GetString("UtilityToolBar.textOptions2"), _
            resources.GetString("UtilityToolBar.textOptions3") _
        }

        '
        ' add them all
        '
        For x As Integer = 0 To vals.Length - 1
            Me.textOptionsCombo.Items.Add(vals(x))
        Next

        '
        ' Select the right one!
        '
        Me.textOptionsCombo.SelectedIndex = in_ctl.ShowText

    End Sub ' fillTextOptionsCombo


    '=----------------------------------------------------------------------=
    ' fillIconOptionsCombo
    '=----------------------------------------------------------------------=
    ' Fills up the Icon Options Combo Box with the possible values and selects
    ' the appropriate value based on current settings in the UtilityToolBar
    '
    ' Parameters:
    '       UtilityToolBar          - [in]  control
    '
    Private Sub fillIconOptionsCombo(ByVal in_ctl As UtilityToolBar)


        Dim resources As System.Resources.ResourceManager

        resources = VbPowerPackMain.GetResourceManager()

        '
        ' !!! Please note that the order of these (0, 1) corresponds
        ' exactly to values in the UtilityToolBarIconOptions enumeration !!!!!
        '
        Dim vals() As String = { _
            resources.GetString("UtilityToolBar.iconOptions1"), _
            resources.GetString("UtilityToolBar.iconOptions2") _
        }

        '
        ' add them all
        '
        For x As Integer = 0 To vals.Length - 1
            Me.iconOptionsCombo.Items.Add(vals(x))
        Next

        '
        ' select the right one!
        '
        Me.iconOptionsCombo.SelectedIndex = in_ctl.IconOptions

    End Sub ' fillIconOptionsCombo




    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                            NESTED CLASSES
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' ListBoxButtonData
    '=----------------------------------------------------------------------=
    ' This will hold some private data for us along with the list box text
    '
    Friend Class ListBoxButtonData

        '
        ' This is the printable string in the List Box
        '
        Friend m_text As String

        '
        ' This is the ImageIndex as well as "Type" for the button
        '
        Friend m_imageIndex As Integer

        '
        ' This is used by the design time editor to see if the user has
        ' selected a button that they had before ...
        '
        Friend m_button As UtilityToolBarButton



        '=------------------------------------------------------------------=
        ' Constructor
        '=------------------------------------------------------------------=
        ' Takes some values and stores them for us
        '
        Public Sub New(ByVal in_text As String, _
                       ByVal in_imageIndex As Integer, _
                       ByVal in_button As UtilityToolBarButton)

            Me.m_text = in_text
            Me.m_button = in_button
            Me.m_imageIndex = in_imageIndex

        End Sub


        '=------------------------------------------------------------------=
        ' ToString
        '=------------------------------------------------------------------=
        ' Returns our friendly printable text.
        '
        Public Overrides Function ToString() As String
            Return Me.m_text
        End Function

    End Class ' ListBoxButtonData





End Class ' UtilityToolBarCustomiseDialog



