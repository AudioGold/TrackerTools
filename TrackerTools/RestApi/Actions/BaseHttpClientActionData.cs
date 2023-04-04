using System.Collections.Generic;
using TrackerTools.Utility;

namespace TrackerTools.RestApi.Actions;

public abstract class BaseHttpClientActionData
{
    public HttpClientAction Action { get; protected init; }

    public virtual List<ActionArgument>? GetArguments()
    {
        return null;
    }
}