using Infrastructure.Persistence.Entity;
using Shared.Entity.WorkTasks.Req;
using Shared.Entity.WorkTasks.Res;
using Shared.Entity.WorkTaskStates.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.WorkTaskStates.Req
{
    public partial class WorkTaskStateReq
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }

    public static class WorkTaskStateReqMap
    {
        public static WorkTaskState MapDto(this WorkTaskStateReq value) => MapDto(value, new());
        public static WorkTaskState MapDto(this WorkTaskStateReq value, WorkTaskState element)
        {
            element.Description = value.Description;
            return element;
        }
    }
}
