using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BLL.BE;
using DrugSystem.ViewModels;

namespace DrugSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CurrentElements _currentElements;
        public CurrentElements CurrentElements {
            get { return _currentElements; }
            set {
                _currentElements = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentElements"));
            }
        }
             
        public App() {
            CurrentElements = new CurrentElements();
        }

    }
}
