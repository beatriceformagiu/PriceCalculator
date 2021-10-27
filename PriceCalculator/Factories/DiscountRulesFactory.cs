using System.Collections.Generic;
using PriceCalculator.Domain;

namespace PriceCalculator.Factories
{
    public class DiscountRulesFactory
    {
        public static List<DiscountRule> GetDiscountRules(List<Item> items)
        {
            return new List<DiscountRule>()
            {
                new DiscountRule()
                {
                    DiscountCondition = new DiscountCondition()
                    {
                        ItemId = items[0].Id,
                        Quantity = 2
                    },
                    DiscountOffer = new DiscountOffer()
                    {
                        Discount = 0.5m,
                        ItemId = items[2].Id,
                    }
                },
                new DiscountRule()
                {
                    DiscountCondition = new DiscountCondition()
                    {
                        ItemId = items[1].Id,
                        Quantity = 3
                    },
                    DiscountOffer = new DiscountOffer()
                    {
                        Discount = 1,
                        ItemId = items[1].Id,
                    }
                }
            };
        }
    }
}
