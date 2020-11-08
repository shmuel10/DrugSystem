using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        public List<string> MedicinesName { get; set; }

        public AdminUC_M()
        {
            BL = new BllImplementation();
            Doctors = BL.GetAllDoctors();
            Patients = BL.GetAllPatients();
            Officers = BL.GetAllOfficers();
            Medicines = BL.GetAllMedicines();
            MedicinesName = BL.GetAllMedicinesByName();
        }

        public ObservableCollection<KeyValuePair<string, int>> GetMedsUses(string medName)
        {
            ObservableCollection<KeyValuePair<string, int>> result =
                    new ObservableCollection<KeyValuePair<string, int>>();
            if (medName != "")
            {
                DateTime dateTime;
                string medCode = BL.GetMedicineCodeByName(medName);
                List<Prescription> prescriptions =
                    BL.GetAllPrescriptions().Where(x => x.MedicineCode.Equals(medCode)).ToList();
                for (int i = 11; i >= 0; --i)
                {
                    dateTime = DateTime.Now.AddMonths(-i);
                    result.Add(new KeyValuePair<string, int>(dateTime.Month.ToString() + "/" +
                        dateTime.Year.ToString(), prescriptions
                        .Where(x => x.StartDate.Month.Equals(dateTime.Month) &&
                        x.StartDate.Year.Equals(dateTime.Year)).Count()));
                }                
            }
            return result;
        }
    }
}
