using NUnit.Framework;
using System.Collections.Generic;
using PromotionEngine.Models;
using PromotionEngine.Promotions;
using System.Linq;

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

      Assert.IsEmpty(cart.Items.Where(x => !x.PromotionApplied));
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

      Assert.IsEmpty(cart.Items.Where(x => !x.PromotionApplied));
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
      Assert.AreEqual(45m, cart.TotalPrice);

      Assert.IsEmpty(cart.Items.Where(x => !x.PromotionApplied));
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
      Assert.AreEqual(0m, cart.TotalPrice);

      Assert.IsNotEmpty(cart.Items.Where(x => !x.PromotionApplied));
    }
  }
}