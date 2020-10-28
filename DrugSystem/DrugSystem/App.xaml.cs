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
        private INotifyPropertyChanged _onFrame;
        private bool _frameVisibility;
        private Window _currentWindow;
        public event PropertyChangedEventHandler PropertyChanged;

        public INotifyPropertyChanged OnFrame { get { return _onFrame; }
            set {
                _onFrame = value;
                if (PropertyChanged != null)
                {
                    FrameVisibility = true;
                    PropertyChanged(this, new PropertyChangedEventArgs("OnFrame"));
                }
            }
        }

        public bool FrameVisibility {
            get { return _frameVisibility; }
            set {
                _frameVisibility = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("FrameVisibility"));
                }
            }
        }


        public INotifyPropertyChanged CurrentViewModel {
            get { return _currentViewModel; }
            set 
            {
                _currentViewModel = value; 
                if(PropertyChanged != null) 
                {
                    FrameVisibility = false;
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentViewModel"));
                }
            }
        }

        public Window CurrentWindow {
            get { return _currentWindow; }
            set {
                if (_currentWindow == null)
                {
                    _currentWindow = Current.MainWindow;
                }
                
                    value.Show();
                    _currentWindow.Close();
                    _currentWindow = value;
                
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
