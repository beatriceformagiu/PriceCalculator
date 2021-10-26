using System;

namespace PriceCalculator.Domain
{
    public class CartItem
    {
        public Item Item { get; }
        public int Quantity { get; }

        public CartItem(Item itemId, int quantity = 1)
        {
            Item = itemId;
            Quantity = quantity;
        }
    }
}
