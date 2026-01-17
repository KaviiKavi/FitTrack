using System;
using System.Collections.Generic;

namespace AuthService.Model;

public partial class Owner
{
    public int OwnerId { get; set; }

    public string BusinessName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
