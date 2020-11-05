using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timelogger.Api.Repositories.Interfaces
{
    interface IBaseRepository<T> where T : BaseEntity
    {
        Task Create(T create);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
