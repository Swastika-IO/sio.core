using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.IO.Cms.Lib
{
    public class SWCmsHelper
    {
        public static string GetFullPath(string[] subPaths)
        {
            string result = string.Empty;
            string strFormat = string.Empty;
            for (int i = 0; i < subPaths.Length; i++)
            {
                strFormat += @"{" + i + "}" + (i < subPaths.Length - 1 ? "/" : string.Empty);
            }
            return string.Format(strFormat, subPaths);
        }
    }
}
