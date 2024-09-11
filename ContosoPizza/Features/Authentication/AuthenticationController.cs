using ContosoPizza.Models;
using ContosoPizza.Models.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shared.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ContosoPizza.Features.Authentication
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        
        public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterFormRequest request)
        {
            var newUser = new User { UserName = request.UserName, Email = request.UserEmail };
            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded)  
            {
                return BadRequest();
            }
            var user = await _userManager.FindByNameAsync(request.UserName);

            //generate jwt token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: GetEnvVar.GetEnvString("ISSUER"),
                audience: GetEnvVar.GetEnvString("AUDIENCE"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GetEnvVar.GetEnvString("JWT_SECRET"))), SecurityAlgorithms.HmacSha256)
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginFormRequest request)
        {
            var login = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (!login.Succeeded)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByNameAsync(request.UserName);
            if(user == null)
            {
                return BadRequest();
            }
            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var token = new JwtSecurityToken(
                issuer: GetEnvVar.GetEnvString("ISSUER"),
                audience: GetEnvVar.GetEnvString("AUDIENCE"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GetEnvVar.GetEnvString("JWT_SECRET"))),
                                                           SecurityAlgorithms.HmacSha256)
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                userName = user.UserName
            });


        }
    }
    
}
