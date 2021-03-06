﻿using System;
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
    public partial class CurrentElements : INotifyPropertyChanged
    {
        private User _currentUser;
        private INotifyPropertyChanged _currentViewModel;
        private INotifyPropertyChanged _currentOnShell;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public Stack<INotifyPropertyChanged> StackOnShell { get; set; }

        public CurrentElements()
        {
            CurrentUser = new User();
            CurrentViewModel = new LoginUC_VM();
            StackOnShell = new Stack<INotifyPropertyChanged>();
        }

        string _statusBar;
        public string StatusBar { get { return _statusBar; }
            set {
                _statusBar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StatusBar"));
            }
        }
        public Doctor DoctorSelected { get; set; }
        public Patient PatientSelected { get; set; }
        public Officer OfficerSelected { get; set; }
        public Medicine MedicineSelected { get; set; }
        public Visit VisitSelected { get; set; }
        public User CurrentUser {
            get { return _currentUser; }
            set {
                _currentUser = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentUser"));
                }
            }
        }
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