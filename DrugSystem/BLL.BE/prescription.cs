using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BE
{
    class Prescription
    {
        public Patient PatientDetailes { get; set; }
        public Medicine MedicineDetailes { get; set; }

        public Doctor DoctorDetailes { get; set; }


    }
}
