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
    /// Interaction logic for AddNewDoctorUC.xaml
    /// </summary>
    public partial class AddNewDoctorUC : UserControl
    {
        public AddNewDoctorUC()
        {
            InitializeComponent();
            DataContext = new AddNewDoctorUC_VM();
        }




        //    public bool Shmulik {
        //        get { return (bool)GetValue(ShmulikProperty); }
        //        set { SetValue(ShmulikProperty, value); }
        //    }

        //    // Using a DependencyProperty as the backing store for Shmulik.  This enables animation, styling, binding, etc...
        //    public static readonly DependencyProperty ShmulikProperty =
        //        DependencyProperty.Register("Shmulik", typeof(bool), typeof(AddNewDoctorUC), new PropertyMetadata(null));
        //}
    }
}
