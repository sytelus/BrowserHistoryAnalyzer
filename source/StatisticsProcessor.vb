Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Data

Public Class StatisticsProcessor
    Public Event UpdateProgress(ByVal minProgressValue As Double, ByVal maxProgressValue As Double, ByVal currentProgressValue As Double, ByVal progressDetail As String, ByVal taskFinished As Boolean)

    Private m_BrowserVisitCutOffSeconds As Integer = 300
    Private m_SecondsToAssumeOnBrowserVisitCutOff As Integer = 120
    Public Sub New(ByVal browserVisitCutOffSeconds As Integer, ByVal secondsToAssumeOnBrowserVisitCutOff As Integer)
        m_BrowserVisitCutOffSeconds = browserVisitCutOffSeconds
        m_SecondsToAssumeOnBrowserVisitCutOff = secondsToAssumeOnBrowserVisitCutOff
    End Sub

    Public Sub New()
        'Allow default constructor
    End Sub

    Private m_TotalVisitsCount As Integer = 0
    Public ReadOnly Property TotalVisitsCount() As Integer
        Get
            Return m_TotalVisitsCount
        End Get
    End Property

    Private m_TotalDays As Integer = 0
    Public ReadOnly Property TotalDays() As Integer
        Get
            Return m_TotalDays
        End Get
    End Property

    Public ReadOnly Property AvgVisitsPerDay() As Double
        Get
            Return (m_TotalVisitsCount * 1.0) / m_TotalDays
        End Get
    End Property

    Private m_UniqueUrls As DataTable
    Public ReadOnly Property UniqueUrls() As DataTable
        Get
            Return m_UniqueUrls
        End Get
    End Property

    Private m_UsageByDay As DataTable
    Public ReadOnly Property UsageByDay() As DataTable
        Get
            Return m_UsageByDay
        End Get
    End Property

    Private m_UniqueDomains As DataTable
    Public ReadOnly Property UniqueDomains() As DataTable
        Get
            Return m_UniqueDomains
        End Get
    End Property

    Public ReadOnly Property TotalUniqueUrlsCount() As Integer
        Get
            Return m_UniqueUrls.Rows.Count
        End Get
    End Property

    Public ReadOnly Property AvgUniqueUrlsPerDay() As Double
        Get
            Return (m_UniqueUrls.Rows.Count * 1.0) / m_TotalDays
        End Get
    End Property

    Private m_MaxRecordedVisitsPerDay As Integer = 0
    Public ReadOnly Property MaxRecordedVisitsPerDay() As Integer
        Get
            Return m_MaxRecordedVisitsPerDay
        End Get
    End Property

    Private m_MaxRecordedUniqueUrlsPerDay As Integer = 0
    Public ReadOnly Property MaxRecordedUniqueUrlsPerDay() As Integer
        Get
            Return m_MaxRecordedUniqueUrlsPerDay
        End Get
    End Property

    Public ReadOnly Property AvgTimeBetweenVisits() As Double
        Get
            Return (m_TotalMilliSecondsSpentInVisits * 0.001) / m_TotalVisitsCount
        End Get
    End Property

    Public ReadOnly Property AvgMinutesSpentForBrowsingPerDay() As Integer
        Get
            Return CInt(((m_TotalMilliSecondsSpentInVisits / 1000) / 60) / TotalDays)
        End Get
    End Property

    Private m_TotalMilliSecondsSpentInVisits As Double = 0
    Public ReadOnly Property TotalHoursSpentInVisits() As Integer
        Get
            Return CInt((m_TotalMilliSecondsSpentInVisits / 1000) / 3600)
        End Get
    End Property

    Public Sub CalculateStatistics(ByVal historyDataView As DataView)
        RaiseEvent UpdateProgress(0, historyDataView.Count, 0, "Calculating statistics...", False)

        m_TotalVisitsCount = 0
        m_TotalDays = 0
        m_MaxRecordedVisitsPerDay = 0
        m_MaxRecordedUniqueUrlsPerDay = 0
        m_TotalMilliSecondsSpentInVisits = 0

        historyDataView.Sort = "DateVisited ASC"

        Dim currentDate As DateTime = DateTime.MinValue
        Dim lastVisitTime As DateTime = DateTime.MinValue
        m_UniqueUrls = New DataTable
        m_UniqueUrls.Columns.Add("URL", GetType(String))
        m_UniqueUrls.Columns.Add("Title", GetType(String))
        m_UniqueUrls.Columns.Add("FirstTimeVisited", GetType(DateTime))
        m_UniqueUrls.Columns.Add("VisitCount", GetType(Integer))
        m_UniqueUrls.DefaultView.Sort = "URL"

        m_UniqueDomains = New DataTable
        m_UniqueDomains.Columns.Add("Domain", GetType(String))
        m_UniqueDomains.Columns.Add("LastVisitedTitle", GetType(String))
        m_UniqueDomains.Columns.Add("FirstTimeVisited", GetType(DateTime))
        m_UniqueDomains.Columns.Add("VisitCount", GetType(Integer))
        m_UniqueDomains.DefaultView.Sort = "Domain"

        m_UsageByDay = New DataTable
        m_UsageByDay.Columns.Add("Day", GetType(Date)).Unique = True
        m_UsageByDay.Columns.Add("TotalVisitCount", GetType(Integer))
        m_UsageByDay.Columns.Add("UniqueUrlVisitCount", GetType(Integer))
        m_UsageByDay.Columns.Add("MinutesSpentInVisits", GetType(Double))

        Dim visitsForCurrentDay As Integer = 0
        Dim uniqueUrlsForCurrentDay As Integer = 0
        Dim milliSecondsSpentInVisitsForCurrentDay As Double = 0

        For Each row As DataRowView In historyDataView
            Dim dateVisited As DateTime = CType(row("DateVisited"), DateTime)
            If dateVisited.Subtract(currentDate).Days >= 1 Then
                If visitsForCurrentDay > m_MaxRecordedVisitsPerDay Then
                    m_MaxRecordedVisitsPerDay = visitsForCurrentDay
                End If
                If uniqueUrlsForCurrentDay > m_MaxRecordedUniqueUrlsPerDay Then
                    m_MaxRecordedUniqueUrlsPerDay = uniqueUrlsForCurrentDay
                End If

                'TODO: refactor repeated code block
                If currentDate > DateTime.MinValue Then
                    Dim usageByDayRow As DataRow = m_UsageByDay.NewRow
                    usageByDayRow("Day") = currentDate.Date
                    usageByDayRow("TotalVisitCount") = visitsForCurrentDay
                    usageByDayRow("UniqueUrlVisitCount") = uniqueUrlsForCurrentDay
                    usageByDayRow("MinutesSpentInVisits") = milliSecondsSpentInVisitsForCurrentDay / 60000.0
                    m_UsageByDay.Rows.Add(usageByDayRow)
                End If

                m_TotalDays += 1
                currentDate = dateVisited
                visitsForCurrentDay = 0
                uniqueUrlsForCurrentDay = 0
                milliSecondsSpentInVisitsForCurrentDay = 0
            Else
                'TODO: option parameters here - 300 , 120
                Dim secondsSpendSinceLastVisit As Double = dateVisited.Subtract(lastVisitTime).TotalMilliseconds
                If secondsSpendSinceLastVisit > 300000 Then
                    'Probably this was the last URL in the session
                    m_TotalMilliSecondsSpentInVisits += 250000
                    milliSecondsSpentInVisitsForCurrentDay += 2500
                Else
                    m_TotalMilliSecondsSpentInVisits += secondsSpendSinceLastVisit
                    milliSecondsSpentInVisitsForCurrentDay += secondsSpendSinceLastVisit
                End If
                lastVisitTime = dateVisited
            End If

            m_TotalVisitsCount += 1
            visitsForCurrentDay += 1

            Dim url As String = row("URL").ToString
            Dim uniqueUrlFoundRows As DataRowView()
            uniqueUrlFoundRows = m_UniqueUrls.DefaultView.FindRows(url)
            If uniqueUrlFoundRows.Length = 0 Then
                Dim newUniqueUrlRow As DataRow = m_UniqueUrls.NewRow
                newUniqueUrlRow("URL") = url
                newUniqueUrlRow("Title") = row("Title")
                newUniqueUrlRow("FirstTimeVisited") = row("DateVisited")
                newUniqueUrlRow("VisitCount") = 1
                m_UniqueUrls.Rows.Add(newUniqueUrlRow)
                uniqueUrlsForCurrentDay += 1
            Else
                uniqueUrlFoundRows(0)("VisitCount") = DirectCast(uniqueUrlFoundRows(0)("VisitCount"), Integer) + 1
                uniqueUrlFoundRows(0)("Title") = row("Title")
            End If

            If visitsForCurrentDay > m_MaxRecordedVisitsPerDay Then
                m_MaxRecordedVisitsPerDay = visitsForCurrentDay
            End If
            If uniqueUrlsForCurrentDay > m_MaxRecordedUniqueUrlsPerDay Then
                m_MaxRecordedUniqueUrlsPerDay = uniqueUrlsForCurrentDay
            End If

            Dim domainRegExMatch As RegularExpressions.Match = DomainExtractorRegEx.Match(url)
            If domainRegExMatch.Groups.Count >= 2 Then
                Dim domain As String = domainRegExMatch.Groups(1).Value
                If domain.StartsWith("www.") = True Then
                    domain = domain.Substring("www.".Length)
                End If
                If domain.EndsWith(".com") = True Then
                    domain = domain.Substring(0, domain.Length - ".com".Length)
                End If
                Dim uniqueDomainFoundRows As DataRowView()
                uniqueDomainFoundRows = m_UniqueDomains.DefaultView.FindRows(domain)
                If uniqueDomainFoundRows.Length = 0 Then
                    Dim newUniqueDomainRow As DataRow = m_UniqueDomains.NewRow
                    newUniqueDomainRow("Domain") = domain
                    newUniqueDomainRow("LastVisitedTitle") = row("Title")
                    newUniqueDomainRow("FirstTimeVisited") = row("DateVisited")
                    newUniqueDomainRow("VisitCount") = 1
                    m_UniqueDomains.Rows.Add(newUniqueDomainRow)
                Else
                    uniqueDomainFoundRows(0)("VisitCount") = DirectCast(uniqueDomainFoundRows(0)("VisitCount"), Integer) + 1
                    uniqueDomainFoundRows(0)("LastVisitedTitle") = row("Title")
                End If
            End If

            RaiseEvent UpdateProgress(0, historyDataView.Count, m_TotalVisitsCount, "Calculating statistics...", False)
        Next

        'TODO: refactor repeated code block
        If currentDate > DateTime.MinValue Then
            Dim usageByDayRow As DataRow = m_UsageByDay.NewRow
            usageByDayRow("Day") = currentDate.Date
            usageByDayRow("TotalVisitCount") = visitsForCurrentDay
            usageByDayRow("UniqueUrlVisitCount") = uniqueUrlsForCurrentDay
            usageByDayRow("MinutesSpentInVisits") = milliSecondsSpentInVisitsForCurrentDay / 60000.0
            m_UsageByDay.Rows.Add(usageByDayRow)
        End If

        RaiseEvent UpdateProgress(0, historyDataView.Count, m_TotalVisitsCount, "Finished statistics", True)
    End Sub

    Private ReadOnly DomainExtractorRegEx As New RegularExpressions.Regex("\/\/([^\/]+)\/", RegexOptions.Compiled)
End Class
