using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLTransactionIsolationLevel.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return $"Id : {Id} Name : {Name} Surname : {Surname} Age : {Age} Status : {Status}";
        }
    }
}
