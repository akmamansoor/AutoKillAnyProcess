
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

Module ModCommonOperations

#Region "Variable Declarations"

    ''' <summary>The default Application Data folder path: App Data folder + "\Auto Kill Any Process\"</summary>
    Public strDirPath As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) & "\Auto Kill Any Process\"
    ''' <summary>The default hitlist path with file name: strDirPath + "_default.hitlist"</summary>
    Public strDefaultHitListPath As String = strDirPath & "_default.hitlist"
    ''' <summary>The execution order file's path: strDirPath + "executeorder.ini"</summary>
    Public strExecuteOrderIniPath As String = strDirPath & "executeorder.ini"
    '''<summary>Array of ALL hitlist files in App Data folder</summary>
    Public arrHitlistFiles(-1) As String
    ''' <summary>Array of hitlist files to use for termination</summary>
    Public arrExecuteOrder(-1) As String
    ''' <summary>Number of hitlist files available in arrHitlistFiles (i.e) default Application folder</summary>
    Public intHitlistCount As Integer
    ''' <summary>Array of process names in current hitlist</summary>
    Public arrProcsToTerminate(-1) As String
    ''' <summary>String of process names in current hitlist, seperated by comma</summary>
    Public strProcsToTerminate As String

    Dim objfileop As New modFileOperations

#End Region

#Region "Methods"

    Public Sub updateArrHitlistFiles()
        arrHitlistFiles = Directory.GetFiles(strDirPath, "*.hitlist", SearchOption.TopDirectoryOnly)
        For i As Integer = 0 To arrHitlistFiles.Length - 1
            arrHitlistFiles(i) = Path.GetFileName(arrHitlistFiles(i))
        Next
        Array.Sort(arrHitlistFiles)
        intHitlistCount = arrHitlistFiles.Length
    End Sub

    Public Function getArrFromString(ByVal str As String) As String()
        Dim arrReturn(-1) As String
        Try
            If Not str = "" Then arrReturn = str.Split(CChar(","))
            Return arrReturn
        Catch ex As Exception
            objfileop.writeErrorLog(ex.Message, ex.StackTrace)
            Return arrReturn
        End Try
    End Function

    Public Function getStrFromArray(ByVal arr() As String) As String
        Dim strReturn As String = Nothing
        If arr Is Nothing Then Return Nothing
        strReturn = String.Join(",", arr)
        Return strReturn
    End Function

#End Region

End Module

#End Region