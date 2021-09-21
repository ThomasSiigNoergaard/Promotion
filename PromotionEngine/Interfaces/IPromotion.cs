namespace PromotionEngine.Interfaces
{
  using PromotionEngine.Models;

  public interface IPromotion
  {
    public void Calculate(Cart cart);
  }
}
