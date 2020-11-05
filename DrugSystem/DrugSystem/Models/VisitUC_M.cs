using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.BE;

namespace DrugSystem.Models
{
    public class VisitUC_M
    {
        IBll Bll;
        public VisitUC_M()
        {
            Bll = new BllImplementation();
        }


        public Patient GetPatientByID(string patientID)
        {
            return Bll.GetPatient(patientID);
        }
    }
}
