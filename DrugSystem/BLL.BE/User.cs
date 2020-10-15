using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BE
{
    abstract public class User : Person
    {
        public string Passowrd { get; set; }
        public bool AddPerson { get; set; }
        public bool AddMedicine { get; set; }
        public bool UpdatePatientDetails { get; set; }
        public bool CreatePrescriptions { get; set; }
    }
}
