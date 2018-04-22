<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CopyItems
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
        Me.btnGo = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.lvActivity = New System.Windows.Forms.ListView()
        Me.colhdrAction = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colhdrSource = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colhdrFileSpec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colhdrTarget = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colhdrResult = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'btnGo
        '
        Me.btnGo.Enabled = False
        Me.btnGo.Location = New System.Drawing.Point(655, 13)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 0
        Me.btnGo.Text = "&Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(654, 43)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "&Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'lvActivity
        '
        Me.lvActivity.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvActivity.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colhdrAction, Me.colhdrSource, Me.colhdrFileSpec, Me.colhdrTarget, Me.colhdrResult})
        Me.lvActivity.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvActivity.FullRowSelect = True
        Me.lvActivity.GridLines = True
        Me.lvActivity.HideSelection = False
        Me.lvActivity.Location = New System.Drawing.Point(13, 13)
        Me.lvActivity.MultiSelect = False
        Me.lvActivity.Name = "lvActivity"
        Me.lvActivity.Size = New System.Drawing.Size(623, 119)
        Me.lvActivity.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvActivity.TabIndex = 2
        Me.lvActivity.UseCompatibleStateImageBehavior = False
        Me.lvActivity.View = System.Windows.Forms.View.Details
        '
        'colhdrAction
        '
        Me.colhdrAction.Text = "Action"
        Me.colhdrAction.Width = 50
        '
        'colhdrSource
        '
        Me.colhdrSource.Text = "Source Path"
        Me.colhdrSource.Width = 220
        '
        'colhdrFileSpec
        '
        Me.colhdrFileSpec.Text = "FileName"
        '
        'colhdrTarget
        '
        Me.colhdrTarget.Text = "Target Path"
        Me.colhdrTarget.Width = 220
        '
        'colhdrResult
        '
        Me.colhdrResult.Text = "Result"
        '
        'CopyItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 144)
        Me.Controls.Add(Me.lvActivity)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnGo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(758, 183)
        Me.Name = "CopyItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Analyzing..."
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnGo As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents lvActivity As ListView
    Friend WithEvents colhdrAction As ColumnHeader
    Friend WithEvents colhdrSource As ColumnHeader
    Friend WithEvents colhdrTarget As ColumnHeader
    Friend WithEvents colhdrResult As ColumnHeader
    Friend WithEvents colhdrFileSpec As ColumnHeader
End Class
