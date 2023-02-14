using RestSharp;
using RestSharp.Authenticators;
using System.Threading;
using Client.DTOs.AutherDTOs;
using Client.Interfaces;

namespace Client.Services
{
    public class AutherService : IAutherService
    {
        readonly RestClient _client;


        public AutherService()
        {
            _client= new RestClient("http://localhost:5000/api/Authres").            
                AddDefaultHeader(KnownHeaders.Accept, "application/json");
            ;
        }
        public async Task AddAuther(AddAutherDTO autherDTO)
        {
            try
            {
                RestRequest request = new RestRequest("/Add", Method.Post);
                request.RequestFormat = DataFormat.Json;
                request.AddBody(autherDTO);
                CancellationToken ct = new CancellationToken();
                var s = await _client.PostAsync<AddAutherDTO>(request, ct);


            }
            catch (Exception ex)
            {
                var s  = ex.ToString();

                s =s+ " **Suiii**"; 
                throw;
            }
        }

        public async Task DeleteAuther(Guid id)
        {
            try
            {
                RestRequest request = new RestRequest("Delete/"+id.ToString(), Method.Delete);
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

        public async Task<AutherDTO> GetAuther(Guid id)
        {
            return await _client.GetJsonAsync<AutherDTO>("/" + id);

        }

        public async Task<List<AutherDTO>> GetAuthers( CancellationToken cancellationToken)
        {

             return await _client.GetJsonAsync<List<AutherDTO>>("", cancellationToken);
              
        }

        public async Task UpdateAuther(Guid id, AutherDTO autherDTO)
        {

            try
            {
                RestRequest request = new RestRequest("Edit/", Method.Post);
                request.RequestFormat = DataFormat.Json;
                 request.AddBody(autherDTO);
                CancellationToken ct = new CancellationToken();
                var s = await _client.PutAsync<AutherDTO>(request, ct);
            }
            catch (Exception ex)
            {
                var s = ex.ToString();

                s = s + " **Suiii**";
                throw;
            }
        }
    }
}
