using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using PriceCalculator.Builders;
using PriceCalculator.Constants;
using PriceCalculator.Domain;
using PriceCalculator.Interfaces;
using PriceCalculator.Repositories;

namespace PriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = null;
            try
            {
                serviceProvider = GetServiceProvider();

                var itemRepository = serviceProvider.GetService<IItemRepository>();
                var availableItems = itemRepository?.GetItems();

                var discountRuleRepository = serviceProvider.GetService<IDiscountRuleRepository>();
                var discountRules = discountRuleRepository?.GetDiscountRules(availableItems);

                var discountBuilder = new ShoppingBasketDiscountBuilder(discountRules);
                var shoppingBasket = new ShoppingBasket(discountBuilder);

                ShowMenu(availableItems, shoppingBasket);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                DisposeServices(serviceProvider);
            }
        }

        private static ServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<IDiscountRuleRepository, DiscountRuleRepository>()
                .AddSingleton<IItemRepository, ItemsRepository>()
                .AddSingleton<IShoppingBasketDiscountBuilder, ShoppingBasketDiscountBuilder>()
                .BuildServiceProvider();
        }

        private static void ShowMenu(List<Item> availableItems, ShoppingBasket shoppingBasket)
        {
            var showMenu = true;
            do
            {
                DisplayMainMenuOptions();
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("--------------------------------");
                        DisplayAvailableItems();
                        AddItemToBasket(availableItems, shoppingBasket);
                        Console.WriteLine("--------------------------------");
                        break;
                    case "2":
                        Console.WriteLine("--------------------------------");
                        var price = shoppingBasket.CalculateTotalPrice();
                        Console.WriteLine("--------------------------------");
                        break;
                    case "3":
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("Option not found. Please choose an available option");
                        Console.WriteLine("--------------------------------");
                        break;
                }
            } while (showMenu);
        }

        private static void DisplayMainMenuOptions()
        {
            Console.WriteLine("Price Calculator Shopping Basket");
            Console.WriteLine("Option   Description");
            Console.WriteLine("1        Add product in the basket");
            Console.WriteLine("2        Calculate shopping basket total cost");
            Console.WriteLine("3        Exit");
            Console.Write("Please choose an option: ");

        }

        private static void DisplayAvailableItems()
        {
            Console.WriteLine("Available items:");
            Console.WriteLine("Option   Item          Cost");
            Console.WriteLine("a        Butter           £0.80");
            Console.WriteLine("b        Milk             £1.15");
            Console.WriteLine("c        Bread            £1.00");
        }

        private static void AddItemToBasket(List<Item> availableItems, ShoppingBasket shoppingBasket)
        {
            var productExists = false;
            while (productExists == false)
            {
                var item = SelectItem(availableItems);

                if (item != null)
                {
                    productExists = true;
                    var quantity = SelectQuantity();

                    shoppingBasket.AddItem(item, quantity);
                    Console.WriteLine("Item added to your basket!");
                }
            }
        }

        private static Item SelectItem(List<Item> availableItems)
        {
            Item item = null;
            var product = CaptureInput("Please choose an item:");
            switch (product)
            {
                case "a":
                    item = availableItems?.FirstOrDefault(i => i.Name.ToLower().Equals(ItemConstants.Butter.ToLower()));
                    break;
                case "b":
                    item = availableItems?.FirstOrDefault(i => i.Name.ToLower().Equals(ItemConstants.Milk.ToLower()));
                    break;
                case "c":
                    item = availableItems?.FirstOrDefault(i => i.Name.ToLower().Equals(ItemConstants.Bread.ToLower()));
                    break;
                default:
                    Console.WriteLine("Item not found.");
                    break;
            }

            return item;
        }

        private static int SelectQuantity()
        {
            var isQuantityValid = false;
            var quantity = 1;

            while (isQuantityValid == false)
            {
                var quantityStr = CaptureInput("Please type a valid quantity:");
                if (Int32.TryParse(quantityStr, out quantity) && quantity > 0)
                {
                    isQuantityValid = true;
                }
            }

            return quantity;
        }
        

        private static string CaptureInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        
        private static void DisposeServices(ServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }
    }
}
