using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swastika.UI.Base;
using System.Collections.Generic;

namespace Swastika.Extension.Blog.Api.Controllers
{
    public class BaseApiController<T> : Controller
    {
        public override NotFoundObjectResult NotFound(object value)
        {
            var result = ApiHelper<T>.GetResult(0, default(T), SWConstants.ResponseKey.NotFound.ToString(), null, string.Empty);
            return base.NotFound(result);
        }

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
            var result = ApiHelper<T>.GetResult(0, default(T), SWConstants.ResponseKey.BadRequest.ToString(), errors, string.Empty);
            return base.BadRequest(result);
        }

        public override BadRequestObjectResult BadRequest(object error)
        {
            var result = ApiHelper<T>.GetResult(0, default(T), SWConstants.ResponseKey.BadRequest.ToString(), null, string.Empty);
            return base.BadRequest(result);
        }

        protected IActionResult GetErrorResult(string responseKey, string errorMsg, string message)
        {
            var result = ApiHelper<T>.GetResult(0, default(T), responseKey, null, message);
            return BadRequest(result);
        }

        protected IActionResult GetResult<TResult>(int status, TResult data, string responseKey, string error, string message)
        {
            var result = ApiHelper<TResult>.GetResult(status, data, responseKey, null, message);
            return Ok(result);
        }

        protected IActionResult GetSuccessResult<TResult>(TResult data)
        {
            var result = ApiHelper<TResult>.GetResult(1, data, SWConstants.ResponseKey.OK.ToString(), null, string.Empty);
            return Ok(result);
        }
    }
}