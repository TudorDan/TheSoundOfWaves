using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.Models
{
    public class CataloguePersonDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
