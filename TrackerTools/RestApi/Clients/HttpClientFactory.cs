using System;
using System.Collections.Generic;

namespace TrackerTools.RestApi.Clients;

public static class HttpClientFactory
{
    private static readonly Dictionary<Tracker, BaseHttpClient> Clients = new();

    public static BaseHttpClient GetClient(Tracker tracker)
    {
        if (Clients.ContainsKey(tracker))
        {
            return Clients[tracker];
        }

        BaseHttpClient client = tracker switch
        {
            Tracker.Redacted => new RedactedHttpClient(),
            Tracker.Orpheus => new OrpheusHttpClient(),
            _ => throw new ArgumentOutOfRangeException(nameof(tracker), $"Tracker '{tracker}' not supported."),
        };
        
        client.Initialize();

        Clients[tracker] = client;
        
        return client;
    }
}