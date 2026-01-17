using System;
using System.Collections.Generic;

namespace GymService.Model;

public partial class PaymentHistory
{
    public int HistoryId { get; set; }

    public int PaymentId { get; set; }

    public string Action { get; set; } = null!;

    public DateTime ActionDate { get; set; }

    public virtual Payment Payment { get; set; } = null!;
}
