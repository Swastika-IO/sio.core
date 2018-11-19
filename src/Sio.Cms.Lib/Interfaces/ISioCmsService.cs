using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sio.Cms.Lib.Interfaces
{
    public interface ISioCmsService
    {
        T GetConfig<T>(string name);
        T GetConfig<T>(string name, string culture);
        T Translate<T>(string name, string culture);
        JObject GetTranslator(string culture);
        JObject GetSettings(string culture);
        string GetConnectionString(string name);
    }
}
