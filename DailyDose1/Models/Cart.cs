using System;
using System.Collections.Generic;

namespace DailyDose1.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? MedicineId { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? Quantity { get; set; }

    public decimal? TotalPrice { get; set; }

    //public virtual Users? User { get; set; }
}
