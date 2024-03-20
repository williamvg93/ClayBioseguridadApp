using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClayBio.Dtos.Post.Authentication;

public class AddRoleDto
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
