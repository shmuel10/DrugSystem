using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DrugSystem.Command;

namespace DrugSystem.ViewModels
{
    class FloatingControlsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand NewItemCommand { get; set; }
        public FloatingControlsVM()
        {
            NewItemCommand = new NewItemCommand();
        }
    }
}
