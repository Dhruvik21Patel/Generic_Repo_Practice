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
    public class UserSkill : AuditableEntity<long>
    {
        public long UserId { get; set; }
        public int SkillId { get; set; }

        [ForeignKey("UserId")]
        public User Users { get; set; } = default!;
        [ForeignKey("SkillId")]
        public Skill Skills { get; set; } = default!;

    }
}
