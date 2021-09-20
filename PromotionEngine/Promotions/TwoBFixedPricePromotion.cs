namespace PromotionEngine.Promotions
{
  using System.Linq;
  using PromotionEngine.Interfaces;
  using PromotionEngine.Models;

  public class TwoBFixedPricePromotion : IPromotion
  {
    public void Calculate(Cart cart)
    {
      var itemSkuB = cart.Items.FirstOrDefault(item => item.SKU.Equals("B"));

      FixedPriceOnOneItemPromotionHelper fixedPriceOnOneItemPromotionHelper = new FixedPriceOnOneItemPromotionHelper();
      var calculatedPrice = fixedPriceOnOneItemPromotionHelper.Calculate(cart, itemSkuB, 2, 45);

      cart.TotalPrice += calculatedPrice;
    }
  }
}
