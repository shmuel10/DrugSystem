using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DrugSystem.Validation
{
    public class IDValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string EerrorMessage = null;
            if (value == null)
            {
                EerrorMessage = "תעודת זהות חובה";
                return new ValidationResult(false, EerrorMessage);
            }
            string id = value.ToString();

            if (id.Length != 9)
            {
                EerrorMessage = "תעודת זהות חייבת לכלול 9 ספרות";
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
                    EerrorMessage = "תעודת זהות לא חוקית";
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
