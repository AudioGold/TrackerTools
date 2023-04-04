using System.Net.Http;
using System.Threading.Tasks;
using TrackerTools.RestApi.Actions;
using TrackerTools.RestApi.ApiResponses;
using TrackerTools.Utility;

namespace TrackerTools.RestApi.Clients;

public abstract class BaseHttpClient
{
    protected HttpClient? Client;

    public abstract void Initialize();
    protected abstract bool CanPerformAction(HttpClientAction httpClientAction);
    
    public async Task<T?> AsyncGetActionResponse<T>(BaseHttpClientActionData actionData) where T : BaseApiResponse
    {
        if (CanPerformAction(actionData.Action) == false || Client == null)
            return null;

        var requestUri = HttpHelpers.UrlTextBuilder(actionData.Action, actionData.GetArguments());
        
        return await HttpHelpers.PerformAction<T>(Client, requestUri);
    }
}

public abstract class BaseResponseData
{
    
}