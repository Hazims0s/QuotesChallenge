using UI.DTOs.UserDTOs;

namespace UI.Interfaces
{
    public interface IAccountService
    {
        Task<UserDTO> Login(string email, string password);
        Task<UserDTO> Logout(); 
        Task<UserDTO> Register(RegisterDTO register);
    }
}
