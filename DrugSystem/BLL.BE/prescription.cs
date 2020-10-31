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
  //  public enum MedicineType { Pill, Syrup, Suppository }
    [Table("Prescriptions")]
    public class Prescription
    {
        [Key]
        public string PrescriptionID { get; set; }
        public string DoctorID { get; set; }
        public string PatientID { get; set; }
        public string MedicineCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Instructions { get; set; }
    }
}
