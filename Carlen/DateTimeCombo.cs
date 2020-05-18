using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Carlen
{
    public class DateTimeCombo : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {

                return new object[2] { values[0], values[1] };

            }
            var t = values[2] as BaseDate;

            Debug.WriteLine("(int)values[0]" + (int)values[0]);
            Debug.WriteLine("(int)values[1]"+ (int)values[1]);
            Debug.WriteLine("(values[0]" + values[0]);
            Debug.WriteLine("values[1]" + values[1]);


            t.SetTime((int)values[0], (int)values[1]);

            return t.Time;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
