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
            // Eager Loading -> Include.
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
            List<Domain.Course> courses = _context.Courses.Where(c => c.SchoolId == schoolId)
                .Include(c => c.Documents).Include(c => c.Subject).ToList();

            return (ICollection<Course>)_mapper.Map<IEnumerable<Course>>(courses);
        }

        public Course GetCourse(int id, int schoolId)
        {
            Domain.Course course = _context.Courses.Include(c => c.Documents)
                .Include(c => c.Subject).FirstOrDefault(c => c.Id == id);

            return _mapper.Map<Course>(course);
        }
        public Course AddCourse(Course course, int schoolId)
        {
            Domain.Course newCourse = new Domain.Course()
            {
                Name = course.Name,
                Description = course.Description,
                SubjectId = course.Subject.Id,
                SchoolId = schoolId
            };
            _context.Courses.Add(newCourse);
            _context.SaveChanges();

            course.Id = newCourse.Id;
            return course;
        }
        public void UpdateCourse(Course course, CourseDTO courseDTO, int schoolId)
        {
            Domain.Course updateCourse = _context.Courses.FirstOrDefault(c => c.Id == course.Id);
            updateCourse.Name = courseDTO.Name;
            updateCourse.Description = courseDTO.Description;
            updateCourse.SubjectId = courseDTO.SubjectId;

            _context.SaveChanges();
        }
        public void DeleteCourse(Course course, int schoolId)
        {
            Domain.Course deleteCourse = _context.Courses
                .Include(c => c.CourseCatalogues).FirstOrDefault(c => c.Id == course.Id);

            _context.Remove(deleteCourse);
            _context.SaveChanges();
        }


        // Course Documents
        public ICollection<Document> GetAllDocuments(int schoolId, int courseId)
        {
            List<Domain.Document> documents = _context.Documents.Where(d => d.CourseId == courseId).ToList();

            return (ICollection<Document>)_mapper.Map<IEnumerable<Document>>(documents);
        }

        public Document GetDocument(int id, int schoolId, int courseId)
        {
            Domain.Document document = _context.Documents.FirstOrDefault(d => d.Id == id);

            return _mapper.Map<Document>(document);
        }

        public Document AddDocument(Document document, int schoolId, int courseId)
        {
            Domain.Document newDocument = new Domain.Document()
            {
                Name = document.Name,
                Link = document.Link,
                CourseId = courseId
            };
            _context.Documents.Add(newDocument);
            _context.SaveChanges();

            document.Id = newDocument.Id;
            return document;
        }

        public void UpdateDocument(Document document, DocumentDTO documentDTO)
        {
            Domain.Document updateDocument = _context.Documents.FirstOrDefault(d => d.Id == document.Id);
            updateDocument.Name = documentDTO.Name;
            updateDocument.Link = documentDTO.Link;

            _context.SaveChanges();
        }

        public void DeleteDocument(Document document, int schoolId, int courseId)
        {
            Domain.Document deleteDocument = _context.Documents.FirstOrDefault(d => d.Id == document.Id);

            _context.Remove(deleteDocument);
            _context.SaveChanges();
        }


        // Catalogues
        public ICollection<Catalogue> GetAllCatalogues(int schoolId)
        {
            var catalogues = _context.Catalogues.Select(c => new
            {
                Catalogue = c,
                Mentors = c.MentorCatalogues.Select(mc => mc.Mentor),
                Courses = c.CourseCatalogues.Select(cc => cc.Course),
                Students = c.Students,
                Grades = c.Grades
            }).Where(catalogues => catalogues.Catalogue.SchoolId == schoolId).ToList();

            List<Catalogue> cataloguesModels = new List<Catalogue>();
            foreach (var catalogue in catalogues)
            {
                Catalogue catalogueModel = new Catalogue()
                {
                    Id = catalogue.Catalogue.Id,
                    Name = catalogue.Catalogue.Name,
                    Mentors = (List<Mentor>)_mapper.Map<IEnumerable<Mentor>>(catalogue.Mentors),
                    Students = (List<Student>)_mapper.Map<IEnumerable<Student>>(catalogue.Students),
                    Courses = (List<Course>)_mapper.Map<IEnumerable<Course>>(catalogue.Courses),
                    Grades = (List<Grade>)_mapper.Map<IEnumerable<Grade>>(catalogue.Grades)
                };
                cataloguesModels.Add(catalogueModel);
            }

            return cataloguesModels;
        }

        public Catalogue GetCatalogue(int id, int schoolId)
        {
            var catalogue = _context.Catalogues.Select(c => new
            {
                Catalogue = c,
                Mentors = c.MentorCatalogues.Select(mc => mc.Mentor),
                Courses = c.CourseCatalogues.Select(cc => cc.Course),
                Students = c.Students,
                Grades = c.Grades
            }).Where(catalogues => catalogues.Catalogue.SchoolId == schoolId)
            .FirstOrDefault(catalogue => catalogue.Catalogue.Id == id);

            Catalogue catalogueModel = new Catalogue()
            {
                Id = catalogue.Catalogue.Id,
                Name = catalogue.Catalogue.Name,
                Mentors = (List<Mentor>)_mapper.Map<IEnumerable<Mentor>>(catalogue.Mentors),
                Students = (List<Student>)_mapper.Map<IEnumerable<Student>>(catalogue.Students),
                Courses = (List<Course>)_mapper.Map<IEnumerable<Course>>(catalogue.Courses),
                Grades = (List<Grade>)_mapper.Map<IEnumerable<Grade>>(catalogue.Grades)
            };

            return catalogueModel;
        }

        public Catalogue AddCatalogue(Catalogue catalogue, int schoolId)
        {
            Domain.Catalogue newCatalogue = new Domain.Catalogue()
            {
                Name = catalogue.Name,
                SchoolId = schoolId
            };
            _context.Catalogues.Add(newCatalogue);
            _context.SaveChanges();

            catalogue.Id = newCatalogue.Id;
            return catalogue;
        }

        public void UpdateCatalogue(Catalogue catalogue, CatalogueDTO catalogueDTO)
        {
            Domain.Catalogue updateCatalogue = _context.Catalogues.FirstOrDefault(c => c.Id == catalogue.Id);
            updateCatalogue.Name = catalogueDTO.Name;

            _context.SaveChanges();
        }

        public void DeleteCatalogue(Catalogue catalogue, int schoolId)
        {
            Domain.Catalogue deleteCatalogue = _context.Catalogues.Include(c => c.CourseCatalogues)
                .Include(c => c.MentorCatalogues).FirstOrDefault(c => c.Id == catalogue.Id);
            _context.Catalogues.Remove(deleteCatalogue);
            _context.SaveChanges();
        }


        // Catalogue Mentors
        public ICollection<Mentor> GetALLCatalogueMentors(int schoolId, int catalogueId)
        {
            var catalogue = _context.Catalogues.Select(c => new
            {
                Catalogue = c,
                Mentors = c.MentorCatalogues.Select(mc => mc.Mentor),
            }).Where(c => c.Catalogue.SchoolId == schoolId)
            .FirstOrDefault(c => c.Catalogue.Id == catalogueId);

            return (ICollection<Mentor>)_mapper.Map<IEnumerable<Mentor>>(catalogue.Mentors);
        }

        public Mentor GetCatalogueMentor(int id, int schoolId, int catalogueId)
        {
            var catalogue = _context.Catalogues.Select(c => new
            {
                Catalogue = c,
                Mentors = c.MentorCatalogues.Select(mc => mc.Mentor),
            }).Where(c => c.Catalogue.SchoolId == schoolId)
            .FirstOrDefault(c => c.Catalogue.Id == catalogueId);

            Domain.Mentor mentor = catalogue.Mentors.FirstOrDefault(m => m.Id == id);
            return _mapper.Map<Mentor>(mentor);
        }

        public Mentor AddCatalogueMentor(Mentor mentor, int schoolId, int catalogueId)
        {
            Domain.MentorCatalogue newCatalogueMentor = new Domain.MentorCatalogue()
            {
                MentorId = mentor.Id,
                CatalogueId = catalogueId
            };

            Domain.Catalogue catalogue = _context.Catalogues.Where(c => c.SchoolId == schoolId)
            .FirstOrDefault(c => c.Id == catalogueId);

            catalogue.MentorCatalogues.Add(newCatalogueMentor);
            _context.SaveChanges();

            return mentor;
        }

        public void DeleteCatalogueMentor(Mentor mentor, int schoolId, int catalogueId)
        {
            Domain.Catalogue catalogue = _context.Catalogues.Where(c => c.SchoolId == schoolId)
            .Include(c => c.MentorCatalogues).FirstOrDefault(c => c.Id == catalogueId);

            Domain.MentorCatalogue deleteCatalogueMentor = catalogue.MentorCatalogues
                .FirstOrDefault(mc => mc.MentorId == mentor.Id);

            catalogue.MentorCatalogues.Remove(deleteCatalogueMentor);
            _context.SaveChanges();
        }


        // Catalogue Students
        public ICollection<Student> GetAllCatalogueStudents(int schoolId, int catalogueId)
        {
            Domain.Catalogue catalogue = _context.Catalogues.Where(c => c.SchoolId == schoolId)
            .Include(c => c.Students).FirstOrDefault(c => c.Id == catalogueId);

            return (ICollection<Student>)_mapper.Map<IEnumerable<Student>>(catalogue.Students);
        }

        public Student GetCatalogueStudent(int id, int schoolId, int catalogueId)
        {
            Domain.Catalogue catalogue = _context.Catalogues.Where(c => c.SchoolId == schoolId)
            .Include(c => c.Students).FirstOrDefault(c => c.Id == catalogueId);

            Domain.Student student = catalogue.Students.FirstOrDefault(s => s.Id == id);

            return _mapper.Map<Student>(student);
        }

        public Student AddCatalogueStudent(Student student, int schoolId, int catalogueId)
        {
            Domain.Student newCatalogueStudent = _context.Students.Where(s => s.SchoolId == schoolId)
                .FirstOrDefault(s => s.Id == student.Id);

            newCatalogueStudent.CatalogueId = catalogueId;
            _context.SaveChanges();

            return student;
        }

        public void DeleteCatalogueStudent(Student student, int schoolId, int catalogueId)
        {
            Domain.Student deleteCatalogueStudent = _context.Students.Where(s => s.SchoolId == schoolId)
                .FirstOrDefault(s => s.Id == student.Id);

            deleteCatalogueStudent.CatalogueId = null;
            _context.SaveChanges();
        }


        // Catalogue Courses
        public ICollection<Course> GetAllCatalogueCourses(int schoolId, int catalogueId)
        {  
            var catalogue = _context.Catalogues.Select(c => new
            {
                Catalogue = c,
                Courses = c.CourseCatalogues.Select(cc => cc.Course),
                Subjects = c.CourseCatalogues.Select(cc => cc.Course).Select(c => c.Subject)
            }).Where(c => c.Catalogue.SchoolId == schoolId)
            .FirstOrDefault(c => c.Catalogue.Id == catalogueId);

            List<Course> courses = new List<Course>();
            foreach (var catalogueCourse in catalogue.Courses)
            {
                Course courseModel = _mapper.Map<Course>(catalogueCourse);
                Domain.Subject subject = catalogue.Subjects.FirstOrDefault(s => s.Id == catalogueCourse.SubjectId);
                courseModel.Subject = _mapper.Map<Subject>(subject);

                courses.Add(courseModel);
            }

            return courses;
        }

        public Course GetCatalogueCourse(int id, int schoolId, int catalogueId)
        {
            var course = _context.Catalogues.Select(c => new
            {
                Catalogue = c,
                Course = c.CourseCatalogues.Select(cc => cc.Course).FirstOrDefault(c => c.Id == id),
                Subjects = c.CourseCatalogues.Select(cc => cc.Course).Select(c => c.Subject)
            }).Where(c => c.Catalogue.SchoolId == schoolId).FirstOrDefault(c => c.Catalogue.Id == catalogueId);

            Course courseModel = _mapper.Map<Course>(course.Course);
            Domain.Subject subject = course.Subjects.FirstOrDefault(s => s.Id == course.Course.SubjectId);
            courseModel.Subject = _mapper.Map<Subject>(subject);

            return courseModel;
        }

        public Course AddCatalogueCourse(Course course, int schoolId, int catalogueId)
        {
            Domain.CourseCatalogue newCourseCatalogue = new Domain.CourseCatalogue()
            {
                CourseId = course.Id,
                CatalogueId = catalogueId
            };

            Domain.Catalogue catalogue = _context.Catalogues.Where(c => c.SchoolId == schoolId)
            .FirstOrDefault(c => c.Id == catalogueId);

            catalogue.CourseCatalogues.Add(newCourseCatalogue);
            _context.SaveChanges();

            return course;
        }
        public void DeleteCatalogueCourse(Course course, int schoolId, int catalogueId)
        {
            Domain.Catalogue catalogue = _context.Catalogues.Where(c => c.SchoolId == schoolId)
            .Include(c => c.CourseCatalogues).FirstOrDefault(c => c.Id == catalogueId);

            Domain.CourseCatalogue deleteCatalogueCourse = catalogue.CourseCatalogues
                .FirstOrDefault(cc => cc.CourseId == course.Id);

            catalogue.CourseCatalogues.Remove(deleteCatalogueCourse);
            _context.SaveChanges();
        }


        // Catalogue Grades
        public ICollection<Grade> GetAllCatalogueGrades(int schoolId, int catalogueId)
        {
            List<Domain.Grade> grades = _context.Grades.Include(g => g.Student).Include(g => g.Course)
                .Include(g => g.Course.Subject)
                .Include(g => g.Mentor).Where(g => g.CatalogueId == catalogueId).ToList();

            return (ICollection<Grade>)_mapper.Map<IEnumerable<Grade>>(grades);
        }

        public Grade GetCatalogueGrade(int id, int schoolId, int catalogueId)
        {
            Domain.Grade grade = _context.Grades.Include(g => g.Student).Include(g => g.Course)
                .Include(g => g.Course.Subject)
                .Include(g => g.Mentor).Where(g => g.CatalogueId == catalogueId)
                .FirstOrDefault(g => g.Id == id);

            return _mapper.Map<Grade>(grade);
        }

        public Grade AddCatalogueGrade(Grade grade, int schoolId, int catalogueId)
        {
            Domain.Grade newGrade = new Domain.Grade()
            {
                StudentId = grade.Student.Id,
                Mark = grade.Mark,
                MentorId = grade.Mentor.Id,
                Date = grade.Date,
                CourseId = grade.Course.Id,
                CatalogueId = catalogueId
            };
            _context.Grades.Add(newGrade);
            _context.SaveChanges();

            return grade;
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

        public void DeleteSubject(Subject subject, int schoolId)
        {
            Domain.Subject deleteSubject = _context.Subjects.FirstOrDefault(s => s.Id == subject.Id);
            _context.Subjects.Remove(deleteSubject);
            _context.SaveChanges();
        }

    }
}
