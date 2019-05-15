using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace SAKD.Converters
{
    public class EnumDisplayNameConverter : MarkupExtension, IValueConverter
    {
        private string GetEnumDisplayName(Enum eValue)
        {
            if (eValue == null)
                return string.Empty;
            var nAttributes = eValue.GetType().GetField(eValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return nAttributes.Any() ? (nAttributes.First() as DescriptionAttribute)?.Description : string.Empty;
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var myEnum = (Enum)value;
            var displayName = GetEnumDisplayName(myEnum);
            return displayName;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
