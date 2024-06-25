using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entity;

public partial class WorkTaskRangeTime
{
    public int? WorkTaskId { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    public int Id { get; set; }

    public virtual WorkTask? WorkTask { get; set; }
}
