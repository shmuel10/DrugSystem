using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.BE;
using DrugSystem.Command;

namespace DrugSystem.Models
{
    public class MedicineAdminSide_M
    {
        public IBll BL { get; set; }
        public MedicineAdminSide_M()
        {
            BL = new BllImplementation();  
        }

        public void UpdateMedicine(Medicine medicine)
        {
            BL.UpdateMedicine(medicine);
        }
    }
}
