using Sample_Project.entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.entities.Models
{
    public class City : AuditableEntity<long>
    {
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [ForeignKey("CountryId")]
        public Country Countries { get; set; } = default!;
    }
}
