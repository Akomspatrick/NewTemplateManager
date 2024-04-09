namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record ModelVersionDocumentGetRequestByGuidDTO(Guid guid);
    public  record ModelVersionDocumentGetRequestByIdDTO(Object Value);
    public  record ModelVersionDocumentGetRequestDTO(Object Value);
    public  record ModelVersionDocumentCreateRequestDTO(int  modelVersionId, string  modelName, int  modelVersionDocumentId, string  documentDescription, string  stage, Guid  documentGuid, string  documentname, DateTime  timestamp, string  userName, Guid  guidId );
    public  record ModelVersionDocumentUpdateRequestDTO(int  modelVersionId, string  modelName, int  modelVersionDocumentId, string  documentDescription, string  stage, Guid  documentGuid, string  documentname, DateTime  timestamp, string  userName, Guid  guidId);
    public  record ModelVersionDocumentDeleteRequestDTO(Guid guid);
}