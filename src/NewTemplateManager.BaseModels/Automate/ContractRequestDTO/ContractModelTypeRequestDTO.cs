namespace NewTemplateManager.Contracts.RequestDTO.V1
{
    public  record ModelTypeGetRequestByGuidDTO(Guid guid);
    public  record ModelTypeGetRequestByIdDTO(String ObjectNameId);
    public  record ModelTypeGetRequestDTO(Object JSONValue);
    public  record ModelTypeCreateRequestDTO(string  modelTypeName, Guid  guidId );
    public  record ModelTypeUpdateRequestDTO(string  modelTypeName, Guid  guidId);
    public  record ModelTypeDeleteRequestDTO(Guid guid);
}