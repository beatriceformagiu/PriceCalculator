using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator.Domain
{
    public class ShoppingBasket
    {
        public List<CartItem> CartItems { get; set; }

        public double CalculateTotalPrice()
        {
            return CartItems.Sum(cartItem => cartItem.Quantity * cartItem.Item.Price);
        }
    }
}