using System;
using System.Collections.Generic;
using System.Text;
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
                    Name = "Butter",
                    Price = 0.80m
                },
                new Item()
                {
                    Id = Guid.NewGuid(),
                    Name = "Milk",
                    Price = 1.15m
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
