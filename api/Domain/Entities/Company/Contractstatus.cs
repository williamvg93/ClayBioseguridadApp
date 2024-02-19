using System;
using System.Collections.Generic;

namespace Domain.Entities.Company;

public partial class Contractstatus
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
