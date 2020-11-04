using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.BE;

namespace DrugSystem.Models
{
    public class PatientUC_M
    {
        public IBll BL { get; set; }
        public ObservableCollection<Visit> Visits { get; set; }
        public ObservableCollection<string> MedicinesNames { get; set; }
        public ObservableCollection<Prescription> Prescriptions { get; set; }

        public PatientUC_M(string patientID)
        {
            if (patientID != null)
            {
                BL = new BllImplementation();
                Visits = new ObservableCollection<Visit>(BL.GetAllPatientVisits(patientID));
                Prescriptions = new ObservableCollection<Prescription>(BL.GetPatientsPrescriptions(patientID));
                MedicinesNames = new ObservableCollection<string>(BL.GetPatientsCurrentMedicinesNames(patientID));
            }
        }
    }
}
