using EsemkaVote.API.Model.DTO;

namespace EsemkaVote.API.Repository
{
    public interface IAuthService
    {
        Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO loginRequestDTO);
        Task<EmployeeDTO?> GetMeAsync(int id);
    }
}
