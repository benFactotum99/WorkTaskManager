using Infrastructure.Persistence.Entity;
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
}
