using NewTemplateManager.Contracts.ResponseDTO.V1.auto;

namespace NewTemplateManager.Contracts.ResponseDTO.V1
{
    public record ModelResponseDTO(Guid GuidId, string ModelName, string ModelTypeName, ICollection<ModelVersionResponseDTO>? ModelVersions);

}