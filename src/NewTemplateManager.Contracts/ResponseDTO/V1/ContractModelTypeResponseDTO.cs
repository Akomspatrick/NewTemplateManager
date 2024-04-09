namespace NewTemplateManager.Contracts.ResponseDTO.V1
{
    public record ModelTypeResponseDTO(Guid? ModelTypeId, string? ModelTypeName, ICollection<ModelResponseDTO>? Models);

}