using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timelogger.Models;
using Timelogger.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly ITimeRegistrationRepository _repository;
        public RegistrationsController(ITimeRegistrationRepository repository) => _repository = repository;

        [HttpPost]
        public IActionResult Create([FromBody] TimeRegistration timeRegistration)
        {
            try
            {
                if (timeRegistration == null)
                    return ValidationProblem();

                timeRegistration.RegistrationDateTime = TimeSpan.Parse(timeRegistration.Time);

                if (timeRegistration.RegistrationDateTime.TotalMinutes == 0)
                    return Conflict();

                if (!(timeRegistration.RegistrationDateTime.TotalMinutes >= 30))
                    return Conflict("Registration cannot be registered if less than 30 minutes.");

                _repository.Create(timeRegistration).Wait();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }        
    }
}
