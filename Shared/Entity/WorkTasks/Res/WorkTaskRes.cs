using Infrastructure.Persistence.Entity;
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

        public Project? Project { get; set; }        

        public WorkTaskState? WorkTaskState { get; set; }

        public WorkTaskType? WorkTaskType { get; set; }
    }
}
