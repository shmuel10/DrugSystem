using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DrugSystem.Models
{
    public class PatientUC_M
    {
        IBll BL;
        public PatientUC_M()
        {
            BL = new BllImplementation();
        }
    }
}
