using System;

namespace PriceCalculator.Domain
{
    public class CartItem
    {
        public Guid ItemId { get; }
        public int Quantity { get; }

        public CartItem(Guid itemId, int quantity = 1)
        {
            ItemId = itemId;
            Quantity = quantity;
        }
    }
}
