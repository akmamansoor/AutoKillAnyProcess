
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

Imports System.IO

Public Class frmHitlistChooser

#Region "Variable Declarations"

    Dim objFileOp As New modFileOperations

#End Region

#Region "Events"

    Private Sub frmHitlistChooser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.icoAutoKillAnyProcess
        chkLstExecOrder.Items.Clear()
        If Not arrHitlistFiles.Length = 0 Then chkLstExecOrder.Items.AddRange(arrHitlistFiles)
        chkBoxDontAsk.Enabled = False
        btnKill.Enabled = False
    End Sub

    Private Sub chkLstExecOrder_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstExecOrder.DoubleClick
        Call btnOKEnableDisable()
    End Sub

    Private Sub chkLstExecOrder_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkLstExecOrder.ItemCheck
        Call btnOKEnableDisable()
    End Sub

    Private Sub chkLstExecOrder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkLstExecOrder.KeyPress
        Call btnOKEnableDisable()
    End Sub

    Private Sub chkLstExecOrder_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstExecOrder.SelectedValueChanged
        Call btnOKEnableDisable()
    End Sub

    Private Sub chkLstExecOrder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLstExecOrder.SelectedIndexChanged
        Call btnOKEnableDisable()
    End Sub

    Private Sub chkLstExecOrder_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLstExecOrder.GotFocus
        If chkLstExecOrder.Items.Count > 0 Then chkLstExecOrder.SetSelected(0, True)
    End Sub

    Private Sub chkBoxDontAsk_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBoxDontAsk.EnabledChanged
        If chkBoxDontAsk.Enabled = False Then chkBoxDontAsk.Checked = False
    End Sub

    Private Sub chkBoxDontAsk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxDontAsk.CheckedChanged
        If chkBoxDontAsk.Checked = True Then
            chkLstExecOrder.Enabled = False
        Else
            chkLstExecOrder.Enabled = True
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnKill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKill.Click
        Try
            Dim strExecOrder As String = ""
            Dim blnSaveContents As Boolean = False

            'generate arrExecuteOrder()
            If chkLstExecOrder.CheckedItems.Count = 0 Then
                MsgBox("Please choose a Hitlist to terminate", MsgBoxStyle.Exclamation)
                Exit Sub
            Else
                ReDim arrExecuteOrder(chkLstExecOrder.CheckedItems.Count - 1)
                chkLstExecOrder.CheckedItems.CopyTo(arrExecuteOrder, 0)
            End If

            If chkBoxDontAsk.Checked = True And chkBoxDontAsk.Enabled = True Then blnSaveContents = True
            If blnSaveContents = True Then 'save the values, else save empty string
                strExecOrder = String.Join(",", arrExecuteOrder)
            End If
            If objFileOp.SaveTextToFile(strExecOrder, strExecuteOrderIniPath) = True Then
                Me.Close()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

#End Region

#Region "Methods"

    Private Sub btnOKEnableDisable()
        If chkLstExecOrder.CheckedItems.Count = 0 Then
            chkBoxDontAsk.Enabled = False
            btnKill.Enabled = False
        Else
            chkBoxDontAsk.Enabled = True
            btnKill.Enabled = True
        End If
    End Sub

#End Region

End Class

#End Region