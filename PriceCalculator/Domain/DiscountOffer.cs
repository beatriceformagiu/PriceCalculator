using System;

namespace PriceCalculator.Domain
{
    public class DiscountOffer
    {
        public Guid ItemId { get; set; }

        public decimal Discount { get; set; }
    }
}