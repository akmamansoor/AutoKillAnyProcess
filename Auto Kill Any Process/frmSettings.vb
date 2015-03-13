
#Region "Copyright Notice"

' Copyright © 2009-2015 A.K. Mansoor Ahamed (AKMA Solutions)

' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.

' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.

' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

#End Region

#Region "About"

' Application      :- Auto Kill Any Process
' Version Number   :- 2.2
' Author           :- A.K. Mansoor Ahamed (a.k.a) A.K.M.A
' Created Date     :- October 2009 (version 1.0)
' Updated Date     :- January 2010 (version 2.0)
'                     February 2010 (version 2.1)
'                     March 2015 (version 2.2)
' Website          :- http://akmasolutions.com
' Contact email    :- akma.mansoor@gmail.com 

' Description      :- This sofware is regularly used, to automatically kill multiple processes pre-chosen by the user,
'                     with a simple double-click or at specific intervals based on a timer.
'                     The process names to be deleted are stored in a text file with the extension "hitlist". 
'                     There can be more than one hitlist and the hitlist files to use are chosen by the user at runtime or in the settings.
'                     This "combination" of hitlists is stored in the "executeorder.ini" file in the application data folder of the user.
'                     The user needs to configure his Hitlists just once and then simply execute the application there after.
'                     This configuration can be changed later in the settings window, if the user wishes to do so.
'                     To get the settings window, add the argument "settings", to the shortcut icon of the program, 
'                     To automatically kill processes (silent mode), just execute the main program.

' Note             :- For all feedbacks, suggestions, bug reports, feature requests etc.., please e-mail me at the address above.
'                     All correspondence are welcome.

#End Region

#Region "Source Code"

Option Strict On
Option Explicit On

Imports System
Imports System.IO
Imports System.Security
Imports System.Management
Imports Microsoft.Win32

Public Class frmSettings

#Region "Variable Declarations"
    Dim objModKiller As New modKiller
    Dim objFileOp As New modFileOperations
    Dim strCurrentHitListPath As String
    Dim strButtonPressed As String
    Dim arrCurrProcs(-1) As Process
    Dim regKeyAddToStartup As RegistryKey
    Dim regKeyAutoClear As RegistryKey
    Dim regKeyKillTimer As RegistryKey
    Dim defaultDays As String = "365"
    Dim defaultMilliSeconds As Integer = 60000
    Dim strProductName As String = Application.ProductName
    Dim mnuSeperator As ToolStripSeparator
    Dim WithEvents mnuDisplayForm As ToolStripMenuItem
    Dim WithEvents mnuToggleTimer As ToolStripMenuItem
    Dim WithEvents mnuExit As ToolStripMenuItem
#End Region

#Region "frmSettings - Events"

    Private Sub frmSettings_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        objFileOp.WriteInfoLog("========================================================================================")
        objFileOp.WriteInfoLog("")
    End Sub

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            objFileOp.WriteInfoLog("")
            objFileOp.WriteInfoLog("NEW A.K.A.P SESSION STARTED AT - " & Format(Now, "hh:mm:ss tt"))
            objFileOp.WriteInfoLog("========================================================================================")
            'just a shortcut to check if user has the proper rights to terminate processes, can be replaced by 
            'checking user credentials using "System.Security.Principal.WindowsPrincipal" class.
            Try
                System.Diagnostics.Process.EnterDebugMode()
                System.Diagnostics.Process.LeaveDebugMode()
            Catch ex As Exception
                objFileOp.writeErrorLog("Warning: Insufficient user privileges", "Accessing processes")
            End Try
            Me.Icon = My.Resources.icoAutoKillAnyProcess
            Me.Text = "Auto Kill Any Process" & " - " & System.Environment.UserName
            Call fileChecker()
            Try
                regKeyAddToStartup = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
                regKeyAutoClear = Registry.CurrentUser.OpenSubKey("Software\" & My.Application.Info.CompanyName & "\" & _
                                  My.Application.Info.ProductName & "\auto_clear", True)
                regKeyKillTimer = Registry.CurrentUser.OpenSubKey("Software\" & My.Application.Info.CompanyName & "\" & _
                                  My.Application.Info.ProductName & "\kill_timer", True)
            Catch ex As Exception
                Call checkRegistryEntries()
            End Try
            If regKeyAutoClear.GetValue("is_true").Equals("yes") Then
                If regKeyAutoClear.GetValue("interval") Is Nothing Then
                    regKeyAutoClear.SetValue("interval", defaultDays, RegistryValueKind.String)
                End If
                txtAutoClearDays.Text = regKeyAutoClear.GetValue("interval").ToString
                Call autoClearTerminationLogs()
            End If

            If regKeyKillTimer.GetValue("is_true").Equals("yes") Then
                If regKeyKillTimer.GetValue("interval") Is Nothing Then
                    regKeyKillTimer.SetValue("interval", defaultMilliSeconds, RegistryValueKind.String)
                End If
                Dim millisecs As Integer = CInt(regKeyKillTimer.GetValue("interval"))
                txtTimeInMinutes.Text = (millisecs / defaultMilliSeconds).ToString
                Timer1.Start()
                statusLabel1.Text = "Timer is Enabled."
            End If

            If My.Application.CommandLineArgs.Count > 0 Then
                If My.Application.CommandLineArgs(0).ToLower = "-settings" Or _
                   My.Application.CommandLineArgs(0).ToLower = "settings" Or _
                   My.Application.CommandLineArgs(0).ToLower = "-setting" Or _
                   My.Application.CommandLineArgs(0).ToLower = "setting" Then
                    Call showFrmSettings()
                Else
                    MsgBox("ERROR: Invalid command line argument", MsgBoxStyle.Critical)
                    objFileOp.writeErrorLog("ERROR: Invalid command line argument!", "frmSettings_Load")
                    objFileOp.WriteInfoLog("")
                    Me.Close()
                End If
            ElseIf intHitlistCount = 1 Then 'only one hitlist is available.
                strProcsToTerminate = objFileOp.ReadTextFromFile(strCurrentHitListPath)
                If Not strProcsToTerminate.Length = 0 Then
                    objFileOp.WriteInfoLog("Current Termination List - " & Path.GetFileName(strCurrentHitListPath))
                    Call objModKiller.killThemAll(strProcsToTerminate)
                    objFileOp.WriteInfoLog("")
                    Call showFrmSettings()
                    Me.WindowState = FormWindowState.Minimized
                    'Me.Close()
                Else
                    'MsgBox("No Processes found in hitlist - Nothing was terminated!", MsgBoxStyle.Exclamation)
                    'objFileOp.WriteInfoLog("No Processes found in hitlist - Nothing was terminated!")
                    'objFileOp.WriteInfoLog("")
                    'Me.Close()
                    Call showFrmSettings()
                End If
            ElseIf intHitlistCount > 1 Then
                If arrExecuteOrder.Length = 0 Then
                    frmHitlistChooser.ShowDialog()  'show a modal window and wait till the user choose hitlists to terminate.
                    'if still no hitlists available, then, exit the application.
                    If arrExecuteOrder Is Nothing Or arrExecuteOrder.Length = 0 Then
                        'MsgBox("No Hitlist was chosen for termination - Exiting Application!", MsgBoxStyle.Exclamation)
                        objFileOp.WriteInfoLog("No Hitlist was chosen for termination - Exiting Application!")
                        objFileOp.WriteInfoLog("")
                        Call showFrmSettings()
                        Me.WindowState = FormWindowState.Minimized
                        'Me.Close()
                        'Exit Sub
                    End If
                End If
                For Each hitListFile As String In arrExecuteOrder 'terminate all hitlists in executeorder.ini
                    strCurrentHitListPath = strDirPath & hitListFile
                    strProcsToTerminate = objFileOp.ReadTextFromFile(strCurrentHitListPath)
                    If strProcsToTerminate.Length > 0 Then
                        objFileOp.WriteInfoLog("Current Termination List - " & hitListFile)
                        Call objModKiller.killThemAll(strProcsToTerminate)
                        objFileOp.WriteInfoLog("")
                    End If
                Next
                Call showFrmSettings()
                Me.WindowState = FormWindowState.Minimized
                'Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            statusLabel1.Text = ""
            Select Case TabControl1.SelectedTab.Name

                Case tabPgHitList.Name
                    If File.Exists(strCurrentHitListPath) Then
                        Call refreshHitlist()
                        Call enableDisableButtons_Hitlist()
                    Else
                        Call fileChecker()
                        Call refreshHitlist()
                        Call enableDisableButtons_Hitlist()
                    End If
                Case tabPgRunPro.Name
                    Call refreshRunPro()
                Case tabPgManPro.Name
                    If File.Exists(strCurrentHitListPath) Then
                        Call refreshManPro()
                    Else
                        Call fileChecker()
                        Call refreshManPro()
                    End If
                Case tabPgOtherSettings.Name
                    Call populateChkLstExecOrder() 'populate chkLstExecOrder with ALL Hitlist names     
                    Call updateArrExecuteOrder()
                    If arrExecuteOrder.Length > 0 Then 'Execute order is available
                        chkChooseOnExeution.Checked = False
                        Call selectHitlists() 'select the Hitlist Names based on "executeorder.ini"
                    Else 'Executeorder not available, so choose it during execution
                        chkChooseOnExeution.Checked = True
                    End If
                    Call chkChooseOnExeution_CheckedChanged(Nothing, Nothing)
                    If regKeyAddToStartup.GetValue(strProductName) Is Nothing Then
                        chkAddToStartup.Checked = False
                    Else
                        chkAddToStartup.Checked = True
                    End If
                    Call checkRegistryEntries()
                    If regKeyAutoClear.GetValue("is_true", "no").Equals("no") Then 'false
                        chkAutoClearLogs.Checked = False
                    ElseIf regKeyAutoClear.GetValue("is_true").Equals("yes") Then 'true
                        chkAutoClearLogs.Checked = True
                    End If
                    Call chkAutoClearLogs_CheckedChanged(Nothing, Nothing)
                    If regKeyKillTimer.GetValue("is_true", "no").Equals("no") Then 'false
                        chkEnableTimer.Checked = False
                    ElseIf regKeyKillTimer.GetValue("is_true").Equals("yes") Then 'true
                        chkEnableTimer.Checked = True
                    End If
                    Call chkEnableTimer_CheckedChanged(Nothing, Nothing)
                    btnUpdate.Enabled = False
                    Call activateClearLogsSection()
                Case tabPgAbout.Name
                    lblVersion.Text = ""
                    lblVersion.Text = Auto_Kill_Any_Process.My.Application.Info.Version.Major.ToString
                    lblVersion.Text &= "." & Auto_Kill_Any_Process.My.Application.Info.Version.Minor.ToString
                    Dim text_stream As Stream
                    text_stream = Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(GetType(frmSettings), "COPYING.rtf")
                    If Not (text_stream Is Nothing) Then
                        richtextboxAbout.LoadFile(text_stream, RichTextBoxStreamType.RichText)
                    Else
                        richtextboxAbout.Text = "LICENSE FILE NOT FOUND!" & vbNewLine & "CONTACT THE SOFTWARE AUTHOR FOR ANY QUERIES."
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub TabControl1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown
        If TabControl1.SelectedTab Is tabPgHitList And TabControl1.Focused = True Then
            Select Case e.KeyCode
                Case Keys.F2
                    If btnRenameHitList.Enabled = True Then Call btnRenameHitList_Click(Nothing, Nothing)
                Case Keys.F5
                    If btnRefreshHitList.Enabled = True Then Call btnRefreshHitList_Click(Nothing, Nothing)
                Case Keys.Delete
                    If btnDelHitList.Enabled = True Then Call btnDelHitList_Click(Nothing, Nothing)
                Case Keys.N
                    If e.Control = True Then
                        If btnNewHitlist.Enabled = True Then Call btnNewHitlist_Click(Nothing, Nothing)
                    End If
                Case Keys.O
                    If e.Control = True Then
                        If btnOpenHitlist.Enabled = True Then Call btnOpenHitlist_Click(Nothing, Nothing)
                    End If
                Case Keys.S
                    If e.Control = True Then
                        If btnSaveHitList.Enabled = True Then Call btnSaveHitList_Click(Nothing, Nothing)
                    End If
                Case Keys.K
                    If e.Control = True Then
                        If btnKillHitlist.Enabled = True Then Call btnKillHitlist_Click(Nothing, Nothing)
                    End If
            End Select
        ElseIf TabControl1.SelectedTab Is tabPgRunPro And TabControl1.Focused = True Then
            Select Case e.KeyCode
                Case Keys.F5
                    If btnRefreshRunPro.Enabled = True Then Call btnRefreshRunPro_Click(Nothing, Nothing)
                Case Keys.S
                    If e.Control = True Then
                        If btnSaveRunPro.Enabled = True Then Call btnSaveRunPro_Click(Nothing, Nothing)
                    End If
                Case Keys.K
                    If e.Control = True Then
                        If btnKillRunPro.Enabled = True Then Call btnKillRunPro_Click(Nothing, Nothing)
                    End If
                Case Keys.U
                    If e.Control = True Then
                        If btnUncheckRunPro.Enabled = True Then Call btnUncheckRunPro_Click(Nothing, Nothing)
                    End If
            End Select
        ElseIf TabControl1.SelectedTab Is tabPgManPro And TabControl1.Focused = True Then
            Select Case e.KeyCode
                Case Keys.F5
                    If btnRefreshManPro.Enabled = True Then Call btnRefreshManPro_Click(Nothing, Nothing)
                Case Keys.S
                    If e.Control = True Then
                        If btnSaveManPro.Enabled = True Then Call btnSaveManPro_Click(Nothing, Nothing)
                    End If
                Case Keys.R
                    If e.Control = True Then
                        If btnRemoveManPro.Enabled = True Then Call btnRemoveManPro_Click(Nothing, Nothing)
                    End If
                Case Keys.K
                    If e.Control = True Then
                        If btnKillManPro.Enabled = True Then Call btnKillManPro_Click(Nothing, Nothing)
                    End If
                Case Keys.U
                    If e.Control = True Then
                        If btnUncheckManPro.Enabled = True Then Call btnUncheckManPro_Click(Nothing, Nothing)
                    End If
            End Select
        ElseIf TabControl1.SelectedTab Is tabPgOtherSettings And TabControl1.Focused = True Then
            Select Case e.KeyCode
                Case Keys.O
                    If btnOpenFolder.Enabled = True Then Call btnOpenFolder_Click(Nothing, Nothing)
                Case Keys.U
                    If e.Control = True Then
                        If btnUpdate.Enabled = True Then Call btnUpdate_Click(Nothing, Nothing)
                    End If
                Case Keys.K
                    If e.Control = True Then
                        If btnKillOtherSettings.Enabled = True Then Call btnKillOtherSettings_Click(Nothing, Nothing)
                    End If
                Case Keys.E
                    If e.Control = True Then
                        If btnClearErrLog.Enabled = True Then Call btnClearErrLog_Click(Nothing, Nothing)
                    End If
                Case Keys.T
                    If e.Control = True Then
                        If btnClearTermLog.Enabled = True Then Call btnClearTermLog_Click(Nothing, Nothing)
                    End If
                Case Keys.A
                    If e.Control = True Then
                        If btnClearAllLog.Enabled = True Then Call btnClearAllLog_Click(Nothing, Nothing)
                    End If
            End Select
        ElseIf TabControl1.SelectedTab Is tabPgAbout And TabControl1.Focused = True Then
            Select Case e.KeyCode
                Case Keys.O
                    If e.Control = True Or e.Alt = True Then
                        Call lnkContact_LinkClicked(Nothing, Nothing)
                    End If
                Case Keys.W
                    If e.Control = True Or e.Alt = True Then
                        Call lnkWebsite_LinkClicked(Nothing, Nothing)
                    End If
                Case Keys.U
                    If e.Control = True Or e.Alt = True Then
                        Call lnkUserGuide_LinkClicked(Nothing, Nothing)
                    End If
                Case Keys.L
                    If e.Control = True Or e.Alt = True Then
                        Call lnkLblLicense_LinkClicked(Nothing, Nothing)
                    End If
            End Select
        End If
    End Sub

    Private Sub frmSettings_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.ShowInTaskbar = False
            NotifyIcon1.Visible = True
            Me.Hide()
            Dim cMenu As ContextMenuStrip = New ContextMenuStrip
            mnuSeperator = New ToolStripSeparator()
            mnuDisplayForm = New ToolStripMenuItem("Open")
            mnuToggleTimer = New ToolStripMenuItem("Enable Auto Kill Timer")
            mnuToggleTimer.CheckOnClick = True
            mnuExit = New ToolStripMenuItem("Exit")
            cMenu.Items.AddRange(New ToolStripItem() {mnuDisplayForm, mnuToggleTimer, mnuSeperator, mnuExit})
            If chkEnableTimer.Checked = True Then
                mnuToggleTimer.Checked = True
            Else
                mnuToggleTimer.Checked = False
            End If
            NotifyIcon1.ContextMenuStrip = cMenu
            NotifyIcon1.Text = "Auto Kill Any Process"
            NotifyIcon1.BalloonTipText = "A.K.A.P will now run from system tray"
            NotifyIcon1.ShowBalloonTip(200)
        End If
    End Sub

    Private Sub mnuDisplayForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDisplayForm.Click
        Me.Show()
        Me.ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub

    Private Sub mnuToggleTimer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuToggleTimer.Click
        If chkEnableTimer.Checked = True Then
            chkEnableTimer.Checked = False
        Else
            chkEnableTimer.Checked = True
        End If
    End Sub

    Private Sub mnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub

#End Region

#Region "frmSettings - Methods"

    ''' <summary>
    ''' Check for the registry keys "auto_clear" and "kill_timer" in the registry
    ''' </summary>
    Private Sub checkRegistryEntries()
        If regKeyAutoClear Is Nothing Then
            regKeyAutoClear = Registry.CurrentUser.CreateSubKey( _
            "Software\" & My.Application.Info.CompanyName & "\" & _
            My.Application.Info.ProductName & "\auto_clear")
            regKeyAutoClear.SetValue("is_true", "no", RegistryValueKind.String)
            regKeyAutoClear.SetValue("interval", defaultDays, RegistryValueKind.String)
        End If

        If regKeyKillTimer Is Nothing Then
            regKeyKillTimer = Registry.CurrentUser.CreateSubKey( _
            "Software\" & My.Application.Info.CompanyName & "\" & _
            My.Application.Info.ProductName & "\kill_timer")
            regKeyKillTimer.SetValue("is_true", "no", RegistryValueKind.String)
            regKeyKillTimer.SetValue("interval", defaultMilliSeconds, RegistryValueKind.String)
        End If
    End Sub

    ''' <summary>
    ''' Check for hitlists, save ALL hitlist file names to arrHitlistFiles and get intHitlistCount, currentHitlistPath
    ''' </summary>
    Private Sub fileChecker()
        If Not Directory.Exists(strDirPath) Then Directory.CreateDirectory(strDirPath)
        If Not File.Exists(strExecuteOrderIniPath) Then File.Create(strExecuteOrderIniPath).Close()
        Call updateArrExecuteOrder()

        'Check if any Hitlist files (*.hitlist) are available, else create default hitlist.
        If intHitlistCount = 0 Then
            File.Create(strDefaultHitListPath).Close()
            MsgBox("Default hitlist created at: " & strDefaultHitListPath, MsgBoxStyle.Information)
            strCurrentHitListPath = strDefaultHitListPath
            Call updateArrHitlistFiles()
            Call showFrmSettings()
        Else
            strCurrentHitListPath = strDirPath & arrHitlistFiles(0)
        End If
        Call updateFileSystemWatcherPath(strCurrentHitListPath)
    End Sub

    Private Sub updateArrExecuteOrder()
        Try
            Dim strTemp As String = ""
            strTemp = objFileOp.ReadTextFromFile(strExecuteOrderIniPath)
            ReDim arrExecuteOrder(-1)
            If Not strTemp.Length = 0 Then arrExecuteOrder = strTemp.Split(CChar(","))
            strTemp = ""
            Call updateArrHitlistFiles()
            If arrExecuteOrder.Length = 0 Then Exit Sub

            'delete non-existent hitlist names (*.hilist) from executeorder.ini
            For Each hitlistFileName As String In arrExecuteOrder
                If Array.IndexOf(arrHitlistFiles, hitlistFileName) > -1 Then
                    strTemp = strTemp & hitlistFileName & ","
                End If
            Next
            If strTemp.EndsWith(CChar(",")) Then strTemp = strTemp.Remove(strTemp.Length - 1)
            If objFileOp.SaveTextToFile(strTemp, strExecuteOrderIniPath) = True Then
                arrExecuteOrder = objFileOp.ReadTextFromFile(strExecuteOrderIniPath).Split(CChar(","))
            Else
                ReDim arrExecuteOrder(-1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            ReDim arrExecuteOrder(-1)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub showFrmSettings()
        Me.ShowInTaskbar = True
        TabControl1.SelectedTab = tabPgHitList
        txtNameHitList.Visible = False
        lblNameHitList.Visible = True
        btnOKHitList.Visible = False
        btnCancelHilist.Visible = False
        Call refreshHitlist()
        Call enableDisableButtons_Hitlist()
    End Sub

    Private Sub updateFileSystemWatcherPath(ByVal strPathToWatch As String)
        Try
            FileSystemWatcher1.Path = Path.GetDirectoryName(strPathToWatch)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub FileSystemWatcher1_Changed(ByVal sender As System.Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed
        If Not e.FullPath = strExecuteOrderIniPath Then
            Call fileChangedManually()
        End If
        If e.FullPath = strDirPath & "Logs" Then
            Call activateClearLogsSection()
        End If
    End Sub

    Private Sub FileSystemWatcher1_Created(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Created
        If e.FullPath = strExecuteOrderIniPath Then
            Call updateArrExecuteOrder()
        Else
            Call updateArrHitlistFiles()
        End If
    End Sub

    Private Sub FileSystemWatcher1_Deleted(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Deleted
        If e.FullPath = strExecuteOrderIniPath Then
            File.Create(strExecuteOrderIniPath).Close()
        ElseIf e.FullPath = strCurrentHitListPath Then
            Call fileChangedManually()
        Else
            Call updateArrExecuteOrder()
        End If
    End Sub

    Private Sub FileSystemWatcher1_Renamed(ByVal sender As Object, ByVal e As System.IO.RenamedEventArgs) Handles FileSystemWatcher1.Renamed
        If e.FullPath = strExecuteOrderIniPath Then
            File.Create(strExecuteOrderIniPath).Close()
            Call updateArrExecuteOrder()
            Exit Sub
        End If

        Dim strOldName As String = e.OldName
        Dim strNewName As String = e.Name
        Dim index As Integer = Array.IndexOf(arrExecuteOrder, strOldName)
        If index > -1 Then
            'update ExecuteOrder item
            arrExecuteOrder(index) = strNewName
            objFileOp.SaveTextToFile(getStrFromArray(arrExecuteOrder), strExecuteOrderIniPath)
        End If
        If e.OldFullPath = strCurrentHitListPath Then
            strCurrentHitListPath = e.FullPath
            Call fileChangedManually()
        Else
            Call updateArrHitlistFiles()
        End If
    End Sub

    Private Sub fileChangedManually()
        If File.Exists(strCurrentHitListPath) Then
            Call refreshHitlist()
            Call enableDisableButtons_Hitlist()
        Else
            Call fileChecker()
            Call refreshHitlist()
            Call enableDisableButtons_Hitlist()
        End If
    End Sub

#End Region

#Region "Hilist Operations Tab - Events"

    Private Sub btnNewHitlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewHitlist.Click
        Dim strOldName As String = lblNameHitList.Text
        strButtonPressed = "new"
        btnNewHitlist.BackColor = Drawing.Color.Aqua
        txtNameHitList.Text = ""
        lblNameHitList.Visible = False
        txtNameHitList.Visible = True
        btnOKHitList.Visible = True
        If txtNameHitList.Text = "" Then btnOKHitList.Enabled = False
        btnCancelHilist.Visible = True
        For Each ctrl As Control In pnlHitlistActions.Controls
            If TypeOf (ctrl) Is Button Then ctrl.Enabled = False
        Next
        txtNameHitList.Focus()
    End Sub

    Private Sub btnOpenHitlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenHitlist.Click
        Try
            OpenFileDialog1.Reset()
            OpenFileDialog1.Filter = "HITLIST Files|*.hitlist"
            OpenFileDialog1.FilterIndex = 1
            OpenFileDialog1.InitialDirectory = strDirPath
            OpenFileDialog1.Title = "Browse Hitlist"
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub
            strCurrentHitListPath = OpenFileDialog1.FileName
            If Not Path.GetDirectoryName(strCurrentHitListPath) & "\" = strDirPath Then
                If MsgBox("All Hitlists must be located at the default location below: " & vbNewLine & _
                 strDirPath & vbNewLine & vbNewLine & "Proceed to copy this file to the above location?", _
                 CType(vbYesNo + vbQuestion, MsgBoxStyle)) = MsgBoxResult.Yes Then
                    My.Computer.FileSystem.CopyFile(strCurrentHitListPath, strDirPath & Path.GetFileName(strCurrentHitListPath))
                    strCurrentHitListPath = strDirPath & Path.GetFileName(strCurrentHitListPath)
                    Call updateFileSystemWatcherPath(strCurrentHitListPath)
                Else
                    Exit Sub
                End If
            End If
            Call updateFileSystemWatcherPath(strCurrentHitListPath)
            Call refreshHitlist()
            Call enableDisableButtons_Hitlist()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnRenameHitList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenameHitList.Click
        Dim strOldName As String = lblNameHitList.Text
        strButtonPressed = "rename"
        btnRenameHitList.BackColor = Drawing.Color.Aqua
        txtNameHitList.Text = strOldName
        lblNameHitList.Visible = False
        txtNameHitList.Visible = True
        btnOKHitList.Visible = True
        If txtNameHitList.Text = "" Then btnOKHitList.Enabled = False
        btnCancelHilist.Visible = True
        For Each ctrl As Control In pnlHitlistActions.Controls
            If TypeOf (ctrl) Is Button Then ctrl.Enabled = False
        Next
        txtNameHitList.Focus()
    End Sub

    Private Sub btnRefreshHitList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshHitList.Click
        btnRefreshHitList.BackColor = Drawing.Color.Aqua
        If Not File.Exists(strCurrentHitListPath) Then
            MsgBox("File not found: " & vbNewLine & strCurrentHitListPath, MsgBoxStyle.Exclamation)
            Call fileChecker()
        End If
        Call refreshHitlist()
        Call enableDisableButtons_Hitlist()
        btnRefreshHitList.BackColor = Drawing.Color.Transparent
    End Sub

    Private Sub btnDelHitList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelHitList.Click
        Try
            Dim strTempName As String = Path.GetFileNameWithoutExtension(strCurrentHitListPath)
            If File.Exists(strCurrentHitListPath) Then
                If MsgBox("Are you sure you want to permanently delete the Hilist - '" & strTempName & "'?", _
                CType(vbYesNo + vbQuestion, MsgBoxStyle)) = MsgBoxResult.Yes Then
                    My.Computer.FileSystem.DeleteFile(strCurrentHitListPath)
                    MsgBox(strTempName & ".hitlist" & " - " & "was successfully deleted!", MsgBoxStyle.Information)
                Else
                    Exit Sub
                End If
            Else
                MsgBox("File not found: " & vbNewLine & strCurrentHitListPath, MsgBoxStyle.Exclamation)
            End If
            Call fileChecker()
            Call refreshHitlist()
            Call enableDisableButtons_Hitlist()
        Catch ex As Exception
            MsgBox("Error while deleting hitlist" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnSaveHitList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveHitList.Click
        Dim strOldName As String = lblNameHitList.Text
        strButtonPressed = "saveas"
        btnSaveHitList.BackColor = Drawing.Color.Aqua
        txtNameHitList.Text = ""
        lblNameHitList.Visible = False
        txtNameHitList.Visible = True
        btnOKHitList.Visible = True
        If txtNameHitList.Text = "" Then btnOKHitList.Enabled = False
        btnCancelHilist.Visible = True
        For Each ctrl As Control In pnlHitlistActions.Controls
            If TypeOf (ctrl) Is Button Then ctrl.Enabled = False
        Next
        txtNameHitList.Focus()
    End Sub

    Private Sub btnKillHitlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKillHitlist.Click
        statusLabel1.Text = ""
        If Not strProcsToTerminate.Length = 0 Then
            objFileOp.WriteInfoLog("Current Termination List - " & lblNameHitList.Text & ".hitlist")
            Call objModKiller.killThemAll(strProcsToTerminate)
            objFileOp.WriteInfoLog("")
        End If
        statusLabel1.Text = "Operation Complete in Hitlist_Operations Section!"
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub lblNameHitList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblNameHitList.DoubleClick
        btnRenameHitList_Click(Nothing, Nothing)
    End Sub

    Private Sub txtNameHitList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNameHitList.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnOKHitList_Click(Nothing, Nothing)
        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            btnCancelHitlist_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtNameHitList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNameHitList.TextChanged
        If txtNameHitList.Text = "" Then
            btnOKHitList.Enabled = False
        Else
            btnOKHitList.Enabled = True
        End If
    End Sub

    Private Sub btnOKHitList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOKHitList.Click
        Try
            For Each ch As Char In txtNameHitList.Text.ToCharArray
                If Array.IndexOf(Path.GetInvalidFileNameChars(), ch) > -1 Then
                    MsgBox("File name contains invalid characters!", MsgBoxStyle.Exclamation)
                    btnOKHitList.Enabled = True
                    Exit Sub
                End If
            Next
            Dim strOldName As String = lblNameHitList.Text & ".hitlist"
            Dim strNewName As String = txtNameHitList.Text & ".hitlist"
            If Array.IndexOf(arrHitlistFiles, strNewName) > -1 Then
                MsgBox("Hitlist already exists!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If Not strButtonPressed = "new" And File.Exists(strCurrentHitListPath) = False Then
                MsgBox("File not found: " & vbNewLine & strCurrentHitListPath, MsgBoxStyle.Exclamation)
                Call fileChecker()
                Call refreshHitlist()
                Exit Sub
            End If
            Select Case strButtonPressed
                Case "new"
                    If createNewHitlist(strNewName) = True Then
                        Call updateArrHitlistFiles()
                        strCurrentHitListPath = strDirPath & strNewName
                        Call refreshHitlist()
                        MsgBox("Hitlist created successfully!", MsgBoxStyle.Information)
                        TabControl1.SelectedTab = tabPgRunPro
                    Else
                        MsgBox("Unable to create Hitlist!", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                Case "rename"
                    If renameHitlist(strOldName, strNewName) = True Then
                        strCurrentHitListPath = strDirPath & strNewName
                        lblNameHitList.Text = Path.GetFileNameWithoutExtension(strCurrentHitListPath)
                        MsgBox("Hitlist renamed successfully!", MsgBoxStyle.Information)
                    Else
                        MsgBox("Unable to rename Hitlist!", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                Case "saveas"
                    If saveHitlistAs(strOldName, strNewName) = True Then
                        Call updateArrHitlistFiles()
                        strCurrentHitListPath = strDirPath & strNewName
                        lblNameHitList.Text = Path.GetFileNameWithoutExtension(strCurrentHitListPath)
                        MsgBox("Hitlist saved successfully!", MsgBoxStyle.Information)
                    Else
                        MsgBox("Unable to save Hitlist!", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
            End Select

            txtNameHitList.Text = ""
            lblNameHitList.Visible = True
            txtNameHitList.Visible = False
            btnOKHitList.Visible = False
            btnCancelHilist.Visible = False
            Call updateFileSystemWatcherPath(strCurrentHitListPath)
            Call enableDisableButtons_Hitlist()
            strButtonPressed = ""
        Catch ex As Exception
            MsgBox("Error: " & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCancelHitlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelHilist.Click
        txtNameHitList.Text = ""
        lblNameHitList.Visible = True
        txtNameHitList.Visible = False
        btnOKHitList.Visible = False
        btnCancelHilist.Visible = False
        strButtonPressed = ""
        Call enableDisableButtons_Hitlist()
        TabControl1.Focus()
    End Sub

#End Region

#Region "Hitlist Operations Tab - Methods"

    Private Sub enableDisableButtons_Hitlist()
        btnNewHitlist.Enabled = True
        btnOpenHitlist.Enabled = True
        If lblNameHitList.Visible = True And lblNameHitList.Text <> "" Then
            btnRenameHitList.Enabled = True
            btnRefreshHitList.Enabled = True
            If intHitlistCount > 1 Then btnDelHitList.Enabled = True Else btnDelHitList.Enabled = False
        Else
            btnRenameHitList.Enabled = False
            btnRefreshHitList.Enabled = False
            btnDelHitList.Enabled = False
        End If
        If lstHitListProcs.Items.Count > 0 Then
            btnSaveHitList.Enabled = True
            btnKillHitlist.Enabled = True
        Else
            btnSaveHitList.Enabled = False
            btnKillHitlist.Enabled = False
        End If
        For Each ctrl As Control In pnlHitlistActions.Controls
            If TypeOf (ctrl) Is Button Then ctrl.BackColor = Drawing.Color.Transparent
        Next
    End Sub

    Private Function createNewHitlist(ByVal strNewName As String) As Boolean
        Try
            If Not Directory.Exists(strDirPath) Then Directory.CreateDirectory(strDirPath)
            File.Create(strDirPath & strNewName).Close()
            Return True
        Catch ex As Exception
            MsgBox("Error: " & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
            Return False
        End Try
    End Function

    Private Function renameHitlist(ByVal strOldName As String, ByVal strNewName As String) As Boolean
        Try
            My.Computer.FileSystem.RenameFile(strCurrentHitListPath, strNewName)
            Call updateArrHitlistFiles()
            Dim index As Integer = Array.IndexOf(arrExecuteOrder, strOldName)
            If index > -1 Then
                'update ExecuteOrder
                arrExecuteOrder(index) = strNewName
                objFileOp.SaveTextToFile(getStrFromArray(arrExecuteOrder), strExecuteOrderIniPath)
            End If
            Return True
        Catch ex As Exception
            MsgBox("Error: " & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
            Return False
        End Try
    End Function

    Private Sub refreshHitlist()
        Try
            lblNameHitList.Text = Path.GetFileNameWithoutExtension(strCurrentHitListPath)
            lstHitListProcs.Items.Clear()
            strProcsToTerminate = objFileOp.ReadTextFromFile(strCurrentHitListPath)
            arrProcsToTerminate = getArrFromString(strProcsToTerminate)
            If arrProcsToTerminate.Length > 0 Then lstHitListProcs.Items.AddRange(arrProcsToTerminate)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Function saveHitlistAs(ByVal strOldName As String, ByVal strNewName As String) As Boolean
        Try
            My.Computer.FileSystem.CopyFile(strDirPath & strOldName, strDirPath & strNewName)
            Return True
        Catch ex As Exception
            MsgBox("Error: " & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
            Return False
        End Try
    End Function

#End Region

#Region "Add Running Processes Tab - Events"

    Private Sub btnRefreshRunPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshRunPro.Click
        Call refreshRunPro()
    End Sub

    Private Sub chkLstRunPro_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstRunPro.DoubleClick
        Call enableDisableButtons_RunPro()
    End Sub

    Private Sub chkLstRunPro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstRunPro.GotFocus
        If chkLstRunPro.Items.Count > 0 Then chkLstRunPro.SetSelected(0, True)
    End Sub

    Private Sub chkLstRunPro_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkLstRunPro.ItemCheck
        Call enableDisableButtons_RunPro()
    End Sub

    Private Sub chkLstRunPro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkLstRunPro.KeyPress
        Call enableDisableButtons_RunPro()
    End Sub

    Private Sub chkLstRunPro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstRunPro.SelectedIndexChanged
        Call enableDisableButtons_RunPro()
        Call displayProcessDetails()
    End Sub

    Private Sub chkLstRunPro_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstRunPro.SelectedValueChanged
        Call enableDisableButtons_RunPro()
    End Sub

    Private Sub btnSaveRunPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveRunPro.Click
        Dim strTemp As String = ""
        For Each item As String In chkLstRunPro.CheckedItems
            item = item.Substring(0, item.IndexOf(" - ("))
            If Trim(item) = "" Then Continue For
            'avoid duplicate saving    
            If Array.IndexOf(arrProcsToTerminate, item) = -1 And Array.IndexOf(strTemp.Split(CChar(",")), item) = -1 Then
                strTemp &= item & ","
            End If
        Next
        If strTemp.EndsWith(",") Then strTemp = strTemp.Remove(strTemp.Length - 1)
        If Not Trim(strTemp) = "" Then
            If Trim(strProcsToTerminate) = "" Then
                strProcsToTerminate = strTemp
            Else
                strProcsToTerminate &= "," & strTemp
            End If
        End If
        If strProcsToTerminate.EndsWith(",") Then strProcsToTerminate = strProcsToTerminate.Remove(strProcsToTerminate.Length - 1)
        objFileOp.SaveTextToFile(strProcsToTerminate, strCurrentHitListPath)
        TabControl1.SelectedTab = tabPgHitList
    End Sub

    Private Sub btnKillRunPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKillRunPro.Click
        statusLabel1.Text = ""
        Dim strTemp As String = ""
        For Each item As String In chkLstRunPro.CheckedItems
            strTemp &= item.Substring(item.IndexOf(" - (") + 4).Replace(")", "") & ","
        Next
        If strTemp.EndsWith(",") Then strTemp = strTemp.Remove(strTemp.Length - 1)
        objFileOp.WriteInfoLog("Current Termination List - " & "Checked Items under running processes tab")
        objModKiller.killProcessByID(strTemp)
        objFileOp.WriteInfoLog("")
        statusLabel1.Text = "Operation Complete in Running_processes Section!"
        Call refreshRunPro()
    End Sub

    Private Sub btnUncheckRunPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUncheckRunPro.Click
        Dim index As Integer
        For index = 0 To chkLstRunPro.Items.Count - 1
            chkLstRunPro.SetItemCheckState(index, CheckState.Unchecked)
        Next
        Call enableDisableButtons_RunPro()
    End Sub

#End Region

#Region "Add Running Processes Tab - Methods"

    Private Sub refreshRunPro()
        Try
            Dim i As Integer
            Dim blnWasErrorThrown As Boolean = False
            lblTotRunPro.Text = "---"
            Try
                ReDim arrCurrProcs(Process.GetProcesses.Length - 1)
                Process.GetProcesses.CopyTo(arrCurrProcs, 0)
            Catch ex As Exception
                objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
                blnWasErrorThrown = True
            End Try
            chkLstRunPro.Items.Clear()
            chkLstRunPro.Sorted = False
            Try
                System.Diagnostics.Process.EnterDebugMode()
            Catch ex As Exception
                'objFileOp.writeErrorLog("Warning: You may not have the neccessary privileges to successfully run this application" & vbNewLine & _
                '"Please check your group policy settings - Enter Debug Mode", "refreshRunPro() - line 890")
            End Try
            For i = 0 To arrCurrProcs.Length - 1
                Try
                    If arrCurrProcs(i).Id = 0 Or arrCurrProcs(i).ProcessName = "System" Then Continue For
                    If arrCurrProcs(i).HasExited = False Then
                        'chkLstRunPro.Items.Add(arrCurrProcs(i).MainModule.ModuleName & " - (" & arrCurrProcs(i).Id.ToString & ")")
                        chkLstRunPro.Items.Add(arrCurrProcs(i).ProcessName & " - (" & arrCurrProcs(i).Id.ToString & ")")
                    End If
                Catch ex As Exception
                    'objFileOp.writeErrorLog(arrCurrProcs(i).ProcessName & " - " & ex.Message, "refreshRunPro - Enumerating checkedlistbox")
                    blnWasErrorThrown = True
                End Try
            Next
            Try
                System.Diagnostics.Process.LeaveDebugMode()
            Catch ex As Exception
                'objFileOp.writeErrorLog(ex.Message, "refreshRunPro() - line 907")
            End Try
            'If blnWasErrorThrown = False Then
            lblTotRunPro.Text = (i - 2).ToString
            'End If
            chkLstRunPro.Sorted = True
            Call enableDisableButtons_RunPro()
            Call displayProcessDetails()
            If blnWasErrorThrown = True Then
                'objFileOp.writeErrorLog("Error while enumerating checkedlistbox", "refreshRunPro() - line 916")
                'MsgBox("Error(s) occured while enumerating the list of current running process." & vbNewLine & _
                '"Please refer the error log for more details.", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub displayProcessDetails()
        Try
            If chkLstRunPro.SelectedItems.Count = 0 Then
                txtRunProDetails.Text = ""
            Else
                Try
                    System.Diagnostics.Process.EnterDebugMode()
                Catch ex As Exception
                    'objFileOp.writeErrorLog("Warning: You may not have the neccessary privileges to successfully run this application" & vbNewLine & _
                    '"Please check your group policy settings - Enter Debug Mode" & vbNewLine & ex.Message, ex.StackTrace)
                End Try
                Dim strSelectedItem As String = chkLstRunPro.SelectedItem.ToString
                Dim intProcID As Integer = CInt(strSelectedItem.Substring(strSelectedItem.IndexOf(" - (") + 4).Replace(")", ""))
                Dim proCurrProc As Process = Process.GetProcessById(intProcID)
                Dim strTempProcDetails As String = ""
                strTempProcDetails = "ID: " & intProcID & vbNewLine
                If proCurrProc.HasExited = True Then
                    strTempProcDetails &= "Process has exited!" & vbNewLine
                    Exit Sub
                Else
                    If Trim(proCurrProc.MainModule.ModuleName) = "" Then
                        strTempProcDetails &= "Name: " & "---" & vbNewLine
                    Else
                        strTempProcDetails &= "Name: " & proCurrProc.MainModule.ModuleName & vbNewLine
                    End If

                    Dim strUserName As String = ""
                    Try
                        Dim args(1) As Object
                        Dim mosProCurrProc As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ProcessId = " & intProcID)
                        'args(0) is user name
                        'args(1) is Domain
                        For Each moProCurrProc As ManagementObject In mosProCurrProc.Get
                            If CInt(moProCurrProc.InvokeMethod("GetOwner", args)) = 0 Then
                                strUserName = args(0).ToString
                            End If
                        Next
                    Catch ex As Exception
                        objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
                    End Try

                    If Trim(strUserName) = "" Then
                        strTempProcDetails &= "User: " & "---" & vbNewLine
                    Else
                        strTempProcDetails &= "User: " & strUserName & vbNewLine
                    End If

                    If Trim(proCurrProc.MainWindowTitle) = "" Then
                        strTempProcDetails &= "Title: " & "---" & vbNewLine
                    Else
                        strTempProcDetails &= "Title: " & proCurrProc.MainWindowTitle & vbNewLine
                    End If

                    If Trim(proCurrProc.MainModule.FileName) = "" Then
                        strTempProcDetails &= "Path: " & "---" & vbNewLine
                    Else
                        strTempProcDetails &= "Path: " & proCurrProc.MainModule.FileName & vbNewLine
                    End If

                    If proCurrProc.Responding = True Then
                        strTempProcDetails &= "Is Responding: " & "YES" & vbNewLine
                    Else
                        strTempProcDetails &= "Is Responding: " & "NO" & vbNewLine
                    End If
                    txtRunProDetails.Text = strTempProcDetails

                End If
            End If
            Try
                System.Diagnostics.Process.LeaveDebugMode()
            Catch ex As Exception
                'objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
            End Try
        Catch ex As Exception
            txtRunProDetails.Text = ex.Message
        End Try
    End Sub

    Private Sub enableDisableButtons_RunPro()
        If chkLstRunPro.CheckedItems.Count = 0 Then
            grpBox1.Text = "Action on checked items"
            btnSaveRunPro.Enabled = False
            btnKillRunPro.Enabled = False
            btnUncheckRunPro.Enabled = False
        Else
            grpBox1.Text = "Action on (" & chkLstRunPro.CheckedItems.Count & ") checked items"
            btnSaveRunPro.Enabled = True
            btnKillRunPro.Enabled = True
            btnUncheckRunPro.Enabled = True
        End If
    End Sub

#End Region

#Region "Edit Hitlist a.k.a ManPro [Add Manual Processes] Tab - Events"

    Private Sub btnRefreshManPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshManPro.Click
        Call refreshManPro()
    End Sub

    Private Sub chkLstManPro_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstManPro.DoubleClick
        Call enableDisableButtons_ManPro()
    End Sub

    Private Sub chkLstManPro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstManPro.GotFocus
        If chkLstManPro.Items.Count > 0 Then chkLstManPro.SetSelected(0, True)
    End Sub

    Private Sub chkLstManPro_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkLstManPro.ItemCheck
        Call enableDisableButtons_ManPro()
    End Sub

    Private Sub chkLstManPro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkLstManPro.KeyPress
        Call enableDisableButtons_ManPro()
    End Sub

    Private Sub chkLstManPro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLstManPro.SelectedIndexChanged
        Call enableDisableButtons_ManPro()
    End Sub

    Private Sub chkLstManPro_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstManPro.SelectedValueChanged
        Call enableDisableButtons_ManPro()
    End Sub

    Private Sub txtNamesManPro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNamesManPro.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNamesManPro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNamesManPro.TextChanged
        If Trim(txtNamesManPro.Text) = "" Or Trim(txtNamesManPro.Text.Replace(",", "")) = "" Then
            btnSaveManPro.Enabled = False
        Else
            btnSaveManPro.Enabled = True
        End If
    End Sub

    Private Sub btnSaveManPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveManPro.Click
        Dim strTemp As String = ""
        Dim arrTemp(-1) As String
        arrTemp = getArrFromString(txtNamesManPro.Text)
        For Each item As String In arrTemp
            If Trim(item) = "" Then Continue For
            'avoid duplicate saving
            If Array.IndexOf(arrProcsToTerminate, Trim(item)) = -1 And Array.IndexOf(strTemp.Split(CChar(",")), item) = -1 Then
                strTemp &= Trim(item) & ","
            End If
        Next
        If strTemp.EndsWith(",") Then strTemp = strTemp.Remove(strTemp.Length - 1)
        ' If strTemp = "" Then MsgBox("Nothing to Save!", MsgBoxStyle.Information) : Exit Sub

        If Not Trim(strTemp) = "" Then
            If Trim(strProcsToTerminate) = "" Then
                strProcsToTerminate = strTemp
            Else
                strProcsToTerminate &= "," & strTemp
            End If
        End If
        If strProcsToTerminate.EndsWith(",") Then strProcsToTerminate = strProcsToTerminate.Remove(strProcsToTerminate.Length - 1)

        If objFileOp.SaveTextToFile(strProcsToTerminate, strCurrentHitListPath) = True Then
            txtNamesManPro.Text = ""
            MsgBox("Saved successfully!", MsgBoxStyle.Information)
        End If
        Call refreshManPro()
    End Sub

    Private Sub btnRemoveManPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveManPro.Click
        Dim strTemp As String = ""
        Dim index As Integer
        For Each item As String In chkLstManPro.CheckedItems
            index = Array.IndexOf(arrProcsToTerminate, item)
            If index > -1 Then
                arrProcsToTerminate(index) = Nothing
            End If
        Next
        strTemp = ""
        For Each item As String In arrProcsToTerminate
            If Not item Is Nothing Then
                strTemp &= item & ","
            End If
        Next
        If strTemp.EndsWith(",") Then strTemp = strTemp.Remove(strTemp.Length - 1)
        If objFileOp.SaveTextToFile(strTemp, strCurrentHitListPath) = True Then
            arrProcsToTerminate = getArrFromString(strTemp)
        End If
        Call refreshManPro()
    End Sub

    Private Sub btnKillManPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKillManPro.Click
        statusLabel1.Text = ""
        Dim strTemp As String = ""
        For Each item As String In chkLstManPro.CheckedItems
            strTemp &= item & ","
        Next
        If strTemp.EndsWith(",") Then strTemp = strTemp.Remove(strTemp.Length - 1)
        objFileOp.WriteInfoLog("Current Termination List - " & "Checked Items under Edit Hitlist Tab for - " & lblNameManProHitlist.Text & ".hitlist")
        objModKiller.killThemAll(strTemp)
        objFileOp.WriteInfoLog("")
        Call refreshManPro()
        statusLabel1.Text = "Operation Complete in Edit_Hitlist Section!"
    End Sub

    Private Sub btnUncheckManPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUncheckManPro.Click
        Dim index As Integer
        For index = 0 To chkLstManPro.Items.Count - 1
            chkLstManPro.SetItemCheckState(index, CheckState.Unchecked)
        Next
        Call enableDisableButtons_ManPro()
    End Sub

#End Region

#Region "Edit Hitlist a.k.a ManPro [Add Manual Processes] Tab - Methods"

    Private Sub refreshManPro()
        Try
            lblNameManProHitlist.Text = Path.GetFileNameWithoutExtension(strCurrentHitListPath)
            chkLstManPro.Items.Clear()
            strProcsToTerminate = objFileOp.ReadTextFromFile(strCurrentHitListPath)
            arrProcsToTerminate = getArrFromString(strProcsToTerminate)
            If arrProcsToTerminate.Length > 0 Then chkLstManPro.Items.AddRange(arrProcsToTerminate)
            Call enableDisableButtons_ManPro()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub enableDisableButtons_ManPro()
        If Trim(txtNamesManPro.Text) = "" Then
            btnSaveManPro.Enabled = False
        Else
            btnSaveManPro.Enabled = True
        End If
        If chkLstManPro.CheckedItems.Count = 0 Then
            grpBox2.Text = "Action on checked items"
            btnRemoveManPro.Enabled = False
            btnKillManPro.Enabled = False
            btnUncheckManPro.Enabled = False
        Else
            grpBox2.Text = "Action on (" & chkLstManPro.CheckedItems.Count & ") checked items"
            btnRemoveManPro.Enabled = True
            btnKillManPro.Enabled = True
            btnUncheckManPro.Enabled = True
        End If
    End Sub

#End Region

#Region "Other Settings Tab - Events"

    Private Sub chkAddToStartup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddToStartup.CheckedChanged
        If chkAddToStartup.Checked = True Then
            regKeyAddToStartup.SetValue(strProductName, Application.ExecutablePath)
        Else
            regKeyAddToStartup.DeleteValue(strProductName, False)
        End If
    End Sub

    Private Sub btnOpenFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFolder.Click
        Try
            If Directory.Exists(strDirPath) Then
                Process.Start(strDirPath)
            Else
                MsgBox("Folder not found at " & vbNewLine & strDirPath, MsgBoxStyle.Exclamation)
                Call fileChecker()
                Call refreshHitlist()
                Call enableDisableButtons_Hitlist()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnClearErrLog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearErrLog.Click
        Try
            If MsgBox("Are you sure you want to clear the Error Log?", _
            CType(vbYesNo + vbQuestion, MsgBoxStyle)) = MsgBoxResult.Yes Then
                objFileOp.SaveTextToFile("", strDirPath & "Logs\Error log.log")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
        Call activateClearLogsSection()
    End Sub

    Private Sub btnClearTermLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearTermLog.Click
        Try
            If MsgBox("Are you sure you want to clear all of the Termination Logs?", _
            CType(vbYesNo + vbQuestion, MsgBoxStyle)) = MsgBoxResult.Yes Then
                For Each strFilePath As String In Directory.GetFiles(strDirPath & "Logs\", "*.log")
                    If My.Computer.FileSystem.GetName(strFilePath).Contains("Termination Log") Then
                        File.Delete(strFilePath)
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
        Call activateClearLogsSection()
    End Sub

    Private Sub btnClearAllLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAllLog.Click
        Try
            If MsgBox("Are you sure you want to clear all the Termination Logs including the Error Log?", _
            CType(vbYesNo + vbQuestion, MsgBoxStyle)) = MsgBoxResult.Yes Then
                If File.Exists(strDirPath & "Logs\Error log.log") Then
                    objFileOp.SaveTextToFile("", strDirPath & "Logs\Error log.log")
                End If
                For Each strFilePath As String In Directory.GetFiles(strDirPath & "Logs\", "*.log")
                    If My.Computer.FileSystem.GetName(strFilePath).Contains("Termination Log") Then
                        File.Delete(strFilePath)
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
        Call activateClearLogsSection()
    End Sub

    Private Sub chkAutoClearLogs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoClearLogs.CheckedChanged
        If chkAutoClearLogs.Checked = True Then
            regKeyAutoClear.SetValue("is_true", "yes", RegistryValueKind.String)
            lblAutoClearDays.Enabled = True
            txtAutoClearDays.Enabled = True
            If regKeyAutoClear.GetValue("interval") Is Nothing Then
                regKeyAutoClear.SetValue("interval", defaultDays, RegistryValueKind.String)
            End If
            txtAutoClearDays.Text = regKeyAutoClear.GetValue("interval").ToString
        Else
            regKeyAutoClear.SetValue("is_true", "no", RegistryValueKind.String)
            lblAutoClearDays.Enabled = False
            txtAutoClearDays.Enabled = False
            txtAutoClearDays.Text = ""
        End If
    End Sub

    Private Sub chkEnableTimer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableTimer.CheckedChanged
        If chkEnableTimer.Checked = True Then
            regKeyKillTimer.SetValue("is_true", "yes", RegistryValueKind.String)
            lblKillTimer.Enabled = True
            txtTimeInMinutes.Enabled = True
            If regKeyKillTimer.GetValue("interval") Is Nothing Then
                regKeyKillTimer.SetValue("interval", defaultMilliSeconds, RegistryValueKind.String)
            End If
            Dim millisecs As Integer = CInt(regKeyKillTimer.GetValue("interval"))
            txtTimeInMinutes.Text = (millisecs / defaultMilliSeconds).ToString
            Timer1.Interval = millisecs
            Timer1.Start()
            statusLabel1.Text = "Timer is Enabled."
        Else
            Timer1.Stop()
            statusLabel1.Text = "Timer has been Disabled."
            regKeyKillTimer.SetValue("is_true", "no", RegistryValueKind.String)
            lblKillTimer.Enabled = False
            txtTimeInMinutes.Enabled = False
            txtTimeInMinutes.Text = ""
        End If
    End Sub

    Private Sub txtAutoClearDays_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAutoClearDays.TextChanged
        If Trim(txtAutoClearDays.Text) = "" Then Exit Sub
        For Each character As Char In txtAutoClearDays.Text.ToCharArray
            If Array.IndexOf("1234567890".ToCharArray, character) = -1 Then
                MsgBox("Please enter only numbers in the textbox", MsgBoxStyle.Information)
                txtAutoClearDays.Text = ""
                Exit For
            Else
                regKeyAutoClear.SetValue("interval", Trim(txtAutoClearDays.Text), RegistryValueKind.String)
            End If
        Next
    End Sub

    Private Sub txtAutoClearDays_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAutoClearDays.Validated
        If Trim(txtAutoClearDays.Text) = "" And chkAutoClearLogs.Checked = True Then
            txtAutoClearDays.Text = defaultDays 'default auto clear value is 365.
        End If
    End Sub

    Private Sub txtTimeInMinutes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTimeInMinutes.TextChanged
        If Trim(txtTimeInMinutes.Text) = "" Then Exit Sub
        For Each character As Char In txtTimeInMinutes.Text.ToCharArray
            If Array.IndexOf("1234567890".ToCharArray, character) = -1 Then
                MsgBox("Please enter only numbers in the textbox", MsgBoxStyle.Information)
                txtTimeInMinutes.Text = ""
                Timer1.Stop()
                statusLabel1.Text = "Timer has been Disabled."
                Exit For
            Else
                Dim millisecs As Integer = CInt(Trim(txtTimeInMinutes.Text)) * defaultMilliSeconds
                regKeyKillTimer.SetValue("interval", millisecs, RegistryValueKind.String)
                Timer1.Interval = millisecs
                Timer1.Start()
                statusLabel1.Text = "Timer is Enabled."
            End If
        Next
    End Sub

    Private Sub txtTimeInMinutes_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimeInMinutes.Validated
        If Trim(txtTimeInMinutes.Text) = "" And chkAutoClearLogs.Checked = True Then
            txtTimeInMinutes.Text = "1" 'default timer value is 1 minute (60000 milliseconds). 
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim millisecs As Integer = CInt(txtTimeInMinutes.Text) * defaultMilliSeconds
        If (Timer1.Interval = millisecs) Then
            btnKillOtherSettings_Click(btnKillOtherSettings, System.EventArgs.Empty)
        End If
        statusLabel1.Text &= " - Initiated by Auto Kill Timer at " & Format(Now, "hh:mm:ss tt")
    End Sub

    Private Sub btnMinimizeToTray_Click(sender As Object, e As EventArgs) Handles btnMinimizeToTray.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub chkChooseOnExeution_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChooseOnExeution.CheckedChanged
        Call enableDisableBtnUpdate()
        If chkChooseOnExeution.Checked = True Then
            chkLstExecOrder.Enabled = False
            Call populateChkLstExecOrder()
        ElseIf chkChooseOnExeution.Checked = False Then
            chkLstExecOrder.Enabled = True
            Call selectHitlists()
        End If
    End Sub

    Private Sub chkLstExecOrder_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstExecOrder.DoubleClick
        Call enableDisableBtnUpdate()
    End Sub

    Private Sub chkLstExecOrder_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstExecOrder.GotFocus
        If chkLstExecOrder.Items.Count > 0 Then chkLstExecOrder.SetSelected(0, True)
    End Sub

    Private Sub chkLstExecOrder_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkLstExecOrder.ItemCheck
        Call enableDisableBtnUpdate()
    End Sub

    Private Sub chkLstExecOrder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkLstExecOrder.KeyPress
        Call enableDisableBtnUpdate()
    End Sub

    Private Sub chkLstExecOrder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLstExecOrder.SelectedIndexChanged
        Call enableDisableBtnUpdate()
    End Sub

    Private Sub chkLstExecOrder_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstExecOrder.SelectedValueChanged
        Call enableDisableBtnUpdate()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        btnUpdate.Enabled = False
        If chkChooseOnExeution.Checked = True Then
            objFileOp.SaveTextToFile("", strExecuteOrderIniPath)
            ReDim arrExecuteOrder(-1)
        ElseIf chkChooseOnExeution.Checked = False Then
            Dim strTemp As String = ""
            For Each item As String In chkLstExecOrder.CheckedItems
                strTemp &= item & ","
            Next
            If strTemp.EndsWith(",") Then strTemp = strTemp.Remove(strTemp.Length - 1)
            objFileOp.SaveTextToFile(strTemp, strExecuteOrderIniPath)
        End If
        Call updateArrExecuteOrder()
    End Sub

    Private Sub btnKillOtherSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKillOtherSettings.Click
        Try
            statusLabel1.Text = ""
            Console.Write(e)
            Call updateArrExecuteOrder()
            If intHitlistCount = 1 Then 'terminate single hitlist
                strProcsToTerminate = objFileOp.ReadTextFromFile(strCurrentHitListPath)
                If Not strProcsToTerminate.Length = 0 Then
                    objFileOp.WriteInfoLog("Current Termination List - " & Path.GetFileName(strCurrentHitListPath))
                    Call objModKiller.killThemAll(strProcsToTerminate)
                    objFileOp.WriteInfoLog("")
                Else
                    statusLabel1.Text = "No Processes found in hitlist - Nothing was terminated!"
                    objFileOp.WriteInfoLog("No Processes found in hitlist - Nothing was terminated!")
                    objFileOp.WriteInfoLog("")
                End If
            ElseIf intHitlistCount > 1 Then
                If arrExecuteOrder.Length = 0 Then
                    Timer1.Stop()
                    frmHitlistChooser.ShowDialog()  'show a modal window and wait for the user to choose hitlists to terminate.
                    Timer1.Start()
                    'if still no hitlists available, then, show error msg.
                    If arrExecuteOrder Is Nothing Or arrExecuteOrder.Length = 0 Then
                        Timer1.Stop()
                        MsgBox("No Hitlist was chosen for termination!", MsgBoxStyle.Exclamation)
                        Timer1.Start()
                        Exit Sub
                    End If
                End If
                For Each hitListFile As String In arrExecuteOrder 'terminate all hitlists in executeorder.ini
                    Dim strCurrentHitListPath_temp As String
                    strCurrentHitListPath_temp = strDirPath & hitListFile
                    strProcsToTerminate = objFileOp.ReadTextFromFile(strCurrentHitListPath_temp)
                    If strProcsToTerminate.Length > 0 Then
                        objFileOp.WriteInfoLog("Current Termination List - " & hitListFile)
                        Call objModKiller.killThemAll(strProcsToTerminate)
                        objFileOp.WriteInfoLog("")
                    Else
                        objFileOp.WriteInfoLog("Current Termination List - " & hitListFile)
                        objFileOp.WriteInfoLog("No Processes found in hitlist - Nothing was terminated!")
                        objFileOp.WriteInfoLog("")
                    End If
                Next
            End If
            statusLabel1.Text = "Operation Complete in Other_Settings Section!"
            Call updateArrExecuteOrder()

            Call populateChkLstExecOrder() 'populate chkLstExecOrder with ALL Hitlist names     
            If arrExecuteOrder.Length > 0 Then 'Execute order is available
                chkChooseOnExeution.Checked = False
            Else 'Executeorder not available, so choose it during execution
                chkChooseOnExeution.Checked = True
            End If
            Call chkChooseOnExeution_CheckedChanged(Nothing, Nothing)
            btnUpdate.Enabled = False
            Call activateClearLogsSection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

#End Region

#Region "Other Settings Tab - Methods"

    Private Sub enableDisableBtnUpdate()
        If chkChooseOnExeution.Checked = False And chkLstExecOrder.CheckedItems.Count = 0 Then
            btnUpdate.Enabled = False
        Else
            btnUpdate.Enabled = True
        End If
    End Sub

    Private Sub populateChkLstExecOrder()
        chkLstExecOrder.Items.Clear()
        If arrHitlistFiles.Length > 0 Then
            chkLstExecOrder.Items.AddRange(arrHitlistFiles)
        End If
    End Sub

    Private Sub selectHitlists()
        Call updateArrExecuteOrder()
        For i As Integer = 0 To chkLstExecOrder.Items.Count - 1
            If Array.IndexOf(arrExecuteOrder, chkLstExecOrder.Items.Item(i)) > -1 Then
                chkLstExecOrder.SetItemCheckState(i, CheckState.Checked)
            Else
                chkLstExecOrder.SetItemCheckState(i, CheckState.Unchecked)
            End If
        Next
    End Sub

    Private Sub activateClearLogsSection()
        Dim strLogDirPath As String = strDirPath & "Logs\"
        Dim strErrLogPath As String = strLogDirPath & "Error log.log"
        Dim dblErrLogSizeInBytes As Double = 0.0
        Dim dblAllLogSizeInBytes As Double = 0.0
        Dim dblTermLogSizeInBytes As Double = 0.0

        If Not Directory.Exists(strLogDirPath) Then
            lblErrLogSize.Text = changeFileSizeUnit(dblErrLogSizeInBytes)
            lblTermLogSize.Text = changeFileSizeUnit(dblTermLogSizeInBytes)
            lblAllLogSize.Text = changeFileSizeUnit(dblAllLogSizeInBytes)
            Call enableDisableClearLogButtons()
            Directory.CreateDirectory(strLogDirPath)
            File.Create(strErrLogPath).Close()
            Exit Sub
        End If

        For Each strLogFilePath As String In Directory.GetFiles(strLogDirPath, "*.log")
            dblAllLogSizeInBytes += My.Computer.FileSystem.GetFileInfo(strLogFilePath).Length
        Next
        If File.Exists(strErrLogPath) Then
            dblErrLogSizeInBytes = My.Computer.FileSystem.GetFileInfo(strErrLogPath).Length
        End If
        dblTermLogSizeInBytes = dblAllLogSizeInBytes - dblErrLogSizeInBytes

        lblErrLogSize.Text = changeFileSizeUnit(dblErrLogSizeInBytes)
        lblTermLogSize.Text = changeFileSizeUnit(dblTermLogSizeInBytes)
        lblAllLogSize.Text = changeFileSizeUnit(dblAllLogSizeInBytes)
        Call enableDisableClearLogButtons()
    End Sub

    Private Function changeFileSizeUnit(ByVal sizeInBytes As Double) As String
        Dim convertedSize As Double
        Try
            Select Case sizeInBytes
                Case Is >= 1073741824 '=GB
                    convertedSize = sizeInBytes / (1024 ^ 3)
                    changeFileSizeUnit = Math.Round(convertedSize, 2).ToString & " " & "GB"
                Case Is >= 1048576 '=MB
                    convertedSize = sizeInBytes / (1024 ^ 2)
                    changeFileSizeUnit = Math.Round(convertedSize, 2).ToString & " " & "MB"
                Case Is >= 1024 '=KB
                    convertedSize = sizeInBytes / 1024
                    changeFileSizeUnit = Math.Round(convertedSize, 2).ToString & " " & "KB"
                Case Is >= 1 '=Bytes
                    convertedSize = sizeInBytes
                    changeFileSizeUnit = Math.Round(convertedSize, 2).ToString & " " & "Byte(s)"
                Case Is > 0 '=bits
                    convertedSize = sizeInBytes * 8
                    changeFileSizeUnit = Math.Round(convertedSize, 2).ToString & " " & "Bit(s)"
                Case Else ' means size is 0, empty or no file.
                    convertedSize = 0
                    changeFileSizeUnit = Math.Round(convertedSize, 2).ToString & " " & "Bit(s)"
            End Select
        Catch ex As Exception
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
            Return "Error"
        End Try
    End Function

    Private Sub enableDisableClearLogButtons()
        If lblErrLogSize.Text = "0 Bit(s)" Or lblErrLogSize.Text = "Error" Then
            btnClearErrLog.Enabled = False
        Else
            btnClearErrLog.Enabled = True
        End If
        If lblTermLogSize.Text = "0 Bit(s)" Or lblTermLogSize.Text = "Error" Then
            btnClearTermLog.Enabled = False
        Else
            btnClearTermLog.Enabled = True
        End If
        If lblAllLogSize.Text = "0 Bit(s)" Or lblAllLogSize.Text = "Error" Then
            btnClearAllLog.Enabled = False
        Else
            btnClearAllLog.Enabled = True
        End If
    End Sub

    Private Sub autoClearTerminationLogs()
        Dim intInterval As Integer
        Dim strLogDirPath As String = strDirPath & "Logs\"
        If Not Trim(txtAutoClearDays.Text) = "" Then
            intInterval = CInt(Trim(txtAutoClearDays.Text))
        End If

        If Not Directory.Exists(Path.GetDirectoryName(strLogDirPath)) Then Exit Sub
        For Each strFilePath As String In Directory.GetFiles(strLogDirPath, "*Termination Log.log")
            Dim intFileDate As String = Path.GetFileNameWithoutExtension(strFilePath).Substring(0, 9)
            Dim dtFileDate As Date = CDate(intFileDate)
            Dim dtDateDifference As Integer = Date.Now.Subtract(dtFileDate).Days
            If dtDateDifference >= intInterval Then
                File.Delete(strFilePath)
            End If
        Next
    End Sub

#End Region

#Region "About Tab - Events"

    Private Sub lnkUserGuide_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) _
        Handles lnkUserGuide.LinkClicked
        Try
            Dim pdfAsByteArray As Byte() = My.Resources.AKAP_User_Guide
            Dim ms As MemoryStream = New MemoryStream(pdfAsByteArray)
            Dim f As FileStream = New FileStream(strDirPath & "AKAP User Guide.pdf", FileMode.OpenOrCreate)
            ms.WriteTo(f)
            f.Close()
            ms.Close()
            System.Diagnostics.Process.Start(strDirPath & "AKAP User Guide.pdf")
        Catch ex As Exception
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
            MsgBox("Unable to open the user guide, please visit the product's webpage to download it.", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub lnkContact_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) _
      Handles lnkContact.LinkClicked
        If MsgBox("This will open your default e-mail client." + vbNewLine + "would you like to continue?", _
        CType(vbYesNo + vbQuestion, MsgBoxStyle)) = MsgBoxResult.Yes Then
            System.Diagnostics.Process.Start("mailto:" & lnkContact.Text)
        End If
    End Sub

    Private Sub lnkWebsite_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) _
    Handles lnkWebsite.LinkClicked
        System.Diagnostics.Process.Start(lnkWebsite.Text)
    End Sub

    Private Sub lnkLblLicense_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles lnkLicense.LinkClicked
        System.Diagnostics.Process.Start("http://www.gnu.org/licenses/gpl-3.0.html")
    End Sub
    Private Sub lblUserGuide_Click(sender As Object, e As EventArgs) Handles lblUserGuide.Click
        Call lnkUserGuide_LinkClicked(Nothing, Nothing)
    End Sub

    Private Sub lblContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblContact.Click
        Call lnkContact_LinkClicked(Nothing, Nothing)
    End Sub

    Private Sub lblWebsite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblWebsite.Click
        Call lnkWebsite_LinkClicked(Nothing, Nothing)
    End Sub
    Private Sub lblLicense_Click(sender As Object, e As EventArgs) Handles lblLicense.Click
        Call lnkLblLicense_LinkClicked(Nothing, Nothing)
    End Sub

#End Region

#Region "About Tab - Methods"

    'placeholder for future methods.

#End Region

End Class

#End Region