using LibraryManagementSystem.API.DTOs;

namespace LibraryManagementSystem.API.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(RegisterDto registerDto);
        string Login(LoginDto loginDto);
    }
}
