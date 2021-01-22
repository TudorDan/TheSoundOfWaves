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
                    Photo = "school1.jpg"                 
                },
                new School()
                {
                    Id = 2,
                    Name = "Universidad Técnica de Buenas Maneras y Pistoleros",
                    Photo = "school2.jpg"
                }
            );

            modelBuilder.Entity<Principal>().HasData(
                    new Principal()
                    {
                        Id = 1,
                        Name = "Miss Danger",
                        Photo = "principal1.jpg",
                        BirthDate = new DateTime(1950, 12, 13),
                        AccessRights = AccessRights.FORPRINCIPALS,
                        SchoolId = 1
                    },
                    new Principal()
                    {
                        Id = 2,
                        Name = "Don Guzman",
                        Photo = "principal2.jpg",
                        BirthDate = new DateTime(1967, 1, 3),
                        AccessRights = AccessRights.FORPRINCIPALS,
                        SchoolId = 2
                    }
                );

            modelBuilder.Entity<Subject>().HasData(
                    new Subject()
                    {
                        Id = 1,
                        Name = "HISTORY",
                        SchoolId = 1
                    },
                    new Subject()
                    {
                        Id = 2,
                        Name = "IT",
                        SchoolId = 1
                    },
                    new Subject()
                    {
                        Id = 3,
                        Name = "ASTRONOMY",
                        SchoolId = 1
                    },
                    new Subject()
                    {
                        Id = 4,
                        Name = "IT",
                        SchoolId = 2
                    },
                    new Subject()
                    {
                        Id = 5,
                        Name = "HISTORY",
                        SchoolId = 2
                    }
                );

            modelBuilder.Entity<Mentor>().HasData(
                    new Mentor()
                    {
                        Id = 1,
                        Name = "Tyrone Shotgun",
                        Photo = "mentor11.jpg",
                        BirthDate = new DateTime(1960, 6, 6),
                        AccessRights = AccessRights.FORMENTORS,
                        SchoolId = 1
                    },
                    new Mentor()
                    {
                        Id = 2,
                        Name = "Johnny 3Fingers",
                        Photo = "mentor12.jpg",
                        BirthDate = new DateTime(1970, 1, 4),
                        AccessRights = AccessRights.FORMENTORS,
                        SchoolId = 1
                    },
                    new Mentor()
                    {
                        Id = 3,
                        Name = "Eric Blood Axe",
                        Photo = "mentor21.jpg",
                        BirthDate = new DateTime(1964, 4, 16),
                        AccessRights = AccessRights.FORMENTORS,
                        SchoolId = 2
                    },
                    new Mentor()
                    {
                        Id = 4,
                        Name = "Tommy Machine Gun",
                        Photo = "mentor22.jpg",
                        BirthDate = new DateTime(1970, 1, 4),
                        AccessRights = AccessRights.FORMENTORS,
                        SchoolId = 2
                    }
                );

            modelBuilder.Entity<Student>().HasData(
                    new Student()
                    {
                        Id = 1,
                        Name = "Sister Switchblades",
                        Photo = "student11.jpg",
                        BirthDate = new DateTime(1999, 5, 4),
                        AccessRights = AccessRights.FORSTUDENTS,
                        SchoolId = 1
                    },
                    new Student()
                    {
                        Id = 5,
                        Name = "Jamal Gangsta LeeRoy",
                        Photo = "student12.jpg",
                        BirthDate = new DateTime(2000, 1, 1),
                        AccessRights = AccessRights.FORSTUDENTS,
                        SchoolId = 1
                    },
                    new Student()
                    {
                        Id = 9,
                        Name = "Donna Corason Intenso",
                        Photo = "student21.jpg",
                        BirthDate = new DateTime(1989, 10, 24),
                        AccessRights = AccessRights.FORSTUDENTS,
                        SchoolId = 2
                    },
                    new Student()
                    {
                        Id = 10,
                        Name = "The Sleeping Student",
                        Photo = "student22.jpg",
                        BirthDate = new DateTime(2001, 10, 21),
                        AccessRights = AccessRights.FORSTUDENTS,
                        SchoolId = 2
                    }
                );

            modelBuilder.Entity<Course>().HasData(
                    new Course()
                    {
                        Id = 1,
                        Name = "Guessing Master of Science",
                        SubjectId = 3,
                        Description = "Pay for 1, you get 2",
                        SchoolId = 1
                    },
                    new Course()
                    {
                        Id = 2,
                        Name = "How to Watch Television",
                        SubjectId = 1,
                        Description = "For advanced majors",
                        SchoolId = 1
                    },
                    new Course()
                    {
                        Id = 3,
                        Name = "Hacking Ethics",
                        SubjectId = 4,
                        Description = "2nd edition",
                        SchoolId = 2
                    },
                    new Course()
                    {
                        Id = 4,
                        Name = "The Answer to Life, The Universe and Everything",
                        SubjectId = 5,
                        Description = "42",
                        SchoolId = 2
                    }
                );

            modelBuilder.Entity<Document>().HasData(
                    new Document()
                    {
                        Id = 1,
                        Name = "Palm Reading doc 1",
                        Link = "Palm Reading link 1",
                        CourseId = 1
                    },
                    new Document()
                    {
                        Id = 2,
                        Name = "Witchcraft doc 2",
                        Link = "Witchcraft link 2",
                        CourseId = 1
                    },
                    new Document()
                    {
                        Id = 3,
                        Name = "Getting dressed doc 1",
                        Link = "Getting dressed link 1",
                        CourseId = 2
                    },
                    new Document()
                    {
                        Id = 4,
                        Name = "The art of walking doc 2",
                        Link = "The art of walking link 2",
                        CourseId = 2
                    },
                    new Document()
                    {
                        Id = 5,
                        Name = "hack doc 1",
                        Link = "kack link 1",
                        CourseId = 3
                    },
                    new Document()
                    {
                        Id = 6,
                        Name = "hacky doc 2",
                        Link = "hacky link 2",
                        CourseId = 4
                    },
                    new Document()
                    {
                        Id = 7,
                        Name = "Keep searching doc 1",
                        Link = "Keep searching link 1",
                        CourseId = 4
                    },
                    new Document()
                    {
                        Id = 8,
                        Name = " doc 2",
                        Link = " link 2",
                        CourseId = 4
                    }
                );

            modelBuilder.Entity<Catalogue>().HasData(
                    new Catalogue()
                    {
                        Id = 1,
                        Name = "Broncos Ist Grade",
                        SchoolId = 1
                    },
                    new Catalogue()
                    {
                        Id = 2,
                        Name = "Steelers IIIrd Grade",
                        SchoolId = 1
                    },
                    new Catalogue()
                    {
                        Id = 3,
                        Name = "Cowboys 9th Grade",
                        SchoolId = 2
                    }
                );
        }
    }
}
