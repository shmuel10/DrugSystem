using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace DrugSystem
{
    public class FontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ComboBoxItem comboBoxItem = value as ComboBoxItem;
            int Size = 0;
            if (value != null)
            {
               Int32.TryParse(comboBoxItem.Content.ToString(), out Size);
            }
            return (double)Size;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
