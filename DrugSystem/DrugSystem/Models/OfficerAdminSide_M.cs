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
    public class OfficerAdminSide_M
    {
        public List<Gender> Gender { get; set; }
        public IBll BL { get; set; }
        public OfficerAdminSide_M()
        {
            BL = new BllImplementation();
            Gender = new List<Gender>();
            Gender.Add(AuxiliaryObjects.Gender.זכר);
            Gender.Add(AuxiliaryObjects.Gender.נקבה);
            Gender.Add(AuxiliaryObjects.Gender.אחר);
        }
        public void UpdateOfficer(Officer officer)
        {
            BL.UpdateOfficer(officer);
        }
    }
}
