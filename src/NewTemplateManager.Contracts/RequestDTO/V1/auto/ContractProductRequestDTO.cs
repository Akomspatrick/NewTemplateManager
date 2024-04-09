namespace NewTemplateManager.Contracts.RequestDTO.V1.auto
{
    public record ProductGetRequestByGuidDTO(Guid guid);
    public record ProductGetRequestByIdDTO(object Value);
    public record ProductGetRequestDTO(object Value);
    public record ProductCreateRequestDTO(int productId, int modelVersionId, string modelName, int capacity, DateTime timestamp, string stage, string subStage, string salesOrderId, int cableLength, int inspectionResult, string defaultTestingMode, string TestingModeGroupName, string usedTestingMode, string thermexPurcharseOrderNo, string machiningPurcharseOrderNo, string steelPurcharseOrderNo, int batcNo, Guid guidId);
    public record ProductUpdateRequestDTO(int productId, int modelVersionId, string modelName, int capacity, DateTime timestamp, string stage, string subStage, string salesOrderId, int cableLength, int inspectionResult, string defaultTestingMode, string TestingModeGroupName, string usedTestingMode, string thermexPurcharseOrderNo, string machiningPurcharseOrderNo, string steelPurcharseOrderNo, int batcNo, Guid guidId);
    public record ProductDeleteRequestDTO(Guid guid);
}