using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swastika.Domain.Core.Models;
using System.Linq.Expressions;
using System;
using Swastika.Common.Helper;
using Microsoft.Data.OData.Query;
using System.Threading.Tasks;
using Swastika.Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Swastka.Cms.Api.Controllers
{
    public class BaseAPIController<TContext, TModel> : Controller
        where TContext : DbContext
        where TModel : class
    {
        protected string _domain;
        protected string _lang;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            GetLanguage();
            base.OnActionExecuting(context);
        }
        protected void GetLanguage()
        {

            _lang = RouteData != null && RouteData.Values["culture"] != null
                ? RouteData.Values["culture"].ToString() : "vi-vn";
            ViewBag.culture = _lang;

            _domain = string.Format("{0}://{1}", Request.Scheme, Request.Host);

            //ViewBag.currentCulture = listCultures.FirstOrDefault(c => c.Specificulture == _lang);
            //ViewBag.cultures = listCultures;
        }

        protected readonly DefaultRepository<TContext, TModel> _repo;
        public BaseAPIController()
        {
            _repo = DefaultRepository<TContext, TModel>.Instance;
        }      

    }

    public class BaseAPIController<TDbContext, TModel, TView> : Controller
        where TDbContext : DbContext
        where TModel : class
        where TView : Swastika.Infrastructure.Data.ViewModels.ViewModelBase<TDbContext, TModel, TView>
    {
        protected string _lang;
        protected readonly DefaultRepository<TDbContext, TModel, TView> _repo;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            GetLanguage();
            base.OnActionExecuting(context);
        }
        protected void GetLanguage()
        {

            _lang = RouteData != null && RouteData.Values["culture"] != null
                ? RouteData.Values["culture"].ToString() : "vi-vn";
            ViewBag.culture = _lang;
            //ViewBag.currentCulture = listCultures.FirstOrDefault(c => c.Specificulture == _lang);
            //ViewBag.cultures = listCultures;
        }

        
        public BaseAPIController()
        {
            _repo = DefaultRepository<TDbContext, TModel, TView>.Instance;
        }
    }
}