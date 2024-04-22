using NewTemplateManager.DomainBase;
namespace NewTemplateManager.Domain.Entities
{
    public partial class ModelType  : BaseEntity
    {
        private ModelType(){}
        public string ModelTypeName    { get; init; }  = string.Empty; 
        // public Guid GuidId    { get; init; } 
        
        public static ModelType Create(string  modelTypeName, Guid  guidId)
    {
    if (guidId == Guid.Empty)
    {
        throw new ArgumentException($"ModelType Guid value cannot be empty {nameof(guidId)}");
    }
        return  new()
        {
            ModelTypeName = modelTypeName ,
            GuidId = guidId ,
        };
    }
    }
}