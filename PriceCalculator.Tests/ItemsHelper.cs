using System;
using System.Collections.Generic;
using PriceCalculator.Domain;

namespace PriceCalculator.Tests
{
    public class ItemsHelper
    {
        public static List<Item> GetItems()
        {
            var products = new List<Item>()
            {
                new Item()
                {
                    Id = Guid.NewGuid(),
                    Name = "Butter",
                    Price = 0.80d
                },
                new Item()
                {
                    Id = Guid.NewGuid(),
                    Name = "Milk",
                    Price = 1.15
                },
                new Item()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bread",
                    Price = 1
                }
            };

            return products;
        }
    }
}
