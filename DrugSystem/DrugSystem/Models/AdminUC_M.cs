﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.BE;

namespace DrugSystem.Models
{
    public class AdminUC_M
    {
        public IBll BL { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Officer> Officers { get; set; }
        public List<Medicine> Medicines { get; set; }
        public AdminUC_M()
        {
            BL = new BllImplementation();
            Doctors = BL.GetAllDoctors();
            Patients = BL.GetAllPatients();
            Officers = BL.GetAllOfficers();
            Medicines = BL.GetAllMedicines();
        }
    }
}
