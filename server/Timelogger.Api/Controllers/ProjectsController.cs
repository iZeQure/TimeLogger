using Microsoft.AspNetCore.Mvc;
using Timelogger.Api.Projects;
using Timelogger.Api.Repositories;
using Timelogger.Api.Repositories.Interfaces;

namespace Timelogger.Api.Controllers
{
	[Route("api/[controller]")]
	public class ProjectsController : Controller
	{
		private readonly ApiContext _context;
        private IProjectRepository ProjectRepository { get; } = new ProjectRepository();

		public ProjectsController(ApiContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult Create([FromBody] Project project)
        {
			if (project == null)
				return BadRequest("Bad Request.");

            try
            {
				ProjectRepository.Create(project);

				return Ok();
            }
            catch (System.Exception e)
            {
				return BadRequest("Could not process request. " + e.Message);
            }
        }

		[HttpGet]
		[Route("hello-world")]
		public string HelloWorld()
		{
			return "Hello Back!";
		}

		// GET api/projects
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_context.Projects);
		}
	}
}
