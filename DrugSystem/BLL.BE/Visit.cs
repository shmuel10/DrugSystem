using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.BE.AuxiliaryObjects;

namespace BLL.BE
{
    [Table("Visits")]
    public class Visit
    {
        [Key]
        public string VisitID { get; set; }
        public string DoctorID { get; set; }
        public string PatientID { get; set; }
        public DateTime VisitDate { get; set; }
        public string VisitReason { get; set; }
        public string VisitConclusion { get; set; }
    }
}
