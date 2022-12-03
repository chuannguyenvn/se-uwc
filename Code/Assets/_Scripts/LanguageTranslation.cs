using System;
using System.Collections.Generic;
using System.Globalization;

public static class LanguageTranslation
{
    public enum TextType
    {
        Staff_Role_Collector,
        Staff_Role_Janitor,
        Staff_Currently_At,
        Staff_Is_Driving,

        Major_Collecting_Point,
        MCP_Not_Full,
        MCP_Almost_Full,
        MCP_Fully_Loaded,

        Vehicle_Vehicle,
        Vehicle_Model,
        Vehicle_Weight,
        Vehicle_Capacity,
        Vehicle_Fuel_Consumption,

        Setting_On,
        Setting_Off,
        Setting_English,
        Setting_Vietnamese,
        Setting_Interface_Setting,
        Setting_Theme,
        Setting_Dark_Theme,
        Setting_Colorblind_Mode,
        Setting_Reduced_Motion,
        Setting_Language,
        Setting_Notification_Setting,
        Setting_Message,
        Setting_Employees_Logged_In,
        Setting_Employees_Logged_Out,
        Setting_MCPs_Fully_Loaded,
        Setting_MCPs_Emptied,
        Setting_Maintenance_Log_Updated,
        Setting_Software_Update_Available,
    }

    private static Dictionary<LanguageOption, Dictionary<TextType, string>> Translation = new()
    {
        {
            LanguageOption.English,
            new Dictionary<TextType, string>
            {
                {TextType.Staff_Role_Collector, "collector"},
                {TextType.Staff_Role_Janitor, "janitor"},
                {TextType.Staff_Currently_At, "currently at"},
                {TextType.Staff_Is_Driving, "is driving"},
                {TextType.Major_Collecting_Point, "major collecting point"},
                {TextType.MCP_Not_Full, "not full"},
                {TextType.MCP_Almost_Full, "almost full"},
                {TextType.MCP_Fully_Loaded, "fully loaded"},
                {TextType.Vehicle_Vehicle, "vehicle"},
                {TextType.Vehicle_Model, "model"},
                {TextType.Vehicle_Weight, "weight"},
                {TextType.Vehicle_Capacity, "capacity"},
                {TextType.Vehicle_Fuel_Consumption, "fuel consumption"},
                {TextType.Setting_On, "on"},
                {TextType.Setting_Off, "off"},
                {TextType.Setting_English, "english"},
                {TextType.Setting_Vietnamese, "vietnamese"},
                {TextType.Setting_Interface_Setting, "interface setting"},
                {TextType.Setting_Theme, "theme"},
                {TextType.Setting_Dark_Theme, "dark theme"},
                {TextType.Setting_Colorblind_Mode, "colorblind mode"},
                {TextType.Setting_Reduced_Motion, "reduced motion"},
                {TextType.Setting_Language, "language"},
                {TextType.Setting_Notification_Setting, "notification setting"},
                {TextType.Setting_Message, "message"},
                {TextType.Setting_Employees_Logged_In, "employees logged in"},
                {TextType.Setting_Employees_Logged_Out, "employees logged out"},
                {TextType.Setting_MCPs_Fully_Loaded, "MCPs fully loaded"},
                {TextType.Setting_MCPs_Emptied, "MCPs emptied"},
                {TextType.Setting_Maintenance_Log_Updated, "maintenance log updated"},
                {TextType.Setting_Software_Update_Available, "software update available"},
            }
        },
        {
            LanguageOption.Vietnamese,
            new Dictionary<TextType, string>
            {
                {TextType.Staff_Role_Collector, "người thu gom"},
                {TextType.Staff_Role_Janitor, "lao công"},
                {TextType.Major_Collecting_Point, "điểm thu gom chính"},
            }
        }
    };

    public enum ReturnTextOption
    {
        lower_case,
        UPPER_CASE,
        Sentence_case,
        Title_Case,
    }

    public static string GetText(TextType textType, ReturnTextOption returnTextOption)
    {
        var rawText = Translation[SettingManager.Instance.LanguageOption][textType];

        switch (returnTextOption)
        {
            case ReturnTextOption.lower_case:
                return rawText;
            case ReturnTextOption.UPPER_CASE:
                return rawText.ToUpper();
            case ReturnTextOption.Sentence_case:
                return rawText[0].ToString().ToUpper() + rawText[1..];
            case ReturnTextOption.Title_Case:
                return new CultureInfo("en-US", false).TextInfo.ToTitleCase(rawText);
            default:
                throw new ArgumentOutOfRangeException(nameof(returnTextOption), returnTextOption, null);
        }
    }
}