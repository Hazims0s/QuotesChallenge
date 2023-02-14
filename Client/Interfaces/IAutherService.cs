using Client.DTOs.AutherDTOs;

namespace Client.Interfaces
{
    public interface IAutherService
    {
        Task<List<AutherDTO>> GetAuthers(CancellationToken cancellationToken);
        Task<AutherDTO> GetAuther(Guid id);
        Task AddAuther(AddAutherDTO autherDTO);
        Task DeleteAuther(Guid id); 
        Task UpdateAuther(Guid id, AutherDTO autherDTO);
    }
}
