using E_LearningSite.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.Models
{
    public class InMemorySchoolDatabase : ISchoolRepository
    {
        private readonly List<School> _schoolDatabase;

        public InMemorySchoolDatabase()
        {
            _schoolDatabase = new List<School>()
            {
                new School()
                {
                     Id = 1,
                    Name = "Harvard",
                    Photo = "school1.jpg",
                    Principal = new Principal()
                    {
                        Id = 1,
                        Name = "Georgiana Ionescu",
                        Photo = "principal1.jpg",
                        BirthDate = new DateTime(1950, 12, 13),
                        AccessRights = AccessRights.FORPRINCIPALS
                    },
                    Mentors = new List<Mentor>()
                    {
                        new Mentor()
                        {
                            Id = 2,
                            Name = "Marcel Popescu",
                            Photo = "mentor11.jpg",
                            BirthDate = new DateTime(1960, 6, 6),
                            AccessRights = AccessRights.FORMENTORS
                        },
                        new Mentor()
                        {
                            Id = 3,
                            Name = "Adrian Barbu",
                            Photo = "mentor12.jpg",
                            BirthDate = new DateTime(1970, 1, 4),
                            AccessRights = AccessRights.FORMENTORS
                        },
                        new Mentor()
                        {
                            Id = 4,
                            Name = "Iulain Apostol",
                            Photo = "mentor13.jpg",
                            BirthDate = new DateTime(1980, 10, 23),
                            AccessRights = AccessRights.FORMENTORS
                        }
                    },
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Id = 4,
                            Name = "Elena Diaconescu",
                            BirthDate = new DateTime(1999, 5, 4),
                            Photo = "student11.jpg",
                            AccessRights = AccessRights.FORSTUDENTS
                        },
                        new Student()
                        {
                            Id = 5,
                            Name = "Costin Constantinescu",
                            Photo = "student12.jpg",
                            BirthDate = new DateTime(2000, 1, 1),
                            AccessRights = AccessRights.FORSTUDENTS
                        },
                        new Student()
                        {
                            Id = 6,
                            Name = "George Iordanescu",
                            Photo = "student14.jpg",
                            BirthDate = new DateTime(2000, 3, 17),
                            AccessRights = AccessRights.FORSTUDENTS
                        }
                    },
                    Courses = new List<Course>()
                    {
                        new Course()
                        {
                            Id = 1,
                            Name = "Solar System",
                            Description = "Discover the elements of the solar system",
                            Documents = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 1,
                                    Name = "Planets of the Solar system",
                                    Link = "Link 1"
                                },
                                new Document()
                                {
                                    Id = 2,
                                    Name = "Natural satellites",
                                    Link = "Link 2"
                                }
                            },
                            Subject = new Subject
                            {
                                Id = 3,
                                Name = "ASTRONOMY"
                            }
                        },
                        new Course()
                        {
                            Id = 2,
                            Name = "OOP",
                            Description = "Basic elements of OOP",
                            Documents = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 3,
                                    Name = "Classes and Methods",
                                    Link = "Link 1"
                                },
                                new Document()
                                {
                                    Id = 4,
                                    Name = "Overload and Override",
                                    Link = "Link 2"
                                }
                            },
                            Subject = new Subject
                            {
                                Id = 2,
                                Name = "IT"
                            }
                        }
                    },
                    Catalogues = new List<Catalogue>()
                    {
                        new Catalogue()
                        {
                            Id = 1,
                            Name = "9th Grade - Mathematic Informatic",
                            Mentors = new List<Mentor>(){},
                            Students = new List<Student>() {},
                            Courses = new List<Course>() {},
                            Grades = new List<Grade>() {}
                        },
                        new Catalogue()
                        {
                            Id = 2,
                            Name = "10th Grade - Science",
                            Mentors = new List<Mentor>(){},
                            Students = new List<Student>() {},
                            Courses = new List<Course>() {},
                            Grades = new List<Grade>() {}
                        }
                    },
                    Subjects = new List<Subject>()
                    {
                        new Subject()
                        {
                            Id= 1,
                            Name = "HISTORY"
                        },
                        new Subject()
                        {
                            Id= 2,
                            Name = "IT"
                        },
                        new Subject()
                        {
                            Id= 3,
                            Name = "ASTRONOMY"
                        }
                    }
                },
                new School()
                {
                    Id = 2,
                    Name = "Oxford",
                    Photo = "school2.jpg",
                    Principal = new Principal()
                    {
                        Id = 6,
                        Name = "Marian Stanciulescu",
                        Photo = "principal2.jpg",
                        BirthDate = new DateTime(1967, 1, 3),
                        AccessRights = AccessRights.FORPRINCIPALS
                    },
                    Mentors = new List<Mentor>()
                    {
                        new Mentor()
                        {
                            Id = 7,
                            Name = "Eric Angelescu",
                            Photo = "mentor21.jpg",
                            BirthDate = new DateTime(1964, 4, 16),
                            AccessRights = AccessRights.FORMENTORS
                        },
                        new Mentor()
                        {
                            Id = 8,
                            Name = "Emanuel Aramitu",
                            Photo = "mentor22.jpg",
                            BirthDate = new DateTime(1970, 1, 4),
                            AccessRights = AccessRights.FORMENTORS
                        },
                        new Mentor()
                        {
                            Id = 8,
                            Name = "Andrei Pavel",
                            Photo = "mentor23.jpg",
                            BirthDate = new DateTime(1966, 7, 25),
                            AccessRights = AccessRights.FORMENTORS
                        }
                    },
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Id = 9,
                            Name = "Diana Petrache",
                            Photo = "student21.jpg",
                            BirthDate = new DateTime(1989, 10, 24),
                            AccessRights = AccessRights.FORSTUDENTS
                        },
                        new Student()
                        {
                            Id = 10,
                            Name = "Dorian Stefan",
                            Photo = "student22.jpg",
                            BirthDate = new DateTime(2001, 10, 21),
                            AccessRights = AccessRights.FORSTUDENTS
                        },
                        new Student()
                        {
                            Id = 11,
                            Name = "Andreea Popescu",
                            Photo = "student23.jpg",
                            BirthDate = new DateTime(2000, 9, 30),
                            AccessRights = AccessRights.FORSTUDENTS
                        }
                    },
                    Courses = new List<Course>()
                    {
                        new Course()
                        {
                            Id = 1,
                            Name = "Cyber Security",
                            Description = "Basic elements of cyber security",
                            Documents = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 1,
                                    Name = "Malware",
                                    Link = "Link 1"
                                },
                                new Document()
                                {
                                    Id = 2,
                                    Name = "Data breaches",
                                    Link = "Link 2"
                                }
                            },
                            Subject = new Subject()
                            {
                                Id = 2,
                                Name = "IT"
                            }
                        },
                        new Course()
                        {
                            Id = 2,
                            Name = "World Word II",
                            Description = "The instability created in Europe by the First World War (1914-18) set the stage for another international conflict—World War II",
                            Documents = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 3,
                                    Name = "Outbreak of World War II(1939)",
                                    Link = "Link 1"
                                },
                                new Document()
                                {
                                    Id = 4,
                                    Name = "Hitler vs Stalin: Operation Barbosa(1941-1942)",
                                    Link = "Link 2"
                                }
                            },
                            Subject = new Subject()
                            {
                                Id = 1,
                                Name = "HISTORY"
                            }
                        }
                    },
                    Catalogues = new List<Catalogue>()
                    {
                        new Catalogue()
                        {
                            Id = 1,
                            Name = "9th Grade - Philosophy",
                            Mentors = new List<Mentor>(){ },
                            Students = new List<Student>() {},
                            Courses = new List<Course>() {},
                            Grades = new List<Grade>() {}
                        }
                    },
                    Subjects = new List<Subject>()
                    {
                        new Subject()
                        {
                            Id= 1,
                            Name = "HISTORY"
                        },
                        new Subject()
                        {
                            Id= 2,
                            Name = "IT"
                        },
                        new Subject()
                        {
                            Id= 3,
                            Name = "ASTRONOMY"
                        }
                    }
                }
            };
        }

        // Schools
        public School GetSchool(int id)
        {
            return _schoolDatabase.FirstOrDefault(s => s.Id == id);
        }

        public School AddSchool(School school)
        {
            school.Id = _schoolDatabase.DefaultIfEmpty().Max(s => s == null ? 0 : s.Id) + 1;
            _schoolDatabase.Add(school);
            return school;
        }

        public ICollection<School> GetAllSchools()
        {
            return _schoolDatabase;
        }

        public void UpdateSchool(School school, SchoolDTO schoolDTO)
        {
            school.Name = schoolDTO.Name;
            school.Photo = schoolDTO.Photo;
            school.Principal = schoolDTO.Principal;
        }

        public void DeleteSchool(School school)
        {
            _schoolDatabase.Remove(school);
        }

        // Mentors
        public Mentor AddMentor(Mentor mentor, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            mentor.Id = school.Mentors.DefaultIfEmpty().Max(m => m == null ? 0 : m.Id) + 1;
            school.Mentors.Add(mentor);
            return mentor;
        }

        public Mentor GetMentor(int id, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.Mentors.FirstOrDefault(m => m.Id == id);
        }

        public ICollection<Mentor> GetAllMentors(int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.Mentors;
        }

        public void UpdateMentor(Mentor mentor, PersonDTO personDTO)
        {
            mentor.Name = personDTO.Name;
            mentor.Photo = personDTO.Photo;
            mentor.BirthDate = personDTO.BirthDate;
            mentor.AccessRights = personDTO.AccessRights;
        }
        public void DeleteMentor(Mentor mentor, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            school.Catalogues.ForEach(c => c.Mentors.Remove(mentor));
            school.Mentors.Remove(mentor);
        }

        // Student
        public Student AddStudent(Student student, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            student.Id = school.Students.DefaultIfEmpty().Max(m => m == null ? 0 : m.Id) + 1;
            school.Students.Add(student);
            return student;
        }
        public Student GetStudent(int id, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.Students.FirstOrDefault(s => s.Id == id);
        }
        public ICollection<Student> GetAllStudents(int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.Students;
        }
        public void UpdateStudent(Student student, PersonDTO personDTO)
        {
            student.Name = personDTO.Name;
            student.Photo = personDTO.Photo;
            student.BirthDate = personDTO.BirthDate;
            student.AccessRights = personDTO.AccessRights;
        }
        public void DeleteStudent(Student student, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            school.Catalogues.ForEach(c => c.Students.Remove(student));
            school.Students.Remove(student);
        }

        // Courses
        public Course AddCourse(Course course, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            course.Id = school.Courses.DefaultIfEmpty().Max(c => c == null ? 0 : c.Id) + 1;
            school.Courses.Add(course);
            return course;
        }

        public Course GetCourse(int id, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.Courses.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Course> GetAllCourses(int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.Courses;
        }

        public void UpdateCourse(Course course, CourseDTO courseDTO, int schoolId)
        {
            course.Name = courseDTO.Name;
            int subjectId = courseDTO.SubjectId;
            ICollection<Subject> schoolSubjects = _schoolDatabase
                .FirstOrDefault(s => s.Id == schoolId).Subjects;
            Subject subject = schoolSubjects.FirstOrDefault(sbj => sbj.Id == subjectId);
            course.Subject = subject;
            course.Description = courseDTO.Description;
        }

        public void DeleteCourse(Course course, int schoolId)
        {
            _schoolDatabase.FirstOrDefault(s => s.Id == schoolId).Courses.Remove(course);
            _schoolDatabase.FirstOrDefault(s => s.Id == schoolId)
                .Catalogues.ForEach(c => c.Courses.Remove(course));
        }

        // Documents
        public Document AddDocument(Document document, int schoolId, int courseId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Course course = school.Courses.FirstOrDefault(c => c.Id == courseId);
            document.Id = course.Documents.DefaultIfEmpty().Max(d => d == null ? 0 : d.Id) + 1;
            course.Documents.Add(document);
            return document;
        }

        public Document GetDocument(int id, int schoolId, int courseId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Course course = school.Courses.FirstOrDefault(c => c.Id == courseId);
            return course.Documents.FirstOrDefault(d => d.Id == id);
        }

        public ICollection<Document> GetAllDocuments(int schoolId, int courseId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Course course = school.Courses.FirstOrDefault(c => c.Id == courseId);
            return course.Documents;
        }

        public void UpdateDocument(Document document, DocumentDTO documentDTO)
        {
            document.Name = documentDTO.Name;
            document.Link = documentDTO.Link;
        }
        public void DeleteDocument(Document document, int schoolId, int courseId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Course course = school.Courses.FirstOrDefault(c => c.Id == courseId);

            school.Catalogues.ForEach(cat => cat.Courses.ForEach(cc => cc.Documents.Remove(document)));
            course.Documents.Remove(document);
        }

        // Catalogues
        public Catalogue AddCatalogue(Catalogue catalogue, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            catalogue.Id = school.Catalogues.DefaultIfEmpty().Max(c => c == null ? 0 : c.Id) + 1;
            school.Catalogues.Add(catalogue);
            return catalogue;
        }

        public Catalogue GetCatalogue(int id, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.Catalogues.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Catalogue> GetAllCatalogues(int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.Catalogues;
        }

        public void UpdateCatalogue(Catalogue catalogue, CatalogueDTO catalogueDTO)
        {
            catalogue.Name = catalogueDTO.Name;
        }

        public void DeleteCatalogue(Catalogue catalogue, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            school.Catalogues.Remove(catalogue);
        }

        // Catalogue Mentors
        public Mentor AddCatalogueMentor(Mentor mentor, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.Catalogues.FirstOrDefault(c => c.Id == catalogueId);
            if (!catalogue.Mentors.Contains(mentor))
            {
                catalogue.Mentors.Add(mentor);
            }
            return mentor;
        }

        public Mentor GetCatalogueMentor(int id, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.Catalogues.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.Mentors.FirstOrDefault(m => m.Id == id);
        }

        public ICollection<Mentor> GetALLCatalogueMentors(int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.Catalogues.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.Mentors;
        }

        public void DeleteCatalogueMentor(Mentor mentor, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.Catalogues.FirstOrDefault(c => c.Id == catalogueId);
            catalogue.Mentors.Remove(mentor);
        }

        // Catalogue Students
        public Student AddCatalogueStudent(Student student, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.Catalogues.FirstOrDefault(c => c.Id == catalogueId);
            if (!catalogue.Students.Contains(student))
            {
                catalogue.Students.Add(student);
            }
            return student;
        }
        public Student GetCatalogueStudent(int id, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.Catalogues.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.Students.FirstOrDefault(s => s.Id == id);
        }
        public ICollection<Student> GetAllCatalogueStudents(int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.Catalogues.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.Students;
        }

        // Catalogue Courses
        public Course AddCatalogueCourse(Course course, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.Catalogues.FirstOrDefault(c => c.Id == catalogueId);
            if (!catalogue.Courses.Contains(course))
            {
                catalogue.Courses.Add(course);
            }
            return course;
        }
        public Course GetCatalogueCourse(int id, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.Catalogues.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.Courses.FirstOrDefault(c => c.Id == id);
        }
        public ICollection<Course> GetAllCatalogueCourses(int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.Catalogues.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.Courses;
        }

        // Catalogue Grades
        public Grade AddCatalogueGrade(Grade grade, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.Catalogues.FirstOrDefault(c => c.Id == catalogueId);
            grade.Id = catalogue.Grades.DefaultIfEmpty().Max(g => g == null ? 0 : g.Id) + 1;
            if (!catalogue.Grades.Contains(grade))
            {
                catalogue.Grades.Add(grade);
            }
            return grade;
        }
        public Grade GetCatalogueGrade(int id, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.Catalogues.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.Grades.FirstOrDefault(g => g.Id == id);
        }
        public ICollection<Grade> GetAllCatalogueGrades(int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.Catalogues.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.Grades;
        }

        // School Subjects
        public Subject AddSubject(Subject subject, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            subject.Id = school.Subjects.DefaultIfEmpty().Max(school => school == null ? 0 : school.Id) + 1;
            school.Subjects.Add(subject);
            return subject;
        }

        public Subject GetSubject(int id, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.Subjects.FirstOrDefault(s => s.Id == id);
        }

        public ICollection<Subject> GetAllSubjects(int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.Subjects;
        }

        public void UpdateSubject(Subject subject, SubjectDTO subjectDTO)
        {
            subject.Name = subjectDTO.Name;
        }

        public void DeleteSubject(Subject subject, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            school.Subjects.Remove(subject);
        }

        // Enums
        /*public List<EnumValue> GetValues<T>()
        {
            List<EnumValue> values = new List<EnumValue>();
            foreach(var itemType in Enum.GetValues(typeof(T)))
            {
                values.Add(new EnumValue() 
                {
                    Id = (int)itemType,
                    Name = Enum.GetName(typeof(T), itemType)
                });
            }
            return values;
        }*/
    }
}
