﻿namespace NewTemplateManager.Domain.Errors
{
    public interface IGeneralFailure
    {
        string Code { get; init; }
        string ErrorDescription { get; init; }
        string OriginalError { get; init; }

        //void Deconstruct(out string Code, out string ErrorType, out string ErrorDescription);
        //bool Equals(GeneralFailure? other);
        //bool Equals(object? obj);
        //int GetHashCode();
        //string ToString();
    }
}