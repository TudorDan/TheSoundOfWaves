using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.DTOs
{
    public interface ISchoolRepository
    {
        School GetSchool(int id);
        ICollection<School> GetAllSchools();
        School AddSchool(School school);

        Mentor AddMentor(Mentor mentor, int schoolId);
        Mentor GetMentor(int id, int schoolId);
        ICollection<Mentor> GetAllMentors(int schoolId);

        Student AddStudent(Student student, int schoolId);
        Student GetStudent(int id, int schoolId);
        ICollection<Student> GetAllStudents(int schoolId);

        Course AddCourse(Course course, int schoolId);
        Course GetCourse(int id, int schoolId);
        ICollection<Course> GetAllCourses(int schoolId);

        Document AddDocument(Document document, int schoolId, int courseId);
        Document GetDocument(int id, int schoolId, int courseId);
        ICollection<Document> GetAllDocuments(int schoolId, int courseId);

        Catalogue AddCatalogue(Catalogue catalogue, int schoolId);
        Catalogue GetCatalogue(int id, int schoolId);
        ICollection<Catalogue> GetAllCatalogues(int schoolId);
    }
}
