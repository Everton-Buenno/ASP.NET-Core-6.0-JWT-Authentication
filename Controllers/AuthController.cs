using ASP.NET_Core_6._0_JWT_Authentication.Entities;
using ASP.NET_Core_6._0_JWT_Authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASP.NET_Core_6._0_JWT_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }



        [HttpPost]
        [Route("Entrar")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var token = GetToken();

                return Ok(new
                {
                    Message = "Login realizado com sucesso!",
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expire = token.ValidTo
                });
            }

            return BadRequest(new { Message = "Usuário ou senha incorretos." });
        }

        [HttpPost]
        [Route("novo-usuario")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto register)
        {
            if (string.IsNullOrWhiteSpace(register.Name) || string.IsNullOrWhiteSpace(register.Password))
            {
                return BadRequest(new { Message = "Nome e senha são obrigatórios." });
            }




            if (!IsValidEmail(register.Email))
            {
                return BadRequest(new { Message = "Email inválido." });
            }


            var existUser = await _userManager.FindByNameAsync(register.Email);
            if (existUser != null)
            {
                return BadRequest(new { Message = "Usuário já registrado." });
            }

            var user = new ApplicationUser
            {
                UserName = register.Email,
                Email = register.Email,
                Name = register.Name,
                LastName = register.LastName,
                Age = register.Age,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Usuário criado com sucesso!" });
            }
            else
            {
                return BadRequest(new { Message = "Erro ao criar usuário.", Errors = result.Errors });
            }
        }





        private JwtSecurityToken GetToken()
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));



            var token = new JwtSecurityToken(


                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddMinutes(5),

                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );


            return token;
        }




        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }


}
