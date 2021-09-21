namespace PromotionEngine.Promotions
{
  using System.Linq;
  using PromotionEngine.Interfaces;
  using PromotionEngine.Models;

  public class ThreeAFixedPricePromotion : IPromotion
  {
    public void Calculate(Cart cart)
    {
      var itemSkuA = cart.Items.FirstOrDefault(item => item.SKU.Equals("A"));

      FixedPriceOnOneItemPromotionHelper fixedPriceOnOneItemPromotionHelper = new FixedPriceOnOneItemPromotionHelper();
      var calculatedPrice = fixedPriceOnOneItemPromotionHelper.Calculate(itemSkuA, 3, 130);

      cart.TotalPrice += calculatedPrice;
    }
  }
}