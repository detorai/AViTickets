using System;
using System.Collections.Generic;

namespace AVi.Models;

public partial class Booker
{
    public int UserId { get; set; }

    public int BookerId { get; set; }

    public int TicketId { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
