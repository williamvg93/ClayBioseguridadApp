using System;
using System.Collections.Generic;

namespace Domain.Entities.FPerson;

public partial class Contacttype
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Personcontact> Personcontacts { get; set; } = new List<Personcontact>();
}
