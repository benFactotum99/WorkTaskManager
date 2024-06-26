using Infrastructure.Persistence.Entity;
using Newtonsoft.Json.Linq;
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
    public partial class ProjectRes
    {
        public int Id { get; set; }

        public int? ProjectTypeId { get; set; }

        public string? Name { get; set; }

        public int? CustomerId { get; set; }

        public virtual CustomerRes? Customer { get; set; }

        public virtual ProjectTypeRes? ProjectType { get; set; }
    }

    public static class ProjectResMap
    {
        public static Project MapDto(this ProjectRes value) => MapDto(value, new());
        public static Project MapDto(this ProjectRes value, Project element)
        {
            element.Id = value.Id;
            element.ProjectTypeId = value.ProjectTypeId;
            element.Name = value.Name;
            element.CustomerId = value.CustomerId;
            element.Customer = value.Customer == null ? new Customer() : value.Customer.MapDto();
            element.ProjectType = value.ProjectType == null ? new ProjectType() : value.ProjectType.MapDto();
            return element;
        }

        public static ProjectReq MapToReqDto(this ProjectRes value) => MapToReqDto(value, new ProjectReq());
        public static ProjectReq MapToReqDto(this ProjectRes value, ProjectReq element)
        {
            element.Id = value.Id;
            element.ProjectTypeId = value.ProjectTypeId;
            element.Name = value.Name;
            element.CustomerId = value.CustomerId;
            return element;
        }

        public static ProjectRes MapDto(this Project element)
        {
            return new ProjectRes
            {
                Id = element.Id,
                ProjectTypeId = element.ProjectTypeId,
                Name = element.Name,
                CustomerId = element.CustomerId,
                Customer = element.Customer == null ? new CustomerRes() : element.Customer.MapDto(),
                ProjectType = element.ProjectType == null ? new ProjectTypeRes() : element.ProjectType.MapDto(),
            };
        }

        public static List<ProjectRes> MapDto(this List<Project> values)
        {
            List<ProjectRes> res = new();
            for (int i = 0; i < values.Count(); i++) { res.Add(values[i].MapDto()); };
            return res;
        }
    }
}
