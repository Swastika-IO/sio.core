// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Newtonsoft.Json.Linq;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.Api;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swastka.Cms.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme
    //    //, Policy = "AddEditUser"
    //    )]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/customer")]
    public class ApiCustomerController :
        BaseApiController
    {
        public ApiCustomerController()
        {
        }

        #region Get

        // GET api/customers/id
        [HttpGet, HttpOptions]
        [Route("details/{viewType}/{id}")]
        [Route("details/{viewType}")]
        public async Task<JObject> Details(string viewType, string id = null)
        {
            switch (viewType)
            {
                default:
                    if (!string.IsNullOrEmpty(id))
                    {
                        var feResult = await ApiCustomerViewModel.Repository.GetSingleModelAsync(
                        model => model.Id == id
                        ).ConfigureAwait(false);
                        return JObject.FromObject(feResult);
                    }
                    else
                    {
                        var customer = new SiocCustomer()
                        {
                        };

                        var result = new RepositoryResponse<ApiCustomerViewModel>()
                        { 
                            IsSucceed = true,
                            Data = (await ApiCustomerViewModel.InitViewAsync(customer))
                        };
                        return JObject.FromObject(result);
                    }

            }
        }

        // GET api/customers/id
        [HttpGet, HttpOptions]
        [Route("delete/{id}")]
        public async Task<RepositoryResponse<SiocCustomer>> Delete(string id)
        {
            var getCustomer = ApiCustomerViewModel.Repository.GetSingleModel(a => a.Id == id);
            if (getCustomer.IsSucceed)
            {
                return await getCustomer.Data.RemoveModelAsync(true).ConfigureAwait(false);
            }
            else
            {
                return new RepositoryResponse<SiocCustomer>() { IsSucceed = false };
            }
        }

        #endregion Get

        #region Post

        // POST api/customers
        [HttpPost, HttpOptions]
        [Route("save")]
        public async Task<RepositoryResponse<ApiCustomerViewModel>> Post([FromBody]ApiCustomerViewModel model)
        {
            if (model != null)
            {
                var result = await model.SaveModelAsync(true).ConfigureAwait(false);

                return result;
            }
            return new RepositoryResponse<ApiCustomerViewModel>();
        }

        // GET api/customers

        [HttpPost, HttpOptions]
        [Route("list")]
        public async Task<RepositoryResponse<PaginationModel<ApiCustomerViewModel>>> GetList([FromBody]RequestPaging request)
        {
            ParseRequestPagingDate(request);
            Expression<Func<SiocCustomer, bool>> predicate = model =>
                (string.IsNullOrWhiteSpace(request.Keyword)
                || (model.FullName.Contains(request.Keyword)
                || model.PhoneNumber.Contains(request.Keyword)
                || model.Email.Contains(request.Keyword)));
            
            var data = await ApiCustomerViewModel.Repository.GetModelListByAsync(predicate, request.OrderBy, request.Direction, request.PageSize, request.PageIndex).ConfigureAwait(false);

            return data;
        }
        #endregion Post

    }
}
