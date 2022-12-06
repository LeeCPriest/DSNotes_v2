Imports DraftSight.Interop.dsAutomation

Public Class CommandHello
    Inherits CommandBase

    Public Sub New( _
    ByRef app As Application, _
    ByVal groupName As String)
        MyBase.New(app, groupName)
    End Sub

    Public Overrides Function globalName() As String
        Return "_MHELLO"
    End Function

    Public Overrides Function localName() As String
        Return "MHELLO"
    End Function

    Public Overrides Function ItemName() As String
        Return "Hello"
    End Function

    Public Overrides Sub execute()

        Dim commandline As CommandMessage = application.GetCommandMessage()
        If commandline Is Nothing Then
            Return
        End If

        commandline.PrintLine("Command Executed! You need to write code to create entity.")

    End Sub

End Class
