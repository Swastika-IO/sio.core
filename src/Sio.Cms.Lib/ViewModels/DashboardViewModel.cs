using Sio.Cms.Lib.Models.Cms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sio.Cms.Lib.ViewModels
{
    public class DashboardViewModel
    {
        [JsonProperty("totalPage")]
        public int TotalPage { get; set; }

        [JsonProperty("totalArticle")]
        public int TotalArticle { get; set; }

        [JsonProperty("totalProduct")]
        public int TotalProduct { get; set; }

        [JsonProperty("totalModule")]
        public int TotalModule { get; set; }

        [JsonProperty("totalUser")]
        public int TotalUser { get; set; }

        public DashboardViewModel()
        {
            using (SioCmsContext context = new SioCmsContext())
            {
                TotalPage = context.SioPage.Count();
                TotalArticle = context.SioArticle.Count();
                TotalProduct = context.SioProduct.Count();
            }
        }
    }
}
