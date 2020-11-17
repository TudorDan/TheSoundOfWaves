using System;
using System.Collections.Generic;

namespace E_LearningSite.Domain
{
    public class School
    {
        public School()
        {
            MentorsList = new List<Mentor>();
            StudentsList = new List<Student>();
            CoursesList = new List<Course>();
            CataloguesList = new List<Catalogue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public Principal Principal { get; set; }
        public List<Mentor> MentorsList { get; set; }
        public List<Student> StudentsList { get; set; }
        public List<Course> CoursesList { get; set; }
        public List<Catalogue> CataloguesList { get; set; }
    }
}
