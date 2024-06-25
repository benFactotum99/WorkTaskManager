using Infrastructure.Persistence.Entity;
using Shared.Entity.Customers.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.WorkTasks.Req
{
    public class WorkTaskReq
    {
        public int? ProjectId { get; set; }

        public int? WorkTaskTypeId { get; set; }

        public int? WorkTaskStateId { get; set; }

        public string? Description { get; set; }

        public string? WorkTaskNote { get; set; }
    }

    public static class WorkTaskReqMap
    {
        public static WorkTask MapDto(this WorkTaskReq value) => MapDto(value, new());
        public static WorkTask MapDto(this WorkTaskReq value, WorkTask element)
        {
            element.ProjectId = value.ProjectId;
            element.WorkTaskTypeId = value.WorkTaskTypeId;
            element.WorkTaskStateId = value.WorkTaskStateId;
            element.Description = value.Description;
            element.WorkTaskNote = value.WorkTaskNote;
            return element;
        }
    }
}
