﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BLL.BE;
using DrugSystem.Command;

namespace DrugSystem.ViewModels
{
    public class ShellUC_VM : INotifyPropertyChanged
    {
        public ICommand SignOutCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand NewItemCommand { get; set; }
        public ICommand StackCommand { get; set; }


        BitmapImage _currentUserImg;
        public BitmapImage CurrentUserImg {
            get { return _currentUserImg; }
            set {
                _currentUserImg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentUserImg"));
            }
        }

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

                    Background = new BrushConverter().ConvertFromString("#41506C") as SolidColorBrush;
                    Foreground = Brushes.WhiteSmoke;
                }
                else
                {
                    Background = Brushes.WhiteSmoke;
                    Foreground = Brushes.Black;
                }
            }
        }

        string _statusBar;
        public string StatusBar { get { return _statusBar; } 
            set { _statusBar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StatusBar"));
            }
        }

        string _currentUserName;
        public string CurrentUserName { get { return _currentUserName; }
            set {
                _currentUserName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentUserName"));
            }
        }

        public ShellUC_VM()
        {
            User currentUser =
                ((App)System.Windows.Application.Current).CurrentElements.CurrentUser;
            DarkMode = false;
            NewItemCommand = new NewItemCommand();
            SignOutCommand = new SignOutCommand();
            ExitCommand = new ExitCommand();
            StackCommand = new StackCommand();
            StatusBar = "";
            CurrentUserName = "שלום" + " " +currentUser.FirstName;
            if (File.Exists(currentUser.ProfileImagePath))
            {
                string tempPath = System.IO.Path.GetTempFileName();
                File.Copy(currentUser.ProfileImagePath, tempPath, true);
                CurrentUserImg = new BitmapImage(new Uri(tempPath));
            }
          }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
