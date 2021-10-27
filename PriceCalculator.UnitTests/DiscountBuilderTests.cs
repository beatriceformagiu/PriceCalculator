using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using PriceCalculator.Builders;
using PriceCalculator.Domain;
using PriceCalculator.Factories;

namespace PriceCalculator.UnitTests
{
    public class DiscountBuilderTests
    {
        private List<Item> _items;
        private ShoppingBasketDiscountBuilder _shoppingBasketDiscountBuilder;

        [SetUp]
        public void Setup()
        {
            _items = ItemsFactory.GetItems();
            var discountRules = DiscountRulesFactory.GetDiscountRules(_items);

            _shoppingBasketDiscountBuilder = new ShoppingBasketDiscountBuilder(discountRules);
        }

        [Test]
        public void Should_return_no_discount()
        {
            // arrange & act
            var discount = _shoppingBasketDiscountBuilder.GetTotalDiscount(new List<CartItem>() { new CartItem(_items[0]) });

            // assert
            discount.Should().Be(0);
        }

        [Test]
        public void Should_return_discount_at_bread()
        {
            // arrange & act
            var discount = _shoppingBasketDiscountBuilder.GetTotalDiscount(new List<CartItem>
                { new CartItem(_items[0], 2), new CartItem(_items[2], 2) });

            // assert
            discount.Should().Be(0.50m);
        }

        [Test]
        public void Should_return_discount_at_milk()
        {
            // arrange & act
            var discount = _shoppingBasketDiscountBuilder.GetTotalDiscount(new List<CartItem>
                { new CartItem(_items[1], 4) });

            // assert
            discount.Should().Be(1.15m);
        }
    }
}
