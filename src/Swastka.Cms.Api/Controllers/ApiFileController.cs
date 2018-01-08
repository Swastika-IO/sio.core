using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swastika.Api.Controllers;
using Swastika.Cms.Lib.Models;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.ViewModels;

namespace Swastka.IO.Cms.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/file")]
    public class ApiFileController : BaseApiController
    {

        // POST api/values        
        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <param name="image">The img information.</param> Ex: { "base64": "", "fileFolder":"" }
        /// <returns></returns>
        [Route("uploadFile")]
        [HttpPost]
        public IActionResult Edit(FileViewModel template)
        {
            if (ModelState.IsValid)
            {
                var result = FileRepository.Instance.SaveWebFile(template);
                return GetSuccessResult(result);
            }
            return GetErrorResult("failed", "invalid");
        }
    }
}