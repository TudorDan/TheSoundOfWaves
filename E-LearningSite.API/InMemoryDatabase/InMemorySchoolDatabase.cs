using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.DTOs
{
    public class InMemorySchoolDatabase : ISchoolRepository
    {
        private List<School> _schoolDatabase;

        public InMemorySchoolDatabase()
        {
            _schoolDatabase = new List<School>()
            {
                new School()
                {
                    Id = 1,
                    Name = "Weed Health Institute",
                    Principal = new Principal()
                    {
                        Id = 1,
                        Name = "Miss Danger",
                        BirthDate = new DateTime(1950, 12, 13),
                        AccessRights = AccessRights.FORPRINCIPALS
                    },
                    MentorsList = new List<Mentor>()
                    {
                        new Mentor()
                        {
                            Id = 2,
                            Name = "Tyrone Shotgun",
                            BirthDate = new DateTime(1960, 6, 6),
                            AccessRights = AccessRights.FORMENTORS
                        },
                        new Mentor()
                        {
                            Id = 3,
                            Name = "Johnny 3Fingers",
                            BirthDate = new DateTime(1970, 1, 4),
                            AccessRights = AccessRights.FORMENTORS
                        }
                    },
                    StudentsList = new List<Student>()
                    {
                        new Student()
                        {
                            Id = 4,
                            Name = "Sister Switchblades",
                            BirthDate = new DateTime(1999, 5, 4),
                            AccessRights = AccessRights.FORSTUDENTS
                        },
                        new Student()
                        {
                            Id = 5,
                            Name = "Jamal Gangsta LeeRoy",
                            BirthDate = new DateTime(2000, 1, 1),
                            AccessRights = AccessRights.FORSTUDENTS
                        }
                    },
                    CoursesList = new List<Course>()
                    {
                        new Course()
                        {
                            Id = 1,
                            Name = "Guessing Master of Science",
                            Subject = Subject.ASTRONOMY,
                            Description = "Pay for 1, you get 2",
                            CourseMaterials = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 1,
                                    Documentation = "Palm Reading doc 1",
                                    Link = "Palm Reading link 1"
                                },
                                new Document()
                                {
                                    Id = 2,
                                    Documentation = "Witchcraft doc 2",
                                    Link = "Witchcraft link 2"
                                }
                            }
                        },
                        new Course()
                        {
                            Id = 2,
                            Name = "How to Watch Television",
                            Subject = Subject.HISTORY,
                            Description = "For advanced majors",
                            CourseMaterials = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 3,
                                    Documentation = "Getting dressed doc 1",
                                    Link = "Getting dressed link 1"
                                },
                                new Document()
                                {
                                    Id = 4,
                                    Documentation = "The art of walking doc 2",
                                    Link = "The art of walking link 2"
                                }
                            }
                        }
                    },
                    CataloguesList = new List<Catalogue>()
                    {
                        new Catalogue()
                        {
                            Id = 1,
                            ClassName = "Cannabis Ist Class",
                            ClassMentors = new List<Mentor>(){},
                            ClassStudents = new List<Student>() {},
                            ClassCourses = new List<Course>() {},
                            ClassGrades = new List<Grade>() {}
                        },
                        new Catalogue()
                        {
                            Id = 2,
                            ClassName = "Fermentation IIIrd Class",
                            ClassMentors = new List<Mentor>(){},
                            ClassStudents = new List<Student>() {},
                            ClassCourses = new List<Course>() {},
                            ClassGrades = new List<Grade>() {}
                        }
                    }
                },
                new School()
                {
                    Id = 2,
                    Name = "Universidad Técnica de Buenas Maneras y Pistoleros",
                    Principal = new Principal()
                    {
                        Id = 6,
                        Name = "Don Guzman",
                        BirthDate = new DateTime(1967, 1, 3),
                        AccessRights = AccessRights.FORPRINCIPALS
                    },
                    MentorsList = new List<Mentor>()
                    {
                        new Mentor()
                        {
                            Id = 7,
                            Name = "Eric Blood Axe",
                            BirthDate = new DateTime(1964, 4, 16),
                            AccessRights = AccessRights.FORMENTORS
                        },
                        new Mentor()
                        {
                            Id = 8,
                            Name = "Tommy Machine Gun",
                            BirthDate = new DateTime(1970, 1, 4),
                            AccessRights = AccessRights.FORMENTORS
                        }
                    },
                    StudentsList = new List<Student>()
                    {
                        new Student()
                        {
                            Id = 9,
                            Name = "Donna Corason Intenso",
                            BirthDate = new DateTime(1989, 10, 24),
                            AccessRights = AccessRights.FORSTUDENTS
                        },
                        new Student()
                        {
                            Id = 10,
                            Name = "The Sleeping Student",
                            BirthDate = new DateTime(2001, 10, 21),
                            AccessRights = AccessRights.FORSTUDENTS
                        }
                    },
                    CoursesList = new List<Course>()
                    {
                        new Course()
                        {
                            Id = 1,
                            Name = "Hacking Ethics",
                            Subject = Subject.IT,
                            Description = "2nd edition",
                            CourseMaterials = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 1,
                                    Documentation = "hack doc 1",
                                    Link = "kack link 1"
                                },
                                new Document()
                                {
                                    Id = 2,
                                    Documentation = "hacky doc 2",
                                    Link = "hacky link 2"
                                }
                            }
                        },
                        new Course()
                        {
                            Id = 2,
                            Name = "The Answer to Life, The Universe and Everything",
                            Subject = Subject.HISTORY,
                            Description = "42",
                            CourseMaterials = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 3,
                                    Documentation = "Keep searching doc 1",
                                    Link = "Keep searching link 1"
                                },
                                new Document()
                                {
                                    Id = 4,
                                    Documentation = " doc 2",
                                    Link = " link 2"
                                }
                            }
                        }
                    },
                    CataloguesList = new List<Catalogue>()
                    {
                        new Catalogue()
                        {
                            Id = 1,
                            ClassName = "2nd Class",
                            ClassMentors = new List<Mentor>(){ },
                            ClassStudents = new List<Student>() {},
                            ClassCourses = new List<Course>() {},
                            ClassGrades = new List<Grade>() {}
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
            school.Id = _schoolDatabase.Max(s => s.Id) + 1;
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
            mentor.Id = school.MentorsList.Max(m => m.Id) + 1;
            school.MentorsList.Add(mentor);
            return mentor;
        }

        public Mentor GetMentor(int id, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.MentorsList.FirstOrDefault(m => m.Id == id);
        }

        public ICollection<Mentor> GetAllMentors(int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.MentorsList;
        }

        // Student
        public Student AddStudent(Student student, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            student.Id = school.StudentsList.Max(m => m.Id) + 1;
            school.StudentsList.Add(student);
            return student;
        }
        public Student GetStudent(int id, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.StudentsList.FirstOrDefault(s => s.Id == id);
        }
        public ICollection<Student> GetAllStudents(int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.StudentsList;
        }

        // Courses
        public Course AddCourse(Course course, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            course.Id = school.CoursesList.Max(c => c.Id) + 1;
            school.CoursesList.Add(course);
            return course;
        }
        public Course GetCourse(int id, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.CoursesList.FirstOrDefault(c => c.Id == id);
        }
        public ICollection<Course> GetAllCourses(int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.CoursesList;
        }

        // Documents
        public Document AddDocument(Document document, int schoolId, int courseId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Course course = school.CoursesList.FirstOrDefault(c => c.Id == courseId);
            course.CourseMaterials.Add(document);
            return document;
        }

        public Document GetDocument(int id, int schoolId, int courseId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Course course = school.CoursesList.FirstOrDefault(c => c.Id == courseId);
            return course.CourseMaterials.FirstOrDefault(d => d.Id == id);
        }

        public ICollection<Document> GetAllDocuments(int schoolId, int courseId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Course course = school.CoursesList.FirstOrDefault(c => c.Id == courseId);
            return course.CourseMaterials;
        }

        // Catalogues
        public Catalogue AddCatalogue(Catalogue catalogue, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            catalogue.Id = school.CataloguesList.Max(c => c.Id) + 1;
            school.CataloguesList.Add(catalogue);
            return catalogue;
        }
        public Catalogue GetCatalogue(int id, int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.CataloguesList.FirstOrDefault(c => c.Id == id);
        }
        public ICollection<Catalogue> GetAllCatalogues(int schoolId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            return school.CataloguesList;
        }

        // Catalogue Mentors
        public Mentor AddCatalogueMentor(Mentor mentor, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.CataloguesList.FirstOrDefault(c => c.Id == catalogueId);
            if (!catalogue.ClassMentors.Contains(mentor))
            {
                catalogue.ClassMentors.Add(mentor);
            }
            return mentor;
        }
        public Mentor GetCatalogueMentor(int id, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.CataloguesList.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.ClassMentors.FirstOrDefault(m => m.Id == id);
        }
        public ICollection<Mentor> GetALLCatalogueMentors(int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.CataloguesList.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.ClassMentors;
        }

        // Catalogue Students
        public Student AddCatalogueStudent(Student student, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.CataloguesList.FirstOrDefault(c => c.Id == catalogueId);
            if (!catalogue.ClassStudents.Contains(student))
            {
                catalogue.ClassStudents.Add(student);
            }
            return student;
        }
        public Student GetCatalogueStudent(int id, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.CataloguesList.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.ClassStudents.FirstOrDefault(s => s.Id == id);
        }
        public ICollection<Student> GetAllCatalogueStudents(int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.CataloguesList.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.ClassStudents;
        }

        // Catalogue Courses
        public Course AddCatalogueCourse(Course course, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.CataloguesList.FirstOrDefault(c => c.Id == catalogueId);
            if (!catalogue.ClassCourses.Contains(course))
            {
                catalogue.ClassCourses.Add(course);
            }
            return course;
        }
        public Course GetCatalogueCourse(int id, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.CataloguesList.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.ClassCourses.FirstOrDefault(c => c.Id == id);
        }
        public ICollection<Course> GetAllCatalogueCourses(int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.CataloguesList.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.ClassCourses;
        }

        // Catalogue Grades
        public Grade AddCatalogueGrade(Grade grade, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.CataloguesList.FirstOrDefault(c => c.Id == catalogueId);
            if (!catalogue.ClassGrades.Contains(grade))
            {
                catalogue.ClassGrades.Add(grade);
            }
            return grade;
        }
        public Grade GetCatalogueGrade(int id, int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.CataloguesList.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.ClassGrades.FirstOrDefault(g => g.Id == id);
        }
        public ICollection<Grade> GetAllCatalogueGrades(int schoolId, int catalogueId)
        {
            School school = _schoolDatabase.FirstOrDefault(s => s.Id == schoolId);
            Catalogue catalogue = school.CataloguesList.FirstOrDefault(c => c.Id == catalogueId);
            return catalogue.ClassGrades;
        }
    }
}
