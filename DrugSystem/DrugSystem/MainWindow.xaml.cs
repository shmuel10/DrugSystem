﻿using BLL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrugSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserControl UC;
        Grid AdminGr, LoginGr;
        IBll Bll;
        public MainWindow()
        {
            InitializeComponent();
            Bll = new BllImplementation();
            AdminGr = this.AdminGrid;
            LoginGr = this.LoginGrid;
            AdminGr.Visibility = Visibility.Collapsed;
        }

        public void Login_func(object sender, RoutedEventArgs e)
        {
            LoginGr.Visibility = Visibility.Collapsed;
            AdminGr.Visibility = Visibility.Visible;
        }
    }
}
