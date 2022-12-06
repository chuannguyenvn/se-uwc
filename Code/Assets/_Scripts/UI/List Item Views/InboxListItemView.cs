using UnityEngine;

public class InboxListItemView : DataListItemView<StaffData>
{
    public override void SetData(StaffData data)
    {
        base.SetData(data);
        
        PrimaryText = data.Name;

        UpdateView();

        button.onClick.AddListener(() => ListViewManager.Instance.InboxListView.OnInboxChosen(data));
    }

    protected override void UpdateView()
    {
        primaryText_TMP.text = PrimaryText;
    }
}