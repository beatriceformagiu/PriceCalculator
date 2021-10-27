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
        public void Should_add_cart_items()
        {
            // arrange & act
            foreach (var item in _items)
            {
                _shoppingBasket.AddCartItem(new CartItem(item));
            }
            
            // assert
            _shoppingBasket.CartItems.Count.Should().Be(_items.Count);
        }

        [Test]
        public void Should_add_cart_items_with_correct_quantity()
        {
            // arrange & act
            _shoppingBasket.AddCartItem(new CartItem(_items[0]));
            _shoppingBasket.AddCartItem(new CartItem(_items[0]));

            // assert
            _shoppingBasket.CartItems.Count.Should().Be(1);
            _shoppingBasket.CartItems[0].Quantity.Should().Be(2);
        }

        [Test]
        public void Should_add_items()
        {
            // arrange & act
           _shoppingBasket.AddItems(_items);

            // assert
            _shoppingBasket.CartItems.Count.Should().Be(_items.Count);
        }

        [Test]
        public void Should_add_items_with_correct_quantity()
        {
            // arrange & act
            _shoppingBasket.AddItems(new List<Item>() { _items[0], _items[0]});

            // assert
            _shoppingBasket.CartItems.Count.Should().Be(1);
            _shoppingBasket.CartItems[0].Quantity.Should().Be(2);
        }

        [Test]
        public void Should_calculate_total_price_when_no_discounts()
        {
            // arrange
            _shoppingBasket.AddItems(_items);
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
            _shoppingBasket.AddItems(_items);
            _shoppingBasketDiscountBuilder.Setup(x => x.GetTotalDiscount(It.IsAny<List<CartItem>>())).Returns(0.40m);

            // act
            var price = _shoppingBasket.CalculateTotalPrice();

            // assert
            price.Should().Be(2.55m);
        }
    }
}
