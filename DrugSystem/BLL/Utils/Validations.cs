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
            ValidateName(person.PersonName) &
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
            if (id.Equals(null))
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
            if (BirthDate.Day < 1 || BirthDate.Day > 31 || BirthDate.Month < 1 || BirthDate.Month > 12 || BirthDate.Year < 1900 || BirthDate.Year > 2021)
                throw new ArgumentException("Invalid Birth Date");
            return true;
        }
        public bool ValidateName(Name name)
        {
            string ErrorMessage = null;
            if (name.FirstName.Length < 1)
                ErrorMessage += "First Name Is requierd\n";
            if (name.LastName.Length < 1)
                ErrorMessage += "Last Name Is requierd";
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
                throw new ArgumentException("Password must contain upper case letters as well as digits");
        }
        public bool ValidatePhoneNumber(string phonenNumber)
        {
            Regex phoneRegex = new Regex(@"0([23489]|5[0123458]|77)([0-9]{7}");
            return phoneRegex.IsMatch(phonenNumber) ? true :
                throw new ArgumentException("Invalid Phone Number");
        }
    }
}
