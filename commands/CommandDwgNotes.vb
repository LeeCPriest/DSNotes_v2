Imports DraftSight.Interop.dsAutomation

Public Class CommandDwgNotes
    Inherits CommandBase

    Public Sub New(
    ByRef app As Application,
    ByVal groupName As String)
        MyBase.New(app, groupName)
    End Sub

    Public Overrides Function globalName() As String
        Return "_DSNotes"
    End Function

    Public Overrides Function localName() As String
        Return "DSNOTES"
    End Function

    Public Overrides Function ItemName() As String
        Return "Drawing Notes"
    End Function

    Public Overrides Sub execute()

        Dim commandline As CommandMessage = application.GetCommandMessage()
        If commandline Is Nothing Then
            Return
        End If

        commandline.PrintLine("Opening drawing notes function...")

        Dim notesForm As New NotesForm()
        notesForm.StartPosition = Windows.Forms.FormStartPosition.CenterParent
        notesForm.ShowDialog()

        If notesForm.NoteText <> "" Then
            Dim dsDoc As Document = application.GetActiveDocument
            Dim dsModel As Model = dsDoc.GetModel
            Dim dsSketchMgr As SketchManager = dsModel.GetSketchManager

            Dim strArray(0) As String
            strArray(0) = notesForm.NoteText

            'dsSketchMgr.InsertNote(0, 0, 0, 0, 0, 0, strArray) 'this inserts the note at 0,0, but was replaced by code below to insert at selected insertion point

            Dim x As Double = 0, y As Double = 0, z As Double = 0

            Dim dsNote As Note
            application.TemporaryEntityMode = True
            dsNote = dsSketchMgr.InsertNote(x, y, z, 0, 0, 0, strArray)
            application.TemporaryEntityMode = False

            Dim tracker As Tracker = application.CreateTracker()
            tracker.AddTemporaryEntity(dsNote)

            Dim dsTrackerEvent As New DSTracker
            dsTrackerEvent.myTracker = tracker

            Dim dsCommandMessage As CommandMessage = application.GetCommandMessage
            dsCommandMessage.AddTracker(tracker)

            Dim dsMath As MathUtility = application.GetMathUtility

            dsCommandMessage.PromptForPoint("Please select an insertion point for the notes...", x, y, z)

            dsNote.SetPosition(x, y, z)

            dsSketchMgr.AddTemporaryEntity(dsNote)

            dsCommandMessage.RemoveTracker(tracker)
        End If

    End Sub

End Class
