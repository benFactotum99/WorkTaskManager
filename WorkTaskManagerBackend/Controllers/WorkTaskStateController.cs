using Core.Services.WorkTasks;
using Infrastructure.Persistence.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.WorkTaskStates.Req;
using Shared.Entity.WorkTaskStates.Res;

namespace WorkTaskManagerBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WorkTaskStateController : Controller
    {
        private WorkTaskStatesService workTaskStatesService;

        public WorkTaskStateController(WorkTaskStatesService workTaskStatesService)
        {
            this.workTaskStatesService = workTaskStatesService;
        }

        [HttpGet]
        public async Task<List<WorkTaskStateRes>> GetAll()
        {
            return (await workTaskStatesService.GetAllAsync()).MapDto();
        }

        [HttpGet("{id}")]
        public async Task<WorkTaskStateRes> Get(int id)
        {
            var res = (await workTaskStatesService.GetByIdAsync(id))?.MapDto();
            if (res == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
            }
            return res;
        }

        [HttpPost]
        public async Task<WorkTaskStateRes> Create([FromBody] WorkTaskStateReq req)
        {
            WorkTaskState workTaskState = req.MapDto();
            return (await workTaskStatesService.Create(workTaskState)).MapDto();
        }

        [HttpPut("{id}")]
        public async Task<WorkTaskStateRes> Update(int id, [FromBody] WorkTaskStateReq req)
        {
            WorkTaskState workTaskState = req.MapDto((await workTaskStatesService.GetByIdAsync(id)));
            return (await workTaskStatesService.Update(workTaskState)).MapDto();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await workTaskStatesService.Delete(id);
        }
    }

}
