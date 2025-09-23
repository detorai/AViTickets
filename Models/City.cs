using System;
using System.Collections.Generic;

namespace AVi.Models;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public int CountryId { get; set; }

    public virtual ICollection<Airport> Airports { get; set; } = new List<Airport>();

    public virtual Country Country { get; set; } = null!;
}
