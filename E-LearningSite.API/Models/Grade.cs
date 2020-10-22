using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.DTOs
{
    public struct Grade
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public float Mark { get; set; }
        public Course Course { get; set; }
    }
}
