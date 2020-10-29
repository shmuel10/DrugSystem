using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugSystem.ViewModels
{
    public class MedChooseUC_VM
    {
        public MedChooseUC_M MedChooseUC_M { get; set; }
        public List<string> Medicines { get { return MedChooseUC_M.Medicines; } }
        public MedChooseUC_VM()
        {
            MedChooseUC_M = new MedChooseUC_M();
        }
    }
}
