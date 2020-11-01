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
        public List<string> Medicines { get; internal set; }

        public NewVisitUC_M()
        {
            BL = new BllImplementation();
            Medicines = BL.GetAllMedicinesByName();

        }

        public void AddPrescription(Prescription prescription)
        {
            BL.AddPrescription(prescription);
        }

        internal List<string> GetAllMedicinies()
        {
            return BL.GetAllMedicinesByName();
        }
    }
}
