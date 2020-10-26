using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BLL.BE
{
    [Table("Users")]
    public class User : Person
    {
        public string Password { get; set; }
        public bool CanAddPerson { get; set; }
        public bool CanAddMedicine { get; set; }
        public bool CanUpdatePatientDetails { get; set; }
        public bool CanCreatePrescriptions { get; set; }
    }
}
