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
        User GetLoginUser(string userMail, string Password);



        //Users DB
        List<User> GetAllUsers();

        //Admins DB
        void AddAdmin(Administrator administrator);

        //Doctors DB
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        Doctor GetDoctor(string DocrorsID);
        List<Doctor> GetAllDoctors();

        //Officers DB
        void AddOfficer(Officer officer);
        void UpdateOfficer(Officer officer);
        Officer GetOfficer(string OfficerID);
        List<Officer> GetAllOfficers();

        //Medicines DB
        void AddMedicine(Medicine medicine);
        void UpdateMedicine(Medicine medicine);
        Medicine GetMedicine(string MedicineCode);
        List<Medicine> GetAllMedicines();

        //Patients DB
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        Patient GetPatient(string PatientID);
        List<Patient> GetAllPatients();

        //Prescription DB
        void AddPrescription(Prescription prescription);
        List<Prescription> GetAllPrescriptions();
        List<Prescription> GetPatientsPrescriptions(string PatientID);

        //Visits DB
        void AddVisit(Visit visit);
        List<Visit> GetAllVisits();
        List<Visit> GetAllPatientVisits(string patientID);
        List<Visit> GetAllDoctorVisits(string doctorID);
        List<string> GetPatientsCurrentMedicines(string PatientID);
        List<string> GetPatientsCurrentMedicinesNames(string PatientID);
        List<string> GetInteractionMedicines(string patientID, string medicineID);
    }
}
