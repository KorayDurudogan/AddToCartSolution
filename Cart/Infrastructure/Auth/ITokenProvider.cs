using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Providing JWT token for calling APIs.
    /// </summary>
    public interface ITokenProvider
    {
        Task<string> GetToken();
    }
}
