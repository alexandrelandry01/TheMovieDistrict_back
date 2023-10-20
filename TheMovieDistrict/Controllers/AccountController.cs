using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheMovieDistrict.Entities;
using TheMovieDistrict.Models;
using TheMovieDistrict.Service;

namespace TheMovieDistrict.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager ??
                throw new ArgumentNullException(nameof(userManager));
            _tokenService = tokenService ??
                throw new ArgumentNullException(nameof(tokenService));
        }

        /*
         * Nobody else shall register! Hahahahihihiheheheh!
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>>? Register([FromBody] RegisterDto RegisterDto)
        {
            if (await UserAlreadyExists(RegisterDto.UserName))
            {
                return BadRequest("Username is taken");
            }

            var account = new AppUser
            {
                UserName = RegisterDto.UserName
            };

            var result = await _userManager.CreateAsync(account, RegisterDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var roleResult = await _userManager.AddToRoleAsync(account, "user");

            if (!roleResult.Succeeded)
            {
                return BadRequest(roleResult.Errors);
            }

            return new UserDto
            {
                UserName = account.UserName,
                Token = await _tokenService.CreateToken(account)
            };
        }
        */

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>>? Login([FromBody] LoginDto LoginDto)
        {
            var account = await _userManager.Users.SingleOrDefaultAsync(a => a.UserName == LoginDto.UserName);

            if (account == null)
            {
                return Unauthorized("Invalid username");
            }

            if (_userManager.SupportsUserLockout && await _userManager.IsLockedOutAsync(account))
            {
                return Forbid();
            }

            if (await _userManager.CheckPasswordAsync(account, LoginDto.Password))
            {
                if (_userManager.SupportsUserLockout && await _userManager.GetAccessFailedCountAsync(account) > 0)
                {
                    await _userManager.ResetAccessFailedCountAsync(account);
                }
                return new UserDto
                {
                    UserName = account.UserName,
                    Token = await _tokenService.CreateToken(account),
                    IsAdmin = await IsAdmin(account)
                };
            } else
            {
                if (_userManager.SupportsUserLockout && await _userManager.GetLockoutEnabledAsync(account))
                {
                    await _userManager.AccessFailedAsync(account);
                }
                return Unauthorized("Invalid credentials");
            }
        }

        private async Task<bool> UserAlreadyExists(string username)
        {
            return await _userManager.Users.AnyAsync(a => a.UserName == username.ToLower());
        }

        private async Task<bool> IsAdmin(AppUser User)
        {
            IList<string> roles = await _userManager.GetRolesAsync(User);
            return roles.Contains("Admin");
        }
    }
}
