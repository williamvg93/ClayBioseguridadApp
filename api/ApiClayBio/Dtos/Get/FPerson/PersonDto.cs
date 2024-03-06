using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClayBio.Dtos.Get.FPerson;

public class PersonDto
{
    public int Id { get; set; }
    public string Idperson { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
}
