using System;

namespace ShoppingCarts.StorageRoom.Data.Entities
{
    public class CartItem : EntityBase
    {
        public string CartId { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
