using System.ComponentModel;

namespace TrackerTools.RestApi.Actions;

public enum HttpClientAction
{
    [Description("index")]
    Index,
    [Description("user")]
    User,
    [Description("inbox")]
    Inbox,
}