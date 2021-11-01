using System;
using System.Collections.Generic;
using System.Linq;
using PriceCalculator.Domain;
using PriceCalculator.Interfaces;

namespace PriceCalculator.Builders
{
    public class ShoppingBasketDiscountBuilder: IShoppingBasketDiscountBuilder
    {
        private readonly List<DiscountRule> _discountRules;

        public ShoppingBasketDiscountBuilder(List<DiscountRule> discountRules)
        {
            _discountRules = discountRules;
        }

        public decimal GetTotalDiscount(List<CartItem> cartItems)
        {
            var discountOffers = GetDiscountOffers(cartItems);

            var discount = CalculateDiscount(discountOffers, cartItems);

            return discount;
        }

        private List<DiscountOffer> GetDiscountOffers(List<CartItem> cartItems)
        {
            var discountOffers = new List<DiscountOffer>();
            foreach (var cartItem in cartItems)
            {
                AddDiscountOffers(cartItem, discountOffers);
            }

            return discountOffers;
        }

        private void AddDiscountOffers(CartItem cartItem, List<DiscountOffer> discountOffers)
        {
            foreach (var discountRule in _discountRules)
            {
                if (!discountRule.DiscountCondition.ItemId.Equals(cartItem.Item.Id))
                {
                    continue;
                }

                var offers = Convert.ToInt32(cartItem.Quantity / discountRule.DiscountCondition.Quantity);

                while (offers > 0)
                {
                    discountOffers.Add(discountRule.DiscountOffer);
                    offers--;
                }
            }
        }

        private decimal CalculateDiscount(List<DiscountOffer> discountOffers, List<CartItem> cartItems)
        {
            var discount = 0m;
            foreach (var cartItem in cartItems)
            {
                var discountOffersForItem = discountOffers.FindAll(d => d.ItemId == cartItem.Item.Id);
                var discountedItems = 0;
                discountedItems = discountOffersForItem.Count > cartItem.Quantity
                    ? cartItem.Quantity
                    : discountOffersForItem.Count;

                if (discountOffersForItem.Any())
                {
                    discount += discountedItems * cartItem.Item.Price * discountOffersForItem.First().Discount;
                }
            }

            return discount;
        }
    }
}
