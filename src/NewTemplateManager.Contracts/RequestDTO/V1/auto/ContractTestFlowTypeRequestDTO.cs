namespace NewTemplateManager.Contracts.RequestDTO.V1.auto
{
    public record TestFlowTypeGetRequestByGuidDTO(Guid guid);
    public record TestFlowTypeGetRequestByIdDTO(object Value);
    public record TestFlowTypeGetRequestDTO(object Value);
    public record TestFlowTypeCreateRequestDTO(Guid GuidId, object Value);
    public record TestFlowTypeUpdateRequestDTO(object Value);
    public record TestFlowTypeDeleteRequestDTO(Guid guid);
}