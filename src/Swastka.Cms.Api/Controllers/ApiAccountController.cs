// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Swastika.Api.Controllers;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Account;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.Account;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Domain.Core.ViewModels;
using Swastika.Identity.Models;
using Swastika.Identity.Models.AccountViewModels;
using Swastika.Identity.Services;
using Swastka.Cms.Api;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using static Swastika.Common.Utility.Enums;

namespace Swastika.Core.Controllers
{
    //[Authorize(Roles = "SuperAdmin,Admin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin")]
    [Route("api/account")]
    public class ApiAccountController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public ApiAccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender,
            ILogger<ApiAccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        //
        // POST: /Account/Logout
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<RepositoryResponse<AccessTokenViewModel>> Login([FromBody] LoginViewModel model)
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
                    //var roles = await _userManager.GetRolesAsync(user);

                    var token = await GenerateAccessTokenAsync(user);
                    if (token != null)
                    {
                        var info = await InfoUserViewModel.Repository.GetSingleModelAsync(u => u.Username == user.UserName);
                        if (!info.IsSucceed)
                        {
                            info.Data = new InfoUserViewModel();
                        }
                        //info.Data.Roles = roles.ToList();
                        token.UserData = info.Data;

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

                    // Save to cms db context
                    InfoUserViewModel cmsUser = new InfoUserViewModel()
                    {
                        Id = user.Id,
                        Username = model.UserName,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        CreatedDateTime = DateTime.UtcNow
                    };
                    await cmsUser.SaveModelAsync();

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

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin")]
        [Route("user-in-role")]
        [HttpPost]
        public async Task<RepositoryResponse<bool>> ManageUserInRole(UserRoleModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var result = new RepositoryResponse<bool>();

            List<string> errors = new List<string>();

            if (role == null)
            {
                errors.Add($"Role: {model.RoleId} does not exists");
            }
            else if (model.IsUserInRole)
            {
                var appUser = await _userManager.FindByIdAsync(model.UserId);

                if (appUser == null)
                {
                    errors.Add($"User: {model.UserId} does not exists");
                }
                else if (!(await _userManager.IsInRoleAsync(appUser, role.Name)))
                {
                    var addResult = await _userManager.AddToRoleAsync(appUser, role.Name);

                    if (!addResult.Succeeded)
                    {
                        errors.Add($"User: {model.UserId} could not be added to role");
                    }
                }
            }
            else
            {
                var appUser = await _userManager.FindByIdAsync(model.UserId);

                if (appUser == null)
                {
                    errors.Add($"User: {model.UserId} does not exists");
                }

                var removeResult = await _userManager.RemoveFromRoleAsync(appUser, role.Name);
                if (!removeResult.Succeeded)
                {
                    errors.Add($"User: {model.UserId} could not be removed from role");
                }
            }
            result.IsSucceed = errors.Count == 0;
            result.Data = errors.Count == 0;
            result.Errors = errors;
            return result;
        }


        // GET api/users/id
        [HttpGet]
        [Route("details/{viewType}/{id}")]
        [Route("details/{viewType}")]
        public async Task<JObject> BEDetails(string viewType, string id = null)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var beResult = await InfoUserViewModel.Repository.GetSingleModelAsync(
                    model => model.Id == id).ConfigureAwait(false);
                beResult.Data.Specificulture = _lang;
                return JObject.FromObject(beResult);
            }
            else
            {
                var model = new SiocCmsUser() { Status = (int)SWStatus.Preview };

                RepositoryResponse<InfoUserViewModel> result = new RepositoryResponse<InfoUserViewModel>()
                {
                    IsSucceed = true,
                    Data = await InfoUserViewModel.InitAsync(model)
                };
                result.Data.Specificulture = _lang;
                return JObject.FromObject(result);
            }
        }


        // POST api/template
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<InfoUserViewModel>> Save(
            [FromBody] InfoUserViewModel model)
        {
            if (model != null)
            {
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);
                return result;
            }
            return new RepositoryResponse<InfoUserViewModel>();
        }

        // POST api/account/list
        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<RepositoryResponse<PaginationModel<InfoUserViewModel>>> GetList(RequestPaging request)
        {
            Expression<Func<SiocCmsUser, bool>> predicate = model =>
                (!request.Status.HasValue || model.Status == (int)request.Status.Value)
                && (string.IsNullOrWhiteSpace(request.Keyword)
                || (
                    model.Username.Contains(request.Keyword)
                   || model.FirstName.Contains(request.Keyword)
                   || model.LastName.Contains(request.Keyword)
                   )
                )
                && (!request.FromDate.HasValue
                    || (model.CreatedDateTime >= request.FromDate.Value.ToUniversalTime())
                )
                && (!request.ToDate.HasValue
                    || (model.CreatedDateTime <= request.ToDate.Value.ToUniversalTime())
                );

            var data = await InfoUserViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);
            if (data.IsSucceed)
            {
                data.Data.Items.ForEach(a =>
                {
                    a.DetailsUrl = SwCmsHelper.GetRouterUrl(
                        "Profile", new { a.Id }, Request, Url);
                }
                );
            }
            return data;
        }

        private async Task<AccessTokenViewModel> GenerateAccessTokenAsync(ApplicationUser user)
        {
            string refreshToken = Guid.NewGuid().ToString();
            var dtIssued = DateTime.UtcNow;
            var dtExpired = dtIssued.AddMinutes(SWCmsConstants.AuthConfiguration.AuthCookieExpiration);
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
                Access_token = await GenerateTokenAsync(user, dtExpired, refreshToken),
                Refresh_token = saveRefreshTokenResult.Data.Id,
                Token_type = SWCmsConstants.AuthConfiguration.TokenType,
                Expires_in = SWCmsConstants.AuthConfiguration.AuthCookieExpiration,
                //UserData = user,
                Issued = dtIssued,
                Expires = dtExpired,
            };
            return token;
        }

        private async Task<string> GenerateTokenAsync(ApplicationUser user, DateTime expires, string refreshToken)
        {
            List<Claim> claims = await GetClaimsAsync(user);
            claims.AddRange(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Username", user.UserName),
                    new Claim("RefreshToken", refreshToken)
                });
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: SWCmsConstants.JwtSettings.ISSUER,
                audience: SWCmsConstants.JwtSettings.AUDIENCE,
                notBefore: DateTime.UtcNow,
                claims: claims,
                // our token will live 1 hour, but you can change you token lifetime here
                expires: expires,
                signingCredentials: new SigningCredentials(JwtSecurityKey.Create(SWCmsConstants.JwtSettings.SECRET_KEY), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        protected async Task<List<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            List<Claim> claims = new List<Claim>();
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var claim in user.Claims)
            {
                claims.Add(CreateClaim(claim.ClaimType, claim.ClaimValue));
            }

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            return claims;
        }

        protected Claim CreateClaim(string type, string value)
        {
            return new Claim(type, value, ClaimValueTypes.String);
        }
    }
}