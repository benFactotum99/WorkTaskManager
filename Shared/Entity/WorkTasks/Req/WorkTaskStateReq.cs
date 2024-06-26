using Infrastructure.Persistence.Entity;
using Shared.Entity.WorkTasks.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.WorkTasks.Req
{
    public partial class WorkTaskStateReq
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }

    public static class WorkTaskStateReqMap
    {
        public static WorkTaskStateReq MapToReqDto(this WorkTaskStateRes value) => MapToReqDto(value, new WorkTaskStateReq());
        public static WorkTaskStateReq MapToReqDto(this WorkTaskStateRes value, WorkTaskStateReq element)
        {
            element.Description = value.Description;
            return element;
        }
    }
}
