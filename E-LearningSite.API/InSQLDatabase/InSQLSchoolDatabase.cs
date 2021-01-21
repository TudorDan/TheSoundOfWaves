using AutoMapper;
using E_LearningSite.API.DTOs;
using E_LearningSite.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_LearningSite.API.SQLDatabase
{
    public class InSQLSchoolDatabase : ISchoolRepository
    {
        private readonly LearningContext _context;
        private readonly IMapper _mapper;

        public InSQLSchoolDatabase(LearningContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Schools
        public ICollection<School> GetAllSchools()
        {
            List<Domain.School> schools = _context.Schools.Include(s => s.Principal).ToList();

            return (ICollection<School>)_mapper.Map<IEnumerable<School>>(schools);
        }
        public School GetSchool(int id)
        {
            Domain.School school = _context.Schools.FirstOrDefault(s => s.Id == id);
            Domain.Principal principal = _context.Principals.FirstOrDefault(p => p.SchoolId == school.Id);

            school.Principal = principal;

            return _mapper.Map<School>(school);
        }
        public School AddSchool(School school)
        {
            _context.Schools.Add(_mapper.Map<Domain.School>(school));
            _context.SaveChanges();
            return school;
        }

        // Mentors
        public ICollection<Mentor> GetAllMentors(int schoolId)
        {
            List<Domain.Mentor> mentors = _context.Mentors.Where(m => m.SchoolId == schoolId).ToList();

            return (ICollection<Mentor>)_mapper.Map<IEnumerable<Mentor>>(mentors);
        }
        public Mentor GetMentor(int id, int schoolId)
        {
            throw new NotImplementedException();
        }
        public Mentor AddMentor(Mentor mentor, int schoolId)
        {
            throw new NotImplementedException();
        }

        // Students
        public ICollection<Student> GetAllStudents(int schoolId)
        {
            List<Domain.Student> students = _context.Students.Where(s => s.SchoolId == schoolId).ToList();
            return (ICollection<Student>)_mapper.Map<IEnumerable<Student>>(students);
        }
        public Student GetStudent(int id, int schoolId)
        {
            throw new NotImplementedException();
        }
        public Student AddStudent(Student student, int schoolId)
        {
            throw new NotImplementedException();
        }

        // Courses
        public ICollection<Course> GetAllCourses(int schoolId)
        {
            try
            {
                List<Domain.Course> courses = _context.Courses
                                .Where(c => c.SchoolId == schoolId).ToList();
                /*foreach(Domain.Course course in courses)
                {
                    course.Subject = _context.Subjects.FirstOrDefault(sbj => sbj.Id == course.SubjectId);
                }*/
            return (ICollection<Course>)_mapper.Map<IEnumerable<Course>>(courses);
            }
            catch (Exception e)
            {
                var x = e.Message;
                Console.WriteLine(x);
            }
            return null;
        }
        public Course GetCourse(int id, int schoolId)
        {
            throw new NotImplementedException();
        }
        public Course AddCourse(Course course, int schoolId)
        {
            throw new NotImplementedException();
        }

        // Course Documents
        public ICollection<Document> GetAllDocuments(int schoolId, int courseId)
        {
            throw new NotImplementedException();
        }
        public Document GetDocument(int id, int schoolId, int courseId)
        {
            throw new NotImplementedException();
        }
        public Document AddDocument(Document document, int schoolId, int courseId)
        {
            throw new NotImplementedException();
        }

        // Catalogues
        public ICollection<Catalogue> GetAllCatalogues(int schoolId)
        {
            throw new NotImplementedException();
        }
        public Catalogue GetCatalogue(int id, int schoolId)
        {
            throw new NotImplementedException();
        }
        public Catalogue AddCatalogue(Catalogue catalogue, int schoolId)
        {
            var school = _context.Schools.FirstOrDefault(s => s.Id == schoolId);
            if (school != null)
            {
                var c = _mapper.Map<Domain.Catalogue>(catalogue);
                _context.Catalogues.Add(c);
                _context.SaveChanges();
                return catalogue;
            }
            return null;
        }

        // Catalogue Mentors
        public ICollection<Mentor> GetALLCatalogueMentors(int schoolId, int catalogueId)
        {
            throw new NotImplementedException();
        }
        public Mentor GetCatalogueMentor(int id, int schoolId, int catalogueId)
        {
            throw new NotImplementedException();
        }        
        public Mentor AddCatalogueMentor(Mentor mentor, int schoolId, int catalogueId)
        {
            throw new NotImplementedException();
        }

        // Catalogue Students
        public ICollection<Student> GetAllCatalogueStudents(int schoolId, int catalogueId)
        {
            throw new NotImplementedException();
        }
        public Student GetCatalogueStudent(int id, int schoolId, int catalogueId)
        {
            throw new NotImplementedException();
        }
        public Student AddCatalogueStudent(Student student, int schoolId, int catalogueId)
        {
            throw new NotImplementedException();
        }


        // Catalogue Courses
        public ICollection<Course> GetAllCatalogueCourses(int schoolId, int catalogueId)
        {
            throw new NotImplementedException();
        }
        public Course GetCatalogueCourse(int id, int schoolId, int catalogueId)
        {
            throw new NotImplementedException();
        }
        public Course AddCatalogueCourse(Course course, int schoolId, int catalogueId)
        {
            throw new NotImplementedException();
        }


        // Catalogue Grades
        public ICollection<Grade> GetAllCatalogueGrades(int schoolId, int catalogueId)
        {
            throw new NotImplementedException();
        }
        public Grade GetCatalogueGrade(int id, int schoolId, int catalogueId)
        {
            throw new NotImplementedException();
        }
        public Grade AddCatalogueGrade(Grade grade, int schoolId, int catalogueId)
        {
            throw new NotImplementedException();
        }

        // Subjects
        public ICollection<Subject> GetAllSubjects(int schoolId)
        {
            try
            {
                //Domain.School school = _context.Schools.FirstOrDefault(s => s.Id == schoolId);
                List<Domain.Subject> subjects = _context.Subjects.Where(s => s.SchoolId == schoolId).ToList();
                return (ICollection<Subject>)_mapper.Map<IEnumerable<Subject>>(subjects);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return null;
        }
        public Subject GetSubject(int id, int schoolId)
        {
            Domain.Subject subject = _context.Subjects.FirstOrDefault(sbj => sbj.Id == id);

            return _mapper.Map<Subject>(subject);
        }
        public Subject AddSubject(Subject subject, int schoolId)
        {
            throw new NotImplementedException();
        }
    }
}
