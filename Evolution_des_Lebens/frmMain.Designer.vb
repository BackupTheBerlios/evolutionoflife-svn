Partial Public Class frmMain
	Inherits System.Windows.Forms.Form

	<System.Diagnostics.DebuggerNonUserCode()> _
	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

	End Sub

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing AndAlso components IsNot Nothing Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
		Me.StatusZeile = New System.Windows.Forms.StatusStrip
		Me.mnuMain = New System.Windows.Forms.MenuStrip
		Me.mnuDatei = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuDateiBeenden = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuAnsicht = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHilfe = New System.Windows.Forms.ToolStripMenuItem
		Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ÜberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.Tabs = New System.Windows.Forms.TabControl
		Me.TabSpielfelder = New System.Windows.Forms.TabPage
		Me.BlendPanel1 = New VbPowerPack.BlendPanel
		Me.TabControl1 = New System.Windows.Forms.TabControl
		Me.TabPage1 = New System.Windows.Forms.TabPage
		Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid
		Me.TabPage2 = New System.Windows.Forms.TabPage
		Me.PropertyGrid2 = New System.Windows.Forms.PropertyGrid
		Me.TaskPane1 = New VbPowerPack.TaskPane
		Me.TaskFrame1 = New VbPowerPack.TaskFrame
		Me.ListBox1 = New System.Windows.Forms.ListBox
		Me.TaskFrame2 = New VbPowerPack.TaskFrame
		Me.TextBox1 = New System.Windows.Forms.TextBox
		Me.TaskFrame3 = New VbPowerPack.TaskFrame
		Me.TextBox2 = New System.Windows.Forms.TextBox
		Me.TabWelten = New System.Windows.Forms.TabPage
		Me.TabLebewesen = New System.Windows.Forms.TabPage
		Me.TabExperimente = New System.Windows.Forms.TabPage
		Me.TabEinstellungen = New System.Windows.Forms.TabPage
		Me.TabSimulationen = New System.Windows.Forms.TabPage
		Me.TabWWW = New System.Windows.Forms.TabPage
		Me.ToolStripWWW = New System.Windows.Forms.ToolStrip
		Me.IconListe = New System.Windows.Forms.ImageList(Me.components)
		Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
		Me.WWWWBrowser = New System.Windows.Forms.WebBrowser
		Me.mnuMain.SuspendLayout()
		Me.Tabs.SuspendLayout()
		Me.TabSpielfelder.SuspendLayout()
		Me.BlendPanel1.SuspendLayout()
		Me.TabControl1.SuspendLayout()
		Me.TabPage1.SuspendLayout()
		Me.TabPage2.SuspendLayout()
		Me.TaskPane1.SuspendLayout()
		Me.TaskFrame1.SuspendLayout()
		Me.TaskFrame2.SuspendLayout()
		Me.TaskFrame3.SuspendLayout()
		Me.TabWWW.SuspendLayout()
		Me.ToolStripWWW.SuspendLayout()
		Me.SuspendLayout()
		'
		'StatusZeile
		'
		Me.StatusZeile.Location = New System.Drawing.Point(0, 506)
		Me.StatusZeile.Name = "StatusZeile"
		Me.StatusZeile.Padding = New System.Windows.Forms.Padding(0, 0, 12, 0)
		Me.StatusZeile.Raft = System.Windows.Forms.RaftingSides.None
		Me.StatusZeile.TabIndex = 0
		Me.StatusZeile.Text = "StatusStrip1"
		'
		'mnuMain
		'
		Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDatei, Me.mnuAnsicht, Me.mnuHilfe})
		Me.mnuMain.Location = New System.Drawing.Point(0, 0)
		Me.mnuMain.Name = "mnuMain"
		Me.mnuMain.Padding = New System.Windows.Forms.Padding(6, 2, 0, 2)
		Me.mnuMain.ShowItemToolTips = True
		Me.mnuMain.Size = New System.Drawing.Size(765, 22)
		Me.mnuMain.TabIndex = 0
		Me.mnuMain.Text = "Menu"
		'
		'mnuDatei
		'
		Me.mnuDatei.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDateiBeenden})
		Me.mnuDatei.Name = "mnuDatei"
		Me.mnuDatei.SettingsKey = "frmMain.DateiToolStripMenuItem"
		Me.mnuDatei.Text = "&Datei"
		'
		'mnuDateiBeenden
		'
		Me.mnuDateiBeenden.Name = "mnuDateiBeenden"
		Me.mnuDateiBeenden.SettingsKey = "frmMain.BeendenToolStripMenuItem"
		Me.mnuDateiBeenden.Text = "&Beenden"
		'
		'mnuAnsicht
		'
		Me.mnuAnsicht.Name = "mnuAnsicht"
		Me.mnuAnsicht.SettingsKey = "frmMain.AnsichtToolStripMenuItem"
		Me.mnuAnsicht.Text = "&Ansicht"
		'
		'mnuHilfe
		'
		Me.mnuHilfe.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IndexToolStripMenuItem, Me.ÜberToolStripMenuItem})
		Me.mnuHilfe.Name = "mnuHilfe"
		Me.mnuHilfe.SettingsKey = "frmMain.HilfeToolStripMenuItem"
		Me.mnuHilfe.Text = "&Hilfe"
		'
		'IndexToolStripMenuItem
		'
		Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
		Me.IndexToolStripMenuItem.SettingsKey = "frmMain.IndexToolStripMenuItem"
		Me.IndexToolStripMenuItem.Text = "&Index"
		'
		'ÜberToolStripMenuItem
		'
		Me.ÜberToolStripMenuItem.Name = "ÜberToolStripMenuItem"
		Me.ÜberToolStripMenuItem.SettingsKey = "frmMain.ÜberToolStripMenuItem"
		Me.ÜberToolStripMenuItem.Text = "&Über"
		'
		'Tabs
		'
		Me.Tabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
		Me.Tabs.Controls.Add(Me.TabSpielfelder)
		Me.Tabs.Controls.Add(Me.TabWelten)
		Me.Tabs.Controls.Add(Me.TabLebewesen)
		Me.Tabs.Controls.Add(Me.TabExperimente)
		Me.Tabs.Controls.Add(Me.TabEinstellungen)
		Me.Tabs.Controls.Add(Me.TabSimulationen)
		Me.Tabs.Controls.Add(Me.TabWWW)
		Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Tabs.ImageList = Me.IconListe
		Me.Tabs.ItemSize = New System.Drawing.Size(83, 22)
		Me.Tabs.Location = New System.Drawing.Point(0, 22)
		Me.Tabs.Name = "Tabs"
		Me.Tabs.SelectedIndex = 0
		Me.Tabs.ShowToolTips = True
		Me.Tabs.Size = New System.Drawing.Size(765, 484)
		Me.Tabs.TabIndex = 4
		'
		'TabSpielfelder
		'
		Me.TabSpielfelder.Controls.Add(Me.BlendPanel1)
		Me.TabSpielfelder.ImageIndex = 1
		Me.TabSpielfelder.Location = New System.Drawing.Point(4, 26)
		Me.TabSpielfelder.Name = "TabSpielfelder"
		Me.TabSpielfelder.Padding = New System.Windows.Forms.Padding(3)
		Me.TabSpielfelder.Size = New System.Drawing.Size(757, 454)
		Me.TabSpielfelder.TabIndex = 0
		Me.TabSpielfelder.Text = "Spielfelder"
		'
		'BlendPanel1
		'
		Me.BlendPanel1.Controls.Add(Me.TabControl1)
		Me.BlendPanel1.Controls.Add(Me.TaskPane1)
		Me.BlendPanel1.Location = New System.Drawing.Point(9, 7)
		Me.BlendPanel1.Name = "BlendPanel1"
		Me.BlendPanel1.Size = New System.Drawing.Size(740, 432)
		Me.BlendPanel1.TabIndex = 0
		'
		'TabControl1
		'
		Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
		Me.TabControl1.Controls.Add(Me.TabPage1)
		Me.TabControl1.Controls.Add(Me.TabPage2)
		Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Right
		Me.TabControl1.Location = New System.Drawing.Point(540, 0)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(200, 432)
		Me.TabControl1.TabIndex = 1
		'
		'TabPage1
		'
		Me.TabPage1.BackColor = System.Drawing.SystemColors.InactiveCaption
		Me.TabPage1.Controls.Add(Me.PropertyGrid1)
		Me.TabPage1.Location = New System.Drawing.Point(4, 4)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(192, 406)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "Standard"
		'
		'PropertyGrid1
		'
		Me.PropertyGrid1.CommandsVisibleIfAvailable = True
		Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.PropertyGrid1.Location = New System.Drawing.Point(3, 3)
		Me.PropertyGrid1.Name = "PropertyGrid1"
		Me.PropertyGrid1.SelectedObject = Me.TextBox1
		Me.PropertyGrid1.Size = New System.Drawing.Size(186, 400)
		Me.PropertyGrid1.TabIndex = 0
		'
		'TabPage2
		'
		Me.TabPage2.BackColor = System.Drawing.SystemColors.InactiveCaption
		Me.TabPage2.Controls.Add(Me.PropertyGrid2)
		Me.TabPage2.Location = New System.Drawing.Point(4, 4)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(192, 406)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "Erweitert"
		'
		'PropertyGrid2
		'
		Me.PropertyGrid2.CommandsVisibleIfAvailable = True
		Me.PropertyGrid2.Location = New System.Drawing.Point(37, 66)
		Me.PropertyGrid2.Name = "PropertyGrid2"
		Me.PropertyGrid2.TabIndex = 0
		'
		'TaskPane1
		'
		Me.TaskPane1.AutoScroll = True
		Me.TaskPane1.BackColor = System.Drawing.SystemColors.InactiveCaption
		Me.TaskPane1.Controls.Add(Me.TaskFrame1)
		Me.TaskPane1.Controls.Add(Me.TaskFrame2)
		Me.TaskPane1.Controls.Add(Me.TaskFrame3)
		Me.TaskPane1.CornerStyle = VbPowerPack.TaskFrameCornerStyle.SystemDefault
		Me.TaskPane1.Dock = System.Windows.Forms.DockStyle.Left
		Me.TaskPane1.Location = New System.Drawing.Point(0, 0)
		Me.TaskPane1.Name = "TaskPane1"
		Me.TaskPane1.Size = New System.Drawing.Size(156, 432)
		Me.TaskPane1.TabIndex = 0
		'
		'TaskFrame1
		'
		Me.TaskFrame1.AllowDrop = True
		Me.TaskFrame1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
		Me.TaskFrame1.CaptionHighlightColor = System.Drawing.SystemColors.ActiveCaption
		Me.TaskFrame1.Controls.Add(Me.ListBox1)
		Me.TaskFrame1.Location = New System.Drawing.Point(12, 33)
		Me.TaskFrame1.Name = "TaskFrame1"
		Me.TaskFrame1.Size = New System.Drawing.Size(132, 100)
		Me.TaskFrame1.TabIndex = 1
		Me.TaskFrame1.Text = "Spielfelder"
		'
		'ListBox1
		'
		Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.ListBox1.FormattingEnabled = True
		Me.ListBox1.Items.AddRange(New Object() {"Wasser 15m", "Berg 500m", "Hügel", "Ebene", "Kuhle", "Fütze"})
		Me.ListBox1.Location = New System.Drawing.Point(0, 0)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(132, 95)
		Me.ListBox1.TabIndex = 0
		'
		'TaskFrame2
		'
		Me.TaskFrame2.AllowDrop = True
		Me.TaskFrame2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
		Me.TaskFrame2.CaptionHighlightColor = System.Drawing.SystemColors.ActiveCaption
		Me.TaskFrame2.Controls.Add(Me.TextBox1)
		Me.TaskFrame2.Location = New System.Drawing.Point(12, 166)
		Me.TaskFrame2.Name = "TaskFrame2"
		Me.TaskFrame2.Size = New System.Drawing.Size(132, 100)
		Me.TaskFrame2.TabIndex = 3
		Me.TaskFrame2.Text = "Kommentar"
		'
		'TextBox1
		'
		Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TextBox1.Location = New System.Drawing.Point(0, 0)
		Me.TextBox1.Multiline = True
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(132, 100)
		Me.TextBox1.TabIndex = 0
		Me.TextBox1.Text = "Der editierbare Kommentar, der dem gerade gewählten Objekt zugeordnet wurde. Dies" & _
			"er wird mit dem Objekt gespeichert."
		'
		'TaskFrame3
		'
		Me.TaskFrame3.AllowDrop = True
		Me.TaskFrame3.BackColor = System.Drawing.SystemColors.InactiveCaptionText
		Me.TaskFrame3.CaptionHighlightColor = System.Drawing.SystemColors.ActiveCaption
		Me.TaskFrame3.Controls.Add(Me.TextBox2)
		Me.TaskFrame3.Location = New System.Drawing.Point(12, 299)
		Me.TaskFrame3.Name = "TaskFrame3"
		Me.TaskFrame3.Size = New System.Drawing.Size(132, 100)
		Me.TaskFrame3.TabIndex = 5
		Me.TaskFrame3.Text = "Schnell-Hilfe"
		'
		'TextBox2
		'
		Me.TextBox2.BackColor = System.Drawing.SystemColors.Info
		Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TextBox2.Location = New System.Drawing.Point(0, 0)
		Me.TextBox2.Multiline = True
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.Size = New System.Drawing.Size(132, 100)
		Me.TextBox2.TabIndex = 0
		Me.TextBox2.Text = "Kurze Hilfe für das jeweils gerade gewählte Objekt o.ä."
		'
		'TabWelten
		'
		Me.TabWelten.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.TabWelten.ImageIndex = 0
		Me.TabWelten.Location = New System.Drawing.Point(4, 26)
		Me.TabWelten.Name = "TabWelten"
		Me.TabWelten.Padding = New System.Windows.Forms.Padding(3)
		Me.TabWelten.Size = New System.Drawing.Size(757, 454)
		Me.TabWelten.TabIndex = 1
		Me.TabWelten.Text = "Welten"
		'
		'TabLebewesen
		'
		Me.TabLebewesen.ImageIndex = 2
		Me.TabLebewesen.Location = New System.Drawing.Point(4, 26)
		Me.TabLebewesen.Name = "TabLebewesen"
		Me.TabLebewesen.Size = New System.Drawing.Size(757, 454)
		Me.TabLebewesen.TabIndex = 2
		Me.TabLebewesen.Text = "Lebewesen"
		'
		'TabExperimente
		'
		Me.TabExperimente.Location = New System.Drawing.Point(4, 26)
		Me.TabExperimente.Name = "TabExperimente"
		Me.TabExperimente.Size = New System.Drawing.Size(757, 454)
		Me.TabExperimente.TabIndex = 3
		Me.TabExperimente.Text = "Experimente"
		'
		'TabEinstellungen
		'
		Me.TabEinstellungen.Location = New System.Drawing.Point(4, 26)
		Me.TabEinstellungen.Name = "TabEinstellungen"
		Me.TabEinstellungen.Size = New System.Drawing.Size(757, 454)
		Me.TabEinstellungen.TabIndex = 4
		Me.TabEinstellungen.Text = "Einstellungen"
		'
		'TabSimulationen
		'
		Me.TabSimulationen.Location = New System.Drawing.Point(4, 26)
		Me.TabSimulationen.Name = "TabSimulationen"
		Me.TabSimulationen.Size = New System.Drawing.Size(757, 454)
		Me.TabSimulationen.TabIndex = 5
		Me.TabSimulationen.Text = "Simulationen"
		'
		'TabWWW
		'
		Me.TabWWW.Controls.Add(Me.ToolStripWWW)
		Me.TabWWW.Controls.Add(Me.WWWWBrowser)
		Me.TabWWW.ImageIndex = 4
		Me.TabWWW.Location = New System.Drawing.Point(4, 26)
		Me.TabWWW.Name = "TabWWW"
		Me.TabWWW.Size = New System.Drawing.Size(757, 454)
		Me.TabWWW.TabIndex = 6
		Me.TabWWW.Text = "WWW"
		'
		'ToolStripWWW
		'
		Me.ToolStripWWW.ImageList = Me.IconListe
		Me.ToolStripWWW.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
		Me.ToolStripWWW.Location = New System.Drawing.Point(0, 0)
		Me.ToolStripWWW.Name = "ToolStripWWW"
		Me.ToolStripWWW.Raft = System.Windows.Forms.RaftingSides.None
		Me.ToolStripWWW.Size = New System.Drawing.Size(757, 22)
		Me.ToolStripWWW.TabIndex = 2
		Me.ToolStripWWW.Text = "ToolStripWWW"
		'
		'IconListe
		'
		Me.IconListe.ImageSize = New System.Drawing.Size(16, 16)
		Me.IconListe.ImageStream = CType(resources.GetObject("IconListe.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.IconListe.TransparentColor = System.Drawing.Color.Transparent
		Me.IconListe.Images.SetKeyName(0, "Welten.ico")
		Me.IconListe.Images.SetKeyName(1, "spielfelder.ico")
		Me.IconListe.Images.SetKeyName(2, "lebewesen.ico")
		Me.IconListe.Images.SetKeyName(3, "home.gif")
		Me.IconListe.Images.SetKeyName(4, "home.ico")
		'
		'ToolStripButton1
		'
		Me.ToolStripButton1.ImageIndex = 3
		Me.ToolStripButton1.Name = "ToolStripButton1"
		Me.ToolStripButton1.SettingsKey = "frmMain.ToolStripButton1"
		Me.ToolStripButton1.Text = "Home"
		'
		'WWWWBrowser
		'
		Me.WWWWBrowser.Dock = System.Windows.Forms.DockStyle.Fill
		Me.WWWWBrowser.Location = New System.Drawing.Point(0, 0)
		Me.WWWWBrowser.Name = "WWWWBrowser"
		Me.WWWWBrowser.Size = New System.Drawing.Size(757, 454)
		Me.WWWWBrowser.TabIndex = 1
		Me.WWWWBrowser.Url = "http://developer.berlios.de/projects/evolutionoflife/"
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(765, 525)
		Me.Controls.Add(Me.Tabs)
		Me.Controls.Add(Me.mnuMain)
		Me.Controls.Add(Me.StatusZeile)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmMain"
		Me.Text = "Evolution des Lebens"
		Me.mnuMain.ResumeLayout(False)
		Me.Tabs.ResumeLayout(False)
		Me.TabSpielfelder.ResumeLayout(False)
		Me.BlendPanel1.ResumeLayout(False)
		Me.TabControl1.ResumeLayout(False)
		Me.TabPage1.ResumeLayout(False)
		Me.TabPage2.ResumeLayout(False)
		Me.TaskPane1.ResumeLayout(False)
		Me.TaskFrame1.ResumeLayout(False)
		Me.TaskFrame2.ResumeLayout(False)
		Me.TaskFrame2.PerformLayout()
		Me.TaskFrame3.ResumeLayout(False)
		Me.TaskFrame3.PerformLayout()
		Me.TabWWW.ResumeLayout(False)
		Me.TabWWW.PerformLayout()
		Me.ToolStripWWW.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents StatusZeile As System.Windows.Forms.StatusStrip
	Friend WithEvents Tabs As System.Windows.Forms.TabControl
	Friend WithEvents TabWelten As System.Windows.Forms.TabPage
	Friend WithEvents TabSpielfelder As System.Windows.Forms.TabPage
	Friend WithEvents TabLebewesen As System.Windows.Forms.TabPage
	Friend WithEvents TabExperimente As System.Windows.Forms.TabPage
	Friend WithEvents TabEinstellungen As System.Windows.Forms.TabPage
	Friend WithEvents TabSimulationen As System.Windows.Forms.TabPage
	Friend WithEvents IconListe As System.Windows.Forms.ImageList
	Friend WithEvents TabWWW As System.Windows.Forms.TabPage
	Friend WithEvents WWWWBrowser As System.Windows.Forms.WebBrowser
	Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
	Friend WithEvents mnuDatei As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuDateiBeenden As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuAnsicht As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuHilfe As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripWWW As System.Windows.Forms.ToolStrip
	Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
	Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
	Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
	Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
	Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
	Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
	Friend WithEvents PropertyGrid2 As System.Windows.Forms.PropertyGrid
	Friend WithEvents TaskPane1 As VbPowerPack.TaskPane
	Friend WithEvents TaskFrame1 As VbPowerPack.TaskFrame
	Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
	Friend WithEvents TaskFrame2 As VbPowerPack.TaskFrame
	Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
	Friend WithEvents TaskFrame3 As VbPowerPack.TaskFrame
	Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
	Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ÜberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
