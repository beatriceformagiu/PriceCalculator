using System.Collections.Generic;
using PriceCalculator.Domain;
using PriceCalculator.Factories;
using PriceCalculator.Interfaces;

namespace PriceCalculator.Repositories
{
   public class DiscountRuleRepository: IDiscountRuleRepository
    {
        public List<DiscountRule> GetDiscountRules(List<Item> items)
        {
            return DiscountRulesFactory.GetDiscountRules(items);
        }
    }
}
