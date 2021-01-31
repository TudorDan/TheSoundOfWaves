using E_LearningSite.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.Models
{
    public interface ISchoolRepository
    {
        // schools
        School GetSchool(int id);
        ICollection<School> GetAllSchools();
        School AddSchool(School school);
        void UpdateSchool(School school, SchoolDTO schoolDTO);
        void DeleteSchool(School school);

        // mentors
        Mentor AddMentor(Mentor mentor, int schoolId);
        Mentor GetMentor(int id, int schoolId);
        ICollection<Mentor> GetAllMentors(int schoolId);
        void UpdateMentor(Mentor mentor, PersonDTO personDTO);
        void DeleteMentor(Mentor mentor, int schoolId);

        // students
        Student AddStudent(Student student, int schoolId);
        Student GetStudent(int id, int schoolId);
        ICollection<Student> GetAllStudents(int schoolId);
        void UpdateStudent(Student student, PersonDTO personDTO);
        void DeleteStudent(Student student, int schoolId);

        // courses
        Course AddCourse(Course course, int schoolId);
        Course GetCourse(int id, int schoolId);
        ICollection<Course> GetAllCourses(int schoolId);
        void UpdateCourse(Course course, CourseDTO courseDTO, int schoolId);
        void DeleteCourse(Course course, int schoolId);

        // documents
        Document AddDocument(Document document, int schoolId, int courseId);
        Document GetDocument(int id, int schoolId, int courseId);
        ICollection<Document> GetAllDocuments(int schoolId, int courseId);
        void UpdateDocument(Document document, DocumentDTO documentDTO);
        void DeleteDocument(Document document, int schoolId, int courseId);

        // catalogues
        Catalogue AddCatalogue(Catalogue catalogue, int schoolId);
        Catalogue GetCatalogue(int id, int schoolId);
        ICollection<Catalogue> GetAllCatalogues(int schoolId);
        void UpdateCatalogue(Catalogue catalogue, CatalogueDTO catalogueDTO);
        void DeleteCatalogue(Catalogue catalogue, int schoolId);

        // catalogue mentors
        Mentor AddCatalogueMentor(Mentor mentor, int schoolId, int catalogueId);
        Mentor GetCatalogueMentor(int id, int schoolId, int catalogueId);
        ICollection<Mentor> GetALLCatalogueMentors(int schoolId, int catalogueId);
        void DeleteCatalogueMentor(Mentor mentor, int schoolId, int catalogueId);

        // catalogue students
        Student AddCatalogueStudent(Student student, int schoolId, int catalogueId);
        Student GetCatalogueStudent(int id, int schoolId, int catalogueId);
        ICollection<Student> GetAllCatalogueStudents(int schoolId, int catalogueId);
        void DeleteCatalogueStudent(Student student, int schoolId, int catalogueId);

        // catalogue courses
        Course AddCatalogueCourse(Course course, int schoolId, int catalogueId);
        Course GetCatalogueCourse(int id, int schoolId, int catalogueId);
        ICollection<Course> GetAllCatalogueCourses(int schoolId, int catalogueId);
        void DeleteCatalogueCourse(Course course, int schoolId, int catalogueId);

        // catalogue grades
        Grade AddCatalogueGrade(Grade grade, int schoolId, int catalogueId);
        Grade GetCatalogueGrade(int id, int schoolId, int catalogueId);
        ICollection<Grade> GetAllCatalogueGrades(int schoolId, int catalogueId);
        void UpdateCatalogueGrade(Grade grade, GradeDTO gradeDTO, int schoolId);

        // subjects
        Subject AddSubject(Subject subject, int schoolId);
        Subject GetSubject(int id, int schoolId);
        ICollection<Subject> GetAllSubjects(int schoolId);
        void UpdateSubject(Subject subject, SubjectDTO subjectDTO);
        void DeleteSubject(Subject subject, int schoolId);
    }
}
