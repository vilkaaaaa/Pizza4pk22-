using System;
using System.Collections.Generic;

namespace Pizza.Models;

public partial class ProductSize
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal? PremiumPrice { get; set; }

    public decimal? ToppingPrice { get; set; }

    public bool? IsGlutenFree { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
