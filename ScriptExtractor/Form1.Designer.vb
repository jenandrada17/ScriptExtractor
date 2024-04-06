<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.AppProgressBar = New System.Windows.Forms.ProgressBar()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnBrowseData = New System.Windows.Forms.Button()
        Me.fbdBackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.sfdPath = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'AppProgressBar
        '
        Me.AppProgressBar.Location = New System.Drawing.Point(30, 385)
        Me.AppProgressBar.Maximum = 1000
        Me.AppProgressBar.Name = "AppProgressBar"
        Me.AppProgressBar.Size = New System.Drawing.Size(602, 34)
        Me.AppProgressBar.TabIndex = 24
        '
        'txtQuery
        '
        Me.txtQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuery.Location = New System.Drawing.Point(30, 91)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.Size = New System.Drawing.Size(681, 259)
        Me.txtQuery.TabIndex = 23
        '
        'btnExtract
        '
        Me.btnExtract.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExtract.Location = New System.Drawing.Point(646, 385)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(65, 34)
        Me.btnExtract.TabIndex = 22
        Me.btnExtract.Text = "OK"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPath.Location = New System.Drawing.Point(30, 32)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(638, 20)
        Me.txtPath.TabIndex = 21
        '
        'btnBrowseData
        '
        Me.btnBrowseData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseData.Location = New System.Drawing.Point(674, 31)
        Me.btnBrowseData.Name = "btnBrowseData"
        Me.btnBrowseData.Size = New System.Drawing.Size(40, 21)
        Me.btnBrowseData.TabIndex = 20
        Me.btnBrowseData.Text = "..."
        Me.btnBrowseData.UseVisualStyleBackColor = True
        '
        'fbdBackup
        '
        Me.fbdBackup.SelectedPath = "C:\"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 450)
        Me.Controls.Add(Me.AppProgressBar)
        Me.Controls.Add(Me.txtQuery)
        Me.Controls.Add(Me.btnExtract)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.btnBrowseData)
        Me.Name = "Form1"
        Me.Text = "Script Extractor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AppProgressBar As ProgressBar
    Friend WithEvents txtQuery As TextBox
    Friend WithEvents btnExtract As Button
    Friend WithEvents txtPath As TextBox
    Friend WithEvents btnBrowseData As Button
    Friend WithEvents fbdBackup As FolderBrowserDialog
    Friend WithEvents sfdPath As SaveFileDialog
End Class
