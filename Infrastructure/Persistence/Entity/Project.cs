using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entity;

public partial class Project
{
    public int Id { get; set; }

    public int? ProjectTypeId { get; set; }

    public string? Name { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ProjectType? ProjectType { get; set; }

    public virtual ICollection<WorkTask> WorkTasks { get; set; } = new List<WorkTask>();
}
