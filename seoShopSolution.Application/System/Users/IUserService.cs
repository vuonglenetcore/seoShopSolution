using seoShopSolution.ViewModel.System.Users;
using System.Threading.Tasks;

namespace seoShopSolution.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);
    }
}