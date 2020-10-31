using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.BE;

namespace DrugSystem.Models
{
    public class NewVisitUC_M
    {
        public IBll BL { get; set; }
        public NewVisitUC_M()
        {
            BL = new BllImplementation();
        }

        public void AddPrescription(Prescription prescription)
        {
            BL.AddPrescription(prescription);
        }
    }
}
