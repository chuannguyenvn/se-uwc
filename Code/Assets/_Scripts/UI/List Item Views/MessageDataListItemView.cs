public class MessageDataListItemView : DataListItemView<MessageData>
{
    public override void SetData(MessageData data)
    {
        PrimaryText = data.Content + " " + data.SenderID;
        SecondaryText = data.Timestamp.ToShortTimeString();

        if (data.SenderID == AccountManager.Instance.AccountID)
            image.color = VisualManager.Instance.PrimaryColor;
        
        UpdateView();
    }
}