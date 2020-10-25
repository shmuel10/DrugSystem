using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.BE;

namespace DrugSystem.Models
{
    class LoginUC_M
    {
        IBll BL;
        public LoginUC_M()
        {
            BL = new BllImplementation();
        }

        public User Login(string mail, string password)
        {
            return BL.GetUserByEmail(mail);
        }
    }
}
