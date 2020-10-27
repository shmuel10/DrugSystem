using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.BE;

namespace DrugSystem.Models
{
    class LoginWindowM
    {
        public IBll Bll;
        public LoginWindowM()
        {
            Bll = new BllImplementation();
        }

        public User Login(string mail, string password)
        {
            return Bll.GetLoginUser(mail, password);
        }
    }
}
