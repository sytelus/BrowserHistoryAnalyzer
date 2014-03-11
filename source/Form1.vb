Imports Shell32
Imports System.Environment
Imports System.Data.OleDb
Imports System.Data
Imports System.IO

Imports Sytel.Common
Imports Sytel.Common.WinForms

Public Class Form1
    Private WithEvents m_HistoryData As New HistoryData
    Private Sub openToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles openToolStripMenuItem.Click
        Try
            DBFileOpenFileDialog.FileName = My.Settings.DBFilePath
        Catch ex As Exception
            '
        End Try

        If DBFileOpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.DBFilePath = DBFileOpenFileDialog.FileName
            My.Settings.Save()
            m_HistoryData.ReadFromFile(DBFileOpenFileDialog.FileName)
        End If
    End Sub

    Private Sub readHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles readHistoryToolStripMenuItem.Click
        Dim shellInstance As New Shell
        Dim historyFolder As Shell32.Folder
        historyFolder = shellInstance.BrowseForFolder(CInt(Me.Handle), "Select the History folder", 0, ShellSpecialFolderConstants.ssfHISTORY)

        If Not (historyFolder Is Nothing) Then
            m_HistoryData.MergeFromIEHistory(historyFolder)
        Else
            'User cancelled the operaion
        End If
    End Sub

    Private Sub fileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fileToolStripMenuItem.Click

    End Sub

    Private Sub updateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateToolStripMenuItem.Click
        If m_HistoryData.LastReadDbFilePath <> "" Then
            m_HistoryData.SaveToFile()
        Else
            updateAsToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub updateAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateAsToolStripMenuItem.Click
        Try
            DBFileOpenFileDialog.FileName = m_HistoryData.LastReadDbFilePath
        Catch ex As Exception
            '
        End Try

        If DBFileSaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.DBFilePath = DBFileSaveFileDialog.FileName
            My.Settings.Save()
            m_HistoryData.SaveToFile(DBFileSaveFileDialog.FileName)
        End If
    End Sub

    Private Sub mergeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mergeToolStripMenuItem.Click
        Try
            DBFileOpenFileDialog.FileName = ""
        Catch ex As Exception
            '
        End Try

        If DBFileOpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            m_HistoryData.MergeFromFile(DBFileOpenFileDialog.FileName)
        End If
    End Sub

    Private Sub exitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitToolStripMenuItem.Click
        On Error Resume Next
        Me.Close()
        Application.Exit()
        Application.ExitThread()
    End Sub

    Private Sub openFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles openFolderToolStripMenuItem.Click
        If m_HistoryData.LastReadDbFilePath = "" Then
            MsgBox("No files have been opened so far")
        Else
            Process.Start(Path.GetDirectoryName(m_HistoryData.LastReadDbFilePath))
        End If
    End Sub

    Private Sub unloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unloadToolStripMenuItem.Click
        m_HistoryData.UnloadData()
    End Sub

    Private Sub Form1_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackColorChanged

    End Sub

    Dim m_plugins As New Generic.Collection(Of IHistoryViewPlugin)
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_plugins.Add(New HistoryViewPlugin)
        m_plugins.Add(New SearchQueriesPlugin)
        m_plugins.Add(New StatisticsPlugin)
        m_plugins.Add(New MostVisitedUrlsPlugin)
        m_plugins.Add(New MostVisitedDomainsPlugin)
        m_plugins.Add(New UsageByDayPlugin)

        PaintPlugins()
    End Sub

    Private Sub PluginUpdateStatus(ByVal statusText As String)
        StatusStripPanel1.Text = statusText
    End Sub

    Private Sub CreatePluginPages()
        PluginTabs.TabPages.Clear()
        SelectPluginToolStripMenuItem.ComboBox.DisplayMember = "Text"
        For Each plugin As IHistoryViewPlugin In m_plugins
            PluginTabs.TabPages.Add(plugin.MyTitle)
            'If plugin Is GetType(Control) Then
            PluginTabs.TabPages(PluginTabs.TabPages.Count - 1).Controls.Add(DirectCast(plugin, Control))
            DirectCast(plugin, Control).Dock = DockStyle.Fill
            SelectPluginToolStripMenuItem.ComboBox.Items.Add(PluginTabs.TabPages(PluginTabs.TabPages.Count - 1))
            'End If
            AddHandler plugin.UpdateStatus, AddressOf PluginUpdateStatus
        Next
        If PluginTabs.TabPages.Count > 0 Then
            PluginTabs.TabPages(0).Select()
            PaintPlugins()
        End If
    End Sub

    Public Sub PaintPlugins()
        If m_HistoryData.IsDataExist Then
            If (PluginTabs.TabPages.Count = 0) Or (PluginTabs.TabPages.Count = 1 AndAlso (PluginTabs.TabPages(0).Controls(0).Name = "NoDataPlugin")) Then
                CreatePluginPages()
            Else
                'Unload all
                For Each plugin As IHistoryViewPlugin In m_plugins
                    plugin.UnloadData()
                Next
                If PluginTabs.SelectedIndex >= 0 Then
                    m_plugins(PluginTabs.SelectedIndex).LoadData(m_HistoryData)
                End If
            End If
        Else
            Dim noDataPlugin As IHistoryViewPlugin = New NoDataPlugin
            PluginTabs.TabPages.Add(noDataPlugin.MyTitle)
            'If plugin Is GetType(Control) Then
            PluginTabs.TabPages(PluginTabs.TabPages.Count - 1).Controls.Add(DirectCast(noDataPlugin, Control))
            DirectCast(noDataPlugin, Control).Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub m_HistoryData_DataLoaded() Handles m_HistoryData.DataLoaded
        PaintPlugins()
    End Sub

    Private Sub m_HistoryData_UpdateProgress(ByVal minProgressValue As Double, ByVal maxProgressValue As Double, ByVal currentProgressValue As Double, ByVal progressDetail As String, ByVal taskFinished As Boolean) Handles m_HistoryData.UpdateProgress
        If taskFinished = False Then
            ToolStripProgressBar1.Visible = True
            Me.Cursor = Cursors.WaitCursor
            ToolStripProgressBar1.Minimum = CType(minProgressValue, Integer)
            ToolStripProgressBar1.Maximum = CType(maxProgressValue, Integer)
            ToolStripProgressBar1.Value = CType(currentProgressValue, Integer)
            ToolStripProgressBar1.ToolTipText = currentProgressValue.ToString + " / " + maxProgressValue.ToString
        Else
            ToolStripProgressBar1.Visible = False
            Me.Cursor = Cursors.Default
        End If
        StatusStripPanel1.Text = progressDetail
        DoEvents()
    End Sub

    Private Sub ToolStripProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripProgressBar1.Click

    End Sub

    Private Sub PluginTabs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PluginTabs.SelectedIndexChanged
        If PluginTabs.SelectedIndex <> -1 Then
            If m_plugins(PluginTabs.SelectedIndex).IsDataLoaded = False Then
                m_plugins(PluginTabs.SelectedIndex).LoadData(m_HistoryData)
            End If
        End If
    End Sub

    Private Sub toolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolsToolStripMenuItem.Click
        SelectPluginToolStripMenuItem.ComboBox.SelectedItem = PluginTabs.SelectedTab
    End Sub

    Private Sub helpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles helpToolStripMenuItem.Click

    End Sub

    Private Function GetAssemblyAttributeInfo() As AssemblyAttributeInfo
        Return New AssemblyAttributeInfo(System.Reflection.Assembly.GetExecutingAssembly())
    End Function

    Private Sub SendCommentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendCommentsToolStripMenuItem.Click
        Process.Start((GetAssemblyAttributeInfo()).SendCommentsUrl)
    End Sub

    Private Sub GotoHomepageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GotoHomepageToolStripMenuItem.Click
        Process.Start((GetAssemblyAttributeInfo()).ProductHomepageUrl)
    End Sub

    Private Sub aboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aboutToolStripMenuItem.Click
        Using newAboutForm As WinForms.AboutForm = New WinForms.AboutForm()
            newAboutForm.SetupForm(System.Reflection.Assembly.GetExecutingAssembly())
            newAboutForm.ShowDialog()
        End Using
    End Sub

    Private Sub SelectPluginToolStripMenuItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectPluginToolStripMenuItem.SelectedIndexChanged
        DirectCast(SelectPluginToolStripMenuItem.ComboBox.SelectedItem, TabPage).Select()
        PaintPlugins()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        ShowApplicationSettingsHandler()
    End Sub

    Private Sub ShowApplicationSettingsHandler()
        Dim optionsForm As New AppOptionsForm()
        optionsForm.ApplicationSettingsToUse = m_ApplicationSettings
        Dim bag As PropertyBag = optionsForm.ApplicationPropertiesInfo

        bag.Properties.Add(New PropertySpec("Last Page Visit Cut Off Time (Sec)", GetType(Integer), "Preferences", "If there is no immediate visit for than this amount of time then it would mean this was your last visit in a browsing session. So, in nutshell, this defines how long before it can be assumed that after visiting this URL you closed all your browser windows.", Integer.Parse(m_ApplicationSettings.GetSetting("Preferences", "Last Page Visit Cut Off Time (Sec)", 300.ToString()))))
        bag.Properties.Add(New PropertySpec("Assumed Visit Time For Last Page (Sec)", GetType(Integer), "Preferences", "When you close the browser there is no records added in history and so it is difficult to track time for the last page you visited in your browsing session. This setting allows you to set how much an average time this program should assume for the last page you visited.", Integer.Parse(m_ApplicationSettings.GetSetting("Preferences", "Assumed Visit Time For Last Page (Sec)", 120.ToString()))))

        optionsForm.RefreshPropertyDisplay()
        m_ApplicationSettings.Save()
        If optionsForm.ShowDialog() = DialogResult.OK Then
            m_ApplicationSettings.Save()
            UpdateFlagsFromApplicationSettings()
        Else
            m_ApplicationSettings.ReloadFromFile(True)
        End If

    End Sub 'ShowApplicationSettingsHandler
    Private Sub UpdateFlagsFromApplicationSettings()
        m_HistoryData.BrowserVisitCutOffSeconds = Integer.Parse(m_ApplicationSettings.GetSetting("Preferences", "Last Page Visit Cut Off Time (Sec)", 300.ToString()))
        m_HistoryData.SecondsToAssumeOnBrowserVisitCutOff = Integer.Parse(m_ApplicationSettings.GetSetting("Preferences", "Assumed Visit Time For Last Page (Sec)", 120.ToString()))
    End Sub 'UpdateFlagsFromApplicationSettings

    Private m_ApplicationSettings As New ApplicationSettings()
    Private Sub Form1_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_ApplicationSettings.OpenOrCreateSettingsDocument(True)
    End Sub

    Private Sub SaveOptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveOptionsToolStripMenuItem.Click
        Dim selectedFile As String = CommonFunctions.SelectFileUsingSaveDialog(saveSettingsFileDialog, String.Empty)
        If selectedFile <> String.Empty Then
            m_ApplicationSettings.SaveCopy(selectedFile)
        End If
    End Sub

    Private Sub LoadOptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadOptionsToolStripMenuItem.Click
        If openSettingsFileDialog.ShowDialog() = DialogResult.OK Then
            m_ApplicationSettings.LoadFromFile(openSettingsFileDialog.FileName)
            m_ApplicationSettings.Save()
            UpdateFlagsFromApplicationSettings()
        End If
    End Sub

    Private Sub DeleteOptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteOptionsToolStripMenuItem.Click
        If MessageBox.Show(Me, "This will force you to shutdown this application and you will loose any unsaved work as well as your settings. Do you want to continue?", "Critical Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            m_ApplicationSettings.Delete()
            ExitApplicationForced()
        End If
    End Sub

    Private Sub ExitApplicationForced()
        Environment.Exit(0)
        Application.ExitThread()
        Application.Exit()
    End Sub 'ExitApplicationForced
End Class
