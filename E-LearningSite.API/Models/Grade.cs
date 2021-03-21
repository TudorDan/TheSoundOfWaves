using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.Models
{
    public class Grade
    {
        public int Id { get; set; }
        [Required]
        public Student Student { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public float Mark { get; set; }
        [Required]
        public Course Course { get; set; }
        [Required]
        public Mentor Mentor { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
