using NUnit.Framework;

namespace PromotionEngine.Tests
{
  using System.Collections.Generic;
  using PromotionEngine.Models;

  public class Tests
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

      Assert.AreEqual(130m, cart.TotalPrice);
    }
  }
}