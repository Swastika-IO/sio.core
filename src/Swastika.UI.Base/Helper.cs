using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.UI.Base
{
    public class ApiHelper<T>
    {
        public static ApiResult<T> GetResult(int status, T data, string responseKey, IEnumerable<string> errors, string message)
        {
            ApiResult<T> result = new ApiResult<T>()
            {
                status = status,
                responseKey = responseKey,
                data = data,
                errors = errors,
                message = message,
            };

            return result;
        }
    }
}
