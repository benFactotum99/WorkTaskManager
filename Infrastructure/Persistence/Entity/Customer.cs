using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entity;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? MobilePhone { get; set; }

    public string? Alias { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
