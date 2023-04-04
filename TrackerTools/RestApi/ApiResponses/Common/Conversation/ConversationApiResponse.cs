using System.Collections.Generic;

namespace TrackerTools.RestApi.ApiResponses.Common.Conversation;

public class ConversationApiResponse : BaseApiResponse
{
    public ResponseData Response { get; set; }
}

public class ResponseData
{
    public int ConvId { get; set; }
    public string Subject { get; set; }
    public bool Sticky { get; set; }
    public List<Message> Messages { get; set; }
}

public class Message
{
    public int MessageId { get; set; }
    public int SenderId { get; set; }
    public string SenderName { get; set; }
    public string SentDate { get; set; }
    public string BbBody { get; set; }
    public string Body { get; set; }
}
