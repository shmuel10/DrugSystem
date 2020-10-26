using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.BE;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.Models
{
    public class AddNewDoctorUC_M
    {
        IBll BL;
        public AuxiliaryObjects AuxiliaryObjects { get; set; }
        public Doctor Doctor { get; set; }
        public List<Gender> Gender { get; set; }
        public AddNewDoctorUC_M()
        {
            BL = new BllImplementation();
            Doctor = new Doctor();
            AuxiliaryObjects = new AuxiliaryObjects();
            Gender = new List<Gender>();
            Gender.Add(AuxiliaryObjects.Gender.זכר);
            Gender.Add(AuxiliaryObjects.Gender.נקבה);
            Gender.Add(AuxiliaryObjects.Gender.אחר);
        }

        public void AddNewDoctor(Doctor doctor)
        {
            BL.AddDoctor(doctor);
        }     
    }
}
