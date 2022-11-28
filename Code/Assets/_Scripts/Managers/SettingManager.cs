using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : PersistentSingleton<SettingManager>
{
    // @formatter:off
    
    [Header("Interface Settings")]
    public ThemeOption ThemeOption;
    public ToggleOption DarkThemeOption;
    public ToggleOption ReducedMotion;
    public LanguageOption LanguageOption;

    [Header("Notification Settings")]
    public ToggleOption MessageNotificationOption;
    public ToggleOption EmployeesLoggedInNotificationOption;
    public ToggleOption EmployeesLoggedOutNotificationOption;
    public ToggleOption MCPsFullyLoadedNotificationOption;
    public ToggleOption MCPsEmptiedNotificationOption;
    public ToggleOption MaintenanceLogsUpdatedNotificationOption;
    public ToggleOption SoftwareUpdateAvailableNotificationOption;

    [Header("Account Settings")]
    public OnlineStatusOption OnlineStatusOption;
    public ToggleOption AutomaticallyLogOutOption;
    public ToggleOption AutomaticallySendCrashLogsOption;

    // @formatter:on

    public void ExportMessages()
    {
    }

    public void ExportWorkLogs()
    {
    }

    public void ChangePersonalInformation()
    {
    }

    public void ChangePassword()
    {
    }

    public void ReportProblem()
    {
    }

    public void Logout()
    {
    }
}

public enum ToggleOption
{
    On,
    Off,
}

public enum ThemeOption
{
    Green,
    Red,
    Blue,
    Yellow,
    Purple,
    Gray,
}

public enum OnlineStatusOption
{
    Online,
    Busy,
    Offline,
}

public enum LanguageOption
{
    English,
    Vietnamese,
}