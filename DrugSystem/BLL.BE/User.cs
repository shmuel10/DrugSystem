using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BLL.BE
{
    [Table("tblUsers")]
    public abstract class User : Person
    {
        public string Passowrd { get; set; }
        public bool CanAddPerson { get; set; }
        public bool CanAddMedicine { get; set; }
        public bool CanUpdatePatientDetails { get; set; }
        public bool CanCreatePrescriptions { get; set; }
    }
}
