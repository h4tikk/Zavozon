namespace Backend.Model.Models;

public class Product
{
   public string Title { get; set; } = string.Empty;
   public string? Description { get; set; }
   
   public int Price { get; set; }
   public int Stock { get; set; }
   public bool IsActive { get; set; }
   
   public Guid SellerId { get; set; }
   public Seller Seller { get; set; } = null!;
   
   public string ImagePath { get; set; } = string.Empty;
}