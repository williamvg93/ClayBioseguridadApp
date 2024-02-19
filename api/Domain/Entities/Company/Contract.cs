using System;
using System.Collections.Generic;
using Domain.Entities.FPerson;

namespace Domain.Entities.Company;

public partial class Contract
{
    public int Id { get; set; }

    public DateTime ContractStartDate { get; set; }

    public DateTime ContractEndDate { get; set; }

    public int FkIdClient { get; set; }

    public int FkIdEmployee { get; set; }

    public int FkIdContractStatus { get; set; }

    public virtual Person FkIdClientNavigation { get; set; }

    public virtual Contractstatus FkIdContractStatusNavigation { get; set; }

    public virtual Person FkIdEmployeeNavigation { get; set; }

    public virtual ICollection<Shiftscheduling> Shiftschedulings { get; set; } = new List<Shiftscheduling>();
}
