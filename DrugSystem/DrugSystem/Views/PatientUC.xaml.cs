﻿using System;
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
using DrugSystem.ViewModels;

namespace DrugSystem.Views
{
    /// <summary>
    /// Interaction logic for PatientUC.xaml
    /// </summary>
    public partial class PatientUC : UserControl
    {
        public PatientUC()
        {
            InitializeComponent();
            DataContext = new PatientUC_VM();
            //DataContext = (App)System.Windows.Application.Current).CurrentOnShell;
        }
    }
}
