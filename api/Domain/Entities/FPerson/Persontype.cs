using System;
using System.Collections.Generic;

namespace Domain.Entities.FPerson;

public partial class Persontype
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
