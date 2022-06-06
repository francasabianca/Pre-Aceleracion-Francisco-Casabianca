using AppDisney.Models;
using AppDisney.Services;
using AppDisney.ViewModels.Auth;
using AppDisney.ViewModels.Auth.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppDisney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailService _emailservice;

        public AuthenticationController(UserManager<User> userManager,
                                        SignInManager<User> signInManager,
                                        IEmailService EmailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailservice = EmailService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequestVM model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);

            if (userExists != null)
            {
                return BadRequest("User already exists");
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "User could not be created"
                });
            }

            await _emailservice.SendEmailAsync(model.Email);

            return Ok(new
            {
                Message = "User created with success"
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestVM model)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user.IsActive)
                {
                    var token = GetToken(user);

                    return Ok(await GetToken(user));
                }
            }

            return StatusCode(StatusCodes.Status401Unauthorized, new
            {
                Message = "User not autorizhed"
            });
        }

        private async Task<LoginResponseVM> GetToken(User currentUser)
        {
            var userRoles = await _userManager.GetRolesAsync(currentUser);

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, currentUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            authClaims.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AcaVaLaKeySecreta"));

            var token = new JwtSecurityToken(
                        issuer: "https://localhost:44323/",
                        audience: "https://localhost:44323/",
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: new SigningCredentials(
                            authSigningKey, SecurityAlgorithms.HmacSha256));

            return new LoginResponseVM
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ValidTo = token.ValidTo
            };


        }
    }
}
