Partial Public Class HistoryViewPlugin
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
        Me.HistoryDataGridView = New System.Windows.Forms.DataGridView
        CType(Me.HistoryDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HistoryDataGridView
        '
        Me.HistoryDataGridView.AllowUserToAddRows = False
        Me.HistoryDataGridView.AllowUserToOrderColumns = True
        Me.HistoryDataGridView.BackgroundColor = System.Drawing.Color.Tan
        Me.HistoryDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.SaddleBrown
        Me.HistoryDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.OldLace
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.HistoryDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.HistoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HistoryDataGridView.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.HistoryDataGridView.GridColor = System.Drawing.Color.Tan
        Me.HistoryDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.HistoryDataGridView.Name = "HistoryDataGridView"
        Me.HistoryDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.HistoryDataGridView.Size = New System.Drawing.Size(541, 329)
        Me.HistoryDataGridView.TabIndex = 1
        '
        'HistoryView
        '
        Me.Controls.Add(Me.HistoryDataGridView)
        Me.Name = "HistoryView"
        Me.Size = New System.Drawing.Size(541, 329)
        CType(Me.HistoryDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HistoryDataGridView As System.Windows.Forms.DataGridView

End Class
