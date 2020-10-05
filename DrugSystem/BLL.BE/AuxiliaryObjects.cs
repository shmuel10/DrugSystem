using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BE
{
    class AuxiliaryObjects
    {
        public enum Gender { Male, Feamle, Other }
        public struct Name
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
            public struct Address
        {
            public string City { get; set; }
            public string Street { get; set; }
            public string BuildingNumber { get; set; }
        }
        public struct Date {
            public int Year { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
        }
    }
}
