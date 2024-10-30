

using Infra.Entities;
using Microsoft.AspNetCore.Identity;
using Services.Models.Auth;
using Services.Services;
using Services.Services.Auth;

namespace Services
{
    public class AuthService :IAuth
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;

        }

        public async Task<AuthResponse> Login(LoginDto model)
        {
            // Attempt to find user by username
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new AuthResponse { Token = null, UserId = null, Username = null }; // or throw an exception
            }

            // Check the password
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                //  jwt token

                // You can return a token or success message
                var token = _tokenService.CreateToken(user);
                return new AuthResponse { Token = await token, UserId = user.Id, Username = user.UserName  };
            }

            return new AuthResponse { Token = null, UserId = null, Username = null }; // or throw an exception
        }
        public async Task<string> Register(RegisterDto model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email, 
                FirstName = model.Email, 
                LastName = model.Email, 
            };

            // Attempt to create the user
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Optionally sign the user in automatically or return a success message
                await _signInManager.SignInAsync(user, isPersistent: false);
                return "Registration successful";
            }

            // In case of failure, return the errors
            return string.Join(", ", result.Errors.Select(e => e.Description));
        }

        Task<string> IAuth.Login(LoginDto model)
        {
            throw new NotImplementedException();
        }
    }
}
