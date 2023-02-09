using System;
using System.Collections.Generic;

namespace Repositories.entities;

public partial class Child
{
    public int NumChild { get; set; }

    public string? IdChild { get; set; }

    public string? Fullname { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? ParentId { get; set; }

    public virtual User? Parent { get; set; }
}
