using System;
using System.Collections.Generic;

namespace GymService.Model;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int ClientId { get; set; }

    public int ClientPackageId { get; set; }

    public decimal PaidAmount { get; set; }

    public DateOnly PaymentDate { get; set; }

    public DateOnly? NextPaymentDate { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ClientPackage ClientPackage { get; set; } = null!;

    public virtual ICollection<PaymentHistory> PaymentHistories { get; set; } = new List<PaymentHistory>();
}
