Partial Public Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DBFileOpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.HistoryReaderWorker = New System.ComponentModel.BackgroundWorker
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.StatusStripPanel1 = New System.Windows.Forms.StatusStripPanel
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.leftRaftingContainer = New System.Windows.Forms.RaftingContainer
        Me.leftRaftingContainer1 = New System.Windows.Forms.RaftingContainer
        Me.topRaftingContainer = New System.Windows.Forms.RaftingContainer
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.readHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mergeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.updateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.updateAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.openFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.unloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ManageSettingsFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.SelectPluginToolStripMenuItem = New System.Windows.Forms.ToolStripComboBox
        Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GotoHomepageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SendCommentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.bottomRaftingContainer = New System.Windows.Forms.RaftingContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PluginTabs = New System.Windows.Forms.TabControl
        Me.DBFileSaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.LoadOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.saveSettingsFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.openSettingsFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.DeleteOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1.SuspendLayout()
        CType(Me.leftRaftingContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leftRaftingContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.topRaftingContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.topRaftingContainer.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.bottomRaftingContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bottomRaftingContainer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DBFileOpenFileDialog
        '
        Me.DBFileOpenFileDialog.DefaultExt = "mdb"
        Me.DBFileOpenFileDialog.Title = "Locate Access Database File"
        '
        'HistoryReaderWorker
        '
        Me.HistoryReaderWorker.WorkerReportsProgress = True
        Me.HistoryReaderWorker.WorkerSupportsCancellation = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusStripPanel1, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 12, 0)
        Me.StatusStrip1.Raft = System.Windows.Forms.RaftingSides.Bottom
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusStripPanel1
        '
        Me.StatusStripPanel1.AutoToolTip = True
        Me.StatusStripPanel1.Name = "StatusStripPanel1"
        Me.StatusStripPanel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.StatusStripPanel1.SettingsKey = "Form1.StatusStripPanel1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Tail
        Me.ToolStripProgressBar1.AutoSize = False
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.SettingsKey = "Form1.ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ToolStripProgressBar1.Text = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Visible = False
        '
        'leftRaftingContainer
        '
        Me.leftRaftingContainer.Dock = System.Windows.Forms.DockStyle.Left
        Me.leftRaftingContainer.Name = "leftRaftingContainer"
        '
        'leftRaftingContainer1
        '
        Me.leftRaftingContainer1.Dock = System.Windows.Forms.DockStyle.Left
        Me.leftRaftingContainer1.Name = "leftRaftingContainer1"
        '
        'topRaftingContainer
        '
        Me.topRaftingContainer.Controls.Add(Me.MenuStrip1)
        Me.topRaftingContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.topRaftingContainer.Name = "topRaftingContainer"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowItemReorder = True
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.toolsToolStripMenuItem, Me.helpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(6, 2, 0, 2)
        Me.MenuStrip1.Raft = System.Windows.Forms.RaftingSides.Top
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.readHistoryToolStripMenuItem, Me.ToolStripSeparator3, Me.openToolStripMenuItem, Me.mergeToolStripMenuItem, Me.updateToolStripMenuItem, Me.updateAsToolStripMenuItem, Me.ToolStripSeparator4, Me.openFolderToolStripMenuItem, Me.ToolStripSeparator1, Me.unloadToolStripMenuItem, Me.exitToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.SettingsKey = "Form1.fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Text = "&File"
        '
        'readHistoryToolStripMenuItem
        '
        Me.readHistoryToolStripMenuItem.Name = "readHistoryToolStripMenuItem"
        Me.readHistoryToolStripMenuItem.SettingsKey = "Form1.ToolStripMenuItem1"
        Me.readHistoryToolStripMenuItem.Text = "Read History..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.SettingsKey = "Form1.ToolStripSeparator3"
        '
        'openToolStripMenuItem
        '
        Me.openToolStripMenuItem.Image = CType(resources.GetObject("openToolStripMenuItem.Image"), System.Drawing.Image)
        Me.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Lime
        Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
        Me.openToolStripMenuItem.SettingsKey = "Form1.openToolStripMenuItem"
        Me.openToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.openToolStripMenuItem.Text = "Open..."
        Me.openToolStripMenuItem.ToolTipText = "Open Access database where you have stored history data from Internet Explorer"
        '
        'mergeToolStripMenuItem
        '
        Me.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem"
        Me.mergeToolStripMenuItem.SettingsKey = "Form1.ToolStripMenuItem1"
        Me.mergeToolStripMenuItem.Text = "Merge..."
        Me.mergeToolStripMenuItem.ToolTipText = "Merge history data from another database to current database"
        '
        'updateToolStripMenuItem
        '
        Me.updateToolStripMenuItem.Name = "updateToolStripMenuItem"
        Me.updateToolStripMenuItem.SettingsKey = "Form1.ToolStripMenuItem1"
        Me.updateToolStripMenuItem.Text = "Save"
        Me.updateToolStripMenuItem.ToolTipText = "Read current IE history and update the database"
        '
        'updateAsToolStripMenuItem
        '
        Me.updateAsToolStripMenuItem.Name = "updateAsToolStripMenuItem"
        Me.updateAsToolStripMenuItem.SettingsKey = "Form1.ToolStripMenuItem1"
        Me.updateAsToolStripMenuItem.Text = "Save As..."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.SettingsKey = "Form1.ToolStripSeparator4"
        '
        'openFolderToolStripMenuItem
        '
        Me.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem"
        Me.openFolderToolStripMenuItem.SettingsKey = "Form1.ToolStripMenuItem2"
        Me.openFolderToolStripMenuItem.Text = "Open Containing Folder..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.SettingsKey = "Form1.ToolStripSeparator1"
        '
        'unloadToolStripMenuItem
        '
        Me.unloadToolStripMenuItem.Name = "unloadToolStripMenuItem"
        Me.unloadToolStripMenuItem.SettingsKey = "Form1.ToolStripMenuItem1"
        Me.unloadToolStripMenuItem.Text = "Unload data"
        '
        'exitToolStripMenuItem
        '
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.SettingsKey = "Form1.exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Text = "E&xit"
        '
        'toolsToolStripMenuItem
        '
        Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ToolStripSeparator5, Me.ManageSettingsFileToolStripMenuItem, Me.ToolStripSeparator6, Me.SelectPluginToolStripMenuItem})
        Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
        Me.toolsToolStripMenuItem.SettingsKey = "Form1.toolsToolStripMenuItem"
        Me.toolsToolStripMenuItem.Text = "&Tools"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.SettingsKey = "Form1.ToolStripMenuItem1"
        Me.OptionsToolStripMenuItem.Text = "Options..."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.SettingsKey = "Form1.ToolStripSeparator5"
        '
        'ManageSettingsFileToolStripMenuItem
        '
        Me.ManageSettingsFileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveOptionsToolStripMenuItem, Me.LoadOptionsToolStripMenuItem, Me.ToolStripSeparator2, Me.DeleteOptionsToolStripMenuItem})
        Me.ManageSettingsFileToolStripMenuItem.Name = "ManageSettingsFileToolStripMenuItem"
        Me.ManageSettingsFileToolStripMenuItem.SettingsKey = "Form1.ToolStripMenuItem1"
        Me.ManageSettingsFileToolStripMenuItem.Text = "Manage Settings File"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.SettingsKey = "Form1.ToolStripSeparator6"
        '
        'SelectPluginToolStripMenuItem
        '
        Me.SelectPluginToolStripMenuItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SelectPluginToolStripMenuItem.Name = "SelectPluginToolStripMenuItem"
        Me.SelectPluginToolStripMenuItem.SettingsKey = "Form1.ToolStripComboBox1"
        Me.SelectPluginToolStripMenuItem.Size = New System.Drawing.Size(100, 21)
        '
        'helpToolStripMenuItem
        '
        Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GotoHomepageToolStripMenuItem, Me.SendCommentsToolStripMenuItem, Me.ToolStripSeparator7, Me.aboutToolStripMenuItem})
        Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
        Me.helpToolStripMenuItem.SettingsKey = "Form1.helpToolStripMenuItem"
        Me.helpToolStripMenuItem.Text = "&Help"
        '
        'GotoHomepageToolStripMenuItem
        '
        Me.GotoHomepageToolStripMenuItem.Name = "GotoHomepageToolStripMenuItem"
        Me.GotoHomepageToolStripMenuItem.SettingsKey = "Form1.ToolStripMenuItem1"
        Me.GotoHomepageToolStripMenuItem.Text = "Visit Internet Homepage..."
        '
        'SendCommentsToolStripMenuItem
        '
        Me.SendCommentsToolStripMenuItem.Name = "SendCommentsToolStripMenuItem"
        Me.SendCommentsToolStripMenuItem.SettingsKey = "Form1.ToolStripMenuItem1"
        Me.SendCommentsToolStripMenuItem.Text = "Send your comments..."
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.SettingsKey = "Form1.ToolStripSeparator7"
        '
        'aboutToolStripMenuItem
        '
        Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
        Me.aboutToolStripMenuItem.SettingsKey = "Form1.aboutToolStripMenuItem"
        Me.aboutToolStripMenuItem.Text = "&About..."
        '
        'bottomRaftingContainer
        '
        Me.bottomRaftingContainer.Controls.Add(Me.StatusStrip1)
        Me.bottomRaftingContainer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottomRaftingContainer.Name = "bottomRaftingContainer"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PluginTabs)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(572, 284)
        Me.Panel1.TabIndex = 13
        '
        'PluginTabs
        '
        Me.PluginTabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PluginTabs.Location = New System.Drawing.Point(0, 0)
        Me.PluginTabs.Name = "PluginTabs"
        Me.PluginTabs.SelectedIndex = 0
        Me.PluginTabs.Size = New System.Drawing.Size(572, 284)
        Me.PluginTabs.TabIndex = 14
        '
        'DBFileSaveFileDialog
        '
        Me.DBFileSaveFileDialog.DefaultExt = "mdb"
        Me.DBFileSaveFileDialog.Title = "Locate Access Database File"
        '
        'LoadOptionsToolStripMenuItem
        '
        Me.LoadOptionsToolStripMenuItem.Name = "LoadOptionsToolStripMenuItem"
        Me.LoadOptionsToolStripMenuItem.SettingsKey = "Form1.ToolStripMenuItem1"
        Me.LoadOptionsToolStripMenuItem.Text = "Restore Settings File..."
        '
        'SaveOptionsToolStripMenuItem
        '
        Me.SaveOptionsToolStripMenuItem.Name = "SaveOptionsToolStripMenuItem"
        Me.SaveOptionsToolStripMenuItem.SettingsKey = "Form1.ToolStripMenuItem1"
        Me.SaveOptionsToolStripMenuItem.Text = "Backup Settings File..."
        '
        'saveSettingsFileDialog
        '
        Me.saveSettingsFileDialog.DefaultExt = "config.npx"
        Me.saveSettingsFileDialog.FileName = "notepadx_settings_backup"
        Me.saveSettingsFileDialog.Filter = "NotepadX Settings files (*.config.npx)|*.config.npx|All files (*.*)|*.*"
        '
        'openSettingsFileDialog
        '
        Me.openSettingsFileDialog.DefaultExt = "config.npx"
        Me.openSettingsFileDialog.Filter = "NotepadX Settings files (*.config.npx)|*.config.npx|All files (*.*)|*.*"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.SettingsKey = "Form1.ToolStripSeparator2"
        '
        'DeleteOptionsToolStripMenuItem
        '
        Me.DeleteOptionsToolStripMenuItem.Name = "DeleteOptionsToolStripMenuItem"
        Me.DeleteOptionsToolStripMenuItem.SettingsKey = "Form1.ToolStripMenuItem1"
        Me.DeleteOptionsToolStripMenuItem.Text = "Delete Settings File..."
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(572, 324)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.leftRaftingContainer)
        Me.Controls.Add(Me.leftRaftingContainer1)
        Me.Controls.Add(Me.topRaftingContainer)
        Me.Controls.Add(Me.bottomRaftingContainer)
        Me.Name = "Form1"
        Me.Text = "Browser History Analyser"
        Me.StatusStrip1.ResumeLayout(False)
        CType(Me.leftRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leftRaftingContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.topRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.topRaftingContainer.ResumeLayout(False)
        Me.topRaftingContainer.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        CType(Me.bottomRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bottomRaftingContainer.ResumeLayout(False)
        Me.bottomRaftingContainer.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DBFileOpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents HistoryReaderWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents leftRaftingContainer As System.Windows.Forms.RaftingContainer
    Friend WithEvents leftRaftingContainer1 As System.Windows.Forms.RaftingContainer
    Friend WithEvents topRaftingContainer As System.Windows.Forms.RaftingContainer
    Friend WithEvents bottomRaftingContainer As System.Windows.Forms.RaftingContainer
    Friend WithEvents StatusStripPanel1 As System.Windows.Forms.StatusStripPanel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents updateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mergeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents readHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PluginTabs As System.Windows.Forms.TabControl
    Friend WithEvents updateAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DBFileSaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents unloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectPluginToolStripMenuItem As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents SendCommentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GotoHomepageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ManageSettingsFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents saveSettingsFileDialog As System.Windows.Forms.SaveFileDialog
    Private WithEvents openSettingsFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
