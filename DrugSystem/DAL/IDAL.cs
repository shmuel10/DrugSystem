using BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL
    {
        //Admins DB
        void AddAdmin(Administrator administrator);
        
        //Doctors DB
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        Doctor GetDoctor(string DocrorsID);
        List<Doctor> GetDoctors();

        //Officers DB
        void AddOfficer(Officer officer);
        void UpdateOfficer(Officer officer);
        Officer GetOfficer();
        List<Officer> GetOfficers();

        //Medicines DB
        void AddMedicine(Medicine medicine);
        void UpdateMedicine(Medicine medicine);
        Medicine GetMedicine();
        List<Medicine> GetMedicines();

        //Patients DB
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        Patient GetPatient();
        List<Patient> GetPatients();

        //Prescription DB
        void AddPrescription(Prescription prescription);
        List<Prescription> GetPrescriptions();
        List<Prescription> GetPatientsPrescriptions(string PatientID);
    }
}
