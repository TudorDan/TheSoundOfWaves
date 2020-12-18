using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LearningSite.Domain
{
    public class School
    {
        public School()
        {
            Mentors = new List<Mentor>();
            Students = new List<Student>();
            Courses = new List<Course>();
            Catalogues = new List<Catalogue>();
            Subjects = new List<Subject>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public Principal Principal { get; set; }
        public List<Mentor> Mentors { get; set; }
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Catalogue> Catalogues { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
