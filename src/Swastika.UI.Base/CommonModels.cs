using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.UI.Base
{
    public class ApiResult<T>
    {
        public int status { get; set; }
        public string responseKey { get; set; }
        public T data { get; set; }
        public string message { get; set; }
        public IEnumerable<string> errors { get; set; }
    }
    public class SWConstants
    {
        public enum ResponseKey
        {
            BadRequest = 400,
            NotFound = 404,
            OK = 200
        }      
    }
}
