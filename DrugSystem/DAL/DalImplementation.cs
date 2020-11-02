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
using static BLL.BE.AuxiliaryObjects;
using System.Data.Entity.Validation;

namespace DAL
{
    public class DalImplementation : IDAL
    {
        DrugSystemContext DB;
        public DalImplementation()
        {
            DB = new DrugSystemContext();
        }
        #region add to DB
        public void AddAdmin(Administrator administrator)
        {
            ThrowExceptionIfPrsonExist(administrator);
            DB.PersonsTable.Add(administrator);
            DB.SaveChanges();
        }

        public void AddVisit(Visit visit)
        {
            DB.VisitsTable.Add(visit);
            DB.SaveChanges();
        }

        public void AddDoctor(Doctor doctor)
        {
            try
            {
                ThrowExceptionIfPrsonExist(doctor);
                DB.PersonsTable.Add(doctor);
                DB.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var errors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in errors.ValidationErrors)
                    {
                        // get the error message 
                        string errorMessage = validationError.ErrorMessage;
                    }
                }
            }
        }

        public void AddOfficer(Officer officer)
        {
            ThrowExceptionIfPrsonExist(officer);
            DB.PersonsTable.Add(officer);
            DB.SaveChanges();
        }

        public void AddPatient(Patient patient)
        {
            ThrowExceptionIfPrsonExist(patient);
            DB.PersonsTable.Add(patient);
            DB.SaveChanges();
        }
        public void AddMedicine(Medicine medicine)
        {
            ThrowExceptionIfMedicineExist(medicine);
            DB.MedicinesTable.Add(medicine);
            DB.SaveChanges();
        }

        public void AddPrescription(Prescription prescription)
        {
            ThrowExceptionIfPrescriptionExist(prescription);
            DB.PrescriptionsTable.Add(prescription);
            DB.SaveChanges();  
        }
        #endregion

        #region update DB
        public void UpdateDoctor(Doctor doctor)
        {
            Doctor doctorToUpdate = GetDoctor(doctor.ID);
            UpdateUser(doctorToUpdate, doctor);
            doctorToUpdate.Specialty = doctor.Specialty;
            doctorToUpdate.LicenceNumber = doctor.LicenceNumber;
            DB.SaveChanges();
        }
        private void UpdatePerson(Person personToUpdate, Person updatedPerson)
        {
            personToUpdate.Gender = updatedPerson.Gender;
            personToUpdate.EmailAddress = updatedPerson.EmailAddress;
            personToUpdate.City = updatedPerson.City;
            personToUpdate.Street = updatedPerson.Street;
            personToUpdate.BuildingNumber = updatedPerson.BuildingNumber;
            personToUpdate.FirstName = updatedPerson.FirstName;
            personToUpdate.LastName = updatedPerson.LastName;
            personToUpdate.PhoneNumber = updatedPerson.PhoneNumber;
        }
        private void UpdateUser(User userToUpdate, User updatedUser)
        {
            UpdatePerson(userToUpdate, updatedUser);
            userToUpdate.Password = updatedUser.Password;
        }

        public void UpdateMedicine(Medicine medicine)
        {
            Medicine medicineToUpdate = GetMedicine(medicine.MedicineID);
            medicineToUpdate.ActiveIngredients = medicine.ActiveIngredients;
            medicineToUpdate.CommercialName = medicine.CommercialName;
            medicineToUpdate.DoseCharacteristics = medicine.DoseCharacteristics;
            medicineToUpdate.GenericName = medicine.GenericName;
            medicineToUpdate.ImageUrl = medicine.ImageUrl;
            medicineToUpdate.Manufacturer = medicine.Manufacturer;
            DB.SaveChanges();
        }

        public void UpdateOfficer(Officer officer)
        {
            Officer officerToUpdate = GetOfficer(officer.ID);
            UpdateUser(officerToUpdate, officer);
            DB.SaveChanges();
        }

        public void UpdatePatient(Patient patient)
        {
            Patient patientToUpdate = GetPatient(patient.ID);
            UpdatePerson(patientToUpdate, patient);
            patientToUpdate.FamilyDoctor = patient.FamilyDoctor;
            patientToUpdate.Weight = patient.Weight;
            patientToUpdate.FatherName = patient.FatherName;
            DB.SaveChanges();
        }
        #endregion

        #region get elements from DB
        public Doctor GetDoctor(string DocrorsID)
        {
            Doctor doctor = DB.PersonsTable.Find(DocrorsID) as Doctor;
            return doctor ?? throw new ArgumentException("Doctor Dosn't exist");
        }

        public List<Doctor> GetAllDoctors()
        {
            return GetAllElementsOfTypeT<Doctor>();
        }
        public List<Visit> getAllVisits()
        {
            return DB.VisitsTable.ToList();
        }

        public List<Visit> GetAllPatientVisits(string patientID)
        {
            return DB.VisitsTable.Where(visit => visit.PatientID.Equals(patientID)).ToList();
        }


        public List<Visit> GetAllDoctorVisits(string doctorID)
        {
            return DB.VisitsTable.Where(visit => visit.DoctorID.Equals(doctorID)).ToList();
        }

        public string GetMedicineCodeByName(string genericName)
        {
            return DB.MedicinesTable.Where(MedName => MedName.GenericName.Equals(genericName))
                .Select(Med => Med.MedicineID).FirstOrDefault();
        }

        public Medicine GetMedicine(string MedicineID)
        {
            Medicine medicine = DB.MedicinesTable.Find(MedicineID);
            return medicine ?? throw new ArgumentException("Medicine Dosn't exist");
        }

        public List<string> GetMedicinesNames(List<string> MedicinesID)
        {
            List<string> medicinesNames = new List<string>();
            if (MedicinesID != null)
            {
                foreach (string medicineId in MedicinesID)
                {
                    medicinesNames.Add(GetMedicine(medicineId).CommercialName);
                }
            }
            return medicinesNames;
        }

        public List<Medicine> GetAllMedicines()
        {
            return DB.MedicinesTable.ToList();
        }

        public Officer GetOfficer(string OfficerID)
        {
            Officer officer = DB.PersonsTable.Find(OfficerID) as Officer;
            return officer ?? throw new ArgumentException("Officer Dosn't exist");
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
            Patient patient = DB.PersonsTable.Find(PatientID) as Patient;
            return patient ?? throw new ArgumentException("Patient Dosn't exist");
        }

        public List<Patient> GetAllPatients()
        {
            return GetAllElementsOfTypeT<Patient>();
        }

        public List<Prescription> GetPatientsPrescriptions(string PatientID)
        {
            if (DB.PersonsTable.Find(PatientID) == null)
            {
                throw new ArgumentException("Patient Dosn't exist");
            }
            return DB.PrescriptionsTable.Where(prescription => prescription.PatientID == PatientID).ToList();
        }
        public List<string> GetPatientsCurrentMedicinesCodes(string PatientID)
        {
            if (DB.PersonsTable.Find(PatientID) == null)
            {
                throw new ArgumentException("Patient Dosn't exist");
            }
            List<Prescription> prescriptions = DB.PrescriptionsTable.Where(prescription =>
            prescription.PatientID == PatientID).ToList();
            List<string> medicineCodes = new List<string>();
            foreach (var pres in prescriptions)
            {
                if (IsMedicineStillTaken(pres.ExpireDate))
                {
                    medicineCodes.Add(pres.MedicineCode);
                }
            }
            return GetMedicinesNames(medicineCodes);
        }
        public List<Prescription> GetAllPrescriptions()
        {
            return DB.PrescriptionsTable.ToList();
        }

        public User GetUserByEmail(string emailAddress)
        {
            User result = DB.PersonsTable.Where(user => user.EmailAddress.Equals(emailAddress.Trim())).FirstOrDefault() as User;
            return result;
        }
        #endregion
        private bool IsMedicineStillTaken(DateTime prescriptionExpireDate)
        {
            int result = DateTime.Compare(DateTime.Now, prescriptionExpireDate);
            if (result < 0)
            {
                return true;
            }
            return false;
        }

        private void ThrowExceptionIfPrsonExist(Person person)
        {
            if (DoesElementExistInPersonsDB(user => user.ID == person.ID))
            {
                throw new ArgumentException("The ID number is already stored in the system");
            }

            if (DoesElementExistInPersonsDB(user => user.EmailAddress == person.EmailAddress))
            {
                throw new ArgumentException("The email address is already stored in the system");
            }
        }
        private void ThrowExceptionIfMedicineExist(Medicine medicine)
        {
            if (DB.MedicinesTable.Find(medicine.MedicineID) != null)
            {
                throw new ArgumentException("Medicine already exist");
            }
        }
        private void ThrowExceptionIfPrescriptionExist(Prescription prescription)
        {
            if (DB.PrescriptionsTable.Find(prescription.PrescriptionID) != null)
            {
                throw new ArgumentException("Medicine already exist");
            }
        }
        private bool DoesElementExistInPersonsDB(Func<Person, bool> predicate)
        {
            return DB.PersonsTable.Where(predicate).FirstOrDefault() != null;
        }

        public List<string> GetPatientsCurrentMedicinesNames(string PatientID)
        {
            if (DB.PersonsTable.Find(PatientID) == null)
            {
                throw new ArgumentException("Patient Dosn't exist");
            }
            List<Prescription> prescriptions = DB.PrescriptionsTable.Where(prescription =>
            prescription.PatientID == PatientID).ToList();
            List<string> medicineCodes = new List<string>();
            foreach (var pres in prescriptions)
            {
                if (IsMedicineStillTaken(pres.ExpireDate))
                {
                    medicineCodes.Add(pres.MedicineCode);
                }
            }
            return GetMedicinesNames(medicineCodes);
        }

        public List<string> GetAllMedicinesByName()
        {
            return DB.MedicinesTable.Select(medicine => medicine.GenericName).ToList();
        }
    }
}