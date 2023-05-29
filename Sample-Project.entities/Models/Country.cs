using Sample_Project.entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.entities.Models
{
    public class Country : AuditableEntity<int>
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string ISO { get; set; } = null!;
    }
}
