using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zappor.Application.DTO;
using Zappor.Domain.Entities;
using Zappor.Infrastructure.Persistence;

namespace Zappor.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ZapporDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<User> _passwordHash;

        public AuthenticationService(ZapporDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _passwordHash = new PasswordHasher<User>();
        }

        public async Task<string?> LoginAsync(AuthenticationDTO authenticationDTO)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == authenticationDTO.Email);
            if (user == null)
                return null;

            var result = _passwordHash.VerifyHashedPassword(user, user.PassWordHash, authenticationDTO.Password);
            if (result == PasswordVerificationResult.Failed)
                return null;

            return GenerateToken(user);
        }

        public async Task<string> RegisterAsync(AuthenticationDTO authenticationDTO)
        {
            if (await _context.Users.AnyAsync(u => u.Email == authenticationDTO.Email))
            {
                throw new InvalidOperationException("User with this email already exists.");
            }

            var user = new User
            {
                Name = authenticationDTO.Name,
                Email = authenticationDTO.Email,
                PassWordHash = _passwordHash.HashPassword(null, authenticationDTO.Password)
            };

            user.PassWordHash = _passwordHash.HashPassword(user, authenticationDTO.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
      {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
