namespace NewTemplateManager.Contracts.ResponseDTO.V1.auto
{

    // public record ModelResponseDTO(Guid GuidId, string ModelName, string ModelTypesName);
    //result.GuidId, result.ModelTypeName, result.ModelTypes.Select(x => new ModelTypeResponseDTO(x.GuidId, x.ModelTypeName, x.Value)))));        } 
    public record TestingModeGroupResponseDTO(string TestingModeGroupName, string testingMode, string description, Guid guidId);
}