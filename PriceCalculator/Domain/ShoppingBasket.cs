using System.Collections.Generic;

namespace PriceCalculator.Domain
{
    public class ShoppingBasket
    {
        public List<CartItem> CartItems { get; set; }

        public double CalculateTotalPrice()
        {
            throw new System.NotImplementedException();
        }
    }
}