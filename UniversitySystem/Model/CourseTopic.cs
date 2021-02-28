using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitySystem.Model
{
    public class CourseTopic
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Topic cannot be longer than 50 characters.")]
        public string  Topic { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
