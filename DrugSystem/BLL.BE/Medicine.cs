using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BE
{
    [Table("Medicines")]
    public class Medicine
    {
        [Key]
        public string MedicineID { get; set; }
        public string CommercialName { get; set; }
        public string GenericName { get; set; }
        public string Manufacturer { get; set; }
        public string ActiveIngredients { get; set; }
        public string DoseCharacteristics { get; set; }
        public string ImageUrl { get; set; }
    }
}
