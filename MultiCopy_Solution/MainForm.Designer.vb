<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.lblSource = New System.Windows.Forms.Label()
        Me.lblWhereToCopy = New System.Windows.Forms.Label()
        Me.lvTargets = New System.Windows.Forms.ListView()
        Me.colhdrDirName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAddSource = New System.Windows.Forms.Button()
        Me.btnChangeSource = New System.Windows.Forms.Button()
        Me.btnDeleteSource = New System.Windows.Forms.Button()
        Me.btnDeleteTarget = New System.Windows.Forms.Button()
        Me.btnChangeTarget = New System.Windows.Forms.Button()
        Me.btnAddTarget = New System.Windows.Forms.Button()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lvSources = New System.Windows.Forms.ListView()
        Me.colhdrFolderName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colhdrFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colhdrIncludeSubDirs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colhdrDeleteWhenDone = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colhdrUseDirName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lblSource
        '
        Me.lblSource.AutoSize = True
        Me.lblSource.Location = New System.Drawing.Point(13, 13)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(109, 13)
        Me.lblSource.TabIndex = 0
        Me.lblSource.Text = "Source items to copy:"
        '
        'lblWhereToCopy
        '
        Me.lblWhereToCopy.AutoSize = True
        Me.lblWhereToCopy.Location = New System.Drawing.Point(16, 158)
        Me.lblWhereToCopy.Name = "lblWhereToCopy"
        Me.lblWhereToCopy.Size = New System.Drawing.Size(80, 13)
        Me.lblWhereToCopy.TabIndex = 2
        Me.lblWhereToCopy.Text = "Where to copy:"
        '
        'lvTargets
        '
        Me.lvTargets.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colhdrDirName})
        Me.lvTargets.FullRowSelect = True
        Me.lvTargets.GridLines = True
        Me.lvTargets.Location = New System.Drawing.Point(16, 175)
        Me.lvTargets.MultiSelect = False
        Me.lvTargets.Name = "lvTargets"
        Me.lvTargets.Size = New System.Drawing.Size(466, 97)
        Me.lvTargets.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvTargets.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.lvTargets, "Where to copy the source items (shown above) to.")
        Me.lvTargets.UseCompatibleStateImageBehavior = False
        Me.lvTargets.View = System.Windows.Forms.View.Details
        '
        'colhdrDirName
        '
        Me.colhdrDirName.Text = "Folder Name"
        Me.colhdrDirName.Width = 460
        '
        'btnAddSource
        '
        Me.btnAddSource.Location = New System.Drawing.Point(489, 29)
        Me.btnAddSource.Name = "btnAddSource"
        Me.btnAddSource.Size = New System.Drawing.Size(75, 23)
        Me.btnAddSource.TabIndex = 0
        Me.btnAddSource.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.btnAddSource, "Adds a new folder & file specification to copy.")
        Me.btnAddSource.UseVisualStyleBackColor = True
        '
        'btnChangeSource
        '
        Me.btnChangeSource.Enabled = False
        Me.btnChangeSource.Location = New System.Drawing.Point(489, 59)
        Me.btnChangeSource.Name = "btnChangeSource"
        Me.btnChangeSource.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeSource.TabIndex = 1
        Me.btnChangeSource.Text = "Change"
        Me.ToolTip1.SetToolTip(Me.btnChangeSource, "Make changes to the selected Thing to Copy.")
        Me.btnChangeSource.UseVisualStyleBackColor = True
        '
        'btnDeleteSource
        '
        Me.btnDeleteSource.Enabled = False
        Me.btnDeleteSource.Location = New System.Drawing.Point(489, 89)
        Me.btnDeleteSource.Name = "btnDeleteSource"
        Me.btnDeleteSource.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteSource.TabIndex = 2
        Me.btnDeleteSource.Text = "Delete"
        Me.ToolTip1.SetToolTip(Me.btnDeleteSource, "Deletes the selected Thing to Copy.")
        Me.btnDeleteSource.UseVisualStyleBackColor = True
        '
        'btnDeleteTarget
        '
        Me.btnDeleteTarget.Enabled = False
        Me.btnDeleteTarget.Location = New System.Drawing.Point(489, 235)
        Me.btnDeleteTarget.Name = "btnDeleteTarget"
        Me.btnDeleteTarget.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteTarget.TabIndex = 6
        Me.btnDeleteTarget.Text = "Delete"
        Me.ToolTip1.SetToolTip(Me.btnDeleteTarget, "Deletes (removes) the folder name selected. Does not delete the actual folder.")
        Me.btnDeleteTarget.UseVisualStyleBackColor = True
        '
        'btnChangeTarget
        '
        Me.btnChangeTarget.Enabled = False
        Me.btnChangeTarget.Location = New System.Drawing.Point(489, 205)
        Me.btnChangeTarget.Name = "btnChangeTarget"
        Me.btnChangeTarget.Size = New System.Drawing.Size(75, 23)
        Me.btnChangeTarget.TabIndex = 5
        Me.btnChangeTarget.Text = "Change"
        Me.ToolTip1.SetToolTip(Me.btnChangeTarget, "Changes (edits) the folder name selected. Does not change the actual folder.")
        Me.btnChangeTarget.UseVisualStyleBackColor = True
        '
        'btnAddTarget
        '
        Me.btnAddTarget.Location = New System.Drawing.Point(489, 175)
        Me.btnAddTarget.Name = "btnAddTarget"
        Me.btnAddTarget.Size = New System.Drawing.Size(75, 23)
        Me.btnAddTarget.TabIndex = 4
        Me.btnAddTarget.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.btnAddTarget, "Adds a new folder to copy the Things to.")
        Me.btnAddTarget.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Enabled = False
        Me.btnGo.Location = New System.Drawing.Point(651, 28)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 8
        Me.btnGo.Text = "&Go"
        Me.ToolTip1.SetToolTip(Me.btnGo, "Starts the copying process.")
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'btnAbout
        '
        Me.btnAbout.Location = New System.Drawing.Point(651, 89)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(75, 23)
        Me.btnAbout.TabIndex = 10
        Me.btnAbout.Text = "About"
        Me.ToolTip1.SetToolTip(Me.btnAbout, "Displays some information about this application.")
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(651, 59)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "&Cancel"
        Me.ToolTip1.SetToolTip(Me.btnCancel, "Cancels (stops) the copying process. Does not rollback any changes.")
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lvSources
        '
        Me.lvSources.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colhdrFolderName, Me.colhdrFileName, Me.colhdrIncludeSubDirs, Me.colhdrDeleteWhenDone, Me.colhdrUseDirName})
        Me.lvSources.FullRowSelect = True
        Me.lvSources.Location = New System.Drawing.Point(16, 29)
        Me.lvSources.MultiSelect = False
        Me.lvSources.Name = "lvSources"
        Me.lvSources.Size = New System.Drawing.Size(466, 97)
        Me.lvSources.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.lvSources, "What folders and files are to be copied to the targets shown below.")
        Me.lvSources.UseCompatibleStateImageBehavior = False
        Me.lvSources.View = System.Windows.Forms.View.Details
        '
        'colhdrFolderName
        '
        Me.colhdrFolderName.Text = "Folder Name"
        Me.colhdrFolderName.Width = 133
        '
        'colhdrFileName
        '
        Me.colhdrFileName.Text = "File Name"
        Me.colhdrFileName.Width = 100
        '
        'colhdrIncludeSubDirs
        '
        Me.colhdrIncludeSubDirs.Text = "Include Sub-folders"
        Me.colhdrIncludeSubDirs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colhdrIncludeSubDirs.Width = 110
        '
        'colhdrDeleteWhenDone
        '
        Me.colhdrDeleteWhenDone.Text = "Delete When Done"
        Me.colhdrDeleteWhenDone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colhdrDeleteWhenDone.Width = 110
        '
        'colhdrUseDirName
        '
        Me.colhdrUseDirName.Text = "Use Folder Name"
        Me.colhdrUseDirName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(742, 296)
        Me.Controls.Add(Me.lvSources)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.btnDeleteTarget)
        Me.Controls.Add(Me.btnChangeTarget)
        Me.Controls.Add(Me.btnAddTarget)
        Me.Controls.Add(Me.btnDeleteSource)
        Me.Controls.Add(Me.btnChangeSource)
        Me.Controls.Add(Me.btnAddSource)
        Me.Controls.Add(Me.lvTargets)
        Me.Controls.Add(Me.lblWhereToCopy)
        Me.Controls.Add(Me.lblSource)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(758, 335)
        Me.Name = "MainForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "MultiCopy"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblSource As Label
    Friend WithEvents lblWhereToCopy As Label
    Friend WithEvents lvTargets As ListView
    Friend WithEvents btnAddSource As Button
    Friend WithEvents btnChangeSource As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents btnDeleteSource As Button
    Friend WithEvents btnDeleteTarget As Button
    Friend WithEvents btnChangeTarget As Button
    Friend WithEvents btnAddTarget As Button
    Friend WithEvents btnGo As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lvSources As ListView
    Friend WithEvents colhdrFolderName As ColumnHeader
    Friend WithEvents colhdrFileName As ColumnHeader
    Friend WithEvents colhdrIncludeSubDirs As ColumnHeader
    Friend WithEvents colhdrDeleteWhenDone As ColumnHeader
    Friend WithEvents colhdrDirName As ColumnHeader
    Friend WithEvents colhdrUseDirName As ColumnHeader
End Class
