using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitySystem.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Column("Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Column("Full name")]
        [Display(Name = "Full name")]
        public ICollection<Course> Courses { get; set; }
    }
}
