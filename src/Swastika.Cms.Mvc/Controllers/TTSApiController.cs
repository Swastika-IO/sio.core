using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Swastika.Cms.Mvc.Controllers
{
    [Route("api/tts")]
    public class TTSApiController : BaseController<TTSApiController>
    {
        public TTSApiController(IHostingEnvironment env) : base(env)
        {
        }

        // POST api/values        
        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <param name="image">The img information.</param> Ex: { "base64": "", "fileFolder":"" }
        /// <returns></returns>
        [Route("uploadImage")]
        [HttpPost]
        public async Task<string> UploadImageAsync([FromForm] string fileFolder)
        {
            var files = Request.Form.Files;

            if (files.Count > 0)
            {
                var fileUpload = files.FirstOrDefault();

                string folderPath = string.Format("Uploads/{0}", fileFolder);
                //return ImageHelper.ResizeImage(Image.FromStream(fileUpload.OpenReadStream()), System.IO.Path.Combine(_env.WebRootPath, folderPath));
                //var fileName = await Common.UploadFileAsync(filePath, files.FirstOrDefault());
                return string.Format("/{0}", await UploadFileAsync(files.FirstOrDefault(), folderPath));
            }
            else
            {
                return string.Empty;
            }


        }
    }
}
