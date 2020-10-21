using BLL.BE;
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
        private Validations validations;
        private CheckInteraction checkInteraction;
        public BllImplementation()
        {
            dal = new DalImplementation();
            validations = new Validations();
            checkInteraction = new CheckInteraction();
            //AddAdmin(new Administrator() { BirthDate = new AuxiliaryObjects.Date { Day = 20, Month = 10, Year = 2000 } ,
            //ID = "311215149", EmailAddress="simchapodo@gmail.com", PersonName = new AuxiliaryObjects.Name{ FirstName = "simcha", LastName = "podolsky" }
            //, PhoneNumber="0556679804", Passowrd="Simchap1"}) ;

            //AddAdmin(new Administrator() {
            //    BirthDate = new AuxiliaryObjects.Date { Day = 20, Month = 10, Year = 2000 },
            //    ID = "206322042",
            //    EmailAddress = "noa96f@gmail.com",
            //    PersonName = new AuxiliaryObjects.Name { FirstName = "simcha", LastName = "podolsky" },
            //    PhoneNumber = "0556679804",
            //    Passowrd = "Simchap1"
            //});
            //List<User> users = dal.GetAllUsers();
            //AddMedicine(new Medicine() { CommercialName = "Advil", 
            //ActiveIngredients = new List<string>() { "a", "b", "c" }
            //});
            //Medicine m = dal.GetAllMedicines()[0];
        }
        public void AddAdmin(Administrator administrator)
        {
            try
            {
                validations.ValidateAdmin(administrator);
                dal.AddAdmin(administrator);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void AddDoctor(Doctor doctor)
        {
            try
            {
                validations.ValidateDoctor(doctor);
                dal.AddDoctor(doctor);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void AddMedicine(Medicine medicine)
        {
            try
            {
                validations.ValidateMedicine(medicine);
                medicine.MedicineID = checkInteraction.FindMedicineID(medicine.CommercialName).ToString();
                dal.AddMedicine(medicine);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void AddVisit(Visit visit)
        {
            dal.AddVisit(visit);
        }
        public void AddOfficer(Officer officer)
        {
            try
            {
                validations.ValidateOfficer(officer);
                dal.AddOfficer(officer);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void AddPatient(Patient patient)
        {
            try
            {
                validations.ValidatePatient(patient);
                dal.AddPatient(patient);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void AddPrescription(Prescription prescription)
        {
            try
            {
                validations.ValidatePrescription(prescription);
                dal.AddPrescription(prescription);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public List<Visit> GetAllVisits()
        {
            return dal.getAllVisits();
        }

        public List<Visit> GetAllPatientVisits(string patientID)
        {
            return dal.GetAllPatientVisits(patientID);
        }
        public List<Visit> GetAllDoctorVisits(string doctorID)
        {
            return dal.GetAllDoctorVisits(doctorID);
        }
        public List<Doctor> GetAllDoctors()
        {
            return dal.GetAllDoctors();
        }

        public List<Medicine> GetAllMedicines()
        {
            return dal.GetAllMedicines();
        }

        public List<Officer> GetAllOfficers()
        {
            return dal.GetAllOfficers();
        }

        public List<Patient> GetAllPatients()
        {
            return dal.GetAllPatients();
        }

        public List<Prescription> GetAllPrescriptions()
        {
            return dal.GetAllPrescriptions();
        }

        public List<User> GetAllUsers()
        {
            return dal.GetAllUsers();
        }

        public Doctor GetDoctor(string DocrorsID)
        {
            return dal.GetDoctor(DocrorsID);
        }

        public User GetLoginUser(string userMail, string Password)
        {
            User user = dal.GetUserByEmail(userMail);
            if (user == null)
            {
                throw new ArgumentException("User Dosn't Exist");
            }
            if (!user.Passowrd.Equals(Password))
            {
                throw new ArgumentException("Wrong Password");
            }
            return dal.GetUserByEmail(userMail);
        }

        public Medicine GetMedicine(string MedicineID)
        {
            return dal.GetMedicine(MedicineID);
        }

        public Officer GetOfficer(string OfficerID)
        {
            return dal.GetOfficer(OfficerID);
        }

        public Patient GetPatient(string PatientID)
        {
            return dal.GetPatient(PatientID);
        }

        public List<Prescription> GetPatientsPrescriptions(string PatientID)
        {
            return dal.GetPatientsPrescriptions(PatientID);
        }

        public User GetUserByEmail(string emailAddress)
        {
            return dal.GetUserByEmail(emailAddress);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            dal.UpdateDoctor(doctor);
        }

        public void UpdateMedicine(Medicine medicine)
        {
            dal.UpdateMedicine(medicine);
        }

        public void UpdateOfficer(Officer officer)
        {
            dal.UpdateOfficer(officer);
        }

        public void UpdatePatient(Patient patient)
        {
            dal.UpdatePatient(patient);
        }

        public bool VerifyLogIn(string EmailAddress, string Password)
        {
            User user = dal.GetUserByEmail(EmailAddress);
            return (user.Passowrd.Equals(Password));
        }
    }
}
