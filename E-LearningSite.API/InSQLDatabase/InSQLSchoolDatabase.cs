using AutoMapper;
using E_LearningSite.API.Models;
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
            Domain.Principal newPrincipal = _mapper.Map<Domain.Principal>(school.Principal);
            Domain.School newSchool = new Domain.School()
            {
                Name = school.Name,
                Photo = school.Photo
            };
            _context.Schools.Add(newSchool);
            _context.SaveChanges();

            newPrincipal.SchoolId = newSchool.Id;
            _context.Principals.Add(newPrincipal);
            _context.SaveChanges();

            school.Id = newSchool.Id;
            return school;
        }

        public void UpdateSchool(School school, SchoolDTO schoolDTO)
        {
            Domain.Principal updatePrincipal = _context.Principals.FirstOrDefault(s => s.Id == school.Principal.Id);
            updatePrincipal.Name = schoolDTO.Principal.Name;
            updatePrincipal.Photo = schoolDTO.Principal.Photo;
            updatePrincipal.BirthDate = schoolDTO.Principal.BirthDate;
            _context.SaveChanges();

            Domain.School updateSchool = _context.Schools.FirstOrDefault(s => s.Id == school.Id);
            updateSchool.Name = schoolDTO.Name;
            updateSchool.Photo = schoolDTO.Photo;
            _context.SaveChanges();
        }

        public void DeleteSchool(School school)
        {
            // delete principal
            Domain.Principal deletePrincipal = _context.Principals.FirstOrDefault(s => s.Id == school.Principal.Id);
            _context.Remove(deletePrincipal);
            _context.SaveChanges();

            // select catalogues
            List<Domain.Catalogue> deleteCatalogues = _context.Catalogues
                .Include(c => c.CourseCatalogues).Include(c => c.MentorCatalogues)
                .Where(c => c.SchoolId == school.Id).ToList();

            //A. delete catalogues grades
            List<Domain.Grade> deleteGrades = new List<Domain.Grade>();
            foreach (Domain.Catalogue catalogue in deleteCatalogues)
            {
                List<Domain.Grade> oneCatalogueGrades = _context.Grades
                    .Where(g => g.CatalogueId == catalogue.Id).ToList();

                deleteGrades.AddRange(oneCatalogueGrades);
            }
            _context.Grades.RemoveRange(deleteGrades);
            _context.SaveChanges();

            // select courses
            List<Domain.Course> deleteCourses = _context.Courses.Where(c => c.SchoolId == school.Id).ToList();

            //B. delete courses documents
            List<Domain.Document> deleteDocuments = new List<Domain.Document>();
            foreach (Domain.Course course in deleteCourses)
            {
                List<Domain.Document> oneCourseDocuments = _context.Documents
                    .Where(d => d.CourseId == course.Id).ToList();

                deleteDocuments.AddRange(oneCourseDocuments);
            }
            _context.Documents.RemoveRange(deleteDocuments);
            _context.SaveChanges();

            //C. delete courses
            _context.Courses.RemoveRange(deleteCourses);
            _context.SaveChanges();

            //D. delete mentors
            List<Domain.Mentor> deleteMentors = _context.Mentors.Where(m => m.SchoolId == school.Id).ToList();
            _context.Mentors.RemoveRange(deleteMentors);
            _context.SaveChanges();

            //E. delete students
            List<Domain.Student> deleteStudents = _context.Students.Where(s => s.SchoolId == school.Id).ToList();
            _context.Students.RemoveRange(deleteStudents);
            _context.SaveChanges();

            //F. delete catalogues
            _context.Catalogues.RemoveRange(deleteCatalogues);
            _context.SaveChanges();

            //G. delete subjects
            List<Domain.Subject> deleteSubjects = _context.Subjects.Where(s => s.SchoolId == school.Id).ToList();
            _context.Subjects.RemoveRange(deleteSubjects);
            _context.SaveChanges();

            //delete school
            Domain.School deleteSchool = _context.Schools.FirstOrDefault(s => s.Id == school.Id);
            _context.Schools.Remove(deleteSchool);
            _context.SaveChanges();
        }

        // Mentors
        public ICollection<Mentor> GetAllMentors(int schoolId)
        {
            List<Domain.Mentor> mentors = _context.Mentors.Where(m => m.SchoolId == schoolId).ToList();

            return (ICollection<Mentor>)_mapper.Map<IEnumerable<Mentor>>(mentors);
        }

        public Mentor GetMentor(int id, int schoolId)
        {
            Domain.Mentor mentor = _context.Mentors.Where(m => m.SchoolId == schoolId).FirstOrDefault(m => m.Id == id);
            return _mapper.Map<Mentor>(mentor);
        }

        public Mentor AddMentor(Mentor mentor, int schoolId)
        {
            Domain.Mentor newMentor = new Domain.Mentor()
            {
                Name = mentor.Name,
                Photo = mentor.Photo,
                BirthDate = mentor.BirthDate,
                AccessRights = (Domain.AccessRights)mentor.AccessRights,
                SchoolId = schoolId
            };
            _context.Mentors.Add(newMentor);
            _context.SaveChanges();

            mentor.Id = newMentor.Id;
            return mentor;
        }

        public void UpdateMentor(Mentor mentor, PersonDTO personDTO)
        {
            Domain.Mentor updateMentor = _context.Mentors.FirstOrDefault(m => m.Id == mentor.Id);
            updateMentor.Name = personDTO.Name;
            updateMentor.Photo = personDTO.Photo;
            updateMentor.BirthDate = personDTO.BirthDate;

            _context.SaveChanges();
        }

        public void DeleteMentor(Mentor mentor, int schoolId)
        {
            // firstly, delete mentor in catalogues 
            List<Domain.Catalogue> catalogues = _context.Catalogues
                .Include(c => c.MentorCatalogues).Where(c => c.SchoolId == schoolId).ToList();

            List<Domain.MentorCatalogue> deleteMentorCatalogues = catalogues
                .SelectMany(c => c.MentorCatalogues).Where(mc => mc.MentorId == mentor.Id).ToList();
            _context.RemoveRange(deleteMentorCatalogues);
            _context.SaveChanges();

            // secondly, delete mentor in school
            Domain.Mentor deleteMentor = _context.Mentors.FirstOrDefault(m => m.Id == mentor.Id);
            _context.Mentors.Remove(deleteMentor);
            _context.SaveChanges();
        }


        // Students
        public ICollection<Student> GetAllStudents(int schoolId)
        {
            List<Domain.Student> students = _context.Students.Where(s => s.SchoolId == schoolId).ToList();
            return (ICollection<Student>)_mapper.Map<IEnumerable<Student>>(students);
        }

        public Student GetStudent(int id, int schoolId)
        {
            Domain.Student student = _context.Students.Where(s => s.SchoolId == schoolId).FirstOrDefault(s => s.Id == id);
            return _mapper.Map<Student>(student);
        }

        public Student AddStudent(Student student, int schoolId)
        {
            Domain.Student newStudent = new Domain.Student()
            {
                Name = student.Name,
                Photo = student.Photo,
                BirthDate = student.BirthDate,
                AccessRights = (Domain.AccessRights)student.AccessRights,
                SchoolId = schoolId
            };
            _context.Students.Add(newStudent);
            _context.SaveChanges();

            student.Id = newStudent.Id;
            return student;
        }

        public void UpdateStudent(Student student, PersonDTO personDTO)
        {
            Domain.Student updateStudent = _context.Students.FirstOrDefault(s => s.Id == student.Id);
            updateStudent.Name = personDTO.Name;
            updateStudent.Photo = personDTO.Photo;
            updateStudent.BirthDate = personDTO.BirthDate;

            _context.SaveChanges();
        }
        
        public void DeleteStudent(Student student, int schoolId)
        {
            Domain.Student deleteStudent = _context.Students.FirstOrDefault(s => s.Id == student.Id);
            _context.Students.Remove(deleteStudent);
            _context.SaveChanges();
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
            List<Domain.Subject> subjects = _context.Subjects.Where(s => s.SchoolId == schoolId).ToList();

            return (ICollection<Subject>)_mapper.Map<IEnumerable<Subject>>(subjects);
        }
        public Subject GetSubject(int id, int schoolId)
        {
            Domain.Subject subject = _context.Subjects.FirstOrDefault(sbj => sbj.Id == id);

            return _mapper.Map<Subject>(subject);
        }
        public Subject AddSubject(Subject subject, int schoolId)
        {
            Domain.Subject newSubject = new Domain.Subject()
            {
                Name = subject.Name,
                SchoolId = schoolId
            };
            _context.Subjects.Add(newSubject);
            _context.SaveChanges();

            subject.Id = newSubject.Id;
            return subject;
        }

        public void UpdateSubject(Subject subject, SubjectDTO subjectDTO)
        {
            Domain.Subject updateSubject = _context.Subjects.FirstOrDefault(s => s.Id == subject.Id);
            updateSubject.Name = subjectDTO.Name;

            _context.SaveChanges();
        }
    }
}
