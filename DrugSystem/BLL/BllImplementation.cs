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
            List<User> users = dal.GetAllUsers();
        }
        public void AddAdmin(Administrator administrator)
        {
            try
            {
                validations.ValidateAdmin(administrator);
                dal.AddAdmin(administrator);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void AddDoctor(Doctor doctor)
        {
            validations.ValidateDoctor(doctor);
            dal.AddDoctor(doctor);        
        }

        public void AddMedicine(Medicine medicine)
        {
            validations.ValidateMedicine(medicine);
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
            validations.ValidatePrescription(prescription);
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
