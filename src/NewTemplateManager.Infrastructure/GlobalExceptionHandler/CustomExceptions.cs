using System;

namespace NewTemplateManager.Infrastructure.GlobalExceptionHandler
{
    public class NotFoundException : Exception
    {
        public string Type = "A07";
        public string Title = "Data Not Found  in Repository";
        public int statusCode = 404;
        public NotFoundException(string name, object key)
            : base("Data Not Found  in Repository")
        {
        }
    }

    public class DuplicateException : Exception
    {
        public string Type = "A01";
        public string Title = "Data  already Exist in Repository";
        public int statusCode = 409;
        public DuplicateException(string name, object key)
            : base("Data  already Exist in Repository")
        {
        }
    }
}
//   public static GeneralFailure DuplicateEntity(string? value) => new("A01", $"{value} ", "Data  already Exist in Repository", FailureType.DuplicateFailure);
