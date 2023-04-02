using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrackerTools;

public class OrpheusHttpClient : BaseHttpClient
{
    private TrackerData _trackerData;

    private const string BaseAddress = "https://orpheus.network/";
    
    private static readonly List<HttpClientAction> PermittedActions = new()
    {
        HttpClientAction.Index
    };
    
    public override void Initialize()
    {
        _client = new HttpClient();
        _trackerData = Config.Instance.GetConfigData(Tracker.Orpheus);

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

