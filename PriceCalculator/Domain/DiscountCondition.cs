using System;

namespace PriceCalculator.Domain
{
    public class DiscountCondition
    {
        public Guid ItemId { get; set; }

        public int Quantity { get; set; }
    }
}