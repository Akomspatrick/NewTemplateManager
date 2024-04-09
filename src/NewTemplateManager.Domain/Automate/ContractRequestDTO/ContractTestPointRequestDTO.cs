namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record TestPointGetRequestByGuidDTO(Guid guid);
    public  record TestPointGetRequestByIdDTO(Object Value);
    public  record TestPointGetRequestDTO(Object Value);
    public  record TestPointCreateRequestDTO(int  modelVersionId, string  modelName, int  capacityTestPoint, Guid  guidId );
    public  record TestPointUpdateRequestDTO(int  modelVersionId, string  modelName, int  capacityTestPoint, Guid  guidId);
    public  record TestPointDeleteRequestDTO(Guid guid);
}