using System;
using System.Collections.Generic;

namespace AVi.Models;

public partial class Airport
{
    public int AirportId { get; set; }

    public string AirportName { get; set; } = null!;

    public int AirportCity { get; set; }

    public virtual City AirportCityNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> TicketArAirports { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketDepAirports { get; set; } = new List<Ticket>();
}
