using System.Collections.Generic;
using BLL;

namespace DrugSystem.ViewModels
{
    public class MedChooseUC_M
    {
        public IBll BL { get; set; }

        public List<string> Medicines { get; internal set; }
        public MedChooseUC_M()
        {
            BL = new BllImplementation();
            Medicines = BL.GetAllMedicinesByName();
        }
    }
}