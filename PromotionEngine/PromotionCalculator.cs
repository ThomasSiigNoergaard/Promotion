using System.Collections.Generic;
using PromotionEngine.Interfaces;
using PromotionEngine.Models;

namespace PromotionEngine
{
  using System;
  using System.Linq;

  public class PromotionCalculator
  {
    private readonly IEnumerable<IPromotion> _promotions;

    public PromotionCalculator(IEnumerable<IPromotion> promotions)
    {
      _promotions = promotions;
    }

    public decimal CalculatePrice(Cart cart)
    {
      AddPromotions(cart);
      AddNotPromotioned(cart);

      return cart.TotalPrice;
    }

    private void AddNotPromotioned(Cart cart)
    {
      foreach (var cartItem in cart.Items.Where(x => x.ItemsPromoted != x.Amount))
      {
        var itemsAmountNotPromoted = cartItem.Amount - cartItem.ItemsPromoted;
        cart.TotalPrice += itemsAmountNotPromoted * cartItem.Price;
      }
    }

    private void AddPromotions(Cart cart)
    {
      foreach (var promotion in _promotions)
      {
        promotion.Calculate(cart);
      }
    }
  }
}