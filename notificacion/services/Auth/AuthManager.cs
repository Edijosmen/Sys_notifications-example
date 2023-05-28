using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using notificacion.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace notificacion.services.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;
        private IdentityUser _IdentityUser;
        public AuthManager(UserManager<IdentityUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<string> CreatToken()
        {
            byte[] key = Encoding.ASCII.GetBytes(_config.GetSection("Jwt:key").Value);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha512);

            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _IdentityUser.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_IdentityUser);
            foreach (var role in roles)
            {
                Claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var optionsToken = new JwtSecurityToken(
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                claims : Claims,
                expires : DateTime.UtcNow.AddHours(1),
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(optionsToken);
        }

        public async Task<string> ValidateAuthTokenAndGetUserId(string token)
        {
          
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:key").Value));
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key 
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                // Valida y deserializa el token
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;

                // Obtén el ID de usuario del token (si está presente)
                var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                // Realiza cualquier otra verificación adicional que necesites

                return userId;
            }
            catch (Exception ex)
            {
                // Maneja cualquier error de validación del token
                // Puedes lanzar una excepción personalizada, registrar el error, etc.
                throw new Exception("Token de autenticación inválido", ex);
            }
        }

        public async Task<bool> ValidateUser(UserDto auth)
        {
             _IdentityUser = await _userManager.FindByNameAsync(auth.Email);
            return (_IdentityUser != null && await _userManager.CheckPasswordAsync(_IdentityUser, auth.Password));
        }
    }
}
