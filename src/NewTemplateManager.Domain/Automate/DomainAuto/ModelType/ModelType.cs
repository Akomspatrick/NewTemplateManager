using DocumentVersionManager.DomainBase;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ModelType  : BaseEntity
    {
        private ModelType(){}
        public string ModelTypeName    { get; init; }  = string.Empty; 
        private  List <Model> _Models { get;  set;}  = new List<Model>();
        public  IReadOnlyCollection<Model> Models => _Models;
        public Guid GuidId    { get; init; } 
        
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