using TrackerTools.RestApi.Clients;

namespace TrackerTools.RestApi.ApiResponses.Common;

public class IndexApiResponse : BaseApiResponse
{
    public ResponseData Response { get; set; }
}

public class ResponseData : BaseResponseData
{
    public string Username { get; set; }
    public int Id { get; set; }
    public string Authkey { get; set; }
    public string Passkey { get; set; }
    public string Api_version { get; set; }
    public ResponseNotifications Notifications { get; set; }
    public ResponseUserStats UserStats { get; set; }
}

public class ResponseNotifications
{
    public int Messages { get; set; }
    public int NotificationsCount { get; set; }
    public bool NewAnnouncement { get; set; }
    public bool NewBlog { get; set; }
    public bool NewSubscriptions { get; set; }
}

public class ResponseUserStats
{
    public long Uploaded { get; set; }
    public long Downloaded { get; set; }
    public double Ratio { get; set; }
    public double Requiredratio { get; set; }
    public string Class { get; set; }
}