using NUnit.Framework;

namespace PromotionEngine.Tests
{
  using System.Collections.Generic;
  using PromotionEngine.Models;
  using PromotionEngine.Promotions;

  public class ThreeAFixedPricePromotionTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Can_Give_Discount_On_Three_Items()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "A", 
          Price = 50m,
          Amount = 3
        }
      };

      ThreeAFixedPricePromotion promotion = new ThreeAFixedPricePromotion();
      promotion.Calculate(cart);
      Assert.AreEqual(130m, cart.TotalPrice);
    }

    [Test]
    public void Can_Give_Discount_On_Six_Items()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "A",
          Price = 50m,
          Amount = 6
        }
      };

      ThreeAFixedPricePromotion promotion = new ThreeAFixedPricePromotion();
      promotion.Calculate(cart);
      Assert.AreEqual(260m, cart.TotalPrice);
    }

    [Test]
    public void Can_Give_Discount_On_Five_Items()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "A",
          Price = 50m,
          Amount = 5
        }
      };

      ThreeAFixedPricePromotion promotion = new ThreeAFixedPricePromotion();
      promotion.Calculate(cart);
      Assert.AreEqual(230m, cart.TotalPrice);
    }

    [Test]
    public void No_Discount_On_Two_Items()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "A",
          Price = 50m,
          Amount = 2
        }
      };

      ThreeAFixedPricePromotion promotion = new ThreeAFixedPricePromotion();
      promotion.Calculate(cart);
      Assert.AreEqual(100m, cart.TotalPrice);
    }
  }
}