using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.Models
{
    public class GradeDTO
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public float Mark { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int MentorId { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
