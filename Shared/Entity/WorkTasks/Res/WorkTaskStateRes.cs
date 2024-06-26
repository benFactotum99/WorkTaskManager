using Infrastructure.Persistence.Entity;
using Shared.Entity.WorkTasks.Req;
using Shared.Entity.WorkTaskStates.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.WorkTaskStates.Res
{
    public partial class WorkTaskStateRes
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }

    public static class WorkTaskStateResMap
    {
        public static WorkTaskState MapDto(this WorkTaskStateRes value) => MapDto(value, new());
        public static WorkTaskState MapDto(this WorkTaskStateRes value, WorkTaskState element)
        {
            element.Id = value.Id;
            element.Description = value.Description;
            return element;
        }

        public static WorkTaskStateReq MapToReqDto(this WorkTaskStateRes value) => MapToReqDto(value, new WorkTaskStateReq());
        public static WorkTaskStateReq MapToReqDto(this WorkTaskStateRes value, WorkTaskStateReq element)
        {
            element.Description = value.Description;
            return element;
        }

        public static WorkTaskStateRes MapDto(this WorkTaskState element)
        {
            return new WorkTaskStateRes
            {
                Id = element.Id,
                Description = element.Description,
            };
        }

        public static List<WorkTaskStateRes> MapDto(this List<WorkTaskState> values)
        {
            List<WorkTaskStateRes> res = new();
            for (int i = 0; i < values.Count(); i++) { res.Add(values[i].MapDto()); }
            return res;
        }
    }
}
