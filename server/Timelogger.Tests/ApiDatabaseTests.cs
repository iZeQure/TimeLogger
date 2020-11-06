using NUnit.Framework;
using System.Data;
using Timelogger;

namespace Timelogger.Tests
{
    public class ApiDatabaseTests
    {
        private ApiDatabase _apiDatabase;

        [SetUp]
        public void SetUp()
        {
            _apiDatabase = ApiDatabase.Instance;
        }

        [Test]
        public void DatabaseConnection_ShouldBe_Closed()
        {
            // Assert
            Assert.AreEqual(ConnectionState.Closed, _apiDatabase.SqlConnection.State);
        }

        [Test]
        public void DatabaseConnection_ShouldBe_Connecting()
        {
            // Act
            _apiDatabase.OpenConn.Wait();

            // Assert
            Assert.AreEqual(ConnectionState.Connecting, _apiDatabase.SqlConnection.State);
        }

        [Test]
        public void DatabaseConnection_ShouldBe_Open()
        {
            // Act
            _apiDatabase.OpenConn.Wait();

            // Assert
            Assert.AreEqual(ConnectionState.Open, _apiDatabase.SqlConnection.State);
        }

        [Test]
        public void DatabaseConnection_ShouldBe_Closing()
        {
            // Act
            _apiDatabase.CloseConn.Wait();

            // Assert
            Assert.AreEqual(ConnectionState.Closed, _apiDatabase.SqlConnection.State);
        }

        [Test]
        public void DatabaseConnection_ShouldNotBe_Broken()
        {
            // Act
            _apiDatabase.OpenConn.Wait();

            // Assert
            Assert.AreNotEqual(ConnectionState.Broken, _apiDatabase.SqlConnection.State);

            _apiDatabase.CloseConn.Wait();
            Assert.AreEqual(ConnectionState.Closed, _apiDatabase.SqlConnection.State);
        }
    }
}