
using NewTemplateManager.Api.APIResponse;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;

namespace NewTemplateManager.Api.Extensions
{
    public static class EitherToActionResultExtensions
    {
        public static Task<IActionResult> ToActionResult<L, R>(this Task<Either<L, R>> either)
        {
            return either.Map(Match);
        }

        private static IActionResult Match<L, R>(this Either<L, R> either)
        {
            return either.Match<IActionResult>(
                Left: l => new BadRequestObjectResult(new ApiBadRequestResponse(400, l).ProblemDetails),
                Right: r => new OkObjectResult(r));
        }

        public static Task<IActionResult> ToEitherActionResult<L, R>(this Task<Either<L, R>> either)
        {
            return either.Map(MatchEitherActionResult);
        }

        private static IActionResult MatchEitherActionResult<L, R>(this Either<L, R> either)
        {
            return either.Match<IActionResult>(
                Left: l => new NotFoundObjectResult(new ApiBadRequestResponse(404, l).ProblemDetails),
                //Left: l => new NotFoundObjectResult(new ProblemDetails { Detail = "vbvfbfd", Title = "dggrfgrgrg" }),
                Right: r => new OkObjectResult(r));
        }

        public static Task<IActionResult> ToActionResultCreated<L, R>(this Task<Either<L, R>> either, string endPoint, object data)
        {
            return either.Map(x => MatchCreated(x, endPoint, data));
        }

        private static IActionResult MatchCreated<L, R>(this Either<L, R> either, string endPoint, object data)
        {
            return either.Match<IActionResult>(
                Left: l => new BadRequestObjectResult(new ApiBadRequestResponse(409, l).ProblemDetails),
                Right: r => new CreatedResult($"{endPoint}/{r}", data));
        }
    }
}
