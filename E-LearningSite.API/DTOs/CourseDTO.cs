﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.DTOs
{
    public class CourseDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public string Description { get; set; }
#nullable enable
        public List<Document>? Documents { get; set; }
#nullable disable
    }
}
