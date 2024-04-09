namespace NewTemplateManager.Contracts.RequestDTO.V1.auto
{
    public record TestingModeGroupGetRequestByGuidDTO(Guid guid);
    public record TestingModeGroupGetRequestByIdDTO(string TestingModeGroupName);
    public record TestingModeGroupGetRequestDTO(object Value);
    public record TestingModeGroupCreateRequestDTO(string TestingModeGroupName, string testingMode, string description, Guid guidId);
    public record TestingModeGroupUpdateRequestDTO(string TestingModeGroupName, string testingMode, string description, Guid guidId);
    public record TestingModeGroupDeleteRequestDTO(Guid guid);
}