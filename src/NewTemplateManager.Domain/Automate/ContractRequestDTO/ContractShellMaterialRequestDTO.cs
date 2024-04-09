namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record ShellMaterialGetRequestByGuidDTO(Guid guid);
    public  record ShellMaterialGetRequestByIdDTO(Object Value);
    public  record ShellMaterialGetRequestDTO(Object Value);
    public  record ShellMaterialCreateRequestDTO(string  shellMaterialName, Boolean  alloy, Guid  guidId );
    public  record ShellMaterialUpdateRequestDTO(string  shellMaterialName, Boolean  alloy, Guid  guidId);
    public  record ShellMaterialDeleteRequestDTO(Guid guid);
}