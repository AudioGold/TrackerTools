using System.Collections.Generic;
using TrackerTools.RestApi.Clients;

namespace TrackerTools.RestApi.ApiResponses.Common.Inbox;

public class InboxApiResponse : BaseApiResponse
{
    public ResponseData Response { get; set; }
}

public class ResponseData : BaseResponseData
{
    public int CurrentPage { get; set; }
    public int Pages { get; set; }
    public List<Message> Messages { get; set; }
}

public class Message
{
    public int ConvId { get; set; }
    public string Subject { get; set; }
    public bool Unread { get; set; }
    public bool Sticky { get; set; }
    public int ForwardedId { get; set; }
    public string ForwardedName { get; set; }
    public int SenderId { get; set; }
    public string Username { get; set; }
    public bool Donor { get; set; }
    public bool Warned { get; set; }
    public bool Enabled { get; set; }
    public string Date { get; set; }
}
