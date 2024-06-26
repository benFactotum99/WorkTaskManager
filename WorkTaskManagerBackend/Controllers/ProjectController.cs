using Core.Services.Projects;
using Infrastructure.Persistence.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.Projects.Req;
using Shared.Entity.Projects.Res;

namespace WorkTaskManagerBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private ProjectsService projectsService;

        public ProjectController(ProjectsService projectsService)
        {
            this.projectsService = projectsService;
        }

        [HttpGet]
        public async Task<List<ProjectRes>> GetAll()
        {
            return (await projectsService.GetAllAsync()).MapDto();
        }

        [HttpGet("{id}")]
        public async Task<ProjectRes> Get(int id)
        {
            var res = (await projectsService.GetByIdAsync(id))?.MapDto();
            if (res == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
            }
            return res;
        }

        [HttpPost]
        public async Task<ProjectRes> Create([FromBody] ProjectReq req)
        {
            Project project = req.MapDto();
            return (await projectsService.Create(project)).MapDto();
        }

        [HttpPut("{id}")]
        public async Task<ProjectRes> Update(int id, [FromBody] ProjectReq req)
        {
            Project project = req.MapDto((await projectsService.GetByIdAsync(id)));
            return (await projectsService.Update(project)).MapDto();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await projectsService.Delete(id);
        }
    }
}
