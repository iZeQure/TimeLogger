using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Api.Repositories;
using Timelogger.Api.Users.Interfaces;

namespace Timelogger.Api.Users
{
    /// <summary>
    /// Identifies a Customer.
    /// 
    /// Inherits:
    /// <see cref="BaseEntity"/>
    /// 
    /// Implements:
    /// <see cref="IUser"/>
    /// </summary>
    public class Customer : BaseEntity, IUser
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _emailAddress;
        private readonly string _password;
        private readonly string _accountName;

        public string FirstName => _firstName;

        public string LastName => _lastName;

        public string EmailAddress => _emailAddress;

        public string Password => _password;

        public string AccountName => _accountName;

        public string FullName => GetFullName();

        /// <summary>
        /// Contains empty Customer object.
        /// </summary>
        public Customer() { }

        /// <summary>
        /// Initializes a new customer with defined parameters.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <param name="accountName"></param>
        public Customer(string firstName, string lastName, string emailAddress, string password, string accountName)
        {
            _firstName = firstName;
            _lastName = lastName;
            _emailAddress = emailAddress;
            _password = password;
            _accountName = accountName;
        }

        /// <summary>
        /// Get the customer's full name.
        /// </summary>
        /// <returns>The customer's full name.</returns>
        private protected virtual string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
