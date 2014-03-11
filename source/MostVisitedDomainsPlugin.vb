Public Class MostVisitedDomainsPlugin
    Implements IHistoryViewPlugin


    Public ReadOnly Property IsDataLoaded() As Boolean Implements IHistoryViewPlugin.IsDataLoaded
        Get
            Return Not (DataGridView1.DataSource Is Nothing)
        End Get
    End Property

    Public Sub LoadData(ByVal historyData As HistoryData) Implements IHistoryViewPlugin.LoadData
        historyData.DefaultStatisticsProcessor.UniqueDomains.DefaultView.Sort = "VisitCount DESC"
        DataGridView1.DataSource = historyData.DefaultStatisticsProcessor.UniqueDomains.DefaultView
    End Sub

    Public ReadOnly Property MyTitle() As String Implements IHistoryViewPlugin.MyTitle
        Get
            Return "Most Visited Domains"
        End Get
    End Property

    Public Sub UnloadData() Implements IHistoryViewPlugin.UnloadData
        DataGridView1.DataSource = Nothing
    End Sub

    Public Event UpdateStatus(ByVal statusText As String) Implements IHistoryViewPlugin.UpdateStatus
End Class
