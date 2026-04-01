using EsemkaVote.API.Data;
using EsemkaVote.API.Model;
using EsemkaVote.API.Model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EsemkaVote.API.Repository
{
    public class AuthService(EsemkaVoteAPIDataContext db, IConfiguration configuration) : IAuthService
    {
        public async Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var user = await db.Employees.FirstOrDefaultAsync(u => u.email == loginRequestDTO.email && u.password == loginRequestDTO.password);

            if (user == null)
            {
                return null;
            }

            return new LoginResponseDTO
            {
                token = CreateToken(user),
            };
        }

        private string CreateToken(Employee employee)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, employee.id.ToString()),
                new Claim(ClaimTypes.Name, employee.name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Key")!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.Sha256);

            var tokenDescriptor = new JwtSecurityToken(
                    issuer: configuration.GetValue<string>("Jwt:Issuer"),
                    audience: configuration.GetValue<string>("Jwt:Audience"),
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }

}
