Partial Public Class SearchQueriesPlugin
    Inherits System.Windows.Forms.UserControl

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GoogleQueriesToolStrip = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.SearchQueriesFilterTextBox = New System.Windows.Forms.ToolStripTextBox
        Me.SearchQuerySearchButton = New System.Windows.Forms.ToolStripButton
        Me.SearchQueriesDataGridView = New System.Windows.Forms.DataGridView
        Me.GoogleQueriesToolStrip.SuspendLayout()
        CType(Me.SearchQueriesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GoogleQueriesToolStrip
        '
        Me.GoogleQueriesToolStrip.AllowItemReorder = True
        Me.GoogleQueriesToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.SearchQueriesFilterTextBox, Me.SearchQuerySearchButton})
        Me.GoogleQueriesToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.GoogleQueriesToolStrip.Name = "GoogleQueriesToolStrip"
        Me.GoogleQueriesToolStrip.Raft = System.Windows.Forms.RaftingSides.None
        Me.GoogleQueriesToolStrip.Size = New System.Drawing.Size(509, 24)
        Me.GoogleQueriesToolStrip.TabIndex = 3
        Me.GoogleQueriesToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.SettingsKey = "Form1.ToolStripLabel1"
        Me.ToolStripLabel1.Text = "Filter for:"
        '
        'SearchQueriesFilterTextBox
        '
        Me.SearchQueriesFilterTextBox.AcceptsReturn = True
        Me.SearchQueriesFilterTextBox.Name = "SearchQueriesFilterTextBox"
        Me.SearchQueriesFilterTextBox.SettingsKey = "Form1.ToolStripTextBox1"
        Me.SearchQueriesFilterTextBox.Size = New System.Drawing.Size(100, 24)
        '
        'SearchQuerySearchButton
        '
        Me.SearchQuerySearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SearchQuerySearchButton.Image = BrowserHistoryAnalyser.My.Resources.MyResources.filter1
        Me.SearchQuerySearchButton.Name = "SearchQuerySearchButton"
        Me.SearchQuerySearchButton.SettingsKey = "Form1.ToolStripButton1"
        Me.SearchQuerySearchButton.ToolTipText = "Filter rows with search phrase"
        '
        'SearchQueriesDataGridView
        '
        Me.SearchQueriesDataGridView.AllowUserToOrderColumns = True
        Me.SearchQueriesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.HeaderAndColumnsDisplayedRows
        Me.SearchQueriesDataGridView.BackgroundColor = System.Drawing.Color.Lavender
        Me.SearchQueriesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Lavender
        Me.SearchQueriesDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SearchQueriesDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.SearchQueriesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SearchQueriesDataGridView.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.SearchQueriesDataGridView.GridColor = System.Drawing.Color.RoyalBlue
        Me.SearchQueriesDataGridView.Location = New System.Drawing.Point(0, 24)
        Me.SearchQueriesDataGridView.Name = "SearchQueriesDataGridView"
        Me.SearchQueriesDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.SearchQueriesDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SearchQueriesDataGridView.Size = New System.Drawing.Size(509, 314)
        Me.SearchQueriesDataGridView.TabIndex = 2
        '
        'SearchQueriesView
        '
        Me.Controls.Add(Me.SearchQueriesDataGridView)
        Me.Controls.Add(Me.GoogleQueriesToolStrip)
        Me.Name = "SearchQueriesView"
        Me.Size = New System.Drawing.Size(509, 338)
        Me.GoogleQueriesToolStrip.ResumeLayout(False)
        Me.GoogleQueriesToolStrip.PerformLayout()
        CType(Me.SearchQueriesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GoogleQueriesToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SearchQueriesFilterTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents SearchQuerySearchButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SearchQueriesDataGridView As System.Windows.Forms.DataGridView
End Class
