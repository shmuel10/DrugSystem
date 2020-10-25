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
    class EmailAddressValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                new MailAddress(value as string);
                return ValidationResult.ValidResult;
            }
            catch
            {
                return new ValidationResult(false, "Invalid Mail Address");
            }
        }
    }
}
