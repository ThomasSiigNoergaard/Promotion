using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Models
{
  public class Cart
  {
    public List<Item> Items { get; set; }

    public decimal TotalPrice { get; set; }

    public decimal TotalPriceWithoutDiscount => Items.Sum(x => x.Price * x.Amount);
  }
}
