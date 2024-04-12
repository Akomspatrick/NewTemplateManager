

namespace NewTemplateManager.Contracts.RequestDTO.V1
{


    //public record ModelTypeCreateRequestDTO(Guid GuidId, string ModelTypeName, string TestingModeGroupName);


    //public record ModelTypeUpdateRequestDTO(Guid ModelTypeId, string ModelTypeName, string TestingModeGroupName);
    public record ModelTypeCreateRequestDTO(Guid GuidId, string ModelTypeName);


    public record ModelTypeUpdateRequestDTO(Guid GuidId, string ModelTypeName);
    public record ModelTypeGetRequestByGuidDTO(Guid GuidId);
    public record ModelTypeGetRequestByIdDTO(string ModelTypeId);
    public record ModelTypeGetRequestDTO(string ModelTypeName);
    public record ModelTypeDeleteRequestDTO(Guid guid);
}
