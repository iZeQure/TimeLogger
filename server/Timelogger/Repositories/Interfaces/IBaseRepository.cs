using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Models;

namespace Timelogger.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Create(T create);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
