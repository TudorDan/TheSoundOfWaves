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
                    //Id = 1,
                    //Name = "Weed Health Institute",
                    //Photo = "http://localhost:54719/images/school1.jpg",
                    //Principal = new Principal()
                    //{
                    //    Id = 1,
                    //    Name = "Miss Danger",
                    //    Photo = "http://localhost:54719/images/principal1.jpg",
                    //    BirthDate = new DateTime(1950, 12, 13),
                    //    AccessRights = AccessRights.FORPRINCIPALS
                    //},
                    //MentorsList = new List<Mentor>()
                    //{
                    //    new Mentor()
                    //    {
                    //        Id = 2,
                    //        Name = "Tyrone Shotgun",
                    //        Photo = "http://localhost:54719/images/mentor11.jpg",
                    //        BirthDate = new DateTime(1960, 6, 6),
                    //        AccessRights = AccessRights.FORMENTORS
                    //    },
                    //    new Mentor()
                    //    {
                    //        Id = 3,
                    //        Name = "Johnny 3Fingers",
                    //        Photo = "http://localhost:54719/images/mentor12.jpg",
                    //        BirthDate = new DateTime(1970, 1, 4),
                    //        AccessRights = AccessRights.FORMENTORS
                    //    }
                    //},
                    //StudentsList = new List<Student>()
                    //{
                    //    new Student()
                    //    {
                    //        Id = 4,
                    //        Name = "Sister Switchblades",
                    //        BirthDate = new DateTime(1999, 5, 4),
                    //        Photo = "http://localhost:54719/images/student11.jpg",
                    //        AccessRights = AccessRights.FORSTUDENTS
                    //    },
                    //    new Student()
                    //    {
                    //        Id = 5,
                    //        Name = "Jamal Gangsta LeeRoy",
                    //        Photo = "http://localhost:54719/images/student12.jpg",
                    //        BirthDate = new DateTime(2000, 1, 1),
                    //        AccessRights = AccessRights.FORSTUDENTS
                    //    }
                    //},
                    //CoursesList = new List<Course>()
                    //{
                    //    new Course()
                    //    {
                    //        Id = 1,
                    //        Name = "Guessing Master of Science",
                    //        Subject = Subject.ASTRONOMY,
                    //        Description = "Pay for 1, you get 2",
                    //        CourseMaterials = new List<Document>()
                    //        {
                    //            new Document()
                    //            {
                    //                Id = 1,
                    //                Documentation = "Palm Reading doc 1",
                    //                Link = "Palm Reading link 1"
                    //            },
                    //            new Document()
                    //            {
                    //                Id = 2,
                    //                Documentation = "Witchcraft doc 2",
                    //                Link = "Witchcraft link 2"
                    //            }
                    //        }
                    //    },
                    //    new Course()
                    //    {
                    //        Id = 2,
                    //        Name = "How to Watch Television",
                    //        Subject = Subject.HISTORY,
                    //        Description = "For advanced majors",
                    //        CourseMaterials = new List<Document>()
                    //        {
                    //            new Document()
                    //            {
                    //                Id = 3,
                    //                Documentation = "Getting dressed doc 1",
                    //                Link = "Getting dressed link 1"
                    //            },
                    //            new Document()
                    //            {
                    //                Id = 4,
                    //                Documentation = "The art of walking doc 2",
                    //                Link = "The art of walking link 2"
                    //            }
                    //        }
                    //    }
                    //},
                    //CataloguesList = new List<Catalogue>()
                    //{
                    //    new Catalogue()
                    //    {
                    //        Id = 1,
                    //        ClassName = "Cannabis Ist Class",
                    //        ClassMentors = new List<Mentor>(){},
                    //        ClassStudents = new List<Student>() {},
                    //        ClassCourses = new List<Course>() {},
                    //        ClassGrades = new List<Grade>() {}
                    //    },
                    //    new Catalogue()
                    //    {
                    //        Id = 2,
                    //        ClassName = "Fermentation IIIrd Class",
                    //        ClassMentors = new List<Mentor>(){},
                    //        ClassStudents = new List<Student>() {},
                    //        ClassCourses = new List<Course>() {},
                    //        ClassGrades = new List<Grade>() {}
                    //    }
                    //}
                }
                //new School()
                //{
                //    Id = 2,
                //    Name = "Universidad Técnica de Buenas Maneras y Pistoleros",
                //    Photo = "http://localhost:54719/images/school2.jpg",
                //    Principal = new Principal()
                //    {
                //        Id = 6,
                //        Name = "Don Guzman",
                //        Photo = "http://localhost:54719/images/principal2.jpg",
                //        BirthDate = new DateTime(1967, 1, 3),
                //        AccessRights = AccessRights.FORPRINCIPALS
                //    },
                //    MentorsList = new List<Mentor>()
                //    {
                //        new Mentor()
                //        {
                //            Id = 7,
                //            Name = "Eric Blood Axe",
                //            BirthDate = new DateTime(1964, 4, 16),
                //            AccessRights = AccessRights.FORMENTORS
                //        },
                //        new Mentor()
                //        {
                //            Id = 8,
                //            Name = "Tommy Machine Gun",
                //            BirthDate = new DateTime(1970, 1, 4),
                //            AccessRights = AccessRights.FORMENTORS
                //        }
                //    },
                //    StudentsList = new List<Student>()
                //    {
                //        new Student()
                //        {
                //            Id = 9,
                //            Name = "Donna Corason Intenso",
                //            BirthDate = new DateTime(1989, 10, 24),
                //            AccessRights = AccessRights.FORSTUDENTS
                //        },
                //        new Student()
                //        {
                //            Id = 10,
                //            Name = "The Sleeping Student",
                //            BirthDate = new DateTime(2001, 10, 21),
                //            AccessRights = AccessRights.FORSTUDENTS
                //        }
                //    },
                //    CoursesList = new List<Course>()
                //    {
                //        new Course()
                //        {
                //            Id = 1,
                //            Name = "Hacking Ethics",
                //            Subject = Subject.IT,
                //            Description = "2nd edition",
                //            CourseMaterials = new List<Document>()
                //            {
                //                new Document()
                //                {
                //                    Id = 1,
                //                    Documentation = "hack doc 1",
                //                    Link = "kack link 1"
                //                },
                //                new Document()
                //                {
                //                    Id = 2,
                //                    Documentation = "hacky doc 2",
                //                    Link = "hacky link 2"
                //                }
                //            }
                //        },
                //        new Course()
                //        {
                //            Id = 2,
                //            Name = "The Answer to Life, The Universe and Everything",
                //            Subject = Subject.HISTORY,
                //            Description = "42",
                //            CourseMaterials = new List<Document>()
                //            {
                //                new Document()
                //                {
                //                    Id = 3,
                //                    Documentation = "Keep searching doc 1",
                //                    Link = "Keep searching link 1"
                //                },
                //                new Document()
                //                {
                //                    Id = 4,
                //                    Documentation = " doc 2",
                //                    Link = " link 2"
                //                }
                //            }
                //        }
                //    },
                //    CataloguesList = new List<Catalogue>()
                //    {
                //        new Catalogue()
                //        {
                //            Id = 1,
                //            ClassName = "2nd Class",
                //            ClassMentors = new List<Mentor>(){ },
                //            ClassStudents = new List<Student>() {},
                //            ClassCourses = new List<Course>() {},
                //            ClassGrades = new List<Grade>() {}
                //        }
                //    }
                //}
            );
        }
    }
}
