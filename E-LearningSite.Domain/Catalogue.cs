using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_LearningSite.Domain
{
    public class Catalogue
    {
        public Catalogue()
        {
            // initialized here, instead of school level
            ClassGrades = new List<Grade>();
            MentorCatalogues = new List<MentorCatalogue>();
            CourseCatalogues = new List<CourseCatalogue>();

            ClassStudents = new List<Student>();
            ClassMentors = new List<Mentor>();
            ClassCourses = new List<Course>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ClassName { get; set; }
        public List<Mentor> ClassMentors { get; set; }
        public List<Student> ClassStudents { get; set; }
        public List<Course> ClassCourses { get; set; }
        public List<Grade> ClassGrades { get; set; }

        [ForeignKey("SchoolId")]
        public School School { get; set; }
        public int SchoolId { get; set; }

        public List<MentorCatalogue> MentorCatalogues { get; set; }
        public List<CourseCatalogue> CourseCatalogues { get; set; }
    }
}
