using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DrugSystem.Validation
{
    class PhoneNumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex phoneRegex = new Regex(@"0([23489]|5[0123458]|77)([0-9]{7})");
            return phoneRegex.IsMatch(value.ToString()) ? ValidationResult.ValidResult :
                 new ValidationResult(false, "מספר הטלפון לא תקין");
    
        }
    }
}
