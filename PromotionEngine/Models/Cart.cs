using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
  public class Cart
  {
    public List<Item> Items { get; set; }

    public decimal TotalPrice { get; set; }
  }
}
