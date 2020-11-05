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
using DrugSystem.ViewModels;

namespace DrugSystem.Views
{
    /// <summary>
    /// Interaction logic for PdfViewerUC.xaml
    /// </summary>
    public partial class PdfViewerUC : UserControl
    {
        public PdfViewerUC()
        {
            InitializeComponent();
        }

        public string PdfPath {
            get { return (string)GetValue(PdfPathProperty); }
            set { SetValue(PdfPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PdfPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PdfPathProperty =
            DependencyProperty.Register("PdfPath", typeof(string), typeof(PdfViewerUC),
                new FrameworkPropertyMetadata("path", FrameworkPropertyMetadataOptions.AffectsRender,
                    new PropertyChangedCallback(StateChangeedCallBack), new CoerceValueCallback(FixValueCallBack)));

        private static void StateChangeedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var result = d as PdfViewerUC;
            if (e.NewValue != null)
            {
                result.MyBrows.Source = new Uri(e.NewValue.ToString());
            }
        }

        private static object FixValueCallBack(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

    }
}
