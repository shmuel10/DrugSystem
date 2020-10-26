﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
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
        private Window _currentWindow;
        public event PropertyChangedEventHandler PropertyChanged;

        public INotifyPropertyChanged CurrentViewModel {
            get { return _currentViewModel; }
            set 
            {
                _currentViewModel = value; 
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentViewModel"));
                }
            }
        }

        public Window CurrentWindow {
            get { return _currentWindow; }
            set {
                _currentWindow = value;
                _currentWindow.Show();
                if (_currentWindow != null)
                {
                    //Current.MainWindow.Close();
                }   
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentWindow"));
                }
            }
        }

        public App()
        {
            CurrentViewModel = new LoginWindowVM();
        }
    }
}
