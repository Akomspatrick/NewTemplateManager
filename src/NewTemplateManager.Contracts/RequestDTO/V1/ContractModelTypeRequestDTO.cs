

namespace NewTemplateManager.Contracts.RequestDTO.V1
{


    public record ModelTypeCreateRequestDTO(Guid GuidId, string ModelTypeName, string TestingModeGroupName);


    public record ModelTypeUpdateRequestDTO(Guid ModelTypeId, string ModelTypeName, string TestingModeGroupName);
    public record ModelTypeGetRequestByGuidDTO(Guid ModelTypeId);
    public record ModelTypeGetRequestByIdDTO(string ModelTypeId);
    public record ModelTypeGetRequestDTO(string ModelTypeName);
    public record ModelTypeDeleteRequestDTO(Guid guid);
}
