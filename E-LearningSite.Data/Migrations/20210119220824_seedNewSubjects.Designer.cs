﻿// <auto-generated />
using System;
using E_LearningSite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_LearningSite.Data.Migrations
{
    [DbContext(typeof(LearningContext))]
    [Migration("20210119220824_seedNewSubjects")]
    partial class seedNewSubjects
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("E_LearningSite.Domain.Catalogue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Catalogues");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CatalogueId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CatalogueId");

                    b.HasIndex("SchoolId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("E_LearningSite.Domain.CourseCatalogue", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("CatalogueId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "CatalogueId");

                    b.HasIndex("CatalogueId");

                    b.ToTable("CourseCatalogue");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CatalogueId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<float>("Mark")
                        .HasColumnType("real");

                    b.Property<int>("MentorId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CatalogueId");

                    b.HasIndex("CourseId");

                    b.HasIndex("MentorId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Mentor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccessRights")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CatalogueId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CatalogueId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Mentors");
                });

            modelBuilder.Entity("E_LearningSite.Domain.MentorCatalogue", b =>
                {
                    b.Property<int>("MentorId")
                        .HasColumnType("int");

                    b.Property<int>("CatalogueId")
                        .HasColumnType("int");

                    b.HasKey("MentorId", "CatalogueId");

                    b.HasIndex("CatalogueId");

                    b.ToTable("MentorCatalogue");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Principal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccessRights")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId")
                        .IsUnique();

                    b.ToTable("Principals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessRights = 2,
                            BirthDate = new DateTime(1950, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Miss Danger",
                            Photo = "http://localhost:54719/images/principal1.jpg",
                            SchoolId = 1
                        },
                        new
                        {
                            Id = 6,
                            AccessRights = 2,
                            BirthDate = new DateTime(1967, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Don Guzman",
                            Photo = "http://localhost:54719/images/principal2.jpg",
                            SchoolId = 2
                        });
                });

            modelBuilder.Entity("E_LearningSite.Domain.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schools");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Weed Health Institute",
                            Photo = "school1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Universidad Técnica de Buenas Maneras y Pistoleros",
                            Photo = "school2.jpg"
                        });
                });

            modelBuilder.Entity("E_LearningSite.Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccessRights")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CatalogueId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CatalogueId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "HISTORY",
                            SchoolId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "IT",
                            SchoolId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "ASTRONOMY",
                            SchoolId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "IT",
                            SchoolId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "HISTORY",
                            SchoolId = 2
                        });
                });

            modelBuilder.Entity("E_LearningSite.Domain.Catalogue", b =>
                {
                    b.HasOne("E_LearningSite.Domain.School", "School")
                        .WithMany("Catalogues")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Course", b =>
                {
                    b.HasOne("E_LearningSite.Domain.Catalogue", null)
                        .WithMany("Courses")
                        .HasForeignKey("CatalogueId");

                    b.HasOne("E_LearningSite.Domain.School", "School")
                        .WithMany("Courses")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_LearningSite.Domain.Subject", "Subject")
                        .WithMany("Courses")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("School");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("E_LearningSite.Domain.CourseCatalogue", b =>
                {
                    b.HasOne("E_LearningSite.Domain.Catalogue", "Catalogue")
                        .WithMany("CourseCatalogues")
                        .HasForeignKey("CatalogueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_LearningSite.Domain.Course", "Course")
                        .WithMany("CourseCatalogues")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalogue");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Document", b =>
                {
                    b.HasOne("E_LearningSite.Domain.Course", "Course")
                        .WithMany("Documents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Grade", b =>
                {
                    b.HasOne("E_LearningSite.Domain.Catalogue", "Catalogue")
                        .WithMany("Grades")
                        .HasForeignKey("CatalogueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("E_LearningSite.Domain.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_LearningSite.Domain.Mentor", "Mentor")
                        .WithMany()
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_LearningSite.Domain.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalogue");

                    b.Navigation("Course");

                    b.Navigation("Mentor");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Mentor", b =>
                {
                    b.HasOne("E_LearningSite.Domain.Catalogue", null)
                        .WithMany("Mentors")
                        .HasForeignKey("CatalogueId");

                    b.HasOne("E_LearningSite.Domain.School", "School")
                        .WithMany("Mentors")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("E_LearningSite.Domain.MentorCatalogue", b =>
                {
                    b.HasOne("E_LearningSite.Domain.Catalogue", "Catalogue")
                        .WithMany("MentorCatalogues")
                        .HasForeignKey("CatalogueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_LearningSite.Domain.Mentor", "Mentor")
                        .WithMany("MentorCatalogues")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalogue");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Principal", b =>
                {
                    b.HasOne("E_LearningSite.Domain.School", "School")
                        .WithOne("Principal")
                        .HasForeignKey("E_LearningSite.Domain.Principal", "SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Student", b =>
                {
                    b.HasOne("E_LearningSite.Domain.Catalogue", "Catalogue")
                        .WithMany("Students")
                        .HasForeignKey("CatalogueId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("E_LearningSite.Domain.School", "School")
                        .WithMany("Students")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Catalogue");

                    b.Navigation("School");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Subject", b =>
                {
                    b.HasOne("E_LearningSite.Domain.School", "School")
                        .WithMany("Subjects")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Catalogue", b =>
                {
                    b.Navigation("CourseCatalogues");

                    b.Navigation("Courses");

                    b.Navigation("Grades");

                    b.Navigation("MentorCatalogues");

                    b.Navigation("Mentors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Course", b =>
                {
                    b.Navigation("CourseCatalogues");

                    b.Navigation("Documents");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Mentor", b =>
                {
                    b.Navigation("MentorCatalogues");
                });

            modelBuilder.Entity("E_LearningSite.Domain.School", b =>
                {
                    b.Navigation("Catalogues");

                    b.Navigation("Courses");

                    b.Navigation("Mentors");

                    b.Navigation("Principal")
                        .IsRequired();

                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("E_LearningSite.Domain.Subject", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}