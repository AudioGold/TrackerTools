using System.Collections.Generic;
using TrackerTools.Utility;

namespace TrackerTools.RestApi.Actions;

public class UserHttpClientActionData : BaseHttpClientActionData
{
    public readonly int Id;

    public UserHttpClientActionData(int id)
    {
        Action = HttpClientAction.User;
        Id = id;
    }

    public override List<ActionArgument> GetArguments()
    {
        return new List<ActionArgument>
        {
            new (ActionArgumentType.Id, Id.ToString())
        };
    }
}