using System;
using System.Collections.Generic;
using System.Text;

namespace E_LearningSite.Domain
{
    public class Catalogue
    {
        public Catalogue()
        {
            ClassGrades = new List<Grade>();
        }

        public int Id { get; set; }
        public string ClassName { get; set; }
        public List<Mentor> ClassMentors { get; set; }
        public List<Student> ClassStudents { get; set; }
        public List<Course> ClassCourses { get; set; }
        public List<Grade> ClassGrades { get; set; }

        public School School { get; set; }
        public int SchoolId { get; set; }
    }
}
