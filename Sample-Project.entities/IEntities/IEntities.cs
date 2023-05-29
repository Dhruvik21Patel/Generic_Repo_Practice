using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.entities.IEntities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
