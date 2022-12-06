<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NotesForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotesForm))
        Me.CommandAddNote = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ListBoxType = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ListBoxNOTES = New System.Windows.Forms.ListBox()
        Me.CommandNotepad = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboTitle = New System.Windows.Forms.ComboBox()
        Me.CheckHighlightTitle = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ListBoxBuild = New System.Windows.Forms.ListView()
        Me.FlagNote = New System.Windows.Forms.CheckBox()
        Me.TextBoxWidth = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CommandEditNote = New System.Windows.Forms.Button()
        Me.CommandClearAll = New System.Windows.Forms.Button()
        Me.CommandRemove = New System.Windows.Forms.Button()
        Me.CommandMoveDown = New System.Windows.Forms.Button()
        Me.CommandMoveUp = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FrameNoteNumbering = New System.Windows.Forms.GroupBox()
        Me.CheckBoxNoteNumberSkip = New System.Windows.Forms.CheckBox()
        Me.CheckboxNumberBottomUp = New System.Windows.Forms.CheckBox()
        Me.CommandNoNotes = New System.Windows.Forms.Button()
        Me.CommandAllNotes = New System.Windows.Forms.Button()
        Me.CommandNoteNumber = New System.Windows.Forms.Button()
        Me.CommandAddNotes = New System.Windows.Forms.Button()
        Me.CommandAbout = New System.Windows.Forms.Button()
        Me.CommandCancel = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxUpperCase = New System.Windows.Forms.CheckBox()
        Me.CheckLineSpace = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CommandNotesCfg = New System.Windows.Forms.Button()
        Me.NotesCfgPath = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.FrameNoteNumbering.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'CommandAddNote
        '
        Me.CommandAddNote.Location = New System.Drawing.Point(12, 117)
        Me.CommandAddNote.Name = "CommandAddNote"
        Me.CommandAddNote.Size = New System.Drawing.Size(188, 23)
        Me.CommandAddNote.TabIndex = 0
        Me.CommandAddNote.Text = "Add Custom Note"
        Me.CommandAddNote.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ListBoxType)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(188, 99)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Notes List:"
        '
        'ListBoxType
        '
        Me.ListBoxType.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ListBoxType.FormattingEnabled = True
        Me.ListBoxType.Location = New System.Drawing.Point(6, 19)
        Me.ListBoxType.Name = "ListBoxType"
        Me.ListBoxType.Size = New System.Drawing.Size(176, 69)
        Me.ListBoxType.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.ListBoxNOTES)
        Me.GroupBox2.Location = New System.Drawing.Point(206, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(466, 134)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Notes:"
        '
        'ListBoxNOTES
        '
        Me.ListBoxNOTES.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ListBoxNOTES.FormattingEnabled = True
        Me.ListBoxNOTES.Location = New System.Drawing.Point(6, 19)
        Me.ListBoxNOTES.Name = "ListBoxNOTES"
        Me.ListBoxNOTES.Size = New System.Drawing.Size(450, 108)
        Me.ListBoxNOTES.TabIndex = 0
        '
        'CommandNotepad
        '
        Me.CommandNotepad.Location = New System.Drawing.Point(12, 143)
        Me.CommandNotepad.Name = "CommandNotepad"
        Me.CommandNotepad.Size = New System.Drawing.Size(188, 23)
        Me.CommandNotepad.TabIndex = 3
        Me.CommandNotepad.Text = "Notepad Style Editor"
        Me.CommandNotepad.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(206, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Title:"
        '
        'ComboTitle
        '
        Me.ComboTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboTitle.FormattingEnabled = True
        Me.ComboTitle.Location = New System.Drawing.Point(242, 149)
        Me.ComboTitle.Name = "ComboTitle"
        Me.ComboTitle.Size = New System.Drawing.Size(299, 21)
        Me.ComboTitle.TabIndex = 5
        '
        'CheckHighlightTitle
        '
        Me.CheckHighlightTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckHighlightTitle.AutoSize = True
        Me.CheckHighlightTitle.Location = New System.Drawing.Point(547, 152)
        Me.CheckHighlightTitle.Name = "CheckHighlightTitle"
        Me.CheckHighlightTitle.Size = New System.Drawing.Size(115, 17)
        Me.CheckHighlightTitle.TabIndex = 6
        Me.CheckHighlightTitle.Text = "Highlight notes title"
        Me.CheckHighlightTitle.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.ListBoxBuild)
        Me.GroupBox3.Controls.Add(Me.FlagNote)
        Me.GroupBox3.Controls.Add(Me.TextBoxWidth)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.CommandEditNote)
        Me.GroupBox3.Controls.Add(Me.CommandClearAll)
        Me.GroupBox3.Controls.Add(Me.CommandRemove)
        Me.GroupBox3.Controls.Add(Me.CommandMoveDown)
        Me.GroupBox3.Controls.Add(Me.CommandMoveUp)
        Me.GroupBox3.Location = New System.Drawing.Point(206, 176)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(466, 175)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Note Builder:"
        '
        'ListBoxBuild
        '
        Me.ListBoxBuild.FullRowSelect = True
        Me.ListBoxBuild.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListBoxBuild.HideSelection = False
        Me.ListBoxBuild.Location = New System.Drawing.Point(102, 19)
        Me.ListBoxBuild.MultiSelect = False
        Me.ListBoxBuild.Name = "ListBoxBuild"
        Me.ListBoxBuild.Size = New System.Drawing.Size(354, 123)
        Me.ListBoxBuild.TabIndex = 9
        Me.ListBoxBuild.UseCompatibleStateImageBehavior = False
        Me.ListBoxBuild.View = System.Windows.Forms.View.Details
        '
        'FlagNote
        '
        Me.FlagNote.AutoSize = True
        Me.FlagNote.Location = New System.Drawing.Point(102, 148)
        Me.FlagNote.Name = "FlagNote"
        Me.FlagNote.Size = New System.Drawing.Size(72, 17)
        Me.FlagNote.TabIndex = 8
        Me.FlagNote.Text = "Flag Note"
        Me.FlagNote.UseVisualStyleBackColor = True
        '
        'TextBoxWidth
        '
        Me.TextBoxWidth.Location = New System.Drawing.Point(51, 144)
        Me.TextBoxWidth.Name = "TextBoxWidth"
        Me.TextBoxWidth.Size = New System.Drawing.Size(45, 20)
        Me.TextBoxWidth.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Width"
        '
        'CommandEditNote
        '
        Me.CommandEditNote.Location = New System.Drawing.Point(6, 115)
        Me.CommandEditNote.Name = "CommandEditNote"
        Me.CommandEditNote.Size = New System.Drawing.Size(90, 23)
        Me.CommandEditNote.TabIndex = 4
        Me.CommandEditNote.Text = "Edit Note"
        Me.CommandEditNote.UseVisualStyleBackColor = True
        '
        'CommandClearAll
        '
        Me.CommandClearAll.Location = New System.Drawing.Point(6, 91)
        Me.CommandClearAll.Name = "CommandClearAll"
        Me.CommandClearAll.Size = New System.Drawing.Size(90, 23)
        Me.CommandClearAll.TabIndex = 3
        Me.CommandClearAll.Text = "Clear All"
        Me.CommandClearAll.UseVisualStyleBackColor = True
        '
        'CommandRemove
        '
        Me.CommandRemove.Location = New System.Drawing.Point(6, 67)
        Me.CommandRemove.Name = "CommandRemove"
        Me.CommandRemove.Size = New System.Drawing.Size(90, 23)
        Me.CommandRemove.TabIndex = 2
        Me.CommandRemove.Text = "Remove Note"
        Me.CommandRemove.UseVisualStyleBackColor = True
        '
        'CommandMoveDown
        '
        Me.CommandMoveDown.Location = New System.Drawing.Point(6, 43)
        Me.CommandMoveDown.Name = "CommandMoveDown"
        Me.CommandMoveDown.Size = New System.Drawing.Size(90, 23)
        Me.CommandMoveDown.TabIndex = 1
        Me.CommandMoveDown.Text = "Move Down"
        Me.CommandMoveDown.UseVisualStyleBackColor = True
        '
        'CommandMoveUp
        '
        Me.CommandMoveUp.Location = New System.Drawing.Point(6, 19)
        Me.CommandMoveUp.Name = "CommandMoveUp"
        Me.CommandMoveUp.Size = New System.Drawing.Size(90, 23)
        Me.CommandMoveUp.TabIndex = 0
        Me.CommandMoveUp.Text = "Move Up"
        Me.CommandMoveUp.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 176)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(188, 266)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Instructions:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 221)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'FrameNoteNumbering
        '
        Me.FrameNoteNumbering.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FrameNoteNumbering.Controls.Add(Me.CheckBoxNoteNumberSkip)
        Me.FrameNoteNumbering.Controls.Add(Me.CheckboxNumberBottomUp)
        Me.FrameNoteNumbering.Controls.Add(Me.CommandNoNotes)
        Me.FrameNoteNumbering.Controls.Add(Me.CommandAllNotes)
        Me.FrameNoteNumbering.Controls.Add(Me.CommandNoteNumber)
        Me.FrameNoteNumbering.Location = New System.Drawing.Point(206, 357)
        Me.FrameNoteNumbering.Name = "FrameNoteNumbering"
        Me.FrameNoteNumbering.Size = New System.Drawing.Size(466, 85)
        Me.FrameNoteNumbering.TabIndex = 8
        Me.FrameNoteNumbering.TabStop = False
        Me.FrameNoteNumbering.Text = "Note Builder:"
        '
        'CheckBoxNoteNumberSkip
        '
        Me.CheckBoxNoteNumberSkip.AutoSize = True
        Me.CheckBoxNoteNumberSkip.Location = New System.Drawing.Point(248, 47)
        Me.CheckBoxNoteNumberSkip.Name = "CheckBoxNoteNumberSkip"
        Me.CheckBoxNoteNumberSkip.Size = New System.Drawing.Size(214, 17)
        Me.CheckBoxNoteNumberSkip.TabIndex = 10
        Me.CheckBoxNoteNumberSkip.Text = "Skip numbers for notes without numbers"
        Me.CheckBoxNoteNumberSkip.UseVisualStyleBackColor = True
        '
        'CheckboxNumberBottomUp
        '
        Me.CheckboxNumberBottomUp.AutoSize = True
        Me.CheckboxNumberBottomUp.Location = New System.Drawing.Point(248, 23)
        Me.CheckboxNumberBottomUp.Name = "CheckboxNumberBottomUp"
        Me.CheckboxNumberBottomUp.Size = New System.Drawing.Size(183, 17)
        Me.CheckboxNumberBottomUp.TabIndex = 9
        Me.CheckboxNumberBottomUp.Text = "Number notes from the bottom up"
        Me.CheckboxNumberBottomUp.UseVisualStyleBackColor = True
        '
        'CommandNoNotes
        '
        Me.CommandNoNotes.Location = New System.Drawing.Point(124, 43)
        Me.CommandNoNotes.Name = "CommandNoNotes"
        Me.CommandNoNotes.Size = New System.Drawing.Size(117, 23)
        Me.CommandNoNotes.TabIndex = 7
        Me.CommandNoNotes.Text = "No Note Numbers"
        Me.CommandNoNotes.UseVisualStyleBackColor = True
        '
        'CommandAllNotes
        '
        Me.CommandAllNotes.Location = New System.Drawing.Point(124, 19)
        Me.CommandAllNotes.Name = "CommandAllNotes"
        Me.CommandAllNotes.Size = New System.Drawing.Size(117, 23)
        Me.CommandAllNotes.TabIndex = 6
        Me.CommandAllNotes.Text = "Number All Notes"
        Me.CommandAllNotes.UseVisualStyleBackColor = True
        '
        'CommandNoteNumber
        '
        Me.CommandNoteNumber.Location = New System.Drawing.Point(5, 19)
        Me.CommandNoteNumber.Name = "CommandNoteNumber"
        Me.CommandNoteNumber.Size = New System.Drawing.Size(117, 23)
        Me.CommandNoteNumber.TabIndex = 5
        Me.CommandNoteNumber.Text = "Edit Note Numbers"
        Me.CommandNoteNumber.UseVisualStyleBackColor = True
        '
        'CommandAddNotes
        '
        Me.CommandAddNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CommandAddNotes.Location = New System.Drawing.Point(398, 513)
        Me.CommandAddNotes.Name = "CommandAddNotes"
        Me.CommandAddNotes.Size = New System.Drawing.Size(90, 23)
        Me.CommandAddNotes.TabIndex = 9
        Me.CommandAddNotes.Text = "Insert Notes"
        Me.CommandAddNotes.UseVisualStyleBackColor = True
        '
        'CommandAbout
        '
        Me.CommandAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CommandAbout.Location = New System.Drawing.Point(490, 513)
        Me.CommandAbout.Name = "CommandAbout"
        Me.CommandAbout.Size = New System.Drawing.Size(90, 23)
        Me.CommandAbout.TabIndex = 10
        Me.CommandAbout.Text = "About"
        Me.CommandAbout.UseVisualStyleBackColor = True
        '
        'CommandCancel
        '
        Me.CommandCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CommandCancel.Location = New System.Drawing.Point(582, 513)
        Me.CommandCancel.Name = "CommandCancel"
        Me.CommandCancel.Size = New System.Drawing.Size(90, 23)
        Me.CommandCancel.TabIndex = 11
        Me.CommandCancel.Text = "Cancel"
        Me.CommandCancel.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.CheckBoxUpperCase)
        Me.GroupBox6.Controls.Add(Me.CheckLineSpace)
        Me.GroupBox6.Location = New System.Drawing.Point(206, 448)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(466, 52)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Additional Options:"
        '
        'CheckBoxUpperCase
        '
        Me.CheckBoxUpperCase.AutoSize = True
        Me.CheckBoxUpperCase.Location = New System.Drawing.Point(248, 22)
        Me.CheckBoxUpperCase.Name = "CheckBoxUpperCase"
        Me.CheckBoxUpperCase.Size = New System.Drawing.Size(183, 17)
        Me.CheckBoxUpperCase.TabIndex = 11
        Me.CheckBoxUpperCase.Text = "Apply notes in UPPER CASE text"
        Me.CheckBoxUpperCase.UseVisualStyleBackColor = True
        '
        'CheckLineSpace
        '
        Me.CheckLineSpace.AutoSize = True
        Me.CheckLineSpace.Location = New System.Drawing.Point(9, 22)
        Me.CheckLineSpace.Name = "CheckLineSpace"
        Me.CheckLineSpace.Size = New System.Drawing.Size(177, 17)
        Me.CheckLineSpace.TabIndex = 10
        Me.CheckLineSpace.Text = "Add line spacing between notes"
        Me.CheckLineSpace.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CommandNotesCfg)
        Me.GroupBox5.Controls.Add(Me.NotesCfgPath)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 448)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(188, 52)
        Me.GroupBox5.TabIndex = 12
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Notes Config Location"
        '
        'CommandNotesCfg
        '
        Me.CommandNotesCfg.Location = New System.Drawing.Point(153, 18)
        Me.CommandNotesCfg.Name = "CommandNotesCfg"
        Me.CommandNotesCfg.Size = New System.Drawing.Size(28, 23)
        Me.CommandNotesCfg.TabIndex = 1
        Me.CommandNotesCfg.Text = "..."
        Me.CommandNotesCfg.UseVisualStyleBackColor = True
        '
        'NotesCfgPath
        '
        Me.NotesCfgPath.Location = New System.Drawing.Point(6, 19)
        Me.NotesCfgPath.Name = "NotesCfgPath"
        Me.NotesCfgPath.Size = New System.Drawing.Size(141, 20)
        Me.NotesCfgPath.TabIndex = 0
        '
        'NotesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 548)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.CommandCancel)
        Me.Controls.Add(Me.CommandAbout)
        Me.Controls.Add(Me.CommandAddNotes)
        Me.Controls.Add(Me.FrameNoteNumbering)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.CheckHighlightTitle)
        Me.Controls.Add(Me.ComboTitle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CommandNotepad)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CommandAddNote)
        Me.MinimumSize = New System.Drawing.Size(700, 575)
        Me.Name = "NotesForm"
        Me.Text = "Draftsight Notes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.FrameNoteNumbering.ResumeLayout(False)
        Me.FrameNoteNumbering.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CommandAddNote As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents CommandNotepad As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents ComboTitle As Windows.Forms.ComboBox
    Friend WithEvents CheckHighlightTitle As Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents CommandEditNote As Windows.Forms.Button
    Friend WithEvents CommandClearAll As Windows.Forms.Button
    Friend WithEvents CommandRemove As Windows.Forms.Button
    Friend WithEvents CommandMoveDown As Windows.Forms.Button
    Friend WithEvents CommandMoveUp As Windows.Forms.Button
    Friend WithEvents GroupBox4 As Windows.Forms.GroupBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents FrameNoteNumbering As Windows.Forms.GroupBox
    Friend WithEvents FlagNote As Windows.Forms.CheckBox
    Friend WithEvents TextBoxWidth As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents CheckBoxNoteNumberSkip As Windows.Forms.CheckBox
    Friend WithEvents CheckboxNumberBottomUp As Windows.Forms.CheckBox
    Friend WithEvents CommandNoNotes As Windows.Forms.Button
    Friend WithEvents CommandAllNotes As Windows.Forms.Button
    Friend WithEvents CommandNoteNumber As Windows.Forms.Button
    Friend WithEvents CommandAddNotes As Windows.Forms.Button
    Friend WithEvents CommandAbout As Windows.Forms.Button
    Friend WithEvents CommandCancel As Windows.Forms.Button
    Friend WithEvents GroupBox6 As Windows.Forms.GroupBox
    Friend WithEvents CheckBoxUpperCase As Windows.Forms.CheckBox
    Friend WithEvents CheckLineSpace As Windows.Forms.CheckBox
    Friend WithEvents ListBoxNOTES As Windows.Forms.ListBox
    Friend WithEvents ListBoxType As Windows.Forms.ListBox
    Friend WithEvents ListBoxBuild As Windows.Forms.ListView
    Friend WithEvents GroupBox5 As Windows.Forms.GroupBox
    Friend WithEvents CommandNotesCfg As Windows.Forms.Button
    Friend WithEvents NotesCfgPath As Windows.Forms.TextBox
End Class
