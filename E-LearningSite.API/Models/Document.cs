using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.DTOs
{
    public struct Document
    {
        public int Id { get; set; }
        [Required]
        public string Documentation { get; set; }
        public string Link { get; set; }
    }
}
