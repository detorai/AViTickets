using System;
using System.Collections.Generic;

namespace AVi.Models;

public partial class Airline
{
    public int AirlinesId { get; set; }

    public string AirlinesName { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
