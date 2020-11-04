using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrugSystem
{
    /// <summary>
    /// Interaction logic for SearchLineUC.xaml
    /// </summary>
    public partial class SearchLineUC : UserControl
    {
        public SearchLineUC()
        {
            InitializeComponent();
        }



        public double SearchFontSize {
            get { return (double)GetValue(SearchFontSizeProperty); }
            set { SetValue(SearchFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SearchFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchFontSizeProperty =
            DependencyProperty.Register("SearchFontSize", typeof(double), typeof(SearchLineUC), new FrameworkPropertyMetadata(23.0, FrameworkPropertyMetadataOptions.AffectsRender,
                  new PropertyChangedCallback(StateChangeedCallBack), new CoerceValueCallback(FixValueCallBack)));

        private static void StateChangeedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var result = d as SearchLineUC;
            if (e.Property.Name.Equals("SearchFontSize"))
            {
                result.FontSize = (int)e.NewValue;
            }
        }

        private static object FixValueCallBack(DependencyObject d, object baseValue)
        {
            return baseValue;
        }
    }
}
