using seoShopSolution.ViewModel.System.Users;
using System.Threading.Tasks;

namespace seoShopSolution.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}