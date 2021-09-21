using PromotionEngine.Models;

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
        var remainder = itemToGetPromotion.Amount % amountToGetPromotion;

        result = (numberOfPromotions * fixedPrice) + (remainder * itemToGetPromotion.Price);
      }

      return result;
    }
  }
}