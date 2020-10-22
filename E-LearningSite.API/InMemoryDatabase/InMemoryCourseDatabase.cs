using E_LearningSite.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.InMemoryDatabase
{
    public class InMemoryCourseDatabase : ICourseRepository
    {
        private List<Course> _courseDatabase;

        public InMemoryCourseDatabase()
        {
            _courseDatabase = new List<Course>();
        }

        public Course Add(Course course)
        {
            course.Id = _courseDatabase.Max(s => s.Id) + 1;
            _courseDatabase.Add(course);
            return course;
        }

        public Document Add(Document document, int courseId)
        {
            Course course = _courseDatabase.FirstOrDefault(s => s.Id == courseId);
            document.Id = course.CourseMaterials.Max(m => m.Id) + 1;
            course.CourseMaterials.Add(document);
            return document;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseDatabase;
        }

        public Course GetCourse(int id)
        {
            return _courseDatabase.FirstOrDefault(c => c.Id == id);
        }
    }
}
