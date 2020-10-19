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
        public BllImplementation()
        {
            dal = new DalImplementation();
            validations = new Validations();
        }
        public void AddAdmin(Administrator administrator)
        {
            validations.ValidateAdmin(administrator);
            dal.AddAdmin(administrator);
        }

        public void AddDoctor(Doctor doctor)
        {
            validations.ValidateDoctor(doctor);
            dal.AddDoctor(doctor);        
        }

        public void AddMedicine(Medicine medicine)
        {
            dal.AddMedicine(medicine);
        }

        public void AddOfficer(Officer officer)
        {
            validations.ValidateOfficer(officer);
            dal.AddOfficer(officer);
        }

        public void AddPatient(Patient patient)
        {
            validations.ValidatePatient(patient);
            dal.AddPatient(patient);
        }

        public void AddPrescription(Prescription prescription)
        {
            dal.AddPrescription(prescription);
        }

        public User GetLoginUser(string userMail, string Password)
        {
            User user = dal.GetUserByEmail(userMail);
            if(user == null)
            {
                throw new ArgumentException("User Dosn't Exist");
            }
            if (!user.Passowrd.Equals(Password))
            {
                throw new ArgumentException("Wrong Password");
            }
            return dal.GetUserByEmail(userMail);
        }

        public bool VerifyLogIn(string EmailAddress, string Password)
        {
            User user = dal.GetUserByEmail(EmailAddress);
            return (user.Passowrd.Equals(Password));
        }
    }
}
