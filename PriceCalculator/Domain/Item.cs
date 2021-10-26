using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Domain
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
