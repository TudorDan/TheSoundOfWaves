using System;
using System.Collections.Generic;
using System.Text;

namespace E_LearningSite.Domain
{
    public class Course
    {
        public Course()
        {
            CourseMaterials = new List<Document>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Subject? Subject { get; set; }
        public string Description { get; set; }
        public List<Document> CourseMaterials { get; set; }

        public School School { get; set; }
        public int SchoolId { get; set; }
    }
}
