<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHitlistChooser
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
        Me.chkBoxDontAsk = New System.Windows.Forms.CheckBox
        Me.chkLstExecOrder = New System.Windows.Forms.CheckedListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnKill = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'chkBoxDontAsk
        '
        Me.chkBoxDontAsk.AutoSize = True
        Me.chkBoxDontAsk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBoxDontAsk.Location = New System.Drawing.Point(9, 155)
        Me.chkBoxDontAsk.Name = "chkBoxDontAsk"
        Me.chkBoxDontAsk.Size = New System.Drawing.Size(115, 17)
        Me.chkBoxDontAsk.TabIndex = 2
        Me.chkBoxDontAsk.Text = "Don't ask again"
        Me.chkBoxDontAsk.UseVisualStyleBackColor = True
        '
        'chkLstExecOrder
        '
        Me.chkLstExecOrder.CheckOnClick = True
        Me.chkLstExecOrder.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLstExecOrder.FormattingEnabled = True
        Me.chkLstExecOrder.HorizontalScrollbar = True
        Me.chkLstExecOrder.Location = New System.Drawing.Point(9, 28)
        Me.chkLstExecOrder.Name = "chkLstExecOrder"
        Me.chkLstExecOrder.Size = New System.Drawing.Size(200, 116)
        Me.chkLstExecOrder.Sorted = True
        Me.chkLstExecOrder.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 175)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "(can be changed later)"
        '
        'btnKill
        '
        Me.btnKill.Location = New System.Drawing.Point(9, 200)
        Me.btnKill.Name = "btnKill"
        Me.btnKill.Size = New System.Drawing.Size(75, 23)
        Me.btnKill.TabIndex = 4
        Me.btnKill.Text = "&Kill"
        Me.btnKill.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(102, 200)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "&Close"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Choose Hitlists to terminate:"
        '
        'frmHitlistChooser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(221, 237)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnKill)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkBoxDontAsk)
        Me.Controls.Add(Me.chkLstExecOrder)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHitlistChooser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Auto Kill Any Process"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkBoxDontAsk As System.Windows.Forms.CheckBox
    Friend WithEvents chkLstExecOrder As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnKill As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
