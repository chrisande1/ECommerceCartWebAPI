namespace ECommerceCart.Domain.Model;

public class Cart : Entity
{
    public string ItemName { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public User User { get; set; } = null!;
}

