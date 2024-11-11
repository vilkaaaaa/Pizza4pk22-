using System;
using System.Collections.Generic;

namespace Pizza.Models;

public partial class OrderItem
{
    public long Id { get; set; }

    public Guid? StoreId { get; set; }

    public long OrderId { get; set; }

    public int ProductId { get; set; }

    public int ProductSizeId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public string? Instructions { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<OrderItemOption> OrderItemOptions { get; set; } = new List<OrderItemOption>();

    public virtual Product Product { get; set; } = null!;

    public virtual ProductSize ProductSize { get; set; } = null!;
}
