using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Timelogger.Models;

namespace Timelogger.Repositories.Interfaces
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<List<Project>> SortProjectsByDeadline();
    }
}
