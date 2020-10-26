using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DrugSystem
{
    /// <summary>
    /// Interaction logic for PermitionsUC.xaml
    /// </summary>
    public partial class PermitionsUC : UserControl
    {
        public PermitionsUC()
        {
            InitializeComponent();
            DataContext = this;
        }

        //public static readonly DependencyProperty CreateDoctorProperty =
        //    DependencyProperty.Register("CreateDoctor", typeof(Boolean), typeof(PermitionsUC));
        //public bool CreateDoctor {
        //    get { return (bool)GetValue(CreateDoctorProperty); }
        //    set { SetValue(CreateDoctorProperty, value); }
        //}
        bool Add;

        public bool CreateDoctor { get { return Add; } set { Add = value; } }
        public bool CreatePatient { get; set; }
        public bool CreatePrescription { get; set; }
        // public DependencyProperty CreateDoctor { get; set; }
    }
}
