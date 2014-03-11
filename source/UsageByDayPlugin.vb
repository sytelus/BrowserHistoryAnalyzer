Imports Dundas.Charting.WinControl
Imports System.Data

Public Class UsageByDayPlugin
    Implements IHistoryViewPlugin


    Public ReadOnly Property IsDataLoaded() As Boolean Implements IHistoryViewPlugin.IsDataLoaded
        Get
            Return Chart1.Series.Count > 0
        End Get
    End Property

    Private Sub PaintChart()
        RaiseEvent UpdateStatus("Updating chart...")

        Chart1.Series.Clear()
        Dim mainSeries As Series = Chart1.Series.Add("Main")
        mainSeries.ChartType = "Spline"

        mainSeries.MarkerStyle = MarkerStyle.Circle

        Chart1.ChartAreas("Default").AxisY.Maximum = Double.NaN
        Chart1.ChartAreas("Default").AxisY.Minimum = Double.NaN

        Dim yColumnName As String = ""
        Select Case chartDataCategoryToolStripComboBox.SelectedIndex
            Case 0  'Total visits
                mainSeries.Points.DataBindXY(m_UsageByDayData.DefaultView, "Day", m_UsageByDayData.DefaultView, "TotalVisitCount")
            Case 1  'Unique Urls
                mainSeries.Points.DataBindXY(m_UsageByDayData.DefaultView, "Day", m_UsageByDayData.DefaultView, "UniqueUrlVisitCount")
            Case 2  'Time spent
                mainSeries.Points.DataBindXY(m_UsageByDayData.DefaultView, "Day", m_UsageByDayData.DefaultView, "MinutesSpentInVisits")
            Case Else
                MsgBox("This category is not yet implemented")
        End Select

        'Force re-calc of Y-Maxima
        Chart1.ChartAreas("Default").ReCalc()

        RaiseEvent UpdateStatus("Chart Done")

    End Sub

    Private m_UsageByDayData As System.Data.DataTable
    Public Sub LoadData(ByVal historyData As HistoryData) Implements IHistoryViewPlugin.LoadData
        m_UsageByDayData = historyData.DefaultStatisticsProcessor.UsageByDay

        If chartDataCategoryToolStripComboBox.SelectedIndex < 0 Then
            chartDataCategoryToolStripComboBox.SelectedIndex = 0
        End If
    End Sub

    Public ReadOnly Property MyTitle() As String Implements IHistoryViewPlugin.MyTitle
        Get
            Return "Usage Chart"
        End Get
    End Property

    Public Sub UnloadData() Implements IHistoryViewPlugin.UnloadData
        Chart1.Series.Clear()
    End Sub

    Public Event UpdateStatus(ByVal statusText As String) Implements IHistoryViewPlugin.UpdateStatus

    Private Sub chartDataCategoryToolStripComboBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chartDataCategoryToolStripComboBox.Click

    End Sub

    Private Sub chartDataCategoryToolStripComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chartDataCategoryToolStripComboBox.SelectedIndexChanged
        PaintChart()
    End Sub
End Class
