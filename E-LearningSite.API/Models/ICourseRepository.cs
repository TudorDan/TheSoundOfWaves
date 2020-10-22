using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.DTOs
{
    public interface ICourseRepository
    {
        Course GetCourse(int id);
        IEnumerable<Course> GetAllCourses();
        Course Add(Course course);
        Document Add(Document document, int courseId);
    }
}
