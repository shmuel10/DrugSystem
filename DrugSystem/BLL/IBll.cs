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
        void AddAdmin(Administrator administrator);
        void AddDoctor(Doctor doctor);
        void AddOfficer(Officer officer);
        void AddMedicine(Medicine medicine);
        void AddPatient(Patient patient);
        void AddPrescription(Prescription prescription);
        bool VerifyLogIn(string EmailAddress, string Password);    
    }
}
