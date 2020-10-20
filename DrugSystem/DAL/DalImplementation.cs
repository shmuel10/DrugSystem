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
            //    DoesPersonExist(administrator);
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

        public List<Doctor> GetAllDoctors()
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

        public List<Officer> GetAllOfficers()
        {
            return GetAllElementsOfTypeT<Officer>();
        }

        private List<T> GetAllElementsOfTypeT<T>()
        {
            return DB.PersonsTable.OfType<T>().ToList();
        }
        public List<User> GetAllUsers()
        {
            return GetAllElementsOfTypeT<User>();
        }

        public Patient GetPatient(string PatientID)
        {
            return DB.PersonsTable.Find(PatientID) as Patient;
        }

        public List<Patient> GetAllPatients()
        {
            return GetAllElementsOfTypeT<Patient>();
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
            return DB.PersonsTable.Where(user => user.EmailAddress == emailAddress) as User;
        }
        public bool DoesPersonExist(Person person)
        {
            if (DoesElementExistInDB(user => user.ID == person.ID))
                throw new ArgumentException("The ID number is already stored in the system");
            if (DoesElementExistInDB(user => user.EmailAddress == person.EmailAddress))
                throw new ArgumentException("The email address is already stored in the system");
            return false;

        }
        private bool DoesElementExistInDB(Func<Person, bool> predicate)
        {
            return DB.PersonsTable.Where(predicate).FirstOrDefault() != null;
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
