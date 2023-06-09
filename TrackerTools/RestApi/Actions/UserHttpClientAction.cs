using System.Collections.Generic;
using TrackerTools.Utility;

namespace TrackerTools.RestApi.Actions;

public class UserHttpClientActionData : BaseHttpClientActionData
{
    private readonly int _id;

    public UserHttpClientActionData(int id)
    {
        Action = HttpClientAction.User;
        _id = id;
    }

    public override List<ActionArgument> GetArguments()
    {
        return new List<ActionArgument>
        {
            new (ActionArgumentType.Id, _id.ToString())
        };
    }
}