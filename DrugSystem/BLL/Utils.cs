using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class Utils
    {
        public static void ValidateEmailAddress(string EmailToValidate)
        {
            new MailAddress(EmailToValidate);
        }
    }
}
