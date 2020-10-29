using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using static BLL.BE.AuxiliaryObjects;

namespace BLL.BE
{
    [Table("Patients")]
    public class Patient : Person
    {
        private Patient currentPatient;

        public double Weight { get; set; }
        public string FatherName { get; set; }
        public string FamilyDoctor { get; set; }
    }
}
