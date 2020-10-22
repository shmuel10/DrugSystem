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
using System.Windows.Shapes;

namespace DrugSystem
{
    /// <summary>
    /// Interaction logic for VisitWindow.xaml
    /// </summary>
    public partial class VisitWindow : Window
    {
        public VisitWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.MedChoose.Visibility == Visibility.Collapsed)
                this.MedChoose.Visibility = Visibility.Visible;
            else
                this.MedChoose.Visibility = Visibility.Collapsed;
        }
    }
}
