using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BE
{
    class Medicine
    {
        public string CommercialName { get; set; }
        public string GenericName { get; set; }
        public string Manufacturer { get; set; }
        public List<string> ActiveIngredients { get; set; }
        public List<string> DoseCharacteristics { get; set; }
        public Uri ImageUrl { get; set; }
    }
}
