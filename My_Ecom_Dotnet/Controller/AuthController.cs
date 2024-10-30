
using Azure.Core;
using Infra.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models.Auth;
using Services.Services;
using Services.Services.Auth;



namespace AngularEcommerceApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _auth;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenService _tokenService;
        public AuthController(IAuth auth, UserManager<ApplicationUser> userManager, TokenService tokenService)
        {
            _auth = auth;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto model)
        {
            //var result = await _auth.Login(model);
            //return Ok(result);

            // Assume _userService.FindByEmailAsync is already implemented
            ApplicationUser? user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            //var result = AuthService.VerifyHashedPassword(user, user.Password, request.Password + user.Salt);

            //if (result != PasswordVerificationResult.Success)
            //{
            //    return Unauthorized("Invalid credentials");
            //}

            // Generate JWT token using the token service
            var token = _tokenService.CreateToken(user);

            // Return the token
            return Ok(new AuthResponse { Token = await token });
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto model)
        {
            try
            {

                var result = await _auth.Register(model);

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
                return Ok();
            }
        }
    }
}



