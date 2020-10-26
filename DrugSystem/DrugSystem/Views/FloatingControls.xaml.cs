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
using DrugSystem.Command;

namespace DrugSystem
{
    /// <summary>
    /// Interaction logic for FloatingControls.xaml
    /// </summary>
    public partial class FloatingControls : UserControl, INotifyPropertyChanged
    {
        public event EventHandler<RoutedEventArgs> ClickHandler;
        public event PropertyChangedEventHandler PropertyChanged;

        ICommand command;
        public FloatingControls()
        {
            InitializeComponent();
            this.DataContext = this;
            command = new NewDoctorCommand(this);
        }
    }
}
