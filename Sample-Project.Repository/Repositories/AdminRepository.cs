using Sample_Project.entities.Data;
using Sample_Project.entities.Models;
using Sample_Project.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Repository.Repositories
{
    public class AdminRepository : GenericRepository<Skill>, IAdminRepository
    {
        private readonly protected SampleDBContext _context;

        public AdminRepository(SampleDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
