using System;

namespace PriceCalculator.Domain
{
    public class CartItem
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }

        public CartItem(Item itemId, int quantity = 1)
        {
            Item = itemId;
            Quantity = quantity;
        }
    }
}
