using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BE
{
    class Patient : Person
    {
        public double Weight { get; set; }
        public List<Medicine> OldMedicines { get; set; }
        public List<Medicine> CurrentMedicines { get; set; }


    }
}
