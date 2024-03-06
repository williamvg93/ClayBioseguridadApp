using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClayBio.Dtos.Post.Location;

public class TownPDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int FkIdDepartment { get; set; }
}
