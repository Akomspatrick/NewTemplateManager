namespace NewTemplateManager.Contracts.RequestDTO
{
    public  record ShellMaterialGetRequestByGuidDTO(Guid guid);
    public  record ShellMaterialGetRequestByIdDTO(String ObjectNameId);
    public  record ShellMaterialGetRequestDTO(Object JSONValue);
    public  record ShellMaterialCreateRequestDTO(string  shellMaterialName, bool  alloy, Guid  guidId );
    public  record ShellMaterialUpdateRequestDTO(string  shellMaterialName, bool  alloy, Guid  guidId);
    public  record ShellMaterialDeleteRequestDTO(Guid guid);
}