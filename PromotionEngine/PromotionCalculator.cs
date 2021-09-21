using System.Collections.Generic;
using PromotionEngine.Interfaces;
using PromotionEngine.Models;

namespace PromotionEngine
{

  public class PromotionCalculator
  {
    private readonly IEnumerable<IPromotion> _promotions;

    public PromotionCalculator(IEnumerable<IPromotion> promotions)
    {
      _promotions = promotions;
    }

    public decimal CalculatePrice(Cart cart)
    {
      foreach (var promotion in _promotions)
      {
        promotion.Calculate(cart);
      }

      return cart.TotalPrice;
    }
  }
}