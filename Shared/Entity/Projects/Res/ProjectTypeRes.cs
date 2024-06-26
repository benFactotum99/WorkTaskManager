using Infrastructure.Persistence.Entity;
using Shared.Entity.Customers.Req;
using Shared.Entity.Customers.Res;
using Shared.Entity.Projects.Req;
using Shared.Entity.WorkTasks.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.Projects.Res
{
    public class ProjectTypeRes
    {
        public int Id { get; set; }

        public string? Description { get; set; }
    }

    public static class ProjectTypeResMap
    {
        public static ProjectType MapDto(this ProjectTypeRes value) => MapDto(value, new());
        public static ProjectType MapDto(this ProjectTypeRes value, ProjectType element)
        {
            element.Id = value.Id;
            element.Description = value.Description;
            return element;
        }

        public static ProjectTypeReq MapToReqDto(this ProjectTypeRes value) => MapToReqDto(value, new ProjectTypeReq());
        public static ProjectTypeReq MapToReqDto(this ProjectTypeRes value, ProjectTypeReq element)
        {
            element.Description = value.Description;
            return element;
        }

        public static ProjectTypeRes MapDto(this ProjectType element)
        {
            return new ProjectTypeRes
            {
                Id = element.Id,
                Description = element.Description,
            };
        }

        public static List<ProjectTypeRes> MapDto(this List<ProjectType> values)
        {
            List<ProjectTypeRes> res = new();
            for (int i = 0; i < values.Count(); i++) { res.Add(values[i].MapDto()); };
            return res;
        }
    }
}
