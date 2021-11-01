using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using PriceCalculator.Builders;
using PriceCalculator.Domain;
using PriceCalculator.Factories;

namespace PriceCalculator.IntegrationTests
{
    public class ShoppingBasketTests
    {
        private List<Item> _items;
        private ShoppingBasket _shoppingBasket;

        [SetUp]
        public void Setup()
        {
            _items = ItemsFactory.GetItems();
            var discountRules = DiscountRulesFactory.GetDiscountRules(_items);
            var discountFactory = new ShoppingBasketDiscountBuilder(discountRules);
            _shoppingBasket = new ShoppingBasket(discountFactory);
        }

        [Test]
        public void Should_calculate_total_price_with_no_discount()
        {
            // arrange
            foreach (var item in _items)
            {
                _shoppingBasket.AddItem(item);
            }

            // act
            var totalPrice = _shoppingBasket.CalculateTotalPrice();

            // assert
            totalPrice.Should().Be(2.95m);
        }

        [Test]
        public void Should_calculate_total_price_with_50_percent_off_discount_on_bread()
        {
            // arrange
            _shoppingBasket.AddItem(_items[0], 2);
            _shoppingBasket.AddItem(_items[2], 2);

            // act
            var totalPrice = _shoppingBasket.CalculateTotalPrice();

            // assert
            totalPrice.Should().Be(3.10m);
        }

        [Test]
        public void Should_calculate_total_price_with_one_milk_for_free()
        {
            // arrange
            _shoppingBasket.AddItem(_items[1], 4);

            // act
            var totalPrice = _shoppingBasket.CalculateTotalPrice();

            // assert
            totalPrice.Should().Be(3.45m);
        }

        [Test]
        public void Should_calculate_total_price_with_multiple_discounts()
        {
            // arrange
            _shoppingBasket.AddItem(_items[0], 2);
            _shoppingBasket.AddItem(_items[1], 8);
            _shoppingBasket.AddItem(_items[2], 1);

            // act
            var totalPrice = _shoppingBasket.CalculateTotalPrice();

            // assert
            totalPrice.Should().Be(9);
        }
    }
}