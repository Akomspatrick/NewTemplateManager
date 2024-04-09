namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record TestingModeGroupGetRequestByGuidDTO(Guid guid);
    public  record TestingModeGroupGetRequestByIdDTO(String ObjectNameId);
    public  record TestingModeGroupGetRequestDTO(Object Value);
    public  record TestingModeGroupCreateRequestDTO(string  testingModeGroupName, string  defaultTestingMode, string  description, Guid  guidId );
    public  record TestingModeGroupUpdateRequestDTO(string  testingModeGroupName, string  defaultTestingMode, string  description, Guid  guidId);
    public  record TestingModeGroupDeleteRequestDTO(Guid guid);
}