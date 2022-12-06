<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCustomNote
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
        Me.TextBoxCustomNote = New System.Windows.Forms.TextBox()
        Me.CommandCancel = New System.Windows.Forms.Button()
        Me.CommandDone = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBoxCustomNote
        '
        Me.TextBoxCustomNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCustomNote.Location = New System.Drawing.Point(12, 12)
        Me.TextBoxCustomNote.Name = "TextBoxCustomNote"
        Me.TextBoxCustomNote.Size = New System.Drawing.Size(512, 20)
        Me.TextBoxCustomNote.TabIndex = 0
        '
        'CommandCancel
        '
        Me.CommandCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CommandCancel.Location = New System.Drawing.Point(409, 44)
        Me.CommandCancel.Name = "CommandCancel"
        Me.CommandCancel.Size = New System.Drawing.Size(115, 23)
        Me.CommandCancel.TabIndex = 4
        Me.CommandCancel.Text = "Cancel"
        Me.CommandCancel.UseVisualStyleBackColor = True
        '
        'CommandDone
        '
        Me.CommandDone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CommandDone.Location = New System.Drawing.Point(288, 44)
        Me.CommandDone.Name = "CommandDone"
        Me.CommandDone.Size = New System.Drawing.Size(115, 23)
        Me.CommandDone.TabIndex = 3
        Me.CommandDone.Text = "Done"
        Me.CommandDone.UseVisualStyleBackColor = True
        '
        'FormCustomNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 79)
        Me.Controls.Add(Me.CommandCancel)
        Me.Controls.Add(Me.CommandDone)
        Me.Controls.Add(Me.TextBoxCustomNote)
        Me.Name = "FormCustomNote"
        Me.Text = "Custom Note"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxCustomNote As Windows.Forms.TextBox
    Friend WithEvents CommandCancel As Windows.Forms.Button
    Friend WithEvents CommandDone As Windows.Forms.Button
End Class
