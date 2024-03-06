using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClayBio.Dtos.Post.Location;

public class AddressPDto
{
    public int Id { get; set; }
    public string Address1 { get; set; }
    public int FkIdPerson { get; set; }
    public int FkIdAddressType { get; set; }
}
