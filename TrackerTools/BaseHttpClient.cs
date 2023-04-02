using System.Net.Http;
using System.Threading.Tasks;

namespace TrackerTools;

public abstract class BaseHttpClient
{
    protected HttpClient? _client;

    public abstract void Initialize();
    public abstract bool CanPerformAction(HttpClientAction httpClientAction);
    
    public async Task<IndexResponseData?> AsyncGetActionResponse(HttpClientAction httpClientAction)
    {
        if (CanPerformAction(httpClientAction) == false)
            return null;
        
        var action = HttpClientActionFactory.GetAction(httpClientAction);
        return (IndexResponseData) await action.PerformAction(_client);
    }
}