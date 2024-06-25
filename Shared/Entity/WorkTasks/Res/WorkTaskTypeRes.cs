using Infrastructure.Persistence.Entity;
using Shared.Entity.WorkTasks.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.WorkTasks.Res
{   
    public partial class WorkTaskTypeRes
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }

    public static class WorkTaskTypeResMap
    {
        public static WorkTaskType MapDto(this WorkTaskTypeRes value) => MapDto(value, new());
        public static WorkTaskType MapDto(this WorkTaskTypeRes value, WorkTaskType element)
        {
            element.Id = value.Id;
            element.Description = value.Description;
            return element;
        }

        public static WorkTaskTypeReq MapToReqDto(this WorkTaskTypeRes value) => MapToReqDto(value, new WorkTaskTypeReq());
        public static WorkTaskTypeReq MapToReqDto(this WorkTaskTypeRes value, WorkTaskTypeReq element)
        {
            element.Description = value.Description;
            return element;
        }

        public static WorkTaskTypeRes MapDto(this WorkTaskType element)
        {
            return new WorkTaskTypeRes
            {
                Id = element.Id,
                Description = element.Description,
            };
        }

        public static List<WorkTaskTypeRes> MapDto(this List<WorkTaskType> values)
        {
            List<WorkTaskTypeRes> res = new();
            for (int i = 0; i < values.Count(); i++) { res.Add(values[i].MapDto()); };
            return res;
        }
    }
}
