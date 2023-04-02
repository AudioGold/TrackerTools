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
    private const string RequestUri = "ajax.php?action=index";

    public void Initialize()
    {
        _client = new HttpClient();
        _trackerData = Config.Instance.GetConfigData(Tracker.Orpheus);

        _client.DefaultRequestHeaders.Add("Authorization", _trackerData.Token);
        _client.BaseAddress = new Uri(BaseAddress);
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public async Task<ResponseData?> AsyncGetIndex()
    {
        var response = await _client.GetAsync(RequestUri);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<ApiResponse>(result, options);

            return data.Response;
        }

        Console.WriteLine("Internal server Error");
        return null;
    }
}