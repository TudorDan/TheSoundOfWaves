using E_LearningSite.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_LearningSite.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().HasData(
                new School()
                {
                    Id = 1,
                    Name = "Weed Health Institute",
                    Photo = "school1.jpg",
                    /*Principal = new Principal()
                    {
                        Id = 1,
                        Name = "Miss Danger",
                        Photo = "http://localhost:54719/images/principal1.jpg",
                        BirthDate = new DateTime(1950, 12, 13),
                        AccessRights = AccessRights.FORPRINCIPALS
                    },
                    Mentors = new List<Mentor>()
                    {
                        new Mentor()
                        {
                            Id = 2,
                            Name = "Tyrone Shotgun",
                            Photo = "http://localhost:54719/images/mentor11.jpg",
                            BirthDate = new DateTime(1960, 6, 6),
                            AccessRights = AccessRights.FORMENTORS
                        },
                        new Mentor()
                        {
                            Id = 3,
                            Name = "Johnny 3Fingers",
                            Photo = "http://localhost:54719/images/mentor12.jpg",
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
                            Photo = "http://localhost:54719/images/student11.jpg",
                            AccessRights = AccessRights.FORSTUDENTS
                        },
                        new Student()
                        {
                            Id = 5,
                            Name = "Jamal Gangsta LeeRoy",
                            Photo = "http://localhost:54719/images/student12.jpg",
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
                            Subject = new Subject(1, "ASTRONOMY", SubjectType.ASTRONOMY),
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
                            SchoolId = 1
                        },
                        new Course()
                        {
                            Id = 2,
                            Name = "How to Watch Television",
                            Subject = new Subject(2, "HISTORY", SubjectType.HISTORY),
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
                            SchoolId = 1
                        }
                    },
                    Catalogues = new List<Catalogue>()
                    {
                        new Catalogue()
                        {
                            Id = 1,
                            Name = "Cannabis Ist Class",
                            Mentors = new List<Mentor>(){},
                            Students = new List<Student>() {},
                            Courses = new List<Course>() {},
                            Grades = new List<Grade>() {},
                            SchoolId = 1
                        },
                        new Catalogue()
                        {
                            Id = 2,
                            Name = "Fermentation IIIrd Class",
                            Mentors = new List<Mentor>(){},
                            Students = new List<Student>() {},
                            Courses = new List<Course>() {},
                            Grades = new List<Grade>() {},
                            SchoolId = 1
                        }
                    },
                    Subjects = new List<Subject>()
                    {
                        new Subject()
                        {
                            Id = 1,
                            SubjectType = SubjectType.HISTORY,
                            SchoolId = 1
                        },
                        new Subject()
                        {
                            Id = 2,
                            SubjectType = SubjectType.IT,
                            SchoolId = 1
                        },
                        new Subject()
                        {
                            Id = 3,
                            SubjectType = SubjectType.ASTRONOMY,
                            SchoolId = 1
                        }
                    }*/
                },
                new School()
                {
                    Id = 2,
                    Name = "Universidad Técnica de Buenas Maneras y Pistoleros",
                    Photo = "school2.jpg",
                    /*Principal = new Principal()
                    {
                        Id = 6,
                        Name = "Don Guzman",
                        Photo = "http://localhost:54719/images/principal2.jpg",
                        BirthDate = new DateTime(1967, 1, 3),
                        AccessRights = AccessRights.FORPRINCIPALS
                    },
                    Mentors = new List<Mentor>()
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
                    Students = new List<Student>()
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
                    Courses = new List<Course>()
                    {
                        new Course()
                        {
                            Id = 1,
                            Name = "Hacking Ethics",
                            Subject = new Subject(3, "IT", SubjectType.IT),
                            Description = "2nd edition",
                            Documents = new List<Document>()
                            {
                                new Document()
                                {
                                    Id = 1,
                                    Name = "hack doc 1",
                                    Link = "kack link 1"
                                },
                                new Document()
                                {
                                    Id = 2,
                                    Name = "hacky doc 2",
                                    Link = "hacky link 2"
                                }
                            },
                            SchoolId = 2
                        },
                        new Course()
                        {
                            Id = 2,
                            Name = "The Answer to Life, The Universe and Everything",
                            Subject = new Subject(4, "HISTORY", SubjectType.HISTORY),
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
                                    Name = " doc 2",
                                    Link = " link 2"
                                }
                            },
                            SchoolId = 2
                        }
                    },
                    Catalogues = new List<Catalogue>()
                    {
                        new Catalogue()
                        {
                            Id = 1,
                            Name = "2nd Class",
                            Mentors = new List<Mentor>(){ },
                            Students = new List<Student>() {},
                            Courses = new List<Course>() {},
                            Grades = new List<Grade>() {},
                            SchoolId = 2
                        }
                    }*/
                }
            );

        }
    }
}
