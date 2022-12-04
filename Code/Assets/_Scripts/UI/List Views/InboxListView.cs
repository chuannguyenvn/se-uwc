using System;

public class InboxListView : DataListView<Inbox>
{
    public event Action<Inbox> InboxChosen;

    protected override void Init()
    {
        base.Init();

        prefab = ResourceManager.Instance.InboxListItemView;

        var inboxesByID = DatabaseManager.Instance.InboxesByID;
        foreach (var (id, inbox) in inboxesByID)
        {
            AddDataItem(inbox);
        }
    }

    public void OnInboxChosen(Inbox inbox)
    {
        InboxChosen?.Invoke(inbox);
    }
}