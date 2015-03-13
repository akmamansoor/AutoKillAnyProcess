<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPgHitList = New System.Windows.Forms.TabPage()
        Me.pnlHitlistActions = New System.Windows.Forms.Panel()
        Me.btnSaveHitList = New System.Windows.Forms.Button()
        Me.btnNewHitlist = New System.Windows.Forms.Button()
        Me.btnRefreshHitList = New System.Windows.Forms.Button()
        Me.btnKillHitlist = New System.Windows.Forms.Button()
        Me.btnRenameHitList = New System.Windows.Forms.Button()
        Me.btnOpenHitlist = New System.Windows.Forms.Button()
        Me.btnDelHitList = New System.Windows.Forms.Button()
        Me.btnCancelHilist = New System.Windows.Forms.Button()
        Me.btnOKHitList = New System.Windows.Forms.Button()
        Me.lblNameHitList = New System.Windows.Forms.Label()
        Me.lstHitListProcs = New System.Windows.Forms.ListBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtNameHitList = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tabPgRunPro = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRunProDetails = New System.Windows.Forms.TextBox()
        Me.grpBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSaveRunPro = New System.Windows.Forms.Button()
        Me.btnKillRunPro = New System.Windows.Forms.Button()
        Me.btnUncheckRunPro = New System.Windows.Forms.Button()
        Me.lblTotRunPro = New System.Windows.Forms.Label()
        Me.btnRefreshRunPro = New System.Windows.Forms.Button()
        Me.chkLstRunPro = New System.Windows.Forms.CheckedListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tabPgManPro = New System.Windows.Forms.TabPage()
        Me.lblNameManProHitlist = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSaveManPro = New System.Windows.Forms.Button()
        Me.txtNamesManPro = New System.Windows.Forms.TextBox()
        Me.grpBox2 = New System.Windows.Forms.GroupBox()
        Me.btnRemoveManPro = New System.Windows.Forms.Button()
        Me.btnUncheckManPro = New System.Windows.Forms.Button()
        Me.btnKillManPro = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnRefreshManPro = New System.Windows.Forms.Button()
        Me.chkLstManPro = New System.Windows.Forms.CheckedListBox()
        Me.tabPgOtherSettings = New System.Windows.Forms.TabPage()
        Me.grpBoxTimer = New System.Windows.Forms.GroupBox()
        Me.btnMinimizeToTray = New System.Windows.Forms.Button()
        Me.txtTimeInMinutes = New System.Windows.Forms.TextBox()
        Me.lblKillTimer = New System.Windows.Forms.Label()
        Me.chkEnableTimer = New System.Windows.Forms.CheckBox()
        Me.grpBoxClearLogs = New System.Windows.Forms.GroupBox()
        Me.btnOpenFolder = New System.Windows.Forms.Button()
        Me.lblAllLogSize = New System.Windows.Forms.Label()
        Me.lblTermLogSize = New System.Windows.Forms.Label()
        Me.lblErrLogSize = New System.Windows.Forms.Label()
        Me.btnClearAllLog = New System.Windows.Forms.Button()
        Me.btnClearTermLog = New System.Windows.Forms.Button()
        Me.btnClearErrLog = New System.Windows.Forms.Button()
        Me.grpBoxMisc = New System.Windows.Forms.GroupBox()
        Me.chkAddToStartup = New System.Windows.Forms.CheckBox()
        Me.grpBox3 = New System.Windows.Forms.GroupBox()
        Me.btnKillOtherSettings = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.chkChooseOnExeution = New System.Windows.Forms.CheckBox()
        Me.chkLstExecOrder = New System.Windows.Forms.CheckedListBox()
        Me.grpBoxAutoClearLogs = New System.Windows.Forms.GroupBox()
        Me.txtAutoClearDays = New System.Windows.Forms.TextBox()
        Me.lblAutoClearDays = New System.Windows.Forms.Label()
        Me.chkAutoClearLogs = New System.Windows.Forms.CheckBox()
        Me.tabPgAbout = New System.Windows.Forms.TabPage()
        Me.lblLicense = New System.Windows.Forms.Label()
        Me.lnkLicense = New System.Windows.Forms.LinkLabel()
        Me.lblUserGuide = New System.Windows.Forms.Label()
        Me.lnkUserGuide = New System.Windows.Forms.LinkLabel()
        Me.richtextboxAbout = New System.Windows.Forms.RichTextBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblWebsite = New System.Windows.Forms.Label()
        Me.lnkWebsite = New System.Windows.Forms.LinkLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.lnkContact = New System.Windows.Forms.LinkLabel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.tabPgHitList.SuspendLayout()
        Me.pnlHitlistActions.SuspendLayout()
        Me.tabPgRunPro.SuspendLayout()
        Me.grpBox1.SuspendLayout()
        Me.tabPgManPro.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpBox2.SuspendLayout()
        Me.tabPgOtherSettings.SuspendLayout()
        Me.grpBoxTimer.SuspendLayout()
        Me.grpBoxClearLogs.SuspendLayout()
        Me.grpBoxMisc.SuspendLayout()
        Me.grpBox3.SuspendLayout()
        Me.grpBoxAutoClearLogs.SuspendLayout()
        Me.tabPgAbout.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabPgHitList)
        Me.TabControl1.Controls.Add(Me.tabPgRunPro)
        Me.TabControl1.Controls.Add(Me.tabPgManPro)
        Me.TabControl1.Controls.Add(Me.tabPgOtherSettings)
        Me.TabControl1.Controls.Add(Me.tabPgAbout)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(694, 399)
        Me.TabControl1.TabIndex = 0
        '
        'tabPgHitList
        '
        Me.tabPgHitList.BackColor = System.Drawing.Color.Transparent
        Me.tabPgHitList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabPgHitList.Controls.Add(Me.pnlHitlistActions)
        Me.tabPgHitList.Controls.Add(Me.btnCancelHilist)
        Me.tabPgHitList.Controls.Add(Me.btnOKHitList)
        Me.tabPgHitList.Controls.Add(Me.lblNameHitList)
        Me.tabPgHitList.Controls.Add(Me.lstHitListProcs)
        Me.tabPgHitList.Controls.Add(Me.btnExit)
        Me.tabPgHitList.Controls.Add(Me.txtNameHitList)
        Me.tabPgHitList.Controls.Add(Me.Label3)
        Me.tabPgHitList.Location = New System.Drawing.Point(4, 22)
        Me.tabPgHitList.Name = "tabPgHitList"
        Me.tabPgHitList.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPgHitList.Size = New System.Drawing.Size(686, 373)
        Me.tabPgHitList.TabIndex = 0
        Me.tabPgHitList.Text = "Hitlist Operations"
        Me.tabPgHitList.UseVisualStyleBackColor = True
        '
        'pnlHitlistActions
        '
        Me.pnlHitlistActions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlHitlistActions.Controls.Add(Me.btnSaveHitList)
        Me.pnlHitlistActions.Controls.Add(Me.btnNewHitlist)
        Me.pnlHitlistActions.Controls.Add(Me.btnRefreshHitList)
        Me.pnlHitlistActions.Controls.Add(Me.btnKillHitlist)
        Me.pnlHitlistActions.Controls.Add(Me.btnRenameHitList)
        Me.pnlHitlistActions.Controls.Add(Me.btnOpenHitlist)
        Me.pnlHitlistActions.Controls.Add(Me.btnDelHitList)
        Me.pnlHitlistActions.Location = New System.Drawing.Point(4, 275)
        Me.pnlHitlistActions.Name = "pnlHitlistActions"
        Me.pnlHitlistActions.Size = New System.Drawing.Size(239, 92)
        Me.pnlHitlistActions.TabIndex = 8
        '
        'btnSaveHitList
        '
        Me.btnSaveHitList.AutoSize = True
        Me.btnSaveHitList.BackColor = System.Drawing.Color.Transparent
        Me.btnSaveHitList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSaveHitList.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnSaveHitList.FlatAppearance.BorderSize = 10
        Me.btnSaveHitList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveHitList.ForeColor = System.Drawing.Color.Green
        Me.btnSaveHitList.Location = New System.Drawing.Point(153, 3)
        Me.btnSaveHitList.Name = "btnSaveHitList"
        Me.btnSaveHitList.Size = New System.Drawing.Size(72, 23)
        Me.btnSaveHitList.TabIndex = 8
        Me.btnSaveHitList.Text = "&Save as"
        Me.btnSaveHitList.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveHitList.UseVisualStyleBackColor = False
        '
        'btnNewHitlist
        '
        Me.btnNewHitlist.AutoSize = True
        Me.btnNewHitlist.BackColor = System.Drawing.Color.Transparent
        Me.btnNewHitlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNewHitlist.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnNewHitlist.FlatAppearance.BorderSize = 10
        Me.btnNewHitlist.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewHitlist.ForeColor = System.Drawing.Color.Black
        Me.btnNewHitlist.Location = New System.Drawing.Point(4, 3)
        Me.btnNewHitlist.Name = "btnNewHitlist"
        Me.btnNewHitlist.Size = New System.Drawing.Size(65, 23)
        Me.btnNewHitlist.TabIndex = 6
        Me.btnNewHitlist.Text = "&New"
        Me.btnNewHitlist.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNewHitlist.UseVisualStyleBackColor = False
        '
        'btnRefreshHitList
        '
        Me.btnRefreshHitList.AutoSize = True
        Me.btnRefreshHitList.BackColor = System.Drawing.Color.Transparent
        Me.btnRefreshHitList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRefreshHitList.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnRefreshHitList.FlatAppearance.BorderSize = 10
        Me.btnRefreshHitList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshHitList.ForeColor = System.Drawing.Color.Black
        Me.btnRefreshHitList.Location = New System.Drawing.Point(4, 32)
        Me.btnRefreshHitList.Name = "btnRefreshHitList"
        Me.btnRefreshHitList.Size = New System.Drawing.Size(65, 23)
        Me.btnRefreshHitList.TabIndex = 9
        Me.btnRefreshHitList.Text = "&Refresh"
        Me.btnRefreshHitList.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefreshHitList.UseVisualStyleBackColor = False
        '
        'btnKillHitlist
        '
        Me.btnKillHitlist.AutoSize = True
        Me.btnKillHitlist.BackColor = System.Drawing.Color.Transparent
        Me.btnKillHitlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnKillHitlist.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnKillHitlist.FlatAppearance.BorderSize = 10
        Me.btnKillHitlist.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKillHitlist.ForeColor = System.Drawing.Color.Red
        Me.btnKillHitlist.Location = New System.Drawing.Point(4, 61)
        Me.btnKillHitlist.Name = "btnKillHitlist"
        Me.btnKillHitlist.Size = New System.Drawing.Size(221, 23)
        Me.btnKillHitlist.TabIndex = 12
        Me.btnKillHitlist.Text = "&Kill Now!"
        Me.btnKillHitlist.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnKillHitlist.UseVisualStyleBackColor = False
        '
        'btnRenameHitList
        '
        Me.btnRenameHitList.AutoSize = True
        Me.btnRenameHitList.BackColor = System.Drawing.Color.Transparent
        Me.btnRenameHitList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRenameHitList.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnRenameHitList.FlatAppearance.BorderSize = 10
        Me.btnRenameHitList.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnRenameHitList.ForeColor = System.Drawing.Color.Black
        Me.btnRenameHitList.Location = New System.Drawing.Point(75, 32)
        Me.btnRenameHitList.Name = "btnRenameHitList"
        Me.btnRenameHitList.Size = New System.Drawing.Size(72, 23)
        Me.btnRenameHitList.TabIndex = 10
        Me.btnRenameHitList.Text = "R&ename"
        Me.btnRenameHitList.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRenameHitList.UseVisualStyleBackColor = False
        '
        'btnOpenHitlist
        '
        Me.btnOpenHitlist.AutoSize = True
        Me.btnOpenHitlist.BackColor = System.Drawing.Color.Transparent
        Me.btnOpenHitlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnOpenHitlist.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnOpenHitlist.FlatAppearance.BorderSize = 10
        Me.btnOpenHitlist.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenHitlist.ForeColor = System.Drawing.Color.Black
        Me.btnOpenHitlist.Location = New System.Drawing.Point(75, 3)
        Me.btnOpenHitlist.Name = "btnOpenHitlist"
        Me.btnOpenHitlist.Size = New System.Drawing.Size(72, 23)
        Me.btnOpenHitlist.TabIndex = 7
        Me.btnOpenHitlist.Text = "&Open"
        Me.btnOpenHitlist.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOpenHitlist.UseVisualStyleBackColor = False
        '
        'btnDelHitList
        '
        Me.btnDelHitList.AutoSize = True
        Me.btnDelHitList.BackColor = System.Drawing.Color.Transparent
        Me.btnDelHitList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDelHitList.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnDelHitList.FlatAppearance.BorderSize = 10
        Me.btnDelHitList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelHitList.ForeColor = System.Drawing.Color.Black
        Me.btnDelHitList.Location = New System.Drawing.Point(153, 32)
        Me.btnDelHitList.Name = "btnDelHitList"
        Me.btnDelHitList.Size = New System.Drawing.Size(72, 23)
        Me.btnDelHitList.TabIndex = 11
        Me.btnDelHitList.Text = "&Delete"
        Me.btnDelHitList.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelHitList.UseVisualStyleBackColor = False
        '
        'btnCancelHilist
        '
        Me.btnCancelHilist.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelHilist.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelHilist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancelHilist.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCancelHilist.FlatAppearance.BorderSize = 10
        Me.btnCancelHilist.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnCancelHilist.ForeColor = System.Drawing.Color.Black
        Me.btnCancelHilist.Location = New System.Drawing.Point(623, 10)
        Me.btnCancelHilist.Name = "btnCancelHilist"
        Me.btnCancelHilist.Size = New System.Drawing.Size(55, 22)
        Me.btnCancelHilist.TabIndex = 4
        Me.btnCancelHilist.Text = "Cancel"
        Me.btnCancelHilist.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelHilist.UseVisualStyleBackColor = False
        Me.btnCancelHilist.Visible = False
        '
        'btnOKHitList
        '
        Me.btnOKHitList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOKHitList.BackColor = System.Drawing.Color.Transparent
        Me.btnOKHitList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnOKHitList.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnOKHitList.FlatAppearance.BorderSize = 10
        Me.btnOKHitList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOKHitList.ForeColor = System.Drawing.Color.Black
        Me.btnOKHitList.Location = New System.Drawing.Point(585, 9)
        Me.btnOKHitList.Name = "btnOKHitList"
        Me.btnOKHitList.Size = New System.Drawing.Size(32, 22)
        Me.btnOKHitList.TabIndex = 3
        Me.btnOKHitList.Text = "OK"
        Me.btnOKHitList.UseVisualStyleBackColor = False
        Me.btnOKHitList.Visible = False
        '
        'lblNameHitList
        '
        Me.lblNameHitList.AutoSize = True
        Me.lblNameHitList.BackColor = System.Drawing.Color.Transparent
        Me.lblNameHitList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameHitList.Location = New System.Drawing.Point(53, 15)
        Me.lblNameHitList.Name = "lblNameHitList"
        Me.lblNameHitList.Size = New System.Drawing.Size(31, 13)
        Me.lblNameHitList.TabIndex = 1
        Me.lblNameHitList.Text = "----"
        '
        'lstHitListProcs
        '
        Me.lstHitListProcs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstHitListProcs.BackColor = System.Drawing.SystemColors.Control
        Me.lstHitListProcs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstHitListProcs.FormattingEnabled = True
        Me.lstHitListProcs.HorizontalScrollbar = True
        Me.lstHitListProcs.Location = New System.Drawing.Point(4, 43)
        Me.lstHitListProcs.Name = "lstHitListProcs"
        Me.lstHitListProcs.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstHitListProcs.Size = New System.Drawing.Size(674, 212)
        Me.lstHitListProcs.Sorted = True
        Me.lstHitListProcs.TabIndex = 5
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.AutoSize = True
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.Black
        Me.btnExit.Location = New System.Drawing.Point(249, 278)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(60, 23)
        Me.btnExit.TabIndex = 13
        Me.btnExit.Text = "E&XIT"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'txtNameHitList
        '
        Me.txtNameHitList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNameHitList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNameHitList.Location = New System.Drawing.Point(51, 11)
        Me.txtNameHitList.Name = "txtNameHitList"
        Me.txtNameHitList.Size = New System.Drawing.Size(528, 21)
        Me.txtNameHitList.TabIndex = 2
        Me.txtNameHitList.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Name : "
        '
        'tabPgRunPro
        '
        Me.tabPgRunPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabPgRunPro.Controls.Add(Me.Label10)
        Me.tabPgRunPro.Controls.Add(Me.txtRunProDetails)
        Me.tabPgRunPro.Controls.Add(Me.grpBox1)
        Me.tabPgRunPro.Controls.Add(Me.lblTotRunPro)
        Me.tabPgRunPro.Controls.Add(Me.btnRefreshRunPro)
        Me.tabPgRunPro.Controls.Add(Me.chkLstRunPro)
        Me.tabPgRunPro.Controls.Add(Me.Label6)
        Me.tabPgRunPro.Location = New System.Drawing.Point(4, 22)
        Me.tabPgRunPro.Name = "tabPgRunPro"
        Me.tabPgRunPro.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPgRunPro.Size = New System.Drawing.Size(686, 373)
        Me.tabPgRunPro.TabIndex = 1
        Me.tabPgRunPro.Text = "Add Running Processes"
        Me.tabPgRunPro.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label10.Location = New System.Drawing.Point(304, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Process Details:"
        '
        'txtRunProDetails
        '
        Me.txtRunProDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRunProDetails.Location = New System.Drawing.Point(306, 49)
        Me.txtRunProDetails.Multiline = True
        Me.txtRunProDetails.Name = "txtRunProDetails"
        Me.txtRunProDetails.ReadOnly = True
        Me.txtRunProDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRunProDetails.Size = New System.Drawing.Size(372, 170)
        Me.txtRunProDetails.TabIndex = 4
        Me.txtRunProDetails.TabStop = False
        '
        'grpBox1
        '
        Me.grpBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpBox1.Controls.Add(Me.btnSaveRunPro)
        Me.grpBox1.Controls.Add(Me.btnKillRunPro)
        Me.grpBox1.Controls.Add(Me.btnUncheckRunPro)
        Me.grpBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBox1.Location = New System.Drawing.Point(307, 237)
        Me.grpBox1.Name = "grpBox1"
        Me.grpBox1.Size = New System.Drawing.Size(180, 132)
        Me.grpBox1.TabIndex = 6
        Me.grpBox1.TabStop = False
        Me.grpBox1.Text = "Action on checked items"
        '
        'btnSaveRunPro
        '
        Me.btnSaveRunPro.BackColor = System.Drawing.Color.Transparent
        Me.btnSaveRunPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSaveRunPro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveRunPro.ForeColor = System.Drawing.Color.Green
        Me.btnSaveRunPro.Location = New System.Drawing.Point(30, 31)
        Me.btnSaveRunPro.Name = "btnSaveRunPro"
        Me.btnSaveRunPro.Size = New System.Drawing.Size(120, 23)
        Me.btnSaveRunPro.TabIndex = 5
        Me.btnSaveRunPro.Text = "&Save to Hitlist"
        Me.btnSaveRunPro.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveRunPro.UseVisualStyleBackColor = False
        '
        'btnKillRunPro
        '
        Me.btnKillRunPro.BackColor = System.Drawing.Color.Transparent
        Me.btnKillRunPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnKillRunPro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKillRunPro.ForeColor = System.Drawing.Color.Red
        Me.btnKillRunPro.Location = New System.Drawing.Point(30, 61)
        Me.btnKillRunPro.Name = "btnKillRunPro"
        Me.btnKillRunPro.Size = New System.Drawing.Size(120, 23)
        Me.btnKillRunPro.TabIndex = 6
        Me.btnKillRunPro.Text = "&Kill Now!"
        Me.btnKillRunPro.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnKillRunPro.UseVisualStyleBackColor = False
        '
        'btnUncheckRunPro
        '
        Me.btnUncheckRunPro.BackColor = System.Drawing.Color.Transparent
        Me.btnUncheckRunPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnUncheckRunPro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUncheckRunPro.ForeColor = System.Drawing.Color.Black
        Me.btnUncheckRunPro.Location = New System.Drawing.Point(30, 91)
        Me.btnUncheckRunPro.Name = "btnUncheckRunPro"
        Me.btnUncheckRunPro.Size = New System.Drawing.Size(120, 23)
        Me.btnUncheckRunPro.TabIndex = 7
        Me.btnUncheckRunPro.Text = "&Uncheck"
        Me.btnUncheckRunPro.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUncheckRunPro.UseVisualStyleBackColor = False
        '
        'lblTotRunPro
        '
        Me.lblTotRunPro.AutoSize = True
        Me.lblTotRunPro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotRunPro.Location = New System.Drawing.Point(174, 22)
        Me.lblTotRunPro.Name = "lblTotRunPro"
        Me.lblTotRunPro.Size = New System.Drawing.Size(22, 13)
        Me.lblTotRunPro.TabIndex = 1
        Me.lblTotRunPro.Text = "---"
        '
        'btnRefreshRunPro
        '
        Me.btnRefreshRunPro.BackColor = System.Drawing.Color.Transparent
        Me.btnRefreshRunPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRefreshRunPro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshRunPro.ForeColor = System.Drawing.Color.Black
        Me.btnRefreshRunPro.Location = New System.Drawing.Point(241, 18)
        Me.btnRefreshRunPro.Name = "btnRefreshRunPro"
        Me.btnRefreshRunPro.Size = New System.Drawing.Size(59, 23)
        Me.btnRefreshRunPro.TabIndex = 2
        Me.btnRefreshRunPro.Text = "&Refresh"
        Me.btnRefreshRunPro.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefreshRunPro.UseVisualStyleBackColor = False
        '
        'chkLstRunPro
        '
        Me.chkLstRunPro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkLstRunPro.CheckOnClick = True
        Me.chkLstRunPro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLstRunPro.FormattingEnabled = True
        Me.chkLstRunPro.HorizontalScrollbar = True
        Me.chkLstRunPro.Location = New System.Drawing.Point(5, 47)
        Me.chkLstRunPro.Name = "chkLstRunPro"
        Me.chkLstRunPro.Size = New System.Drawing.Size(295, 324)
        Me.chkLstRunPro.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(172, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Current running processes : "
        '
        'tabPgManPro
        '
        Me.tabPgManPro.BackColor = System.Drawing.Color.Transparent
        Me.tabPgManPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabPgManPro.Controls.Add(Me.lblNameManProHitlist)
        Me.tabPgManPro.Controls.Add(Me.GroupBox2)
        Me.tabPgManPro.Controls.Add(Me.grpBox2)
        Me.tabPgManPro.Controls.Add(Me.Label5)
        Me.tabPgManPro.Controls.Add(Me.btnRefreshManPro)
        Me.tabPgManPro.Controls.Add(Me.chkLstManPro)
        Me.tabPgManPro.Location = New System.Drawing.Point(4, 22)
        Me.tabPgManPro.Name = "tabPgManPro"
        Me.tabPgManPro.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPgManPro.Size = New System.Drawing.Size(686, 373)
        Me.tabPgManPro.TabIndex = 2
        Me.tabPgManPro.Text = "Edit Hitlist"
        Me.tabPgManPro.UseVisualStyleBackColor = True
        '
        'lblNameManProHitlist
        '
        Me.lblNameManProHitlist.AutoSize = True
        Me.lblNameManProHitlist.BackColor = System.Drawing.Color.Transparent
        Me.lblNameManProHitlist.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameManProHitlist.Location = New System.Drawing.Point(53, 12)
        Me.lblNameManProHitlist.Name = "lblNameManProHitlist"
        Me.lblNameManProHitlist.Size = New System.Drawing.Size(31, 13)
        Me.lblNameManProHitlist.TabIndex = 1
        Me.lblNameManProHitlist.Text = "----"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnSaveManPro)
        Me.GroupBox2.Controls.Add(Me.txtNamesManPro)
        Me.GroupBox2.Location = New System.Drawing.Point(283, 34)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(395, 200)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Enter Process Names (comma seperated)"
        '
        'btnSaveManPro
        '
        Me.btnSaveManPro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveManPro.BackColor = System.Drawing.Color.Transparent
        Me.btnSaveManPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSaveManPro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveManPro.ForeColor = System.Drawing.Color.Green
        Me.btnSaveManPro.Location = New System.Drawing.Point(21, 165)
        Me.btnSaveManPro.Name = "btnSaveManPro"
        Me.btnSaveManPro.Size = New System.Drawing.Size(130, 24)
        Me.btnSaveManPro.TabIndex = 5
        Me.btnSaveManPro.Text = "&Save to Hitlist"
        Me.btnSaveManPro.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveManPro.UseVisualStyleBackColor = False
        '
        'txtNamesManPro
        '
        Me.txtNamesManPro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNamesManPro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamesManPro.Location = New System.Drawing.Point(6, 35)
        Me.txtNamesManPro.Multiline = True
        Me.txtNamesManPro.Name = "txtNamesManPro"
        Me.txtNamesManPro.Size = New System.Drawing.Size(383, 124)
        Me.txtNamesManPro.TabIndex = 4
        '
        'grpBox2
        '
        Me.grpBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpBox2.BackColor = System.Drawing.Color.Transparent
        Me.grpBox2.Controls.Add(Me.btnRemoveManPro)
        Me.grpBox2.Controls.Add(Me.btnUncheckManPro)
        Me.grpBox2.Controls.Add(Me.btnKillManPro)
        Me.grpBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBox2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpBox2.Location = New System.Drawing.Point(283, 240)
        Me.grpBox2.Name = "grpBox2"
        Me.grpBox2.Size = New System.Drawing.Size(178, 125)
        Me.grpBox2.TabIndex = 5
        Me.grpBox2.TabStop = False
        Me.grpBox2.Text = "Action on checked items"
        '
        'btnRemoveManPro
        '
        Me.btnRemoveManPro.BackColor = System.Drawing.Color.Transparent
        Me.btnRemoveManPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRemoveManPro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveManPro.ForeColor = System.Drawing.Color.Black
        Me.btnRemoveManPro.Location = New System.Drawing.Point(21, 31)
        Me.btnRemoveManPro.Name = "btnRemoveManPro"
        Me.btnRemoveManPro.Size = New System.Drawing.Size(130, 23)
        Me.btnRemoveManPro.TabIndex = 6
        Me.btnRemoveManPro.Text = "R&emove from Hitlist"
        Me.btnRemoveManPro.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRemoveManPro.UseVisualStyleBackColor = False
        '
        'btnUncheckManPro
        '
        Me.btnUncheckManPro.BackColor = System.Drawing.Color.Transparent
        Me.btnUncheckManPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnUncheckManPro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUncheckManPro.ForeColor = System.Drawing.Color.Black
        Me.btnUncheckManPro.Location = New System.Drawing.Point(21, 89)
        Me.btnUncheckManPro.Name = "btnUncheckManPro"
        Me.btnUncheckManPro.Size = New System.Drawing.Size(130, 23)
        Me.btnUncheckManPro.TabIndex = 8
        Me.btnUncheckManPro.Text = "&Uncheck"
        Me.btnUncheckManPro.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUncheckManPro.UseVisualStyleBackColor = False
        '
        'btnKillManPro
        '
        Me.btnKillManPro.BackColor = System.Drawing.Color.Transparent
        Me.btnKillManPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnKillManPro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKillManPro.ForeColor = System.Drawing.Color.Red
        Me.btnKillManPro.Location = New System.Drawing.Point(21, 60)
        Me.btnKillManPro.Name = "btnKillManPro"
        Me.btnKillManPro.Size = New System.Drawing.Size(130, 23)
        Me.btnKillManPro.TabIndex = 7
        Me.btnKillManPro.Text = "&Kill Now!"
        Me.btnKillManPro.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnKillManPro.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Name :"
        '
        'btnRefreshManPro
        '
        Me.btnRefreshManPro.BackColor = System.Drawing.Color.Transparent
        Me.btnRefreshManPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRefreshManPro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshManPro.ForeColor = System.Drawing.Color.Black
        Me.btnRefreshManPro.Location = New System.Drawing.Point(218, 7)
        Me.btnRefreshManPro.Name = "btnRefreshManPro"
        Me.btnRefreshManPro.Size = New System.Drawing.Size(59, 23)
        Me.btnRefreshManPro.TabIndex = 2
        Me.btnRefreshManPro.Text = "&Refresh"
        Me.btnRefreshManPro.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefreshManPro.UseVisualStyleBackColor = False
        '
        'chkLstManPro
        '
        Me.chkLstManPro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkLstManPro.CheckOnClick = True
        Me.chkLstManPro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLstManPro.FormattingEnabled = True
        Me.chkLstManPro.HorizontalScrollbar = True
        Me.chkLstManPro.Location = New System.Drawing.Point(5, 34)
        Me.chkLstManPro.Name = "chkLstManPro"
        Me.chkLstManPro.Size = New System.Drawing.Size(272, 324)
        Me.chkLstManPro.Sorted = True
        Me.chkLstManPro.TabIndex = 3
        '
        'tabPgOtherSettings
        '
        Me.tabPgOtherSettings.BackColor = System.Drawing.Color.Transparent
        Me.tabPgOtherSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabPgOtherSettings.Controls.Add(Me.grpBoxTimer)
        Me.tabPgOtherSettings.Controls.Add(Me.grpBoxClearLogs)
        Me.tabPgOtherSettings.Controls.Add(Me.grpBoxMisc)
        Me.tabPgOtherSettings.Controls.Add(Me.grpBox3)
        Me.tabPgOtherSettings.Controls.Add(Me.grpBoxAutoClearLogs)
        Me.tabPgOtherSettings.Location = New System.Drawing.Point(4, 22)
        Me.tabPgOtherSettings.Name = "tabPgOtherSettings"
        Me.tabPgOtherSettings.Size = New System.Drawing.Size(686, 373)
        Me.tabPgOtherSettings.TabIndex = 3
        Me.tabPgOtherSettings.Text = "Other Settings"
        Me.tabPgOtherSettings.UseVisualStyleBackColor = True
        '
        'grpBoxTimer
        '
        Me.grpBoxTimer.Controls.Add(Me.btnMinimizeToTray)
        Me.grpBoxTimer.Controls.Add(Me.txtTimeInMinutes)
        Me.grpBoxTimer.Controls.Add(Me.lblKillTimer)
        Me.grpBoxTimer.Controls.Add(Me.chkEnableTimer)
        Me.grpBoxTimer.Location = New System.Drawing.Point(8, 12)
        Me.grpBoxTimer.Name = "grpBoxTimer"
        Me.grpBoxTimer.Size = New System.Drawing.Size(231, 87)
        Me.grpBoxTimer.TabIndex = 1
        Me.grpBoxTimer.TabStop = False
        Me.grpBoxTimer.Text = "                                     "
        '
        'btnMinimizeToTray
        '
        Me.btnMinimizeToTray.Location = New System.Drawing.Point(9, 53)
        Me.btnMinimizeToTray.Name = "btnMinimizeToTray"
        Me.btnMinimizeToTray.Size = New System.Drawing.Size(187, 23)
        Me.btnMinimizeToTray.TabIndex = 2
        Me.btnMinimizeToTray.Text = "&Minimize to System Tray"
        Me.btnMinimizeToTray.UseVisualStyleBackColor = True
        '
        'txtTimeInMinutes
        '
        Me.txtTimeInMinutes.Location = New System.Drawing.Point(74, 26)
        Me.txtTimeInMinutes.MaxLength = 3
        Me.txtTimeInMinutes.Name = "txtTimeInMinutes"
        Me.txtTimeInMinutes.Size = New System.Drawing.Size(28, 21)
        Me.txtTimeInMinutes.TabIndex = 1
        Me.txtTimeInMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblKillTimer
        '
        Me.lblKillTimer.AutoSize = True
        Me.lblKillTimer.Location = New System.Drawing.Point(7, 29)
        Me.lblKillTimer.Name = "lblKillTimer"
        Me.lblKillTimer.Size = New System.Drawing.Size(158, 13)
        Me.lblKillTimer.TabIndex = 1
        Me.lblKillTimer.Text = "Kill Every           Minute(s)"
        '
        'chkEnableTimer
        '
        Me.chkEnableTimer.AutoSize = True
        Me.chkEnableTimer.BackColor = System.Drawing.Color.Transparent
        Me.chkEnableTimer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEnableTimer.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.chkEnableTimer.Location = New System.Drawing.Point(10, 0)
        Me.chkEnableTimer.Name = "chkEnableTimer"
        Me.chkEnableTimer.Size = New System.Drawing.Size(152, 17)
        Me.chkEnableTimer.TabIndex = 0
        Me.chkEnableTimer.Text = "Enable Auto Kill &Timer"
        Me.chkEnableTimer.UseVisualStyleBackColor = False
        '
        'grpBoxClearLogs
        '
        Me.grpBoxClearLogs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpBoxClearLogs.Controls.Add(Me.btnOpenFolder)
        Me.grpBoxClearLogs.Controls.Add(Me.lblAllLogSize)
        Me.grpBoxClearLogs.Controls.Add(Me.lblTermLogSize)
        Me.grpBoxClearLogs.Controls.Add(Me.lblErrLogSize)
        Me.grpBoxClearLogs.Controls.Add(Me.btnClearAllLog)
        Me.grpBoxClearLogs.Controls.Add(Me.btnClearTermLog)
        Me.grpBoxClearLogs.Controls.Add(Me.btnClearErrLog)
        Me.grpBoxClearLogs.Location = New System.Drawing.Point(8, 225)
        Me.grpBoxClearLogs.Name = "grpBoxClearLogs"
        Me.grpBoxClearLogs.Size = New System.Drawing.Size(231, 145)
        Me.grpBoxClearLogs.TabIndex = 4
        Me.grpBoxClearLogs.TabStop = False
        Me.grpBoxClearLogs.Text = "Clear Log Files"
        '
        'btnOpenFolder
        '
        Me.btnOpenFolder.BackColor = System.Drawing.Color.Transparent
        Me.btnOpenFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnOpenFolder.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenFolder.ForeColor = System.Drawing.Color.Black
        Me.btnOpenFolder.Location = New System.Drawing.Point(6, 114)
        Me.btnOpenFolder.Name = "btnOpenFolder"
        Me.btnOpenFolder.Size = New System.Drawing.Size(206, 23)
        Me.btnOpenFolder.TabIndex = 9
        Me.btnOpenFolder.Text = "&Open Hitlist Folder"
        Me.btnOpenFolder.UseVisualStyleBackColor = False
        '
        'lblAllLogSize
        '
        Me.lblAllLogSize.AutoSize = True
        Me.lblAllLogSize.Location = New System.Drawing.Point(150, 90)
        Me.lblAllLogSize.Name = "lblAllLogSize"
        Me.lblAllLogSize.Size = New System.Drawing.Size(49, 13)
        Me.lblAllLogSize.TabIndex = 5
        Me.lblAllLogSize.Text = "0 Bit(s)"
        '
        'lblTermLogSize
        '
        Me.lblTermLogSize.AutoSize = True
        Me.lblTermLogSize.Location = New System.Drawing.Point(150, 62)
        Me.lblTermLogSize.Name = "lblTermLogSize"
        Me.lblTermLogSize.Size = New System.Drawing.Size(49, 13)
        Me.lblTermLogSize.TabIndex = 3
        Me.lblTermLogSize.Text = "0 Bit(s)"
        '
        'lblErrLogSize
        '
        Me.lblErrLogSize.AutoSize = True
        Me.lblErrLogSize.Location = New System.Drawing.Point(150, 34)
        Me.lblErrLogSize.Name = "lblErrLogSize"
        Me.lblErrLogSize.Size = New System.Drawing.Size(49, 13)
        Me.lblErrLogSize.TabIndex = 1
        Me.lblErrLogSize.Text = "0 Bit(s)"
        '
        'btnClearAllLog
        '
        Me.btnClearAllLog.Location = New System.Drawing.Point(6, 85)
        Me.btnClearAllLog.Name = "btnClearAllLog"
        Me.btnClearAllLog.Size = New System.Drawing.Size(138, 23)
        Me.btnClearAllLog.TabIndex = 8
        Me.btnClearAllLog.Text = "&All Logs"
        Me.btnClearAllLog.UseVisualStyleBackColor = True
        '
        'btnClearTermLog
        '
        Me.btnClearTermLog.Location = New System.Drawing.Point(6, 57)
        Me.btnClearTermLog.Name = "btnClearTermLog"
        Me.btnClearTermLog.Size = New System.Drawing.Size(138, 23)
        Me.btnClearTermLog.TabIndex = 7
        Me.btnClearTermLog.Text = "Termination &Logs"
        Me.btnClearTermLog.UseVisualStyleBackColor = True
        '
        'btnClearErrLog
        '
        Me.btnClearErrLog.Location = New System.Drawing.Point(6, 29)
        Me.btnClearErrLog.Name = "btnClearErrLog"
        Me.btnClearErrLog.Size = New System.Drawing.Size(138, 23)
        Me.btnClearErrLog.TabIndex = 6
        Me.btnClearErrLog.Text = "&Error Log"
        Me.btnClearErrLog.UseVisualStyleBackColor = True
        '
        'grpBoxMisc
        '
        Me.grpBoxMisc.Controls.Add(Me.chkAddToStartup)
        Me.grpBoxMisc.Location = New System.Drawing.Point(8, 165)
        Me.grpBoxMisc.Name = "grpBoxMisc"
        Me.grpBoxMisc.Size = New System.Drawing.Size(231, 54)
        Me.grpBoxMisc.TabIndex = 3
        Me.grpBoxMisc.TabStop = False
        Me.grpBoxMisc.Text = "Miscellanious"
        '
        'chkAddToStartup
        '
        Me.chkAddToStartup.AutoSize = True
        Me.chkAddToStartup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAddToStartup.Location = New System.Drawing.Point(10, 24)
        Me.chkAddToStartup.Name = "chkAddToStartup"
        Me.chkAddToStartup.Size = New System.Drawing.Size(109, 17)
        Me.chkAddToStartup.TabIndex = 5
        Me.chkAddToStartup.Text = "Add to &Startup"
        Me.chkAddToStartup.UseVisualStyleBackColor = True
        '
        'grpBox3
        '
        Me.grpBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpBox3.Controls.Add(Me.btnKillOtherSettings)
        Me.grpBox3.Controls.Add(Me.btnUpdate)
        Me.grpBox3.Controls.Add(Me.chkChooseOnExeution)
        Me.grpBox3.Controls.Add(Me.chkLstExecOrder)
        Me.grpBox3.Location = New System.Drawing.Point(245, 12)
        Me.grpBox3.Name = "grpBox3"
        Me.grpBox3.Size = New System.Drawing.Size(433, 358)
        Me.grpBox3.TabIndex = 5
        Me.grpBox3.TabStop = False
        Me.grpBox3.Text = "Hitlist(s) to use upon execution"
        '
        'btnKillOtherSettings
        '
        Me.btnKillOtherSettings.BackColor = System.Drawing.Color.Transparent
        Me.btnKillOtherSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnKillOtherSettings.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKillOtherSettings.ForeColor = System.Drawing.Color.Red
        Me.btnKillOtherSettings.Location = New System.Drawing.Point(276, 22)
        Me.btnKillOtherSettings.Name = "btnKillOtherSettings"
        Me.btnKillOtherSettings.Size = New System.Drawing.Size(146, 27)
        Me.btnKillOtherSettings.TabIndex = 13
        Me.btnKillOtherSettings.Text = "&Kill Now!"
        Me.btnKillOtherSettings.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Transparent
        Me.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.Green
        Me.btnUpdate.Location = New System.Drawing.Point(187, 22)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(83, 27)
        Me.btnUpdate.TabIndex = 12
        Me.btnUpdate.Text = "&UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'chkChooseOnExeution
        '
        Me.chkChooseOnExeution.AutoSize = True
        Me.chkChooseOnExeution.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkChooseOnExeution.Location = New System.Drawing.Point(13, 28)
        Me.chkChooseOnExeution.Name = "chkChooseOnExeution"
        Me.chkChooseOnExeution.Size = New System.Drawing.Size(168, 17)
        Me.chkChooseOnExeution.TabIndex = 10
        Me.chkChooseOnExeution.Text = "C&hoose during execution"
        Me.chkChooseOnExeution.UseVisualStyleBackColor = True
        '
        'chkLstExecOrder
        '
        Me.chkLstExecOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkLstExecOrder.CheckOnClick = True
        Me.chkLstExecOrder.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLstExecOrder.FormattingEnabled = True
        Me.chkLstExecOrder.HorizontalScrollbar = True
        Me.chkLstExecOrder.Location = New System.Drawing.Point(13, 55)
        Me.chkLstExecOrder.Name = "chkLstExecOrder"
        Me.chkLstExecOrder.Size = New System.Drawing.Size(409, 292)
        Me.chkLstExecOrder.Sorted = True
        Me.chkLstExecOrder.TabIndex = 11
        '
        'grpBoxAutoClearLogs
        '
        Me.grpBoxAutoClearLogs.Controls.Add(Me.txtAutoClearDays)
        Me.grpBoxAutoClearLogs.Controls.Add(Me.lblAutoClearDays)
        Me.grpBoxAutoClearLogs.Controls.Add(Me.chkAutoClearLogs)
        Me.grpBoxAutoClearLogs.Location = New System.Drawing.Point(8, 105)
        Me.grpBoxAutoClearLogs.Name = "grpBoxAutoClearLogs"
        Me.grpBoxAutoClearLogs.Size = New System.Drawing.Size(231, 54)
        Me.grpBoxAutoClearLogs.TabIndex = 2
        Me.grpBoxAutoClearLogs.TabStop = False
        Me.grpBoxAutoClearLogs.Text = "                                            "
        '
        'txtAutoClearDays
        '
        Me.txtAutoClearDays.Location = New System.Drawing.Point(74, 26)
        Me.txtAutoClearDays.MaxLength = 3
        Me.txtAutoClearDays.Name = "txtAutoClearDays"
        Me.txtAutoClearDays.Size = New System.Drawing.Size(28, 21)
        Me.txtAutoClearDays.TabIndex = 4
        Me.txtAutoClearDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblAutoClearDays
        '
        Me.lblAutoClearDays.AutoSize = True
        Me.lblAutoClearDays.Location = New System.Drawing.Point(7, 29)
        Me.lblAutoClearDays.Name = "lblAutoClearDays"
        Me.lblAutoClearDays.Size = New System.Drawing.Size(142, 13)
        Me.lblAutoClearDays.TabIndex = 1
        Me.lblAutoClearDays.Text = "Older than         Day(s)"
        '
        'chkAutoClearLogs
        '
        Me.chkAutoClearLogs.AutoSize = True
        Me.chkAutoClearLogs.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoClearLogs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoClearLogs.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.chkAutoClearLogs.Location = New System.Drawing.Point(9, -1)
        Me.chkAutoClearLogs.Name = "chkAutoClearLogs"
        Me.chkAutoClearLogs.Size = New System.Drawing.Size(188, 17)
        Me.chkAutoClearLogs.TabIndex = 3
        Me.chkAutoClearLogs.Text = "Auto &Clear Termination Logs"
        Me.chkAutoClearLogs.UseVisualStyleBackColor = False
        '
        'tabPgAbout
        '
        Me.tabPgAbout.Controls.Add(Me.lblLicense)
        Me.tabPgAbout.Controls.Add(Me.lnkLicense)
        Me.tabPgAbout.Controls.Add(Me.lblUserGuide)
        Me.tabPgAbout.Controls.Add(Me.lnkUserGuide)
        Me.tabPgAbout.Controls.Add(Me.richtextboxAbout)
        Me.tabPgAbout.Controls.Add(Me.lblVersion)
        Me.tabPgAbout.Controls.Add(Me.PictureBox1)
        Me.tabPgAbout.Controls.Add(Me.lblWebsite)
        Me.tabPgAbout.Controls.Add(Me.lnkWebsite)
        Me.tabPgAbout.Controls.Add(Me.Label7)
        Me.tabPgAbout.Controls.Add(Me.lblContact)
        Me.tabPgAbout.Controls.Add(Me.lnkContact)
        Me.tabPgAbout.Controls.Add(Me.Label12)
        Me.tabPgAbout.Controls.Add(Me.Label2)
        Me.tabPgAbout.Controls.Add(Me.Label1)
        Me.tabPgAbout.Controls.Add(Me.Label4)
        Me.tabPgAbout.Location = New System.Drawing.Point(4, 22)
        Me.tabPgAbout.Name = "tabPgAbout"
        Me.tabPgAbout.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPgAbout.Size = New System.Drawing.Size(686, 373)
        Me.tabPgAbout.TabIndex = 4
        Me.tabPgAbout.Text = "About"
        Me.tabPgAbout.UseVisualStyleBackColor = True
        '
        'lblLicense
        '
        Me.lblLicense.AutoSize = True
        Me.lblLicense.Location = New System.Drawing.Point(9, 124)
        Me.lblLicense.Name = "lblLicense"
        Me.lblLicense.Size = New System.Drawing.Size(62, 13)
        Me.lblLicense.TabIndex = 13
        Me.lblLicense.Text = "&License : "
        '
        'lnkLicense
        '
        Me.lnkLicense.AutoSize = True
        Me.lnkLicense.Location = New System.Drawing.Point(67, 124)
        Me.lnkLicense.Name = "lnkLicense"
        Me.lnkLicense.Size = New System.Drawing.Size(251, 13)
        Me.lnkLicense.TabIndex = 12
        Me.lnkLicense.TabStop = True
        Me.lnkLicense.Text = "&Licensed under the terms of GNU GPL v3.0"
        '
        'lblUserGuide
        '
        Me.lblUserGuide.AutoSize = True
        Me.lblUserGuide.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserGuide.Location = New System.Drawing.Point(347, 78)
        Me.lblUserGuide.Name = "lblUserGuide"
        Me.lblUserGuide.Size = New System.Drawing.Size(79, 13)
        Me.lblUserGuide.TabIndex = 7
        Me.lblUserGuide.Text = "&User Guide :"
        '
        'lnkUserGuide
        '
        Me.lnkUserGuide.AutoSize = True
        Me.lnkUserGuide.Location = New System.Drawing.Point(425, 78)
        Me.lnkUserGuide.Name = "lnkUserGuide"
        Me.lnkUserGuide.Size = New System.Drawing.Size(123, 13)
        Me.lnkUserGuide.TabIndex = 1
        Me.lnkUserGuide.TabStop = True
        Me.lnkUserGuide.Text = "Open the user guide"
        '
        'richtextboxAbout
        '
        Me.richtextboxAbout.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.richtextboxAbout.Location = New System.Drawing.Point(12, 157)
        Me.richtextboxAbout.Name = "richtextboxAbout"
        Me.richtextboxAbout.ReadOnly = True
        Me.richtextboxAbout.Size = New System.Drawing.Size(666, 208)
        Me.richtextboxAbout.TabIndex = 4
        Me.richtextboxAbout.Text = ""
        Me.richtextboxAbout.WordWrap = False
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(123, 41)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(23, 15)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "----"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Auto_Kill_Any_Process.My.Resources.Resources.AKAP_About_Image_Small
        Me.PictureBox1.Location = New System.Drawing.Point(12, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'lblWebsite
        '
        Me.lblWebsite.AutoSize = True
        Me.lblWebsite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebsite.Location = New System.Drawing.Point(365, 124)
        Me.lblWebsite.Name = "lblWebsite"
        Me.lblWebsite.Size = New System.Drawing.Size(60, 13)
        Me.lblWebsite.TabIndex = 11
        Me.lblWebsite.Text = "&Website :"
        '
        'lnkWebsite
        '
        Me.lnkWebsite.AutoSize = True
        Me.lnkWebsite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkWebsite.Location = New System.Drawing.Point(425, 124)
        Me.lnkWebsite.Name = "lnkWebsite"
        Me.lnkWebsite.Size = New System.Drawing.Size(154, 13)
        Me.lnkWebsite.TabIndex = 3
        Me.lnkWebsite.TabStop = True
        Me.lnkWebsite.Text = "http://akmasolutions.com"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(67, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Mansoor Ahamed"
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContact.Location = New System.Drawing.Point(366, 101)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(60, 13)
        Me.lblContact.TabIndex = 9
        Me.lblContact.Text = "C&ontact :"
        '
        'lnkContact
        '
        Me.lnkContact.AutoSize = True
        Me.lnkContact.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkContact.Location = New System.Drawing.Point(425, 101)
        Me.lnkContact.Name = "lnkContact"
        Me.lnkContact.Size = New System.Drawing.Size(162, 13)
        Me.lnkContact.TabIndex = 2
        Me.lnkContact.TabStop = True
        Me.lnkContact.Text = "akma.mansoor@gmail.com"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(151, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Copyright (C) 2009-2015"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(239, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Auto Kill Any Process"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Version :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Author - "
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'Timer1
        '
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 397)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(694, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusLabel1
        '
        Me.statusLabel1.Name = "statusLabel1"
        Me.statusLabel1.Size = New System.Drawing.Size(125, 17)
        Me.statusLabel1.Text = "Welcome A.K.A.P User"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Auto Kill Any Process"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(694, 419)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(710, 458)
        Me.Name = "frmSettings"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auto Kill Any Process"
        Me.TabControl1.ResumeLayout(False)
        Me.tabPgHitList.ResumeLayout(False)
        Me.tabPgHitList.PerformLayout()
        Me.pnlHitlistActions.ResumeLayout(False)
        Me.pnlHitlistActions.PerformLayout()
        Me.tabPgRunPro.ResumeLayout(False)
        Me.tabPgRunPro.PerformLayout()
        Me.grpBox1.ResumeLayout(False)
        Me.tabPgManPro.ResumeLayout(False)
        Me.tabPgManPro.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpBox2.ResumeLayout(False)
        Me.tabPgOtherSettings.ResumeLayout(False)
        Me.grpBoxTimer.ResumeLayout(False)
        Me.grpBoxTimer.PerformLayout()
        Me.grpBoxClearLogs.ResumeLayout(False)
        Me.grpBoxClearLogs.PerformLayout()
        Me.grpBoxMisc.ResumeLayout(False)
        Me.grpBoxMisc.PerformLayout()
        Me.grpBox3.ResumeLayout(False)
        Me.grpBox3.PerformLayout()
        Me.grpBoxAutoClearLogs.ResumeLayout(False)
        Me.grpBoxAutoClearLogs.PerformLayout()
        Me.tabPgAbout.ResumeLayout(False)
        Me.tabPgAbout.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabPgHitList As System.Windows.Forms.TabPage
    Friend WithEvents tabPgRunPro As System.Windows.Forms.TabPage
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnKillHitlist As System.Windows.Forms.Button
    Friend WithEvents btnSaveRunPro As System.Windows.Forms.Button
    Friend WithEvents lstHitListProcs As System.Windows.Forms.ListBox
    Friend WithEvents chkLstRunPro As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnUncheckRunPro As System.Windows.Forms.Button
    Friend WithEvents btnRefreshRunPro As System.Windows.Forms.Button
    Friend WithEvents lblTotRunPro As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents btnRefreshHitList As System.Windows.Forms.Button
    Friend WithEvents tabPgManPro As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNamesManPro As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveManPro As System.Windows.Forms.Button
    Friend WithEvents chkLstManPro As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnKillRunPro As System.Windows.Forms.Button
    Friend WithEvents btnOpenHitlist As System.Windows.Forms.Button
    Friend WithEvents btnNewHitlist As System.Windows.Forms.Button
    Friend WithEvents btnSaveHitList As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNameHitList As System.Windows.Forms.Label
    Friend WithEvents txtNameHitList As System.Windows.Forms.TextBox
    Friend WithEvents btnRenameHitList As System.Windows.Forms.Button
    Friend WithEvents tabPgOtherSettings As System.Windows.Forms.TabPage
    Friend WithEvents grpBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkLstExecOrder As System.Windows.Forms.CheckedListBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents grpBoxMisc As System.Windows.Forms.GroupBox
    Friend WithEvents chkAddToStartup As System.Windows.Forms.CheckBox
    Friend WithEvents grpBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelHitList As System.Windows.Forms.Button
    Friend WithEvents btnOKHitList As System.Windows.Forms.Button
    Friend WithEvents btnUncheckManPro As System.Windows.Forms.Button
    Friend WithEvents btnRefreshManPro As System.Windows.Forms.Button
    Friend WithEvents grpBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemoveManPro As System.Windows.Forms.Button
    Friend WithEvents btnKillManPro As System.Windows.Forms.Button
    Friend WithEvents chkChooseOnExeution As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelHilist As System.Windows.Forms.Button
    Friend WithEvents lblNameManProHitlist As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnKillOtherSettings As System.Windows.Forms.Button
    Friend WithEvents tabPgAbout As System.Windows.Forms.TabPage
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblWebsite As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lnkWebsite As System.Windows.Forms.LinkLabel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents lnkContact As System.Windows.Forms.LinkLabel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents richtextboxAbout As System.Windows.Forms.RichTextBox
    Friend WithEvents txtRunProDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grpBoxClearLogs As System.Windows.Forms.GroupBox
    Friend WithEvents btnClearErrLog As System.Windows.Forms.Button
    Friend WithEvents lblAllLogSize As System.Windows.Forms.Label
    Friend WithEvents lblTermLogSize As System.Windows.Forms.Label
    Friend WithEvents lblErrLogSize As System.Windows.Forms.Label
    Friend WithEvents btnClearAllLog As System.Windows.Forms.Button
    Friend WithEvents btnClearTermLog As System.Windows.Forms.Button
    Friend WithEvents grpBoxAutoClearLogs As System.Windows.Forms.GroupBox
    Friend WithEvents chkAutoClearLogs As System.Windows.Forms.CheckBox
    Friend WithEvents txtAutoClearDays As System.Windows.Forms.TextBox
    Friend WithEvents lblAutoClearDays As System.Windows.Forms.Label
    Friend WithEvents lnkUserGuide As System.Windows.Forms.LinkLabel
    Friend WithEvents lblUserGuide As System.Windows.Forms.Label
    Friend WithEvents pnlHitlistActions As System.Windows.Forms.Panel
    Friend WithEvents grpBoxTimer As System.Windows.Forms.GroupBox
    Friend WithEvents txtTimeInMinutes As System.Windows.Forms.TextBox
    Friend WithEvents lblKillTimer As System.Windows.Forms.Label
    Friend WithEvents chkEnableTimer As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents btnOpenFolder As System.Windows.Forms.Button
    Friend WithEvents btnMinimizeToTray As System.Windows.Forms.Button
    Friend WithEvents lnkLicense As System.Windows.Forms.LinkLabel
    Friend WithEvents lblLicense As System.Windows.Forms.Label
End Class
