'Sample Name: HelloDSAPI
'
'Sample Description:
'    This sample insert a simple note on drawing

'Usage:
'    This example has a command, which can be invoked using the
'    command line.
'
'   _HelloDSAPI "insert a simple note on drawing"

Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Runtime.InteropServices

Imports DraftSight.Interop.dsAddin
Imports DraftSight.Interop.dsAutomation

<Guid("3D90F06F-1915-481F-810B-9F3CED15D660")> <ComVisible(True)> _
Public Class MenusAndToolbars
    Implements DsAddin

    Private m_AddinGUID As String = ""
    Private application As Application = Nothing
    Private m_CommandNotes As CommandDwgNotes = Nothing

    Public Sub New()
        m_AddinGUID = Me.GetType.GUID.ToString
    End Sub

    Private Sub CreateUserInterfaceAndCommands()
        ' 1 - First create and register your command here. This is
        '     for invoking the command from the command line.
        'm_CommandHello = New CommandHello(application, m_AddinGUID)
        'm_CommandHello.registerCommand()
        m_CommandNotes = New CommandDwgNotes(application, m_AddinGUID)
        m_CommandNotes.registerCommand()

        'Dim menu As MenuItem = application.AddMenu(m_AddinGUID, dsUIState_e.dsUIState_Document, 9, "Ribbon")
        'If menu Is Nothing Then
        '    Return
        'End If

        'Dim toolbar As Toolbar = application.AddToolbar(m_AddinGUID, dsUIState_e.dsUIState_Document, "Ribbon")
        'If toolbar Is Nothing Then
        '    Return
        'End If

        'm_CommandHello.createUserCommand()
        'm_CommandHello.insert(menu, 1)
        'm_CommandHello.insert(toolbar, 1)

        Dim [Error] As dsCreateCommandError_e
        Dim tb_standards As UserCommand = application.CreateUserCommand(m_AddinGUID, m_CommandNotes.localName(), "^C^CMHELLO", "Shows the Ribbon items: MHELLO", "c:/Program Files/Dassault Systemes/DraftSight/APISDK/samples/VB.Net/simple/Ribbon/ToolBar_Large.png", "c:/Program Files/Dassault Systemes/DraftSight/APISDK/samples/VB.Net/simple/Ribbon/ToolBar_Small.png",
         dsUIState_e.dsUIState_Document, [Error])

        Dim tb_Hello_id As String = tb_standards.GetID()

        Dim dsWorkSpace As WorkSpace = application.AddWorkspace("SampleWorkSpace")
        dsWorkSpace.Activate()

        Dim tabs As Object = dsWorkSpace.GetRibbonTabs()
        Dim objects As Object() = DirectCast(tabs, Object())
        Dim length As Integer = 1

        'Add a New Tab
        Dim ribbonTab As RibbonTab = dsWorkSpace.AddRibbonTab(m_AddinGUID, length, "Circle", "Circle")
        If ribbonTab IsNot Nothing Then
            'Add a New Pannel to RibbonSampleTab Tab
            Dim dsRibbonPanel As RibbonPanel = ribbonTab.InsertRibbonPanel(m_AddinGUID, 1, "Sample", "Sample")
            dsRibbonPanel.Name = "Draw Circle"
            dsRibbonPanel.DisplayText = "Draw Circle"

            'Add a New Row to SamplePannel
            Dim dsRibbonRow As RibbonRow = dsRibbonPanel.InsertRibbonRow(m_AddinGUID, "CircleRow")
            'Add a New Button to SampleRow
            Dim dsRibbonCmdBtn1 As RibbonCommandButton, dsRibbonCmdBtn2 As RibbonCommandButton
            dsRibbonCmdBtn1 = dsRibbonRow.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Small Circle", tb_Hello_id)
            'Add a Separator to SampleRow
            Dim dsRibbonSeparator As RibbonSeparator = dsRibbonRow.InsertRibbonSeparator(m_AddinGUID, dsRibbonSeparatorStyle_e.dsRibbonSeparatorStyle_Spacer)
            'Add a New Button to SampleRow
            dsRibbonCmdBtn2 = dsRibbonRow.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Big Circle", tb_Hello_id)

            'Add a new panel
            dsRibbonPanel = ribbonTab.InsertRibbonPanel(m_AddinGUID, 2, "Draw Arc", "Draw Arc")
            dsRibbonRow = dsRibbonPanel.InsertRibbonRow(m_AddinGUID, "ArcRow")
            'Add a New Button to SampleRow
            dsRibbonCmdBtn1 = dsRibbonRow.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Small Arc", tb_Hello_id)
            'Add a Separator to SampleRow
            dsRibbonSeparator = dsRibbonRow.InsertRibbonSeparator(m_AddinGUID, dsRibbonSeparatorStyle_e.dsRibbonSeparatorStyle_Spacer)
            'Add a New Button to SampleRow
            dsRibbonCmdBtn2 = dsRibbonRow.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Big Arc", tb_Hello_id)
        End If

        ribbonTab = dsWorkSpace.AddRibbonTab(m_AddinGUID, length + 1, "Line", "Line")
        If ribbonTab IsNot Nothing Then
            'Add a New Pannel to RibbonSampleTab Tab
            Dim dsRibbonPanel As RibbonPanel = ribbonTab.InsertRibbonPanel(m_AddinGUID, 1, "Sample", "Sample")
            dsRibbonPanel.Name = "Draw Line"
            dsRibbonPanel.DisplayText = "Draw Line"

            'Add a New Row to SamplePannel
            Dim dsRibbonRow As RibbonRow = dsRibbonPanel.InsertRibbonRow(m_AddinGUID, "LineRow")
            'Add a New Button to SampleRow
            Dim dsRibbonCmdBtn1 As RibbonCommandButton, dsRibbonCmdBtn2 As RibbonCommandButton
            dsRibbonCmdBtn1 = dsRibbonRow.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Small Line", tb_Hello_id)
            'Add a Separator to SampleRow
            Dim dsRibbonSeparator As RibbonSeparator = dsRibbonRow.InsertRibbonSeparator(m_AddinGUID, dsRibbonSeparatorStyle_e.dsRibbonSeparatorStyle_Spacer)
            'Add a New Button to SampleRow
            dsRibbonCmdBtn2 = dsRibbonRow.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Big Line", tb_Hello_id)
        End If

        ribbonTab = dsWorkSpace.AddRibbonTab(m_AddinGUID, length + 2, "PolyLine", "PolyLine")
        If ribbonTab IsNot Nothing Then
            'Add a New Pannel to RibbonSampleTab Tab
            Dim dsRibbonPanel As RibbonPanel = ribbonTab.InsertRibbonPanel(m_AddinGUID, 1, "Sample", "Sample")
            dsRibbonPanel.Name = "Draw PolyLine"
            dsRibbonPanel.DisplayText = "Draw PolyLine"

            'Add a New Row to SamplePannel
            Dim dsRibbonRow As RibbonRow = dsRibbonPanel.InsertRibbonRow(m_AddinGUID, "PolyLineRow")
            'Add a New Button to SampleRow
            Dim dsRibbonCmdBtn1 As RibbonCommandButton, dsRibbonCmdBtn2 As RibbonCommandButton
            dsRibbonCmdBtn1 = dsRibbonRow.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Small PolyLine", tb_Hello_id)
            'Add a Separator to SampleRow
            Dim dsRibbonSeparator As RibbonSeparator = dsRibbonRow.InsertRibbonSeparator(m_AddinGUID, dsRibbonSeparatorStyle_e.dsRibbonSeparatorStyle_Spacer)
            'Add a New Button to SampleRow
            dsRibbonCmdBtn2 = dsRibbonRow.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Big PolyLine", tb_Hello_id)
        End If

        ribbonTab = dsWorkSpace.AddRibbonTab(m_AddinGUID, length + 3, "Xline", "Xline")
        If ribbonTab IsNot Nothing Then
            'Add a New Pannel to RibbonSampleTab Tab
            Dim dsRibbonPanel As RibbonPanel = ribbonTab.InsertRibbonPanel(m_AddinGUID, 1, "Sample", "Sample")
            dsRibbonPanel.Name = "Draw Xline"
            dsRibbonPanel.DisplayText = "Draw Xline"

            'Add a New Row to SamplePannel
            Dim dsRibbonRow As RibbonRow = dsRibbonPanel.InsertRibbonRow(m_AddinGUID, "XlineRow")
            'Add a New Button to SampleRow
            Dim dsRibbonCmdBtn1 As RibbonCommandButton, dsRibbonCmdBtn2 As RibbonCommandButton
            dsRibbonCmdBtn1 = dsRibbonRow.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Small Xline", tb_Hello_id)
            'Add a Separator to SampleRow
            Dim dsRibbonSeparator As RibbonSeparator = dsRibbonRow.InsertRibbonSeparator(m_AddinGUID, dsRibbonSeparatorStyle_e.dsRibbonSeparatorStyle_Spacer)
            'Add a New Button to SampleRow
            dsRibbonCmdBtn2 = dsRibbonRow.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Big Xline", tb_Hello_id)
        End If

        ribbonTab = dsWorkSpace.AddRibbonTab(m_AddinGUID, length + 4, "Ellipse", "Ellipse")
        If ribbonTab IsNot Nothing Then
            'Add a New Pannel to RibbonSampleTab Tab
            Dim dsRibbonPanel As RibbonPanel = ribbonTab.InsertRibbonPanel(m_AddinGUID, 1, "Sample", "Sample")
            dsRibbonPanel.Name = "Draw Ellipse"
            dsRibbonPanel.DisplayText = "Draw Ellipse"

            'Add a New Row to SamplePannel
            Dim dsRibbonRow As RibbonRow = dsRibbonPanel.InsertRibbonRow(m_AddinGUID, "EllipseRow")
            'Add a New Button to SampleRow
            Dim dsRibbonCmdBtn1 As RibbonCommandButton, dsRibbonCmdBtn2 As RibbonCommandButton
            dsRibbonCmdBtn1 = dsRibbonRow.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Ellipse", tb_Hello_id)
            'Add a Separator to SampleRow
            Dim dsRibbonSeparator As RibbonSeparator = dsRibbonRow.InsertRibbonSeparator(m_AddinGUID, dsRibbonSeparatorStyle_e.dsRibbonSeparatorStyle_Spacer)

            Dim dsRibbonSplitButton As RibbonSplitButton = dsRibbonRow.InsertRibbonSplitButton(m_AddinGUID, dsRibbonItemType_e.dsRibbonItemType_SplitButton, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, dsRibbonSplitButtonListStyle_e.dsRibbonSplitButtonListStyle_IconText, dsRibbonSplitButtonBehaviour_e.dsRibbonSplitButtonBehaviour_FollowStaticText, "Split")

            'Add a New Button to SampleRow
            dsRibbonCmdBtn1 = dsRibbonSplitButton.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Small Elliptical Arc", tb_Hello_id)
            dsRibbonCmdBtn2 = dsRibbonSplitButton.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Big Elliptical Arc", tb_Hello_id)
        End If

        'Get system ribbon menu of the workspace
        Dim dsRibbonSystemMenu As RibbonSystemMenu = dsWorkSpace.GetRibbonSystemMenu()
        'Get items of the system ribbon menu
        Dim systemMenuItems As Object = dsRibbonSystemMenu.GetRibbonSystemMenuItems()
        Dim objs As Object() = DirectCast(systemMenuItems, Object())
        Dim szRbSysMenu As Integer = objs.Length

        'Insert items to the system ribbon menu
        Dim dsRibbonSystemMenuItem As RibbonSystemMenuItem = dsRibbonSystemMenu.InsertRibbonSystemMenuItem(m_AddinGUID, dsRibbonItemType_e.dsRibbonItemType_SystemMenuItem, szRbSysMenu + 1, "Circle", tb_Hello_id)
        dsRibbonSystemMenuItem = dsRibbonSystemMenu.InsertRibbonSystemMenuItem(m_AddinGUID, dsRibbonItemType_e.dsRibbonItemType_SystemMenuItem, szRbSysMenu + 2, "Line", tb_Hello_id)
        dsRibbonSystemMenuItem = dsRibbonSystemMenu.InsertRibbonSystemMenuItem(m_AddinGUID, dsRibbonItemType_e.dsRibbonItemType_SystemMenuItem, szRbSysMenu + 3, "PolyLine", tb_Hello_id)
        dsRibbonSystemMenuItem = dsRibbonSystemMenu.InsertRibbonSystemMenuItem(m_AddinGUID, dsRibbonItemType_e.dsRibbonItemType_SystemMenuItem, szRbSysMenu + 4, "Xline", tb_Hello_id)
        dsRibbonSystemMenuItem = dsRibbonSystemMenu.InsertRibbonSystemMenuItem(m_AddinGUID, dsRibbonItemType_e.dsRibbonItemType_SystemMenuItem, szRbSysMenu + 5, "Ellipse", tb_Hello_id)


        'Add Ribbon Quick Access Bar
        Dim dsRibbonQuickAccessBar As RibbonQuickAccessBar = dsWorkSpace.AddRibbonQuickAccessBar(m_AddinGUID, "SampleRQAB")

        'Add Ribbon Quick Access Bar items
        Dim dsRibbonQuickAccessBarItem1 As RibbonQuickAccessBarItem = dsRibbonQuickAccessBar.InsertRibbonQuickAccessBarItem(m_AddinGUID, "RQAB", tb_Hello_id)
        dsRibbonQuickAccessBarItem1 = dsRibbonQuickAccessBar.InsertRibbonQuickAccessBarItem(m_AddinGUID, "RQAB", tb_Hello_id)
        dsRibbonQuickAccessBarItem1 = dsRibbonQuickAccessBar.InsertRibbonQuickAccessBarItem(m_AddinGUID, "RQAB", tb_Hello_id)
        dsRibbonQuickAccessBarItem1 = dsRibbonQuickAccessBar.InsertRibbonQuickAccessBarItem(m_AddinGUID, "RQAB", tb_Hello_id)
        dsRibbonQuickAccessBarItem1 = dsRibbonQuickAccessBar.InsertRibbonQuickAccessBarItem(m_AddinGUID, "RQAB", tb_Hello_id)

        dsWorkSpace = application.GetWorkspace("Drafting and Annotation")
        Dim ObjTabArr As Object = dsWorkSpace.GetRibbonTabs()
        Dim DATabs As Object() = DirectCast(ObjTabArr, Object())
        Dim len As Integer = DATabs.Length
        For i As Integer = 0 To len - 1
            Dim Tab As RibbonTab = DirectCast(DATabs(i), RibbonTab)
            If Tab IsNot Nothing Then
                Dim TabName As String = Tab.Name
                Dim ItemType As dsRibbonItemType_e = Tab.[GetType]()
                If ItemType = dsRibbonItemType_e.dsRibbonItemType_Tab AndAlso TabName.CompareTo("Manage") = 0 Then
                    'Add a New Pannel to Add-Ins Tab                        
                    Dim dsRibbonPanels As Object = Tab.GetRibbonPanels()
                    Dim dsRibbonPanelsArr As Object() = DirectCast(dsRibbonPanels, Object())
                    For ii As Integer = 0 To dsRibbonPanelsArr.Length - 1
                        Dim dsRibbonPanel As RibbonPanel = DirectCast(dsRibbonPanelsArr(ii), RibbonPanel)
                        If dsRibbonPanel IsNot Nothing Then
                            Dim panelName As String = dsRibbonPanel.Name
                            panelName = dsRibbonPanel.GetApiID()
                            If panelName.CompareTo("ID_PanelMacro") = 0 Then
                                Dim dsRibbonRow As RibbonRow = dsRibbonPanel.GetRibbonRow()

                                'Add a Separator to SampleRow
                                Dim dsRibbonSeparator As RibbonSeparator = dsRibbonRow.InsertRibbonSeparator(m_AddinGUID, dsRibbonSeparatorStyle_e.dsRibbonSeparatorStyle_Spacer)

                                'Add a New Button to SampleRow
                                Dim dsRibbonCmdBtn1 As RibbonCommandButton = dsRibbonRow.InsertRibbonCommandButton(m_AddinGUID, dsRibbonButtonStyle_e.dsRibbonButtonStyle_LargeWithText, "Hello", tb_Hello_id)
                            End If
                        End If
                    Next
                End If
            End If
        Next

    End Sub

    Private Sub RemoveUserInterface()
        Dim dsWSObj As Object = application.GetWorkspaces(dsUIState_e.dsUIState_Document)
        Dim dsWSArr As Object() = DirectCast(dsWSObj, Object())
        For i As Integer = 0 To dsWSArr.Length - 1
            Dim dsWorkspace As WorkSpace = DirectCast(dsWSArr(i), WorkSpace)
            If dsWorkspace IsNot Nothing Then
                Dim nameWS As String = dsWorkspace.Name
                If nameWS.CompareTo("SampleWorkSpace") = 0 Then
                    Dim dsObj As Object = dsWorkspace.GetRibbonTabs()
                    Dim dsObjArr As Object() = DirectCast(dsObj, Object())
                    For k As Integer = 0 To dsObjArr.Length - 1
                        Dim ribbonTab As RibbonTab = DirectCast(dsObjArr(k), RibbonTab)
                        If ribbonTab IsNot Nothing Then
                            Dim dsRbPanelsobj As Object = ribbonTab.GetRibbonPanels()
                            Dim dsRbPanelsArr As Object() = DirectCast(dsRbPanelsobj, Object())
                            For j As Integer = 0 To dsRbPanelsArr.Length - 1
                                Dim dsRibbonPanel As RibbonPanel = DirectCast(dsRbPanelsArr(j), RibbonPanel)
                                If dsRibbonPanel IsNot Nothing Then
                                    dsRibbonPanel.Remove()
                                    ribbonTab.Remove()
                                End If
                            Next
                        End If
                    Next

                    Dim dsRibbonSystemMenu As RibbonSystemMenu = dsWorkspace.GetRibbonSystemMenu()
                    Dim dsObjSM As Object = dsRibbonSystemMenu.GetRibbonSystemMenuItems()
                    Dim dsObjSMArr As Object() = DirectCast(dsObjSM, Object())
                    Dim szRbSysMenu As Integer = dsObjSMArr.Length
                    For ik As Integer = 0 To szRbSysMenu - 1
                        Dim dsRibbonSystemMenuItem As RibbonSystemMenuItem = DirectCast(dsObjSMArr(ik), RibbonSystemMenuItem)
                        If dsRibbonSystemMenuItem IsNot Nothing Then
                            Dim ItemType As dsRibbonItemType_e = dsRibbonSystemMenuItem.[GetType]()
                            If ItemType = dsRibbonItemType_e.dsRibbonItemType_SystemMenuItem Then
                                Dim menuName As String = dsRibbonSystemMenuItem.Name
                                Dim menuID As String = dsRibbonSystemMenuItem.GetApiID()
                                If menuName.CompareTo("Circle") = 0 AndAlso menuID.Equals(m_AddinGUID, StringComparison.OrdinalIgnoreCase) Then
                                    dsRibbonSystemMenuItem.Remove()
                                ElseIf menuName.CompareTo("Line") = 0 AndAlso menuID.Equals(m_AddinGUID, StringComparison.OrdinalIgnoreCase) Then
                                    dsRibbonSystemMenuItem.Remove()
                                ElseIf menuName.CompareTo("PolyLine") = 0 AndAlso menuID.Equals(m_AddinGUID, StringComparison.OrdinalIgnoreCase) Then
                                    dsRibbonSystemMenuItem.Remove()
                                ElseIf menuName.CompareTo("Xline") = 0 AndAlso menuID.Equals(m_AddinGUID, StringComparison.OrdinalIgnoreCase) Then
                                    dsRibbonSystemMenuItem.Remove()
                                ElseIf menuName.CompareTo("Ellipse") = 0 AndAlso menuID.Equals(m_AddinGUID, StringComparison.OrdinalIgnoreCase) Then
                                    dsRibbonSystemMenuItem.Remove()
                                End If
                            End If
                        End If
                    Next

                    Dim dsRibbonQuickAccessBar As RibbonQuickAccessBar = dsWorkspace.GetRibbonQuickAccessBar()
                    Dim dsObjQAB As Object = dsRibbonQuickAccessBar.GetRibbonQuickAccessBarItems()
                    Dim dsObjQABArr As Object() = DirectCast(dsObjQAB, Object())

                    Dim Type As dsRibbonItemType_e = dsRibbonQuickAccessBar.[GetType]()
                    If Type = dsRibbonItemType_e.dsRibbonItemType_QuickAccessBar Then
                        szRbSysMenu = dsObjQABArr.Length
                        For id As Integer = 0 To szRbSysMenu - 1
                            Dim dsRibbonQuickAccessBarItem As RibbonQuickAccessBarItem = DirectCast(dsObjQABArr(id), RibbonQuickAccessBarItem)
                            If dsRibbonQuickAccessBarItem IsNot Nothing Then
                                Dim ItemType As dsRibbonItemType_e = dsRibbonQuickAccessBarItem.[GetType]()
                                If ItemType = dsRibbonItemType_e.dsRibbonItemType_QuickAccessBarItem Then
                                    Dim QABID As String = dsRibbonQuickAccessBarItem.GetApiID()
                                    Dim bEnable As Boolean = True
                                    bEnable = dsRibbonQuickAccessBarItem.Enabled
                                    If QABID.CompareTo(m_AddinGUID) = 0 Then
                                        dsRibbonQuickAccessBarItem.Remove()
                                    End If
                                End If
                            End If
                        Next
                    End If
                    dsWorkspace.Remove()
                ElseIf nameWS.CompareTo("Drafting and Annotation") = 0 Then
                    Dim dsOb As Object = dsWorkspace.GetRibbonTabs()
                    Dim dsObArr As Object() = DirectCast(dsOb, Object())
                    For ip As Integer = 0 To dsObArr.Length - 1
                        Dim ribbonsTab As RibbonTab = DirectCast(dsObArr(ip), RibbonTab)
                        If ribbonsTab IsNot Nothing Then
                            Dim name As String = ribbonsTab.Name
                            Dim displayText As String = ribbonsTab.DisplayText
                            Dim apiID As String = ribbonsTab.GetApiID()
                            If name.CompareTo("RibbonSampleTab") = 0 AndAlso displayText.CompareTo("RibbonSampleTab") = 0 AndAlso apiID.CompareTo(m_AddinGUID) = 0 Then
                                Dim dsObjRbPanels As Object = ribbonsTab.GetRibbonPanels()
                                Dim dsRbPanelsArr As Object() = DirectCast(dsObjRbPanels, Object())

                                For j As Integer = 0 To dsRbPanelsArr.Length - 1
                                    Dim dsRibbonPanel As RibbonPanel = DirectCast(dsRbPanelsArr(j), RibbonPanel)
                                    If dsRibbonPanel IsNot Nothing Then
                                        Dim ItemType As dsRibbonItemType_e = dsRibbonPanel.[GetType]()
                                        If ItemType = dsRibbonItemType_e.dsRibbonItemType_Panel Then
                                            name = dsRibbonPanel.Name
                                            Dim displayTxt As String = dsRibbonPanel.DisplayText
                                            If name.CompareTo("SamplePannel") = 0 AndAlso displayTxt.CompareTo("SamplePannel") = 0 Then
                                                Dim dsRibbonRow As RibbonRow = dsRibbonPanel.GetRibbonRow()
                                                If dsRibbonRow IsNot Nothing Then
                                                    dsRibbonRow.Remove()
                                                    dsRibbonPanel.RemoveFromTab("Manage")
                                                    dsRibbonPanel.Remove()
                                                    ribbonsTab.Remove()
                                                End If
                                            End If
                                        End If
                                    End If
                                Next
                            ElseIf name.CompareTo("Manage") = 0 Then
                                Dim dsObjRibbonPanelsArr As Object = ribbonsTab.GetRibbonPanels()
                                Dim dsRibbonPanelsArr As Object() = DirectCast(dsObjRibbonPanelsArr, Object())

                                For it As Integer = 0 To dsRibbonPanelsArr.Length - 1
                                    Dim dsRibbonPanel As RibbonPanel = DirectCast(dsRibbonPanelsArr(it), RibbonPanel)
                                    If dsRibbonPanel IsNot Nothing Then
                                        Dim panelName As String = dsRibbonPanel.GetApiID()
                                        If panelName.CompareTo("ID_PanelMacro") = 0 Then
                                            Dim dsRibbonRow As RibbonRow = dsRibbonPanel.GetRibbonRow()
                                            Dim dsObjRibbonRow As Object = dsRibbonRow.GetRibbonRowItems()
                                            Dim dsRibbonRowArr As Object() = DirectCast(dsObjRibbonRow, Object())

                                            For ig As Integer = 0 To dsRibbonRowArr.Length - 1
                                                Dim dsRibbonRowItem As RibbonRowItem = DirectCast(dsRibbonRowArr(ig), RibbonRowItem)
                                                Dim ItemType As dsRibbonItemType_e = dsRibbonRowItem.[GetType]()
                                                If ItemType = dsRibbonItemType_e.dsRibbonItemType_CommandButton Then
                                                    Dim nameRow As String = dsRibbonRowItem.Name
                                                    If nameRow.CompareTo("Hello") = 0 Then
                                                        dsRibbonRowItem.Remove()
                                                    End If
                                                End If
                                            Next
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub


    Public Function ConnectToDraftSight(ByVal dsApp As Object, ByVal Cookie As Integer) As Boolean _
    Implements DraftSight.Interop.dsAddin.IDsAddin.ConnectToDraftSight
        application = dsApp
        CreateUserInterfaceAndCommands()
        Return True
    End Function

    Public Function DisconnectFromDraftSight() As Boolean _
    Implements DraftSight.Interop.dsAddin.IDsAddin.DisconnectFromDraftSight
        RemoveUserInterface()
        application.RemoveUserInterface(m_AddinGUID)
        application = Nothing
        Return True
    End Function

End Class
