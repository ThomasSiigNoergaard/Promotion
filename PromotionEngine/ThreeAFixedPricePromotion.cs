using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
  using PromotionEngine.Interfaces;
  using PromotionEngine.Models;

  public class ThreeAFixedPricePromotion : IPromotion
  {
    public void Calculate(Cart cart)
    {
      var itemSkuA = cart.Items.FirstOrDefault(item => item.SKU.Equals("A"));

      if (itemSkuA != null)
      {
        var numberOfPromotions = itemSkuA.Amount / 3;
        var remainder = itemSkuA.Amount % 3;

        cart.TotalPrice += (numberOfPromotions * 130) + (remainder * 50);
      }
    }
  }
}
