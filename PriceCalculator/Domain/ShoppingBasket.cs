using System;
using System.Collections.Generic;
using System.Linq;
using PriceCalculator.Interfaces;

namespace PriceCalculator.Domain
{
    public class ShoppingBasket: IShoppingBasket
    {
        private readonly IShoppingBasketDiscountBuilder _shoppingBasketDiscountBuilder;
        public List<CartItem> CartItems { get; private set; }
        
        public ShoppingBasket(IShoppingBasketDiscountBuilder shoppingBasketDiscountBuilder)
        {
            _shoppingBasketDiscountBuilder = shoppingBasketDiscountBuilder;
            CartItems = new List<CartItem>();
        }

        public decimal CalculateTotalPrice()
        {
            var discount = _shoppingBasketDiscountBuilder.GetTotalDiscount(CartItems);
            return CartItems.Sum(cartItem => cartItem.Quantity * cartItem.Item.Price) - discount;
        }

        public void AddItems(List<Item> items)
        {
            foreach (var item in items)
            {
                AddCartItem(new CartItem(item));
            }
        }

        public void AddCartItem(CartItem newCartItem)
        {
            var cartItemExists = CartItems.Exists(c => c.Item.Id.Equals(newCartItem.Item.Id));
            if (cartItemExists)
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