
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
Imports System.Management
Imports System.io

Public Class modKiller

#Region "Variable Declarations"

    Dim objFileOp As New modFileOperations
    ''' <summary>Instance Array - number of instances of the processes with same name</summary>
    Dim InstanceArrayOfMyProcess As Process()

#End Region

#Region "Methods"

    ''' <summary>Kills all the process specified in the chosen Hitlist</summary>
    ''' <param name="strProcsListFromFile">The list of processes to terminate specified in the chosen hitlist</param>
    Public Sub killThemAll(ByVal strProcsListFromFile As String)
        Dim index As Integer
        Dim arrProcsWithExtension(-1) As String
        Dim arrProcsWithoutExtension(-1) As String

        If Trim(strProcsListFromFile).Length > 0 Then
            arrProcsWithExtension = strProcsListFromFile.Split(CChar(","))
            ReDim arrProcsWithoutExtension(arrProcsWithExtension.Length - 1)
            index = 0
            For Each procName As String In arrProcsWithExtension
                If procName.Contains(".") Then
                    procName = procName.Substring(0, procName.LastIndexOf("."))
                End If
                If Not procName = "" Then
                    arrProcsWithoutExtension(index) = procName
                    index += 1
                End If
            Next
        Else
            Exit Sub
        End If

        'Get all the instances of a process in an array and kill them, repeat for each process.
        For index = 0 To arrProcsWithoutExtension.Length - 1
            InstanceArrayOfMyProcess = System.Diagnostics.Process.GetProcessesByName(arrProcsWithoutExtension(index))
            If InstanceArrayOfMyProcess.Length > 0 Then
                killEachInstanceOfMyProcess()
            Else
                objFileOp.WriteInfoLog("**" & Format(Now, "hh:mm:ss tt") & "** " & "Process - " & arrProcsWithoutExtension(index) & " - " & "Process was not active!")
            End If
        Next
    End Sub

    Private Sub killEachInstanceOfMyProcess()
        Dim myProcessInstance As New Process
        Dim index As Integer
        For index = 0 To InstanceArrayOfMyProcess.Length - 1
            myProcessInstance = InstanceArrayOfMyProcess(index)
            'check if the process instance belongs to the current user. Terminate the instance only when TRUE.
            Dim strUserName As String = ""
            Try
                Dim args(1) As Object
                Dim mosProCurrProc As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ProcessId = " & myProcessInstance.Id)
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
            If strUserName = System.Environment.UserName _
                Or strUserName = "LOCAL SERVICE" _
                Or strUserName = "NETWORK SERVICE" _
                Or strUserName = "SYSTEM" Then
                Call kill(myProcessInstance)
            Else
                objFileOp.WriteInfoLog("**" & Format(Now, "hh:mm:ss tt") & "** " & "Process\ID - " & myProcessInstance.ProcessName & "\" & myProcessInstance.Id & " - " & "was not terminated, process belongs to a different user.")
            End If
        Next
    End Sub

    ''' <summary>Used for terminating selected running processes</summary> 
    ''' <param name="strProcsIDList">List of running processes to terminate</param> 
    Public Sub killProcessByID(ByVal strProcsIDList As String)
        Dim myProcessInstance As New Process
        Try
            For Each procID As Integer In strProcsIDList.Split(CChar(","))
                myProcessInstance = Process.GetProcessById(procID)
                'check if the process instance belongs to the current user. Terminate the instance only when TRUE.
                Dim strProcUserName As String = ""
                Try
                    Dim args(1) As Object
                    Dim mosProCurrProc As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ProcessId = " & myProcessInstance.Id)
                    'args(0) is user name
                    'args(1) is Domain
                    For Each moProCurrProc As ManagementObject In mosProCurrProc.Get
                        If CInt(moProCurrProc.InvokeMethod("GetOwner", args)) = 0 Then
                            strProcUserName = args(0).ToString
                        End If
                    Next
                Catch ex As Exception
                    objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
                End Try
                If strProcUserName = System.Environment.UserName _
                Or strProcUserName = "LOCAL SERVICE" _
                Or strProcUserName = "NETWORK SERVICE" _
                Or strProcUserName = "SYSTEM" Then
                    Call kill(myProcessInstance)
                ElseIf MsgBox(myProcessInstance.ProcessName & "(" & myProcessInstance.Id & ")" & " - belongs to the user: " & strProcUserName & vbNewLine & _
              "Are you sure you want to terminate it?", _
              CType((vbYesNo + vbQuestion), MsgBoxStyle)) = MsgBoxResult.Yes Then
                    Call kill(myProcessInstance)
                Else
                    objFileOp.WriteInfoLog("**" & Format(Now, "hh:mm:ss tt") & "** " & "Process\ID - " & myProcessInstance.ProcessName & "\" & myProcessInstance.Id & " - " & "was not terminated, process belongs to a different user, aborted by current user.")
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            objFileOp.writeErrorLog(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub kill(ByVal myProcessInstance As Process)
        Try
            Try
                System.Diagnostics.Process.EnterDebugMode()
            Catch ex As Exception
                objFileOp.writeErrorLog("Warning: You may not have the neccessary privileges to successfully run this application" & vbNewLine & _
                "Please check your group policy settings - Enter Debug Mode" & vbNewLine & ex.Message, "kill() - line 191")
            End Try
            Dim proName As String = myProcessInstance.ProcessName
            If myProcessInstance.HasExited = False Then
                myProcessInstance.Kill()
                While myProcessInstance.HasExited = False
                    Continue While
                End While
                objFileOp.WriteInfoLog("**" & Format(Now, "hh:mm:ss tt") & "** " & "Process\ID - " & proName & "\" & myProcessInstance.Id & " - " & "was successfully terminated!")
            Else
                objFileOp.WriteInfoLog("**" & Format(Now, "hh:mm:ss tt") & "** " & "Process\ID - " & proName & "\" & myProcessInstance.Id & " - " & "has already exited!")
            End If
            Try
                System.Diagnostics.Process.LeaveDebugMode()
            Catch ex As Exception
                'objFileOp.writeErrorLog(ex.Message, "kill() - line 206")
            End Try
        Catch ex As Exception
            'MsgBox("Process Name: " & myProcessInstance.ProcessName & vbNewLine & ex.Message & vbNewLine & vbNewLine & "Click OK to continue.", MsgBoxStyle.Information)
            objFileOp.WriteInfoLog("**" & Format(Now, "hh:mm:ss tt") & "** " & "Process - " & myProcessInstance.ProcessName & " - " & "encountered an error during termination!")
            objFileOp.writeErrorLog("Process\ID - " & myProcessInstance.ProcessName & "\" & myProcessInstance.Id & " - " & ex.Message, ex.StackTrace)
        End Try
        myProcessInstance = Nothing
    End Sub

#End Region

End Class

#End Region