using PromotionEngine.Models;
using System.Linq;

namespace PromotionEngine.Promotions
{

  public class FixedPriceOnOneItemPromotionHelper
  {
    public decimal Calculate(Item itemToGetPromotion, int amountToGetPromotion, decimal fixedPrice)
    {
      decimal result = default;

      if (itemToGetPromotion != null)
      {
        var numberOfPromotions = itemToGetPromotion.Amount / amountToGetPromotion;
        itemToGetPromotion.ItemsPromoted = numberOfPromotions * amountToGetPromotion;
        result = (numberOfPromotions * fixedPrice);

        if (itemToGetPromotion.ItemsPromoted > 0)
        {
          itemToGetPromotion.PromotionApplied = true;
        }
      }

      return result;
    }
  }
}