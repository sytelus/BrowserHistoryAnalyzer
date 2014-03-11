Public Class HistoryViewPlugin
    Implements IHistoryViewPlugin


    Public Sub LoadData(ByVal historyData As HistoryData) Implements IHistoryViewPlugin.LoadData
        HistoryDataGridView.DataSource = historyData.HistoryTable
        RaiseEvent UpdateStatus(historyData.HistoryTable.Rows.Count.ToString + " recors")
    End Sub

    Public Sub UnloadData() Implements IHistoryViewPlugin.UnloadData
        HistoryDataGridView.DataSource = Nothing
    End Sub

    Public Event UpdateStatus(ByVal statusText As String) Implements IHistoryViewPlugin.UpdateStatus

    Public ReadOnly Property MyTitle() As String Implements IHistoryViewPlugin.MyTitle
        Get
            Return "History Data"
        End Get
    End Property

    Public ReadOnly Property IsDataLoaded() As Boolean Implements IHistoryViewPlugin.IsDataLoaded
        Get
            Return Not (HistoryDataGridView.DataSource Is Nothing)
        End Get
    End Property
End Class
