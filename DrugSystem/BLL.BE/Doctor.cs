using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BE
{
    [Table("Doctors")]
    public class Doctor : User
    {
        [Index(IsUnique =true), MaxLength(15)]
        public string LicenceNumber { get; set; }
        public string Specialty { get; set; }
    }
}
