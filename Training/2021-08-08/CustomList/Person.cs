using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Undefined,
        Male,
        Female
    }
}
