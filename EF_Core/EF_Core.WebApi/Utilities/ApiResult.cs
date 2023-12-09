using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EF_Core.WebApi.Utilities
{
    public class ApiResult
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public ApiResultStatusCode StatusCode { get; set; }
        public ApiResult(bool isSuccess, ApiResultStatusCode statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
        }
        public static implicit operator ApiResult(OkResult okResult)
        {
            return new ApiResult(true, ApiResultStatusCode.Succeded);
        }
        public static implicit operator ApiResult(BadRequestResult result)
        {
            return new ApiResult(false, ApiResultStatusCode.Failed);
        }

        public static implicit operator ApiResult(BadRequestObjectResult result)
        {
            var message = result.Value?.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new ApiResult(false, ApiResultStatusCode.Failed, message);
        }

        public static implicit operator ApiResult(ContentResult result)
        {
            return new ApiResult(true, ApiResultStatusCode.Failed, result.Content);
        }

        public static implicit operator ApiResult(NotFoundResult result)
        {
            return new ApiResult(false, ApiResultStatusCode.Failed);
        }
    }

    public class ApiResult<TData> : ApiResult
        where TData : class
    {
        public ApiResult(bool isSuccess, ApiResultStatusCode statusCode, TData data, string message = null)
            : base(isSuccess, statusCode, message)
        {
            Data = data;
        }

        public TData Data { get; set; }
        #region Implicit Operators
        public static implicit operator ApiResult<TData>(TData data)
        {
            return new ApiResult<TData>(true, ApiResultStatusCode.Succeded, data);
        }

        public static implicit operator ApiResult<TData>(OkResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatusCode.Succeded, null);
        }

        public static implicit operator ApiResult<TData>(OkObjectResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatusCode.Succeded, (TData)result.Value);
        }

        public static implicit operator ApiResult<TData>(BadRequestResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatusCode.Failed, null);
        }

        public static implicit operator ApiResult<TData>(BadRequestObjectResult result)
        {
            var message = result.Value?.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new ApiResult<TData>(false, ApiResultStatusCode.Failed, null, message);
        }

        public static implicit operator ApiResult<TData>(ContentResult result)
        {
            return new ApiResult<TData>(true, ApiResultStatusCode.Failed, null, result.Content);
        }

        public static implicit operator ApiResult<TData>(NotFoundResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatusCode.Failed, null);
        }

        public static implicit operator ApiResult<TData>(NotFoundObjectResult result)
        {
            return new ApiResult<TData>(false, ApiResultStatusCode.Failed, (TData)result.Value);
        }
        #endregion
    }
}
