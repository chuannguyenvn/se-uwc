public class MessageDataListItemView : DataListItemView<MessageData>
{
    public override void SetData(MessageData data)
    {
        PrimaryText = data.Content;
        SecondaryText = data.Timestamp.ToShortTimeString();
    }
}