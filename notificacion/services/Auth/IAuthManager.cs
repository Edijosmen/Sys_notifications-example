using notificacion.Models;

namespace notificacion.services.Auth
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserDto auth);
        Task<string> CreatToken();
        Task<string> ValidateAuthTokenAndGetUserId(string token);
    }
}
