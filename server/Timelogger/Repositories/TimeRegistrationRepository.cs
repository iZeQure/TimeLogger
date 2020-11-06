using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Timelogger.Models;
using Timelogger.Repositories.Interfaces;

namespace Timelogger.Repositories
{
    public class TimeRegistrationRepository : ITimeRegistrationRepository
    {
        private protected virtual ApiDatabase GetDatabase { get; } = ApiDatabase.Instance;

        public async Task Create(TimeRegistration create)
        {
            using SqlCommand command = new SqlCommand()
            {
                CommandText = "proc_Insert_registration",
                CommandType = CommandType.StoredProcedure,
                Connection = GetDatabase.SqlConnection
            };

            command.Parameters.AddWithValue("@time", create.RegistrationDateTime);
            command.Parameters.AddWithValue("@projectID", create.ProjectID);

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

        public Task<IEnumerable<TimeRegistration>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TimeRegistration> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
