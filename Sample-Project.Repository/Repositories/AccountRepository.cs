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
    public class AccountRepository : GenericRepository<User>, IAccountRepository
    {
        private readonly protected SampleDBContext _context;

        public AccountRepository(SampleDBContext context) : base(context)
        {
            _context = context;
        }
        public User GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
