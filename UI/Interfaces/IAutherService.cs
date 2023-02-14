using UI.DTOs.AutherDTOs;

namespace UI.Interfaces
{
    public interface IAutherService
    {
        Task<List<AutherDTO>> GetAuthers(CancellationToken cancellationToken);
        Task AddAuther(AddAutherDTO autherDTO);
        Task DeletableAuther(Guid id); 
        Task UpdateAuther(Guid id, AutherDTO autherDTO);
    }
}
