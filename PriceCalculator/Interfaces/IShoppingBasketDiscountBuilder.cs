using System.Collections.Generic;
using PriceCalculator.Domain;

namespace PriceCalculator.Interfaces
{
    public interface IShoppingBasketDiscountBuilder
    {
        decimal GetTotalDiscount(List<CartItem> cartItems);
    }
}
