using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator.Domain
{
    public class ShoppingBasket
    {
        public ShoppingBasket()
        {
            CartItems = new List<CartItem>();
        }

        private List<CartItem> CartItems { get; set; }

        public double CalculateTotalPrice()
        {
            return CartItems.Sum(cartItem => cartItem.Quantity * cartItem.Item.Price);
        }

        public void AddCartItem(CartItem newCartItem)
        {
            if (CartItems.Contains(newCartItem))
            {
                foreach (var cartItem in CartItems)
                {
                    if (cartItem.Item == newCartItem.Item)
                    {
                        cartItem.Quantity++;
                    }
                }
            }
            else
            {
                CartItems.Add(newCartItem);
            }
        }
    }
}