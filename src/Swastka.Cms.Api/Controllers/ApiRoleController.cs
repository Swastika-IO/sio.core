using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swastika.Cms.Lib.ViewModels.Account;
using Swastika.Domain.Core.ViewModels;
using Swastika.Identity.Models;
using Swastika.Identity.Services;

namespace Swastka.Cms.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/role")]
    public class ApiRoleController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public ApiRoleController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender,
            ILogger<ApiRoleController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("claims")]
        public object Claims()
        {

            return User.Claims.Select(c =>
            new
            {
                Type = c.Type,
                Value = c.Value
            });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin")]
        [HttpGet, HttpPost]
        [Route("list")]
        public async Task<RepositoryResponse<List<RoleViewModel>>> GetList()
        {
            return await RoleViewModel.Repository.GetModelListAsync();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin")]
        [HttpPost]
        [Route("create")]
        public async Task<RepositoryResponse<IdentityRole>> Save([FromBody]string name)
        {
            var role = new IdentityRole()
            {
                Name = name,
                Id = Guid.NewGuid().ToString()
            };

            var result = await _roleManager.CreateAsync(role);

            return new RepositoryResponse<IdentityRole>()
            {
                IsSucceed = result.Succeeded,
                Data = role,
                Errors = result.Errors?.Select(e => $"{e.Code}: {e.Description}").ToList()
            };
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin")]
        [HttpPost]
        [Route("delete")]
        public async Task<RepositoryResponse<bool>> Delete([FromBody] string name)
        {
            if (name != "SuperAdmin")
            {

                var result = await RoleViewModel.Repository.RemoveModelAsync(r => r.Name == name);
                return result;
            }
            else
            {
                return new RepositoryResponse<bool>()
                {
                };
            }
        }


    }
}