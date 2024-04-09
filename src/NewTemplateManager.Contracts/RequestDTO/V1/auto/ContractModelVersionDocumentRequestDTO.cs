namespace NewTemplateManager.Contracts.RequestDTO.V1.auto
{
    public record ModelVersionDocumentGetRequestByGuidDTO(Guid guid);
    public record ModelVersionDocumentGetRequestByIdDTO(object Value);
    public record ModelVersionDocumentGetRequestDTO(object Value);
    public record ModelVersionDocumentCreateRequestDTO(int modelVersionId, string modelName, int modelVersionDocumentId, string documentDescription, string stage, string documentDrive, string documentPath, string documentname, DateTime timestamp, string userName, Guid guidId);
    public record ModelVersionDocumentUpdateRequestDTO(int modelVersionId, string modelName, int modelVersionDocumentId, string documentDescription, string stage, string documentDrive, string documentPath, string documentname, DateTime timestamp, string userName, Guid guidId);
    public record ModelVersionDocumentDeleteRequestDTO(Guid guid);
}