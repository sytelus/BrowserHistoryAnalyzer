Public Class NoDataPlugin
    Implements IHistoryViewPlugin



    Public Sub LoadData(ByVal historyData As HistoryData) Implements IHistoryViewPlugin.LoadData

    End Sub

    Public ReadOnly Property MyTitle() As String Implements IHistoryViewPlugin.MyTitle
        Get
            Return "No Data Loaded"
        End Get
    End Property

    Public Sub UnloadData() Implements IHistoryViewPlugin.UnloadData

    End Sub

    Public Event UpdateStatus(ByVal statusText As String) Implements IHistoryViewPlugin.UpdateStatus

    Public ReadOnly Property IsDataLoaded() As Boolean Implements IHistoryViewPlugin.IsDataLoaded
        Get

        End Get
    End Property
End Class
