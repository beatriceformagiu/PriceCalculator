using System;

namespace PriceCalculator.Domain
{
    public class CartItem
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }

        public CartItem(Item item, int quantity = 1)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}
