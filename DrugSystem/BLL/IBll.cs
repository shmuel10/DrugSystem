using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BE;

namespace BLL
{
    public interface IBll
    {
        //Admins DB
        void AddAdmin(Administrator administrator);

        //Users DB
        List<User> GetAllUsers();
        User GetLoginUser(string userMail, string Password);

        //Officers DB
        void AddOfficer(Officer officer);
        void UpdateOfficer(Officer officer);
        Officer GetOfficer(string OfficerID);
        List<Officer> GetAllOfficers();

        //Doctors DB
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        Doctor GetDoctor(string DocrorsID);
        List<Doctor> GetAllDoctors();

        //Patients DB
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        Patient GetPatient(string PatientID);
        List<Patient> GetAllPatients();

        //Visits DB
        void AddVisit(Visit visit);
        List<Visit> GetAllVisits();
        List<Visit> GetAllPatientVisits(string patientID);
        List<Visit> GetAllDoctorVisits(string doctorID);

        //Prescription DB
        void AddPrescription(Prescription prescription);
        List<Prescription> GetAllPrescriptions();
        List<Prescription> GetPatientsPrescriptions(string PatientID);
        string GeneratePrescriptionSerialNumber();

        //Medicines DB
        void AddMedicine(Medicine medicine);
        void UpdateMedicine(Medicine medicine);
        Medicine GetMedicine(string MedicineCode);
        List<Medicine> GetAllMedicines();
        List<string> GetAllMedicinesByName();
        string GetMedicineCodeByName(string genericName);
        List<string> GetPatientsCurrentMedicines(string PatientID);
        List<string> GetPatientsCurrentMedicinesNames(string PatientID);
        string GetMedicineCodeIfExistInXML(string medicineName);
        List<string> GetInteractionMedicines(string patientID, string medicineName, string medicineID);
    }
}
