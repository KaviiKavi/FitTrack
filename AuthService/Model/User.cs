using System;
using System.Collections.Generic;

namespace AuthService.Model;

public partial class User
{
    public int UserId { get; set; }

    public int OwnerId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int RoleId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual Owner Owner { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
