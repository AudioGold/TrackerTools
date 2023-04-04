using System.Collections.Generic;
using System.ComponentModel;
using TrackerTools.Utility;

namespace TrackerTools.RestApi.Actions;

public class InboxHttpClientActionData : BaseHttpClientActionData
{
    private readonly int _page;
    private readonly Type _type;
    private readonly string _sort;
    private readonly string _search;
    private readonly SearchType _searchType;

    public enum Type
    {
        [Description("inbox")]
        Inbox = 0,
        [Description("sentbox")]
        SentBox = 1
    }
    
    public enum SearchType
    {
        [Description("subject")]
        Subject = 0,
        [Description("message")]
        Message = 1,
        [Description("user")]
        User = 2
    }

    public InboxHttpClientActionData(int page, Type type, string sort, string search, SearchType searchType)
    {
        _searchType = searchType;
        _search = search;
        _sort = sort;
        _type = type;
        _page = page;
        Action = HttpClientAction.Inbox;
    }

    public override List<ActionArgument> GetArguments()
    {
        return new List<ActionArgument>
        {
            new (ActionArgumentType.Page, _page.ToString()),
            new (ActionArgumentType.Type, _type.GetDescription()),
            new (ActionArgumentType.Sort, _sort),
            new (ActionArgumentType.Search, _search),
            new (ActionArgumentType.SearchType, _searchType.GetDescription())
        };
    }
}