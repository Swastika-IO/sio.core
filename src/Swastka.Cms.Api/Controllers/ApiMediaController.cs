using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Swastika.Domain.Core.ViewModels;
using Swastika.Api.Controllers;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.Models.Cms;
using Newtonsoft.Json.Linq;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace Swastka.Cms.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme
    //    //, Policy = "AddEditUser"
    //    )]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            JObject result = new JObject();
            switch (viewType)
            {

                default:
                    var feResult = await BEMediaViewModel.Repository.GetSingleModelAsync(
                        model => model.Id == id && model.Specificulture == _lang);
                    result = JObject.FromObject(feResult);
                    break;
            }
            return result;
        }



        // GET api/medias/id
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<bool>> Delete(int id)
        {
            var getMedia = BEMediaViewModel.Repository.GetSingleModel(a => a.Id == id && a.Specificulture == _lang);
            if (getMedia.IsSucceed)
            {
                return await getMedia.Data.RemoveModelAsync(true);
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
                m => m.Specificulture == _lang, orderBy, direction, pageSize, pageIndex); //base.Get(orderBy, direction, pageSize, pageIndex);
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
            var data = await BEMediaViewModel.Repository.GetModelListByAsync(predicate, orderBy, direction, pageSize, pageIndex); // base.Search(predicate, orderBy, direction, pageSize, pageIndex, keyword);

            return data;
        }


        #endregion

        #region Post

        [Route("upload")]
        [HttpPost]
        public async Task<RepositoryResponse<BEMediaViewModel>> UploadAsync([FromForm] string fileFolder)
        {
            var files = Request.Form.Files;

            if (files.Count > 0)
            {
                var fileUpload = files.FirstOrDefault();

                string folderPath = string.Format("Uploads/{0}", fileFolder);
                //return ImageHelper.ResizeImage(Image.FromStream(fileUpload.OpenReadStream()), System.IO.Path.Combine(_env.WebRootPath, folderPath));
                //var fileName = await Common.UploadFileAsync(filePath, files.FirstOrDefault());
                var fileName = string.Format("/{0}", await base.UploadFileAsync(files.FirstOrDefault(), folderPath));
                BEMediaViewModel media = new BEMediaViewModel(new SiocMedia()
                {
                    Specificulture = _lang,
                    FileName = fileName.Split('.')[0].Substring(fileName.LastIndexOf('/') + 1),
                    FileFolder = folderPath,
                    Extension = fileName.Substring(fileName.LastIndexOf('.')),
                    CreatedDateTime = DateTime.UtcNow,
                    FileType = fileUpload.ContentType.Split('/')[0]
                });
                //media.SaveModel();
                return media.SaveModel(); ;
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
                var result = await model.SaveModelAsync(true);

                return result;
            }
            return new RepositoryResponse<BEMediaViewModel>();

        }


        // GET api/medias

        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<RepositoryResponse<PaginationModel<BEMediaViewModel>>> GetList(RequestPaging request)
        {
            string domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);
            if (string.IsNullOrEmpty(request.Keyword))
            {

                var data = await BEMediaViewModel.Repository.GetModelListByAsync(
                m => m.Specificulture == _lang, request.OrderBy, request.Direction, request.PageSize, request.PageIndex);

                return data;

            }
            else
            {
                Expression<Func<SiocMedia, bool>> predicate = model =>
            model.Specificulture == _lang
            && (string.IsNullOrWhiteSpace(request.Keyword) ||
                (
                    model.FileName.Contains(request.Keyword)
                )
                );
                var data = await BEMediaViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex);

                return data;
            }

        }
        #endregion

        #region Helper

        //string GetFileType(string ext)
        //{
        //    switch (ext)
        //    {
        //        default:
        //            break;
        //    }
        //}

        #endregion
    }
}
