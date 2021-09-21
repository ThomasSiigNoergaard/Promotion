using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PromotionEngine.Models;
using PromotionEngine.Promotions;

namespace PromotionEngine.Tests
{
  using PromotionEngine.Interfaces;

  public class PromotionCalculatorTests
  {
    public List<IPromotion> Promotions { get; set; }

    [SetUp]
    public void Setup()
    {
      Promotions = new List<IPromotion>
      {
        new SkuCAndSkuDPromotion(),
        new ThreeAFixedPricePromotion(),
        new TwoBFixedPricePromotion()
      };
    }

    [Test]
    public void NoDiscountAllPromotions()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "A",
          Price = 50m,
          Amount = 1
        },
        new Item()
        {
          SKU = "B",
          Price = 30,
          Amount = 1
        },
        new Item()
        {
          SKU = "C",
          Price = 20,
          Amount = 1
        }
      };

      PromotionCalculator promotion = new PromotionCalculator(Promotions);
      var calculatedPromotion = promotion.CalculatePrice(cart);

      Assert.AreEqual(0, calculatedPromotion);
      Assert.AreEqual(100, cart.TotalPriceWithoutDiscount);

      Assert.AreEqual(3, cart.Items.Where(x => !x.PromotionApplied)?.Count());
    }

    [Test]
    public void DiscountScenarioB()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "A",
          Price = 50m,
          Amount = 5
        },
        new Item()
        {
          SKU = "B",
          Price = 30,
          Amount = 5
        },
        new Item()
        {
          SKU = "C",
          Price = 20,
          Amount = 1
        }
      };

      PromotionCalculator promotion = new PromotionCalculator(Promotions);
      var calculatedPrice = promotion.CalculatePrice(cart);

      Assert.AreEqual(370, calculatedPrice);
      Assert.AreEqual(420, cart.TotalPriceWithoutDiscount);
      Assert.AreEqual(1, cart.Items.Where(x => !x.PromotionApplied)?.Count());
    }

    [Test]
    public void DiscountScenarioC()
    {
      Cart cart = new Cart();
      cart.Items = new List<Item>()
      {
        new Item()
        {
          SKU = "A",
          Price = 50m,
          Amount = 5
        },
        new Item()
        {
          SKU = "B",
          Price = 30,
          Amount = 5
        },
        new Item()
        {
          SKU = "C",
          Price = 20,
          Amount = 1
        }
      };

      PromotionCalculator promotion = new PromotionCalculator(Promotions);
      var calculatedPrice = promotion.CalculatePrice(cart);

      Assert.AreEqual(370, calculatedPrice);
      Assert.AreEqual(420, cart.TotalPriceWithoutDiscount);
      Assert.AreEqual(1, cart.Items.Where(x => !x.PromotionApplied)?.Count());
    }
  }
}