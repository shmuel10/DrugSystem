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
    public partial class PermitionsUC : UserControl, INotifyPropertyChanged
    {
        public PermitionsUC()
        {
            InitializeComponent();
            DataContext = this;
        }


        public bool CanAddDoctor {
            get { return (bool)GetValue(CanAddDoctorDPProperty); }
            set {
                SetValue(CanAddDoctorDPProperty, value);
                PropertyChanged(this, new PropertyChangedEventArgs("CanAddDoctor"));
            }
        }

        public bool CanAddDoctorDP {
            get { return (bool)GetValue(CanAddDoctorDPProperty); }
            set { SetValue(CanAddDoctorDPProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanAddDoctorDP.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanAddDoctorDPProperty =
            DependencyProperty.Register("CanAddDoctorDP", typeof(bool), typeof(PermitionsUC), new PropertyMetadata(false));



        public bool CanAddPatient {
            get { return (bool)GetValue(CanAddPatientDPProperty); }
            set {
                SetValue(CanAddPatientDPProperty, value);
                PropertyChanged(this, new PropertyChangedEventArgs("CanAddPatient"));
            }
        }

        public bool CanAddPatientDP {
            get { return (bool)GetValue(CanAddPatientDPProperty); }
            set { SetValue(CanAddPatientDPProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanAddPatientDP.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanAddPatientDPProperty =
            DependencyProperty.Register("CanAddPatientDP", typeof(bool), typeof(PermitionsUC), new PropertyMetadata(false));



        public bool CanAddPrescription { get { return (bool)GetValue(CanAddPrescriptionDPProperty); }
            set {
                SetValue(CanAddPrescriptionDPProperty, value);
                PropertyChanged(this, new PropertyChangedEventArgs("CanAddPrescription")); } }

        public bool CanAddPrescriptionDP {
            get { return (bool)GetValue(CanAddPrescriptionDPProperty); }
            set { SetValue(CanAddPrescriptionDPProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanAddPrescriptionDP.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanAddPrescriptionDPProperty =
            DependencyProperty.Register("CanAddPrescriptionDP", typeof(bool), typeof(PermitionsUC), new PropertyMetadata(false));



        public bool CanAddMedicine { get { return (bool)GetValue(CanAddMedicineDPProperty); }
            set {
                SetValue(CanAddMedicineDPProperty, value);
                PropertyChanged(this, new PropertyChangedEventArgs("CanAddMedicine"));
            } }
    

        public bool CanAddMedicineDP {
            get { return (bool)GetValue(CanAddMedicineDPProperty); }
            set { SetValue(CanAddMedicineDPProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanAddMedicineDP.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanAddMedicineDPProperty =
            DependencyProperty.Register("CanAddMedicineDP", typeof(bool), typeof(PermitionsUC), new PropertyMetadata(false));


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
