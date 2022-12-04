using System;
using TMPro;
using UnityEngine;

public class StaffInformationPanel : InformationPanel<StaffData>
{
    [SerializeField] private TMP_Text staffName;
    [SerializeField] private TMP_Text role;
    [SerializeField] private TMP_Text genderAndAge;
    [SerializeField] private TMP_Text address;
    [SerializeField] private TMP_Text phoneNumber;

    protected override void SetData(StaffData data)
    {
        staffName.text = data.Name;
        role.text = data.Role.ToString();
        genderAndAge.text = data.Gender + ", " + (DateTime.Today - data.DateOfBirth).Days / 365;
        address.text = data.HomeAddress;
        phoneNumber.text = data.PhoneNumber;
    }
}