using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.Api.Repositories;

namespace Timelogger.Api.Projects
{
    /// <summary>
    /// Identifies a Project Registration Time.
    /// 
    /// Inherits:
    /// <see cref="BaseEntity"/>
    /// </summary>
    public class Registration : BaseEntity
    {
        private Project _registrationForProject;
        private DateTime _registrationTime;

        public Project RegistrationForProject { get => _registrationForProject; set => _registrationForProject = value; }

        public DateTime RegistrationDateTime { get => _registrationTime; set => _registrationTime = value; }

        /// <summary>
        /// Initializes an empty Registration object.
        /// </summary>
        public Registration() { }

        /// <summary>
        /// Initializes a new Registration with specified parameters.
        /// </summary>
        /// <param name="registrationForProject"></param>
        /// <param name="registrationTime"></param>
        public Registration(Project registrationForProject, DateTime registrationTime)
        {
            _registrationForProject = registrationForProject;
            _registrationTime = registrationTime;
        }
    }
}
