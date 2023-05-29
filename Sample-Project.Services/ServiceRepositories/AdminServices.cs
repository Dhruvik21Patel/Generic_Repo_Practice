using Microsoft.Extensions.Logging;
using PagedList;
using Sample_Project.entities.Models;
using Sample_Project.entities.ViewModels;
using Sample_Project.Repository.Interface;
using Sample_Project.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Services.ServiceRepositories
{
    public class AdminServices : GenericService<Skill>, IAdminServices
    {
        private readonly IAdminRepository _adminRepository;
        private readonly ILogger<AdminServices> _logger;
        public AdminServices(IAdminRepository adminRepository, ILogger<AdminServices> logger) : base(adminRepository)
        {
            _adminRepository = adminRepository;
            _logger = logger;
        }

        public SkillViewModel pagedListSkill(int? page, string? searchSkill, string sorting)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            //IQueryable<SkillViewModel?> skillViewModels;
            var query = _adminRepository.QueryableData(skill => skill.DeletedDate == null);
            if (!string.IsNullOrEmpty(searchSkill))
            {
                query = _adminRepository.QueryableData(x => x.SkillName.ToLower().Contains(searchSkill.ToLower()));
            }
            if (sorting != null)
            {
                if (sorting == "Name Asc")
                {
                    query = query.OrderBy(skill1 => skill1.SkillName);
                }
                else if (sorting == "Name Desc")
                {
                    query = query.OrderByDescending(skill1 => skill1.SkillName);
                }
                else if (sorting == "Date Asc")
                {
                    query = query.OrderBy(skill1 => skill1.CreatedDate);
                }
                else if (sorting == "Date Desc")
                {
                    query = query.OrderByDescending(skill1 => skill1.CreatedDate);
                }
            }
            int pageCount = (int)Math.Ceiling((double)query.Count() / pageSize);
            var pagedSkills = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            SkillViewModel skillModel = new SkillViewModel();
            skillModel.skills = pagedSkills.ToList();
            skillModel.CurrentPage = pageNumber;
            skillModel.PageSize = pageSize;
            skillModel.PageCount = pageCount;

            return skillModel;
        }
        public void addSkill(bool status, string skillTitle)
        {
            Skill skill = new Skill();
            skill.SkillName = skillTitle;
            skill.Status = status;
            _adminRepository.Add(skill);
            _adminRepository.Save();
        }
        public void updateSkill(int skillId, string skillTitle, bool status)
        {
            Skill skill = _adminRepository.FindBy(x => x.Id == skillId).FirstOrDefault();
            skill.Status = status;
            skill.SkillName = skillTitle;
            _adminRepository.Edit(skill);
            _adminRepository.Save();
        }
        public void deleteSkill(int skillId)
        {
            Skill skill = _adminRepository.FindBy(x => x.Id == skillId).FirstOrDefault();
            skill.DeletedDate = DateTime.Now;
            _adminRepository.Edit(skill);
            _adminRepository.Save();
        }
    }
}
