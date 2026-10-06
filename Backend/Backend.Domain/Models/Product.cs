namespace Backend.Model.Models;

public class Product : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public long Price { get; set; }
    public int Stock { get; set; }
    public bool IsActive { get; set; }

    public Guid SellerId { get; set; }
    public Seller Seller { get; set; } = null!;

    public string ImagePath { get; set; } = string.Empty;

    public ICollection<CartItem> CartItems { get; set; } = [];
    public ICollection<OrderItem> OrderItems { get; set; } = [];
}
