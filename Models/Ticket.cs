using System;
using System.Collections.Generic;

namespace AVi.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int? TarifId { get; set; }

    public int ClassId { get; set; }

    public int AircraftId { get; set; }

    public int ArAirportId { get; set; }

    public int DepAirportId { get; set; }

    public int AirlinesId { get; set; }

    public DateTime TimeOut { get; set; }

    public DateTime TimeIn { get; set; }

    public int TicketNumb { get; set; }

    public bool? BookerState { get; set; }

    public string Seat { get; set; } = null!;

    public int Cost { get; set; }

    public virtual Aircraft Aircraft { get; set; } = null!;

    public virtual Airline Airlines { get; set; } = null!;

    public virtual Airport ArAirport { get; set; } = null!;

    public virtual ICollection<Booker> Bookers { get; set; } = new List<Booker>();

    public virtual PlaneClass Class { get; set; } = null!;

    public virtual Airport DepAirport { get; set; } = null!;

    public virtual Tarif? Tarif { get; set; }
}
