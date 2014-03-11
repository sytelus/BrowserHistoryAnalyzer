Imports System.Data
Imports System.Text
Imports System.Text.RegularExpressions

Public Class SearchQueriesPlugin
    Implements IHistoryViewPlugin



    Private Sub SearchQuerySearchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchQuerySearchButton.Click
        Dim googleQueryTableView As DataView = DirectCast(SearchQueriesDataGridView.DataSource, DataView)
        If SearchQueriesFilterTextBox.Text <> "" Then
            googleQueryTableView.RowFilter = "Query LIKE " + "'*" + SearchQueriesFilterTextBox.Text + "*'"
        Else
            googleQueryTableView.RowFilter = ""
        End If
    End Sub
    Private Sub SearchQueriesTextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchQueriesFilterTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchQuerySearchButton_Click(Nothing, Nothing)
        End If
    End Sub

    Public Sub LoadData(ByVal historyData As HistoryData) Implements IHistoryViewPlugin.LoadData
        'Create the dataset for google
        Dim searchQueryData As New Data.DataSet
        Dim searchQueryTable As DataTable = searchQueryData.Tables.Add("GoogleQuery")
        searchQueryTable.Columns.Add("SubSite", GetType(String))
        searchQueryTable.Columns.Add("Query", GetType(String))
        searchQueryTable.Columns.Add("DatePerformed", GetType(DateTime))
        searchQueryTable.Columns.Add("RawUrl", GetType(String))

        For Each searchEngine As SearchEngineData In m_SearchEngineData
            'Get all the rows in main table for google
            Dim googleHistoryRows As DataRow()
            googleHistoryRows = historyData.HistoryTable.Select(searchEngine.UrlFilter, "DateVisited")
            For Each searchHistoryRow As DataRow In googleHistoryRows
                Dim urlParts As String() = searchHistoryRow("URL").ToString.ToLower.Split("?"c)
                If urlParts.Length = 2 Then 'Only if it has query string
                    If urlParts(1).IndexOf(searchEngine.KeywordsQueryParameterName + "=") > 1 Then
                        Dim subSite As String = searchEngine.Name
                        If (Not searchEngine.SubSiteRegEx Is Nothing) AndAlso (searchEngine.SubSiteRegEx.Match(urlParts(0)).Groups.Count >= 2) Then
                            subSite += (":" + searchEngine.SubSiteRegEx.Match(urlParts(0)).Groups(1).Value)
                        End If
                        Dim req As New Web.HttpRequest("", urlParts(0), urlParts(1))
                        searchQueryTable.Rows.Add(New Object() {subSite, req.QueryString.Item(searchEngine.KeywordsQueryParameterName), searchHistoryRow("DateVisited"), searchHistoryRow("URL").ToString})
                    Else
                        'There is no standard google query
                    End If
                Else
                    'This doesn't seem to be query string
                End If
            Next
        Next

        SearchQueriesDataGridView.DataSource = searchQueryTable.DefaultView
        SearchQueriesDataGridView.Columns("RawUrl").Visible = False

        RaiseEvent UpdateStatus(searchQueryTable.DefaultView.Count.ToString + " records")
    End Sub

    Public Sub UnloadData() Implements IHistoryViewPlugin.UnloadData
        SearchQueriesDataGridView.DataSource = Nothing
    End Sub

    Public Event UpdateStatus(ByVal statusText As String) Implements IHistoryViewPlugin.UpdateStatus

    Public ReadOnly Property MyTitle() As String Implements IHistoryViewPlugin.MyTitle
        Get
            Return "Search Queries"
        End Get
    End Property

    Public ReadOnly Property IsDataLoaded() As Boolean Implements IHistoryViewPlugin.IsDataLoaded
        Get
            Return Not (SearchQueriesDataGridView.DataSource Is Nothing)
        End Get
    End Property

    Private Structure SearchEngineData
        Public ReadOnly UrlFilter As String
        Public ReadOnly Name As String
        Public ReadOnly KeywordsQueryParameterName As String
        Public ReadOnly SubSiteRegEx As Regex
        Public Sub New(ByVal paramUrlFilter1 As String, ByVal paramUrlFilter2 As String, ByVal paramName As String, ByVal paramKeywordsQueryParameterName As String, ByVal paramSubSiteRegEx As Regex)
            UrlFilter = "(URL LIKE " + "'" + paramUrlFilter1 + "'" + ")"
            If paramUrlFilter2 <> "" Then
                UrlFilter += " AND " + "(URL LIKE " + "'" + paramUrlFilter2 + "'" + ")"
            End If
            Name = paramName
            KeywordsQueryParameterName = paramKeywordsQueryParameterName
            SubSiteRegEx = paramSubSiteRegEx
        End Sub
    End Structure

    Private m_SearchEngineData As New Generic.Collection(Of SearchEngineData)
    Private Sub GoogleQueriesView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_SearchEngineData.Add(New SearchEngineData("*google.com*", "", "Google", "q", New Regex("\/\/(\w+)\.", RegexOptions.Compiled)))

        m_SearchEngineData.Add(New SearchEngineData("*search.yahoo.com*", "", "Yahoo:Web", "p", Nothing))
        m_SearchEngineData.Add(New SearchEngineData("*images.search.yahoo.com*", "", "Yahoo:Images", "p", Nothing))
        m_SearchEngineData.Add(New SearchEngineData("*news.search.yahoo.com*", "", "Yahoo:News", "p", Nothing))

        m_SearchEngineData.Add(New SearchEngineData("*mamma.com*", "*qtype=0*", "Mamma:Web", "query", Nothing))
        m_SearchEngineData.Add(New SearchEngineData("*mamma.com*", "*qtype=4*", "Mamma:News", "query", Nothing))
        m_SearchEngineData.Add(New SearchEngineData("*mamma.com*", "*qtype=48*", "Mamma:Images", "query", Nothing))

        m_SearchEngineData.Add(New SearchEngineData("*search.msn.com*", "*FORM=SMCRT*", "MSN:Web", "q", Nothing))
        m_SearchEngineData.Add(New SearchEngineData("*search.msn.com*", "*FORM=SRCHNS*", "MSN:News", "q", Nothing))

        m_SearchEngineData.Add(New SearchEngineData("*clusty.com/search*", "", "Clusty:All", "query", Nothing))
    End Sub
End Class

