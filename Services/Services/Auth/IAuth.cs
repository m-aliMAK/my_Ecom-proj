using Services.Models.Auth;

namespace Services.Services.Auth
{
    public interface IAuth
    {
        Task<string> Login(LoginDto model);
        Task<string> Register(RegisterDto model);
    }
}
