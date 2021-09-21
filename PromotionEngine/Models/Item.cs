namespace PromotionEngine.Models
{
  public class Item
  {
    public string SKU { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public bool PromotionApplied { get; set; }
    public int ItemsPromoted { get; set; }
  }
}