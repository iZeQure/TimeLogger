using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Models;
using Timelogger.Repositories.Interfaces;

namespace Timelogger.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private protected virtual ApiDatabase GetDatabase { get; } = ApiDatabase.Instance;

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

        public async Task<IEnumerable<Project>> GetAll()
        {
            using SqlCommand command = new SqlCommand()
            {
                CommandText = "proc_SelectAll_projects",
                CommandType = CommandType.StoredProcedure,
                Connection = GetDatabase.SqlConnection
            };

            try
            {
                await GetDatabase.OpenConn;

                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                if (!dataReader.HasRows) await Task.CompletedTask;
                else
                {
                    List<Project> projects = new List<Project>();
                    while (await dataReader.ReadAsync())
                    {
                        projects.Add(
                            new Project()
                            {
                                EntityId = dataReader.GetInt32("ProjectID"),
                                ProjectName = dataReader.GetString("ProjectName"),
                                ProjectDateOfCreation = dataReader.GetDateTime("ProjectDateOfCreation"),
                                ProjectDeadline = dataReader.GetDateTime("ProjectDeadline"),
                                ProjectOwner = new User()
                                {
                                    EntityId = dataReader.GetInt32("ProjectOwner")
                                },
                                ProjectCustomer = new Customer()
                                {

                                    EntityId = dataReader.GetInt32("ProjectForCustomerID")
                                },
                                ProjectDateTimeRegistrations = new List<TimeRegistration>()
                            });

                        if (projects.Any(p => p.EntityId == dataReader.GetInt32("RegistrationForProjectID")))
                        {
                            foreach (var p in projects)
                            {
                                if (p.EntityId == dataReader.GetInt32("RegistrationForProjectID"))
                                {
                                    p.ProjectDateTimeRegistrations.Add(
                                        new TimeRegistration(dataReader.GetInt32("RegistrationForProjectID"), dataReader.GetTimeSpan(8))
                                        {
                                            EntityId = dataReader.GetInt32("RegistrationID")
                                        }
                                    );
                                }
                            }
                        }
                    }

                    return projects;
                }

                return null;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                await GetDatabase.CloseConn;
                await Task.CompletedTask;
            }
        }

        public async Task<Project> GetById(int id)
        {
            using SqlCommand command = new SqlCommand()
            {
                CommandText = "proc_SelectById_project",
                CommandType = CommandType.StoredProcedure,
                Connection = GetDatabase.SqlConnection
            };

            command.Parameters.AddWithValue("@projectId", id);

            try
            {
                await GetDatabase.OpenConn;

                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                if (!dataReader.HasRows) await Task.CompletedTask;
                else
                {
                    Project project = null;
                    while (await dataReader.ReadAsync())
                    {
                        project = new Project()
                        {
                            EntityId = dataReader.GetInt32("ProjectID"),
                            ProjectName = dataReader.GetString("ProjectName"),
                            ProjectDateOfCreation = dataReader.GetDateTime("ProjectDateOfCreation"),
                            ProjectDeadline = dataReader.GetDateTime("ProjectDeadline"),
                            ProjectOwner = new User()
                            {
                                EntityId = dataReader.GetInt32("ProjectOwner")
                            },
                            ProjectCustomer = new Customer()
                            {

                                EntityId = dataReader.GetInt32("ProjectForCustomerID")
                            }
                        };

                    }
                    return project;
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                await GetDatabase.CloseConn;
                await Task.CompletedTask;
            }
        }

        public Task<List<Project>> SortProjectsByDeadline()
        {
            throw new NotImplementedException();
        }
    }
}
