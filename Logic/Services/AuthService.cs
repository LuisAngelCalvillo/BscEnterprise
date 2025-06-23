using DataAccess.Interfaces;
using Logic.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.Dictionaries;
using Shared.DTOs;
using Shared.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Logic.Services
{
    public class AuthService
        (IUserRepository userRepository, IConfiguration configuration) : IAuthService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IConfiguration _configuration = configuration;

        public async Task<ResponseDataDto<string>> LoginAsync(string email, string password)
        {
            ResponseDataDto<string> response = new();
            UserLoginDto user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                response.Data = null;
                response.Message = "El usuario no fue encontrado.";
                response.Completed = false;
                return response;
            }


            if (!UtilitiesHelper.VerifyPassword(user.Password, password)) 
            {
                response.Data = null;
                response.Message = $"La contraseña fue incorrecta para el usuario con correo: {user.Email}.";
                response.Completed = true;
                return response;
            }

            List<string> permissions = await _userRepository.GetPermissionsByUserIdAsync(user.IdUser);
            if (permissions == null || permissions.Count == 0)
            {
                response.Data = null;
                response.Message = "El usuario no tiene permisos asignados.";
                response.Completed = true;
                return response;
            }

            string token = GenerateJwtToken(user, permissions);
            response.Data = token;
            response.Message = "Se inicio sesion exitosamente.";
            response.Completed = true;
 
            return response;
        }

        public string GenerateJwtToken(UserLoginDto user, List<string> permissions)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                new(ClaimTypes.Name, user.Email),
                new(ClaimTypes.Role, user.RoleName)
            };

            foreach (var perm in permissions)
            {
                claims.Add(new Claim("Permission", perm));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(double.Parse(_configuration["Jwt:ExpirationTime"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
