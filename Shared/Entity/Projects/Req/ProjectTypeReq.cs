using Infrastructure.Persistence.Entity;
using Shared.Entity.Customers.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entity.Projects.Req
{
    public class ProjectTypeReq
    {
        public string? Description { get; set; }
    }

    public static class ProjectTypeReqMap
    {
        public static ProjectType MapDto(this ProjectTypeReq value) => MapDto(value, new());
        public static ProjectType MapDto(this ProjectTypeReq value, ProjectType element)
        {
            element.Description = value.Description;
            return element;
        }
    }
}
