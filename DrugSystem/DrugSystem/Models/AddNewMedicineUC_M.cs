using BLL;
using BLL.BE;

namespace DrugSystem.Models
{
    public class AddNewMedicineUC_M
    {
        IBll BL;
        public AddNewMedicineUC_M()
        {
            BL = new BllImplementation();
        }
        public void AddNewMedicine(Medicine newMedicine)
        {
            BL.AddMedicine(newMedicine);
        }
        public string GetMedicineCode(string medicineName)
        {
            return BL.GetMedicineCodeIfExistInXML(medicineName);
        }
    }
}
