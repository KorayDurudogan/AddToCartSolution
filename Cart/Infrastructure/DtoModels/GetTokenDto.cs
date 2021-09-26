namespace Infrastructure.DtoModels
{
    internal class GetTokenDto
    {
        public string Password { get; set; }

        public GetTokenDto(string password) => Password = password;
    }
}
