Public Class SourceItem
    Public Property DirName() As String
    Public Property FileName() As String
    Public Property IncludeSubDirs() As Boolean
    Public Property DeleteWhenDone() As Boolean
    Public Property UseDirName() As Boolean

    Public Sub SourceItem()

        With Me
            .DirName = vbNullString
            .FileName = vbNullString
            .IncludeSubDirs = False
            .DeleteWhenDone = False
            .UseDirName = False
        End With

    End Sub

    Public Sub SourceItem(
                         ByVal dirName As String,
                         ByVal fileName As String,
                         ByVal includeSubDirs As Boolean,
                         ByVal deleteWhenDone As Boolean,
                         ByVal useDirName As Boolean)

        With Me
            .DirName = dirName
            .FileName = fileName
            .IncludeSubDirs = includeSubDirs
            .DeleteWhenDone = deleteWhenDone
            .UseDirName = useDirName
        End With

    End Sub

    Public Function GetNew() As Boolean

        Dim myForm As New AddSource
        Dim dlgResult As DialogResult

        With myForm
            .Text = Application.ProductName + " -- Add New Source"
            .ShowDialog()
            dlgResult = .Result()
            Me.DirName = .txtDir.Text
            Me.FileName = .txtFileSpec.Text
            Me.IncludeSubDirs = .chkIncludeSubFolders.Checked
            Me.DeleteWhenDone = .chkDeleteWhenDone.Checked
            Me.UseDirName = .chkUseDirName.checked
            .Close()
        End With

        GetNew = (dlgResult = DialogResult.OK)

    End Function

    Public Function Change() As Boolean

        Dim myForm As New AddSource
        Dim dlgResult As DialogResult

        With myForm
            .Text = Application.ProductName + " -- Change Source"
            .txtDir.Text = DirName()
            .txtFileSpec.Text = FileName()
            .chkIncludeSubFolders.Checked = IncludeSubDirs()
            .chkDeleteWhenDone.Checked = DeleteWhenDone()
            .chkUseDirName.Checked = UseDirName()
            .ShowDialog()
            dlgResult = .Result()
            Me.DirName = .txtDir.Text
            Me.FileName = .txtFileSpec.Text
            Me.IncludeSubDirs = .chkIncludeSubFolders.Checked
            Me.DeleteWhenDone = .chkDeleteWhenDone.Checked
            Me.UseDirName = .chkUseDirName.checked
            .Close()
        End With

        Change = (dlgResult = DialogResult.OK)

    End Function
End Class
