using DataAccess.Entities;
using DataAccess.Interfaces;
using Logic.Interfaces;
using Shared.DTOs;
using Shared.Utilities;
using System.Data;

namespace Logic.Services
{
    public class UserService(IUserRepository userRepository, IDbConnection dbConnection) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<ResponseDto> InsertUser(CreateUserDto user)
        {
            ResponseDto response = new();
            _dbConnection.Open();
            using var transaction = _dbConnection.BeginTransaction();

            try
            {
                string password = UtilitiesHelper.Encode(user.Password);
                User userEntitie = new()
                {
                    Email = user.Email,
                    Name = user.Name,
                    LastName = user.LastName,
                    Password = password,
                    IdUser = 0,
                    IsActive = true,
                    RoleId = user.RoleId
                };
                response.Completed = await _userRepository.InsertAsync(userEntitie, transaction);

                if (!response.Completed)
                {
                    response.Message = "No se pudo registrar al usuario";
                    transaction.Rollback();
                    return response;
                } 

                transaction.Commit();
                response.Message = "Se registro exitosamente al usuario";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error al registrar al usuario: " + ex.Message;
                transaction.Rollback();
                return response;
            }
            finally
            {
                _dbConnection.Close();
            }
        }
    }
}
