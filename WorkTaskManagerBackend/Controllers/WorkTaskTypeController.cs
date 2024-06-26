using Core.Services.WorkTasks;
using Infrastructure.Persistence.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.WorkTasks.Req;
using Shared.Entity.WorkTasks.Res;

namespace WorkTaskManagerBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WorkTaskTypeController : Controller
    {
        private WorkTaskTypesService workTaskTypesService;

        public WorkTaskTypeController(WorkTaskTypesService workTaskTypesService)
        {
            this.workTaskTypesService = workTaskTypesService;
        }

        [HttpGet]
        public async Task<List<WorkTaskTypeRes>> GetAll()
        {
            return (await workTaskTypesService.GetAllAsync()).MapDto();
        }

        [HttpGet("{id}")]
        public async Task<WorkTaskTypeRes> Get(int id)
        {
            var res = (await workTaskTypesService.GetByIdAsync(id))?.MapDto();
            if (res == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
            }
            return res;
        }

        [HttpPost]
        public async Task<WorkTaskTypeRes> Create([FromBody] WorkTaskTypeReq req)
        {
            WorkTaskType workTaskType = req.MapDto();
            return (await workTaskTypesService.Create(workTaskType)).MapDto();
        }

        [HttpPut("{id}")]
        public async Task<WorkTaskTypeRes> Update(int id, [FromBody] WorkTaskTypeReq req)
        {
            WorkTaskType workTaskType = req.MapDto((await workTaskTypesService.GetByIdAsync(id)));
            return (await workTaskTypesService.Update(workTaskType)).MapDto();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await workTaskTypesService.Delete(id);
        }
    }
}
