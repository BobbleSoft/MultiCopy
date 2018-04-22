Imports System.ComponentModel

Public Class MainForm
    Private _ilAddButton As Integer     ' Initial left position of [Add] button.
    Private _ilGoButton As Integer      ' Initial left position of [Go] button.
    Private _iwForm As Integer          ' Initial width of the form.
    Private _iwListView As Integer      ' Initial width of the ListView controls.

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

    Private Sub SaveUserSettingss()
        Dim sourceDirs As New System.Collections.Specialized.StringCollection
        Dim sourceFileSpecs As New System.Collections.Specialized.StringCollection
        Dim sourceIncludeSubDirs As New System.Collections.Specialized.StringCollection
        Dim sourceDeleteWhenDone As New System.Collections.Specialized.StringCollection
        Dim sourceUseDirName As New System.Collections.Specialized.StringCollection
        Dim targetDirs As New System.Collections.Specialized.StringCollection
        Dim lviItem As ListViewItem

        For Each lviItem In lvSources.Items
            sourceDirs.Add(lviItem.SubItems(Globals.SourceColumn.Dir).Text)
            sourceFileSpecs.Add(lviItem.SubItems(Globals.SourceColumn.FileSpec).Text)
            sourceIncludeSubDirs.Add(lviItem.SubItems(Globals.SourceColumn.IncludeSubDirs).Text)
            sourceDeleteWhenDone.Add(lviItem.SubItems(Globals.SourceColumn.DeleteWhenDone).Text)
            sourceUseDirName.Add(lviItem.SubItems(Globals.SourceColumn.UseDirName).Text)
        Next

        For Each lviItem In lvTargets.Items
            targetDirs.Add(lviItem.SubItems(Globals.TargetColumn.Dir).Text)
        Next

        With My.Settings
            .MainFormPositionX = Me.Location.X
            .MainFormPositionY = Me.Location.Y
            .MainFormWidth = Me.Width
            .MainFormHeight = Me.Height
            .MainFormSrcListViewWidthCol0 = lvSources.Columns(0).Width
            .MainFormSrcListViewWidthCol1 = lvSources.Columns(1).Width
            .MainFormSrcListViewWidthCol2 = lvSources.Columns(2).Width
            .MainFormSrcListViewWidthCol3 = lvSources.Columns(3).Width
            .MainFormSrcListViewWidthCol4 = lvSources.Columns(4).Width
            .SourceDirs = sourceDirs
            .SourceDirsCount = lvSources.Items.Count
            .SourceFileSpecs = sourceFileSpecs
            .SourceIncludeSubDirs = sourceIncludeSubDirs
            .SourceDeleteWhenDone = sourceDeleteWhenDone
            .SourceUseDirName = sourceUseDirName
            .TargetDirs = targetDirs
            .TargetDirsCount = lvTargets.Items.Count
        End With
    End Sub

    Private Sub ReadUserSettings()
        Dim sourceDirs As New System.Collections.Specialized.StringCollection
        Dim sourceFileSpecs As New System.Collections.Specialized.StringCollection
        Dim sourceIncludeSubDirs As New System.Collections.Specialized.StringCollection
        Dim sourceDeleteWhenDone As New System.Collections.Specialized.StringCollection
        Dim sourceUseDirName As New System.Collections.Specialized.StringCollection
        Dim targetDirs As New System.Collections.Specialized.StringCollection
        Dim i As Integer
        Dim iValX As Integer
        Dim iValY As Integer
        Dim nMax As Integer

        With My.Settings
            ' Position the main form
            iValX = My.Settings.MainFormPositionX
            If iValX < 0 Then iValX = 100
            iValY = My.Settings.MainFormPositionY
            If iValY < 0 Then iValY = 100
            Me.Location = New Point(x:=iValX, y:=iValY)

            ' Size the form
            i = My.Settings.MainFormWidth
            If i >= 0 Then Me.Width = i
            i = My.Settings.MainFormHeight
            If i >= 0 Then Me.Height = i

            ' Set the Source ListView column widths
            lvSources.Columns(0).Width = .MainFormSrcListViewWidthCol0
            lvSources.Columns(1).Width = .MainFormSrcListViewWidthCol1
            lvSources.Columns(2).Width = .MainFormSrcListViewWidthCol2
            lvSources.Columns(3).Width = .MainFormSrcListViewWidthCol3
            lvSources.Columns(4).Width = .MainFormSrcListViewWidthCol4

            sourceDirs = .SourceDirs
            sourceFileSpecs = .SourceFileSpecs
            sourceIncludeSubDirs = .SourceIncludeSubDirs
            sourceDeleteWhenDone = .SourceDeleteWhenDone
            sourceUseDirName = .SourceUseDirName
            targetDirs = .TargetDirs
        End With

        If Not IsNothing(sourceDirs) Then
            ' We may have more entries saved than what was used the last time. If so,
            ' ignore the extraneous ones.
            nMax = My.Settings.SourceDirsCount
            If sourceDirs.Count < nMax Or nMax < 0 Then
                nMax = sourceDirs.Count
            End If
            For i = 0 To nMax
                Try
                    Dim srcInfo(5) As String
                    Dim lviItem As ListViewItem
                    srcInfo(Globals.SourceColumn.Dir) = sourceDirs.Item(i)
                    If Not srcInfo(Globals.SourceColumn.Dir).ToUpper.Equals("PLACEHOLDER") Then
                        srcInfo(Globals.SourceColumn.FileSpec) = sourceFileSpecs.Item(i)
                        srcInfo(Globals.SourceColumn.IncludeSubDirs) = sourceIncludeSubDirs.Item(i)
                        srcInfo(Globals.SourceColumn.DeleteWhenDone) = sourceDeleteWhenDone.Item(i)
                        srcInfo(Globals.SourceColumn.UseDirName) = sourceUseDirName.Item(i)
                        lviItem = New ListViewItem(srcInfo)
                        lvSources.Items.Add(lviItem)
                    End If
                Catch ex As Exception
                    Debug.WriteLine(ex)
                End Try
            Next
        End If

        If Not IsNothing(targetDirs) Then
            nMax = My.Settings.TargetDirsCount
            If targetDirs.Count < nMax Or nMax < 0 Then
                nMax = targetDirs.Count
            End If
            For i = 0 To targetDirs.Count
                Try
                    Dim tgtInfo(1) As String
                    Dim lviItem As ListViewItem
                    tgtInfo(Globals.TargetColumn.Dir) = targetDirs.Item(i)
                    If Not tgtInfo(Globals.TargetColumn.Dir).ToUpper.Equals("PLACEHOLDER") Then
                        lviItem = New ListViewItem(tgtInfo)
                        lvTargets.Items.Add(lviItem)
                    End If
                Catch ex As Exception
                    Debug.WriteLine(ex)
                End Try
            Next
        End If

        EnableControls()
    End Sub

    ''' <summary>
    ''' Adds a new source item.
    ''' </summary>
    Private Sub AddNew()
        Dim si As New SourceItem()
        Dim bOk As Boolean
        Dim sourceInfo(5) As String     ' Dir, Fspec, SubDirs, Del, UseDirName
        Dim lviSource As ListViewItem

        bOk = si.GetNew()
        If bOk Then
            With si
                sourceInfo(Globals.SourceColumn.Dir) = System.IO.Path.GetFullPath(.DirName)
                sourceInfo(Globals.SourceColumn.FileSpec) = .FileName
                sourceInfo(Globals.SourceColumn.IncludeSubDirs) = YesOrNo(.IncludeSubDirs)
                sourceInfo(Globals.SourceColumn.DeleteWhenDone) = YesOrNo(.DeleteWhenDone)
                sourceInfo(Globals.SourceColumn.UseDirName) = YesOrNo(.UseDirName)
            End With
            lviSource = New ListViewItem(sourceInfo)
            lvSources.Items.Add(lviSource)
        End If
    End Sub

    Private Sub ChangeSource()
        Dim si As New SourceItem()
        Dim bOk As Boolean
        Dim lviSource As ListViewItem

        lviSource = lvSources.SelectedItems(0)
        With si
            .DirName = lviSource.SubItems(Globals.SourceColumn.Dir).Text
            .FileName = lviSource.SubItems(Globals.SourceColumn.FileSpec).Text
            .IncludeSubDirs = TrueOrFalse(lviSource.SubItems(Globals.SourceColumn.IncludeSubDirs).Text)
            .DeleteWhenDone = TrueOrFalse(lviSource.SubItems(Globals.SourceColumn.DeleteWhenDone).Text)
            .UseDirName = TrueOrFalse(lviSource.SubItems(Globals.SourceColumn.UseDirName).Text)
        End With
        bOk = si.Change()
        If bOk Then
            With si
                lviSource.SubItems(Globals.SourceColumn.Dir).Text = .DirName
                lviSource.SubItems(Globals.SourceColumn.FileSpec).Text = .FileName
                lviSource.SubItems(Globals.SourceColumn.IncludeSubDirs).Text = YesOrNo(.IncludeSubDirs)
                lviSource.SubItems(Globals.SourceColumn.DeleteWhenDone).Text = YesOrNo(.DeleteWhenDone)
                lviSource.SubItems(Globals.SourceColumn.UseDirName).Text = YesOrNo(.UseDirName)
            End With
        End If

    End Sub

    Private Sub DeleteSource()
        lvSources.SelectedItems(0).Remove()
        EnableControls()
    End Sub

    Private Sub AddTarget()
        Dim myForm As New AddTarget
        Dim dlgResult As DialogResult
        Dim lviTarget As ListViewItem
        Dim targetInfo(1) As String

        myForm.Text = Application.ProductName + " -- Add Target Folder"
        myForm.ShowDialog()
        dlgResult = myForm.Result()
        If dlgResult = DialogResult.OK Then
            targetInfo(0) = myForm.txtDir.Text
            lviTarget = New ListViewItem(targetInfo)
            lvTargets.Items.Add(lviTarget)
        End If
        myForm.Close()
    End Sub

    Private Sub ChangeTarget()
        Dim myForm As New AddTarget
        Dim dlgResult As DialogResult
        Dim lviTarget As ListViewItem

        lviTarget = lvTargets.SelectedItems(0)

        myForm.Text = Application.ProductName + " -- Change Target Folder"
        myForm.txtDir.Text = lviTarget.SubItems(0).Text
        myForm.ShowDialog()
        dlgResult = myForm.Result()
        If dlgResult = DialogResult.OK Then
            lviTarget.SubItems(0).Text = myForm.txtDir.Text
        End If
        myForm.Close()
    End Sub

    Private Sub DeleteTarget()
        lvTargets.SelectedItems(0).Remove()
        EnableControls()
    End Sub

    ''' <summary>
    ''' Enable and disable controls on the form dependent on values or contents of
    ''' other controls.
    ''' </summary>
    Private Sub EnableControls()
        Dim bEnableSrc As Boolean
        Dim bEnableTgt As Boolean
        Dim bEnable As Boolean

        bEnableSrc = (lvSources.Items.Count > 0)
        bEnableTgt = (lvTargets.Items.Count > 0)

        btnGo.Enabled = (bEnableSrc And bEnableTgt)

        bEnable = (lvSources.SelectedItems.Count <> 0)
        btnChangeSource.Enabled = bEnable
        btnDeleteSource.Enabled = bEnable

        bEnable = (lvTargets.SelectedItems.Count <> 0)
        btnChangeTarget.Enabled = bEnable
        btnDeleteTarget.Enabled = bEnable

    End Sub

    Private Sub BeginProcess()
        Dim myForm As New CopyItems
        myForm.Show()
        myForm.Analyze(lvSources, lvTargets)
        'myForm.ShowDialog()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        Dim frmAbout As New AboutBox
        frmAbout.ShowDialog()
    End Sub

    Private Sub btnAddThingToCopy_Click(sender As Object, e As EventArgs) Handles btnAddSource.Click
        AddNew()
        EnableControls()
    End Sub

    Private Sub form_load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me
            .lvSources.Items.Clear()
            .lvTargets.Items.Clear()
            _iwForm = .Width
            _ilAddButton = .btnAddSource.Left
            _ilGoButton = .btnGo.Left
            _iwListView = .lvSources.Width
        End With

        ReadUserSettings()

        Me.Text = Application.ProductName + " v" + Application.ProductVersion
#If DEBUG Then
        Me.Text = Me.Text + "    [DEBUG]"
#End If
    End Sub

    Private Sub form_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.Visible Then
            Try
                lvSources.Width = _iwListView + (Me.Width - _iwForm)
                lvTargets.Width = lvSources.Width
                '                lvActivity.Height = _ihActivity + (Me.Height - _ihForm)

                btnAddSource.Left = _ilAddButton + (Me.Width - _iwForm)
                btnChangeSource.Left = btnAddSource.Left
                btnDeleteSource.Left = btnAddSource.Left
                btnAddTarget.Left = btnAddSource.Left
                btnChangeTarget.Left = btnAddSource.Left
                btnDeleteTarget.Left = btnAddSource.Left

                btnGo.Left = _ilGoButton + (Me.Width - _iwForm)
                btnCancel.Left = btnGo.Left
                btnAbout.Left = btnGo.Left
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try
        End If
    End Sub

    Private Sub SourcesColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvSources.ColumnClick

        If lvSources.Columns.Item(e.Column).ListView.Sorting <> SortOrder.Descending Then
            lvSources.Columns.Item(e.Column).ListView.Sorting = SortOrder.Descending
        Else
            lvSources.Columns.Item(e.Column).ListView.Sorting = SortOrder.Ascending
        End If

    End Sub

    Private Sub TargetsColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvTargets.ColumnClick

        If lvTargets.Columns.Item(e.Column).ListView.Sorting <> SortOrder.Descending Then
            lvTargets.Columns.Item(e.Column).ListView.Sorting = SortOrder.Descending
        Else
            lvTargets.Columns.Item(e.Column).ListView.Sorting = SortOrder.Ascending
        End If

    End Sub

    Private Sub lvSources_MouseMove(sender As Object, e As MouseEventArgs) Handles lvSources.MouseMove
        EnableControls()
    End Sub

    Private Sub lvTargets_MouseMove(sender As Object, e As MouseEventArgs) Handles lvTargets.MouseMove
        EnableControls()
    End Sub

    Private Sub btnChangeSource_Click(sender As Object, e As EventArgs) Handles btnChangeSource.Click
        ChangeSource()
    End Sub

    Private Sub btnDeleteSource_Click(sender As Object, e As EventArgs) Handles btnDeleteSource.Click
        DeleteSource()
        EnableControls()
    End Sub

    Private Sub btnAddTarget_Click(sender As Object, e As EventArgs) Handles btnAddTarget.Click
        AddTarget()
        EnableControls()
    End Sub

    Private Sub btnChangeTarget_Click(sender As Object, e As EventArgs) Handles btnChangeTarget.Click
        ChangeTarget()
    End Sub

    Private Sub btnDeleteTarget_Click(sender As Object, e As EventArgs) Handles btnDeleteTarget.Click
        DeleteTarget()
        EnableControls()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        EnableControls()
        BeginProcess()
    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        SaveUserSettingss()
    End Sub

    Private Sub lvSources_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvSources.MouseDoubleClick
        Dim lvi As ListViewItem = lvSources.HitTest(e.Location).Item
        If lvi IsNot Nothing Then
            Try
                Process.Start(lvi.SubItems(Globals.SourceColumn.Dir).Text)
            Catch ex As Exception
                MessageBox.Show("Sorry, but I cannot seem to open that folder.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub lvTargets_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvTargets.MouseDoubleClick
        Dim lvi As ListViewItem = lvTargets.HitTest(e.Location).Item
        If lvi IsNot Nothing Then
            Try
                Process.Start(lvi.SubItems(Globals.TargetColumn.Dir).Text)
            Catch ex As Exception
                MessageBox.Show("Sorry, but I cannot seem to open that folder.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
