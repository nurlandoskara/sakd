using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SAKD.Models;

namespace SAKD
{
    public static class EnumHelper
    {
        public static List<EnumListItem> EnumList<TE>() where TE : struct, IConvertible
        {
            var enumList = new List<EnumListItem>();
            foreach (Enum item in Enum.GetValues(typeof(TE)))
            {
                enumList.Add(new EnumListItem(Convert.ToInt32(item), Description(item)));
            }

            return enumList;
        }

        public static string Description(Enum eValue)
        {
            if (eValue == null)
                return string.Empty;
            var nAttributes = eValue.GetType().GetField(eValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return nAttributes.Any() ? (nAttributes.First() as DescriptionAttribute)?.Description : string.Empty;
        }
    }
}
