using Infrastructure.Persistence.Entity;
using Shared.Entity.WorkTasks.Res;
using Shared.Entity.WorkTaskStates.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.WorkTasks.Req
{
    public partial class WorkTaskTypeReq
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }

    public static class WorkTaskTypeReqMap
    {
        public static WorkTaskType MapDto(this WorkTaskTypeReq value) => MapDto(value, new());
        public static WorkTaskType MapDto(this WorkTaskTypeReq value, WorkTaskType element)
        {
            element.Description = value.Description;
            return element;
        }
    }
}
