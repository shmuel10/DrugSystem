using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.BE.AuxiliaryObjects;

namespace BLL.BE
{
    abstract class Person
    {
        public string ID { get; set; }
        public Name PersonName { get; set; }
        public Date BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public Address PersonAddress { get; set; }
        public Gender Gender { get; set; }
    }
}
