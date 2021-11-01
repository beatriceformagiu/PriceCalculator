using System.Collections.Generic;
using PriceCalculator.Domain;
using PriceCalculator.Factories;
using PriceCalculator.Interfaces;

namespace PriceCalculator.Repositories
{
    public class ItemsRepository: IItemRepository
    {
        // To fetch the items from database
        public List<Item> GetItems()
        {
            return ItemsFactory.GetItems();
        }
    }
}
