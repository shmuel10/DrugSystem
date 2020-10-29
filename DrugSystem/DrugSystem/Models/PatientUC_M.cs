using System;
using System.Collections.Generic;
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
        public List<Visit> Visits { get; set; }
        public List<string> MedicinesNames { get; set; }
        public PatientUC_M(string patientID)
        {
            if (patientID != null)
            {
                BL = new BllImplementation();
                Visits = BL.GetAllPatientVisits(patientID);
                MedicinesNames = BL.GetPatientsCurrentMedicinesNames(patientID);
            }
        }
    }
}
