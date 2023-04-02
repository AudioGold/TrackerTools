using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrackerTools;

public static class HttpClientActionFactory
{
    private static readonly Dictionary<HttpClientAction, IHttpClientAction> Actions = new();

    public static IHttpClientAction GetAction(HttpClientAction actionType)
    {
        if (Actions.ContainsKey(actionType))
        {
            return Actions[actionType];
        }

        IHttpClientAction action = actionType switch
        {
            HttpClientAction.Index => new IndexHttpClientAction(),
            _ => throw new ArgumentOutOfRangeException(nameof(actionType), $"Action '{actionType}' not supported."),
        };

        Actions[actionType] = action;
        
        return action;
    }
}

public enum HttpClientAction
{
    Index = 0
}

public interface IHttpClientAction
{
    public Task<BaseResponseData?> PerformAction(HttpClient httpClient);
}

public sealed class IndexHttpClientAction : IHttpClientAction
{
    private const string RequestUri = "ajax.php?action=index";
    
    public async Task<BaseResponseData?> PerformAction(HttpClient httpClient)
    {
        var response = await httpClient.GetAsync(RequestUri);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<IndexApiResponse>(result, options);

            return data.Response;
        }

        Console.WriteLine("Internal server Error");
        return null;
    }
}