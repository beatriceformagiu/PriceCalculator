using System;
using System.Collections.Generic;
using System.Text;
using PriceCalculator.Constants;
using PriceCalculator.Domain;

namespace PriceCalculator.Factories
{
    public class ItemsFactory
    {
        public static List<Item> GetItems()
        {
            var products = new List<Item>()
            {
                new Item()
                {
                    Id = Guid.NewGuid(),
                    Name = ItemConstants.Butter,
                    Price = 0.80m
                },
                new Item()
                {
                    Id = Guid.NewGuid(),
                    Name = ItemConstants.Milk,
                    Price = 1.15m
                },
                new Item()
                {
                    Id = Guid.NewGuid(),
                    Name = ItemConstants.Bread,
                    Price = 1
                }
            };

            return products;
        }
    }
}
