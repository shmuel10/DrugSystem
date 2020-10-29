﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using DrugSystem.Command;

namespace DrugSystem.ViewModels
{
    public class ShellUC_VM : INotifyPropertyChanged
    {
        public ICommand NewMedicineCommand { get; set; }
        public ICommand NewPatientCommand { get; set; }
        public ICommand SignOutCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand NewWorkerCommand { get; set; }

        Brush _background;
        public Brush Background { get { return _background; }
            set { _background = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Background"));
                }
            }
        }
        Brush _foreground;
        public Brush Foreground {
            get { return _foreground; }
            set {
                _foreground = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Foreground"));
                }
            }
        }

        bool _darkMode;
        public bool DarkMode {
            get { return _darkMode; }
            set {
                _darkMode = value;
                if (_darkMode)
                {
                    Background = Brushes.Black;
                    Foreground = Brushes.WhiteSmoke;
                }
                else
                {
                    Background = Brushes.WhiteSmoke;
                    Foreground = Brushes.Black;
                }
            }
        }

        public ShellUC_VM()
        {
            DarkMode = false;
            NewWorkerCommand = new NewItemCommand();
            NewMedicineCommand = new NewMedicineCommand();
            NewPatientCommand = new NewPatientCommand();
            SignOutCommand = new SignOutCommand();
            ExitCommand = new ExitCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}