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
                    Name = "Salem School of Witchcraft",
                    Principal = new Principal()
                    {
                        Id = 1,
                        Name = "Baba Cloanta",
                        BirthDate = new DateTime(1950, 12, 13),
                        AccessRights = AccessRights.FORPRINCIPALS
                    },
                    MentorsList = new List<Mentor>()
                    {
                        new Mentor()
                        {
                            Id = 2,
                            Name = "Eric BloodAxe",
                            BirthDate = new DateTime(1960, 6, 6),
                            AccessRights = AccessRights.FORMENTORS
                        },
                        new Mentor()
                        {
                            Id = 3,
                            Name = "Harald BlueTooth",
                            BirthDate = new DateTime(1970, 1, 4),
                            AccessRights = AccessRights.FORMENTORS
                        }
                    },
                    StudentsList = new List<Student>()
                    {
                        new Student()
                        {
                            Id = 4,
                            Name = "Titus Killer",
                            BirthDate = new DateTime(1999, 5, 4),
                            AccessRights = AccessRights.FORSTUDENTS
                        },
                        new Student()
                        {
                            Id = 5,
                            Name = "John 3Fingers",
                            BirthDate = new DateTime(2000, 1, 1),
                            AccessRights = AccessRights.FORSTUDENTS
                        }
                    },
                    CoursesList = new List<Course>()
                    {
                        new Course()
                        {
                            Id = 1,
                            Name = "Cuantum Physics",
                            Subject = Subject.ASTRONOMY,
                            Description = "Very simple",
                            CourseMaterials = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 1,
                                    Documentation = "Bla bla",
                                    Link = ""
                                },
                                new Document()
                                {
                                    Id = 2,
                                    Documentation = "Blu blu",
                                    Link = ""
                                }
                            }
                        },
                        new Course()
                        {
                            Id = 2,
                            Name = "Prolegomene hagiografice",
                            Subject = Subject.HISTORY,
                            Description = "Very simple",
                            CourseMaterials = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 3,
                                    Documentation = "Ble ble",
                                    Link = ""
                                },
                                new Document()
                                {
                                    Id = 4,
                                    Documentation = "Ble ble",
                                    Link = ""
                                }
                            }
                        }
                    },
                    CataloguesList = new List<Catalogue>()
                    {
                        new Catalogue()
                        {
                            Id = 1,
                            ClassName = "Clasa a I-a",
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
                    Name = "School Nr 24",
                    Principal = new Principal()
                    {
                        Id = 6,
                        Name = "Mrs. Iancu",
                        BirthDate = new DateTime(1967, 1, 3),
                        AccessRights = AccessRights.FORPRINCIPALS
                    },
                    MentorsList = new List<Mentor>()
                    {
                        new Mentor()
                        {
                            Id = 7,
                            Name = "Plutarch",
                            BirthDate = new DateTime(1964, 4, 16),
                            AccessRights = AccessRights.FORMENTORS
                        },
                        new Mentor()
                        {
                            Id = 8,
                            Name = "Suetonius",
                            BirthDate = new DateTime(1970, 1, 4),
                            AccessRights = AccessRights.FORMENTORS
                        }
                    },
                    StudentsList = new List<Student>()
                    {
                        new Student()
                        {
                            Id = 9,
                            Name = "Xenophon",
                            BirthDate = new DateTime(1989, 10, 24),
                            AccessRights = AccessRights.FORSTUDENTS
                        },
                        new Student()
                        {
                            Id = 10,
                            Name = "Herodot",
                            BirthDate = new DateTime(2001, 10, 21),
                            AccessRights = AccessRights.FORSTUDENTS
                        }
                    },
                    CoursesList = new List<Course>()
                    {
                        new Course()
                        {
                            Id = 1,
                            Name = "DOT NET",
                            Subject = Subject.IT,
                            Description = "Phenomenal",
                            CourseMaterials = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 1,
                                    Documentation = "Bli bli",
                                    Link = ""
                                },
                                new Document()
                                {
                                    Id = 2,
                                    Documentation = "1 + 1 = 3",
                                    Link = ""
                                }
                            }
                        },
                        new Course()
                        {
                            Id = 2,
                            Name = "Paradigme istoriografice",
                            Subject = Subject.HISTORY,
                            Description = "hagiografie",
                            CourseMaterials = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 3,
                                    Documentation = "Blq blq",
                                    Link = ""
                                },
                                new Document()
                                {
                                    Id = 4,
                                    Documentation = "agfhdh",
                                    Link = ""
                                }
                            }
                        }
                    },
                    CataloguesList = new List<Catalogue>()
                    {
                        new Catalogue()
                        {
                            Id = 1,
                            ClassName = "Clasa a II-a",
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
    }
}
