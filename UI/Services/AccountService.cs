using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Security.Claims;
using UI.DTOs.UserDTOs;
using UI.Interfaces;
using UI.Models;
using UI.Services.Base;

namespace UI.Services
{
    public class AccountService : IAccountService
    {
        private SignInManager<UserDTO>  signInManager;

        readonly RestClient _client;
        private readonly ILocalStorageService _localStorage;

        public AccountService(ILocalStorageService localStorage)
        {
            _client = new RestClient("http://localhost:5000/api/Account").
                AddDefaultHeader(KnownHeaders.Accept, "application/json");
            ;
            _localStorage = localStorage;
        }
        public async Task<UserDTO> Login(string email, string password)
        {

            try
            {
                RestRequest request = new RestRequest("login/", Method.Post);
                request.RequestFormat = DataFormat.Json;
                request.AddBody(new LoginDTO { Email = email , Password = password });
                CancellationToken ct = new CancellationToken();
                var user = await _client.PostAsync<UserDTO>(request, ct);
                if(user != null)
                {
                    _localStorage.SetStorageValue(user.Email, user.Token);
                    ClaimsIdentity identity = new ClaimsIdentity(claims, AuthenticationType);




                    /*var identity = new Claim ("token", user.Token);   
                    var claimUser = new User { Id = "1", UserName = "SSS", Email = user.Email, Token = user.Token ,Id };
                    IdentityUser  identityUser = new IdentityUser(user.Token ); 
                    var result = await UserManager<User>.AddClaimAsync(claimUser, identity);*/
                    return user;
                }

           
                
            }
            catch (Exception ex)
            {
                var s = ex.ToString();

                s = s + " **Suiii**";
                throw;
            }
            return null;
        }

        public Task<UserDTO> Logout()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Register(RegisterDTO register)
        {
            throw new NotImplementedException();
        }
    }
}
