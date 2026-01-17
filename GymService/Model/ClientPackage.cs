using System;
using System.Collections.Generic;

namespace GymService.Model;

public partial class ClientPackage
{
    public int ClientPackageId { get; set; }

    public int ClientId { get; set; }

    public int PackageId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public DateTime AssignedOn { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Package Package { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
