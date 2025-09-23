using System;
using System.Collections.Generic;

namespace AVi.Models;

public partial class Aircraft
{
    public int AircraftsId { get; set; }

    public string AircraftsName { get; set; } = null!;

    public int AircraftsModel { get; set; }

    public virtual AircraftsModel AircraftsModelNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
