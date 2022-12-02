public class InboxListView : DataListView<Inbox>
{
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        prefab = ResourceManager.Instance.InboxListItemView;

        var inboxesByID = DatabaseManager.Instance.InboxesByID;
        foreach (var (id, inbox) in inboxesByID)
        {
            AddDataItem(inbox);
        }
    }
}