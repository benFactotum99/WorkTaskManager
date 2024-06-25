using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entity;

public partial class WorkTask
{
    public string? Description { get; set; }

    public string? WorkTaskNote { get; set; }

    public int? ProjectId { get; set; }

    public int? WorkTaskTypeId { get; set; }

    public int? WorkTaskStateId { get; set; }

    public int Id { get; set; }

    public virtual Project? Project { get; set; }

    public virtual ICollection<WorkTaskRangeTime> WorkTaskRangeTimes { get; set; } = new List<WorkTaskRangeTime>();

    public virtual WorkTaskState? WorkTaskState { get; set; }

    public virtual WorkTaskType? WorkTaskType { get; set; }
}
