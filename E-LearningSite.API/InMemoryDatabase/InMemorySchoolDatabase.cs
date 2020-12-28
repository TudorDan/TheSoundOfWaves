using E_LearningSite.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.DTOs
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
                    Name = "Weed Health Institute",
                    Photo = "school1.jpg",
                    Principal = new Principal()
                    {
                        Id = 1,
                        Name = "Miss Danger",
                        Photo = "principal1.jpg",
                        BirthDate = new DateTime(1950, 12, 13),
                        AccessRights = AccessRights.FORPRINCIPALS
                    },
                    Mentors = new List<Mentor>()
                    {
                        new Mentor()
                        {
                            Id = 2,
                            Name = "Tyrone Shotgun",
                            Photo = "mentor11.jpg",
                            BirthDate = new DateTime(1960, 6, 6),
                            AccessRights = AccessRights.FORMENTORS
                        },
                        new Mentor()
                        {
                            Id = 3,
                            Name = "Johnny 3Fingers",
                            Photo = "mentor12.jpg",
                            BirthDate = new DateTime(1970, 1, 4),
                            AccessRights = AccessRights.FORMENTORS
                        }
                    },
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Id = 4,
                            Name = "Sister Switchblades",
                            BirthDate = new DateTime(1999, 5, 4),
                            Photo = "student11.jpg",
                            AccessRights = AccessRights.FORSTUDENTS
                        },
                        new Student()
                        {
                            Id = 5,
                            Name = "Jamal Gangsta LeeRoy",
                            Photo = "student12.jpg",
                            BirthDate = new DateTime(2000, 1, 1),
                            AccessRights = AccessRights.FORSTUDENTS
                        }
                    },
                    Courses = new List<Course>()
                    {
                        new Course()
                        {
                            Id = 1,
                            Name = "Guessing Master of Science",
                            SubjectId = 3,
                            Description = "Pay for 1, you get 2",
                            Documents = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 1,
                                    Name = "Palm Reading doc 1",
                                    Link = "Palm Reading link 1"
                                },
                                new Document()
                                {
                                    Id = 2,
                                    Name = "Witchcraft doc 2",
                                    Link = "Witchcraft link 2"
                                }
                            },
                            Subject = new Subject
                            {
                                Id = 3,
                                SubjectType = SubjectType.ASTRONOMY
                            }
                        },
                        new Course()
                        {
                            Id = 2,
                            Name = "How to Watch Television",
                            SubjectId = 2,
                            Description = "For advanced majors",
                            Documents = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 3,
                                    Name = "Getting dressed doc 1",
                                    Link = "Getting dressed link 1"
                                },
                                new Document()
                                {
                                    Id = 4,
                                    Name = "The art of walking doc 2",
                                    Link = "The art of walking link 2"
                                }
                            },
                            Subject = new Subject
                            {
                                Id = 2,
                                SubjectType = SubjectType.IT
                            }
                        }
                    },
                    Catalogues = new List<Catalogue>()
                    {
                        new Catalogue()
                        {
                            Id = 1,
                            Name = "Steelers Ist Class",
                            Mentors = new List<Mentor>(){},
                            Students = new List<Student>() {},
                            Courses = new List<Course>() {},
                            Grades = new List<Grade>() {}
                        },
                        new Catalogue()
                        {
                            Id = 2,
                            Name = "Broncos IIIrd Class",
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
                            SubjectType = SubjectType.HISTORY
                        },
                        new Subject()
                        {
                            Id= 2,
                            SubjectType = SubjectType.IT
                        },
                        new Subject()
                        {
                            Id= 3,
                            SubjectType = SubjectType.ASTRONOMY
                        }
                    }
                },
                new School()
                {
                    Id = 2,
                    Name = "Universidad Técnica de Buenas Maneras y Pistoleros",
                    Photo = "school2.jpg",
                    Principal = new Principal()
                    {
                        Id = 6,
                        Name = "Don Guzman",
                        Photo = "principal2.jpg",
                        BirthDate = new DateTime(1967, 1, 3),
                        AccessRights = AccessRights.FORPRINCIPALS
                    },
                    Mentors = new List<Mentor>()
                    {
                        new Mentor()
                        {
                            Id = 7,
                            Name = "Eric Blood Axe",
                            Photo = "mentor21.jpg",
                            BirthDate = new DateTime(1964, 4, 16),
                            AccessRights = AccessRights.FORMENTORS
                        },
                        new Mentor()
                        {
                            Id = 8,
                            Name = "Tommy Machine Gun",
                            Photo = "mentor22.jpg",
                            BirthDate = new DateTime(1970, 1, 4),
                            AccessRights = AccessRights.FORMENTORS
                        }
                    },
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Id = 9,
                            Name = "Donna Corason Intenso",
                            Photo = "student21.jpg",
                            BirthDate = new DateTime(1989, 10, 24),
                            AccessRights = AccessRights.FORSTUDENTS
                        },
                        new Student()
                        {
                            Id = 10,
                            Name = "The Sleeping Student",
                            Photo = "student22.jpg",
                            BirthDate = new DateTime(2001, 10, 21),
                            AccessRights = AccessRights.FORSTUDENTS
                        }
                    },
                    Courses = new List<Course>()
                    {
                        new Course()
                        {
                            Id = 1,
                            Name = "Hacking Ethics",
                            SubjectId = 2,
                            Description = "2nd edition",
                            Documents = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 1,
                                    Name = "Torrent doc 1",
                                    Link = "Torrent link 1"
                                },
                                new Document()
                                {
                                    Id = 2,
                                    Name = "Pirating doc 2",
                                    Link = "Pirating link 2"
                                }
                            },
                            Subject = new Subject()
                            {
                                Id = 2,
                                SubjectType = SubjectType.IT
                            }
                        },
                        new Course()
                        {
                            Id = 2,
                            Name = "The Answer to Life, The Universe and Everything",
                            SubjectId = 1,
                            Description = "42",
                            Documents = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 3,
                                    Name = "Keep searching doc 1",
                                    Link = "Keep searching link 1"
                                },
                                new Document()
                                {
                                    Id = 4,
                                    Name = "Keep searching doc 2",
                                    Link = "Keep searching link 2"
                                }
                            },
                            Subject = new Subject()
                            {
                                Id = 1,
                                SubjectType = SubjectType.HISTORY
                            }
                        }
                    },
                    Catalogues = new List<Catalogue>()
                    {
                        new Catalogue()
                        {
                            Id = 1,
                            Name = "Chargers 2nd Class",
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
                            SubjectType = SubjectType.HISTORY
                        },
                        new Subject()
                        {
                            Id= 2,
                            SubjectType = SubjectType.IT
                        },
                        new Subject()
                        {
                            Id= 3,
                            SubjectType = SubjectType.ASTRONOMY
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
