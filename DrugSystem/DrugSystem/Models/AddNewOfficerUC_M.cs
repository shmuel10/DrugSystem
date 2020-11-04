using System;
using System.Collections.Generic;
using BLL;
using BLL.BE;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.Models
{
    public class AddNewOfficerUC_M
    {
        IBll BL;
        public List<Gender> Gender { get; set; }
        public AddNewOfficerUC_M()
        {
            BL = new BllImplementation();
            Gender = new List<Gender>();
            Gender.Add(AuxiliaryObjects.Gender.זכר);
            Gender.Add(AuxiliaryObjects.Gender.נקבה);
            Gender.Add(AuxiliaryObjects.Gender.אחר);
        }

        public void AddNewOfficer(Officer officer)
        {
            BL.AddOfficer(officer);
        }
    }
}