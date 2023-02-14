using RestSharp;
using RestSharp.Authenticators;
using System.Threading;
using UI.DTOs.AutherDTOs;
using UI.Interfaces;

namespace UI.Services
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
                RestRequest request = new RestRequest("Add/", Method.Post);
                request.RequestFormat = DataFormat.Json;
                _client.Authenticator = new JwtAuthenticator("eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImhAaC5oZGEiLCJuYW1laWQiOiIyZTNmZWMxNi05MTRiLTRlZTQtYTg2Zi1mMjYzZWI0NjlkY2EiLCJuYmYiOjE2NzYyOTIwOTUsImV4cCI6MTY3NjM3ODQ5NSwiaWF0IjoxNjc2MjkyMDk1fQ.vam7MuZVH21-qAImcDFTLX5a1t9zOGuQH87zvPDemKrlCZWzmJcWgTxSfke8l7HQYLJ4vKvaZ07JpKskvs5iuQ");
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

        public async Task DeletableAuther(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AutherDTO>> GetAuthers( CancellationToken cancellationToken)
        {

            var s = await _client.GetJsonAsync<List<AutherDTO>>("", cancellationToken);
            return s; return s; 
        }

        public async Task UpdateAuther(Guid id, AutherDTO autherDTO)
        {

            try
            {
                RestRequest request = new RestRequest("Add/", Method.Post);
                request.RequestFormat = DataFormat.Json;
                _client.Authenticator = new JwtAuthenticator("eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImhAaC5oZGEiLCJuYW1laWQiOiIyZTNmZWMxNi05MTRiLTRlZTQtYTg2Zi1mMjYzZWI0NjlkY2EiLCJuYmYiOjE2NzYyOTIwOTUsImV4cCI6MTY3NjM3ODQ5NSwiaWF0IjoxNjc2MjkyMDk1fQ.vam7MuZVH21-qAImcDFTLX5a1t9zOGuQH87zvPDemKrlCZWzmJcWgTxSfke8l7HQYLJ4vKvaZ07JpKskvs5iuQ");
                request.AddBody(autherDTO);
                CancellationToken ct = new CancellationToken();
                var s = await _client.PostAsync<AddAutherDTO>(request, ct);
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
