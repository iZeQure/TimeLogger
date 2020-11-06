using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Timelogger.Models;
using Timelogger.Repositories;
using Timelogger.Repositories.Interfaces;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _repository;
        public ProjectsController(IProjectRepository repository) => _repository = repository;

        [HttpPost]
        public IActionResult Create([FromBody] Project project)
        {
            if (project == null)
                return ValidationProblem();

            try
            {
                _repository.Create(project).GetAwaiter();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {            
            try
            {
                var result = _repository.GetAll().GetAwaiter().GetResult();

                if (result == null) return NotFound();
                else return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            if (id == 0) return BadRequest();

            try
            {
                Project project = new Project();

                Task.Run(async () =>
                {
                    project = await _repository.GetById(id);
                });

                if (project == null) return NotFound();
                else return Ok(project);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
