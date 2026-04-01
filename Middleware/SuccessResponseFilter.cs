using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ApiDocumentation.OpenApi;

namespace ApiDocumentation.Middleware;

public class SuccessResponseFilter : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is ObjectResult objectResult)
        {
            var statusCode = objectResult.StatusCode ?? 200;

            if (statusCode >= 200 && statusCode < 300)
            {
                if (objectResult.Value is ProblemDetails)
                    return;

                var response = new ApiResponse<object>
                {
                    Success = true,
                    StatusCode = statusCode,
                    Message = ApiResponseMetadata.GetDefaultMessage(statusCode),
                    Data = objectResult.Value
                };

                objectResult.Value = response;
                objectResult.DeclaredType = response.GetType();
            }
        }

        else if (context.Result is StatusCodeResult statusCodeResult)
        {
            var statusCode = statusCodeResult.StatusCode;

            if (statusCode >= 200 && statusCode < 300)
            {
                var response = new ApiResponse<object>
                {
                    Success = true,
                    StatusCode = statusCode,
                    Message = ApiResponseMetadata.GetDefaultMessage(statusCode),
                    Data = null
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = statusCode
                };
            }
        }
    }
}
