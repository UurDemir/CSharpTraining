using System.ComponentModel.DataAnnotations;

namespace AdventureW.BackOffice.Model
{
    public class EmployeeEditModel
    {
        public int Id { get; set; }
        public int? SuperVisorId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
    }
}
