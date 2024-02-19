using System;
using System.Collections.Generic;

namespace Domain.Entities.FPerson;

public partial class Personcontact
{
    public int Id { get; set; }

    public string Description { get; set; }

    public int FkIdPerson { get; set; }

    public int FkIdContactType { get; set; }

    public virtual Contacttype FkIdContactTypeNavigation { get; set; }

    public virtual Person FkIdPersonNavigation { get; set; }
}
