// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Swastika.Common.Helper;
using Swastika.Common.Utility;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.Repository;
using Swastika.UI.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Services;

namespace Swastka.Cms.Api.Controllers
{
    /// <summary>
    /// Base Api Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller"/>
    public class BaseApiController : ControllerBase
    {
        /// <summary>
        /// The domain
        /// </summary>
        protected string _domain;

        /// <summary>
        /// The language
        /// </summary>
        protected string _lang;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApiController"/> class.
        /// </summary>
        public BaseApiController()
        {
        }

        /// <summary>
        /// Creates an <see cref="T:Microsoft.AspNetCore.Mvc.BadRequestObjectResult"/> that produces
        /// a <see cref="F:Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest"/> response.
        /// </summary>
        /// <param name="error"></param>
        /// <returns>
        /// The created <see cref="T:Microsoft.AspNetCore.Mvc.BadRequestObjectResult"/> for the response.
        /// </returns>
        public override BadRequestObjectResult BadRequest(object error)
        {
            return base.BadRequest(error);
        }

        /// <summary>
        /// Creates an <see cref="T:Microsoft.AspNetCore.Mvc.NotFoundObjectResult"/> that produces a
        /// <see cref="F:Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound"/> response.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// The created <see cref="T:Microsoft.AspNetCore.Mvc.NotFoundObjectResult"/> for the response.
        /// </returns>
        public override NotFoundObjectResult NotFound(object value)
        {
            return base.NotFound(value);
        }

        /// <summary>
        /// Gets the error result.
        /// </summary>
        /// <param name="responseKey">The response key.</param>
        /// <param name="errorMsg">The error MSG.</param>
        /// <returns></returns>
        protected IActionResult GetErrorResult(string responseKey, string errorMsg)
        {
            var result = ApiHelper<string>.GetResult(0, string.Empty, responseKey, null);
            return BadRequest(result);
        }

        /// <summary>
        /// Gets the success result.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        protected IActionResult GetSuccessResult<TResult>(TResult data)
        {
            var result = ApiHelper<TResult>.GetResult(1, data, nameof(Enums.ResponseKey.OK), null);
            return Ok(result);
        }


        protected void ParseRequestPagingDate(RequestPaging request)
        {
            request.FromDate = request.FromDate.HasValue ? new DateTime(request.FromDate.Value.Year, request.FromDate.Value.Month, request.FromDate.Value.Day).ToUniversalTime()
                : default(DateTime?);
            request.ToDate = request.ToDate.HasValue ? new DateTime(request.ToDate.Value.Year, request.ToDate.Value.Month, request.ToDate.Value.Day).ToUniversalTime().AddDays(1)
                : default(DateTime?);
        }

        /// <summary>
        /// Uploads the file asynchronous.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="folderPath">The folder path.</param>
        /// <returns></returns>
        protected async Task<string> UploadFileAsync(IFormFile file, string folderPath)
        {
            if (file?.Length > 0)
            {
                string fileName = await CommonHelper.UploadFileAsync(folderPath, file).ConfigureAwait(false);
                if (!string.IsNullOrEmpty(fileName))
                {
                    string filePath = string.Format("{0}/{1}", folderPath, fileName);
                    return filePath;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Uploads the list file asynchronous.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        /// <returns></returns>
        protected async Task<List<string>> UploadListFileAsync(string folderPath)
        {
            List<string> result = new List<string>();
            var files = HttpContext.Request.Form.Files;
            foreach (var file in files)
            {
                string fileName = await UploadFileAsync(file, folderPath).ConfigureAwait(false);
                if (!string.IsNullOrEmpty(fileName))
                {
                    result.Add(fileName);
                }
            }
            return result;
        }
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller"/>
    public class BaseApiController<TDbContext, TModel, TView> : Controller
        where TDbContext : DbContext
        where TModel : class
        where TView : Swastika.Domain.Data.ViewModels.ViewModelBase<TDbContext, TModel, TView>
    {
        /// <summary>
        /// The repo
        /// </summary>
        protected readonly DefaultRepository<TDbContext, TModel, TView> _repo;

        /// <summary>
        /// The language
        /// </summary>
        protected string _lang;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApiController{TDbContext, TModel,
        /// TView}"/> class.
        /// </summary>
        public BaseApiController()
        {
            _repo = DefaultRepository<TDbContext, TModel, TView>.Instance;
        }

        /// <summary>
        /// Creates an <see cref="T:Microsoft.AspNetCore.Mvc.BadRequestObjectResult"/> that produces
        /// a <see cref="F:Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest"/> response.
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns>
        /// The created <see cref="T:Microsoft.AspNetCore.Mvc.BadRequestObjectResult"/> for the response.
        /// </returns>
        public override BadRequestObjectResult BadRequest(ModelStateDictionary modelState)
        {
            List<string> errors = new List<string>();
            foreach (ModelStateEntry state in ViewData.ModelState.Values)
            {
                foreach (ModelError error in state.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            var result = ApiHelper<TView>.GetResult(0, default(TView), nameof(Enums.ResponseKey.BadRequest), errors);
            return base.BadRequest(result);
        }

        /// <summary>
        /// Creates an <see cref="T:Microsoft.AspNetCore.Mvc.BadRequestObjectResult"/> that produces
        /// a <see cref="F:Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest"/> response.
        /// </summary>
        /// <param name="error"></param>
        /// <returns>
        /// The created <see cref="T:Microsoft.AspNetCore.Mvc.BadRequestObjectResult"/> for the response.
        /// </returns>
        public override BadRequestObjectResult BadRequest(object error)
        {
            var result = ApiHelper<TView>.GetResult(0, default(TView), nameof(Enums.ResponseKey.BadRequest), null);
            return base.BadRequest(result);
        }

        /// <summary>
        /// Creates an <see cref="T:Microsoft.AspNetCore.Mvc.NotFoundObjectResult"/> that produces a
        /// <see cref="F:Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound"/> response.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// The created <see cref="T:Microsoft.AspNetCore.Mvc.NotFoundObjectResult"/> for the response.
        /// </returns>
        public override NotFoundObjectResult NotFound(object value)
        {
            var result = ApiHelper<TView>.GetResult(0, default(TView), nameof(Enums.ResponseKey.NotFound), null);
            return base.NotFound(result);
        }

        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="context">The action executing context.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            GetLanguage();
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// Gets the error result.
        /// </summary>
        /// <param name="responseKey">The response key.</param>
        /// <param name="errorMsg">The error MSG.</param>
        /// <returns></returns>
        protected IActionResult GetErrorResult(string responseKey, string errorMsg)
        {
            var result = ApiHelper<TView>.GetResult(0, default(TView), responseKey, null);
            return BadRequest(result);
        }

        /// <summary>
        /// Gets the language.
        /// </summary>
        protected void GetLanguage()
        {
            _lang = RouteData?.Values["culture"] != null
                ? RouteData.Values["culture"].ToString() : GlobalConfigurationService.Instance.CmsConfigurations.Language;
            ViewBag.culture = _lang;
        }

        /// <summary>
        /// Gets the success result.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        protected IActionResult GetSuccessResult<TResult>(TResult data)
        {
            var result = ApiHelper<TResult>.GetResult(1, data, nameof(Enums.ResponseKey.OK), null);
            return Ok(result);
        }

        protected void ParseRequestPagingDate(RequestPaging request)
        {
            request.FromDate = request.FromDate.HasValue ? new DateTime(request.FromDate.Value.Year, request.FromDate.Value.Month, request.FromDate.Value.Day).ToUniversalTime()
                : default(DateTime?);
            request.ToDate = request.ToDate.HasValue ? new DateTime(request.ToDate.Value.Year, request.ToDate.Value.Month, request.ToDate.Value.Day).ToUniversalTime().AddDays(1)
                : default(DateTime?);

        }
    }
}

