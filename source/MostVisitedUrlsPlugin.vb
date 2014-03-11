Public Class MostVisitedUrlsPlugin
    Implements IHistoryViewPlugin


    Public ReadOnly Property IsDataLoaded() As Boolean Implements IHistoryViewPlugin.IsDataLoaded
        Get
            Return Not (DataGridView1.DataSource Is Nothing)
        End Get
    End Property

    Public Sub LoadData(ByVal historyData As HistoryData) Implements IHistoryViewPlugin.LoadData
        historyData.DefaultStatisticsProcessor.UniqueUrls.DefaultView.Sort = "VisitCount DESC"
        DataGridView1.DataSource = historyData.DefaultStatisticsProcessor.UniqueUrls.DefaultView
    End Sub

    Public ReadOnly Property MyTitle() As String Implements IHistoryViewPlugin.MyTitle
        Get
            Return "Visit Counts"
        End Get
    End Property

    Public Sub UnloadData() Implements IHistoryViewPlugin.UnloadData
        DataGridView1.DataSource = Nothing
    End Sub

    Public Event UpdateStatus(ByVal statusText As String) Implements IHistoryViewPlugin.UpdateStatus
End Class
