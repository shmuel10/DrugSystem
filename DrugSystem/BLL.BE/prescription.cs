using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.BE.AuxiliaryObjects;

namespace BLL.BE
{
    public enum MedicineType { Pill, Syrup, Suppository }
    public class Prescription
    {
        public string DoctorLicenceNumber { get; set; }
        public string PatientID { get; set; }
        public string MedicineCode { get; set; }
        public Date StartDate { get; set; }
        public Date ExpireDate { get; set; }
        public double TimesADay { get; set; }
        public MedicineType MedicineForm { get; set; }
        public double Amount { get; set; }
    }
}
