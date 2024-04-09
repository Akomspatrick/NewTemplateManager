namespace NewTemplateManager.Contracts.RequestDTO.V1
{
    public record ModelGetRequestByGuidDTO(Guid guid);
    public record ModelGetRequestByIdDTO(string ModelName);
    public record ModelGetRequestDTO(string ModelName);
    public record ModelCreateRequestDTO(Guid GuidId, string ModelName, string ModelTypesName);
    public record ModelUpdateRequestDTO(Guid ModelId, string ModelName, string ModelTypesName);
    public record ModelDeleteRequestDTO(Guid guid);
}


