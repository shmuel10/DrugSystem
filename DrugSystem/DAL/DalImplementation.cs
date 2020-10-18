using BLL.BE;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace DAL
{
    public class DalImplementation : IDAL
    {
        DrugSystemContext db = new DrugSystemContext();
        public DalImplementation()
        {

        }

        public void AddAdmin(Administrator administrator)
        {
            db.testSqls.Add(new testSql("123", "simcha"));
                db.SaveChanges();


        }

        public void AddDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void AddMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void AddOfficer(Officer officer)
        {
            throw new NotImplementedException();
        }

        public void AddPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public void AddPrescription(Prescription prescription)
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctor(string DocrorsID)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctors()
        {
            throw new NotImplementedException();
        }

        public Medicine GetMedicine()
        {
            throw new NotImplementedException();
        }

        public List<Medicine> GetMedicines()
        {
            throw new NotImplementedException();
        }

        public Officer GetOfficer()
        {
            throw new NotImplementedException();
        }

        public List<Officer> GetOfficers()
        {
            throw new NotImplementedException();
        }

        public Patient GetPatient()
        {
            throw new NotImplementedException();
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
