﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }        
        [Required]
        public string Description { get; set; }
        [Required]
        public List<Document> Documents { get; set; }  
        
        [Required]
        public Subject Subject { get; set; }
    }
}
