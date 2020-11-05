using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Api.Projects;

namespace Timelogger.Api.Repositories.Interfaces
{
    interface IProjectRepository : IBaseRepository<Project>
    {
        Task<List<Project>> SortProjectsByDeadline();
    }
}
