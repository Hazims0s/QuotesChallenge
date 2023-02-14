using Client.DTOs.QuotesDTOs;

namespace Client.Interfaces
{
    public interface IQuoteService
    {
        Task<List<QuoteDTO>> GetQuotes();
        Task<List<QuoteDTO>> GetQuoteByAuther(Guid id);
        Task<QuoteDTO> GetQuote(Guid id);
        Task<QuoteDTO> GetRandomQuote();
        Task UpdateQuote(UpdateQuoteDTO quote);
        Task DeleteQuote(Guid id);
        Task AddQuote(AddQuoteDTO quote);
    }
}
