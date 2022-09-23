using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carburanti.Model.Dates
{
    internal class DateTimeCustomTypeConverter : TypeConverter
    {
 
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var casted = value as string;
            return casted != null
                ? new DateOnlyCustom(casted)
                : base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var casted = value as DateOnlyCustom;
            if (casted == null || destinationType == null)
                return null;

            var s = casted.ToString();
            return destinationType == typeof(string)
                ? s
                : base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
