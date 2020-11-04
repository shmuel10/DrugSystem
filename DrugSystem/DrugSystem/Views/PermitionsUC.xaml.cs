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



        public bool CanAddPrescription {
            get { return (bool)GetValue(CanAddPrescriptionProperty); }
            set { SetValue(CanAddPrescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanAddPrescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanAddPrescriptionProperty =
            DependencyProperty.Register("CanAddPrescription", typeof(bool), typeof(PermitionsUC), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender,
                   new PropertyChangedCallback(StateChangeedCallBack), new CoerceValueCallback(FixValueCallBack)));



        public bool CanAddDoctor {
            get { return (bool)GetValue(CanAddDoctorProperty); }
            set { SetValue(CanAddDoctorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanAddDoctor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanAddDoctorProperty =
            DependencyProperty.Register("CanAddDoctor", typeof(bool), typeof(PermitionsUC), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender,
                  new PropertyChangedCallback(StateChangeedCallBack), new CoerceValueCallback(FixValueCallBack)));



        public bool CanAddPatient {
            get { return (bool)GetValue(CanAddPatientProperty); }
            set { SetValue(CanAddPatientProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanAddPatient.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanAddPatientProperty =
            DependencyProperty.Register("CanAddPatient", typeof(bool), typeof(PermitionsUC), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender,
                    new PropertyChangedCallback(StateChangeedCallBack), new CoerceValueCallback(FixValueCallBack)));



        public bool CanAddMedicine {
            get { return (bool)GetValue(CanAddMedicineProperty); }
            set { SetValue(CanAddMedicineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanAddMedicine.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanAddMedicineProperty =
            DependencyProperty.Register("CanAddMedicine", typeof(bool), typeof(PermitionsUC), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender,
                   new PropertyChangedCallback(StateChangeedCallBack), new CoerceValueCallback(FixValueCallBack)));

        private static void StateChangeedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var result = d as PermitionsUC;
            if (e.Property.Name.Equals("CanAddPrescription"))
            {
                result.Prescription.IsChecked = (bool)e.NewValue;
            }
            else if (e.Property.Name.Equals("CanAddDoctor"))
            {
                result.Doctor.IsChecked = (bool)e.NewValue;
            }
            else if (e.Property.Name.Equals("CanAddPatient"))
            {
                result.Patient.IsChecked = (bool)e.NewValue;
            }
            else if (e.Property.Name.Equals("CanAddMedicine"))
            {
                result.Medicine.IsChecked = (bool)e.NewValue;
            }
        }

        private static object FixValueCallBack(DependencyObject d, object baseValue)
        {
            return baseValue;
        }



  
    }
}
