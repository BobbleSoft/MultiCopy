<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddSource
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblFolderName = New System.Windows.Forms.Label()
        Me.txtDir = New System.Windows.Forms.TextBox()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.txtFileSpec = New System.Windows.Forms.TextBox()
        Me.lblFolderExist = New System.Windows.Forms.Label()
        Me.chkDeleteWhenDone = New System.Windows.Forms.CheckBox()
        Me.chkIncludeSubFolders = New System.Windows.Forms.CheckBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.chkUseDirName = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(650, 27)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "O&K"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(650, 57)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblFolderName
        '
        Me.lblFolderName.AutoSize = True
        Me.lblFolderName.Location = New System.Drawing.Point(13, 13)
        Me.lblFolderName.Name = "lblFolderName"
        Me.lblFolderName.Size = New System.Drawing.Size(129, 13)
        Me.lblFolderName.TabIndex = 2
        Me.lblFolderName.Text = "Folder name to copy from:"
        '
        'txtDir
        '
        Me.txtDir.Location = New System.Drawing.Point(149, 13)
        Me.txtDir.Name = "txtDir"
        Me.txtDir.Size = New System.Drawing.Size(364, 20)
        Me.txtDir.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtDir, "This is the source folder name. It  must be fully qualified (relative folder name" &
        "s will not work correctly).")
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(16, 66)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(93, 13)
        Me.lblFileName.TabIndex = 4
        Me.lblFileName.Text = "File name to copy:"
        '
        'txtFileSpec
        '
        Me.txtFileSpec.Location = New System.Drawing.Point(149, 66)
        Me.txtFileSpec.Name = "txtFileSpec"
        Me.txtFileSpec.Size = New System.Drawing.Size(237, 20)
        Me.txtFileSpec.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtFileSpec, "This may be any valid file specified. Examples: ""*.*"" or ""movie_list.*"".")
        '
        'lblFolderExist
        '
        Me.lblFolderExist.AutoSize = True
        Me.lblFolderExist.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolderExist.Location = New System.Drawing.Point(149, 36)
        Me.lblFolderExist.Name = "lblFolderExist"
        Me.lblFolderExist.Size = New System.Drawing.Size(111, 14)
        Me.lblFolderExist.TabIndex = 6
        Me.lblFolderExist.Text = "(Folder does not exist)"
        '
        'chkDeleteWhenDone
        '
        Me.chkDeleteWhenDone.AutoSize = True
        Me.chkDeleteWhenDone.Location = New System.Drawing.Point(186, 115)
        Me.chkDeleteWhenDone.Name = "chkDeleteWhenDone"
        Me.chkDeleteWhenDone.Size = New System.Drawing.Size(163, 17)
        Me.chkDeleteWhenDone.TabIndex = 5
        Me.chkDeleteWhenDone.Text = "Delete when copying is done"
        Me.ToolTip1.SetToolTip(Me.chkDeleteWhenDone, "If checked the source folder will be deleted when the copying is done.")
        Me.chkDeleteWhenDone.UseVisualStyleBackColor = True
        '
        'chkIncludeSubFolders
        '
        Me.chkIncludeSubFolders.AutoSize = True
        Me.chkIncludeSubFolders.Location = New System.Drawing.Point(16, 115)
        Me.chkIncludeSubFolders.Name = "chkIncludeSubFolders"
        Me.chkIncludeSubFolders.Size = New System.Drawing.Size(115, 17)
        Me.chkIncludeSubFolders.TabIndex = 4
        Me.chkIncludeSubFolders.Text = "Include sub-folders"
        Me.ToolTip1.SetToolTip(Me.chkIncludeSubFolders, "If checked the source folders' entire folder tree will be copied.l")
        Me.chkIncludeSubFolders.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(528, 12)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "&Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'chkUseDirName
        '
        Me.chkUseDirName.AutoSize = True
        Me.chkUseDirName.Location = New System.Drawing.Point(424, 115)
        Me.chkUseDirName.Name = "chkUseDirName"
        Me.chkUseDirName.Size = New System.Drawing.Size(179, 17)
        Me.chkUseDirName.TabIndex = 6
        Me.chkUseDirName.Text = "Use folder name of source folder"
        Me.ToolTip1.SetToolTip(Me.chkUseDirName, "If checked, the folder name ""MyDoc"" of source ""C:\User\MyDoc"" will be created.")
        Me.chkUseDirName.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        '
        'AddSource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 144)
        Me.Controls.Add(Me.chkUseDirName)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.chkIncludeSubFolders)
        Me.Controls.Add(Me.chkDeleteWhenDone)
        Me.Controls.Add(Me.lblFolderExist)
        Me.Controls.Add(Me.txtFileSpec)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.txtDir)
        Me.Controls.Add(Me.lblFolderName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddSource"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MultiCopy -- Add A Source"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblFolderName As Label
    Friend WithEvents txtDir As TextBox
    Friend WithEvents lblFileName As Label
    Friend WithEvents txtFileSpec As TextBox
    Friend WithEvents lblFolderExist As Label
    Friend WithEvents chkDeleteWhenDone As CheckBox
    Friend WithEvents chkIncludeSubFolders As CheckBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents chkUseDirName As CheckBox
End Class
