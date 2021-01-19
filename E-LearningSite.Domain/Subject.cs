using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LearningSite.Domain
{
    public class Subject
    {
        public Subject()
        {
            Courses = new List<Course>();
            SchoolSubjects = new List<SchoolSubject>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Course> Courses { get; set; }
            
        public List<SchoolSubject> SchoolSubjects { get; set; }
    }
}
