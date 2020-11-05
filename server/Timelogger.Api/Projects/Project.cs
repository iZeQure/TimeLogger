using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Api.Repositories;
using Timelogger.Api.Users;
using Timelogger.Api.Users.Interfaces;

namespace Timelogger.Api.Projects
{
    /// <summary>
    /// Identifies a Project.
    /// 
    /// Inherits:
    /// <see cref="BaseEntity"/>
    /// </summary>
    public class Project : BaseEntity
    {
        private string _name;
        private User _user;
        private Customer _customer;
        private List<Registration> _registrations;
        private DateTime _dateOfCreation;
        private DateTime _deadline;
        private bool _isCompleted;

        public string ProjectName { get => _name; set => _name = value; }

        public User ProjectOwner { get => _user; set => _user = value; }

        public Customer ProjectCustomer { get => _customer; set => _customer = value; }

        public List<Registration> ProjectDateTimeRegistrations { get => _registrations; set => _registrations = value; }

        public DateTime ProjectDateOfCreation { get => _dateOfCreation; set => _dateOfCreation = value; }

        public DateTime ProjectDeadline { get => _deadline; set => _deadline = value; }

        public bool IsProjectCompleted { get => _isCompleted; set => _isCompleted = value; }

        /// <summary>
        /// Initializes empty Project object.
        /// </summary>
        public Project() { }

        /// <summary>
        /// Initializes a new Project object with specified parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="user"></param>
        /// <param name="customer"></param>
        /// <param name="registrations"></param>
        /// <param name="dateOfCreation"></param>
        /// <param name="deadline"></param>
        /// <param name="isCompleted"></param>
        public Project(string name, User user, Customer customer, List<Registration> registrations, DateTime dateOfCreation, DateTime deadline, bool isCompleted)
        {
            _name = name;
            _user = user;
            _customer = customer;
            _registrations = registrations;
            _dateOfCreation = dateOfCreation;
            _deadline = deadline;
            _isCompleted = isCompleted;
        }
    }
}
