using System.Collections.Generic;

namespace PromotionEngine.Tests
{
  using NUnit.Framework;
  using PromotionEngine.Models;
  using PromotionEngine.Promotions;

  class SkuCAndSkuDPromotionTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Can_Give_Discount_On_One_C_And_One_D_Items()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "C",
          Price = 20m,
          Amount = 1
        },
        new Item()
        {
          SKU = "D",
          Price = 15,
          Amount = 1
        }
      };

      SkuCAndSkuDPromotion promotion = new SkuCAndSkuDPromotion();
      promotion.Calculate(cart);
      Assert.AreEqual(30m, cart.TotalPrice);
    }

    [Test]
    public void Can_Give_Discount_On_Two_C_And_Two_D_Items()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "C",
          Price = 20m,
          Amount = 2
        },
        new Item()
        {
          SKU = "D",
          Price = 15,
          Amount = 2
        }
      };

      SkuCAndSkuDPromotion promotion = new SkuCAndSkuDPromotion();
      promotion.Calculate(cart);
      Assert.AreEqual(60m, cart.TotalPrice);
    }

    [Test]
    public void Can_Give_Discount_On_Two_C_And_One_D_Items()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "C",
          Price = 20m,
          Amount = 2
        },
        new Item()
        {
          SKU = "D",
          Price = 15,
          Amount = 1
        }
      };

      SkuCAndSkuDPromotion promotion = new SkuCAndSkuDPromotion();
      promotion.Calculate(cart);
      Assert.AreEqual(50m, cart.TotalPrice);
    }

    [Test]
    public void Can_Give_Discount_On_One_C_And_Two_D_Items()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "C",
          Price = 20m,
          Amount = 1
        },
        new Item()
        {
          SKU = "D",
          Price = 15,
          Amount = 2
        }
      };

      SkuCAndSkuDPromotion promotion = new SkuCAndSkuDPromotion();
      promotion.Calculate(cart);
      Assert.AreEqual(45m, cart.TotalPrice);
    }
  }
}
