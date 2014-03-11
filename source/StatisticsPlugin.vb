Public Class StatisticsPlugin
    Implements IHistoryViewPlugin

    Dim m_IsLoaded As Boolean = False
    Public ReadOnly Property IsDataLoaded() As Boolean Implements IHistoryViewPlugin.IsDataLoaded
        Get
            Return m_IsLoaded
        End Get
    End Property

    Public Sub LoadData(ByVal historyData As HistoryData) Implements IHistoryViewPlugin.LoadData
        m_IsLoaded = True
        'Do statistics
        RaiseEvent UpdateStatus("Calculating statistics...")

        PropertyGrid1.SelectedObject = historyData.DefaultStatisticsProcessor

        RaiseEvent UpdateStatus("Statistics data ready")
    End Sub

    Public ReadOnly Property MyTitle() As String Implements IHistoryViewPlugin.MyTitle
        Get
            Return "Statistics"
        End Get
    End Property

    Public Sub UnloadData() Implements IHistoryViewPlugin.UnloadData
        m_IsLoaded = False
        PropertyGrid1.SelectedObject = Nothing
    End Sub

    Public Event UpdateStatus(ByVal statusText As String) Implements IHistoryViewPlugin.UpdateStatus
End Class


'TODO: 
'1. Most visited URLs
'2. Most Stickiest URLs - Most URLs time spent on
'3. Visits/day graphs, Urls/day graphs
'4. Top domains