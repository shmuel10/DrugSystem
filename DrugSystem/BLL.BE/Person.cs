using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.BE.AuxiliaryObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BLL.BE
{
    [Table("Persons")]
    public abstract class Person
    {
        [Key][Required(ErrorMessage ="ID Is Required")]
        public string ID { get; set; }
        [Index(IsUnique =true), MaxLength(40), MinLength(5)]
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Date BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public Address PersonAddress { get; set; }
        public Gender Gender { get; set; }
    }
}
