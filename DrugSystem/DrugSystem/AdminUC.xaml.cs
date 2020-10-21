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
using MahApps.Metro.Controls;

namespace DrugSystem
{
    /// <summary>
    /// Interaction logic for AdminUC.xaml
    /// </summary>
    public partial class AdminUC : UserControl
    {   
        public AdminUC()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewDoctor newd = new AddNewDoctor();
            newd.Show();
        }

        private void Button_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            this.FloatingButtons.Visibility = Visibility.Visible;

            //UserControl userControl = this.FloatingButtons;
            //userControl.Visibility = Visibility.Visible;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            this.FloatingButtons.Visibility = Visibility.Collapsed;
        }
    }
}
