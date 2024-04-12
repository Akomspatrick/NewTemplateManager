namespace NewTemplateManager.Contracts.RequestDTO.V1
{
    public  record ModelGetRequestByGuidDTO(Guid guid);
    public  record ModelGetRequestByIdDTO(String EntityNameId);
    public  record ModelGetRequestDTO(Object JSONValue);
    public  record ModelCreateRequestDTO(string  modelName, string  modelTypeName, Guid  guidId );
    public  record ModelUpdateRequestDTO(string  modelName, string  modelTypeName, Guid  guidId);
    public  record ModelDeleteRequestDTO(Guid guid);
}