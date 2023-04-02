using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TrackerTools;

public sealed class RedactedHttpClient : BaseHttpClient
{
    private TrackerData _trackerData;

    private const string BaseAddress = "https://redacted.ch/";
    
    private static readonly List<HttpClientAction> PermittedActions = new()
    {
        HttpClientAction.Index
    };

    public override void Initialize()
    {
        _client = new HttpClient();
        _trackerData = Config.Instance.GetConfigData(Tracker.Redacted);

        _client.DefaultRequestHeaders.Add("Authorization", _trackerData.Token);
        _client.BaseAddress = new Uri(BaseAddress);
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public override bool CanPerformAction(HttpClientAction httpClientAction)
    {
        return PermittedActions.Contains(httpClientAction);
    }
}

public class IndexApiResponse
{
    public string Status { get; set; }
    public IndexResponseData Response { get; set; }
}

public abstract class BaseResponseData
{
    
}

public class IndexResponseData : BaseResponseData
{
    public string Username { get; set; }
    public int Id { get; set; }
    public string Authkey { get; set; }
    public string Passkey { get; set; }
    public string Api_version { get; set; }
    public Notifications Notifications { get; set; }
    public Userstats Userstats { get; set; }
}

public class Notifications
{
    public int Messages { get; set; }
    public int NotificationsCount { get; set; }
    public bool NewAnnouncement { get; set; }
    public bool NewBlog { get; set; }
    public bool NewSubscriptions { get; set; }
}

public class Userstats
{
    public long Uploaded { get; set; }
    public long Downloaded { get; set; }
    public double Ratio { get; set; }
    public double Requiredratio { get; set; }
    public string Class { get; set; }
}