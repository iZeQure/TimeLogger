using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Api.Repositories;
using Timelogger.Api.Users.Interfaces;

namespace Timelogger.Api.Users
{
    /// <summary>
    /// Identifies a User.
    /// 
    /// Inherits:
    /// <see cref="BaseEntity"/>
    /// 
    /// Implements:
    /// <see cref="IUser"/>
    /// </summary>
    public class User : BaseEntity, IUser
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
        /// Contains empty User object.
        /// </summary>
        public User() { }

        /// <summary>
        /// Initializes new user with the defined parameters.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <param name="accountName"></param>
        public User(string firstName, string lastName, string emailAddress, string password, string accountName)
        {
            _firstName = firstName;
            _lastName = lastName;
            _emailAddress = emailAddress;
            _password = password;
            _accountName = accountName;
        }

        /// <summary>
        /// Get the user's full name.
        /// </summary>
        /// <returns>The user's full name.</returns>
        private protected virtual string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
