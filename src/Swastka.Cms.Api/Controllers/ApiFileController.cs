// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.ViewModels;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Domain.Core.ViewModels;

namespace Swastka.Cms.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = "SuperAdmin, Admin")]
    [Produces("application/json")]
    [Route("api/file")]
    public class ApiFileController : BaseApiController
    {
        #region Post

        // Post api/files/id
        [HttpGet, HttpOptions]
        [Route("details")]
        public RepositoryResponse<FileViewModel> Details(string folder, string filename)
        {
            // Request: Key => folder, Keyword => filename
            if (!string.IsNullOrEmpty(folder))
            {
                var file = FileRepository.Instance.GetWebFile(filename, folder);

                return new RepositoryResponse<FileViewModel>()
                {
                    IsSucceed = file != null,
                    Data = file
                };
            }
            else
            {
                return new RepositoryResponse<FileViewModel>();
            }
        }

        // GET api/files/id
        [HttpGet, HttpOptions]
        [Route("delete/{id}")]
        public RepositoryResponse<bool> Delete(RequestObject request)
        {
            string fullPath = SwCmsHelper.GetFullPath(new string[]
            {
                request.Key,
                request.Keyword
            });
            var result = FileRepository.Instance.DeleteWebFile(fullPath);
            return new RepositoryResponse<bool>()
            {
                IsSucceed = result,
                Data = result
            };
        }

        // POST api/values
        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <param name="image">The img information.</param>
        /// <param name="template"></param> Ex: { "base64": "", "fileFolder":"" }
        /// <returns></returns>
        [Route("uploadFile")]
        [HttpPost, HttpOptions]
        public IActionResult Edit(FileViewModel template)
        {
            if (ModelState.IsValid)
            {
                var result = FileRepository.Instance.SaveWebFile(template);
                return GetSuccessResult(result);
            }
            return GetErrorResult("failed", "invalid");
        }

        // POST api/files
        [HttpPost, HttpOptions]
        [Route("save")]
        public RepositoryResponse<FileViewModel> Save([FromBody]FileViewModel model)
        {
            if (model != null)
            {
                var result = FileRepository.Instance.SaveWebFile(model);
                return new RepositoryResponse<FileViewModel>()
                {
                    IsSucceed = result,
                    Data = model
                };
            }
            return new RepositoryResponse<FileViewModel>();
        }

        // GET api/files

        [HttpPost, HttpOptions]
        [Route("list")]
        public RepositoryResponse<ApiFilePageViewModel> GetList([FromBody]RequestPaging request)
        {
            ParseRequestPagingDate(request);
            var files = FileRepository.Instance.GetTopFiles(request.Key);
            var directories = FileRepository.Instance.GetTopDirectories(request.Key);
            return new RepositoryResponse<ApiFilePageViewModel>()
            {
                IsSucceed = true,
                Data = new ApiFilePageViewModel()
                {
                    Files = files,
                    Directories = directories
                }
            };
        }
        #endregion Post


    }
}
