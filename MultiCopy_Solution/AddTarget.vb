Public Class AddTarget
    Private _OkClicked As Boolean = False

    Private Sub form_load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblFolderExist.Text = vbNullString
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim sPath As String
        sPath = GetFolder(txtDir.Text)
        If Len(sPath) > 0 Then
            Me.txtDir.Text = sPath
        End If
    End Sub

    ''' <summary>
    ''' Presents the 'Browse for Folder' dialog box to t he user and saves the result, if
    ''' any, to our "starting directory" textbox.
    ''' </summary>
    Private Function GetFolder(ByVal sInPath As String) As String
        Dim sPath As String = vbNullString

        ' Set up and show the 'Browse for Folder' dialog.
        Using objFolderDialog As New FolderBrowserDialog
            With objFolderDialog
                If DirIsReadable(sInPath) Then
                    .SelectedPath = sInPath
                End If
                .ShowNewFolderButton = False
                .Description = "Please select the folder to use"
                If .ShowDialog() = DialogResult.OK Then
                    sPath = .SelectedPath
                End If
            End With
        End Using

        GetFolder = sPath
    End Function

    Public Function Result() As DialogResult
        If _OkClicked Then
            Result = DialogResult.OK
        Else
            Result = DialogResult.Cancel
        End If
    End Function

    ''' <summary>
    ''' Enables or disables the OK button depending on the values in the form.
    ''' </summary>
    Private Sub CheckOkButton()
        Dim enableIt As Boolean = False

        If Len(txtDir.Text) > 0 Then
            enableIt = True
        End If

        btnOK.Enabled = enableIt
    End Sub

    ''' <summary>
    ''' Determines if the directory specified is reachable. If it is a valid directory
    ''' but we do not have permission, then we trap a "permission denied" exception. If
    ''' the directory format is invalid (e.g., C:\MYDIR\D:) then that is trapped also.
    ''' </summary>
    ''' <param name="sDir">The directory (folder) to check for validity.</param>
    ''' <returns>True if the directory is readable, otherwise False.</returns>
    Private Function DirIsReadable(ByVal sDir As String) As Boolean
        Try
            DirIsReadable = System.IO.Directory.Exists(sDir)
        Catch ex As Exception
            DirIsReadable = False
            Debug.WriteLine(ex)
        End Try
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        _OkClicked = True
        txtDir.Text = System.IO.Path.GetFullPath(txtDir.Text)
        Me.Hide()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        _OkClicked = False
        Me.Hide()
    End Sub

    Private Sub txtDir_TextChanged(sender As Object, e As EventArgs) Handles txtDir.TextChanged
        If DirIsReadable(txtDir.Text) Then
            lblFolderExist.Text = vbNullString
        Else
            lblFolderExist.Text = "(This folder does not exist or is not readable.)"
        End If
        CheckOkButton()
    End Sub

End Class