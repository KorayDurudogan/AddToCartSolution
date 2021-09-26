using System;

namespace Infrastructure.Models
{
    /// <summary>
    /// Data access object for CartItem.json.
    /// </summary>
    public class CartDao
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int CustomerId { get; set; }
        public DateTime AddToCartDate { get; set; }
    }
}
