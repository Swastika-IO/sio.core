using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.Cms.Lib.ViewModels.Api
{
    public class ApiFilePageViewModel
    {
        [JsonProperty("files")]
        public List<FileViewModel> Files { get; set; }
        [JsonProperty("directories")]
        public List<string> Directories { get; set; }
    }
}
