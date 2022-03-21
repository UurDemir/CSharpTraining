using System;

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
