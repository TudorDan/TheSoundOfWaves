using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.DTOs
{
    public class DocumentDTO
    {
        [Required]
        public string Name { get; set; }
        public string Link { get; set; }
    }
}
