
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

Public Class modFileOperations

#Region "Methods"

    Public Function ReadTextFromFile(ByVal FilePath As String) As String
        Dim fileContents As String = ""
        Dim objStreamReader As StreamReader
        Try
            objStreamReader = New StreamReader(FilePath)
            fileContents = objStreamReader.ReadToEnd()
            objStreamReader.Close()
            Return fileContents
        Catch Ex As Exception
            MsgBox(Ex.Message, MsgBoxStyle.Critical)
            Call writeErrorLog(Ex.Message, Ex.StackTrace)
            Return fileContents
        End Try
    End Function

    Public Function SaveTextToFile(ByVal textToBeSaved As String, ByVal filePath As String) As Boolean
        Dim blnHasSaveSucceeded As Boolean = False
        Dim objStreamWriter As StreamWriter
        Try
            If File.Exists(filePath) = False Then File.Create(filePath).Close()
            objStreamWriter = New StreamWriter(filePath)
            objStreamWriter.Write(textToBeSaved)
            objStreamWriter.Close()
            blnHasSaveSucceeded = True
        Catch Ex As Exception
            MsgBox(Ex.Message, MsgBoxStyle.Critical)
            Call writeErrorLog(Ex.Message, Ex.StackTrace)
        End Try
        Return blnHasSaveSucceeded
    End Function

    ''' <summary>
    ''' Writes the given message to the specified log file,
    ''' if the file already exists then the message is appended to a new line.
    ''' </summary>
    ''' <param name="strInfoMsg">The message to be logged</param>
    Public Sub WriteInfoLog(ByVal strInfoMsg As String)
        Dim objStreamWriter As StreamWriter
        Dim strInfoLogFilePath As String
        strInfoLogFilePath = strDirPath & "Logs\" & Format(Now, "dd") & Format(Now, "MMM") & Now.Year & " " & "Termination Log.log"
        Try
            If Not Directory.Exists(Path.GetDirectoryName(strInfoLogFilePath)) Then
                Directory.CreateDirectory(Path.GetDirectoryName(strInfoLogFilePath))
            End If
            If File.Exists(strInfoLogFilePath) = True Then 'Append text to new line
                objStreamWriter = New StreamWriter(strInfoLogFilePath, True)
            Else 'Create new message log file
                File.Create(strInfoLogFilePath).Close()
                objStreamWriter = New StreamWriter(strInfoLogFilePath, True)
            End If
            objStreamWriter.WriteLine(strInfoMsg)
            objStreamWriter.Close()
        Catch Ex As Exception
            MsgBox(Ex.Message, MsgBoxStyle.Critical)
            Call writeErrorLog(Ex.Message, Ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' Writes the error/exception message to the specified log file,
    ''' if the file already exists then the message is appended to a new line.
    ''' </summary>
    ''' <param name="strErrMsg">The error message to be logged</param>
    ''' <param name="strStkTrace">The origin of the error obtained from the stack trace</param>
    Public Sub writeErrorLog(ByVal strErrMsg As String, ByVal strStkTrace As String)
        Dim strErrLogFilePath As String = strDirPath & "Logs\Error log.log"
        Dim objStreamWriter As StreamWriter
        Try
            If Not Directory.Exists(Path.GetDirectoryName(strErrLogFilePath)) Then
                Directory.CreateDirectory(Path.GetDirectoryName(strErrLogFilePath))
            End If
            If File.Exists(strErrLogFilePath) = True Then 'Append error message to new line
                objStreamWriter = New StreamWriter(strErrLogFilePath, True)
            Else 'Create new error log file
                File.Create(strErrLogFilePath).Close()
                objStreamWriter = New StreamWriter(strErrLogFilePath)
                objStreamWriter.WriteLine("Auto Kill Any Process - Version: " & _
                Auto_Kill_Any_Process.My.Application.Info.Version.Major.ToString & "." & _
                Auto_Kill_Any_Process.My.Application.Info.Version.Minor.ToString)
            End If
            objStreamWriter.WriteLine("=========================================================")
            objStreamWriter.Write("Date: " & Format(Now, "dd-MMM-yyyy") & vbTab)
            objStreamWriter.WriteLine("Time: " & Format(Now, "hh:mm:ss tt"))
            objStreamWriter.Write("Error Message: ")
            objStreamWriter.WriteLine(strErrMsg)
            objStreamWriter.Write("Stack Trace: ")
            objStreamWriter.WriteLine(strStkTrace)
            objStreamWriter.WriteLine("=========================================================")
            objStreamWriter.WriteLine()
            objStreamWriter.Close()
        Catch Ex As Exception
            MsgBox(Ex.Message, MsgBoxStyle.Critical)
            Call writeErrorLog(Ex.Message, Ex.StackTrace)
        End Try
    End Sub

#End Region

End Class

#End Region