using BLL;
using BLL.BE;

namespace DrugSystem
{
    public class AddNewMedicinWindow_M
    {
        IBll BL;
        public AddNewMedicinWindow_M()
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
