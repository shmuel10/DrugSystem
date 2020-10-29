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
        private INotifyPropertyChanged _currentViewModel;
        private INotifyPropertyChanged _currentOnShell;
        public Stack<INotifyPropertyChanged> StackOnShell { get; set; }
        public App()
        {
            CurrentViewModel = new LoginUC_VM();
            StackOnShell = new Stack<INotifyPropertyChanged>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public INotifyPropertyChanged CurrentViewModel {
            get { return _currentViewModel; }
            set {
                _currentViewModel = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentViewModel"));
                }
            }
        }

        public INotifyPropertyChanged CurrentOnShell {
            get { return _currentOnShell; }
            set {
                if (_currentOnShell != null)
                {
                    if (StackOnShell.Count > 0 && value == StackOnShell.Peek())
                    {
                        StackOnShell.Pop();
                    }
                    else
                    {
                        StackOnShell.Push(_currentOnShell);
                    }
                }
                _currentOnShell = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentOnShell"));
                }
            }
        }
    }
}
