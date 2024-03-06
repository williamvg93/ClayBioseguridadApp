using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClayBio.Dtos.Post.Company;

public class ContractPDto
{
    public int Id { get; set; }
    public DateTime ContractStartDate { get; set; }
    public DateTime ContractEndDate { get; set; }
    public int FkIdClient { get; set; }
    public int FkIdEmployee { get; set; }
    public int FkIdContractStatus { get; set; }
}
