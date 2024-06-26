using Infrastructure.Persistence.Entity;
using Shared.Entity.WorkTasks.Res;
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
        public static WorkTaskTypeReq MapToReqDto(this WorkTaskTypeRes value) => MapToReqDto(value, new WorkTaskTypeReq());
        public static WorkTaskTypeReq MapToReqDto(this WorkTaskTypeRes value, WorkTaskTypeReq element)
        {
            element.Description = value.Description;
            return element;
        }
    }
}
