using Sample_Project.entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.entities.ViewModels
{
    public class SkillViewModel
    {
        //public int id { get; set; }
        //[Required]
        //public string skillName { get; set; } = null!;
        //public bool status { get; set; }

        public List<Skill> skills { get; set; } = new List<Skill>();

        public int PageCount { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }
    }
}
