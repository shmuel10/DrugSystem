using System;
using BLL;
using BLL.BE;

namespace DrugSystem
{
    public class AddNewMedicineWindow_M
    {
        IBll BL;
        public AddNewMedicineWindow_M()
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
