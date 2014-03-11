Imports Shell32
Imports System.Data.OleDb
Imports System.Data

Imports System.Text
Imports System.Text.RegularExpressions
Public Class HistoryData

    Public Event UpdateProgress(ByVal minProgressValue As Double, ByVal maxProgressValue As Double, ByVal currentProgressValue As Double, ByVal progressDetail As String, ByVal taskFinished As Boolean)
    Public Event DataLoaded()

    Dim m_historyData As Data.DataSet
    Dim m_historyDataView As DataView

    Private m_HistoryTable As DataTable = Nothing
    Public ReadOnly Property HistoryTable() As DataTable
        Get
            Return m_HistoryTable
        End Get
    End Property

    Dim m_LastReadDbFilePath As String = ""
    Public ReadOnly Property LastReadDbFilePath() As String
        Get
            Return m_LastReadDbFilePath
        End Get
    End Property

    Public Sub SaveToFile()
        SaveToFile(m_LastReadDbFilePath)
    End Sub

    Public Sub SaveToFile(ByVal dbFilePath As String)
        Dim connectionStringProvider As New OleDbConnectionStringBuilder(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=True", dbFilePath))
        connectionStringProvider.DataSource = dbFilePath

        'Read the initial data
        Dim connection As New OleDbConnection(connectionStringProvider.ConnectionString)
        Dim historyAdapter As New OleDbDataAdapter

        historyAdapter.SelectCommand = New OleDbCommand("SELECT Title, URL, ParentName, DateVisited From Hist", connection)
        Dim commandBuilder As New OleDbCommandBuilder(historyAdapter)

        historyAdapter.Update(m_historyData.Tables("Hist"))
    End Sub

    Public Sub ReadFromFile(ByVal dBFilePath As String)
        Dim connectionStringProvider As New OleDbConnectionStringBuilder(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=True", dBFilePath))
        connectionStringProvider.DataSource = dBFilePath

        'Read the initial data
        Dim connection As New OleDbConnection(connectionStringProvider.ConnectionString)
        Dim historyAdapter As New OleDbDataAdapter

        historyAdapter.SelectCommand = New OleDbCommand("SELECT Title, URL, ParentName, DateVisited From Hist", connection)
        Dim commandBuilder As New OleDbCommandBuilder(historyAdapter)

        m_historyData = New DataSet
        historyAdapter.Fill(m_historyData, "Hist")
        m_HistoryTable = m_historyData.Tables("Hist")
        CreateView()
        m_LastReadDbFilePath = dBFilePath

        OnDataLoaded()
    End Sub

    Private Sub CreateView()
        m_historyDataView = New DataView(m_HistoryTable, "", "Title,URL,DateVisited", DataViewRowState.CurrentRows)
    End Sub

    Public Sub MergeFromIEHistory(ByVal historyFolder As Folder)
        If Me.IsDataExist = False Then
            CreateNewData()
        End If

        FillTreeNode(historyFolder)

        OnDataLoaded()
    End Sub

    Private Sub OnDataLoaded()
        m_DefaultStatisticsProcessor = Nothing
        RaiseEvent DataLoaded()
    End Sub

    Private Sub FillTreeNode(ByVal historyFolder As Folder)
        Dim totalFolderCount As Integer = 0
        Dim totalItemCount As Integer = 0
        For Each HistoryFolderItemObject As Object In historyFolder.Items
            'TODO: Sometime an item is not of FolderItem. Then what it is?
            Dim HistoryFolderItem As FolderItem = DirectCast(HistoryFolderItemObject, FolderItem)
            If HistoryFolderItem.IsFolder Then
                totalFolderCount += 1
            Else
                totalItemCount += 1
            End If
        Next

        RaiseEvent UpdateProgress(0, totalItemCount + 1, 0, "Enumerating " + historyFolder.Title + "...", False)

        Dim runingFolderCount As Integer = 0
        Dim runningItemCount As Integer = 0
        For Each HistoryFolderItem As FolderItem In historyFolder.Items
            If HistoryFolderItem.IsFolder Then
                runingFolderCount += 1
                FillTreeNode(CType(HistoryFolderItem.GetFolder, Folder))
            Else
                runningItemCount += 1
                RaiseEvent UpdateProgress(0, totalItemCount + 1, runningItemCount, "Adding " + HistoryFolderItem.Name + "...", False)
                MergeData(HistoryFolderItem.Name, DirectCast(HistoryFolderItem.GetLink, Shell32.ShellLinkObject).Path, DirectCast(HistoryFolderItem.Parent, Shell32.Folder).ParentFolder.Title, DateTime.Parse(DirectCast(HistoryFolderItem.Parent, Shell32.Folder).GetDetailsOf(HistoryFolderItem, 2)))
            End If
        Next

        RaiseEvent UpdateProgress(0, totalItemCount + 1, totalItemCount + 1, "Done reading history from IE", True)
    End Sub


    Public Sub MergeFromFile(ByVal fromDbFilePath As String)
        If Me.IsDataExist = False Then
            CreateNewData()
        End If

        Dim fromHistoryData As New HistoryData(fromDbFilePath)
        For Each row As DataRow In fromHistoryData.HistoryTable.Rows
            MergeData(row)
        Next

        OnDataLoaded()
    End Sub

    Private Sub MergeData(ByVal row As DataRow)
        MergeData(row("Title").ToString, row("URL").ToString, row("ParentName").ToString, CType(row("DateVisited"), DateTime))
    End Sub

    Private Sub MergeData(ByVal urlTitle As String, ByVal historyUrl As String, ByVal parentFolderName As String, ByVal dateVisited As DateTime)
        If m_historyDataView.FindRows(New Object() {urlTitle, historyUrl, dateVisited}).Length = 0 Then
            Dim newHistoryInfoRow As DataRow = HistoryTable.NewRow()
            newHistoryInfoRow.BeginEdit()
            newHistoryInfoRow("Title") = urlTitle
            newHistoryInfoRow("URL") = historyUrl
            newHistoryInfoRow("ParentName") = parentFolderName
            newHistoryInfoRow("DateVisited") = dateVisited
            newHistoryInfoRow.EndEdit()

            HistoryTable.Rows.Add(newHistoryInfoRow)
        Else
            'Row already exist
        End If
    End Sub

    Public Sub CreateNewData()
        m_historyData = New DataSet
        m_HistoryTable = m_historyData.Tables.Add("Hist")
        m_HistoryTable.Columns.Add("Title", GetType(String))
        m_HistoryTable.Columns.Add("URL", GetType(String))
        m_HistoryTable.Columns.Add("ParentName", GetType(String))
        m_HistoryTable.Columns.Add("DateVisited", GetType(DateTime))
        CreateView()
        m_LastReadDbFilePath = ""
        OnDataLoaded()
    End Sub

    Public Sub UnloadData()
        m_historyData = Nothing
        m_historyDataView = Nothing
        m_HistoryTable = Nothing
        OnDataLoaded()
    End Sub

    Public Sub New()
        'default
        OnDataLoaded()
    End Sub

    Public Sub New(ByVal dbFilePath As String)
        Me.ReadFromFile(dbFilePath)
    End Sub

    Public ReadOnly Property IsDataExist() As Boolean
        Get
            Return Not (HistoryTable Is Nothing)
        End Get
    End Property

    Private WithEvents m_DefaultStatisticsProcessor As StatisticsProcessor = Nothing
    public readonly property DefaultStatisticsProcessor As StatisticsProcessor
        Get
            If m_DefaultStatisticsProcessor Is Nothing Then
                m_DefaultStatisticsProcessor = New StatisticsProcessor(m_BrowserVisitCutOffSeconds, m_SecondsToAssumeOnBrowserVisitCutOff)
                m_DefaultStatisticsProcessor.CalculateStatistics(New DataView(Me.HistoryTable))
            End If
            Return m_DefaultStatisticsProcessor
        End Get
    End Property

    Private m_BrowserVisitCutOffSeconds As Integer = 300
    Public Property BrowserVisitCutOffSeconds() As Integer
        Get
            Return BrowserVisitCutOffSeconds
        End Get
        Set(ByVal value As Integer)
            m_BrowserVisitCutOffSeconds = value
        End Set
    End Property

    Private m_SecondsToAssumeOnBrowserVisitCutOff As Integer = 120
    Public Property SecondsToAssumeOnBrowserVisitCutOff() As Integer
        Get
            Return SecondsToAssumeOnBrowserVisitCutOff
        End Get
        Set(ByVal value As Integer)
            m_SecondsToAssumeOnBrowserVisitCutOff = value
        End Set
    End Property

    Private Sub m_DefaultStatisticsProcessor_UpdateProgress(ByVal minProgressValue As Double, ByVal maxProgressValue As Double, ByVal currentProgressValue As Double, ByVal progressDetail As String, ByVal taskFinished As Boolean) Handles m_DefaultStatisticsProcessor.UpdateProgress
        RaiseEvent UpdateProgress(minProgressValue, maxProgressValue, currentProgressValue, progressDetail, taskFinished)
    End Sub
End Class
