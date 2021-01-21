using E_LearningSite.API.Models;
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

        Mentor AddCatalogueMentor(Mentor mentor, int schoolId, int catalogueId);
        Mentor GetCatalogueMentor(int id, int schoolId, int catalogueId);
        ICollection<Mentor> GetALLCatalogueMentors(int schoolId, int catalogueId);

        Student AddCatalogueStudent(Student student, int schoolId, int catalogueId);
        Student GetCatalogueStudent(int id, int schoolId, int catalogueId);
        ICollection<Student> GetAllCatalogueStudents(int schoolId, int catalogueId);

        Course AddCatalogueCourse(Course course, int schoolId, int catalogueId);
        Course GetCatalogueCourse(int id, int schoolId, int catalogueId);
        ICollection<Course> GetAllCatalogueCourses(int schoolId, int catalogueId);

        Grade AddCatalogueGrade(Grade grade, int schoolId, int catalogueId);
        Grade GetCatalogueGrade(int id, int schoolId, int catalogueId);
        ICollection<Grade> GetAllCatalogueGrades(int schoolId, int catalogueId);

        Subject AddSubject(Subject subject, int schoolId);
        Subject GetSubject(int id, int schoolId);
        ICollection<Subject> GetAllSubjects(int schoolId);
    }
}
