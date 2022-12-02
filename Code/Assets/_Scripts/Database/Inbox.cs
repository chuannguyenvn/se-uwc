using System.Collections.Generic;

public class Inbox : Data
{
    public string RecipientID;

    public string RecipientName;

    public List<MessageData> Messages = new();

    public Inbox(string recipientID, string recipientName)
    {
        RecipientID = recipientID;
        RecipientName = recipientName;
    }

    public void SortMessages()
    {
        Messages.Sort((messageA, messageB) => messageA.Timestamp > messageB.Timestamp ? 1 : -1);
    }
}