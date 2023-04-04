using System.Collections.Generic;
using TrackerTools.Utility;

namespace TrackerTools.RestApi.Actions;

public abstract class BaseHttpClientActionData
{
    public HttpClientAction Action;

    public virtual List<ActionArgument>? GetArguments()
    {
        return null;
    }
}