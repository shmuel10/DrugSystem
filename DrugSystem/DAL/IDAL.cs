﻿using BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL
    {
        //Users DB
        User GetUserByEmail(string emailAddress);
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
        void AddVisit(Visit visit);
        List<Visit> getAllVisits();
        List<Visit> GetAllPatientVisits(string patientID);
        List<Visit> GetAllDoctorVisits(string doctorID);
        List<string> GetPatientsCurrentMedicinesCodes(string PatientID);
        List<string> GetMedicinesNames(List<string> MedicinesID);
        List<string> GetPatientsCurrentMedicinesNames(string patientID);
        List<string> GetAllMedicinesByName();
    }
}
