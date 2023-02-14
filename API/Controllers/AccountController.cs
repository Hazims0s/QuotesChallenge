using API.Services;
using Application.DTOs.UserDTOs;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
                return Unauthorized("UserName Or Pssword Is Incorrect");                
            var result = await _userManager.CheckPasswordAsync(user, login.Password);
            if (result)
            {
                return new UserDTO
                {
                    Email = login.Email,
                    Token = _tokenService.CreateToken(user)
                };
            }
            return Unauthorized("UserName Or Pssword Is Incorrect");
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO register)
        {
            var user = new AppUser
            {
                Email = register.Email,
                UserName = register.Email
            };
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                return new UserDTO
                {
                    Email = register.Email,
                    Token = _tokenService.CreateToken(user)
                };
            }
            return BadRequest(result.Errors.Select(p => p.Code));
        }

    }
}