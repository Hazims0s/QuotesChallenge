using Client.DTOs.UserDTOs;

namespace Client.Interfaces
{
    public interface IAccountService
    {
        Task<UserDTO> Login(string email, string password);
        Task<UserDTO> Logout(); 
        Task<UserDTO> Register(RegisterDTO register);
    }
}
