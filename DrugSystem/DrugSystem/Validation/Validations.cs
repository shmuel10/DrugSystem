using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace DrugSystem.Validation
{
    public class Validations
    {
        string ErrorMessage;
        public string ValidateID(string id)
        {
            ErrorMessage = string.Empty;
            if (string.IsNullOrEmpty(id))
            {
                ErrorMessage = "יש להזין מספר תעודת זהות";
            }
            else if (id.Length != 9)
            {
                ErrorMessage = "מספר זהות צריך להכיל 9 ספרות";
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
                    ErrorMessage = "מספר זהות לא חוקי";
                }
                else
                {
                    ErrorMessage = string.Empty;
                }
            }
            return ErrorMessage;
        }

        public string ValidatePassword(string password)
        {
            ErrorMessage = string.Empty;
            if (string.IsNullOrEmpty(password))
            {
                ErrorMessage = "יש להזין סיסמה";
            }
            else
            {
                Regex hasNumber = new Regex(@"[0-9]+");
                Regex hasUpperChar = new Regex(@"[A-Z]+");
                Regex hasMinimum8Chars = new Regex(@".{5,}");
                if (!(hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password)
                    && hasMinimum8Chars.IsMatch(password)))
                {
                    ErrorMessage = "על סיסמה להכיל לפחות 5 תווים ואות גדולה באנגלית וספרה";
                }
            }
            return ErrorMessage;
        }

        public string ValidatePhoneNumber(string phoneNumber)
        {
            ErrorMessage = string.Empty;
            if (string.IsNullOrEmpty(phoneNumber))
            {
                ErrorMessage = "יש להזין מספר טלפון";
            }
            else
            {
                Regex phoneRegex = new Regex(@"0([23489]|5[0123458]|77)([0-9]{7})");
                if (!phoneRegex.IsMatch(phoneNumber))
                {
                    ErrorMessage = "מספר הטלפון לא תקין";
                }
            }
            return ErrorMessage;
        }

        public string ValidateEmailAddress(string emailAddress)
        {
            ErrorMessage = string.Empty;
            if (string.IsNullOrEmpty(emailAddress))
            {
                ErrorMessage = "יש להזין כתובת אימייל";
            }
            else
            {
                try
                {
                    new MailAddress(emailAddress);
                }
                catch
                {
                    ErrorMessage = "כתובת מייל לא תקינה";
                }
            }
            return ErrorMessage;
        }
        public string ValidateWeight(string weight)
        {
            ErrorMessage = string.Empty;
            if (string.IsNullOrEmpty(weight))
            {
                ErrorMessage = "יש להזין משקל";
            }
            else
            {
                double w = 0;
                bool isDouble = Double.TryParse(weight, out w); ;

                if (!(isDouble && w >= 0.001 && w <= 438))
                    ErrorMessage = "משקל לא תקין";
            }
            return ErrorMessage;
        }
    }
}
