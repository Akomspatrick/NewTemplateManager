namespace NewTemplateManager.Contracts.ResponseDTO.V1
{
    public record SampleModelResponseDTO(Guid? SampleModelId, string? SampleModelName, ICollection<ModelResponseDTO>? Models);

}