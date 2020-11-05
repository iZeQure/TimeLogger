using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Api.Repositories;
using Timelogger.Api.Users;
using Timelogger.Api.Users.Interfaces;

namespace Timelogger.Api.Projects
{
    public class Project : BaseEntity
    {
        private string _name;
        private User _user;
        private Customer _customer;
        private List<DateTime> _registrations;
        private DateTime _dateOfCreation;
        private DateTime _deadline;
        private bool _isCompleted;

        public string ProjectName { get => _name; set => _name = value; }

        public User ProjectOwner { get => _user; set => _user = value; }

        public Customer ProjectCustomer { get => _customer; set => _customer = value; }

        public List<DateTime> ProjectTimeRegistrations { get => _registrations; set => _registrations = value; }

        public DateTime ProjectDateOfCreation { get => _dateOfCreation; set => _dateOfCreation = value; }

        public DateTime ProjectDeadline { get => _deadline; set => _deadline = value; }

        public bool IsProjectCompleted { get => _isCompleted; set => _isCompleted = value; }
    }
}
