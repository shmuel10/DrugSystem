using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DrugSystem.Validation
{
    class WeightValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double weight = 0;
            bool isDouble = Double.TryParse(value.ToString(), out weight); ;

            return isDouble && weight >= 0.001 && weight <= 438 ? ValidationResult.ValidResult :
                 new ValidationResult(false, "מספר הטלפון לא תקין");
        }
    }
}
