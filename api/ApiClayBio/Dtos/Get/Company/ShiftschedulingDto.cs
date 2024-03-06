using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClayBio.Dtos.Get.Company;

public class ShiftschedulingDto
{
    public int Id { get; set; }
    public int FkIdContract { get; set; }
    public int FkIdPerson { get; set; }
    public int FkIdWorkShifts { get; set; }
}
