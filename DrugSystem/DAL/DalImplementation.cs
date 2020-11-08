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
            if (GetAllAdmins().Count == 0)
            {
                Administrator defaultAdmin = new Administrator() {
                    BirthDate = new DateTime(2000, 1, 1),
                    BuildingNumber = "10",
                    CanAddDoctor = true,
                    CanAddMedicine = true,
                    CanAddPatient = true,
                    CanCreatePrescriptions = false,
                    City = "Netanya",
                    EmailAddress = "admin@gmail.com",
                    FirstName = "Yossi",
                    Gender = Gender.זכר,
                    ID = "311215149",
                    LastName = "Zaguri",
                    Password = "Admin1234",
                    PhoneNumber = "0501234567",
                    Street = "Yehuda Halevi"
                };
                AddAdmin(defaultAdmin);
            }

        }

        //Admins DB
        public void AddAdmin(Administrator administrator)
        {
            ThrowExceptionIfPrsonExist(administrator);
            try
            {
                DB.PersonsTable.Add(administrator);
                DB.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("לא ניתן לשמור, בדוק את הנתונים");
            }
        }

        //Users DB
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
            userToUpdate.CanAddDoctor = updatedUser.CanAddDoctor;
            userToUpdate.CanAddMedicine = updatedUser.CanAddMedicine;
            userToUpdate.CanCreatePrescriptions = updatedUser.CanCreatePrescriptions;
            userToUpdate.CanAddPatient = updatedUser.CanAddPatient;
            userToUpdate.ProfileImagePath = updatedUser.ProfileImagePath;
            updatedUser.ProfileImageSrc = updatedUser.ProfileImageSrc;
        }
        public List<User> GetAllUsers()
        {
            return GetAllElementsOfTypeT<User>();
        }
        public List<Administrator> GetAllAdmins()
        {
            return GetAllElementsOfTypeT<Administrator>();
        }
        public User GetUserByEmail(string emailAddress)
        {
            try
            {
                User result = DB.PersonsTable.Where(user => user.EmailAddress.Equals(emailAddress.Trim())).FirstOrDefault() as User;
                return result;
            }
            catch
            {
                throw new ArgumentException("לא ניתן לקבל את המשתמש");
            }
        }

        //Officers DB
        public void AddOfficer(Officer officer)
        {
            ThrowExceptionIfPrsonExist(officer);
            try
            {
                DB.PersonsTable.Add(officer);
                DB.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("לא ניתן לשמור את הפקיד");
            }
        }
        public void UpdateOfficer(Officer officer)
        {
            Officer officerToUpdate = GetOfficer(officer.ID);
            UpdateUser(officerToUpdate, officer);
            try
            {
                DB.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("לא ניתן לעדכן את הפרטים");
            }
        }
        public Officer GetOfficer(string OfficerID)
        {
            try
            {
                Officer officer = DB.PersonsTable.Find(OfficerID) as Officer;
                return officer ?? throw new ArgumentException("לא ניתן למצוא את הפקיד המבוקש");
            }
            catch
            {
                throw new ArgumentException("לא ניתן לבצע את הפעולה");
            }
        }
        public List<Officer> GetAllOfficers()
        {
            return GetAllElementsOfTypeT<Officer>();
        }

        //Doctors DB
        public void AddDoctor(Doctor doctor)
        {
            ThrowExceptionIfPrsonExist(doctor);
            try
            {
                DB.PersonsTable.Add(doctor);
                DB.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("לא ניתן למצוא את הרופא המבוקש במערכת");
            }
        }
        public void UpdateDoctor(Doctor doctor)
        {
            try
            {
                Doctor doctorToUpdate = GetDoctor(doctor.ID);
                UpdateUser(doctorToUpdate, doctor);
                doctorToUpdate.Specialty = doctor.Specialty;
                doctorToUpdate.LicenceNumber = doctor.LicenceNumber;
                DB.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("לא ניתן להשלים את הפעולה");
            }
        }
        public Doctor GetDoctor(string DocrorsID)
        {
            try
            {
                Doctor doctor = DB.PersonsTable.Find(DocrorsID) as Doctor;
                return doctor ?? throw new ArgumentException("לא ניתן למצוא את הרופא המבוקש במערכת");
            }
            catch
            {
                throw new ArgumentException("לא ניתן להשלים את הפעולה");
            }
        }
        public List<Doctor> GetAllDoctors()
        {
            return GetAllElementsOfTypeT<Doctor>();
        }

        //Patients DB
        public void AddPatient(Patient patient)
        {
            ThrowExceptionIfPrsonExist(patient);
            try
            {
                DB.PersonsTable.Add(patient);
                DB.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("לא ניתן להוסיף פציינט למערכת, אנא בדוק את הפרטים");
            }
        }
        public void UpdatePatient(Patient patient)
        {
            try
            {
                Patient patientToUpdate = GetPatient(patient.ID);
                UpdatePerson(patientToUpdate, patient);
                patientToUpdate.FamilyDoctor = patient.FamilyDoctor;
                patientToUpdate.Weight = patient.Weight;
                patientToUpdate.FatherName = patient.FatherName;
                DB.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("לא ניתן לעדכן פרטים כעת");
            }
        }
        public Patient GetPatient(string PatientID)
        {
            try
            {
                Patient patient = DB.PersonsTable.Find(PatientID) as Patient;
                return patient ?? throw new ArgumentException("לא נמצאו פרטי פציינט במערכת");
            }
            catch
            {
                throw new ArgumentException("לא נמצאו פרטי פציינט במערכת");
            }
        }
        public List<Patient> GetAllPatients()
        {
            return GetAllElementsOfTypeT<Patient>();
        }

        //Visits DB
        public void AddVisit(Visit visit)
        {
            try
            {
                DB.VisitsTable.Add(visit);
                DB.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("לא ניתן לשמור ביקור, אנא בדוק את הפרטים");
            }
        }
        public List<Visit> GetAllVisits()
        {
            try
            {
                return DB.VisitsTable.ToList();
            }
            catch
            {
                throw new ArgumentException("לא ניתן לקבל נתונים");
            }
        }
        public List<Visit> GetAllPatientVisits(string patientID)
        {
            try
            {
                return DB.VisitsTable.Where(visit => visit.PatientID.Equals(patientID)).ToList();
            }
            catch
            {
                throw new ArgumentException("לא ניתן לקבל נתונים");
            }
        }
        public List<Visit> GetAllDoctorVisits(string doctorID)
        {
            try
            {
                return DB.VisitsTable.Where(visit => visit.DoctorID.Equals(doctorID)).ToList();
            }
            catch
            {
                throw new ArgumentException("לא ניתן לקבל נתונים");
            }
        }
        //Prescription DB
        public void AddPrescription(Prescription prescription)
        {
            ThrowExceptionIfPrescriptionExist(prescription);
            try
            {
                DB.PrescriptionsTable.Add(prescription);
                DB.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("לא ניתן להוסיף מרשם");
            }
        }
        public List<Prescription> GetPatientsPrescriptions(string PatientID)
        {
            if (DB.PersonsTable.Find(PatientID) == null)
            {
                throw new ArgumentException("פציינט לא זוהה במערכת");
            }
            return DB.PrescriptionsTable.Where(prescription => prescription.PatientID == PatientID).ToList();
        }
        public List<Prescription> GetAllPrescriptions()
        {
            try
            {
                return DB.PrescriptionsTable.ToList();
            }
            catch
            {
                throw new ArgumentException("לא ניתן לקבל נתונים");
            }
        }

        //Medicines DB
        public void AddMedicine(Medicine medicine)
        {
            ThrowExceptionIfMedicineExist(medicine);
            try
            {
                DB.MedicinesTable.Add(medicine);
                DB.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("לא ניתן לנ=הוסיף תרופה למערכת");
            }
        }
        public void UpdateMedicine(Medicine medicine)
        {
            try
            {
                Medicine medicineToUpdate = GetMedicine(medicine.MedicineID);
                medicineToUpdate.ActiveIngredients = medicine.ActiveIngredients;
                medicineToUpdate.CommercialName = medicine.CommercialName;
                medicineToUpdate.DoseCharacteristics = medicine.DoseCharacteristics;
                medicineToUpdate.GenericName = medicine.GenericName;
                medicineToUpdate.ProfileImageSrc = medicine.ProfileImageSrc;
                medicineToUpdate.ProfileImagePath = medicine.ProfileImagePath;
                medicineToUpdate.Manufacturer = medicine.Manufacturer;
                DB.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("לא ניתן להוסיף תרופה למערכת");
            }
        }
        public string GetMedicineCodeByName(string genericName)
        {
            try
            {
                return DB.MedicinesTable.Where(MedName => MedName.GenericName.Equals(genericName))
                    .Select(Med => Med.MedicineID).FirstOrDefault();
            }
            catch
            {
                throw new ArgumentException("המערכת לא יכולה לספק נתונים כרגע");
            }
        }
        public Medicine GetMedicine(string MedicineID)
        {
            try
            {
                Medicine medicine = DB.MedicinesTable.Find(MedicineID);
                return medicine ?? throw new ArgumentException("תרופה לא זוהתה במערכת");
            }
            catch
            {
                throw new ArgumentException("המערכת לא יכולה לספק נתונים כרגע");
            }
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
            try
            {
                return DB.MedicinesTable.ToList();
            }
            catch
            {
                throw new ArgumentException("המערכת לא יכולה לספק נתונים כרגע");
            }
        }
        public List<string> GetPatientsCurrentMedicinesNames(string PatientID)
        {
            if (DB.PersonsTable.Find(PatientID) == null)
            {
                throw new ArgumentException("פציינט לא זוהה במערכת");
            }
            try
            {
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
            catch
            {
                throw new ArgumentException("המערת לא יכולה לבצע את הפעלה כעת");
            }
        }
        public List<string> GetAllMedicinesByName()
        {
            try
            {
                return DB.MedicinesTable.Select(medicine => medicine.GenericName).ToList();
            }
            catch
            {
                throw new ArgumentException("המערת לא יכולה לבצע את הפעלה כעת");
            }
        }
        private bool IsMedicineStillTaken(DateTime prescriptionExpireDate)
        {
            int result = DateTime.Compare(DateTime.Now, prescriptionExpireDate);
            if (result < 0)
            {
                return true;
            }
            return false;
        }
        public List<string> GetPatientsCurrentMedicinesCodes(string PatientID)
        {
            if (DB.PersonsTable.Find(PatientID) == null)
            {
                throw new ArgumentException("פציינט לא זוהה במערכת");
            }
            try
            {
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
            catch
            {
                throw new ArgumentException("המערת לא יכולה לבצע את הפעלה כעת");
            }
        }

        //Exeptions
        private List<T> GetAllElementsOfTypeT<T>()
        {
            try
            {
                return DB.PersonsTable.OfType<T>().ToList();
            }
            catch
            {
                throw new ArgumentException("המערכת לא יכולה לספק את הנתונים המבוקשים");
            }
        }
        private void ThrowExceptionIfPrsonExist(Person person)
        {
            if (DoesElementExistInPersonsDB(user => user.ID == person.ID))
            {
                throw new ArgumentException("מספר זהות כבר שמור במערכת");
            }

            if (DoesElementExistInPersonsDB(user => user.EmailAddress == person.EmailAddress))
            {
                throw new ArgumentException("כתובת המייל כבר שמורה במערכת");
            }
        }
        private void ThrowExceptionIfMedicineExist(Medicine medicine)
        {
            if (DB.MedicinesTable.Find(medicine.MedicineID) != null)
            {
                throw new ArgumentException("תרופה כבר שמורה במערכת");
            }
        }
        private void ThrowExceptionIfPrescriptionExist(Prescription prescription)
        {
            if (DB.PrescriptionsTable.Find(prescription.PrescriptionID) != null)
            {
                throw new ArgumentException("קוד מרשם כבר שמור במערכת");
            }
        }
        private bool DoesElementExistInPersonsDB(Func<Person, bool> predicate)
        {
            try
            {
                return DB.PersonsTable.Where(predicate).FirstOrDefault() != null;
            }
            catch
            {
                throw new ArgumentException("המערת לא יכולה לבצע את הפעלה כעת");
            }
        }
    }
}