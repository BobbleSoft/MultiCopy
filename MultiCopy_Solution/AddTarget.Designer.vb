<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddTarget
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
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblFolderExist = New System.Windows.Forms.Label()
        Me.txtDir = New System.Windows.Forms.TextBox()
        Me.lblFolderName = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
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
        'lblFolderExist
        '
        Me.lblFolderExist.AutoSize = True
        Me.lblFolderExist.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolderExist.Location = New System.Drawing.Point(149, 36)
        Me.lblFolderExist.Name = "lblFolderExist"
        Me.lblFolderExist.Size = New System.Drawing.Size(111, 14)
        Me.lblFolderExist.TabIndex = 14
        Me.lblFolderExist.Text = "(Folder does not exist)"
        '
        'txtDir
        '
        Me.txtDir.Location = New System.Drawing.Point(149, 13)
        Me.txtDir.Name = "txtDir"
        Me.txtDir.Size = New System.Drawing.Size(364, 20)
        Me.txtDir.TabIndex = 1
        '
        'lblFolderName
        '
        Me.lblFolderName.AutoSize = True
        Me.lblFolderName.Location = New System.Drawing.Point(13, 13)
        Me.lblFolderName.Name = "lblFolderName"
        Me.lblFolderName.Size = New System.Drawing.Size(118, 13)
        Me.lblFolderName.TabIndex = 12
        Me.lblFolderName.Text = "Folder name to copy to:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(650, 57)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(650, 27)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "O&K"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'AddTarget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 100)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblFolderExist)
        Me.Controls.Add(Me.txtDir)
        Me.Controls.Add(Me.lblFolderName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddTarget"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AddTarget"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBrowse As Button
    Friend WithEvents lblFolderExist As Label
    Friend WithEvents txtDir As TextBox
    Friend WithEvents lblFolderName As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
End Class
