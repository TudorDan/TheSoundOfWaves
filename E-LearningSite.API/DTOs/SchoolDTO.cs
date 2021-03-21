using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.Models
{
    public class SchoolDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        public string Photo { get; set; }
        [Required]
        public Principal Principal { get; set; }
        public List<Mentor> Mentors { get; set; }
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Catalogue> Catalogues { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
