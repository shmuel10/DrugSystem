using System.Collections.Generic;
using BLL;
using BLL.BE;

namespace DrugSystem.ViewModels
{
    public class DoctorUC_M
    {
        public IBll BL { get; set; }
        public List<Patient> Patients { get; set; }

        public DoctorUC_M()
        {
            BL = new BllImplementation();
            Patients = BL.GetAllPatients();
        }
    }
}