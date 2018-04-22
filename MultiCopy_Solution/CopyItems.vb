Option Strict On

Imports System.ComponentModel
Imports System.IO

Public Class CopyItems
    Private Enum Action
        Copy = 0
        Delete = 1
    End Enum

    Private Enum ActionResult
        Success = 0
        Failure = 1
    End Enum

    ' Columns in the display
    Private Enum Col
        Action = 0
        SrcDir = 1
        SrcFileName = 2
        TgtDir = 3
        Result = 4
    End Enum

    Private _bStopNow As Boolean = False
    Private _iwForm As Integer              ' Form initial width
    Private _ihForm As Integer              ' Form initial height
    Private _iwActivity As Integer          ' lvActivity initial width
    Private _ihActivity As Integer          ' lvActivity initial height
    Private _ilGoButton As Integer          ' [Go] initial left position

    Private Sub SaveUserSettingss()
        With My.Settings
            .ActivityFormPositionX = Me.Left
            .ActivityFormPositionY = Me.Top
            .ActivityFormWidth = Me.Width
            .ActivityFormHeight = Me.Height
            .ActivityColActionWidth = lvActivity.Columns(Col.Action).Width
            .ActivityColSrcDirWidth = lvActivity.Columns(Col.SrcDir).Width
            .ActivityColFnameWidth = lvActivity.Columns(Col.SrcFileName).Width
            .ActivityColTgtDirWidth = lvActivity.Columns(Col.TgtDir).Width
            .ActivityColResultWidth = lvActivity.Columns(Col.Result).Width
        End With
    End Sub

    Private Sub ReadUserSettings()
        Dim i As Integer

        With My.Settings
            ' Position the main form
            i = .ActivityFormPositionX
            If i >= 0 Then Me.Left = i
            i = .ActivityFormPositionY
            If i >= 0 Then Me.Top = i

            ' Resize the form
            i = .ActivityFormWidth
            If i >= 0 Then Me.Width = i
            i = .ActivityFormHeight
            If i >= 0 Then Me.Height = i

            ' Resize the list view columns
            i = .ActivityColActionWidth
            If i >= 10 Then lvActivity.Columns(Col.Action).Width = i
            i = .ActivityColFnameWidth
            If i >= 10 Then lvActivity.Columns(Col.SrcFileName).Width = i
            i = .ActivityColResultWidth
            If i >= 10 Then lvActivity.Columns(Col.Result).Width = i
            i = .ActivityColSrcDirWidth
            If i >= 10 Then lvActivity.Columns(Col.SrcDir).Width = i
            i = .ActivityColTgtDirWidth
            If i >= 10 Then lvActivity.Columns(Col.TgtDir).Width = i
        End With

    End Sub

    Private Function YesOrNo(ByVal bVal As Boolean) As String
        If bVal Then
            YesOrNo = "Yes"
        Else
            YesOrNo = "No"
        End If
    End Function

    Private Function TrueOrFalse(ByVal sText As String) As Boolean
        TrueOrFalse = sText.ToUpper().Equals("YES")
    End Function

    ''' <summary>
    ''' Perform analysis to determine actions that will occur.
    ''' </summary>
    ''' <param name="lvSrc">A ListView containing all the source elements.</param>
    ''' <param name="lvTgt">A ListView containing all the target elements.</param>
    Public Sub Analyze(ByRef lvSrc As ListView, ByRef lvTgt As ListView)
        Dim lviSrcItem As ListViewItem
        Dim lviTgtFolder As ListViewItem
        Dim sSrcPath As String
        Dim sSrcFileSpec As String
        Dim bSrcIncludeSubDirs As Boolean
        Dim bSrcDeleteWhenDone As Boolean
        Dim bSrcUseDirName As Boolean
        Dim sTgtPath As String
        Dim i As Integer = 0
        Dim dirName As String

        SetTitle("Analyzing...")

        ' Create the list of actions that will be performed.
        For Each lviSrcItem In lvSrc.Items
            If _bStopNow Then Exit For

            sSrcPath = lviSrcItem.SubItems(Globals.SourceColumn.Dir).Text
            sSrcFileSpec = lviSrcItem.SubItems(Globals.SourceColumn.FileSpec).Text
            bSrcIncludeSubDirs = TrueOrFalse(lviSrcItem.SubItems(Globals.SourceColumn.IncludeSubDirs).Text)
            bSrcDeleteWhenDone = TrueOrFalse(lviSrcItem.SubItems(Globals.SourceColumn.DeleteWhenDone).Text)
            bSrcUseDirName = TrueOrFalse(lviSrcItem.SubItems(Globals.SourceColumn.UseDirName).Text)

            For Each lviTgtFolder In lvTgt.Items
                If _bStopNow Then Exit For

                sTgtPath = lviTgtFolder.SubItems(Globals.TargetColumn.Dir).Text
                If bSrcUseDirName Then
                    dirName = GetLastDirName(sSrcPath)
                    sTgtPath = Path.Combine(sTgtPath, dirName)
                End If

                Dim nOrigSrcPathLen As Integer
                Dim nOrigTgtPathLen As Integer
                nOrigSrcPathLen = Len(sSrcPath)
                nOrigTgtPathLen = Len(sTgtPath)
                SearchDirs(nOrigSrcPathLen, sSrcPath, sSrcFileSpec, bSrcIncludeSubDirs, bSrcDeleteWhenDone, bSrcUseDirName, nOrigTgtPathLen, sTgtPath)
            Next
        Next

        SetTitle("Ready")
        btnGo.Enabled = True

    End Sub

    Private Sub SearchDirs(
                          ByVal nOrigSrcPathLen As Integer,
                          ByVal sSrcPath As String,
                          ByVal sFileSpec As String,
                          ByVal bIncludeSubDirs As Boolean,
                          ByVal bSrcDeleteWhenDone As Boolean,
                          ByVal bSrcUseDirName As Boolean,
                          ByVal nOrigTgtPathLen As Integer,
                          ByVal sTgtPath As String)

        Dim f As String
        Dim d As String
        Dim arrEntry(5) As String
        Dim lviEntry As ListViewItem
        Dim dirName As String = vbNullString
        Dim sSrc As String
        Dim stgt As String

        arrEntry(Col.Action) = "Copy"
        arrEntry(Col.Result) = "Ready"
        arrEntry(Col.SrcDir) = sSrcPath
        'If bSrcUseDirName Then
        '    dirName = GetLastDirName(sSrcPath)
        '    sTgtPath = Path.Combine(sTgtPath, dirName)
        'End If
        arrEntry(Col.TgtDir) = sTgtPath

        Try
            ' Gather the list of files in the current directory that match the filespec.
            For Each f In Directory.GetFiles(sSrcPath, sFileSpec)
                If _bStopNow Then Exit For
                arrEntry(Col.SrcFileName) = Path.GetFileName(f)
                lviEntry = New ListViewItem(arrEntry)
                lvActivity.Items.Add(lviEntry)
            Next

            If bSrcDeleteWhenDone Then
                arrEntry(Col.Action) = "Delete"
                arrEntry(Col.SrcDir) = sSrcPath
                arrEntry(Col.SrcFileName) = vbNullString
                arrEntry(Col.TgtDir) = vbNullString
                arrEntry(Col.Result) = "Ready"
                lviEntry = New ListViewItem(arrEntry)
                lvActivity.Items.Add(lviEntry)
            End If
        Catch ex As Exception
            ' Source path may not exist or may be unreadable.
            Debug.WriteLine(ex)
        End Try

        If Not _bStopNow And bIncludeSubDirs Then
            ' Go through each subdirectory and repeat this process.
            For Each d In Directory.GetDirectories(sSrcPath)
                'dirName = GetLastDirName(d)
                'sTgtPath = Path.Combine(sTgtPath, dirName)
                Dim i As Integer = Len(d) - nOrigSrcPathLen
                sSrc = Mid(d, nOrigSrcPathLen + Len(Path.DirectorySeparatorChar))
                stgt = Mid(sTgtPath, 1, nOrigTgtPathLen)
                sTgtPath = Path.Combine(stgt, sSrc)
                SearchDirs(nOrigSrcPathLen, d, sFileSpec, bIncludeSubDirs, bSrcDeleteWhenDone, bSrcUseDirName, nOrigTgtPathLen, sTgtPath)
            Next
        End If

    End Sub

    ''' <summary>
    ''' Parses a path name to determine the last directory name in the path as well as the file
    ''' name. Example: 
    ''' </summary>
    ''' <param name="srcPath">The path name to parse. Example: \\Samson\recording_in_work\movie\Aliens</param>
    ''' <returns>The last directory name in the path being parsed. Example: Aliens</returns>
    Private Function GetLastDirName(ByVal srcPath As String) As String

        Dim i As Integer
        Dim dirName As String = vbNullString

        Try
            If Not IsNothing(srcPath) Then
                ' Get "Aliens" from "\\Samson\recording_in_work\movie\Aliens"
                i = srcPath.LastIndexOf(Path.DirectorySeparatorChar)
                dirName = Mid(srcPath, i + Len(Path.DirectorySeparatorChar))
            End If
        Catch ex As Exception
            dirName = vbNullString
        End Try

        GetLastDirName = dirName

    End Function

    Private Sub SetTitle(ByVal sText As String)
        Dim sTitle As String = Application.ProductName + " -- " + sText
#If DEBUG Then
        sTitle += "    [DEBUG]"
#End If
        Me.Text = sTitle
    End Sub

    Private Sub form_load(sender As Object, e As EventArgs) Handles MyBase.Load
        _iwForm = Me.Width       ' Initial width of form
        _ihForm = Me.Height      ' Initial height of form
        _iwActivity = lvActivity.Width
        _ihActivity = lvActivity.Height
        _ilGoButton = btnGo.Left
        lvActivity.Items.Clear()
        SetTitle("Analyzing...")
        ReadUserSettings()
    End Sub

    Private Sub form_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.Visible Then
            Try
                lvActivity.Width = _iwActivity + (Me.Width - _iwForm)
                lvActivity.Height = _ihActivity + (Me.Height - _ihForm)
                btnGo.Left = _ilGoButton + (Me.Width - _iwForm)
                btnStop.Left = btnGo.Left
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        End If
    End Sub

    Private Sub PerformActivities()

        Dim lviEntry As ListViewItem
        Dim sAction As String
        Dim sSrcFname As String
        Dim sTgtFname As String
        Dim mySrcFileInfo As FileInfo
        Dim myTgtFileInfo As FileInfo

        btnGo.Enabled = False
        btnStop.Enabled = True
        SetTitle("Processing...")
        lvActivity.Cursor = Cursors.WaitCursor

        ' Perform the activities shown in the Activity ListView
        For Each lviEntry In lvActivity.Items
            If _bStopNow Then Exit For
            lviEntry.SubItems(Col.Result).Text = "In work"
            lvActivity.Refresh()
            sAction = lviEntry.SubItems(Col.Action).Text
            Select Case sAction.ToUpper()
                Case "COPY"
                    sSrcFname = Path.Combine(lviEntry.SubItems(Col.SrcDir).Text, lviEntry.SubItems(Col.SrcFileName).Text)
                    If Not File.Exists(sSrcFname) Then
                        lviEntry.SubItems(Col.Result).Text = "Source unavailable"
                    Else
                        sTgtFname = Path.Combine(lviEntry.SubItems(Col.TgtDir).Text, lviEntry.SubItems(Col.SrcFileName).Text)
                        If File.Exists(sTgtFname) Then
                            lviEntry.SubItems(Col.Result).Text = "Target exists"
                        Else
                            If FileCopy(sSrcFname, sTgtFname, False) Then
                                mySrcFileInfo = New FileInfo(sSrcFname)
                                myTgtFileInfo = New FileInfo(sTgtFname)
                                If mySrcFileInfo.Length = myTgtFileInfo.Length Then
                                    lviEntry.SubItems(Col.Result).Text = "Success"
                                Else
                                    lviEntry.SubItems(Col.Result).Text = "File size mis-match"
                                End If
                            Else
                                lviEntry.SubItems(Col.Result).Text = "Failed"
                            End If
                        End If
                    End If
                Case "DELETE"
                    lviEntry.SubItems(Col.Result).Text = "Bypassed"
                Case Else
            End Select
            lvActivity.Refresh()
        Next

        lvActivity.Cursor = Cursors.Default
        btnGo.Enabled = True
        btnStop.Enabled = False

    End Sub

    Private Function FileCopy(ByVal sSrc As String, ByVal sTgt As String, ByVal bOverwrite As Boolean) As Boolean
        Try
            Directory.CreateDirectory(Path.GetDirectoryName(sTgt))
            File.Copy(sSrc, sTgt, bOverwrite)
            FileCopy = File.Exists(sTgt)
        Catch ex As Exception
            FileCopy = False
        End Try
    End Function

    Private Sub StopNow()
        btnGo.Enabled = False
        btnStop.Enabled = False
        _bStopNow = True
        SetTitle("Stopped")
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        PerformActivities()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        StopNow()
    End Sub

    Private Sub CopyItems_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        SaveUserSettingss()
    End Sub

    Private Sub lvActivity_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvActivity.MouseDoubleClick
        Dim lvi As ListViewItem = lvActivity.HitTest(e.Location).Item
        If lvi IsNot Nothing Then
            Try
                Process.Start(lvi.SubItems(Col.SrcDir).Text)
                Process.Start(lvi.SubItems(Col.TgtDir).Text)
            Catch ex As Exception
                MessageBox.Show("Sorry, but I cannot seem to process the entry correctly.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class