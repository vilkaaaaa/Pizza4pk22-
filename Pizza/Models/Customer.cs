using System;
using System.Collections.Generic;

namespace Pizza.Models;

public partial class Customer
{
    public Guid Id { get; set; }

    public Guid? StoreId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
