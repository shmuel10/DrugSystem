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
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : Window
    {
        private Grid AdminGr, LoginGr, DrGrid;
        private MenuItem AddNewMed, NewWorker, NewMed, Finish, NewDoctor, NewPatient, NewOfficer, Out;
        public ShellWindow(String user)
        {
            InitializeComponent();

            AddNewMed = new MenuItem();
            NewWorker = new MenuItem();
            NewMed = new MenuItem();
            NewDoctor = new MenuItem();
            NewOfficer = new MenuItem();
            NewPatient = new MenuItem();
            Finish = new MenuItem();
            Out = new MenuItem();

            AddNewMed.Style = null;
            NewWorker.Style = null;
            NewMed.Style = null;
            NewDoctor.Style = null;
            NewOfficer.Style = null;
            NewPatient.Style = null;
            Finish.Style = null;
            Out.Style = null;

            NewWorker.Header = "עובדים";
            NewMed.Header = "תרופות";
            Finish.Header = "סיום";

            NewDoctor.Header = "רופא חדש";
            NewPatient.Header = "מטופל חדש";
            NewOfficer.Header = "פקיד חדש";
            AddNewMed.Header = "תרופה חדשה";
            Out.Header = "יציאה";

            NewWorker.Items.Add(NewDoctor);
            NewWorker.Items.Add(NewOfficer);
            NewWorker.Items.Add(NewPatient);

            NewMed.Items.Add(AddNewMed);

            Finish.Items.Add(Out);

            AppMenu.Items.Add(NewWorker);
            AppMenu.Items.Add(NewMed);
            AppMenu.Items.Add(Finish);

          
            //AdminGr = this.AdminGrid;
            //DrGrid = this.DoctorGrid;
            //if (user == "Doctor")
            //{
            //    AdminGr.Visibility = Visibility.Collapsed;
            //    DrGrid.Visibility = Visibility.Visible;
            //}
            //else if (user == "Admin")
            //{
            //    AdminGr.Visibility = Visibility.Visible;
            //    DrGrid.Visibility = Visibility.Collapsed;
            //}
        }

    }
}
