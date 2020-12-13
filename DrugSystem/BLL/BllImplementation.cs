using BLL.BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BllImplementation : IBll
    {
        private IDAL dal;
        private Validations validations;
        private HandleMedicineAPI medicineApiHandler;
        public BllImplementation()
        {
            dal = new DalImplementation();
            validations = new Validations();
            medicineApiHandler = new HandleMedicineAPI();
        }

        //Admins DB
        public void AddAdmin(Administrator administrator)
        {
            validations.ValidateAdmin(administrator);
            dal.AddAdmin(administrator);
        }

        //Users DB
        public List<User> GetAllUsers()
        {
            return dal.GetAllUsers();
        }
        public User GetLoginUser(string userMail, string Password)
        {
            User user = dal.GetUserByEmail(userMail);
            if (user == null)
            {
                throw new ArgumentException("משתמש לא קיים");
            }
            if (!user.Password.Equals(Password))
            {
                throw new ArgumentException("סיסמה שגויה");
            }
            return user;
        }

        //Officers DB
        public void AddOfficer(Officer officer)
        {
                // validations.ValidateOfficer(officer);
                if (officer.ProfileImagePath != null && officer.ProfileImageSrc != null)
                {
                    File.Create(officer.ProfileImagePath).Close();
                    File.Copy(officer.ProfileImageSrc, officer.ProfileImagePath, true);
                }
                dal.AddOfficer(officer);            
        }
        public void UpdateOfficer(Officer officer)
        {
            if (officer.ProfileImagePath != null && officer.ProfileImageSrc != null)
            {
               File.Create(officer.ProfileImagePath).Close();
                File.Copy(officer.ProfileImageSrc, officer.ProfileImagePath, true);
            }
            dal.UpdateOfficer(officer);
        }
        public Officer GetOfficer(string OfficerID)
        {
            return dal.GetOfficer(OfficerID);
        }
        public List<Officer> GetAllOfficers()
        {
            return dal.GetAllOfficers();
        }

        //Doctors DB
        public void AddDoctor(Doctor doctor)
        {
                //   validations.ValidateDoctor(doctor);
                if (doctor.ProfileImagePath != null && doctor.ProfileImageSrc != null)
                {
                    File.Create(doctor.ProfileImagePath).Close();
                    File.Copy(doctor.ProfileImageSrc, doctor.ProfileImagePath, true);
                }
                dal.AddDoctor(doctor);
        }
        public void UpdateDoctor(Doctor doctor)
        {
            if (doctor.ProfileImagePath != null && doctor.ProfileImageSrc != null)
            {
                File.Create(doctor.ProfileImagePath).Close();
                File.Copy(doctor.ProfileImageSrc, doctor.ProfileImagePath, true);
            }
            dal.UpdateDoctor(doctor);
        }
        public Doctor GetDoctor(string DocrorsID)
        {
            return dal.GetDoctor(DocrorsID);
        }
        public List<Doctor> GetAllDoctors()
        {
            return dal.GetAllDoctors();
        }

        //Patients DB
        public void AddPatient(Patient patient)
        {
                //validations.ValidatePatient(patient);
                dal.AddPatient(patient);
        }
        public void UpdatePatient(Patient patient)
        {
            dal.UpdatePatient(patient);
        }
        public Patient GetPatient(string PatientID)
        {
            return dal.GetPatient(PatientID);
        }
        public List<Patient> GetAllPatients()
        {
            return dal.GetAllPatients();
        }

        //Visits DB
        public void AddVisit(Visit visit)
        {
            //if (dal.GetAllVisits().Count == 0)
            //{
            //    Random random = new Random();
            //    string visitID = Convert.ToString(random.Next(2345465, 999999999));
            //    visit.VisitID = visitID;
            //}
            //else
            //{
            //    int max = Int32.Parse(dal.GetAllPrescriptions().Max(x => x.PrescriptionID));
            //    visit.VisitID = Convert.ToString(max + 1);
            //}
            dal.AddVisit(visit);
        }
        public List<Visit> GetAllVisits()
        {
            return dal.GetAllVisits();
        }
        public List<Visit> GetAllPatientVisits(string patientID)
        {
            return dal.GetAllPatientVisits(patientID);
        }
        public List<Visit> GetAllDoctorVisits(string doctorID)
        {
            return dal.GetAllDoctorVisits(doctorID);
        }

        //Prescription DB
        public void AddPrescription(Prescription prescription)
        {
                //if (dal.GetAllPrescriptions().Count == 0)
                //{
                //    Random random = new Random();
                //    string prescriptionID = Convert.ToString(random.Next(2345465, 999999999));
                //    prescription.PrescriptionID = prescriptionID;
                //}
                //else
                //{
                //    int max = Int32.Parse(dal.GetAllPrescriptions().Max(x => x.PrescriptionID));
                //    prescription.PrescriptionID = Convert.ToString(max + 1);
                //}
                validations.ValidatePrescription(prescription);
                dal.AddPrescription(prescription);
        }
        public List<Prescription> GetAllPrescriptions()
        {
            return dal.GetAllPrescriptions();
        }
        public List<Prescription> GetPatientsPrescriptions(string PatientID)
        {
            return dal.GetPatientsPrescriptions(PatientID);
        }
        public string GeneratePrescriptionSerialNumber()
        {
            string prescriptionID;
            if (dal.GetAllPrescriptions().Count == 0)
            {
                Random random = new Random();
                prescriptionID = Convert.ToString(random.Next(2345465, 999999999));               
            }
            else
            {
                prescriptionID = Convert.ToString(Int32.Parse(dal.GetAllPrescriptions().Max(x => x.PrescriptionID)) + 1);               
            }
            return prescriptionID;
        }

        //Medicines DB
        public void AddMedicine(Medicine medicine)
        {
            
                validations.ValidateMedicine(medicine);
                if (medicine.ProfileImagePath != null && medicine.ProfileImageSrc != null)
                {
                    (File.Create(medicine.ProfileImagePath)).Close();
                    File.Copy(medicine.ProfileImageSrc, medicine.ProfileImagePath, true);
                }
                dal.AddMedicine(medicine);
        }
        public void UpdateMedicine(Medicine medicine)
        {
            if (medicine.ProfileImagePath != null && medicine.ProfileImageSrc != null)
            {
                (File.Create(medicine.ProfileImagePath)).Close();
                File.Copy(medicine.ProfileImageSrc, medicine.ProfileImagePath, true);
            }
            dal.UpdateMedicine(medicine);
        }
        public string GetMedicineCodeIfExistInXML(string medicineName)
        {
            string result = null;
            try
            {
                result = medicineApiHandler.FindMedicineID(medicineName).ToString();
                return result;
            }
            catch
            {
                return result;
            }
        }        
        public List<Medicine> GetAllMedicines()
        {
            return dal.GetAllMedicines();
        }
        public string GetMedicineCodeByName(string genericCode)
        {
            return dal.GetMedicineCodeByName(genericCode);
        }
        public List<string> GetInteractionMedicines(string patientID, string medicineName, string medicineID)
        {
            List<string> abc = medicineApiHandler.GetInteractionMedicinesNames(medicineName, medicineID);
            List<string> abcd = dal.GetPatientsCurrentMedicinesNames(patientID);
            List<string> interaction = abc.Intersect(abcd).ToList();
            return interaction;
        }
        public Medicine GetMedicine(string MedicineID)
        {
            return dal.GetMedicine(MedicineID);
        }        
        public List<string> GetPatientsCurrentMedicines(string PatientID)
        {
            return dal.GetPatientsCurrentMedicinesCodes(PatientID);
        }
        public List<string> GetPatientsCurrentMedicinesNames(string PatientID)
        {
            return dal.GetPatientsCurrentMedicinesNames(PatientID);
        }
        public List<string> GetAllMedicinesByName()
        {
            return dal.GetAllMedicinesByName();
        }
    }
}
