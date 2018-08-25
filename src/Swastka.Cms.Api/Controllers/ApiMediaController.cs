// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Navigation;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swastka.Cms.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme
    //    //, Policy = "AddEditUser"
    //    )]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/{culture}/media")]
    public class ApiMediaController :
        BaseApiController
    {
        public ApiMediaController()
        {
        }

        #region Get

        // GET api/medias/id
        [HttpGet,HttpOptions]
        [Route("details/{viewType}/{id}")]
        [Route("details/{viewType}")]
        public async Task<JObject> BEDetails(string viewType, int? id = null)
        {
            switch (viewType)
            {
                default:
                    if (id.HasValue)
                    {
                        var feResult = await BEMediaViewModel.Repository.GetSingleModelAsync(
                        model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                        return JObject.FromObject(feResult);
                    }
                    else
                    {
                        var media = new SiocMedia()
                        {
                            Specificulture = _lang,
                            Priority = BEMediaViewModel.Repository.Max(a => a.Priority).Data + 1
                        };
                        var result = new RepositoryResponse<BEMediaViewModel>()
                        {
                            IsSucceed = true,
                            Data = (await BEMediaViewModel.InitViewAsync(media))
                        };
                        return JObject.FromObject(result);
                    }

            }
        }

        // GET api/medias/id
        [HttpGet, HttpOptions]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<SiocMedia>> Delete(int id)
        {
            var getMedia = BEMediaViewModel.Repository.GetSingleModel(a => a.Id == id && a.Specificulture == _lang);
            if (getMedia.IsSucceed)
            {
                return await getMedia.Data.RemoveModelAsync(true).ConfigureAwait(false);
            }
            else
            {
                return new RepositoryResponse<SiocMedia>() { IsSucceed = false };
            }
        }

        // GET api/medias
        [HttpGet, HttpOptions]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin, Admin")]
        [Route("list")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}")]
        [Route("list/{orderBy}/{direction}")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<BEMediaViewModel>>> Get(
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            var data = await BEMediaViewModel.Repository.GetModelListByAsync(
                m => m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false);
            return data;
        }

        // GET api/medias
        [HttpGet, HttpOptions]
        [Route("search/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("search/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}/{keyword}")]
        public async Task<RepositoryResponse<PaginationModel<BEMediaViewModel>>> Search(
            string keyword = null, int? pageSize = null, int? pageIndex = null, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            Expression<Func<SiocMedia, bool>> predicate = model =>
            model.Specificulture == _lang
            && (
            string.IsNullOrWhiteSpace(keyword)
                || model.FileName.Contains(keyword)
                );
            var data = await BEMediaViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false);

            return data;
        }

        #endregion Get

        #region Post

        [Route("upload")]
        [HttpPost, HttpOptions]
        public async Task<RepositoryResponse<BEMediaViewModel>> UploadAsync([FromForm] string fileFolder, [FromForm] string title, [FromForm] string description)
        {
            var files = Request.Form.Files;

            if (files.Count > 0)
            {
                var fileUpload = files.FirstOrDefault();

                string folderPath = SwCmsHelper.GetFullPath(new[] {
                    SWCmsConstants.Parameters.UploadFolder,
                    fileFolder,
                    DateTime.UtcNow.ToString("MM-yyyy")
                });
                // save web files in wwwRoot
                string uploadPath = SwCmsHelper.GetFullPath(new[] {
                    SWCmsConstants.Parameters.WebRootPath,
                    folderPath
                });

                string fileName =
                SwCmsHelper.GetFullPath(new[] {
                    "/",
                    await UploadFileAsync(files.FirstOrDefault(), uploadPath).ConfigureAwait(false)
                });
                BEMediaViewModel media = new BEMediaViewModel(new SiocMedia()
                {
                    Specificulture = _lang,
                    FileName = fileName.Split('.')[0].Substring(fileName.LastIndexOf('/') + 1),
                    FileFolder = folderPath,
                    Extension = fileName.Substring(fileName.LastIndexOf('.')),
                    CreatedDateTime = DateTime.UtcNow,
                    FileType = fileUpload.ContentType.Split('/')[0],
                    FileSize = fileUpload.Length,
                    Title = title ?? fileName.Split('.')[0].Substring(fileName.LastIndexOf('/') + 1),
                    Description = description ?? fileName.Split('.')[0].Substring(fileName.LastIndexOf('/') + 1)
                });
                return await media.SaveModelAsync();
            }
            else
            {
                return new RepositoryResponse<BEMediaViewModel>();
            }
        }

        // POST api/medias
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<BEMediaViewModel>> Post([FromBody]BEMediaViewModel model)
        {
            if (model != null)
            {
                model.Specificulture = _lang;
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);

                return result;
            }
            return new RepositoryResponse<BEMediaViewModel>();
        }

        // GET api/medias

        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<RepositoryResponse<PaginationModel<BEMediaViewModel>>> GetList([FromBody]RequestPaging request)
        {
            ParseRequestPagingDate(request);
            Expression<Func<SiocMedia, bool>> predicate = model =>
                model.Specificulture == _lang
                && (string.IsNullOrWhiteSpace(request.Keyword)
                || (model.FileName.Contains(request.Keyword)
                || model.Title.Contains(request.Keyword)
                || model.Description.Contains(request.Keyword)))
                && (!request.FromDate.HasValue
                    || (model.CreatedDateTime >= request.FromDate.Value)
                )
                && (!request.ToDate.HasValue
                    || (model.CreatedDateTime <= request.ToDate.Value)
                );

            var data = await BEMediaViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);

            return data;
        }

        [HttpPost, HttpOptions]
        [Route("list/byProduct/{productId}")]
        [Route("list/byProduct")]
        public async Task<RepositoryResponse<PaginationModel<NavProductMediaViewModel>>> GetListByProduct(RequestPaging request, string productId = null)
        {
            var data = await NavProductMediaViewModel.Repository.GetModelListByAsync(
            m => m.ProductId == productId && m.Specificulture == _lang, request.OrderBy
            , request.Direction, request.PageSize, request.PageIndex)
            .ConfigureAwait(false);

            return data;

        }

        #endregion Post
    }
}
