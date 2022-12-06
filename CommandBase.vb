Imports DraftSight.Interop.dsAutomation

' Derive commands you want to add to your add-in from this class, defining
' the abstract methods globalName(), localName(), and execute. This
' suffices if you want to invoke your command from the command line only.
' 
' If you want your command to be available in menus or on toolbars as
' well, you should also redefine ItemName() and Description(). If you have
' an icon available for this command, you use it redefining SmallIcon() or
' LargeIcon().
'
' This abstract base class contains only dsAPI code and is thus
' independent from this project. Hence you can use it, as is, in other
' add-in projects as well.
Public MustInherit Class CommandBase
    Protected application As Application = Nothing
    Protected m_user_command As UserCommand
    Protected m_command As Command = Nothing
    Protected m_user_command_id As String = ""
    Protected m_group_name As String = ""

    Public Sub New(ByRef app As Application, ByVal groupName As String)
        application = app
        m_group_name = groupName
    End Sub

    ' This method is the command body. It will be
    ' called when this command was invoked.
    Public MustOverride Sub execute()

    ' The globalName is the untranslated name of the command. Usually it
    ' starts with an underscore '_'.
    ' It has to be unique within a group.
    Public MustOverride Function globalName() As String

    ' The localName is the translated name of the command.
    ' It has to be unique within a group.
    Public MustOverride Function localName() As String

    Public MustOverride Function ItemName() As String

    Public Function UserCommandID() As String
        Return m_user_command_id
    End Function

    ' Registers the command, so it can be used from the
    ' command line by typing the command's global or local name.
    Public Function registerCommand() As dsCreateCommandError_e
        Dim result As dsCreateCommandError_e
        m_command = application.CreateCommand2( _
            m_group_name, _
            globalName(), _
            localName(), _
            result)
        If result = dsCreateCommandError_e.dsCreateCommand_Succeeded And Not m_command Is Nothing Then
            AddHandler m_command.ExecuteNotify, AddressOf Me.execute
        End If
        Return result
    End Function

    Public Function createUserCommand(uiState As dsUIState_e) As dsCreateCommandError_e
        Dim error1 As dsCreateCommandError_e
        m_user_command_id = ""
        m_user_command = application.CreateUserCommand(m_group_name, globalName(), "^C^C" + globalName(), "", "", "", uiState, error1)

        If error1 = dsCreateCommandError_e.dsCreateCommand_Succeeded Then
            m_user_command_id = m_user_command.GetID()
        End If

        Return error1
    End Function

    Public Function createUserCommand() As dsCreateCommandError_e
        Return createUserCommand(dsUIState_e.dsUIState_Document)
    End Function

    Public Function insert(menu As MenuItem, position As Integer) As MenuItem
        Return menu.InsertMenuItem(m_group_name, dsMenuItemType_e.dsMenuItemType_UserCommand, position, ItemName(), m_user_command_id)
    End Function

    Public Function insert(toolbar As Toolbar, position As Integer) As ToolbarItem
        Return toolbar.InsertToolbarItem(m_group_name, dsToolbarItemType_e.dsToolBarItemType_UserCommand, position, ItemName(), m_user_command_id)
    End Function

End Class
