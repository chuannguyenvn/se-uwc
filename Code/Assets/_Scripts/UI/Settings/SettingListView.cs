using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingListView : ListView
{
    private const float HORIZONTAL_MARGIN = 10f;

    private RectTransform rectTransform;
    private List<ITMPDeferrable> deferrables = new();

    private void Awake()
    {
        ApplicationManager.Instance.AddInitWork(Init, ApplicationManager.InitState.UI);
    }

    protected override void Init()
    {
        rectTransform = GetComponent<RectTransform>();
        var headerPrefab = ResourceManager.Instance.SettingSectionHeader;
        var itemPrefab = ResourceManager.Instance.SettingListItemView;
        var SM = SettingManager.Instance;
        var settingTitle = "";
        
        #region InterfaceSettings

        var interfaceHeader = Instantiate(headerPrefab).GetComponent<SettingSectionHeader>();
        settingTitle = LanguageTranslation.GetText(LanguageTranslation.TextType.Setting_Interface_Setting,
            LanguageTranslation.ReturnTextOption.Title_Case);
        interfaceHeader.Init(settingTitle, rectTransform.rect.width - HORIZONTAL_MARGIN * 2);

        AddItem(interfaceHeader);

        settingTitle = LanguageTranslation.GetText(LanguageTranslation.TextType.Setting_Dark_Theme,
            LanguageTranslation.ReturnTextOption.Sentence_case);
        var darkThemeOption = Instantiate(itemPrefab).GetComponent<SettingListItemView>();
        darkThemeOption.Init(settingTitle + ": ", () => SM.DarkThemeOption,
            e => SM.DarkThemeOption = (ToggleOption)e, typeof(ToggleOption));

        AddItem(darkThemeOption);


        var colorblindModeOption = Instantiate(itemPrefab).GetComponent<SettingListItemView>();
        colorblindModeOption.Init("Colorblind mode:", () => SM.ColorblindOption,
            e => SM.ColorblindOption = (ToggleOption)e, typeof(ToggleOption));

        AddItem(colorblindModeOption);


        var reducedMotionOption = Instantiate(itemPrefab).GetComponent<SettingListItemView>();
        reducedMotionOption.Init("Reduced motion:", () => SM.ReducedMotion,
            e => SM.ReducedMotion = (ToggleOption)e, typeof(ToggleOption));

        AddItem(reducedMotionOption);


        var languageOption = Instantiate(itemPrefab).GetComponent<SettingListItemView>();
        languageOption.Init("Language:", () => SM.LanguageOption,
            e => SM.LanguageOption = (LanguageOption)e, typeof(LanguageOption));

        AddItem(languageOption);

        #endregion

        #region NotificationSettings

        var notificationHeader = Instantiate(headerPrefab).GetComponent<SettingSectionHeader>();
        notificationHeader.Init("Notification setting",
            rectTransform.rect.width - HORIZONTAL_MARGIN * 2);

        AddItem(notificationHeader);


        var messageNotificationOption = Instantiate(itemPrefab).GetComponent<SettingListItemView>();
        messageNotificationOption.Init("Message:", () => SM.MessageNotificationOption,
            e => SM.MessageNotificationOption = (ToggleOption)e, typeof(ToggleOption));

        AddItem(messageNotificationOption);


        var employeesLoggedInNotificationOption =
            Instantiate(itemPrefab).GetComponent<SettingListItemView>();
        employeesLoggedInNotificationOption.Init("Employees logged in:",
            () => SM.EmployeesLoggedInNotificationOption,
            e => SM.EmployeesLoggedInNotificationOption = (ToggleOption)e, typeof(ToggleOption));

        AddItem(employeesLoggedInNotificationOption);


        var employeesLoggedOutNotificationOption =
            Instantiate(itemPrefab).GetComponent<SettingListItemView>();
        employeesLoggedOutNotificationOption.Init("Employees logged out:",
            () => SM.EmployeesLoggedOutNotificationOption,
            e => SM.EmployeesLoggedOutNotificationOption = (ToggleOption)e, typeof(ToggleOption));

        AddItem(employeesLoggedOutNotificationOption);


        var MCPsFullyLoadedNotificationOption =
            Instantiate(itemPrefab).GetComponent<SettingListItemView>();
        MCPsFullyLoadedNotificationOption.Init("MCPs fully loaded:",
            () => SM.MCPsFullyLoadedNotificationOption,
            e => SM.MCPsFullyLoadedNotificationOption = (ToggleOption)e, typeof(ToggleOption));

        AddItem(MCPsFullyLoadedNotificationOption);


        var MCPsEmptiedNotificationOption = Instantiate(itemPrefab).GetComponent<SettingListItemView>();
        MCPsEmptiedNotificationOption.Init("MCPs emptied:", () => SM.MCPsEmptiedNotificationOption,
            e => SM.MCPsEmptiedNotificationOption = (ToggleOption)e, typeof(ToggleOption));

        AddItem(MCPsEmptiedNotificationOption);


        var maintenanceLogsUpdatedNotificationOption =
            Instantiate(itemPrefab).GetComponent<SettingListItemView>();
        maintenanceLogsUpdatedNotificationOption.Init("Maintenance logs updated:",
            () => SM.MaintenanceLogsUpdatedNotificationOption,
            e => SM.MaintenanceLogsUpdatedNotificationOption = (ToggleOption)e, typeof(ToggleOption));

        AddItem(maintenanceLogsUpdatedNotificationOption);


        var softwareUpdateAvailableNotificationOption =
            Instantiate(itemPrefab).GetComponent<SettingListItemView>();
        softwareUpdateAvailableNotificationOption.Init("Software update available:",
            () => SM.SoftwareUpdateAvailableNotificationOption,
            e => SM.SoftwareUpdateAvailableNotificationOption = (ToggleOption)e, typeof(ToggleOption));

        AddItem(softwareUpdateAvailableNotificationOption);

        #endregion

        SettingManager.Instance.StartCoroutine(ExecuteDeferredWork());
    }

    public override void AddItem(ListItemView itemView)
    {
        base.AddItem(itemView);
        deferrables.Add(itemView.GetComponent<ITMPDeferrable>());
    }

    private IEnumerator ExecuteDeferredWork()
    {
        yield return null;
        yield return new WaitForSeconds(0.5f);
        foreach (var deferrable in deferrables)
        {
            deferrable.ExecuteDeferredWork();
        }
    }
}