using DevIO.Api.Controllers.Common;
using DevIO.Api.DTO;
using DevIO.Api.Extensions;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Services;
using EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IJogadorService _jogadorService;
        private readonly IEmailSender _emailSender;
        public const string ConfirmEmailTokenPurpose = "PasswordReset";



        public AuthController(INotificador notificador,
                              SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<AppSettings> appSettings,
                              IUser user,
                              IJogadorService jogadorService, IEmailSender emailSender) : base(notificador, user)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _jogadorService = jogadorService;
            _emailSender = emailSender;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Registrar(RegisterUserDto registerUserDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUserDto.Email,
                Email = registerUserDto.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, registerUserDto.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                await _jogadorService.Adicionar(new Jogador
                {
                    Celular = registerUserDto.Celular,
                    Email = registerUserDto.Email,
                    IdClash = registerUserDto.IdClash,
                    UserId = user.Id,
                    Nome = registerUserDto.Nome
                });
                return CustomResponse(await GerarJwt(user.Email));
            }
            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse(registerUserDto);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUserDto.Email, loginUserDto.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GerarJwt(loginUserDto.Email));
            }
            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse(loginUserDto);
            }

            NotificarErro("Usuário ou Senha incorretos");
            return CustomResponse(loginUserDto);
        }

        private async Task<LoginResponseDto> GerarJwt(string email)
        {

            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseDto
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                User = new UserTokenDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    JogadorId = await _jogadorService.GetById(user.Id),
                    IdClash = await _jogadorService.GetIdClashById(user.Id),
                    Claims = claims.Select(c => new ClaimDto { Type = c.Type, Value = c.Value }),
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        [HttpPost("redefinirSenha")]
        public async void Post(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null) return;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);


            var message = new Message(new string[] { forgotPasswordDto.Email }, "Redefinir senha Clash Cup", $"Alguém solicitou alteração nas suas credenciais da conta do Clash Cup. Se foi você, click no link abaixo para redefinir sua senha. https://login.clashcup.com.br/resetPassword?token={token}");
            _emailSender.SendEmail(message);
        }

        [HttpPost("updateSenha")]
        public async Task<ActionResult> UpdateSenha(UpdatePasswordDto updatePasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(updatePasswordDto.Email);
            if (user == null)
            {
                return CustomResponse("Email invalido.");
            }
           

            if (updatePasswordDto.Password == updatePasswordDto.ConfirmPassword)
            {
                var result = await _userManager.ResetPasswordAsync(user, "CfDJ8BEiIMj9vwZPg7WWZGAgRMIWEf3GGZ6xYH4wa9dnqx6kxP1N/HjP0a9dvhJDaMr8AlbtXOIHPP0hG9S9M/k+aj9wQAj2u9ZdB2jxAPtfhFOs6NCDmZ3kH2thMMEipY/S/dExBgj6ZQt6swa35dOo3b1GyF7sX23ahOfSNOWo4mC1XUIo/GMjHkkM/QqvBMF7rDj0hfRjOmJZMXr6gJHhcq3rPTCu8gz0LK8ytcP7bqal", updatePasswordDto.Password);
                if(result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return CustomResponse("Token invalido ou expirado.");
                }
            }
            else
            {
                return CustomResponse("Password divergente do Confirmar Passowrd.");
            }
        }
    }
}
