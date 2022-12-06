<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNotepad
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
        Me.TextBoxEditor = New System.Windows.Forms.TextBox()
        Me.CommandDone = New System.Windows.Forms.Button()
        Me.CommandCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBoxEditor
        '
        Me.TextBoxEditor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxEditor.Location = New System.Drawing.Point(12, 12)
        Me.TextBoxEditor.Multiline = True
        Me.TextBoxEditor.Name = "TextBoxEditor"
        Me.TextBoxEditor.Size = New System.Drawing.Size(576, 294)
        Me.TextBoxEditor.TabIndex = 0
        '
        'CommandDone
        '
        Me.CommandDone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CommandDone.Location = New System.Drawing.Point(352, 312)
        Me.CommandDone.Name = "CommandDone"
        Me.CommandDone.Size = New System.Drawing.Size(115, 23)
        Me.CommandDone.TabIndex = 1
        Me.CommandDone.Text = "Done"
        Me.CommandDone.UseVisualStyleBackColor = True
        '
        'CommandCancel
        '
        Me.CommandCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CommandCancel.Location = New System.Drawing.Point(473, 312)
        Me.CommandCancel.Name = "CommandCancel"
        Me.CommandCancel.Size = New System.Drawing.Size(115, 23)
        Me.CommandCancel.TabIndex = 2
        Me.CommandCancel.Text = "Cancel"
        Me.CommandCancel.UseVisualStyleBackColor = True
        '
        'FormNotepad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 341)
        Me.Controls.Add(Me.CommandCancel)
        Me.Controls.Add(Me.CommandDone)
        Me.Controls.Add(Me.TextBoxEditor)
        Me.Name = "FormNotepad"
        Me.Text = "Notepad Editor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxEditor As Windows.Forms.TextBox
    Friend WithEvents CommandDone As Windows.Forms.Button
    Friend WithEvents CommandCancel As Windows.Forms.Button
End Class
