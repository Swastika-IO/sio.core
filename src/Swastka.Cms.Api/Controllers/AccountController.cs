using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swastika.Identity.Models.AccountViewModels;
using Swastika.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Swastika.Identity.Services;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swastika.IO.Cms.Lib;

namespace Swastika.IO.Core.Controllers
{
    [Route("api/{culture}/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        //private readonly IIdentityServerInteractionService _interaction;
        //private readonly AccountService _account;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            //IEmailSender emailSender,
            ILogger<AccountController> logger,            
            IHttpContextAccessor httpContextAccessor
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_emailSender = emailSender;
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "test";
        }


        //[AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> GenerateToken(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (result.Succeeded)
                    {

                        var claims = new[]
                        {
          new Claim(JwtRegisteredClaimNames.Sub, user.Email),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SWCmsConstants.AuthConfiguration.AuthTokenKey));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(SWCmsConstants.AuthConfiguration.AuthTokenIssuer,
                          SWCmsConstants.AuthConfiguration.AuthTokenIssuer,
                          claims,
                          expires: DateTime.Now.AddMinutes(30),
                          signingCredentials: creds);

                        return new JsonResult(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                    }
                }
            }
            return new JsonResult("Could not create token");
        }
    }
}