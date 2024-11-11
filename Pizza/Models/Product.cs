using System;
using System.Collections.Generic;

namespace Pizza.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Image { get; set; }

    public bool HasOptions { get; set; }

    public bool? IsVegetarian { get; set; }

    public bool? WithTomatoSauce { get; set; }

    public string? SizeIds { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
