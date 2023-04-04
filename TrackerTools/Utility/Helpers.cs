using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace TrackerTools.Utility;

public static class Helpers
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? items)
    {
        return items == null || !items.Any();
    }
    
    public static string GetDescription<T>(this T e) where T : IConvertible
    {
        if (e is Enum)
        {
            var type = e.GetType();
            var values = System.Enum.GetValues(type);

            foreach (int val in values)
            {
                if (val == e.ToInt32(CultureInfo.InvariantCulture))
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttribute = memInfo[0]
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null)
                    {
                        return descriptionAttribute.Description;
                    }
                }
            }
        }

        return null; // could also return string.Empty
    }
}