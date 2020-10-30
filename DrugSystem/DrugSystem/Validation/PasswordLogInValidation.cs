using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DrugSystem.Validation
{
    class PasswordLogInValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;
            return str.Length < 5
                ? new ValidationResult(false, "סיסמה מכילה לפחות 5 תווים")
                : ValidationResult.ValidResult;
        }
    }
}
