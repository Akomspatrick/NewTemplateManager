namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record ModelVersionDocumentGetRequestByGuidDTO(Guid guid);
    public  record ModelVersionDocumentGetRequestByIdDTO(String ObjectNameId);
    public  record ModelVersionDocumentGetRequestDTO(Object Value);
    public  record ModelVersionDocumentCreateRequestDTO(Int32  modelVersionId, string  modelName, Int32  modelVersionDocumentId, string  documentDescription, string  stage, string  documentDrive, string  documentPath, Guid  documentGuid, string  documentname, DateTime  timestamp, string  userName, Guid  guidId );
    public  record ModelVersionDocumentUpdateRequestDTO(Int32  modelVersionId, string  modelName, Int32  modelVersionDocumentId, string  documentDescription, string  stage, string  documentDrive, string  documentPath, Guid  documentGuid, string  documentname, DateTime  timestamp, string  userName, Guid  guidId);
    public  record ModelVersionDocumentDeleteRequestDTO(Guid guid);
}