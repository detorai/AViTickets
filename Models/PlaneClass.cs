using System;
using System.Collections.Generic;

namespace AVi.Models;

public partial class PlaneClass
{
    public int ClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
