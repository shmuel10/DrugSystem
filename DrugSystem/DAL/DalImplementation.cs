using BLL.BE;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace DAL
{
    public class DalImplementation : IDAL
    {
        DrugSystemContext DB = new DrugSystemContext();
        public DalImplementation()
        {

        }

        public void AddAdmin(Administrator administrator)
        {
            DB.AdminsTable.Add(administrator);
            DB.SaveChanges();
        }

        public void AddDoctor(Doctor doctor)
        {

            DB.PersonsTable.Add(doctor);
            DB.SaveChanges();
        }

        public void AddMedicine(Medicine medicine)
        {
            DB.MedicinesTable.Add(medicine);
            DB.SaveChanges();
        }

        public void AddOfficer(Officer officer)
        {
            DB.PersonsTable.Add(officer);
            DB.SaveChanges();
        }

        public void AddPatient(Patient patient)
        {
            DB.PersonsTable.Add(patient);
            DB.SaveChanges();
        }

        public void AddPrescription(Prescription prescription)
        {
            DB.PrescriptionsTable.Add(prescription);
            DB.SaveChanges();
        }

        public Doctor GetDoctor(string DocrorsID)
        {
            return DB.PersonsTable.Find(DocrorsID) as Doctor;
        }

        public List<Doctor> GetDoctors()
        {
            throw new NotImplementedException();
        }

        public Medicine GetMedicine(string MedicineCode)
        {
            return DB.MedicinesTable.Find(MedicineCode);
        }

        public List<Medicine> GetMedicines()
        {
            throw new NotImplementedException();
        }

        public Officer GetOfficer(string OfficerID)
        {
            return DB.PersonsTable.Find(OfficerID) as Officer;
        }

        public List<Officer> GetOfficers()
        {
            throw new NotImplementedException();
        }

        public Patient GetPatient(string PatientID)
        {
            return DB.PersonsTable.Find(PatientID) as Patient;
        }

        public List<Patient> GetPatients()
        {
            throw new NotImplementedException();
        }

        public List<Prescription> GetPatientsPrescriptions(string PatientID)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> GetPrescriptions()
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string emailAddress)
        {
            return DB.PersonsTable.Where(user => user.EmailAddress == emailAddress).FirstOrDefault() as User;
        }

        public void UpdateDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void UpdateMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void UpdateOfficer(Officer officer)
        {
            throw new NotImplementedException();
        }

        public void UpdatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
