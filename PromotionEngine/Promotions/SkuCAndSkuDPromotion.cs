namespace PromotionEngine.Promotions
{
  using System.Linq;
  using PromotionEngine.Interfaces;
  using PromotionEngine.Models;

  public class SkuCAndSkuDPromotion : IPromotion
  {
    public void Calculate(Cart cart)
    {
      var itemSkuC = cart.Items.FirstOrDefault(item => item.SKU.Equals("C"));
      var itemSkuD = cart.Items.FirstOrDefault(item => item.SKU.Equals("D"));

      if (itemSkuC?.Amount > 0 && itemSkuD?.Amount > 0)
      {
        if (itemSkuD.Amount > itemSkuC.Amount)
        {
          var numberOfPromotions = itemSkuC.Amount;
          var remainingDItems = itemSkuD.Amount - itemSkuC.Amount;
          cart.TotalPrice = (numberOfPromotions * 30) + (remainingDItems * 15);
        }
        else if(itemSkuD.Amount < itemSkuC.Amount)
        {
          var numberOfPromotions = itemSkuD.Amount;
          var remainingDItems = itemSkuC.Amount - itemSkuD.Amount;
          cart.TotalPrice = (numberOfPromotions * 30) + (remainingDItems * 20);
        }
        else
        {
          var numberOfPromotions = itemSkuC.Amount;
          cart.TotalPrice = (numberOfPromotions * 30);
        }
      }
    }
  }
}
