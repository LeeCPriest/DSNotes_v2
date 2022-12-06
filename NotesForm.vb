Imports System.IO

Public Class NotesForm

    ' ------------------------------------------------------------------------------
    ' This userform allow user to create custom notes to add to drawing.
    ' Permits users to add/edit/remove notes in note builder.
    ' When user clicks "Apply", the NoteText property is set
    ' to the user selected note text, to be used by 
    ' -----------------------------------------------------------------------------

    Public boolstatus As Boolean
    Public longstatus As Long
    Public SelMgr As Object
    Public PickPt As Object 'was variant
    Public CustomNote As String

    Private dsApp As Object

    Private _noteText As String
    Public Property NoteText() As String
        Get
            Return _noteText
        End Get
        Set(ByVal value As String)
            _noteText = value
        End Set
    End Property

    Public Sub Init(ByVal dsAppObj)
        dsApp = dsAppObj
    End Sub

    Dim Source As String
    Dim AllowCustomTitle As Boolean
    Dim NoteNumberChange As Boolean
    Dim BuildBoxHeight As Double
    Const swDetailingNoteTextFormat = 0
    Dim PaddedSpaces As String
    Dim NoteDividerSym As String
    Const TempFlag = "<F>"

    Private Sub NotesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Show program version
        PaddedSpaces = "    "
        ComboTitle.Items.Add("NOTES:")
        ComboTitle.SelectedIndex = 0
        ComboTitle.Enabled = False
        'ComboTitle.BackColor = vbButtonFace
        CheckHighlightTitle.Checked = False
        CheckLineSpace.Checked = False
        AllowCustomTitle = False
        ' Clear group list box and read group names from external file
        ListBoxType.Items.Clear()
        ' Read group names and setup group list box.
        NotesCfgPath.Text = My.Settings.NotesConfigPath

        If IO.File.Exists(NotesCfgPath.Text) = True Then                 ' Does source file exist?
            ReadSource()                                       ' Yes, read file
            ListBoxType.SelectedIndex = 0
        Else
            SetDefaults()                                      ' No, use macro defaults
        End If
        If AllowCustomTitle = True Then
            ComboTitle.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDown 'was fmStyleDropDownCombo
        Else
            ComboTitle.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList 'was fmStyleDropDownList
            If ComboTitle.Items.Count = 1 Then
                ComboTitle.Enabled = False
                'ComboTitle.BackColor = vbButtonFace
            End If
        End If
        ControlSetup()
        ListBoxBuild.Items.Clear()
        BuildBoxHeight = ListBoxBuild.Height
        CommandAllNotes.Enabled = False
        CommandNoNotes.Enabled = False
        ListBoxBuild.MultiSelect = False
        ListBoxBuild.Columns.Add("Checked") ' column 0
        ListBoxBuild.Columns.Add("Note") ' column 1
        ListBoxBuild.Columns.Add("Flag") ' column 2
        ListBoxBuild.Columns(0).Width = 1
        ListBoxBuild.Columns(1).Width = 294
        ListBoxBuild.Columns(2).Width = 40
    End Sub

    Private Sub CommandEditNote_Click() Handles CommandEditNote.Click

        Dim fCustomNote As New FormCustomNote
        fCustomNote.CustomNote = ListBoxBuild.SelectedItems(0).SubItems(1).Text
        fCustomNote.ShowDialog()

        If fCustomNote.CustomNote <> "" Then
            ListBoxBuild.SelectedItems(0).SubItems(1).Text = fCustomNote.CustomNote
        End If

        fCustomNote.Close()

    End Sub

    Private Sub CommandAddNote_Click() Handles CommandAddNote.Click

        Dim fCustomNote As New FormCustomNote
        fCustomNote.ShowDialog()

        If fCustomNote.CustomNote <> "" Then

            Dim newNote As Windows.Forms.ListViewItem = New Windows.Forms.ListViewItem({"", fCustomNote.CustomNote, ""})

            ListBoxBuild.Items.Add(newNote)

        End If

    End Sub


    Private Sub CommandNotePad_Click() Handles CommandNotepad.Click

        Dim fNotepad As New FormNotepad
        Dim notesArray(ListBoxBuild.Items.Count) As String

        For x = 0 To ListBoxBuild.Items.Count - 1
            notesArray(x) = ListBoxBuild.Items(x).SubItems(1).Text
        Next x
        fNotepad.NotepadNote = notesArray
        fNotepad.ShowDialog()

        ListBoxBuild.Items.Clear()

        For x = 0 To UBound(fNotepad.NotepadNote)
            Dim newNote As Windows.Forms.ListViewItem = New Windows.Forms.ListViewItem({"", fNotepad.NotepadNote(x), ""})
            ListBoxBuild.Items.Add(newNote)
        Next

    End Sub

    Private Sub FlagNote_Click() Handles FlagNote.Click

        If ListBoxBuild.SelectedItems.Count > 0 Then
            If FlagNote.Checked = True Then
                ListBoxBuild.SelectedItems(0).SubItems(2).Text = TempFlag
            Else
                ListBoxBuild.SelectedItems(0).SubItems(2).Text = ""
            End If
        End If

    End Sub

    Private Sub ListBoxBuild_DoubleClick(sender As Object, e As EventArgs)
        If (ListBoxBuild.Items.Count > 0) And (ListBoxBuild.SelectedItems.Count > 0) Then

            CustomNote = ListBoxBuild.SelectedItems(0).SubItems(1).Text

            Dim fCustomNote As New FormCustomNote
            fCustomNote.Show()

            If CustomNote <> "" Then
                ListBoxBuild.SelectedItems(0).SubItems(1).Text = CustomNote
            End If
        End If
    End Sub

    Private Sub ListBoxType_Change() Handles ListBoxType.SelectedIndexChanged
        ListBoxNOTES.Items.Clear()

        Dim streamR As New StreamReader(NotesCfgPath.Text)              ' Open file for input.
        Dim textLine As String
        ' Read group specific notes.
        Do While Not streamR.EndOfStream                      ' Loop until end of file.
            textLine = streamR.ReadLine                       ' Read data into variable.
            If UCase(textLine) = "[" + (UCase(ListBoxType.SelectedItem)) + "]" _
                                 Then                   ' Find specific group
                Do While Not streamR.EndOfStream                    ' Loop until end of file.
                    textLine = streamR.ReadLine                 ' Read data into material variable.
                    If textLine <> "" Then
                        ListBoxNOTES.Items.Add(textLine)     ' Add item to list
                    Else
                        GoTo EndReadNotes1
                    End If
                Loop
            End If
        Loop
EndReadNotes1:
        streamR.Close()
    End Sub

    Private Sub ListBoxNOTES_Click() Handles ListBoxNOTES.SelectedIndexChanged

        Dim newNote As Windows.Forms.ListViewItem = New Windows.Forms.ListViewItem({"", ListBoxNOTES.SelectedItem, ""})

        ListBoxBuild.Items.Add(newNote)

        ControlSetup()
    End Sub

    Private Sub ListBoxBuild_Click() Handles ListBoxBuild.SelectedIndexChanged
        ControlSetup()
        If ListBoxBuild.SelectedItems.Count > 0 Then
            If ListBoxBuild.SelectedIndices(0) > 0 Then CommandMoveUp.Enabled = True
            If ListBoxBuild.SelectedIndices(0) < ListBoxBuild.Items.Count - 1 Then CommandMoveDown.Enabled = True
            CommandRemove.Enabled = True
            CommandEditNote.Enabled = True
            NoteNumberControls()
        End If
    End Sub

    Private Sub ListBoxBuild_StyleChanged() Handles ListBoxBuild.StyleChanged '??? is this the right event
        If ListBoxBuild.MultiSelect = True Then
            UpdateNumbers()
        End If
    End Sub

    Private Sub ListBoxBuild_TextChanged() Handles ListBoxBuild.TextChanged '???  is this the right event
        For i = 0 To ListBoxBuild.Items.Count - 1
            If ListBoxBuild.SelectedIndices(i) = True Then
                If ListBoxBuild.Items(i).SubItems(2).Text = TempFlag Then
                    FlagNote.Checked = True
                Else
                    FlagNote.Checked = False
                End If
            End If
        Next

        ListBoxBuild.Height = 90
    End Sub

    Private Sub CommandMoveUp_Click() Handles CommandMoveUp.Click
        If ListBoxBuild.Items.Count > 1 Then
            Dim temp1 As String, temp2 As String
            Dim selIndex As Integer = ListBoxBuild.SelectedIndices(0)

            temp1 = ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0)).SubItems(1).Text
            temp2 = ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0)).SubItems(2).Text
            ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0)).SubItems(1).Text = ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0) - 1).SubItems(1).Text
            ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0)).SubItems(2).Text = ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0) - 1).SubItems(2).Text
            ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0) - 1).SubItems(1).Text = temp1
            ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0) - 1).SubItems(2).Text = temp2
            ListBoxBuild.SelectedIndices.Clear()
            ListBoxBuild.Items(selIndex - 1).Selected = True
        End If
    End Sub

    Private Sub CommandMoveDown_Click() Handles CommandMoveDown.Click
        If ListBoxBuild.Items.Count > 1 Then
            Dim temp1 As String, temp2 As String
            Dim selIndex As Integer = ListBoxBuild.SelectedIndices(0)

            temp1 = ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0)).SubItems(1).Text
            temp2 = ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0)).SubItems(2).Text
            ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0)).SubItems(1).Text = ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0) + 1).SubItems(1).Text
            ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0)).SubItems(2).Text = ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0) + 1).SubItems(2).Text
            ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0) + 1).SubItems(1).Text = temp1
            ListBoxBuild.Items(ListBoxBuild.SelectedIndices(0) + 1).SubItems(2).Text = temp2
            ListBoxBuild.SelectedIndices.Clear()
            ListBoxBuild.Items(selIndex + 1).Selected = True
        End If
    End Sub

    Private Sub CommandRemove_Click() Handles CommandRemove.Click
        'Ensure ListBox contains list items
        If ListBoxBuild.Items.Count > 0 Then
            Dim Position As Integer
            'If no selection, choose last list item.
            If ListBoxBuild.SelectedItems.Count = 0 Then
                ListBoxBuild.Items(ListBoxBuild.Items.Count - 1).Selected = True
            End If
            Position = ListBoxBuild.SelectedIndices(0)
            ListBoxBuild.Items.RemoveAt(ListBoxBuild.SelectedIndices(0))
            ListBoxBuild.SelectedIndices.Clear()
        End If
        ControlSetup()
    End Sub

    Private Sub CommandClearAll_Click() Handles CommandClearAll.Click
        ListBoxBuild.Items.Clear()
        ControlSetup()
    End Sub

    Private Sub CommandNoteNumber_Click() Handles CommandNoteNumber.Click
        ListBoxBuild.SelectedIndices.Clear()

        If ListBoxBuild.MultiSelect = False Then
            CommandMoveUp.Enabled = False
            CommandMoveDown.Enabled = False
            CommandRemove.Enabled = False
            CommandEditNote.Enabled = False
            CommandClearAll.Enabled = False
            ListBoxBuild.Columns(0).Width = 36
            ListBoxBuild.Columns(1).Width = 259
            ListBoxBuild.Columns(2).Width = 40
            'ListBoxBuild.SelectionMode = Windows.Forms.SelectionMode.MultiSimple 'was fmMultiSelectMulti
            'ListBoxBuild.ListStyle = fmListStyleOption
            ListBoxBuild.MultiSelect = True

            For x = 0 To ListBoxBuild.Items.Count - 1
                ListBoxBuild.Items(x).Selected = True
            Next x
            ListBoxType.Enabled = False
            'ListBoxType.ForeColor = vbGrayText
            ListBoxNOTES.Enabled = False
            'ListBoxNOTES.ForeColor = vbGrayText
            CommandNoteNumber.Text = "Add More Notes"
            CommandAllNotes.Enabled = True
            CommandNoNotes.Enabled = True
            UpdateNumbers()
            ListBoxBuild.Height = 90
        Else
            ListBoxBuild.Height = 90
            Dim Answer As MsgBoxResult
            Answer = MsgBox("Note numbering will be lost." & Chr(13) & Chr(13) & "Continue?", vbYesNo + vbExclamation, "Warning:")
            If Answer = vbYes Then
                CommandMoveUp.Enabled = True
                CommandMoveDown.Enabled = True
                CommandRemove.Enabled = True
                CommandEditNote.Enabled = True
                CommandClearAll.Enabled = True
                ListBoxBuild.Columns(0).Width = 1
                ListBoxBuild.Columns(1).Width = 294
                ListBoxBuild.Columns(2).Width = 40
                'ListBoxBuild.SelectionMode = Windows.Forms.SelectionMode.One  'was fmMultiSelectSingle
                'ListBoxBuild.ListStyle = fmListStylePlain
                ListBoxBuild.MultiSelect = False
                For x = 0 To ListBoxBuild.Items.Count - 1
                    ListBoxBuild.Items(x).Selected = False
                Next x
                ListBoxType.Enabled = True
                'ListBoxType.ForeColor = vbWindowText
                ListBoxNOTES.Enabled = True
                'ListBoxNOTES.ForeColor = vbWindowText
                CommandNoteNumber.Text = "Edit Note Numbers"
                CommandAllNotes.Enabled = False
                CommandNoNotes.Enabled = False
                ListBoxBuild.Height = 90
            End If
        End If
    End Sub

    Private Sub CommandAllNotes_Click() Handles CommandAllNotes.Click
        For x = 0 To ListBoxBuild.Items.Count - 1
            ListBoxBuild.Items(x).Selected = True
        Next x
    End Sub

    Private Sub CommandNoNotes_Click() Handles CommandNoNotes.Click
        For x = 0 To ListBoxBuild.Items.Count - 1
            ListBoxBuild.Items(x).Selected = False
        Next x
    End Sub

    Private Sub CheckBoxNumberBottomUp_Click()
        UpdateNumbers()
    End Sub

    Private Sub CheckBoxNoteNumberSkip_Click()
        UpdateNumbers()
    End Sub

    Private Sub UpdateNumbers()
        Dim Counter As Integer = 0
        Dim y As Integer

        For x = 0 To ListBoxBuild.Items.Count - 1
            Counter = Counter + 1
            If CheckboxNumberBottomUp.Checked = False Then
                y = x
            Else
                y = (ListBoxBuild.Items.Count - 1) - x
            End If

            If (ListBoxBuild.Items(y).Selected = True) Then

                If ListBoxBuild.Items(y).SubItems(2).Text = TempFlag And CommandNoteNumber.Text <> "Add More Notes" Then

                    ListBoxBuild.Items(y).SubItems(0).Text = "<S#-" & LTrim(Str(Counter)) & "> "

                Else
                    ListBoxBuild.Items(y).SubItems(0).Text = "  " & LTrim(Str(Counter)) & NoteDividerSym & PaddedSpaces
                End If


            Else
                ListBoxBuild.Items(y).SubItems(0).Text = PaddedSpaces
                If CheckBoxNoteNumberSkip.Checked = False Then
                    Counter = Counter - 1
                End If
            End If
        Next x
    End Sub

    Private Sub NoteNumberControls()
        CommandNoteNumber.Enabled = False
        CommandAllNotes.Enabled = False
        CommandNoNotes.Enabled = False
        CheckboxNumberBottomUp.Enabled = False
        CheckBoxNoteNumberSkip.Enabled = False
        FrameNoteNumbering.Enabled = False

        'The following has been disabled in v2.60
        If (NoteNumberChange = True) _
            And (ListBoxBuild.Items.Count > -1) Then
            CommandNoteNumber.Enabled = True
            CommandAllNotes.Enabled = True
            CommandNoNotes.Enabled = True
            CheckboxNumberBottomUp.Enabled = True
            CheckBoxNoteNumberSkip.Enabled = True
            FrameNoteNumbering.Enabled = True
        Else
        End If
    End Sub

    Private Sub CommandAddNotes_Click() Handles CommandAddNotes.Click
        'Set swSelMgr = 'Document.SelectionManager
        'Set swSelData = swSelMgr.CreateSelectData
        Dim textLine As String, tempText As String, tempText2 As String, lastSpace As String
        Dim returnText As String = ""

        If ListBoxBuild.Items.Count >= 1 Then
            'If CheckHighlightTitle.Checked = True Then
            '    returnText = "%%U" & UCase(ComboTitle.Text) & "%%U" + Strings.Chr(13) + Strings.Chr(10) ' Add title
            'Else
            '    returnText = UCase(ComboTitle.Text)
            'End If
            'returnText &= Strings.Chr(13) + Strings.Chr(10)

            returnText = UCase(ComboTitle.Text) & Strings.Chr(13) + Strings.Chr(10)

            ' If user hasn't used note selection, then select all notes.        
            If ListBoxBuild.MultiSelect = False Then
                ListBoxBuild.MultiSelect = True
                ListBoxBuild.Height = 117.8
                'ListBoxBuild.ListStyle = fmListStyleOption
                For x = 0 To ListBoxBuild.Items.Count - 1
                    ListBoxBuild.Items(x).Selected = True
                Next x
                UpdateNumbers()
            End If
            ' Begin creating note text                                          
            For x As Integer = 0 To ListBoxBuild.Items.Count - 1     ' Each line item in list
                If CheckBoxUpperCase.Checked = True Then
                    textLine = ListBoxBuild.Items(x).SubItems(0).Text + UCase(ListBoxBuild.Items(x).SubItems(1).Text)
                Else
                    textLine = ListBoxBuild.Items(x).SubItems(0).Text + ListBoxBuild.Items(x).SubItems(1).Text
                End If
                If TextBoxWidth.Text > 0 Then
                    tempText = textLine
                    While CInt(Len(tempText)) > CInt(TextBoxWidth.Text)
                        For z As Integer = 1 To TextBoxWidth.Text
                            If Mid(tempText, z, 1) = " " Then
                                lastSpace = z
                            End If
                        Next
                        tempText2 = Strings.Left(tempText, lastSpace)
                        returnText = returnText + tempText2 + Strings.Chr(13) + Strings.Chr(10) ' Add to text variable
                        tempText = PaddedSpaces + PaddedSpaces + " " + Strings.Right(tempText, Len(tempText) - Len(tempText2))
                    End While
                    returnText = returnText + tempText + Strings.Chr(13) + Strings.Chr(10)    ' Add to text variable
                Else
                    returnText = returnText + tempText + Strings.Chr(13) + Strings.Chr(10)    ' Add to text variable
                End If
                If (CheckLineSpace.Checked = True) And (x <> ListBoxBuild.Items.Count - 1) Then
                    returnText = returnText + Strings.Chr(13) + Strings.Chr(10)       ' Add line space between notes
                End If
            Next x                                      ' Next line item

        Else
            MsgBox("No user notes selected or added.", vbExclamation)
        End If
        _noteText = returnText
        Me.Close()
    End Sub

    Private Sub CommandCancel_Click() Handles CommandCancel.Click
        Me.Close()
    End Sub

    Private Sub ControlSetup()
        CommandMoveUp.Enabled = False
        CommandMoveDown.Enabled = False
        CommandRemove.Enabled = False
        CommandEditNote.Enabled = False
        CommandClearAll.Enabled = False
        If ListBoxBuild.Items.Count > 0 Then
            CommandClearAll.Enabled = True
        End If
        NoteNumberControls()
    End Sub

    Private Sub ReadSource()
        Dim streamR As New StreamReader(NotesCfgPath.Text) ' Open file read only
        Dim textLine As String

        Do While Not streamR.EndOfStream                       ' Loop until end of file.
            textLine = streamR.ReadLine()                       ' Read data into variable.
            If textLine = "[GROUPS]" Then
                Do While Not streamR.EndOfStream                    ' Loop until end of file.
                    textLine = streamR.ReadLine()                    ' Read data into material variable.
                    If textLine <> "" Then
                        ListBoxType.Items.Add(textLine)      ' Add item to list
                    Else
                        GoTo EndReadNotes
                    End If
                Loop
EndReadNotes:
            ElseIf textLine = "[GLOBAL OPTIONS]" Then
                ' Read and set options that are 'Global' to the program
                Do While Not streamR.EndOfStream                      ' Loop until end of file.
                    textLine = streamR.ReadLine()                  ' Read data into variable.
                    If textLine <> "" Then
                        If UCase(Strings.Left(textLine, 11)) = UCase("ColumnWidth") Then
                            TextBoxWidth.Text = Strings.Mid(textLine, 13)

                        ElseIf UCase(Strings.Left(textLine, 12)) = UCase("PaddedSpaces") Then
                            PaddedSpaces = ""
                            For x As Integer = 1 To Strings.Mid(textLine, 14)
                                PaddedSpaces = PaddedSpaces & " "
                            Next x

                        ElseIf UCase(Strings.Left(textLine, 14)) = UCase("NoteDividerSym") Then
                            NoteDividerSym = Strings.Mid(textLine, 16)

                        ElseIf UCase(Strings.Left(textLine, 14)) = UCase("HighlightTitle") Then
                            If UCase(Strings.Mid(textLine, 16)) = "TRUE" Then
                                CheckHighlightTitle.Checked = True
                            ElseIf UCase(Strings.Mid(textLine, 16)) = "FALSE" Then
                                CheckHighlightTitle.Checked = False
                            End If
                        ElseIf UCase(Strings.Left(textLine, 21)) = UCase("DisableHighlightTitle") Then
                            If UCase(Strings.Mid(textLine, 23)) = "TRUE" Then
                                CheckHighlightTitle.Enabled = False
                            ElseIf UCase(Strings.Mid(textLine, 23)) = "FALSE" Then
                                CheckHighlightTitle.Enabled = True
                            End If
                        ElseIf UCase(Strings.Left(textLine, 16)) = UCase("AllowCustomTitle") Then
                            If UCase(Strings.Mid(textLine, 18)) = "TRUE" Then
                                AllowCustomTitle = True
                            ElseIf UCase(Strings.Mid(textLine, 18)) = "FALSE" Then
                                AllowCustomTitle = False
                            End If

                        ElseIf UCase(Strings.Left(textLine, 11)) = UCase("LineSpacing") Then
                            If UCase(Strings.Mid(textLine, 13)) = "TRUE" Then
                                CheckLineSpace.Checked = True
                            ElseIf UCase(Strings.Mid(textLine, 13)) = "FALSE" Then
                                CheckLineSpace.Checked = False
                            End If
                        ElseIf UCase(Strings.Left(textLine, 18)) = UCase("DisableLineSpacing") Then
                            If UCase(Strings.Mid(textLine, 20)) = "TRUE" Then
                                CheckLineSpace.Enabled = False
                            ElseIf UCase(Strings.Mid(textLine, 20)) = "FALSE" Then
                                CheckLineSpace.Enabled = True
                            End If

                        ElseIf UCase(Strings.Left(textLine, 14)) = UCase("BottomUpOption") Then
                            If UCase(Strings.Mid(textLine, 16)) = "TRUE" Then
                                CheckboxNumberBottomUp.Checked = True
                            ElseIf UCase(Strings.Mid(textLine, 16)) = "FALSE" Then
                                CheckboxNumberBottomUp.Checked = False
                            End If
                        ElseIf UCase(Strings.Left(textLine, 21)) = UCase("DisableBottomUpOption") Then
                            If UCase(Strings.Mid(textLine, 23)) = "TRUE" Then
                                CheckboxNumberBottomUp.Enabled = False
                            ElseIf UCase(Strings.Mid(textLine, 23)) = "FALSE" Then
                                CheckboxNumberBottomUp.Enabled = True
                            End If

                        ElseIf UCase(Strings.Left(textLine, 14)) = UCase("NoteNumberSkip") Then
                            If UCase(Strings.Mid(textLine, 16)) = "TRUE" Then
                                CheckBoxNoteNumberSkip.Checked = True
                            ElseIf UCase(Strings.Mid(textLine, 16)) = "FALSE" Then
                                CheckBoxNoteNumberSkip.Checked = False
                            End If
                        ElseIf UCase(Strings.Left(textLine, 21)) = UCase("DisableNoteNumberSkip") Then
                            If UCase(Strings.Mid(textLine, 23)) = "TRUE" Then
                                CheckBoxNoteNumberSkip.Enabled = False
                            ElseIf UCase(Strings.Mid(textLine, 23)) = "FALSE" Then
                                CheckBoxNoteNumberSkip.Enabled = True
                            End If
                        ElseIf UCase(Strings.Left(textLine, 23)) = UCase("DisableNoteNumberChange") Then
                            If UCase(Strings.Mid(textLine, 25)) = "TRUE" Then
                                NoteNumberChange = False
                            Else
                                NoteNumberChange = True
                            End If
                            NoteNumberControls()

                        ElseIf UCase(Strings.Left(textLine, 19)) = UCase("ForceUpperCaseNotes") Then
                            If UCase(Strings.Mid(textLine, 21)) = "TRUE" Then
                                CheckBoxUpperCase.Checked = True
                            Else
                                CheckBoxUpperCase.Checked = False
                            End If
                        ElseIf UCase(Strings.Left(textLine, 26)) = UCase("DisableForceUpperCaseNotes") Then
                            If UCase(Strings.Mid(textLine, 28)) = "TRUE" Then
                                CheckBoxUpperCase.Enabled = False
                            ElseIf UCase(Strings.Mid(textLine, 28)) = "FALSE" Then
                                CheckBoxUpperCase.Enabled = True
                            End If

                        End If
                    Else
                        GoTo EndReadOptions
                    End If
                Loop
EndReadOptions:
            ElseIf textLine = "[TITLES]" Then
                ' Read and set options that are 'Global' to the program
                ComboTitle.Items.Clear()

                Do While Not streamR.EndOfStream                ' Loop until end of file.
                    textLine = streamR.ReadLine               ' Read data into variable.
                    If textLine <> "" Then
                        ComboTitle.Items.Add(textLine)
                        ComboTitle.Enabled = True
                        'ComboTitle.BackColor = vbWindowBackground
                    Else
                        GoTo EndReadTitles
                    End If
                Loop
EndReadTitles:
                ComboTitle.SelectedIndex = 0
            End If
        Loop
        streamR.Close()

    End Sub

    Private Sub SetDefaults()
        MsgBox("Source file not found. Using defaults.", vbExclamation)
        ComboTitle.Enabled = True
        ListBoxType.Enabled = True
        CheckHighlightTitle.Checked = True
        AllowCustomTitle = True
        CheckLineSpace.Checked = True
        CheckboxNumberBottomUp.Checked = False
        CheckBoxNoteNumberSkip.Checked = False
        NoteNumberChange = True
        CheckBoxNoteNumberSkip.Enabled = True
        NoteNumberChange = True
        CheckBoxUpperCase.Checked = True
        CheckBoxUpperCase.Enabled = True
        ListBoxNOTES.Items.Add("Symmetrical about centerline except as noted.")
        ListBoxNOTES.Items.Add("Dimensions are to theoretical sharp corners.")
        ListBoxNOTES.Items.Add("Unless otherwise noted, all radii to be R.xx.")
        ListBoxNOTES.Items.Add("Break all sharp edges.")
        ListBoxNOTES.Items.Add("Remove weld spatter and debris.")
        ListBoxNOTES.Items.Add("Component must rotate freely after assembly.")
        TextBoxWidth.Text = "60"
    End Sub

    Private Sub CommandAbout_Click() Handles CommandAbout.Click
        Dim aboutText As String = $"DSNotes: CommonNotes for DraftSight {vbNewLine}{vbNewLine}
Modified from original version created by Lenny Kikstra
Version {My.Application.Info.Version}"
        MsgBox(aboutText, vbInformation)
    End Sub

    Private Sub CommandNotesCfg_Click(sender As Object, e As EventArgs) Handles CommandNotesCfg.Click

        Dim fBrowse As New Windows.Forms.FolderBrowserDialog
        Dim cfgPath As String = ""

        If My.Settings.NotesConfigPath <> "" Then
            fBrowse.SelectedPath = Path.GetFullPath(My.Settings.NotesConfigPath)
        End If
        fBrowse.ShowDialog()

        If fBrowse.SelectedPath <> NotesCfgPath.Text And fBrowse.SelectedPath <> "" Then

            If Strings.Right(fBrowse.SelectedPath, Len(fBrowse.SelectedPath) - InStrRev(fBrowse.SelectedPath, "\")) <> "CommonNotes.ini" Then cfgPath = Path.Combine(fBrowse.SelectedPath, "CommonNotes.ini")

            My.Settings.NotesConfigPath = cfgPath
            My.Settings.Save()

            NotesCfgPath.Text = cfgPath

            If File.Exists(NotesCfgPath.Text) = True Then ReadSource()
        End If

    End Sub

    Private Sub NotesCfgPath_TextChanged(sender As Object, e As EventArgs) Handles NotesCfgPath.TextChanged

        If NotesCfgPath.Text = "" Then
            If MsgBox("Would you like to clear the stored config file path?", vbYesNo + vbQuestion) = vbYes Then
                My.Settings.NotesConfigPath = ""
            Else
                NotesCfgPath.Text = My.Settings.NotesConfigPath
            End If
        ElseIf NotesCfgPath.Text <> My.Settings.NotesConfigPath And File.Exists(NotesCfgPath.Text) = True Then
            If MsgBox("Would you like to update the stored config file path?", vbYesNo + vbQuestion) = vbYes Then
                My.Settings.NotesConfigPath = NotesCfgPath.Text
                My.Settings.Save()
            Else
                NotesCfgPath.Text = My.Settings.NotesConfigPath
            End If
        End If

    End Sub

End Class