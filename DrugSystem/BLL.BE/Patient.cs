using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using static BLL.BE.AuxiliaryObjects;

namespace BLL.BE
{
    class Patient : Person
    {
        public double Weight { get; set; }
        public Name FatherName { get; set; }
        public string FamilyDoctor { get; set; }
    }
}
