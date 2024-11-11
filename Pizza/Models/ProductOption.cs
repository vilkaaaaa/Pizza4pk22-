using System;
using System.Collections.Generic;

namespace Pizza.Models;

public partial class ProductOption
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Factor { get; set; }

    public bool IsPizzaOption { get; set; }

    public bool IsSaladOption { get; set; }

    public virtual ICollection<OrderItemOption> OrderItemOptions { get; set; } = new List<OrderItemOption>();
}
