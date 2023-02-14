using RestSharp;
using UI.DTOs.QuotesDTOs;
using UI.Interfaces;

namespace UI.Services
{
    public class QuoteService : IQuoteService
    {

        readonly RestClient _client;


        public QuoteService()
        {
            _client = new RestClient("http://localhost:5000/api/Quotes").
                AddDefaultHeader(KnownHeaders.Accept, "application/json");
            ;
        }
        public Task AddQuote(AddQuoteDTO quote)
        {
            throw new NotImplementedException();
        }

        public Task DeleteQuote(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<QuoteDTO> GetQuoteByAuther(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<QuoteDTO>> GetQuotes(Guid? autherId)
        {
            throw new NotImplementedException();
        }

        public Task<QuoteDTO> GetRandomQuote()
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuot(UpdateQuoteDTO quote)
        {
            throw new NotImplementedException();
        }
    }
}
