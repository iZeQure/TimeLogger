using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timelogger.Api.Users.Interfaces
{
    /// <summary>
    /// Contains the basic information for Users.
    /// </summary>
    interface IUser
    {
        /// <summary>
        /// The first name of the user.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        string LastName { get; }

        /// <summary>
        /// Gets the full name of the user.
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// The associated email address for the user.
        /// </summary>
        string EmailAddress { get; }

        /// <summary>
        /// The user's unique password.
        /// </summary>
        string Password { get; }

        /// <summary>
        /// Optional username for the user.
        /// </summary>
        string AccountName { get; }
    }
}
