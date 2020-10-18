using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BLL.BE
{
    [Table("tblAdmin")]
    public class Administrator : User
    {
        public Administrator()
        {
            
        }
    }
}
