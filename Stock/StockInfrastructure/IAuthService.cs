using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// Interface for creating token.
    /// </summary>
    public interface IAuthService
    {
        Task<string> CreateToken(string password);
    }
}
