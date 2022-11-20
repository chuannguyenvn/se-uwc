using UnityEngine;
using UnityEngine.UI;


public class StaffListItemView : ListItemView<StaffData>
{
    public override void SetData(StaffData data)
    {
        PrimaryText = data.Name;
        SecondaryText = data.Role + " - currently at " + data.HomeAddress;

        primaryText_TMP.text = PrimaryText;
        secondaryText_TMP.text = SecondaryText;
    }
}