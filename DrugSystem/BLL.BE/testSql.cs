using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BE
{
    [Table("testSql")]
    public class testSql
    {
        public testSql(string v1, string v2)
        {
            id = v1;
            name = v2;
        }

        [Key]
        public string id { get; set; }
        public string name { get; set; }
    }
}
