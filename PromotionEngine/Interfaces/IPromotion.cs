using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Interfaces
{
  using PromotionEngine.Models;

  public interface IPromotion
  {
    public void Calculate(Cart cart);
  }
}
