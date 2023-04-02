using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrackerTools;

public class OrpheusHttpClient : Singleton<OrpheusHttpClient>
{
    private HttpClient? _client;
    private TrackerData _trackerData;

    private const string BaseAddress = "https://orpheus.network/";
    
    public void Initialize()
    {
        _client = new HttpClient();
        _trackerData = Config.Instance.GetConfigData(Tracker.Orpheus);

        _client.DefaultRequestHeaders.Add("Authorization", _trackerData.Token);
        _client.BaseAddress = new Uri(BaseAddress);
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var indexAction = new IndexHttpClientAction();
    }
    
    public async Task<IndexResponseData?> AsyncGetIndex()
    {
        var indexAction = HttpClientActionFactory.GetAction(HttpClientAction.Index);
        return (IndexResponseData) await indexAction.PerformAction(_client);
    }
}

