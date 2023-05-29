using Sample_Project.entities.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.entities.Entities
{
    public  class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string? CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? UpdatedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string? UpdatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DeletedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string? DeletedBy { get; set; }

        public bool IsDeleted { get; set; } = false;

        [Required]
        public bool Status { get; set; } = false;
    }
}
