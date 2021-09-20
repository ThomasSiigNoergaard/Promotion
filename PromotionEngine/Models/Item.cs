using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
  public class Item
  {
    public string SKU { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
  }
}
