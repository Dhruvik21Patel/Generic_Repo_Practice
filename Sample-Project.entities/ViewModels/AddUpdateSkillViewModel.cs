using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.entities.ViewModels
{
    public class AddUpdateSkillViewModel
    {
        public int id { get; set; }
        [Required]
        public string skillName { get; set; } = null!;
        public bool status { get; set; }
        public string? CreatedBy { get; set; }
    }
}
