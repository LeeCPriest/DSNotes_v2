Imports DraftSight.Interop.dsAutomation

Public Class DSTracker

    Private _dsNote As SimpleNote
    Public Property DSNote() As SimpleNote
        Get
            Return _dsNote
        End Get
        Set(ByVal value As SimpleNote)
            _dsNote = value
        End Set
    End Property

    Public WithEvents myTracker As Tracker

    Public Sub myTracker_UpdateNotify(ByVal CursorPosition As MathPoint)

        If CursorPosition Is Nothing Then
            Return
        End If

        Dim x As Double = 0#
        Dim y As Double = 0#
        Dim z As Double = 0#

        CursorPosition.GetPosition(x, y, z)

        _dsNote.SetPosition(x, y, z)

    End Sub

End Class
