Public Class FormCustomNote

    Private customNote_ As String
    Public Property CustomNote() As String
        Get
            Return customNote_
        End Get
        Set(ByVal value As String)
            customNote_ = value
        End Set
    End Property

    Private Sub FormCustomNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxCustomNote.Text = customNote_
    End Sub

    Private Sub CommandDone_Click(sender As Object, e As EventArgs) Handles CommandDone.Click
        customNote_ = TextBoxCustomNote.Text
        Me.Hide()
    End Sub

    Private Sub CommandCancel_Click(sender As Object, e As EventArgs) Handles CommandCancel.Click
        Me.Close()
    End Sub

End Class