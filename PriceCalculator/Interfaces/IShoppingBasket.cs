using PriceCalculator.Domain;

namespace PriceCalculator.Interfaces
{
    public interface IShoppingBasket
    {
        public decimal CalculateTotalPrice();
        public void AddCartItem(CartItem newCartItem);
    }
}
