using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClayBio.Dtos.Post.FPerson;

public class PersonPDto
{
    public int Id { get; set; }
    public string Idperson { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public int FkIdPersonType { get; set; }
    public int FkIdPersonCate { get; set; }
    public int FkIdTown { get; set; }
}
