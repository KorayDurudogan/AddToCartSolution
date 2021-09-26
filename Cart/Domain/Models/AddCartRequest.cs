namespace Domain.Models
{
    public class AddCartRequest
    {
        public int ProductId { get; set; }
     
        public int Amount { get; set; }
      
        public int CustomerId { get; set; }
    }
}
