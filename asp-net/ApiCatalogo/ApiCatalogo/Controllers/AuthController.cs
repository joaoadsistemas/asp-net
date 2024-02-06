using ApiCatalogo.Dtos;
using ApiCatalogo.Entities;
using ApiCatalogo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiCatalogo.Controllers
{
    [Route("/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(ITokenService tokenService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginDTO.Password!))
            {

                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };


                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = _tokenService.GenerateAccessToken(authClaims, _configuration);

                var refreshToken = _tokenService.GenerateRefreshToken();

                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"], out int refreshTokenValidityInMinutes);


                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);

                await _userManager.UpdateAsync(user);

                return Ok(new
                {
                    Token = token,
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo
                });

            }

            return Unauthorized();
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var userExists = await _userManager.FindByNameAsync(registerDTO.Username);
            if (userExists != null) 
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new ResponseDTO
                {
                    Status = "Error",
                    Message = "User already exists!"
                });
            }

            ApplicationUser user = new()
            {
                Email = registerDTO.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerDTO.Username,
            };
            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO
                {
                    Status = "Error",
                    Message = "User creation failed"
                });
            }

            return StatusCode(StatusCodes.Status201Created, new ResponseDTO
            {
                Status = "Success",
                Message = "User created successfuly!"
            });
        }


    }
}
