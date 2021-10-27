using System;
using System.Linq;
using PriceCalculator.Builders;
using PriceCalculator.Domain;
using PriceCalculator.Factories;

namespace PriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // ToDo: allow the user to choose which items to buy and the corresponding quantity from the console app instead of using the application arguments
                if (args == null || args.Length == 0)
                {
                    Console.WriteLine("No items found in the shopping basket");
                    return;
                }

                // ToDo: Create a repository and load all items available in a data store
                var availableItems = ItemsFactory.GetItems();

                // ToDo: Create a repository and load all the discounts' rules
                var discountRules = DiscountRulesFactory.GetDiscountRules(availableItems);

                var discountBuilder = new ShoppingBasketDiscountBuilder(discountRules);
                var shoppingBasket = new ShoppingBasket(discountBuilder);

                // ToDo: Move the logic of getting the items by item name to the domain. Create a method in shopping basket which has a list of item names as a parameter.
                // ToDo: Based on the items' name get the corresponding item and store in the cart items.
                // ToDo: Create a shopping basket handler which will contain all the steps in order to allow the user to pick up the items and put in the shopping basket
                var items = args.Select(itemName => availableItems.FirstOrDefault(i => i.Name.ToLower().Equals(itemName.ToLower())))
                    .Where(item => item != null)
                    .ToList();

                // ToDo: Create a new method which has a list of strings as a parameter( a list of items' names)
                shoppingBasket.AddItems(items);

                var price = shoppingBasket.CalculateTotalPrice();

                Console.WriteLine($"Total price: {price}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
