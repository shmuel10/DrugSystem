﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DrugSystem.Command
{
    public class StackCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return (((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Count > 0);
        }

        public void Execute(object parameter)
        {
            if (((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Count > 0)
            {
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
                ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
            }
        }
    }
}
