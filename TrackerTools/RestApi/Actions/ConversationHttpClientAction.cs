using System.Collections.Generic;
using TrackerTools.Utility;

namespace TrackerTools.RestApi.Actions;

public class ConversationHttpClientActionData : BaseHttpClientActionData
{
    private readonly int _id;

    public ConversationHttpClientActionData(int id)
    {
        Action = HttpClientAction.Conversation;
        _id = id;
    }

    public override List<ActionArgument> GetArguments()
    {
        return new List<ActionArgument>
        {
            new (ActionArgumentType.Type, "viewconv"),
            new (ActionArgumentType.Id, _id.ToString())
        };
    }
}