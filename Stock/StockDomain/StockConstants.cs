namespace Domain
{
    public struct StockConstants
    {
        public const string NoStockMessage = "No products available in stock.";
        public const string NotEnoughStockMessage = "Customer requested {0} number of products but we have only {1} number of products in our stock.";
        public const string StockFileName = "Stock.json";
        public const string StockInfoNotReceivedErrorMessage = "Stock info could not found !";
        public const string StockEventFileName = "StockEvent.json";
        public const string TokenPassword = "Jwt:TokenPassword";
        public const string TokenIssuer = "Jwt:Issuer";
        public const string TokenKey = "Jwt:Key";
        public const string TokenSigningKey = "Jwt:SigningKey";
        public const string BadRequestResponseMessage = "Please check your request.";
        public const string InternalServerErrorResponseMessage = "Something get wrong ! Please try again later.";
        public const string SeriLogMessageTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}";
        public const string LoggingFilePath = "Logs/log.txt";
    }
}
