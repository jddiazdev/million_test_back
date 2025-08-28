using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using million.api.Responses;
namespace million.api.Filters
{
  public class ApiResponseFilter : IActionFilter
  {
    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
      if (context.Result is ObjectResult objectResult)
      {
        if (objectResult.Value != null)
        {
          context.Result = new ObjectResult(
              ApiResponse<object>.Success("Operación exitosa", objectResult.Value, objectResult.StatusCode ?? 200)
          )
          {
            StatusCode = objectResult.StatusCode
          };
        }
      }
      else if (context.Result is StatusCodeResult statusCodeResult)
      {
        context.Result = new ObjectResult(
            ApiResponse<string>.Success("Operación completada", "OK", statusCodeResult.StatusCode)
        )
        {
          StatusCode = statusCodeResult.StatusCode
        };
      }
    }

  }

}

