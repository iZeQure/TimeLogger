using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Timelogger.Api.Communication;
using Timelogger.Api.Projects;
using Timelogger.Api.Repositories.Interfaces;

namespace Timelogger.Api.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private protected virtual DatabaseCommunitcation GetDatabase { get; } = DatabaseCommunitcation.Instance;

        public async Task Create(Project create)
        {
            using SqlCommand command = new SqlCommand()
            {
                CommandText = "proc_insert_project",
                CommandType = CommandType.StoredProcedure,
                Connection = GetDatabase.SqlConnection
            };

            command.Parameters.AddWithValue("@name", create.ProjectName);
            command.Parameters.AddWithValue("@userId", create.ProjectOwner.EntityId);
            command.Parameters.AddWithValue("@customerId", create.ProjectCustomer.EntityId);
            command.Parameters.AddWithValue("@dateOfCreation", create.ProjectDateOfCreation);
            command.Parameters.AddWithValue("@deadline", create.ProjectDeadline);

            try
            {
                await GetDatabase.OpenConn;
                await command.ExecuteNonQueryAsync();
            }
            finally
            {
                await GetDatabase.CloseConn;
                await Task.CompletedTask;
            }
        }

        public Task<IEnumerable<Project>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> SortProjectsByDeadline()
        {
            throw new NotImplementedException();
        }
    }
}
