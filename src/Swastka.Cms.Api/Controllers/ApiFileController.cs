// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Swastika.Api.Controllers;
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
        /// <param name="image">The img information.</param>
        /// <param name="template"></param> Ex: { "base64": "", "fileFolder":"" }
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
