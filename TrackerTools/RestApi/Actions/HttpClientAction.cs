using System.ComponentModel;

namespace TrackerTools.RestApi.Actions;

public enum HttpClientAction
{
    [Description("index")]
    Index = 0,
    
    [Description("user")]
    User = 1,
}