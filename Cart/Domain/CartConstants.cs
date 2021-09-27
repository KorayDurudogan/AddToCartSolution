namespace Domain
{
    public struct CartConstants
    {
        public const string TokenErrorMessage = "Couldn't get token from StockAPI !";
        public const string CartItemFileName = "CartItem.json";
        public const string ApiCallErrorMessage = "An error occured while calling StockAPI. HttpResponse:{0}";
        public const string BadRequestResponseMessage = "Please check your request.";
        public const string InternalServerErrorResponseMessage = "Something get wrong ! Please try again later.";
        public const string SeriLogMessageTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}";
        public const string LoggingFilePath = "Logs/log.txt";
    }
}
