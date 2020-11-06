using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Timelogger
{
    public class ApiDatabase : IDisposable
    {
        private static ApiDatabase instance = null;
        private readonly SqlConnection _sqlConnection;

        private ApiDatabase()
        {
            _sqlConnection = new SqlConnection()
            {
                ConnectionString = $"Server=VIOLURREOT\\DEVELOPMENT; Database=TimeLoggerDb; Integrated Security=true;"
            };
        }

        public Task OpenConn { get { return Task.FromResult(OpenConnection()); } }
        public Task CloseConn { get { return Task.FromResult(CloseConnection()); } }

        public SqlConnection SqlConnection { get => _sqlConnection; }

        public static ApiDatabase Instance
        {
            get
            {
                if (instance == null) instance = new ApiDatabase();

                return instance;
            }
        }

        private Task OpenConnection()
        {
            try
            {
                if (_sqlConnection.State != ConnectionState.Open)
                {
                    if (_sqlConnection.State != ConnectionState.Connecting)
                        _sqlConnection.OpenAsync();
                    else
                    {
                        int counter = 10;

                        do
                        {
                            counter--;

                            if (counter == 0)
                            {
                                if (_sqlConnection.State == ConnectionState.Connecting)
                                    counter = 10;
                                else
                                    _sqlConnection.OpenAsync();
                            }
                        } while (_sqlConnection.State == ConnectionState.Connecting);
                    }
                }

                return Task.CompletedTask;
            }
            catch (SqlException sqlE)
            {
                throw sqlE;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Task CloseConnection()
        {
            try
            {
                if (SqlConnection.State != ConnectionState.Closed) SqlConnection.Close();

                return Task.CompletedTask;
            }
            catch (SqlException sqlE)
            {
                throw sqlE;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Dispose()
        {
            ((IDisposable)instance).Dispose();
        }
    }
}
