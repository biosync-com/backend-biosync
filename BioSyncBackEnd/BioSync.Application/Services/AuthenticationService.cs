using BioSync.Application.Interfaces;
using BioSync.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BioSync.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IColetorRepository _coletorRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationService(
            IUsuarioRepository usuarioRepository,
            IColetorRepository coletorRepository,
            IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _coletorRepository = coletorRepository;
            _configuration = configuration;
        }

        public async Task<string> Authenticate(string email, string senha)
        {
           
            var usuario = await _usuarioRepository.GetByEmailAsync(email);

            if (usuario != null && usuario.Senha == senha)
            {
                return GenerateToken(usuario.Id, usuario.Email, "Usuario");
            }

            
            var coletor = await _coletorRepository.GetByEmailAsync(email);

            if (coletor != null && coletor.Senha == senha)
            {
                return GenerateToken(coletor.Id, coletor.Email, "Coletor");
            }

            
            throw new Exception("Email ou senha inválidos.");
        }

        private string GenerateToken(int id, string email, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
