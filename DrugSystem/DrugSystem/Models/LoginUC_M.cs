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

        internal User SignIn(string mail, string password)
        {
           return BL.GetLoginUser(mail, password);
        }
    }
}
