Public Interface IHistoryViewPlugin
    Sub LoadData(ByVal historyData As HistoryData)
    Sub UnloadData()
    ReadOnly Property IsDataLoaded() As Boolean
    ReadOnly Property MyTitle() As String
    Event UpdateStatus(ByVal statusText As String)
End Interface
