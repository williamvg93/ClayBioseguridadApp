using System;
using System.Collections.Generic;
using Domain.Entities.Company;
using Domain.Entities.Location;

namespace Domain.Entities.FPerson;

public partial class Person
{
    public int Id { get; set; }

    public string Idperson { get; set; }

    public string Name { get; set; }

    public DateTime CreationDate { get; set; }

    public int FkIdPersonType { get; set; }

    public int FkIdPersonCate { get; set; }

    public int FkIdTown { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Contract> ContractFkIdClientNavigations { get; set; } = new List<Contract>();

    public virtual ICollection<Contract> ContractFkIdEmployeeNavigations { get; set; } = new List<Contract>();

    public virtual Personcategory FkIdPersonCateNavigation { get; set; }

    public virtual Persontype FkIdPersonTypeNavigation { get; set; }

    public virtual Town FkIdTownNavigation { get; set; }

    public virtual ICollection<Personcontact> Personcontacts { get; set; } = new List<Personcontact>();

    public virtual ICollection<Shiftscheduling> Shiftschedulings { get; set; } = new List<Shiftscheduling>();
}
