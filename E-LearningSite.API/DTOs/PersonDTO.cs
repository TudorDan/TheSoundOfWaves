using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.DTOs
{
    public class PersonDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        public string Photo { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public AccessRights? AccessRights { get; set; }
    }
}
