using EsemkaVote.API.Data;
using EsemkaVote.API.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace EsemkaVote.API.Repository
{
    public class AuthService(EsemkaVoteAPIDataContext db) : IAuthService
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
                id = user.id,
                name = user.name,
                email = user.email,
                division = user.division
            };
        }
    }
}
