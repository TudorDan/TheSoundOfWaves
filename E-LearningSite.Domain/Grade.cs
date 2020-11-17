using System;
using System.Collections.Generic;
using System.Text;

namespace E_LearningSite.Domain
{
    public class Grade
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public float Mark { get; set; }
        public Course Course { get; set; }
        public Mentor Mentor { get; set; }
    }
}
