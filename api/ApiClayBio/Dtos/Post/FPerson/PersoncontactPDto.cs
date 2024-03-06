using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClayBio.Dtos.Post.FPerson;

public class PersoncontactPDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int FkIdPerson { get; set; }
    public int FkIdContactType { get; set; }
}
