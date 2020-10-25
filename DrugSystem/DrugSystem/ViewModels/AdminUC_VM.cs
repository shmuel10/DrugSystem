using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugSystem.Models;

namespace DrugSystem.ViewModels
{
    
    class AdminUC_VM
    {
        public AdminUC_M AdminUC_M { get; set; }
        public AdminUC_VM()
        {
            AdminUC_M = new AdminUC_M();
        }
    }
}
