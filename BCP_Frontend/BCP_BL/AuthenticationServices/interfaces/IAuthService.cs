using BCP_BL.Models;
using BCP_BL.Shared;

namespace BCP_BL.AuthenticationServices.interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<string>> LoginAsync(LoginUserRequest loginUserRequest);
    }
}
