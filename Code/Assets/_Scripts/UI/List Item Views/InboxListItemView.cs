using UnityEngine;

public class InboxListItemView : DataListItemView<Inbox>
{
    public override void SetData(Inbox data)
    {
        base.SetData(data);
        
        PrimaryText = data.RecipientName;

        UpdateView();

        button.onClick.AddListener(() => ListViewManager.Instance.InboxListView.OnInboxChosen(data));
    }

    protected override void UpdateView()
    {
        primaryText_TMP.text = PrimaryText;
    }
}