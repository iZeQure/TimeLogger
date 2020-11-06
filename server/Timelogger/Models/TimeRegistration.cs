using System;
using System.Collections.Generic;
using System.Text;

namespace Timelogger.Models
{
    /// <summary>
    /// Identifies a Project Registration Time.
    /// 
    /// Inherits:
    /// <see cref="BaseEntity"/>
    /// </summary>
    public class TimeRegistration : BaseEntity
    {
        private int _projectId;
        private TimeSpan _registrationTime;

        public int ProjectID { get => _projectId; set => _projectId = value; }

        public TimeSpan RegistrationDateTime { get => _registrationTime; set => _registrationTime = value; }
        public string Time { get; set; }

        /// <summary>
        /// Initializes an empty Registration object.
        /// </summary>
        public TimeRegistration() { }

        /// <summary>
        /// Initializes a new Registration with specified parameters.
        /// </summary>
        /// <param name="registrationForProject"></param>
        /// <param name="registrationTime"></param>
        public TimeRegistration(int projectId, TimeSpan registrationTime)
        {
            _projectId = projectId;
            _registrationTime = registrationTime;
        }
    }
}
