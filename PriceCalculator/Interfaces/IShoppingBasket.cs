using PriceCalculator.Domain;

namespace PriceCalculator.Interfaces
{
    public interface IShoppingBasket
    {
        decimal CalculateTotalPrice();
        void AddItem(Item item, int quantity);
    }
}
