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
    public class WorkTaskController : Controller
    {
        private WorkTasksService workTasksService;

        public WorkTaskController(WorkTasksService workTasksService)
        {
            this.workTasksService = workTasksService;
        }

        [HttpGet]
        public async Task<List<WorkTaskRes>> GetAll()
        {
            return (await workTasksService.GetAllAsync()).MapDto();
        }

        [HttpGet("{id}")]
        public async Task<WorkTaskRes> Get(int id)
        {
            var res = (await workTasksService.GetByIdAsync(id))?.MapDto();
            if (res == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
            }
            return res;
        }

        [HttpPost]
        public async Task<WorkTaskRes> Create([FromBody] WorkTaskReq req)
        {
            WorkTask workTask = req.MapDto();
            return (await workTasksService.Create(workTask)).MapDto();
        }

        [HttpPut("{id}")]
        public async Task<WorkTaskRes> Update(int id, [FromBody] WorkTaskReq req)
        {
            WorkTask workTask = req.MapDto((await workTasksService.GetByIdAsync(id)));
            return (await workTasksService.Update(workTask)).MapDto();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await workTasksService.Delete(id);
        }
    }
}
