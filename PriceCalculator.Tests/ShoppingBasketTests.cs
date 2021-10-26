using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using PriceCalculator.Domain;

namespace PriceCalculator.Tests
{
    public class ShoppingBasketTests
    {
        private List<Item> _items;
        private ShoppingBasket _shoppingBasket;

        [SetUp]
        public void Setup()
        {
            _items = ItemsHelper.GetItems();
            _shoppingBasket = new ShoppingBasket();
        }

        [TestCase()]
        public void Should_calculate_total_price_with_no_discount()
        {
            // arrange
            _shoppingBasket.CartItems = new List<CartItem>();
            foreach (var item in _items)
            {
                _shoppingBasket.CartItems.Add(new CartItem(item));
            }

            // act
            var totalPrice = _shoppingBasket.CalculateTotalPrice();

            // assert
            totalPrice.Should().Be(2.95d);
        }
    }
}