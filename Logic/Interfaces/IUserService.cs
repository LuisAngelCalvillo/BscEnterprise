using Shared.DTOs;

namespace Logic.Interfaces
{
    public interface IUserService
    {
        Task<ResponseDto> InsertUser(CreateUserDto user);
    }
}
