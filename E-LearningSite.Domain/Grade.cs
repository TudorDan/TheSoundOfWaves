using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_LearningSite.Domain
{
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float Mark { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("CatalogueId")]
        public Catalogue Catalogue { get; set; }
        public int CatalogueId { get; set; }

        [ForeignKey("MentorId")]
        public Mentor Mentor { get; set; }
        public int MentorId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
