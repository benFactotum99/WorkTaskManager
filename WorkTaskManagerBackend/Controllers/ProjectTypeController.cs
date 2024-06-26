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
    public class ProjectTypeController : Controller
    {
        private ProjectTypesService projectTypesService;

        public ProjectTypeController(ProjectTypesService projectTypesService)
        {
            this.projectTypesService = projectTypesService;
        }

        [HttpGet]
        public async Task<List<ProjectTypeRes>> GetAll()
        {
            return (await projectTypesService.GetAllAsync()).MapDto();
        }

        [HttpGet("{id}")]
        public async Task<ProjectTypeRes> Get(int id)
        {
            var res = (await projectTypesService.GetByIdAsync(id))?.MapDto();
            if (res == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
            }
            return res;
        }

        [HttpPost]
        public async Task<ProjectTypeRes> Create([FromBody] ProjectTypeReq req)
        {
            ProjectType projectType = req.MapDto();
            return (await projectTypesService.Create(projectType)).MapDto();
        }

        [HttpPut("{id}")]
        public async Task<ProjectTypeRes> Update(int id, [FromBody] ProjectTypeReq req)
        {
            ProjectType projectType = req.MapDto((await projectTypesService.GetByIdAsync(id)));
            return (await projectTypesService.Update(projectType)).MapDto();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await projectTypesService.Delete(id);
        }
    }
}
