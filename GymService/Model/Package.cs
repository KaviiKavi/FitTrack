using System;
using System.Collections.Generic;

namespace GymService.Model;

public partial class Package
{
    public int PackageId { get; set; }

    public int OwnerId { get; set; }

    public string PackageName { get; set; } = null!;

    public int DurationInDays { get; set; }

    public decimal Amount { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? UpdateOn { get; set; }

    public virtual ICollection<ClientPackage> ClientPackages { get; set; } = new List<ClientPackage>();
}
