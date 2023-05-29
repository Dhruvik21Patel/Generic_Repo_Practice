using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.entities.ViewModels
{
    public class MainSkillViewModel
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalCount { get; set; }
        public int? TotalPages { get; set; }
        public StaticPagedList<SkillViewModel>? storylist { get; set; }
    }
}
