using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entity;

public partial class ProjectType
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
