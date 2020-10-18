﻿using BLL.BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BllImplementation : IBll
    {
        private IDAL dal;
        public BllImplementation()
        {
            dal = new DalImplementation();
        }
        public void AddAdmin(Administrator administrator)
        {
            dal.AddAdmin(new Administrator());
        }

        public void AddDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void AddMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void AddOfficer(Officer officer)
        {
            throw new NotImplementedException();
        }

        public void AddPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public void AddPrescription(Prescription prescription)
        {
            throw new NotImplementedException();
        }

        public bool VerifyLogIn(string EmailAddress, string Password)
        {
            throw new NotImplementedException();
        }
    }
}