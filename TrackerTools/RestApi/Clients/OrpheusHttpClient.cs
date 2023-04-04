using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using TrackerTools.RestApi.Actions;

namespace TrackerTools.RestApi.Clients;

public class OrpheusHttpClient : BaseHttpClient
{
    private TrackerData? _trackerData;

    private const string BaseAddress = "https://orpheus.network/";
    
    private static readonly List<HttpClientAction> PermittedActions = new()
    {
        HttpClientAction.Index,
        HttpClientAction.User,
        HttpClientAction.Inbox
    };
    
    public override void Initialize()
    {
        try
        {
            Client = new HttpClient();
            _trackerData = Config.Instance.GetConfigData(Tracker.Orpheus);

            Client.DefaultRequestHeaders.Add("Authorization", _trackerData?.Token);
            Client.BaseAddress = new Uri(BaseAddress);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    protected override bool CanPerformAction(HttpClientAction httpClientAction)
    {
        return PermittedActions.Contains(httpClientAction);
    }
}

