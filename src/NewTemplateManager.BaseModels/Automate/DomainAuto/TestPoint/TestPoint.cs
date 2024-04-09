using DocumentVersionManager.DomainBase;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class TestPoint  : BaseEntity
    {
        private TestPoint(){}
        public Int32 ModelVersionId    { get; init; } 
        public string ModelName    { get; init; }  = string.Empty; 
        public Int32 CapacityTestPoint    { get; init; } 
        public ModelVersion ModelVersion    { get; init; } 
        // public Guid GuidId    { get; init; } 
        
        public static TestPoint Create(Int32  modelVersionId, string  modelName, Int32  capacityTestPoint, Guid  guidId)
    {
    if (guidId == Guid.Empty)
    {
        throw new ArgumentException($"TestPoint Guid value cannot be empty {nameof(guidId)}");
    }
        return  new()
        {
            ModelVersionId = modelVersionId ,
            ModelName = modelName ,
            CapacityTestPoint = capacityTestPoint ,
            GuidId = guidId ,
        };
    }
    }
}