using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entity;

public partial class WorkTaskState
{
    public string? Description { get; set; }

    public int Id { get; set; }

    public virtual ICollection<WorkTask> WorkTasks { get; set; } = new List<WorkTask>();
}
