using Shared.DTOs;

namespace Logic.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(UserLoginDto user, List<string> permissions);
        Task<ResponseDataDto<string>> LoginAsync(string email, string password);
    }
}
