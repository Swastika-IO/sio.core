// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Services;
using Swastika.Cms.Mvc.Controllers;
using System;
using System.Linq;
using static Swastika.Common.Utility.Enums;

namespace Swastika.Cms.Web.Mvc.Controllers
{
    public class InitCmsController : BaseController<InitCmsController>
    {
        public InitCmsController(IHostingEnvironment env) : base(env)
        {
        }

        [HttpGet]
        [Route("")]
        [Route("{culture}")]
        public IActionResult Index()
        {
            var context = new Lib.Models.Cms.SiocCmsContext();
            var crmCtx = new Swastika.Crm.Lib.Models.Crm.SwastikaCrmContext();

            var transaction = context.Database.BeginTransaction();
            try
            {
                if (context.SiocProduct.Count() == 0)
                {

                    var cultures = context.SiocCulture;
                    foreach (var item in crmCtx.CrmProduct)
                    {
                        foreach (var culture in cultures)
                        {
                            SiocProduct pr = new SiocProduct()
                            {
                                Id = Guid.NewGuid().ToString(),
                                Specificulture = culture.Specificulture,
                                Title = string.IsNullOrEmpty(item.Title) ? item.Code : item.Title,
                                Code = item.Code,
                                CreatedDateTime = DateTime.UtcNow,
                                CreatedBy = "Tinku",

                                Content = item.FullDetails,
                                Excerpt = item.Description,
                                Image = item.Image != null ? SWCmsHelper.GetFullPath(new[] { "/Content", item.Image }) : string.Empty,
                                DealPrice = item.DealPrice,
                                Priority = item.DisplayOrder ?? 0,
                                Source = item.Source,
                                Status = item.IsDeleted ? (int)SWStatus.Deleted :
                                    item.IsDraft ? (int)SWStatus.Draft :
                                    item.IsVisible.Value ? (int)SWStatus.Published :
                                    (int)SWStatus.Preview,
                                Template = "_Default"

                            };
                            context.SiocProduct.Add(pr);
                        }
                    }
                    //int id = context.SiocCategory.Max(c => c.Id);
                    //foreach (var item in crmCtx.CrmCategory)
                    //{
                    //    id += 1;
                    //    foreach (var culture in cultures)
                    //    {
                    //        var cate = new SiocCategory()
                    //        {
                    //            Id = id,
                    //            Specificulture = culture.Specificulture,
                    //            Type = (int)SWCmsConstants.CateType.ListProduct,
                    //            Title = item.Title,
                    //            CreatedDateTime = DateTime.UtcNow,
                    //            CreatedBy = "Admin"
                    //        };
                    //        context.SiocCategory.Add(cate);
                    //    }
                    //}
                    context.SaveChanges();

                    transaction.Commit();
                }
            }
            catch (System.Exception ex)
            {
                transaction.Rollback();
            }
            finally
            {
                context.Dispose();
                crmCtx.Dispose();
            }

            if (string.IsNullOrEmpty(GlobalConfigurationService.Instance.GetConfigConnectionKey()))
            {
                return RedirectToAction("Init", "Portal", new { culture = ROUTE_DEFAULT_CULTURE });
            }
            else
            {
                GlobalConfigurationService.Instance.IsInit = true;
                return RedirectToAction("", "Home", new { culture = CurrentLanguage });
            }
        }
    }
}