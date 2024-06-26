using NewTemplateManager.DomainBase;
namespace NewTemplateManager.Domain.Entities
{
    public partial class Model  : BaseEntity
    {
        private Model(){}
        public string ModelName    { get; init; }  = string.Empty; 
        public string ModelTypeName    { get; init; }  = string.Empty; 
        public ModelType? ModelType    { get; init; } 
        // public Guid GuidId    { get; init; } 
        
        public static Model Create(string  modelName, string  modelTypeName, Guid  guidId)
    {
    if (guidId == Guid.Empty)
    {
        throw new ArgumentException($"Model Guid value cannot be empty {nameof(guidId)}");
    }
        return  new()
        {
            ModelName = modelName ,
            ModelTypeName = modelTypeName ,
            GuidId = guidId ,
        };
    }
    }
}