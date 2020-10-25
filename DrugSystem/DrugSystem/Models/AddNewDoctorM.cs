using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.BE;

namespace DrugSystem.Models
{
    class AddNewDoctorM
    {
        IBll BL;
        public Doctor Doctor { get; set; }
        public AddNewDoctorM()
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
