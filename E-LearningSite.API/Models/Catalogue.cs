using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.DTOs
{
    public class Catalogue
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string ClassName { get; set; }
        public List<Mentor> ClassMentors { get; set; }
        public List<Student> ClassStudents { get; set; }
        public List<Course> ClassCourses { get; set; }
        public List<Grade> ClassGrades { get; set; }
    }
}
