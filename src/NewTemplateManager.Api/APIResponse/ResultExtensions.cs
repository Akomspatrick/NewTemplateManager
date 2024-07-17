using Microsoft.AspNetCore.Mvc;
using NewTemplateManager.Domain.Errors;

namespace NewTemplateManager.Api.APIResponse
{
    public static class ResultExtensions
    {
        public static IActionResult ToProblemDetails(this Object theerror)
        {
            // return new BadRequestObjectResult(new ApiBadRequestResponse(status, error).ProblemDetails);
            var error = theerror as GeneralFailure;
            var Problems = new ProblemDetails
            {
                Detail = $"{error.OriginalError} {error.Code}",
                Title = error.ErrorDescription,
                Status = (int)error.FailureType,
                Type = error.Code,
                Instance = error.OriginalError

            };

            return new ObjectResult(Problems);

        }
    }

}

