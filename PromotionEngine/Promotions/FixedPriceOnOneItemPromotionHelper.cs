using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Promotions
{
  using PromotionEngine.Models;

  public class FixedPriceOnOneItemPromotionHelper
  {
    public decimal Calculate(Cart cart, Item itemToGetPromotion, int amountToGetPromotion, decimal fixedPrice)
    {
      decimal result = default;

      if (itemToGetPromotion != null)
      {
        var numberOfPromotions = itemToGetPromotion.Amount / amountToGetPromotion;
        var remainder = itemToGetPromotion.Amount % amountToGetPromotion;

        result = (numberOfPromotions * fixedPrice) + (remainder * itemToGetPromotion.Price);
      }

      return result;
    }
  }
}