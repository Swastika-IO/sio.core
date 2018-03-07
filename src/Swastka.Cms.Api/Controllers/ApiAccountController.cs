// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

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
                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
                //}
                //if (result.IsLockedOut)
                //{
                //    _logger.LogWarning("User account locked out.");
                //    return RedirectToAction(nameof(Lockout));
                //}
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //    return View(model);
                //}
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
                if (oldToken.ExpiresUtc < DateTime.UtcNow)
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
                    return result;
                }
            }
            else
            {
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

        //[Route("logOut/{refreshTokenId}")]
        //[HttpGet]
        //public async Task<RepositoryResponse<bool>> Logout(string refreshTokenId)
        //{
        //    var result = await RefreshTokenViewModel.Repository.RemoveListModelAsync(t => t.Id == refreshTokenId);
        //    return result;
        //}

        //[Route("logOutOther/{refreshTokenId}")]
        //[HttpGet]
        //public async Task<RepositoryResponse<bool>> LogoutOther(string refreshTokenId)
        //{
        //    return await RefreshTokenViewModel.LogoutOther(refreshTokenId);
        //}
        /*
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWith2fa(bool rememberMe, string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            var model = new LoginWith2faViewModel { RememberMe = rememberMe };
            ViewData["ReturnUrl"] = returnUrl;

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWith2fa(LoginWith2faViewModel model, bool rememberMe, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var authenticatorCode = model.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

            var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, rememberMe, model.RememberMachine);

            if (result.Succeeded)
            {
                _logger.LogInformation("User with ID {UserId} logged in with 2fa.", user.Id);
                return RedirectToLocal(returnUrl);
            }
            else if (result.IsLockedOut)
            {
                _logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
                return RedirectToAction(nameof(Login));
            }
            else
            {
                _logger.LogWarning("Invalid authenticator code entered for user with ID {UserId}.", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithRecoveryCode(string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithRecoveryCode(LoginWithRecoveryCodeViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            var recoveryCode = model.RecoveryCode.Replace(" ", string.Empty);

            var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

            if (result.Succeeded)
            {
                _logger.LogInformation("User with ID {UserId} logged in with a recovery code.", user.Id);
                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
                return RedirectToAction(nameof(Login));
            }
            else
            {
                _logger.LogWarning("Invalid recovery code entered for user with ID {UserId}", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid recovery code entered.");
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToAction(nameof(Login));
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in with {Name} provider.", info.LoginProvider);
                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToAction(nameof(Login)); // LogOut
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    throw new ApplicationException("Error loading external login information during confirmation.");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(nameof(ExternalLogin), model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = "";
                await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                   $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }
            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            AddErrors(result);
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion Helpers

        //[AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> GenerateToken([FromBody] LoginViewModel model)
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

                        var creds = SWCmsConstants.AuthConfiguration.SigningCredentials;

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

        */

        private async Task<AccessTokenViewModel> GenerateAccessTokenAsync(ApplicationUser user)
        {
            string refreshToken = Guid.NewGuid().ToString();
            var dtIssued = DateTime.UtcNow;
            var dtExpired = dtIssued.AddSeconds(SWCmsConstants.AuthConfiguration.AuthCookieExpiration);
            var dtRefreshTokenExpired = dtIssued.AddSeconds(SWCmsConstants.AuthConfiguration.AuthCookieExpiration);

            //RefreshTokenViewModel vmRefreshToken = new RefreshTokenViewModel(
            //            new RefreshTokens()
            //            {
            //                Id = refreshToken,
            //                Email = user.Email,
            //                IssuedUtc = dtIssued,
            //                ClientId = SWCmsConstants.AuthConfiguration.Audience,
            //                //Subject = SWCmsConstants.AuthConfiguration.Audience,
            //                ExpiresUtc = dtRefreshTokenExpired
            //            });

            //var saveRefreshTokenResult = await vmRefreshToken.SaveModelAsync();
            AccessTokenViewModel token = new AccessTokenViewModel()
            {
                Access_token = GenerateToken(user, dtExpired, refreshToken),
                //Refresh_token = vmRefreshToken.Id,
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
