﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BE
{
    class Doctor : User
    {
        public string LicenceNumber { get; set; }
        public string Specialty { get; set; }
      
        public Prescription CreatePrescription()
        {
            //To Do

            return null;
        }
    }
}
