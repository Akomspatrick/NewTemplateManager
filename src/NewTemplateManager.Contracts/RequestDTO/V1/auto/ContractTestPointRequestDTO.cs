namespace NewTemplateManager.Contracts.RequestDTO.V1.auto
{
    public record TestPointGetRequestByGuidDTO(Guid guid);
    public record TestPointGetRequestByIdDTO(object Value);
    public record TestPointGetRequestDTO(object Value);
    public record TestPointCreateRequestDTO(int modelVersionId, string modelName, int capacityTestPoint, Guid guidId);
    public record TestPointUpdateRequestDTO(int modelVersionId, string modelName, int capacityTestPoint, Guid guidId);
    public record TestPointDeleteRequestDTO(Guid guid);
}