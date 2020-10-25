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
    /// Interaction logic for FloatingControls.xaml
    /// </summary>
    public partial class FloatingControls : UserControl
    {
        public event EventHandler<RoutedEventArgs> ClickHandler;
        public FloatingControls()
        {
            InitializeComponent();
        }

        private void New_Med_Button_Click(object sender, RoutedEventArgs e)
        {
            if(ClickHandler != null)
            {
                ClickHandler.Invoke(sender, e);
            }          
        }
    }
}
