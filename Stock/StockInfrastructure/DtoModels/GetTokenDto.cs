namespace Infrastructure.DtoModels
{
    public class GetTokenDto
    {
        public string Password { get; set; }

        public GetTokenDto(string password) => Password = password;
    }
}
