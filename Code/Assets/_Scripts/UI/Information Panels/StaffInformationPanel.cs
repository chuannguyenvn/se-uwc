using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaffInformationPanel : InformationPanel<StaffData>
{
    [SerializeField] private TMP_Text staffName;
    [SerializeField] private TMP_Text role;
    [SerializeField] private TMP_Text genderAndAge;
    [SerializeField] private TMP_Text address;
    [SerializeField] private TMP_Text phoneNumber;

    [SerializeField] private Button assignTaskButton;
    [SerializeField] private Button viewCalendarButton;
    [SerializeField] private Button sendMessageButton;

    [SerializeField] private TaskDataListView taskDataListView;
    [SerializeField] private Calendar calendar;

    [SerializeField] private AssigningMCPListView assigningMcpListView;

    private void Start()
    {
        assignTaskButton.onClick.AddListener(EnterAssignMode);
        viewCalendarButton.onClick.AddListener(EnterCalendarViewingMode);
        sendMessageButton.onClick.AddListener(GoToInbox);
    }

    protected override void SetData(StaffData data)
    {
        base.SetData(data);

        staffName.text = data.Name;
        role.text = data.Role;
        genderAndAge.text = data.Gender + ", " + (DateTime.Today - data.DateOfBirth).Days / 365;
        address.text = data.HomeAddress;
        phoneNumber.text = data.PhoneNumber;
        taskDataListView.ShowTodayTasksOf(data);
    }
    
    private void EnterAssignMode()
    {
        MCPMapEntity.GroupingSelect = true;

        assigningMcpListView.AnimateShow();

        MCPMapEntity.ToggleStateChanged += (entity, isSelected) =>
        {
            if (isSelected)
                assigningMcpListView.AddDataItem(entity.Data);
            else
                assigningMcpListView.RemoveDataItem(entity.Data);
        };
    }

    private void EnterCalendarViewingMode()
    {
        calendar.gameObject.SetActive(true);
    }

    private void GoToInbox()
    {
        PrimarySidebar.Instance.OnViewChanged(ViewType.MessagesOverview);
        ListViewManager.Instance.InboxListView.SelectInboxByStaffId(Data.ID);
    }
}