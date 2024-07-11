namespace ECommerceCart.Domain.Model;

public class Entity
{
    public Guid Id { get; set; } = new Guid();
    public DateTime? CreatedAt { get; set; } = null;
    public DateTime? UpdatedAt { get; set; } = null;
    public DateTime? DeletedAt { get; set; } = null;
}

