using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugSystem.Models;

namespace DrugSystem.ViewModels
{
    public class PrescriptionUC_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        PrescriptionUC_M _prescriptionUC_M;
        public PrescriptionUC_VM()
        {
            _prescriptionUC_M = new PrescriptionUC_M();
        }
    }
}
