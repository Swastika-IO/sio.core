// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Newtonsoft.Json.Linq;
using Swastika.Api.Controllers;
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
    [Produces("application/json")]
    [Route("api/{culture}/media")]
    public class ApiMediaController :
        BaseApiController<SiocCmsContext, SiocMedia>
    {
        public ApiMediaController(IHostingEnvironment env) : base(env)
        {
        }

        #region Get

        // GET api/medias/id
        [HttpGet]
        [Route("details/{viewType}/{id}")]
        public async Task<JObject> BEDetails(string viewType, int id)
        {
            switch (viewType)
            {
                default:
                    var feResult = await BEMediaViewModel.Repository.GetSingleModelAsync(
                        model => model.Id == id && model.Specificulture == _lang).ConfigureAwait(false);
                    return JObject.FromObject(feResult);
            }
        }

        // GET api/medias/id
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<bool>> Delete(int id)
        {
            var getMedia = BEMediaViewModel.Repository.GetSingleModel(a => a.Id == id && a.Specificulture == _lang);
            if (getMedia.IsSucceed)
            {
                return await getMedia.Data.RemoveModelAsync(true).ConfigureAwait(false);
            }
            else
            {
                return new RepositoryResponse<bool>() { IsSucceed = false };
            }
        }

        // GET api/medias
        [HttpGet]
        //[Authorize]
        [Route("list")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}")]
        [Route("list/{orderBy}/{direction}")]
        [Route("list/{pageSize:int?}/{pageIndex:int?}/{orderBy}/{direction}")]
        public async Task<RepositoryResponse<PaginationModel<BEMediaViewModel>>> Get(
            int? pageSize = 15, int? pageIndex = 0, string orderBy = "Id"
            , OrderByDirection direction = OrderByDirection.Ascending)
        {
            var data = await BEMediaViewModel.Repository.GetModelListByAsync(
                m => m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false); //base.Get(orderBy, direction, pageSize, pageIndex);
            return data;
        }

        // GET api/medias
        [HttpGet]
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
            var data = await BEMediaViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex).ConfigureAwait(false); // base.Search(predicate, orderBy, direction, pageSize, pageIndex, keyword);

            return data;
        }

        #endregion Get

        #region Post

        [Route("upload")]
        [HttpPost]
        public async Task<RepositoryResponse<BEMediaViewModel>> UploadAsync([FromForm] string fileFolder, [FromForm] string title, [FromForm] string description)
        {
            var files = Request.Form.Files;

            if (files.Count > 0)
            {
                var fileUpload = files.FirstOrDefault();

                string folderPath = //$"{SWCmsConstants.Parameters.UploadFolder}/{fileFolder}/{DateTime.UtcNow.ToString("MMM-yyyy")}";
                SWCmsHelper.GetFullPath(new[] {
                    SWCmsConstants.Parameters.UploadFolder,
                    fileFolder,
                    DateTime.UtcNow.ToString("MMM-yyyy")
                });
                // string.Format("Uploads/{0}", fileFolder);
                //return ImageHelper.ResizeImage(Image.FromStream(fileUpload.OpenReadStream()), System.IO.Path.Combine(_env.WebRootPath, folderPath));
                //var fileName = await Common.UploadFileAsync(filePath, files.FirstOrDefault());
                string fileName =
                SWCmsHelper.GetFullPath(new[] {
                    "/",
                    await UploadFileAsync(files.FirstOrDefault(), folderPath).ConfigureAwait(false)
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
                    Title = title,
                    Description = description
                });
                //media.SaveModel();
                return media.SaveModel();
            }
            else
            {
                return new RepositoryResponse<BEMediaViewModel>();
            }
        }

        // POST api/medias
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<BEMediaViewModel>> Post(BEMediaViewModel model)
        {
            if (model != null)
            {
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);

                return result;
            }
            return new RepositoryResponse<BEMediaViewModel>();
        }

        // GET api/medias

        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<RepositoryResponse<PaginationModel<BEMediaViewModel>>> GetList(RequestPaging request)
        {
            Expression<Func<SiocMedia, bool>> predicate = model =>
                model.Specificulture == _lang
                && (string.IsNullOrWhiteSpace(request.Keyword)
                || (model.FileName.Contains(request.Keyword)
                || model.Title.Contains(request.Keyword)
                || model.Description.Contains(request.Keyword)));
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

        #region Helper

        //string GetFileType(string ext)
        //{
        //    switch (ext)
        //    {
        //        default:
        //            break;
        //    }
        //}

        #endregion Helper
    }
}
