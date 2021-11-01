using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PriceCalculator.Domain;
using PriceCalculator.Factories;
using PriceCalculator.Interfaces;

namespace PriceCalculator.UnitTests
{
    public class ShoppingBasketTests
    {
        private List<Item> _items;
        private ShoppingBasket _shoppingBasket;
        private Mock<IShoppingBasketDiscountBuilder> _shoppingBasketDiscountBuilder;

        [SetUp]
        public void Setup()
        {
            _items = ItemsFactory.GetItems();
            _shoppingBasketDiscountBuilder = new Mock<IShoppingBasketDiscountBuilder>();
            _shoppingBasket = new ShoppingBasket(_shoppingBasketDiscountBuilder.Object);
        }

        [Test]
        public void Should_add_item()
        {
            // arrange & act
            _shoppingBasket.AddItem(_items[0]);

            // assert
            _shoppingBasket.CartItems.Count.Should().Be(1);
            _shoppingBasket.CartItems[0].Quantity.Should().Be(1);
        }

        [Test]
        public void Should_add_item_with_correct_quantity()
        {
            // arrange
            var quantity = 2;

            // act
           _shoppingBasket.AddItem(_items[0], quantity);

            // assert
            _shoppingBasket.CartItems.Count.Should().Be(1);
            _shoppingBasket.CartItems[0].Quantity.Should().Be(quantity);
        }

      
        [Test]
        public void Should_calculate_total_price_when_no_discounts()
        {
            // arrange
            foreach (var item in _items)
            {
                _shoppingBasket.AddItem(item);
            }
            _shoppingBasketDiscountBuilder.Setup(x => x.GetTotalDiscount(It.IsAny<List<CartItem>>())).Returns(0);

            // act
            var price = _shoppingBasket.CalculateTotalPrice();

            // assert
            price.Should().Be(2.95m);
        }

        [Test]
        public void Should_calculate_total_price_when_discounts()
        {
            // arrange
            foreach (var item in _items)
            {
                _shoppingBasket.AddItem(item);
            }
            _shoppingBasketDiscountBuilder.Setup(x => x.GetTotalDiscount(It.IsAny<List<CartItem>>())).Returns(0.40m);

            // act
            var price = _shoppingBasket.CalculateTotalPrice();

            // assert
            price.Should().Be(2.55m);
        }
    }
}
