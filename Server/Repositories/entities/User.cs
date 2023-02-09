using System;
using System.Collections.Generic;

namespace Repositories.entities;

public partial class User
{
    public int NumUser { get; set; }

    public string? IdUser { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? Date { get; set; }

    public string? MaleOrFemale { get; set; }

    public string? Hmo { get; set; }

    public virtual ICollection<Child> Children { get; } = new List<Child>();
   
}
