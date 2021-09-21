using NUnit.Framework;
using System.Collections.Generic;
using PromotionEngine.Models;
using PromotionEngine.Promotions;

namespace PromotionEngine.Tests
{

  public class TwoBFixedPricePromotionTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Can_Give_Discount_On_Two_Items()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "B", 
          Price = 30m,
          Amount = 2
        }
      };

      TwoBFixedPricePromotion promotion = new TwoBFixedPricePromotion();
      promotion.Calculate(cart);
      Assert.AreEqual(45m, cart.TotalPrice);
    }

    [Test]
    public void Can_Give_Discount_On_Four_Items()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "B",
          Price = 30m,
          Amount = 4
        }
      };

      TwoBFixedPricePromotion promotion = new TwoBFixedPricePromotion();
      promotion.Calculate(cart);
      Assert.AreEqual(90m, cart.TotalPrice);
    }

    [Test]
    public void Can_Give_Discount_On_Three_Items()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "B",
          Price = 30m,
          Amount = 3
        }
      };

      TwoBFixedPricePromotion promotion = new TwoBFixedPricePromotion();
      promotion.Calculate(cart);
      Assert.AreEqual(75m, cart.TotalPrice);
    }

    [Test]
    public void No_Discount_On_One_Item()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "B",
          Price = 30m,
          Amount = 1
        }
      };

      TwoBFixedPricePromotion promotion = new TwoBFixedPricePromotion();
      promotion.Calculate(cart);
      Assert.AreEqual(30m, cart.TotalPrice);
    }
  }
}