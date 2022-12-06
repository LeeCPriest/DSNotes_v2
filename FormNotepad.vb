Public Class FormNotepad

    Private notepadNote_ As String()
    Public Property NotepadNote() As String()
        Get
            Return notepadNote_
        End Get
        Set(ByVal value() As String)
            notepadNote_ = value
        End Set
    End Property

    Private Sub CommandCancel_Click(sender As Object, e As EventArgs) Handles CommandCancel.Click
        Me.Close()
    End Sub

    Private Sub CommandDone_Click(sender As Object, e As EventArgs) Handles CommandDone.Click
        notepadNote_ = TextBoxEditor.Text.Split(vbNewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        Me.Close()
    End Sub

    Private Sub FormNotepad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim textLine As String

        For i = 0 To UBound(notepadNote_) - 1
            textLine = notepadNote_(i)

            If i < UBound(notepadNote_) Then textLine &= vbNewLine

            TextBoxEditor.Text &= textLine
        Next

    End Sub

End Class