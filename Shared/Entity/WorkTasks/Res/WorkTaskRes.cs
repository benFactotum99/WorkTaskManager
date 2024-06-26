using Infrastructure.Persistence.Entity;
using Newtonsoft.Json.Linq;
using Shared.Entity.Projects.Req;
using Shared.Entity.Projects.Res;
using Shared.Entity.WorkTasks.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.WorkTasks.Res
{
    public class WorkTaskRes
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public string? WorkTaskNote { get; set; }

        public int? ProjectId { get; set; }

        public int? WorkTaskTypeId { get; set; }

        public int? WorkTaskStateId { get; set; }

        public ProjectRes? Project { get; set; }        

        public WorkTaskStateRes? WorkTaskState { get; set; }

        public WorkTaskTypeRes? WorkTaskType { get; set; }
    }

    public static class WorkTaskResMap
    {
        public static WorkTask MapDto(this WorkTaskRes value) => MapDto(value, new());
        public static WorkTask MapDto(this WorkTaskRes value, WorkTask element)
        {
            element.Id = value.Id;
            element.Description = value.Description;
            element.WorkTaskNote = value.WorkTaskNote;
            element.ProjectId = value.ProjectId;
            element.WorkTaskTypeId = value.WorkTaskTypeId;
            element.WorkTaskStateId = value.WorkTaskStateId;
            element.Project = value.Project == null ? new Project() : value.Project.MapDto();
            element.WorkTaskState = value.WorkTaskState == null ? new WorkTaskState() : value.WorkTaskState.MapDto();
            element.WorkTaskType = value.WorkTaskType == null ? new WorkTaskType() : value.WorkTaskType.MapDto();
            return element;
        }

        public static WorkTaskReq MapToReqDto(this WorkTaskRes value) => MapToReqDto(value, new WorkTaskReq());
        public static WorkTaskReq MapToReqDto(this WorkTaskRes value, WorkTaskReq element)
        {
            element.Description = value.Description;
            element.WorkTaskNote = value.WorkTaskNote;
            element.ProjectId = value.ProjectId;
            element.WorkTaskTypeId = value.WorkTaskTypeId;
            element.WorkTaskStateId = value.WorkTaskStateId;
            return element;
        }

        public static WorkTaskRes MapDto(this WorkTask element)
        {
            return new WorkTaskRes
            {
                Id = element.Id,
                Description = element.Description,
                WorkTaskNote = element.WorkTaskNote,
                ProjectId = element.ProjectId,
                WorkTaskTypeId = element.WorkTaskTypeId,
                WorkTaskStateId = element.WorkTaskStateId,
                Project = element.Project == null ? new ProjectRes() : element.Project.MapDto(),
                WorkTaskState = element.WorkTaskState == null ? new WorkTaskStateRes() : element.WorkTaskState.MapDto(),
                WorkTaskType = element.WorkTaskType == null ? new WorkTaskTypeRes() : element.WorkTaskType.MapDto(),
            };
        }

        public static List<WorkTaskRes> MapDto(this List<WorkTask> values)
        {
            List<WorkTaskRes> res = new();
            for (int i = 0; i < values.Count(); i++) { res.Add(values[i].MapDto()); };
            return res;
        }
    }
}
