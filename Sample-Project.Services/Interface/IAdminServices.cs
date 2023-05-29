using PagedList;
using Sample_Project.entities.Models;
using Sample_Project.entities.ViewModels;
using Sample_Project.Services.ServiceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Services.Interface
{
    public interface IAdminServices : IGenericService<Skill>
    {
        public SkillViewModel? pagedListSkill(int? page, string? searchSkill, string sorting);
        public void addSkill(bool status, string skillTitle);
        public void updateSkill(int skillId, string skillTitle, bool status);
        public void deleteSkill(int skillId);
    }
}
