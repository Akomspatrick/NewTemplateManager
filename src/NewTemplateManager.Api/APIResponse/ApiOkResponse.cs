namespace NewTemplateManager.Api.APIResponse
{
    public class ApiOkResponse : ApiResponse
    {
        public object Result { get; }
        string? Message { get; }
        public ApiOkResponse(object result, string? message = "")
            : base(200)
        {
            Result = result;
            Message = message;
        }
    }
}
