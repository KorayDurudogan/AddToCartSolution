using System;

namespace Infrastructure.DaoModels
{
    public class StockEventDao
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StockChange { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
    }
}
