﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_LearningSite.Domain
{
    public class Catalogue
    {
        public Catalogue()
        {
            // initialized here, instead of school level
            Grades = new List<Grade>();
            Students = new List<Student>();

            MentorCatalogues = new List<MentorCatalogue>();
            CourseCatalogues = new List<CourseCatalogue>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Grade> Grades { get; set; }

        [ForeignKey("SchoolId")]
        public School School { get; set; }
        public int SchoolId { get; set; }

        public List<MentorCatalogue> MentorCatalogues { get; set; }
        public List<CourseCatalogue> CourseCatalogues { get; set; }
    }
}
