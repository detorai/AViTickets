using System;
using System.Collections.Generic;

namespace AVi.Models;

public partial class AircraftsModel
{
    public int ModelId { get; set; }

    public string ModelName { get; set; } = null!;

    public virtual ICollection<Aircraft> Aircraft { get; set; } = new List<Aircraft>();
}
