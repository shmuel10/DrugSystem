using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DrugSystem.Validation
{
    class IDValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string id = value.ToString();
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
            return EerrorMessage != null
                ? new ValidationResult(false, EerrorMessage)
                : ValidationResult.ValidResult;
        }

    }
}
