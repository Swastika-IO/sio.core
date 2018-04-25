// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swastika.Api.Controllers;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Account;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.Account;
using Swastika.Domain.Core.ViewModels;
using Swastika.Identity.Infrastructure;
using Swastika.Identity.Models;
using Swastika.Identity.Models.AccountViewModels;
using Swastika.Identity.Services;
using Swastka.Cms.Api;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Swastika.Core.Controllers
{
    [Route("api/{culture}/account")]
    public class ApiAccountController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public ApiAccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<ApiAccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        [TempData]
        public string ErrorMessage { get; set; }




        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Get")]
        [HttpGet]
        public string Get()
        {
            var t = User.Claims.FirstOrDefault(c => c.Type == "RefreshToken");
            return t?.Value;
        }

        //
        // POST: /Account/Logout
        [Authorize]
        [Route("Logout")]
        [HttpGet, HttpPost]
        public async Task<RepositoryResponse<bool>> Logout()
        {
            var result = new RepositoryResponse<bool>() { IsSucceed = true, Data = true };
            await _signInManager.SignOutAsync().ConfigureAwait(false);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).ConfigureAwait(false);
            await RefreshTokenViewModel.Repository.RemoveModelAsync(r => r.Username == User.Identity.Name);
            return result;
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<RepositoryResponse<AccessTokenViewModel>> Login(LoginViewModel model)
        {
            RepositoryResponse<AccessTokenViewModel> loginResult = new RepositoryResponse<AccessTokenViewModel>();
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false).ConfigureAwait(false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.UserName).ConfigureAwait(false);
                    var token = await GenerateAccessTokenAsync(user);
                    if (token != null)
                    {
                        loginResult.IsSucceed = true;
                        loginResult.Status = 1;
                        loginResult.Data = token;
                        _logger.LogInformation("User logged in.");
                        return loginResult;
                    }
                    else
                    {
                        return loginResult;
                    }
                }
                else
                {
                    return loginResult;
                }
               
            }
            else
            {
                return loginResult;
            }
        }

        [Route("refreshToken/{refreshTokenId}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<RepositoryResponse<AccessTokenViewModel>> RefreshToken(string refreshTokenId)
        {
            RepositoryResponse<AccessTokenViewModel> result = new RepositoryResponse<AccessTokenViewModel>();
            var getRefreshToken = await RefreshTokenViewModel.Repository.GetSingleModelAsync(t => t.Id == refreshTokenId);
            if (getRefreshToken.IsSucceed)
            {
                var oldToken = getRefreshToken.Data;
                if (oldToken.ExpiresUtc > DateTime.UtcNow)
                {
                    var user = await _userManager.FindByEmailAsync(oldToken.Email);
                    var token = await GenerateAccessTokenAsync(user);
                    if (token != null)
                    {
                        await oldToken.RemoveModelAsync();
                    }
                    result.IsSucceed = true;
                    result.Data = token;
                    return result;
                }
                else
                {
                    await oldToken.RemoveModelAsync();
                    result.Errors.Add("Token expired");
                    return result;
                }
            }
            else
            {
                result.Errors.Add("Token expired");
                return result;
            }

        }

        [Route("Register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<RepositoryResponse<AccessTokenViewModel>> Register(RegisterViewModel model)
        {
            RepositoryResponse<AccessTokenViewModel> result = new RepositoryResponse<AccessTokenViewModel>();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    JoinDate = DateTime.UtcNow
                };
                var createResult = await _userManager.CreateAsync(user, password: model.Password).ConfigureAwait(false);
                if (createResult.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    user = await _userManager.FindByEmailAsync(model.Email).ConfigureAwait(false);
                    var token = await GenerateAccessTokenAsync(user);
                    if (token != null)
                    {
                        result.IsSucceed = true;
                        result.Data = token;
                        _logger.LogInformation("User logged in.");
                        return result;
                    }
                    else
                    {
                        return result;
                    }

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    //_logger.LogInformation("User created a new account with password.");
                }
                else
                {
                    foreach (var error in createResult.Errors)
                    {
                        result.Errors.Add(error.Description);
                    }
                    return result;
                }
            }

            return result;
        }

       

        private async Task<AccessTokenViewModel> GenerateAccessTokenAsync(ApplicationUser user)
        {
            string refreshToken = Guid.NewGuid().ToString();
            var dtIssued = DateTime.UtcNow;
            var dtExpired = dtIssued.AddSeconds(SWCmsConstants.AuthConfiguration.AuthCookieExpiration);
            var dtRefreshTokenExpired = dtIssued.AddDays(SWCmsConstants.AuthConfiguration.AuthCookieExpiration);

            RefreshTokenViewModel vmRefreshToken = new RefreshTokenViewModel(
                        new RefreshTokens()
                        {
                            Id = refreshToken,
                            Email = user.Email,
                            IssuedUtc = dtIssued,
                            ClientId = SWCmsConstants.AuthConfiguration.Audience,
                            Username = user.UserName,
                            //Subject = SWCmsConstants.AuthConfiguration.Audience,
                            ExpiresUtc = dtRefreshTokenExpired
                        });

            var saveRefreshTokenResult = await vmRefreshToken.SaveModelAsync();
            AccessTokenViewModel token = new AccessTokenViewModel()
            {
                Access_token = GenerateToken(user, dtExpired, refreshToken),
                Refresh_token = saveRefreshTokenResult.Data.Id,
                Token_type = SWCmsConstants.AuthConfiguration.TokenType,
                Expires_in = SWCmsConstants.AuthConfiguration.AuthCookieExpiration,
                //UserData = user,
                Issued = dtIssued,
                Expires = dtExpired,
            };
            return token;
            //if (saveRefreshTokenResult.IsSucceed)
            //{
            //    AccessTokenViewModel token = new AccessTokenViewModel()
            //    {
            //        Access_token = GenerateToken(user, dtExpired, refreshToken),
            //        Refresh_token = vmRefreshToken.Id,
            //        Token_type = SWCmsConstants.AuthConfiguration.TokenType,
            //        Expires_in = SWCmsConstants.AuthConfiguration.AuthCookieExpiration,
            //        //UserData = user,
            //        Issued = dtIssued,
            //        Expires = dtExpired,
            //    };
            //    return token;
            //}
            //else
            //{
            //    return null;
            //}

            //var token = new JwtTokenBuilder()
            //                    .AddSecurityKey(JwtSecurityKey.Create(SWCmsConstants.JWTSettings.SECRET_KEY))
            //                    .AddSubject(user.UserName)
            //                    .AddIssuer(SWCmsConstants.JWTSettings.ISSUER)
            //                    .AddAudience(SWCmsConstants.JWTSettings.AUDIENCE)
            //                    //.AddClaim("MembershipId", "111")
            //                    .AddExpiry(SWCmsConstants.JWTSettings.EXPIRED_IN)
            //                    .Build();
            //AccessTokenViewModel access_token = new AccessTokenViewModel()
            //{
            //    Access_token = token.Value, //GenerateToken(user, dtExpired, refreshToken),
            //    //Refresh_token = vmRefreshToken.Id,
            //    Token_type = SWCmsConstants.AuthConfiguration.TokenType,
            //    Expires_in = SWCmsConstants.AuthConfiguration.AuthCookieExpiration,
            //    //UserData = user,
            //    Issued = DateTime.UtcNow,
            //    Expires = token.ValidTo
            //};
            //return access_token;
        }

        private string GenerateToken(ApplicationUser user, DateTime expires, string refreshToken)
        {
            List<Claim> claims = ExtendedClaimsProvider.GetClaims(user).ToList();
            claims.AddRange(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("RefreshToken", refreshToken)
                });
            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create(SWCmsConstants.JWTSettings.SECRET_KEY))
                                .AddSubject(user.UserName)
                                .AddIssuer(SWCmsConstants.JWTSettings.ISSUER)
                                .AddAudience(SWCmsConstants.JWTSettings.AUDIENCE)
                                .AddClaims(claims.ToDictionary(c => c.Type, c => c.Value))
                                .AddExpiry(SWCmsConstants.JWTSettings.EXPIRED_IN)
                                .Build();
            return token.Value;

            //var handler = new JwtSecurityTokenHandler();
            //List<Claim> claims = ExtendedClaimsProvider.GetClaims(user).ToList();
            //claims.AddRange(new[]
            //    {
            //        new Claim("Id", user.Id.ToString()),
            //        new Claim("RefreshToken", refreshToken)
            //    });
            //ClaimsIdentity identity = new ClaimsIdentity(
            //    new GenericIdentity(user.UserName, "TokenAuth"),
            //    claims
            //);

            //var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            //{
            //    Issuer = SWCmsConstants.AuthConfiguration.AuthTokenIssuer,
            //    Audience = SWCmsConstants.AuthConfiguration.Audience,
            //    SigningCredentials = SWCmsConstants.AuthConfiguration.SigningCredentials,
            //    Subject = identity,
            //    IssuedAt = expires.AddSeconds(-SWCmsConstants.AuthConfiguration.AuthCookieExpiration),
            //    Expires = expires
            //});
            //return handler.WriteToken(securityToken);
        }
    }
}
