using System;

public class MessageData : Data
{
    public string SenderID { get; set; }
    public string ReceiverID { get; set; }

    public DateTime Timestamp { get; set; }
    public string Content { get; set; }
    
    public MessageData(string senderID, string receiverID, DateTime timestamp, string content)
    {
        SenderID = senderID;
        ReceiverID = receiverID;
        Timestamp = timestamp;
        Content = content;
    }
}