using System;
using System.Collections.Generic;

namespace AVi.Models;

public partial class Tarif
{
    public int TarifId { get; set; }

    public int TarifCost { get; set; }

    public bool? BaggageState { get; set; }

    public bool? SwitchState { get; set; }

    public bool? BackupState { get; set; }

    public int? BaggageCount { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
