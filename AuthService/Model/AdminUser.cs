using System;
using System.Collections.Generic;

namespace AuthService.Model;

public partial class AdminUser
{
    public int AdminUserId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }
}
