namespace NewTemplateManager.Contracts.RequestDTO.V1.auto
{
    public record ShellMaterialGetRequestByGuidDTO(Guid guid);
    public record ShellMaterialGetRequestByIdDTO(object Value);
    public record ShellMaterialGetRequestDTO(object Value);
    public record ShellMaterialCreateRequestDTO(string shellMaterialName, bool alloy, Guid guidId);
    public record ShellMaterialUpdateRequestDTO(string shellMaterialName, bool alloy, Guid guidId);
    public record ShellMaterialDeleteRequestDTO(Guid guid);
}