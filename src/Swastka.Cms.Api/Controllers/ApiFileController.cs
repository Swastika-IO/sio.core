using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swastika.Api.Controllers;
using Swastika.Cms.Lib.Models;

namespace Swastka.IO.Cms.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/{culture}/ApiFile")]
    public class ApiFileController : BaseApiController<SiocCmsContext, SiocArticle>
    {

    }
}