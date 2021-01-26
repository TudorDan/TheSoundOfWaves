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
                    Name = "Harvard",
                    Photo = "school1.jpg"                 
                },
                new School()
                {
                    Id = 2,
                    Name = "Oxford",
                    Photo = "school2.jpg"
                }
            );

            modelBuilder.Entity<Principal>().HasData(
                    new Principal()
                    {
                        Id = 1,
                        Name = "Georgiana Ionescu",
                        Photo = "principal1.jpg",
                        BirthDate = new DateTime(1950, 12, 13),
                        AccessRights = AccessRights.FORPRINCIPALS,
                        SchoolId = 1
                    },
                    new Principal()
                    {
                        Id = 2,
                        Name = "Marian Stanciulescu",
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
                        Name = "HISTORY",
                        SchoolId = 2
                    },
                    new Subject()
                    {
                        Id = 5,
                        Name = "IT",
                        SchoolId = 2
                    }, 
                    new Subject()
                    {
                        Id = 6,
                        Name = "ASTRONOMY",
                        SchoolId = 2
                    }
                );

            modelBuilder.Entity<Mentor>().HasData(
                    new Mentor()
                    {
                        Id = 1,
                        Name = "Marcel Popescu",
                        Photo = "mentor11.jpg",
                        BirthDate = new DateTime(1960, 6, 6),
                        AccessRights = AccessRights.FORMENTORS,
                        SchoolId = 1
                    },
                    new Mentor()
                    {
                        Id = 2,
                        Name = "Adrian Barbu",
                        Photo = "mentor12.jpg",
                        BirthDate = new DateTime(1970, 1, 4),
                        AccessRights = AccessRights.FORMENTORS,
                        SchoolId = 1
                    },
                    new Mentor()
                    {
                        Id = 3,
                        Name = "Iulain Apostol",
                        Photo = "mentor13.jpg",
                        BirthDate = new DateTime(1980, 10, 23),
                        AccessRights = AccessRights.FORMENTORS,
                        SchoolId = 1
                    },
                    new Mentor()
                    {
                        Id = 4,
                        Name = "Eric Angelescu",
                        Photo = "mentor21.jpg",
                        BirthDate = new DateTime(1964, 4, 16),
                        AccessRights = AccessRights.FORMENTORS,
                        SchoolId = 2
                    },
                    new Mentor()
                    {
                        Id = 5,
                        Name = "Emanuel Aramitu",
                        Photo = "mentor22.jpg",
                        BirthDate = new DateTime(1970, 1, 4),
                        AccessRights = AccessRights.FORMENTORS,
                        SchoolId = 2
                    },
                    new Mentor()
                    {
                        Id = 6,
                        Name = "Andrei Pavel",
                        Photo = "mentor23.jpg",
                        BirthDate = new DateTime(1966, 7, 25),
                        AccessRights = AccessRights.FORMENTORS,
                        SchoolId = 2
                    }
                );

            modelBuilder.Entity<Student>().HasData(
                    new Student()
                    {
                        Id = 1,
                        Name = "Elena Diaconescu",
                        Photo = "student11.jpg",
                        BirthDate = new DateTime(1999, 5, 4),
                        AccessRights = AccessRights.FORSTUDENTS,
                        SchoolId = 1
                    },
                    new Student()
                    {
                        Id = 2,
                        Name = "Costin Constantinescu",
                        Photo = "student12.jpg",
                        BirthDate = new DateTime(2000, 1, 1),
                        AccessRights = AccessRights.FORSTUDENTS,
                        SchoolId = 1
                    },
                    new Student()
                    {
                        Id = 3,
                        Name = "George Iordanescu",
                        Photo = "student14.jpg",
                        BirthDate = new DateTime(2000, 3, 17),
                        AccessRights = AccessRights.FORSTUDENTS,
                        SchoolId = 1
                    },
                    new Student()
                    {
                        Id = 4,
                        Name = "Diana Petrache",
                        Photo = "student21.jpg",
                        BirthDate = new DateTime(1989, 10, 24),
                        AccessRights = AccessRights.FORSTUDENTS,
                        SchoolId = 2
                    },
                    new Student()
                    {
                        Id = 5,
                        Name = "Dorian Stefan",
                        Photo = "student22.jpg",
                        BirthDate = new DateTime(2001, 10, 21),
                        AccessRights = AccessRights.FORSTUDENTS,
                        SchoolId = 2
                    },
                    new Student()
                    {
                        Id = 6,
                        Name = "Andreea Popescu",
                        Photo = "student23.jpg",
                        BirthDate = new DateTime(2000, 9, 30),
                        AccessRights = AccessRights.FORSTUDENTS,
                        SchoolId = 2
                    }
                );

            modelBuilder.Entity<Course>().HasData(
                    new Course()
                    {
                        Id = 1,
                        Name = "Solar System",
                        SubjectId = 3,
                        Description = "Discover the elements of the solar system",
                        SchoolId = 1
                    },
                    new Course()
                    {
                        Id = 2,
                        Name = "OOP",
                        SubjectId = 2,
                        Description = "Basic elements of OOP",
                        SchoolId = 1
                    },
                    new Course()
                    {
                        Id = 3,
                        Name = "Cyber Security",
                        SubjectId = 5,
                        Description = "Basic elements of cyber security",
                        SchoolId = 2
                    },
                    new Course()
                    {
                        Id = 4,
                        Name = "World Word II",
                        SubjectId = 4,
                        Description = "Political, Economic and Diplomatic Causes in the Far East",
                        SchoolId = 2
                    }
                );

            modelBuilder.Entity<Document>().HasData(
                    new Document()
                    {
                        Id = 1,
                        Name = "Planets of the Solar system",
                        Link = "Link 1",
                        CourseId = 1
                    },
                    new Document()
                    {
                        Id = 2,
                        Name = "Natural satellites",
                        Link = "Link 2",
                        CourseId = 1
                    },
                    new Document()
                    {
                        Id = 3,
                        Name = "Classes and Methods",
                        Link = "Link 1",
                        CourseId = 2
                    },
                    new Document()
                    {
                        Id = 4,
                        Name = "Overload and Override",
                        Link = "Link 2",
                        CourseId = 2
                    },
                    new Document()
                    {
                        Id = 5,
                        Name = "Malware",
                        Link = "Link 1",
                        CourseId = 3
                    },
                    new Document()
                    {
                        Id = 6,
                        Name = "Data breaches",
                        Link = "Link 2",
                        CourseId = 3
                    },
                    new Document()
                    {
                        Id = 7,
                        Name = "Chinese Warlords, Kuomintang and Marco Polo Incident(1937)",
                        Link = "Link 1",
                        CourseId = 4
                    },
                    new Document()
                    {
                        Id = 8,
                        Name = "Soviet–Japanese border interests and the Battle of Khalkin Gol(1939)",
                        Link = "Link 2",
                        CourseId = 4
                    }
                );

            modelBuilder.Entity<Catalogue>().HasData(
                    new Catalogue()
                    {
                        Id = 1,
                        Name = "9th Grade - Mathematics Informatics",
                        SchoolId = 1
                    },
                    new Catalogue()
                    {
                        Id = 2,
                        Name = "10th Grade - Science",
                        SchoolId = 1
                    },
                    new Catalogue()
                    {
                        Id = 3,
                        Name = "9th Grade - Philosophy",
                        SchoolId = 2
                    }
                );
        }
    }
}
