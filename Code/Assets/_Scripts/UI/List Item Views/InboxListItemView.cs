using UnityEngine;


public class InboxListItemView : DataListItemView<Inbox>
{
    public override void SetData(Inbox data)
    {
        PrimaryText = data.RecipientName;

        var latestMessage = data.Messages[0];
        SecondaryText = latestMessage.Content + " · " + latestMessage.Timestamp;
    }
}