using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugSystem.ViewModels
{
    public class MedChooseUC_VM
    {
        MedChooseUC_M _medChooseUC_M;
        public List<string> Medicines { get; set; }
        public MedChooseUC_VM()
        {
            _medChooseUC_M = new MedChooseUC_M();
            Medicines = new List<string>(_medChooseUC_M.Medicines);
        }
    }
}
