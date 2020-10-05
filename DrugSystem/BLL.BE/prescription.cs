using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.BE.AuxiliaryObjects;

namespace BLL.BE
{
    class Prescription
    {
        public Patient PatientDetailes { get; set; }
        public Medicine MedicineDetailes { get; set; }
        public Doctor DoctorDetailes { get; set; }
        public Date MyProperty { get; set; }

    }
}
