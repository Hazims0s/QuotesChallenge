using UI.DTOs.QuotesDTOs;

namespace UI.Interfaces
{
    public interface IQuoteService
    {
        Task<List<QuoteDTO>> GetQuotes(Guid? autherId);
        Task<QuoteDTO> GetQuoteByAuther(Guid id);
        Task<QuoteDTO> GetRandomQuote();
        Task UpdateQuot(UpdateQuoteDTO quote);
        Task DeleteQuote(Guid guid);
        Task AddQuote(AddQuoteDTO quote);
    }
}
