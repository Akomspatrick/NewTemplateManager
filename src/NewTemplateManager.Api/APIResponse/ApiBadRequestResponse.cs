using NewTemplateManager.Domain.Errors;
using LanguageExt.Common;
using LanguageExt.Pipes;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace NewTemplateManager.Api.APIResponse
{
    public class ApiBadRequestResponse : ApiResponse
    {

        //public IEnumerable<string> Errors { get; }

        //public ApiBadRequestResponse(ModelStateDictionary modelState)
        //    : base(400)
        //{
        //    if (modelState.IsValid)
        //    {
        //        throw new ArgumentException("ModelState must be invalid", nameof(modelState));
        //    }

        //    Errors = modelState.SelectMany(x => x.Value.Errors)
        //        .Select(x => x.ErrorMessage).ToArray();
        //}
        //  public IEnumerable<string> Errors { get; }
        public ProblemDetails ProblemDetails { get; }
        public ApiBadRequestResponse(int status, object errors)
            : base(status)
        {
            try
            {
                // var error2 = (GeneralFailure)errors;
                GeneralFailure error = errors as GeneralFailure;
                ProblemDetails = new ProblemDetails
                {
                    //  Detail = exception.Message, //details are not passes to the client but are logged
                    Detail = $"{error.OriginalError} {error.Code}",
                    //Type = nameof(exception),
                    Title = error.ErrorDescription,//"An error occured from " + exception.Source,
                    Status = status,// (int)HttpStatusCode.InternalServerError,

                };
            }

            catch (Exception ex)
            {


                try
                {
                    var error = errors as string;
                    ProblemDetails = new ProblemDetails
                    {
                        //  Detail = exception.Message, //details are not passes to the client but are logged
                        Detail = $"{error}",
                        //Type = nameof(exception),
                        Title = error,//"An error occured from " + exception.Source,
                        Status = status,// (int)HttpStatusCode.InternalServerError,

                    };
                }
                catch (Exception)
                {
                    ProblemDetails = new ProblemDetails
                    {
                        //  Detail = exception.Message, //details are not passes to the client but are logged
                        Detail = $"Problem Found Please contact Admin",
                        //Type = nameof(exception),
                        Title = "Problem Found, Please contact Admin",//"An error occured from " + exception.Source,
                        Status = status,// (int)HttpStatusCode.InternalServerError,

                    };
                }


            }
        }
    }
}


