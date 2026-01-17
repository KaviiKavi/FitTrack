using System;
using System.Collections.Generic;

namespace GymService.Model;

public partial class Client
{
    public int ClientId { get; set; }

    public int OwnerId { get; set; }

    public string ClientName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? WhatsAppNumber { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? UpdateOn { get; set; }

    public virtual ICollection<ClientPackage> ClientPackages { get; set; } = new List<ClientPackage>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
