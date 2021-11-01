using System.Collections.Generic;
using PriceCalculator.Domain;

namespace PriceCalculator.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetItems();
    }
}
