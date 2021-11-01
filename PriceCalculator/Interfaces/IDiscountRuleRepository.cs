using System.Collections.Generic;
using PriceCalculator.Domain;

namespace PriceCalculator.Interfaces
{
   public interface IDiscountRuleRepository
   {
       List<DiscountRule> GetDiscountRules(List<Item> items);
   }
}
