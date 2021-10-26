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

        [Test]
        public void Should_calculate_total_price_with_no_discount()
        {
            // arrange
            foreach (var item in _items)
            {
                _shoppingBasket.AddCartItem(new CartItem(item));
            }

            // act
            var totalPrice = _shoppingBasket.CalculateTotalPrice();

            // assert
            totalPrice.Should().Be(2.95d);
        }

        [Test]
        public void Should_calculate_total_price_with_50_percent_off_discount_on_bread()
        {
            // arrange
            _shoppingBasket.AddCartItem(new CartItem(_items[0], 2));
            _shoppingBasket.AddCartItem(new CartItem(_items[2], 2));
            
            // act
            var totalPrice = _shoppingBasket.CalculateTotalPrice();

            // assert
            totalPrice.Should().Be(3.10d);
        }
    }
}