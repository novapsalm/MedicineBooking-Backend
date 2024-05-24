using System;
using System.Collections.Generic;

namespace DailyDose1.Models;

public partial class Medicine
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Descriptions { get; set; }

    public string? Manufacturer { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? Quantity { get; set; }

    public DateTime? ExpDate { get; set; }
}
