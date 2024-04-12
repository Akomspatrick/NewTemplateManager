namespace NewTemplateManager.Domain.Errors
{


    public record GeneralFailure(string Code, string OriginalError, string ErrorDescription) : IGeneralFailure
    {
        public static GeneralFailure None => new(string.Empty, "NONE", string.Empty);
    }
    public static class GeneralFailures
    {
        public static GeneralFailure DuplicatemodelTypesName(string? value) => new("A01", $"{value} ", "Data  already Exist in Repository");
        public static GeneralFailure ErrorRetrievingListDataFromRepository(string? value) => new("A02", $"{value} ", "Error Retrieving  List From  Repository");
        public static GeneralFailure ErrorRetrievingSingleDataFromRepository(string? value) => new("A03", $"{value} ", "Error Retrieving  Single Entity From  Repository/Null Result");
        public static GeneralFailure ProblemAddingEntityIntoDbContext(string? value) => new("A04", $"{value} ", "Error Adding entity  into to Repository");
        public static GeneralFailure ProblemDeletingEntityFromRepository(string? value) => new("A05", $"{value}", "Error Deleting entity  in Repository");
        public static GeneralFailure ProblemUpdatingEntityInRepository(string? value) => new("A06", $"{value} ", "Error Updating entity  in Repository");
        public static GeneralFailure DataNotFoundInRepository(string? value) => new("A07", $"{value} ", "Data Not Found  in Repository");
        public static GeneralFailure ExceptionThrown(string where, string? summary, string details) => new("A08", $": Exception Thrown : {summary}", $"{details} ");

        //    [Description("Data  already Exist in Repository")]
        //    DuplicatemodelTypesName,
        //    [Description("Error Retrieving  List From  Repository")]
        //    ErrorRetrievingListDataFromRepository,
        //    [Description("Error Retrieving  Single Entity From  Repository/Null Result")]
        //    ErrorRetrievingSingleDataFromRepository,
        //    [Description("Error Adding entity  into to Repository")]
        //    ProblemAddingEntityIntoDbContext,
        //    [Description("Error Deleting entity  in Repository")]
        //    ProblemDeletingEntityFromRepository,
        //    [Description("Error Updating entity  in Repository")]
        //    ProblemUpdatingEntityInRepository,
        //    [Description("Data Not Found  in Repository")]
        //    DataNotFoundInRepository,

    }
    //public static class GeneralFailuresFailuresExtensions
    //{

    //    public static string GetEnumDisplayName(this Enum value)
    //    {
    //        FieldInfo fi = value.GetType().GetField(value.ToString());

    //        DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

    //        if (attributes != null && attributes.Length > 0)
    //            return attributes[0].Name;
    //        else
    //            return value.ToString();
    //    }
    //    public static string GetEnumDescription(this Enum value)
    //    {
    //        FieldInfo fi = value.GetType().GetField(value.ToString());

    //        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

    //        if (attributes != null && attributes.Length > 0)
    //            return attributes[0].Description;
    //        else
    //            return value.ToString();
    //    }
    //}
}
