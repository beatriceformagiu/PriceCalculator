using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Domain
{
    public class DiscountRule
    {
        public DiscountCondition DiscountCondition { get; set; }

        public DiscountOffer DiscountOffer { get; set; }
    }
}
