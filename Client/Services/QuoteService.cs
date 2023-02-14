using RestSharp;
using Client.DTOs.QuotesDTOs;
using Client.Interfaces;
using System.Threading;

namespace Client.Services
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
        public async Task AddQuote(AddQuoteDTO quote)
        {
            try
            {
                RestRequest request = new RestRequest("/Add", Method.Post);
                request.RequestFormat = DataFormat.Json;
                request.AddBody(quote);
                CancellationToken ct = new CancellationToken();
                var s = await _client.PostAsync<AddQuoteDTO>(request, ct);


            }
            catch (Exception ex)
            {
                var s = ex.ToString();

                s = s + " **Suiii**";
                throw;
            }
        }

        public async Task DeleteQuote(Guid id)
        {
            try
            {
                RestRequest request = new RestRequest("Delete/" + id.ToString(), Method.Delete);
                request.RequestFormat = DataFormat.Json;
                CancellationToken ct = new CancellationToken();
                var s = await _client.DeleteAsync(request, ct);
            }
            catch (Exception ex)
            {
                var s = ex.ToString();

                s = s + " **Suiii**";
                throw;
            }
        }

        public async Task<QuoteDTO> GetQuote(Guid id)
        {
            return await _client.GetJsonAsync<QuoteDTO>(""+id);
        }

        public async Task<List<QuoteDTO>> GetQuoteByAuther(Guid id)
        {
            return await _client.GetJsonAsync<List<QuoteDTO>>("/ByAuther/" + id);
        }

        public   async Task<List<QuoteDTO>> GetQuotes()
        {
            return await _client.GetJsonAsync<List<QuoteDTO>>("");

        }

        public async Task<QuoteDTO> GetRandomQuote()
        {
            return await _client.GetJsonAsync<QuoteDTO>("/Random");
        }

        public async Task UpdateQuote(UpdateQuoteDTO quote)
        {
            try
            {
                RestRequest request = new RestRequest("Edit/"+
                    quote.Id, Method.Put);
                request.RequestFormat = DataFormat.Json;
                request.AddBody(quote);
                CancellationToken ct = new CancellationToken();
                await _client.PutAsync<UpdateQuoteDTO>(request, ct);
            }
            catch (Exception ex)
            { 
                 
                throw;
            }
        }
    }
}
