using System;
using System.Collections.Generic;
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
        }

        public int Id { get; set; }
        public string ClassName { get; set; }
        public List<Mentor> ClassMentors { get; set; }
        public List<Student> ClassStudents { get; set; }
        public List<Course> ClassCourses { get; set; }
        public List<Grade> ClassGrades { get; set; }

        public School School { get; set; }
        public int SchoolId { get; set; }

        public List<MentorCatalogue> MentorCatalogues { get; set; }
        public List<CourseCatalogue> CourseCatalogues { get; set; }
    }
}
