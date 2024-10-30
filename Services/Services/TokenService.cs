

using Infra.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Infra.Entities.ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        // Inject IConfiguration to access JWT settings from appsettings.json
        public TokenService(IConfiguration configuration, UserManager<ApplicationUser> userManager,
             RoleManager<IdentityRole> roleManager )
        {
            _configuration = configuration; 
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> CreateToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            // Ensure roles are fetched correctly
            var roles = await _userManager.GetRolesAsync(user);  // Get the roles from Identity

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName)
    };

            // Add roles to claims if available
            if (roles != null && roles.Any())
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        






        // Method to create and return JWT token
        //public string CreateToken(IdentityUser user)
        //{
        //    try
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

        //        //Define Token claims
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //            {
        //            new Claim(ClaimTypes.NameIdentifier, user.Id),
        //            new Claim(ClaimTypes.Role, "User")
        //                // Add more claims as necessary
        //            }),
        //            Expires = DateTime.UtcNow.AddHours(1), // Set token expiration time
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

        //            Issuer = _configuration["Jwt:Issuer"], // Get issuer from appsettings
        //            Audience = _configuration["Jwt:Audience"], // Get audience from appsettings


        //        };

        //        var token = tokenHandler.CreateToken(tokenDescriptor);
        //        return tokenHandler.WriteToken(token); // Return the generated JWT
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
    } 
}
