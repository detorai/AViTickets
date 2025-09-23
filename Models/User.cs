using System;
using System.Collections.Generic;

namespace AVi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserFio { get; set; }

    public string UserPhone { get; set; } = null!;

    public string? UserEmail { get; set; }

    public int? Bookers { get; set; }

    public int UserRole { get; set; }

    public string? UserPasport { get; set; }

    public string Passwordhash { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public virtual Booker? Bookers1 { get; set; }

    public virtual ICollection<Booker> BookersNavigation { get; set; } = new List<Booker>();

    public virtual Role UserRoleNavigation { get; set; } = null!;
}
