// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query;
using Microsoft.EntityFrameworkCore;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.ViewModels.BackEnd;
using Swastika.Cms.Lib.ViewModels.Info;
using Swastika.Cms.Mvc.Controllers;
using Swastika.Domain.Core.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Swastika.Common.Utility.Enums;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize(Policy ="AddEditUser")]
    [Area("Portal")]
    [Route("{culture}/Portal/Product")]
    public class ProductController : BaseController<ProductController>
    {
        public ProductController(IHostingEnvironment env
            //, IStringLocalizer<PortalController> portalLocalizer, IStringLocalizer<SharedResource> localizer
            )
            : base(env)
        {
        }

        // GET: Portal/Product
        [HttpPost, HttpGet]
        [Route("Index")]
        [Route("")]
        [Route("{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("{pageSize:int?}/{pageIndex:int?}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        [Route("Index/{pageSize:int?}/{pageIndex:int?}")]
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            RepositoryResponse<PaginationModel<InfoProductViewModel>> getProduct =
                await InfoProductViewModel.Repository.GetModelListByAsync(
                product => product.Specificulture == _lang
                    && product.Status != (int)SWStatus.Deleted
                    && (string.IsNullOrEmpty(keyword) || product.Title.Contains(keyword)),
                "Priority", OrderByDirection.Ascending
                , pageSize, pageIndex).ConfigureAwait(false);
            ViewBag.keyword = keyword;
            return View(getProduct.Data);
        }

        // GET: Portal/Product/Draft
        [HttpGet]
        [Route("Draft")]
        [Route("Draft/{pageSize:int?}/{pageIndex:int?}/{keyword}")]
        public async Task<IActionResult> Draft(int pageSize = 10, int pageIndex = 0, string keyword = null)
        {
            var getProduct = await InfoProductViewModel.Repository.GetModelListByAsync(
                product => product.Specificulture == _lang
                    && (string.IsNullOrEmpty(keyword) || product.Title.Contains(keyword))
                    && product.Status != (int)SWStatus.Deleted,
                "CreatedDateTime", OrderByDirection.Descending,
                pageSize, pageIndex).ConfigureAwait(false);

            return View(getProduct.Data);
        }

        // GET: Portal/Product/Create
        [HttpGet]
        [Route("Create")]
        [Route("Create/{categoryId:int}")]
        public IActionResult Create(int? categoryId = null)
        {
            var vmProduct = new BEProductViewModel(new SiocProduct()
            {
                Specificulture = _lang,
                CreatedBy = User.Identity.Name,
                CreatedDateTime = DateTime.UtcNow
            })
            {
                Status = SWStatus.Preview
            };
            if (categoryId.HasValue)
            {
                var activeCate = vmProduct.Categories.Find(c => c.CategoryId == categoryId);
                if (activeCate != null)
                {
                    activeCate.IsActived = true;
                }
            }
            ViewBag.categoryId = categoryId;
            return View(vmProduct);
        }

        // POST: product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [Route("Create/{categoryId:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BEProductViewModel product, int? categoryId = null)
        {
            if (ModelState.IsValid)
            {
                //var vmProduct = new SWBEProductViewModel<BackendBEProductViewModel>(product);
                //var result = await vmProduct.SaveModelAsync();
                var result = await product.SaveModelAsync(true).ConfigureAwait(false);
                if (result.IsSucceed)
                {
                    if (categoryId.HasValue)
                    {
                        return RedirectToAction("Contents", "Pages", new { id = categoryId });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View(product);
                }
            }
            ViewBag.categoryId = categoryId;
            return View(product);
        }

        // GET: product/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        [Route("Edit/{id}/{categoryId:int}")]
        public async Task<IActionResult> Edit(string id = null, int? categoryId = null)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var product = await BEProductViewModel.Repository.GetSingleModelAsync(
                m => m.Id == id && m.Specificulture == _lang).ConfigureAwait(false);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.categoryId = categoryId;
            return View(product.Data);
        }

        // POST: product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit/{id}")]
        [Route("Edit/{id}/{categoryId:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BEProductViewModel product, string id, int? categoryId = null)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await product.SaveModelAsync(true).ConfigureAwait(false);
                    if (result.IsSucceed)
                    {
                        if (categoryId.HasValue)
                        {
                            return RedirectToAction("Contents", "Pages", new { id = categoryId });
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Exception.Message);
                        return View(product);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BEProductViewModel.Repository.CheckIsExists(m => m.Id == product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        [Route("Recycle/{id}")]
        public async Task<IActionResult> Recycle(string id)
        {
            var getProduct = InfoProductViewModel.Repository.GetSingleModel(a => a.Id == id);
            if (getProduct.IsSucceed)
            {
                var data = getProduct.Data;
                data.IsDeleted = true;
                var result = await data.SaveModelAsync().ConfigureAwait(false);
                if (result.IsSucceed)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("Restore/{id}")]
        public async Task<IActionResult> Restore(string id)
        {
            var getProduct = InfoProductViewModel.Repository.GetSingleModel(a => a.Id == id);
            if (getProduct.IsSucceed)
            {
                var data = getProduct.Data;
                data.IsDeleted = false;
                var result = await data.SaveModelAsync().ConfigureAwait(false);
                if (result.IsSucceed)
                {
                    return RedirectToAction("Draft");
                }
                else
                {
                    return RedirectToAction("Draft");
                }
            }
            else
            {
                return RedirectToAction("Draft");
            }
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var getProduct = await BEProductViewModel.Repository.GetSingleModelAsync(m => m.Id == id && m.Specificulture == _lang).ConfigureAwait(false);
            if (getProduct.IsSucceed)
            {
                await getProduct.Data.RemoveModelAsync(true).ConfigureAwait(false);
            }
            return RedirectToAction("Draft", "Product");
        }
    }
}
