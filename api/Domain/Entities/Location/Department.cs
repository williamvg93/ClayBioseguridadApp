using System;
using System.Collections.Generic;

namespace Domain.Entities.Location;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int FkIdCountry { get; set; }

    public virtual Country FkIdCountryNavigation { get; set; }

    public virtual ICollection<Town> Towns { get; set; } = new List<Town>();
}
