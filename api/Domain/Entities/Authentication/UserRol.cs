using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Authentication;

public class UserRol
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User Users { get; set; }
    public int RolId { get; set; }
    public Rol Rols { get; set; }
}
