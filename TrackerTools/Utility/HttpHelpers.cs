using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TrackerTools.RestApi.Actions;
using TrackerTools.RestApi.ApiResponses;

namespace TrackerTools.Utility;

public class ActionArgument
{
    public readonly ActionArgumentType Type;
    public readonly string Value;

    public ActionArgument(ActionArgumentType type, string value)
    {
        Type = type;
        Value = value;
    }
}

public enum ActionArgumentType
{
    [Description("id")]
    Id,
    [Description("page")]
    Page,
    [Description("type")]
    Type,
    [Description("sort")]
    Sort,
    [Description("search")]
    Search,
    [Description("searchtype")]
    SearchType,
}

public static class HttpHelpers
{
    public static async Task<T?> PerformAction<T>(HttpClient httpClient, string requestUri) where T : BaseApiResponse
    {
        var response = await httpClient.GetAsync(requestUri);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<T>(result, options);

            if (data != null) 
                return data;
        }

        Console.WriteLine("Internal server Error");
        return null;
    }
    
    public static string UrlTextBuilder(HttpClientAction action, List<ActionArgument>? arguments = null)
    {
        var result = $"ajax.php?action={action.GetDescription()}";
        if (arguments.IsNullOrEmpty())
            return result;

        return arguments.Aggregate(result, (current, argument) => current + $"&{argument.Type.GetDescription()}={argument.Value}");
    }
}