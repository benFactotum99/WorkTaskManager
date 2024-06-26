using Infrastructure.Persistence.Entity;
using Shared.Entity.Customers.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.Projects.Req
{
    public partial class ProjectReq
    {
        public int Id { get; set; }

        public int? ProjectTypeId { get; set; }

        public string? Name { get; set; }

        public int? CustomerId { get; set; }
    }

    public static class ProjectReqMap
    {
        public static Project MapDto(this ProjectReq value) => MapDto(value, new());
        public static Project MapDto(this ProjectReq value, Project element)
        {
            element.Name = value.Name;
            element.ProjectTypeId = value.ProjectTypeId;
            element.Name = value.Name;
            element.CustomerId = value.CustomerId;
            return element;
        }
    }
}
