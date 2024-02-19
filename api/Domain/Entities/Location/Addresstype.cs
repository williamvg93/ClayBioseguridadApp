using System;
using System.Collections.Generic;

namespace Domain.Entities.Location;

public partial class Addresstype
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
