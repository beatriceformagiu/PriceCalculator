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
            var totalPrice = CartItems.Sum(cartItem => cartItem.Quantity * cartItem.Item.Price) - discount;
            DisplayCartItems();
            Console.WriteLine($"Total price:    {totalPrice}£");
            return totalPrice;
        }

        public void AddItem(Item item, int quantity = 1)
        {
            AddCartItem(new CartItem(item, quantity));
        }

        public void DisplayCartItems()
        {
            Console.WriteLine("The shopping basket contains the following items:");
            Console.WriteLine("Item  Quantity");
            foreach (var cartItem in CartItems)
            {
                Console.WriteLine($"{cartItem.Item.Name}  x  {cartItem.Quantity}");
            }
            Console.WriteLine("--------------------------------");
        }

        private void AddCartItem(CartItem newCartItem)
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