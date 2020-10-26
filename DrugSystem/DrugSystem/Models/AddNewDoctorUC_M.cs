using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.BE;

namespace DrugSystem.Models
{
    public class AddNewDoctorUC_M
    {
        IBll BL;
        public Doctor Doctor { get; set; }
        public AddNewDoctorUC_M()
        {
            BL = new BllImplementation();
            Doctor = new Doctor();
        }

        public void AddNewDoctor(Doctor doctor)
        {
            BL.AddDoctor(doctor);
        }     
    }
}
