using System;
//using Swastika.Application.Interfaces;
using Swastika.UI.Base.Controllers;
//using Swastika.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swastika.Extension.Customer.Application.Interfaces;
using Swastika.Domain.Core.Notifications;

namespace Swastika.Extension.Customer.UI.Api.Controllers
{
    [Authorize]
    public class ApiCustomerController : BaseController
    {
        private readonly ICustomerAppService _customerAppService;

        public ApiCustomerController(ICustomerAppService customerAppService, IDomainNotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/customer-management/list-all")]
        public JsonResult Index()
        {
            return Json(_customerAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/customer-management/customer-details/{id:guid}")]
        public JsonResult Details(Guid? id)
        {
            if (id == null)
            {
                return Json(null);
            }

            var customerViewModel = _customerAppService.GetById(id.Value);

            if (customerViewModel == null)
            {
                return Json(null);
            }

            return Json(customerViewModel);
        }

        //[HttpGet]
        //[Authorize(Policy = "CanWriteCustomerData")]
        //[Route("api/customer-management/register-new")]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[Authorize(Policy = "CanWriteCustomerData")]
        //[Route("api/customer-management/register-new")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(CustomerViewModel customerViewModel)
        //{
        //    if (!ModelState.IsValid) return View(customerViewModel);
        //    _customerAppService.Register(customerViewModel);

        //    if (IsValidOperation())
        //        ViewBag.Sucesso = "Customer Registered!";

        //    return View(customerViewModel);
        //}

        //[HttpGet]
        //[Authorize(Policy = "CanWriteCustomerData")]
        //[Route("api/customer-management/edit-customer/{id:guid}")]
        //public IActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customerViewModel = _customerAppService.GetById(id.Value);

        //    if (customerViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customerViewModel);
        //}

        //[HttpPost]
        //[Authorize(Policy = "CanWriteCustomerData")]
        //[Route("api/customer-management/edit-customer/{id:guid}")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(CustomerViewModel customerViewModel)
        //{
        //    if (!ModelState.IsValid) return View(customerViewModel);

        //    _customerAppService.Update(customerViewModel);

        //    if (IsValidOperation())
        //        ViewBag.Sucesso = "Customer Updated!";

        //    return View(customerViewModel);
        //}

        //[HttpGet]
        //[Authorize(Policy = "CanRemoveCustomerData")]
        //[Route("api/customer-management/remove-customer/{id:guid}")]
        //public IActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customerViewModel = _customerAppService.GetById(id.Value);

        //    if (customerViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customerViewModel);
        //}

        //[HttpPost, ActionName("Delete")]
        //[Authorize(Policy = "CanRemoveCustomerData")]
        //[Route("api/customer-management/remove-customer/{id:guid}")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(Guid id)
        //{
        //    _customerAppService.Remove(id);

        //    if (!IsValidOperation()) return View(_customerAppService.GetById(id));

        //    ViewBag.Sucesso = "Customer Removed!";
        //    return RedirectToAction("Index");
        //}

        //[AllowAnonymous]
        //[Route("api/customer-management/customer-history/{id:guid}")]
        //public JsonResult History(Guid id)
        //{
        //    var customerHistoryData = _customerAppService.GetAllHistory(id);
        //    return Json(customerHistoryData);
        //}
    }
}
