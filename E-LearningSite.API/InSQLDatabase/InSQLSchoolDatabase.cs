using AutoMapper;
using E_LearningSite.API.DTOs;
using E_LearningSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            List<Domain.School> schools = _context.Schools.OrderBy(s => s.Name).ToList();
            foreach (Domain.School school in schools)
            {
                Domain.Principal principal = _context.Principals.FirstOrDefault(p => p.SchoolId == school.Id);
                if (principal != null)
                {
                    school.Principal = principal;
                }
                else
                {
                    school.Principal = new Domain.Principal() { Name = "Unknown" };
                }
            }
            return (ICollection<School>)_mapper.Map<IEnumerable<School>>(schools);
        }
        public School GetSchool(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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

        public Subject AddSchoolSubject(Subject subject, int schoolId)
        {
            throw new NotImplementedException();
        }

        public Subject GetSubject(int id, int schoolId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Subject> GetAllSchoolSubjects(int schoolId)
        {
            throw new NotImplementedException();
        }
    }
}
