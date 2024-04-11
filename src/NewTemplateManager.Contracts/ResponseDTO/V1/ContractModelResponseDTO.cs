using NewTemplateManager.Contracts.ResponseDTO.V1;

namespace NewTemplateManager.Contracts.ResponseDTO.V1
{
    public record ModelResponseDTO(Guid GuidId, string ModelName, string ModelTypeName, ICollection<ModelVersionResponseDTO>? ModelVersions);

}