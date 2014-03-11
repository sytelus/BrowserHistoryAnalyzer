Partial Public Class UsageByDayPlugin
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
        Dim ChartArea1 As Dundas.Charting.WinControl.ChartArea = New Dundas.Charting.WinControl.ChartArea
        Dim Series1 As Dundas.Charting.WinControl.Series = New Dundas.Charting.WinControl.Series
        Me.Chart1 = New Dundas.Charting.WinControl.Chart
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.chartDataCategoryToolStripComboBox = New System.Windows.Forms.ToolStripComboBox
        Me.leftRaftingContainer = New System.Windows.Forms.RaftingContainer
        Me.leftRaftingContainer1 = New System.Windows.Forms.RaftingContainer
        Me.topRaftingContainer = New System.Windows.Forms.RaftingContainer
        Me.bottomRaftingContainer = New System.Windows.Forms.RaftingContainer
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.leftRaftingContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leftRaftingContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.topRaftingContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.topRaftingContainer.SuspendLayout()
        CType(Me.bottomRaftingContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        Me.Chart1.BorderSkin.PageColor = System.Drawing.SystemColors.Control
        Me.Chart1.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss
        ChartArea1.Area3DStyle.Light = Dundas.Charting.WinControl.LightStyle.Realistic
        ChartArea1.AxisX.LabelStyle.Format = "M"
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.Title = "Dates"
        ChartArea1.Name = "Default"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.ChartData = ""
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart1.Enabled = False
        Me.Chart1.Legend.Alignment = System.Drawing.StringAlignment.Center
        Me.Chart1.Legend.Docking = Dundas.Charting.WinControl.LegendDocking.Bottom
        Me.Chart1.Legend.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row
        Me.Chart1.Location = New System.Drawing.Point(0, 25)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = Dundas.Charting.WinControl.ChartColorPalette.Pastel
        Series1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Series1.BorderWidth = 2
        Series1.ChartType = "100%StackedArea"
        Series1.Name = "Main"
        Series1.ShadowOffset = 1
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(659, 436)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.chartDataCategoryToolStripComboBox})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Raft = System.Windows.Forms.RaftingSides.Top
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.SettingsKey = "UsageByDayPlugin.ToolStripLabel1"
        Me.ToolStripLabel1.Text = "Choose: "
        '
        'chartDataCategoryToolStripComboBox
        '
        Me.chartDataCategoryToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.chartDataCategoryToolStripComboBox.Items.AddRange(New Object() {"Total Visits", "Unique Urls", "Time Spent"})
        Me.chartDataCategoryToolStripComboBox.Name = "chartDataCategoryToolStripComboBox"
        Me.chartDataCategoryToolStripComboBox.SettingsKey = "UsageByDayPlugin.ToolStripComboBox1"
        Me.chartDataCategoryToolStripComboBox.Size = New System.Drawing.Size(100, 25)
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
        Me.topRaftingContainer.Controls.Add(Me.ToolStrip1)
        Me.topRaftingContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.topRaftingContainer.Name = "topRaftingContainer"
        '
        'bottomRaftingContainer
        '
        Me.bottomRaftingContainer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottomRaftingContainer.Name = "bottomRaftingContainer"
        '
        'UsageByDayPlugin
        '
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.leftRaftingContainer)
        Me.Controls.Add(Me.leftRaftingContainer1)
        Me.Controls.Add(Me.topRaftingContainer)
        Me.Controls.Add(Me.bottomRaftingContainer)
        Me.Name = "UsageByDayPlugin"
        Me.Size = New System.Drawing.Size(659, 461)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        CType(Me.leftRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leftRaftingContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.topRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.topRaftingContainer.ResumeLayout(False)
        Me.topRaftingContainer.PerformLayout()
        CType(Me.bottomRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart1 As Dundas.Charting.WinControl.Chart
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents leftRaftingContainer As System.Windows.Forms.RaftingContainer
    Friend WithEvents leftRaftingContainer1 As System.Windows.Forms.RaftingContainer
    Friend WithEvents topRaftingContainer As System.Windows.Forms.RaftingContainer
    Friend WithEvents bottomRaftingContainer As System.Windows.Forms.RaftingContainer
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents chartDataCategoryToolStripComboBox As System.Windows.Forms.ToolStripComboBox

End Class
