using Sample_Project.entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Repository.Interface
{
    public interface IAccountRepository : IGenericRepository<User>
    {
        User GetById(long id);
    }
}
