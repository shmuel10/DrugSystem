using BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static BLL.BE.AuxiliaryObjects;

namespace BLL
{
    class Validations
    {
        private bool ValidatePerson(Person person)
        {
            return ValidateEmailAddress(person.EmailAddress) &
            ValidateID(person.ID) &
            ValidateName(person.FirstName) &
            ValidateName(person.LastName) &
            ValidatePhoneNumber(person.PhoneNumber) &
            ValidateBirthDate(person.BirthDate);
        }
        private bool ValidateUser(User user)
        {
            return ValidatePerson(user) &
                ValidatePassword(user.Passowrd);
        }
        public bool ValidateAdmin(Administrator administrator)
        {
            return ValidateUser(administrator);
        }

        public bool ValidateMedicine(Medicine medicine)
        {
            if(medicine.CommercialName == null)
            {
                throw new ArgumentException("Mediciens Commercial Name is Required");
            }
            return true;
        }

        public bool ValidateDoctor(Doctor doctor)
        {
            return ValidateUser(doctor);
        }
        public bool ValidateOfficer(Officer officer)
        {
            return ValidateUser(officer);
        }
        public bool ValidatePatient(Patient patient)
        {
            return ValidatePerson(patient);
        }

        public bool ValidatePrescription(Prescription prescription)
        {
            string ErrorMessage = null;
            if (prescription.DoctorLicenceNumber == null)
            {
                ErrorMessage += "Doctor Licence Number is Missing\n";
            }
            if (prescription.PrescriptionID == null)
            {
                ErrorMessage += "Patient ID Number is Missing\n";
            }
            if (IsFirstDateLater(prescription.StartDate, prescription.ExpireDate))
            {
                ErrorMessage += "Start Date is after expire date\n";
            }
            if (prescription.MedicineCode == null)
            {
                ErrorMessage += "Medicine Code is Missing\n";
            }

            return ErrorMessage == null ? true : throw new ArgumentException(ErrorMessage);
        }

        public bool ValidateEmailAddress(string EmailToValidate)
        {
            try
            {
                new MailAddress(EmailToValidate);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid Email Address");
            }
            return true;
        }

        public bool ValidateID(string id)
        {
            string EerrorMessage = null;
            if (id == null)
            {
                EerrorMessage = "ID is required";
            }
            else if (id.Length != 9)
            {
                EerrorMessage = "ID Number Must Contain 9 Characters";
            }
            else
            {
                char[] idChars = id.ToArray<char>();
                int[] idNumbs = new int[9];
                for (int i = 0; i < 9; ++i)
                {
                    idNumbs[i] = (int)Char.GetNumericValue(idChars[i]);
                }
                int sum = 0, j;
                for (int i = 0; i <= 6; i += 2)
                {
                    sum += idNumbs[i];
                    j = 2 * idNumbs[i + 1];
                    if (j > 9)
                    {
                        j = 1 + j % 10;
                    }
                    sum += j;
                }
                if (10 - (sum % 10) != (int)idNumbs[8])
                {
                    EerrorMessage = "Invalid ID Number";
                }
                else
                {
                    EerrorMessage = null;
                }
            }
            return EerrorMessage == null ? true : throw new ArgumentException(EerrorMessage);
        }
        public bool ValidateBirthDate(Date BirthDate)
        {
            Date now = new Date() { Day = DateTime.Today.Day, Month = DateTime.Today.Month, Year = DateTime.Today.Year };
            if (IsFirstDateLater(BirthDate, now) || !ValidateDate(BirthDate))
            {
                throw new ArgumentException("Invalid Birth Date");
            }

            return true;
        }

        private bool IsFirstDateLater(Date firstDate, Date secoundDate)
        {
            return firstDate.Year > secoundDate.Year || firstDate.Year == secoundDate.Year && firstDate.Month > secoundDate.Month ||
                            firstDate.Year == secoundDate.Year && firstDate.Month == secoundDate.Month && firstDate.Day > secoundDate.Day;
        }

        public bool ValidateDate(Date date)
        {
            return date.Day >= 1 && date.Day <= 31 && date.Month >= 1 && date.Month <= 12;
        }
        public bool ValidateName(string name)
        {
            string ErrorMessage = null;
            if (name == null || name.Length < 1)
            {
                ErrorMessage += "First Name Is requierd\n";
            }

            if (name == null || name.Length < 1)
            {
                ErrorMessage += "Last Name Is requierd";
            }

            return ErrorMessage == null ? true : throw new ArgumentException(ErrorMessage);
        }
        public bool ValidatePassword(string password)
        {
            Regex hasNumber = new Regex(@"[0-9]+");
            Regex hasUpperChar = new Regex(@"[A-Z]+");
            Regex hasMinimum8Chars = new Regex(@".{8,}");
            return hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password)
                && hasMinimum8Chars.IsMatch(password) ?
                true :
                throw new ArgumentException("Password must contain 8 chracters and upper case letters as well as digits");
        }
        public bool ValidatePhoneNumber(string phonenNumber)
        {
            if(phonenNumber == null)
            {
                throw new ArgumentException("Phone Number Is Required");
            }

            Regex phoneRegex = new Regex(@"0([23489]|5[0123458]|77)([0-9]{7})");
            return phoneRegex.IsMatch(phonenNumber) ? true :
                throw new ArgumentException("Invalid Phone Number");
        }
    }
}
